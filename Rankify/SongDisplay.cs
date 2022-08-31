using SpotifyAPI.Web.Models;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace SpotifyTourney
{
    public partial class SongDisplay : UserControl
    {
        FullTrack song;
        public SongDisplay()
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
                InitializeComponent();
        }
        public void UpdateSong(FullTrack song)
        {
            this.song = song;

            labelAlbum.Text = song.Album.Name;
            labelAuthor.Text = "";
            foreach (SimpleArtist artist in song.Artists)
            {
                labelAuthor.Text += artist.Name;
            }
            labelName.Text = song.Name;
            MemoryStream imgStream = new MemoryStream((new WebClient().DownloadData(song.Album.Images[0].Url)));
            BackgroundImage = System.Drawing.Image.FromStream(imgStream);
        }

        private void ButtonPlay_Click(object sender, System.EventArgs e)
        {
            System.Diagnostics.Process.Start(song.ExternUrls["spotify"]);
        }
    }
}
