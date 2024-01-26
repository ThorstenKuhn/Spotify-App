using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;

namespace App_Spotify
{
    public partial class LoginForm : Form
    {

        private const string YourClientId = "fe2aa9ba80024af0ace2ae28b9dcab6b";
        private const string YourClientSecret = "e0d9ca2234204bfcb5b1bc36735107b9";
        private const string RedirectUri = "http://localhost:5000/callback/";
        private string AccessToken = "";
        private string RefreshToken = "";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void Login_btn_Click(object sender, EventArgs e)
        {
            GetitDone();
        }

        public static async Task GetitDone()
        {
            var config = SpotifyClientConfig.CreateDefault();

            var request = new ClientCredentialsRequest(YourClientId, YourClientSecret);
            var response = await new OAuthClient(config).RequestToken(request);

            var spotify = new SpotifyClient(config.WithToken(response.AccessToken));
        }

        private async void StartHttpServer()
        {
            using (HttpListener listener = new HttpListener())
            {
                listener.Prefixes.Add(RedirectUri);
                listener.TimeoutManager.IdleConnection = TimeSpan.FromSeconds(20);

                listener.Start();

                // Öffne die Authentifizierungs-URL im Standard-Webbrowser
                var request = new LoginRequest(
                    new Uri(RedirectUri),
                    YourClientId,
                    LoginRequest.ResponseType.Code
                )
                {
                    Scope = new[] { Scopes.UserReadPrivate, Scopes.UserReadEmail }  // Benötigte Berechtigungen für den Lesezugriff
                };

                var uri = request.ToUri();
                webBrowser1.ScriptErrorsSuppressed = true;
                const string key = @"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION";
                using (var registryKey = Registry.CurrentUser.OpenSubKey(key, true))
                {
                    registryKey?.SetValue("App_Spotify.exe", 11001, RegistryValueKind.DWord);
                }
                webBrowser1.Navigate(uri);

                //System.Diagnostics.Process.Start(uri.OriginalString);

                //    HttpListenerContext context = await listener.GetContextAsync();

                // Verarbeite die Anfrage und erhalte den Autorisierungscode
                //    string authorizationCode = context.Request.QueryString["code"];

                //HandleAuthorizationCode(authorizationCode, new Uri(RedirectUri));
                //     var response = new OAuthClient().RequestToken(
                //                 new AuthorizationCodeTokenRequest(YourClientId, YourClientSecret, authorizationCode, new Uri(RedirectUri)));
                //     var test = response.GetAwaiter().GetResult();
                // Schließe den Listener
                //     listener.Close();

                //     AccessToken = test.AccessToken;
                //     RefreshToken = test.RefreshToken;
            }
        }

        private void HandleAuthorizationCode(string authorizationCode, Uri redirectUri)
        {
            var response = new OAuthClient().RequestToken(
                new AuthorizationCodeTokenRequest(YourClientId, YourClientSecret, authorizationCode, redirectUri));
        }


    }
}