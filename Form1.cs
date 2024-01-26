using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using SpotifyAPI.Web;
using App_Spotify_Web;

namespace App_Spotify
{
    public partial class SpotifyRandomizer : Form
    {

        private Authentication authenticating;
        private Paging<FullPlaylist> library;
        private FullPlaylist current_playlist;
        private List<Device> devices;
        private List<FullTrack> queue;
        private PlayerClient player;
        private FullTrack NowPlaying;

        public SpotifyRandomizer()
        {
            InitializeComponent();
            initializing();
        }

        private void initializing()
        {
            authenticating = new Authentication();
            queue = new List<FullTrack>();
            player = (PlayerClient)authenticating.GetSpotifyClient.Player;
            Lbl_User.Text = authenticating.GetSpotifyClient.UserProfile.Current().Result.DisplayName;
            GetPlaylists();
            GetDevices();
        }

        /// <summary>
        /// User Interface and Player control
        /// </summary>

        private async void Lbx_Playlists_SelectedIndexChanged(object sender, EventArgs e)
        {
            current_playlist = library.Items[Lbx_Playlists.SelectedIndex];
            await GetPlaylistTracks();
            Lbx_Tracks.Items.Clear();
            foreach (PlaylistTrack<IPlayableItem> item in current_playlist.Tracks.Items)
            {
                if (item.Track is FullTrack track)
                    Lbx_Tracks.Items.Add(track.Name);
                if (item.Track is FullEpisode episode)
                    Lbx_Tracks.Items.Add(episode.Name);
            }
        } // Load Tracks to Interface if selected Playlist changes

        private void Btn_ChangeDevice_Click(object sender, EventArgs e)
        {
            if (devices == null || devices.Count == 0) return;
            PlayerStateTimer.Stop();
            string[] dib = new string[1];
            dib[0] = devices[Lbx_Devices.SelectedIndex].Id;
            PlayerTransferPlaybackRequest request = new PlayerTransferPlaybackRequest(dib);
            player.TransferPlayback(request);
            player.ResumePlayback();
            PlayerStateTimer.Start();
        } // Change wich Device should Play the music

        private void Btn_ReLogIn_Click(object sender, EventArgs e)
        {
            authenticating.AuthenticateUser();
            initializing();
        } // Open Login Window in Standard Browser for authentication

        private void Btn_AddToQuery_Click(object sender, EventArgs e)
        {
            if (devices == null || devices.Count == 0) return;
            var track = (FullTrack)current_playlist.Tracks.Items[Lbx_Tracks.SelectedIndex].Track;
            PlayerAddToQueueRequest request = new PlayerAddToQueueRequest(track.Uri);
            player.AddToQueue(request);
        } // Add selected Track in Lbx_Tracks to Player Queue

        private void Btn_TogglePlay_Click(object sender, EventArgs e)
        {
            if (devices == null || devices.Count == 0) return;
            if (player.GetCurrentPlayback().Result.IsPlaying)
            {
                player.PausePlayback();
                Btn_TogglePlay.Text = "|>";
            }
            else
            {
                player.ResumePlayback();
                Btn_TogglePlay.Text = "||";
            }
        } // Button to Play/Pause

        private void Btn_Back_Click(object sender, EventArgs e)
        {
            if (devices == null || devices.Count == 0) return;
            player.SkipPrevious();
        } // Button to skip to previouse Track

        private void Btn_Forward_Click(object sender, EventArgs e)
        {
            if (devices == null || devices.Count == 0) return;
            player.SkipNext();
        } // Button to skip to next Track

        private void Btn_Start_Playlist_Click(object sender, EventArgs e)
        {
            if (devices == null || devices.Count == 0) return;
            Random rnd = new Random();
            PlayerResumePlaybackRequest request = new PlayerResumePlaybackRequest();

            int offset = rnd.Next(0, current_playlist.Tracks.Items.Count);
            request.OffsetParam.Position = offset;
            request.OffsetParam = new PlayerResumePlaybackRequest.Offset();
            request.ContextUri = current_playlist.Uri;
            player.ResumePlayback(request);

            if (Cbx_RealShuffle.Checked)
            {
                AddShuffleToQueue();
            }
        } // Start selected Playlist with random starting Track

        private void AddShuffleToQueue()
        {
            Random rnd = new Random();
            for (int i = 0; i < 50; i++)
            {
                int next = rnd.Next(Lbx_Tracks.Items.Count - 1);
                var track = (FullTrack)current_playlist.Tracks.Items[next].Track;
                PlayerAddToQueueRequest Qrequest = new PlayerAddToQueueRequest(track.Uri);
                player.AddToQueue(Qrequest);
            }
        } // Add 50 random Tracks from current Playlist to queue

        private void Pb_Time_Click(object sender, EventArgs e)
        {
            if (devices == null || devices.Count == 0 || !player.GetCurrentPlayback().Result.IsPlaying) return;
            MouseEventArgs mouseEventArgs = (MouseEventArgs)e;

            double progress = 100 / (double)Pb_Time.Width * (double)mouseEventArgs.X;
            int progressMs = Convert.ToInt32((double)Pb_Time.Maximum / 100 * progress);
            Pb_Time.Value = progressMs;

            PlayerSeekToRequest request = new PlayerSeekToRequest(progressMs);
            player.SeekTo(request);
        } // Set Time of Song in relation of Progress Bar

        /// <summary>
        /// Update Timers
        /// </summary>

        private void GetTrackProgressTimer_Tick(object sender, EventArgs e)
        {
            if (devices == null || devices.Count == 0) return;
            if (NowPlaying == null)
                GetPlayerState();
            GetTrackProgress();
        } // Timer to call GetTrackProgress Method

        private void PlayerStateTimer_Tick(object sender, EventArgs e)
        {
            if (devices != null)
                GetPlayerState();
            if (NowPlaying != null && !GetTrackProgressTimer.Enabled) { GetTrackProgressTimer.Start(); }
        } // Timer Tick Event to get Status of Player

        private void GetDeviceTimer_Tick(object sender, EventArgs e)
        {
            GetDevices();
        } //Timer to Get avaiable Devices



        /// <summary>
        /// Request Methods
        /// </summary>

        private void GetTrackProgress()
        {
            var state = player.GetCurrentPlayback().Result;
            if (state.IsPlaying)
            {
                FullTrack stateTrack = (FullTrack)state.Item;
                if (stateTrack.Id != NowPlaying.Id) { GetPlayerState(); }
                Pb_Time.Value = state.ProgressMs;
                Lbl_PlaylingTrack_Duration.Text = TimeSpan.FromMilliseconds(NowPlaying.DurationMs).ToString(@"mm\:ss");
                Lbl_PlayingTrack_Timer.Text = TimeSpan.FromMilliseconds(state.ProgressMs).ToString(@"mm\:ss");
            }
        } // Get currently playling Tracks progress and update Interface

        private void GetPlayerState()
        {
            var state = player.GetCurrentPlayback().Result;
            if (state == null || !state.IsPlaying) { Btn_TogglePlay.Text = "|>"; return; }
            Btn_TogglePlay.Text = "||";

            var resultqueue = player.GetQueue().Result;

            FullTrack Next = (FullTrack)resultqueue.Queue[0];
            if (queue.Count > 0 && Next.Id == queue[0].Id)
                return;
            queue.Clear();

            List<string> result = new List<string>();
            foreach (var playableItem in resultqueue.Queue)
            {
                if (playableItem is FullTrack track)
                {
                    result.Add(track.Name);
                    queue.Add(track);
                }
            }

            // Update Interface
            Lbx_Query.DataSource = result;
            NowPlaying = (FullTrack)resultqueue.CurrentlyPlaying;
            Pb_PlayingTrack_Image.ImageLocation = NowPlaying.Album.Images[0].Url;
            Lbl_PlayingTrack_Name.Text = NowPlaying.Name;
            Pb_Time.Maximum = NowPlaying.DurationMs;

            string Artists = "";
            foreach (var artist in NowPlaying.Artists)
                Artists += artist.Name + ", ";
            Lbl_PlayingTrack_Artist.Text = Artists.Remove(Artists.Length - 2);

        } // Method Get State of Player, Update Interface if playing

        private void GetDevices()
        {
            devices = new List<Device>();
            List<string> result = new List<string>();
            var sessions = authenticating.GetSpotifyClient.Player.GetAvailableDevices().Result;
            if (devices == sessions.Devices) { return; }

            foreach (var device in sessions.Devices)
            {
                result.Add(device.Name);
                devices.Add(device);
            }
            Lbx_Devices.DataSource = result;
            if (devices.Count > 0 && !PlayerStateTimer.Enabled) { PlayerStateTimer.Start(); }
        } // Get Devices and start PlayerStateTimer

        public async Task GetPlaylistTracks()
        {
            current_playlist = await authenticating.GetSpotifyClient.Playlists.Get(current_playlist.Id);
        } // Get Tracks of selected Playlist

        public async void GetPlaylists()
        {
            library = await authenticating.GetSpotifyClient.Playlists.CurrentUsers();
            int length = 0;
            foreach (var playlist in library.Items)
            {
                string item;
                if (playlist.Name != "")
                    item = $"{playlist.Name}\r\n";
                else
                    item = "[NoName]\r\n";
                if (length < item.Length)
                    length = item.Length;
                Lbx_Playlists.Items.Add(item);
            }
        } //Get Current Users Playlist
    }
}