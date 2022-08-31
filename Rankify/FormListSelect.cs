using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotifyTourney
{
    public partial class FormListSelect : Form
    {
        private const string clientId = "b71b8998a8844d4c9611d0e693bef056";
        private const string secretId = "c308d73b006b4140b50992a29873ae5b";
        static SpotifyWebAPI api;
        List<SimplePlaylist> playlists;
        string[] args;

        public FormListSelect(string[] args)
        {
            InitializeComponent();

            AuthorizationCodeAuth auth = new AuthorizationCodeAuth(clientId, secretId, "http://localhost:40102", "http://localhost:40102",
            Scope.PlaylistReadPrivate | Scope.PlaylistReadCollaborative | Scope.UserModifyPlaybackState | Scope.PlaylistModifyPrivate);
            auth.AuthReceived += AuthOnAuthReceived;
            auth.Start();
            auth.OpenBrowser();

            this.args= args;
        }
        private static async void AuthOnAuthReceived(object sender, AuthorizationCode payload)
        {
            AuthorizationCodeAuth auth = (AuthorizationCodeAuth)sender;
            auth.Stop();



            Token token = await auth.ExchangeCode(payload.Code);
            SpotifyWebAPI api = new SpotifyWebAPI
            {
                AccessToken = token.AccessToken,
                TokenType = token.TokenType
            };
            FormListSelect.api = api;
        }

        private void ProfileTimer_Tick(object sender, EventArgs e)
        {
            if (api == null)
            {
                int ellipsisLength = (int)labelName.Tag;
                labelName.Text = "Accessing Profile";
                for (int i = 0; i < ellipsisLength; i++)
                    labelName.Text += ".";
                if (++ellipsisLength > 3)
                    ellipsisLength = 0;
                labelName.Tag = ellipsisLength;
            }
            else
            {
                Activate();
                UseWaitCursor = false;
                ProfileTimer.Stop();

                if (args.Any())
                {
                    loadFile(args[0]);
                }

                buttonLoad.Enabled = true;

                PrivateProfile profile = api.GetPrivateProfile();
                string name = string.IsNullOrEmpty(profile.DisplayName) ? profile.Id : profile.DisplayName;
                Paging<SimplePlaylist> playlistsPaging = api.GetUserPlaylists(profile.Id);
                playlists = playlistsPaging.Items;
                foreach (SimplePlaylist playlist in playlists)
                {
                    listBox.Items.Add(playlist.Name);
                }
                labelName.Text = name + ((name[name.Length - 1] == 's') ? "s" : "\'s") + " playlists:";
            }
        }

        private void ListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            buttonSelect.Enabled = true;
        }

        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            new FormRanker(api, playlists[listBox.SelectedIndex].Uri).Show();
            Hide();
        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry, I fricked this feature for now, just hold up a bit","Feature Removed",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            return;
            //TODO:restore load functionallity
            FileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Path.Combine(Application.StartupPath, "Rankings");
            dialog.Filter = "Rankify Files (*.rnk)|*.rnk";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(dialog.FileName))
                {
                    new FormRanker(api, sr.ReadLine(), sr.ReadToEnd()).Show();
                }
            }
            else
            {
                return;
            }
            Hide();
        }

        private void loadFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                new FormRanker(api, sr.ReadLine(), sr.ReadToEnd()).Show();
            }
            Hide();
        }
    }
}
