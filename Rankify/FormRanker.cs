using SpotifyAPI.Web;
using SpotifyAPI.Web.Models;
using System.Windows.Forms;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace SpotifyTourney
{
    public partial class FormRanker : Form
    {
        SpotifyWebAPI api;
        string playlistName;
        string playlistUri;
        List<SortedTrack> sortingTracks;
        List<List<SortedTrack>> trackMatrix;
        List<SortedTrack> activelyCompetingSongs1;
        List<SortedTrack> activelyCompetingSongs2;
        SortedTrack song1;
        SortedTrack song2;
        int currentlySortingRank;
        public FormRanker(SpotifyWebAPI api, string playlistUri)
        {
            InitializeComponent();

            string id = playlistUri.Substring(playlistUri.LastIndexOf(':') + 1);
            playlistName = api.GetPlaylist(id).Name;
            Paging<PlaylistTrack> playlist = api.GetPlaylistTracks(id);

            int totalSongs = playlist.Total;
            currentlySortingRank = totalSongs;


            this.api = api;
            this.playlistUri = playlistUri;
            sortingTracks = new List<SortedTrack>();
            trackMatrix = new List<List<SortedTrack>>();
            activelyCompetingSongs1 = new List<SortedTrack>();
            activelyCompetingSongs2 = new List<SortedTrack>();

            for (int i = 0; i < totalSongs;i++)
                trackMatrix.Add(new List<SortedTrack>());

            playlist.Items.ForEach(track =>
            {
                listBoxSongs.Items.Add(totalSongs + " - " + track.Track.Name);
                sortingTracks.Add(new SortedTrack(track.Track, totalSongs));
            });
            while (playlist.HasNextPage())
            {
                playlist = api.GetNextPage(playlist);
                playlist.Items.ForEach(track =>
                {
                    listBoxSongs.Items.Add(totalSongs + " - " + track.Track.Name);
                    sortingTracks.Add(new SortedTrack(track.Track, totalSongs));
                });
            }
            trackMatrix[0].AddRange(sortingTracks);

            activelyCompetingSongs1.AddRange(sortingTracks.GetRange(0, (sortingTracks.Count+1) / 2));
            activelyCompetingSongs2.AddRange(sortingTracks.GetRange((sortingTracks.Count+1) / 2, sortingTracks.Count / 2));

            SelectSongsForCompetition();
        }

        public FormRanker(SpotifyWebAPI api, string playlistUri, string priorRankings) // loading files 
        {
            InitializeComponent();

            string id = playlistUri.Substring(playlistUri.LastIndexOf(':') + 1);
            playlistName = api.GetPlaylist(id).Name;
            Paging<PlaylistTrack> playlist = api.GetPlaylistTracks(id);

            int totalSongs = playlist.Total;
            currentlySortingRank = totalSongs;


            this.api = api;
            this.playlistUri = playlistUri;
            sortingTracks = new List<SortedTrack>();

            Dictionary<string, string> priorRankingsDict = new Dictionary<string, string>();
            foreach (string line in priorRankings.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None))
            {
                if (line == "")
                    break;
                string[] splitLine = line.Split(',');
                priorRankingsDict.Add(splitLine[0], splitLine[1] + "," + splitLine[2] + "," + splitLine[3]);
            }

            playlist.Items.ForEach(track =>
            {
                listBoxSongs.Items.Add(totalSongs + " - " + track.Track.Name);
                sortingTracks.Add(new SortedTrack(track.Track, priorRankingsDict[track.Track.Id]));
            });
            while (playlist.HasNextPage())
            {
                playlist = api.GetNextPage(playlist);
                playlist.Items.ForEach(track =>
                {
                    listBoxSongs.Items.Add(totalSongs + " - " + track.Track.Name);
                    sortingTracks.Add(new SortedTrack(track.Track, priorRankingsDict[track.Track.Id]));
                });
            }
            //TODO: load files into matrix correctly
            //when loading files the entire list of songs cannot be loaded into the last ranking, they have to be iterated over and placed where they belong🙄
            /*trackMatrix[0].AddRange(sortingTracks);

            activelyCompetingSongs1.AddRange(sortingTracks.GetRange(0, sortingTracks.Count / 2));
            activelyCompetingSongs2.AddRange(sortingTracks.GetRange(sortingTracks.Count / 2, (sortingTracks.Count + 1) / 2));*/

            SelectSongsForCompetition();
        }

        private void SelectSongsForCompetition()
        {
            sortingTracks.Sort();

            listBoxSongs.Items.Clear();
            foreach (SortedTrack track in sortingTracks)
            {
                listBoxSongs.Items.Add(track.Ranking + " - " + track.Track.Name);
            }

            song1 = activelyCompetingSongs1[0];
            song2 = activelyCompetingSongs2[0];
            if (song1.Ranking != song2.Ranking)
                Debug.Write("HELP");

            activelyCompetingSongs1.Remove(song1);
            activelyCompetingSongs2.Remove(song2);

            if(activelyCompetingSongs1.Count <= 1) // 1 is longer, so if it is 1 or 0 then 2 is also empty
            {
                foreach(List<SortedTrack> tracks in trackMatrix)
                {
                    if(tracks.Count > 1)
                    {
                        activelyCompetingSongs1.AddRange(tracks.GetRange(0, tracks.Count / 2));
                        activelyCompetingSongs2.AddRange(tracks.GetRange(tracks.Count / 2, (tracks.Count + 1) / 2));
                    }

                }
            }
            /*for (int i = currentlySortingRank - 1; i > 0; i--)
            {
                SortedTrack currentTrack = sortingTracks[i]; 
                SortedTrack previousTrack = sortingTracks[i - 1];
                if (currentTrack.Ranking == previousTrack.Ranking)
                {
                    song1 = currentTrack;
                    song2 = previousTrack;
                    break;
                }
                else
                {
                    currentlySortingRank--;
                }
            }*/

            songDisplay1.UpdateSong(song1.Track);
            songDisplay2.UpdateSong(song2.Track);
        }
        private void ButtonWinner1_Click(object sender, EventArgs e)
        {
            trackMatrix[sortingTracks.Count - song1.Ranking].Remove(song1);
            trackMatrix[sortingTracks.Count - song1.Ranking + 1].Add(song1);

            if (song1.PromoteRanking(song2.Ledger))
            {
                endRanking();
                return;
            }

            resolveLedgers(song1);
            SelectSongsForCompetition();
        }
        private void ButtonWinner2_Click(object sender, EventArgs e)
        {
            trackMatrix[sortingTracks.Count - song2.Ranking].Remove(song2);
            trackMatrix[sortingTracks.Count - song2.Ranking + 1].Add(song2);

            if (song2.PromoteRanking(song1.Ledger))
            {
                endRanking();
                return;
            }

            resolveLedgers(song2);
            SelectSongsForCompetition();
        }
        private void resolveLedgers(SortedTrack mover)
        {
            Debug.WriteLine(mover.Id + " ledger:");
            foreach (int id in mover.Ledger)
                Debug.WriteLine(id);
            foreach (SortedTrack track in sortingTracks)
            {
                if (track.Ranking == mover.Ranking)
                {
                    if (track.Id != mover.Id)
                    {
                        if (mover.Ledger.Contains(track.Id))
                        {
                            trackMatrix[sortingTracks.Count - mover.Ranking].Remove(mover);
                            trackMatrix[sortingTracks.Count - mover.Ranking + 1].Add(mover);
                            activelyCompetingSongs1.Remove(mover);
                            activelyCompetingSongs2.Remove(mover);

                            if (mover.PromoteRanking(track.Ledger))
                            {
                                endRanking();
                                return;
                            }
                            resolveLedgers(mover);
                        }
                        else if (track.Ledger.Contains(mover.Id))
                        {
                            trackMatrix[sortingTracks.Count - mover.Ranking].Remove(mover);
                            trackMatrix[sortingTracks.Count - mover.Ranking + 1].Add(mover);
                            activelyCompetingSongs1.Remove(mover);
                            activelyCompetingSongs2.Remove(mover);

                            if (track.PromoteRanking(mover.Ledger))
                            {
                                endRanking();
                                return;
                            }
                            resolveLedgers(track);
                        }
                    }
                }
            }

        }

        private void endRanking()
        {
            listBoxSongs.Items.Clear();
            foreach (SortedTrack track in sortingTracks)
            {
                listBoxSongs.Items.Add(track.Ranking + " - " + track.Track.Name);
            }

            buttonWinner1.Enabled = false;
            buttonWinner2.Enabled = false;
        }

        private void FormRanker_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ButtonPlay2_Click(object sender, EventArgs e)
        {
            List<string> uris = new List<string>();
            uris.Add(song2.Track.Uri);
            api.ResumePlayback(contextUri: playlistUri, offset: song2.Id - 1);
        }

        private void ButtonPlay1_Click(object sender, EventArgs e)
        {
            List<string> uris = new List<string>();
            uris.Add(song1.Track.Uri);
            api.ResumePlayback(contextUri: playlistUri, offset: song1.Id - 1);
        }

        private void ButtonExport_Click(object sender, EventArgs e)
        {
            List<string> uris = new List<string>();

            foreach (SortedTrack track in sortingTracks)
                uris.Add(track.Track.Uri);

            api.ReplacePlaylistTracks(playlistUri.Substring(playlistUri.LastIndexOf(':') + 1), uris.GetRange(0, (uris.Count > 99 ? 100 : uris.Count)));
            uris.RemoveRange(0, (uris.Count > 99 ? 100 : uris.Count));

            while (uris.Count > 0)
            {
                api.AddPlaylistTracks(playlistUri.Substring(playlistUri.LastIndexOf(':') + 1), uris.GetRange(0, (uris.Count > 99 ? 100 : uris.Count)));
                uris.RemoveRange(0, (uris.Count > 99 ? 100 : uris.Count));
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "Rankings");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            path = Path.Combine(path, playlistName.Replace(' ', '_') + ".rnk");

            List<string> lines = new List<string>();
            foreach (SortedTrack track in sortingTracks)
                lines.Add(track.Track.Id + "," + track.Id + "," + track.GetLedgerString() + "," +track.Ranking);


            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(playlistUri);
                foreach (string line in lines)
                    sw.WriteLine(line);
            }

            MessageBox.Show("Rankgings successfully saved.\n" + path, "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FormRanker_DoubleClick(object sender, EventArgs e)
        {

            foreach(List<SortedTrack> list in trackMatrix)
            {
                if (list.Count == 0) {
                    Debug.Write("No Tracks\n");
                    continue;
                }
                Debug.Write(list[0].Ranking + "- ");
                foreach(SortedTrack track in list)
                {
                    Debug.Write(track.Track.Name + ", ");
                }
                Debug.Write("\n");
            }
        }
    }
}

