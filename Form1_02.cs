using System;
using System.IO;
using System.Media;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxWMPLib;
using Microsoft.Win32;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Http;
using NAudio.Wave;

namespace App_Spotify
{
    public partial class LoginForm : Form
    {
        
        private const string YourClientId = "fe2aa9ba80024af0ace2ae28b9dcab6b";
        private const string YourClientSecret = "e0d9ca2234204bfcb5b1bc36735107b9";
        private const string RedirectUri = "http://localhost:5000/callback/";
        private SpotifyClient spotify;
        private string access_token, refresh_token = null;
        private DateTime expiring;
        private SpotifyClientConfig config;
        private Paging<FullPlaylist> library;
        private FullPlaylist current_playlist;
        private SoundPlayer soundPlayer;
        

        public LoginForm()
        {
            InitializeComponent();
            config = SpotifyClientConfig.CreateDefault();
            ReadRefreshToken();
            if (refresh_token == null)
                AuthenticateUser();
            else
                RefreshAccessToken();
            GetSpotifyClient();
            GetPlaylists();
        }

        private void Btn_Playlists_Click(object sender, EventArgs e)
        {
            
        }

        public void GetSpotifyClient()
        {
            spotify = new SpotifyClient(config.WithToken(access_token));
        }

        private void AuthenticateUser()
        {
            if (refresh_token != null)
            {
                RefreshAccessToken();
                return;
            }
            try
            {
                // Verwende HttpListener für callback response
                using (HttpListener listener = new HttpListener())
                {
                    listener.Prefixes.Add(RedirectUri);
                    listener.Start();

                    // Erstelle URI Anfrage
                    var request = new LoginRequest(new Uri(RedirectUri), YourClientId, LoginRequest.ResponseType.Code)
                    {
                        Scope = new[] { Scopes.UserReadPrivate, Scopes.UserReadEmail }
                    };
                    var uri = request.ToUri();

                    // Öffne Anfrage im Browser und speichere Authorisierungscode
                    System.Diagnostics.Process.Start(uri.OriginalString);
                    HttpListenerContext context = listener.GetContext();
                    string authorizationCode = context.Request.QueryString["code"];
                    listener.Close();

                    // Verwende Autorisierungscode und speichere nachgefragte Tokens
                    var response = new OAuthClient().RequestToken(
                                    new AuthorizationCodeTokenRequest(YourClientId, YourClientSecret, authorizationCode, new Uri(RedirectUri)));
                    access_token = response.Result.AccessToken;
                    refresh_token = response.Result.RefreshToken;
                    expiring = response.Result.CreatedAt + TimeSpan.FromSeconds(response.Result.ExpiresIn);
                }
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }

            FileStream fs = new FileStream("Session.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(refresh_token);
            sw.Close(); fs.Close();
        }

        private void ReadRefreshToken()
        {
            if (File.Exists("Session.txt"))
            {
                FileStream fs = new FileStream("Session.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                refresh_token = sr.ReadToEnd();
                sr.Close(); fs.Close();
            }
        }

        private void RefreshAccessToken()
        {
            if (access_token == null || expiring >= DateTime.Now)
            {
                    var response = new OAuthClient().RequestToken(
                                new AuthorizationCodeRefreshRequest(YourClientId, YourClientSecret, refresh_token));

                    access_token = response.Result.AccessToken;
                    expiring = response.Result.CreatedAt + TimeSpan.FromSeconds(response.Result.ExpiresIn);
                    spotify = new SpotifyClient(access_token);
                }
        }

        private async void lbx_Playlists_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = lbx_Playlists.SelectedItem.ToString();
            current_playlist = library.Items[lbx_Playlists.SelectedIndex];
            await GetPlaylistTracks();
            lbx_Tracks.Items.Clear();
            foreach (PlaylistTrack<IPlayableItem> item in current_playlist.Tracks.Items)
            {
                if (item.Track is FullTrack track)
                    lbx_Tracks.Items.Add(track.Name);
                if (item.Track is FullEpisode episode)
                    lbx_Tracks.Items.Add(episode.Name);
            }
            
        }

        public async Task GetPlaylistTracks()
        {
            RefreshAccessToken();
            try
            {
                current_playlist = await spotify.Playlists.Get(current_playlist.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Abrufen der Playlist: {ex.Message}");
            }
        }

        public async void GetPlaylists()
        {
            RefreshAccessToken();
            try
            {
                library = await spotify.Playlists.CurrentUsers();
                int length = 0;
                foreach (var playlist in library.Items)
                {
                    string item = $"{playlist.Name}\r\n";
                    if (length < item.Length)
                        length = item.Length;
                    lbx_Playlists.Items.Add(item);
                }
                lbx_Playlists.Width = length*5+20;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Abrufen der Playlists: {ex.Message}");
            }
        }

        private void lbx_Tracks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (current_playlist.Tracks.Items[lbx_Tracks.SelectedIndex].Track is FullTrack track) 
            {
                string url = track.Href.Replace("https://", "http://");
                PlayTrack(url);
            }
            

            
        }

        private void PlayTrack(string trackUrl)
        {
            RefreshAccessToken();

            using (var webClient = new WebClient())
            {
                // Speichern des Streams lokal (temporär)
                var tempFile = "temp_audio.mp3";
                webClient.DownloadFile(trackUrl, tempFile);

                // Verwenden des SoundPlayer, um die lokale Datei abzuspielen
                using (var soundPlayer = new SoundPlayer(tempFile))
                {
                    soundPlayer.Play();
                    // Hier kannst du auf das Ende des Abspielens warten oder andere Aktionen ausführen.
                }
            }

        }

    }
}