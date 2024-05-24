using System.Collections.Generic;

namespace TaxiManagementAssignment
{
    public class RankManager
    {
        private Dictionary<int, Rank> ranks = new Dictionary<int, Rank>();
        public Dictionary<int, Rank> Ranks { get { return ranks; } }

        public RankManager() {
            ranks.Add(1,new Rank(1, 5));
            ranks.Add(2, new Rank(2, 2));
            ranks.Add(3, new Rank(3, 4));
        }

            public Rank FindRank(int id)
        {
            if (ranks.ContainsKey(id))
            {
                return ranks[id];
            }

                return null;

        }

        public bool AddTaxiToRank(Taxi taxi, int rankId)
        {

            if (!string.IsNullOrEmpty(taxi.Destination))
            {
                return false; 
            }

            foreach (var rank in ranks.Values)
            {
                if (rank.TaxiSpace.Contains(taxi))
                {
                    return false; 
                }
            }

            Rank rankToAdd = FindRank(rankId);
            if (rankToAdd != null)
            {
                if (!rankToAdd.TaxiSpace.Contains(taxi))
                {
                    return rankToAdd.AddTaxi(taxi);
                }
                else
                {
                    return false; 
                }
            }
            return false; 
        }

        public Taxi FrontTaxiInRankTakesFare(int rankId, string destination, double agreedPrice)
        {
            Rank rank = FindRank(rankId);
            if (rank != null)
            {
                return rank.FrontTaxiTakesFare(destination, agreedPrice);
            }
            return null;
        }
    }
}
