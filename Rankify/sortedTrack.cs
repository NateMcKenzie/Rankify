using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;

namespace SpotifyTourney
{
    class SortedTrack : IComparable
    {
        private FullTrack track;
        private int ranking;
        private int id;
        private static int nextId = 0;
        private HashSet<int> ledgerOfDefeated;

        public SortedTrack(FullTrack track, int ranking)
        {
            this.track = track;
            this.ranking = ranking;
            this.id = ++nextId;

            ledgerOfDefeated = new HashSet<int>();
            ledgerOfDefeated.Add(id);
        }

        public SortedTrack(FullTrack track, string loadString)
        {
            this.track = track;

            string[] loadValues = loadString.Split(',');
            id = int.Parse(loadValues[0]);

            string ledgerString = loadValues[1].Substring(1, loadValues.Length - 2);
            string[] ledgerValues = ledgerString.Split(';');
            ranking = int.Parse(loadValues[2]);

            ledgerOfDefeated = new HashSet<int>();
            ledgerOfDefeated.Add(id);
            foreach (string ledgerValue in ledgerValues)
                ledgerOfDefeated.Add(int.Parse(ledgerValue));
        }


        public int CompareTo(object obj)
        {
            if (ranking.CompareTo(((SortedTrack)obj).Ranking) == 0)
            {
                return id.CompareTo(((SortedTrack)obj).id);
            }
            return ranking.CompareTo(((SortedTrack)obj).Ranking);
        }

        public bool PromoteRanking(HashSet<int> loserLedger)
        {
            ranking--;
            ledgerOfDefeated.UnionWith(loserLedger);
            return ranking == 1;
        }

        public FullTrack Track { get => track; set => track = value; }
        public int Ranking { get => ranking; }
        public int Id { get => id; }
        public HashSet<int> Ledger { get => ledgerOfDefeated;}

        internal string GetLedgerString()
        {
            string returnValue = "{";
            foreach (int value in ledgerOfDefeated)
                returnValue += value + ";";
            returnValue.Remove(returnValue.Length - 1, 1);
            return returnValue + "}";
        }
    }
}
