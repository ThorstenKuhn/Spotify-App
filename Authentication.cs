using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace App_Spotify_Web
{
    class Authentication
    {
        private string YourClientId = "";
        private string YourClientSecret = "";
        private string RedirectUri = "";
        private string access_token, refresh_token;
        private DateTime expiring;
        private SpotifyClient spotify;

        public Authentication()
        {
            GetClientSettings();
            if (refresh_token == null)
                AuthenticateUser();
            else
                RefreshAccessToken();
        }

        private void GetClientSettings()
        {
            FileStream fs = new FileStream("App_Spotify.config", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            List<string> config = new List<string>();

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if (line.Contains("="))
                    config.Add(line.Split(new char[] { '=', '"' })[2]);
            }
            sr.Close(); fs.Close();
            YourClientId = config[0];
            YourClientSecret = config[1];
            RedirectUri = config[2];
        } // Read config file 

        public void AuthenticateUser()
        {
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
                        Scope = new[] { Scopes.UserReadPrivate, Scopes.UserReadEmail, Scopes.AppRemoteControl, Scopes.PlaylistModifyPrivate,
                                        Scopes.UserModifyPlaybackState, Scopes.UserModifyPlaybackState, Scopes.UserReadPlaybackState, Scopes.Streaming,
                                        Scopes.UserReadCurrentlyPlaying, Scopes.UserReadPlaybackPosition, Scopes.UserReadCurrentlyPlaying}
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
            SetSpotifyClient();
        } // Authenticate with User Login

        private void RefreshAccessToken()
        {
            if (access_token == null || expiring == DateTime.MinValue || expiring >= DateTime.UtcNow)
            {
                var response = new OAuthClient().RequestToken(
                            new AuthorizationCodeRefreshRequest(YourClientId, YourClientSecret, refresh_token));
                access_token = response.Result.AccessToken;
                expiring = response.Result.CreatedAt + TimeSpan.FromSeconds(response.Result.ExpiresIn);
            }
        } // Get new valid AccessToken

        public SpotifyClient GetSpotifyClient
        {
            get
            {
                if (spotify == null)
                    SetSpotifyClient();
                return spotify;
            }
        }

        public void SetSpotifyClient()
        {
            RefreshAccessToken();
            SpotifyClientConfig config = SpotifyClientConfig.CreateDefault();
            spotify = new SpotifyClient(config.WithToken(access_token));
        } // Set new Spotify API Client
    }
}
