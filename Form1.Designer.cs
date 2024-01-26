namespace App_Spotify
{
    partial class SpotifyRandomizer
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Btn_Start_Playlist = new System.Windows.Forms.Button();
            this.Lbx_Playlists = new System.Windows.Forms.ListBox();
            this.Lbl_User = new System.Windows.Forms.Label();
            this.Lbx_Tracks = new System.Windows.Forms.ListBox();
            this.Lbx_Devices = new System.Windows.Forms.ListBox();
            this.Btn_ChangeDevice = new System.Windows.Forms.Button();
            this.Btn_ReLogIn = new System.Windows.Forms.Button();
            this.Btn_AddToQuery = new System.Windows.Forms.Button();
            this.Lbx_Query = new System.Windows.Forms.ListBox();
            this.PlayerStateTimer = new System.Windows.Forms.Timer(this.components);
            this.GetDeviceTimer = new System.Windows.Forms.Timer(this.components);
            this.Btn_Back = new System.Windows.Forms.Button();
            this.Btn_TogglePlay = new System.Windows.Forms.Button();
            this.Btn_Forward = new System.Windows.Forms.Button();
            this.GetTrackProgressTimer = new System.Windows.Forms.Timer(this.components);
            this.Pb_Time = new System.Windows.Forms.ProgressBar();
            this.Pb_PlayingTrack_Image = new System.Windows.Forms.PictureBox();
            this.Lbl_PlayingTrack_Name = new System.Windows.Forms.Label();
            this.Lbl_PlayingTrack_Artist = new System.Windows.Forms.Label();
            this.Lbl_PlayingTrack_Timer = new System.Windows.Forms.Label();
            this.Lbl_PlaylingTrack_Duration = new System.Windows.Forms.Label();
            this.Cbx_RealShuffle = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Pb_PlayingTrack_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Start_Playlist
            // 
            this.Btn_Start_Playlist.FlatAppearance.BorderSize = 0;
            this.Btn_Start_Playlist.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Btn_Start_Playlist.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Btn_Start_Playlist.Location = new System.Drawing.Point(93, 204);
            this.Btn_Start_Playlist.Name = "Btn_Start_Playlist";
            this.Btn_Start_Playlist.Size = new System.Drawing.Size(80, 23);
            this.Btn_Start_Playlist.TabIndex = 2;
            this.Btn_Start_Playlist.Text = "Start Playlist";
            this.Btn_Start_Playlist.UseVisualStyleBackColor = true;
            this.Btn_Start_Playlist.Click += new System.EventHandler(this.Btn_Start_Playlist_Click);
            // 
            // Lbx_Playlists
            // 
            this.Lbx_Playlists.FormattingEnabled = true;
            this.Lbx_Playlists.Location = new System.Drawing.Point(12, 25);
            this.Lbx_Playlists.Name = "Lbx_Playlists";
            this.Lbx_Playlists.Size = new System.Drawing.Size(127, 173);
            this.Lbx_Playlists.TabIndex = 3;
            this.Lbx_Playlists.SelectedIndexChanged += new System.EventHandler(this.Lbx_Playlists_SelectedIndexChanged);
            // 
            // Lbl_User
            // 
            this.Lbl_User.AutoSize = true;
            this.Lbl_User.Location = new System.Drawing.Point(12, 9);
            this.Lbl_User.Name = "Lbl_User";
            this.Lbl_User.Size = new System.Drawing.Size(29, 13);
            this.Lbl_User.TabIndex = 4;
            this.Lbl_User.Text = "User";
            // 
            // Lbx_Tracks
            // 
            this.Lbx_Tracks.FormattingEnabled = true;
            this.Lbx_Tracks.Location = new System.Drawing.Point(138, 25);
            this.Lbx_Tracks.Name = "Lbx_Tracks";
            this.Lbx_Tracks.Size = new System.Drawing.Size(210, 173);
            this.Lbx_Tracks.TabIndex = 6;
            // 
            // Lbx_Devices
            // 
            this.Lbx_Devices.FormattingEnabled = true;
            this.Lbx_Devices.Location = new System.Drawing.Point(12, 357);
            this.Lbx_Devices.Name = "Lbx_Devices";
            this.Lbx_Devices.Size = new System.Drawing.Size(120, 56);
            this.Lbx_Devices.TabIndex = 7;
            // 
            // Btn_ChangeDevice
            // 
            this.Btn_ChangeDevice.Location = new System.Drawing.Point(12, 328);
            this.Btn_ChangeDevice.Name = "Btn_ChangeDevice";
            this.Btn_ChangeDevice.Size = new System.Drawing.Size(120, 23);
            this.Btn_ChangeDevice.TabIndex = 8;
            this.Btn_ChangeDevice.Text = "Change Player";
            this.Btn_ChangeDevice.UseVisualStyleBackColor = true;
            this.Btn_ChangeDevice.Click += new System.EventHandler(this.Btn_ChangeDevice_Click);
            // 
            // Btn_ReLogIn
            // 
            this.Btn_ReLogIn.FlatAppearance.BorderSize = 0;
            this.Btn_ReLogIn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Btn_ReLogIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Btn_ReLogIn.Location = new System.Drawing.Point(12, 204);
            this.Btn_ReLogIn.Name = "Btn_ReLogIn";
            this.Btn_ReLogIn.Size = new System.Drawing.Size(75, 23);
            this.Btn_ReLogIn.TabIndex = 9;
            this.Btn_ReLogIn.Text = "Login";
            this.Btn_ReLogIn.UseVisualStyleBackColor = true;
            this.Btn_ReLogIn.Click += new System.EventHandler(this.Btn_ReLogIn_Click);
            // 
            // Btn_AddToQuery
            // 
            this.Btn_AddToQuery.FlatAppearance.BorderSize = 0;
            this.Btn_AddToQuery.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Btn_AddToQuery.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Btn_AddToQuery.Location = new System.Drawing.Point(179, 204);
            this.Btn_AddToQuery.Name = "Btn_AddToQuery";
            this.Btn_AddToQuery.Size = new System.Drawing.Size(86, 23);
            this.Btn_AddToQuery.TabIndex = 10;
            this.Btn_AddToQuery.Text = "Add to Queue";
            this.Btn_AddToQuery.UseVisualStyleBackColor = true;
            this.Btn_AddToQuery.Click += new System.EventHandler(this.Btn_AddToQuery_Click);
            // 
            // Lbx_Query
            // 
            this.Lbx_Query.FormattingEnabled = true;
            this.Lbx_Query.Location = new System.Drawing.Point(347, 25);
            this.Lbx_Query.Name = "Lbx_Query";
            this.Lbx_Query.Size = new System.Drawing.Size(215, 264);
            this.Lbx_Query.TabIndex = 11;
            // 
            // PlayerStateTimer
            // 
            this.PlayerStateTimer.Interval = 10000;
            this.PlayerStateTimer.Tick += new System.EventHandler(this.PlayerStateTimer_Tick);
            // 
            // GetDeviceTimer
            // 
            this.GetDeviceTimer.Enabled = true;
            this.GetDeviceTimer.Interval = 10000;
            this.GetDeviceTimer.Tick += new System.EventHandler(this.GetDeviceTimer_Tick);
            // 
            // Btn_Back
            // 
            this.Btn_Back.FlatAppearance.BorderSize = 0;
            this.Btn_Back.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Btn_Back.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Btn_Back.Location = new System.Drawing.Point(200, 262);
            this.Btn_Back.Name = "Btn_Back";
            this.Btn_Back.Size = new System.Drawing.Size(31, 31);
            this.Btn_Back.TabIndex = 17;
            this.Btn_Back.Text = "|<";
            this.Btn_Back.UseVisualStyleBackColor = true;
            this.Btn_Back.Click += new System.EventHandler(this.Btn_Back_Click);
            // 
            // Btn_TogglePlay
            // 
            this.Btn_TogglePlay.FlatAppearance.BorderSize = 0;
            this.Btn_TogglePlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Btn_TogglePlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Btn_TogglePlay.Location = new System.Drawing.Point(237, 262);
            this.Btn_TogglePlay.Name = "Btn_TogglePlay";
            this.Btn_TogglePlay.Size = new System.Drawing.Size(31, 31);
            this.Btn_TogglePlay.TabIndex = 18;
            this.Btn_TogglePlay.Text = "||>";
            this.Btn_TogglePlay.UseVisualStyleBackColor = true;
            this.Btn_TogglePlay.Click += new System.EventHandler(this.Btn_TogglePlay_Click);
            // 
            // Btn_Forward
            // 
            this.Btn_Forward.FlatAppearance.BorderSize = 0;
            this.Btn_Forward.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Btn_Forward.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Btn_Forward.Location = new System.Drawing.Point(274, 262);
            this.Btn_Forward.Name = "Btn_Forward";
            this.Btn_Forward.Size = new System.Drawing.Size(31, 31);
            this.Btn_Forward.TabIndex = 19;
            this.Btn_Forward.Text = ">|";
            this.Btn_Forward.UseVisualStyleBackColor = true;
            this.Btn_Forward.Click += new System.EventHandler(this.Btn_Forward_Click);
            // 
            // GetTrackProgressTimer
            // 
            this.GetTrackProgressTimer.Interval = 2000;
            this.GetTrackProgressTimer.Tick += new System.EventHandler(this.GetTrackProgressTimer_Tick);
            // 
            // Pb_Time
            // 
            this.Pb_Time.Location = new System.Drawing.Point(43, 299);
            this.Pb_Time.Name = "Pb_Time";
            this.Pb_Time.Size = new System.Drawing.Size(482, 23);
            this.Pb_Time.Step = 1;
            this.Pb_Time.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.Pb_Time.TabIndex = 21;
            this.Pb_Time.Click += new System.EventHandler(this.Pb_Time_Click);
            // 
            // Pb_PlayingTrack_Image
            // 
            this.Pb_PlayingTrack_Image.Location = new System.Drawing.Point(12, 233);
            this.Pb_PlayingTrack_Image.Name = "Pb_PlayingTrack_Image";
            this.Pb_PlayingTrack_Image.Size = new System.Drawing.Size(60, 60);
            this.Pb_PlayingTrack_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Pb_PlayingTrack_Image.TabIndex = 22;
            this.Pb_PlayingTrack_Image.TabStop = false;
            // 
            // Lbl_PlayingTrack_Name
            // 
            this.Lbl_PlayingTrack_Name.AutoSize = true;
            this.Lbl_PlayingTrack_Name.Location = new System.Drawing.Point(78, 267);
            this.Lbl_PlayingTrack_Name.MaximumSize = new System.Drawing.Size(123, 13);
            this.Lbl_PlayingTrack_Name.Name = "Lbl_PlayingTrack_Name";
            this.Lbl_PlayingTrack_Name.Size = new System.Drawing.Size(66, 13);
            this.Lbl_PlayingTrack_Name.TabIndex = 23;
            this.Lbl_PlayingTrack_Name.Text = "Track Name";
            // 
            // Lbl_PlayingTrack_Artist
            // 
            this.Lbl_PlayingTrack_Artist.AutoSize = true;
            this.Lbl_PlayingTrack_Artist.Location = new System.Drawing.Point(78, 280);
            this.Lbl_PlayingTrack_Artist.MaximumSize = new System.Drawing.Size(365, 13);
            this.Lbl_PlayingTrack_Artist.Name = "Lbl_PlayingTrack_Artist";
            this.Lbl_PlayingTrack_Artist.Size = new System.Drawing.Size(30, 13);
            this.Lbl_PlayingTrack_Artist.TabIndex = 24;
            this.Lbl_PlayingTrack_Artist.Text = "Artist";
            // 
            // Lbl_PlayingTrack_Timer
            // 
            this.Lbl_PlayingTrack_Timer.AutoSize = true;
            this.Lbl_PlayingTrack_Timer.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_PlayingTrack_Timer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Lbl_PlayingTrack_Timer.Location = new System.Drawing.Point(9, 304);
            this.Lbl_PlayingTrack_Timer.Name = "Lbl_PlayingTrack_Timer";
            this.Lbl_PlayingTrack_Timer.Size = new System.Drawing.Size(28, 13);
            this.Lbl_PlayingTrack_Timer.TabIndex = 25;
            this.Lbl_PlayingTrack_Timer.Text = "0:00";
            // 
            // Lbl_PlaylingTrack_Duration
            // 
            this.Lbl_PlaylingTrack_Duration.AutoSize = true;
            this.Lbl_PlaylingTrack_Duration.Location = new System.Drawing.Point(531, 304);
            this.Lbl_PlaylingTrack_Duration.Name = "Lbl_PlaylingTrack_Duration";
            this.Lbl_PlaylingTrack_Duration.Size = new System.Drawing.Size(28, 13);
            this.Lbl_PlaylingTrack_Duration.TabIndex = 26;
            this.Lbl_PlaylingTrack_Duration.Text = "0:00";
            // 
            // Cbx_RealShuffle
            // 
            this.Cbx_RealShuffle.AutoSize = true;
            this.Cbx_RealShuffle.Location = new System.Drawing.Point(93, 233);
            this.Cbx_RealShuffle.Name = "Cbx_RealShuffle";
            this.Cbx_RealShuffle.Size = new System.Drawing.Size(81, 17);
            this.Cbx_RealShuffle.TabIndex = 27;
            this.Cbx_RealShuffle.Text = "RealShuffle";
            this.Cbx_RealShuffle.UseVisualStyleBackColor = true;
            // 
            // SpotifyRandomizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 424);
            this.Controls.Add(this.Cbx_RealShuffle);
            this.Controls.Add(this.Lbl_PlaylingTrack_Duration);
            this.Controls.Add(this.Lbl_PlayingTrack_Timer);
            this.Controls.Add(this.Lbl_PlayingTrack_Artist);
            this.Controls.Add(this.Lbl_PlayingTrack_Name);
            this.Controls.Add(this.Pb_PlayingTrack_Image);
            this.Controls.Add(this.Pb_Time);
            this.Controls.Add(this.Btn_Forward);
            this.Controls.Add(this.Btn_TogglePlay);
            this.Controls.Add(this.Btn_Back);
            this.Controls.Add(this.Lbx_Query);
            this.Controls.Add(this.Btn_AddToQuery);
            this.Controls.Add(this.Btn_ReLogIn);
            this.Controls.Add(this.Btn_ChangeDevice);
            this.Controls.Add(this.Lbx_Devices);
            this.Controls.Add(this.Lbx_Tracks);
            this.Controls.Add(this.Lbl_User);
            this.Controls.Add(this.Lbx_Playlists);
            this.Controls.Add(this.Btn_Start_Playlist);
            this.Name = "SpotifyRandomizer";
            this.Text = "Spotify Client";
            ((System.ComponentModel.ISupportInitialize)(this.Pb_PlayingTrack_Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Btn_Start_Playlist;
        private System.Windows.Forms.ListBox Lbx_Playlists;
        private System.Windows.Forms.Label Lbl_User;
        private System.Windows.Forms.ListBox Lbx_Tracks;
        private System.Windows.Forms.ListBox Lbx_Devices;
        private System.Windows.Forms.Button Btn_ChangeDevice;
        private System.Windows.Forms.Button Btn_ReLogIn;
        private System.Windows.Forms.Button Btn_AddToQuery;
        private System.Windows.Forms.ListBox Lbx_Query;
        private System.Windows.Forms.Timer PlayerStateTimer;
        private System.Windows.Forms.Timer GetDeviceTimer;
        private System.Windows.Forms.Button Btn_Back;
        private System.Windows.Forms.Button Btn_TogglePlay;
        private System.Windows.Forms.Button Btn_Forward;
        private System.Windows.Forms.Timer GetTrackProgressTimer;
        private NAudio.Gui.VolumeSlider Volume_Slider;
        private System.Windows.Forms.ProgressBar Pb_Time;
        private System.Windows.Forms.PictureBox Pb_PlayingTrack_Image;
        private System.Windows.Forms.Label Lbl_PlayingTrack_Name;
        private System.Windows.Forms.Label Lbl_PlayingTrack_Artist;
        private System.Windows.Forms.Label Lbl_PlayingTrack_Timer;
        private System.Windows.Forms.Label Lbl_PlaylingTrack_Duration;
        private System.Windows.Forms.CheckBox Cbx_RealShuffle;
    }
}

