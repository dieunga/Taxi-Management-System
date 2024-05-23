using System.Collections.Generic;

namespace TaxiManagementAssignment
{
    public class RankManager
    {
        private Dictionary<int, Rank> ranks = new Dictionary<int, Rank>();
        public Dictionary<int, Rank> Ranks { get { return ranks; } }

        public RankManager() {}

        public Rank FindRank(int id)
        {
            if (ranks.ContainsKey(id))
            {
                return ranks[id];
            }
            else
            {
                Rank rank = null;
                switch (id)
                {
                    case 1:
                        rank = new Rank(id, 5);
                        break;
                    case 2:
                        rank = new Rank(id, 2);
                        break;
                    case 3:
                        rank = new Rank(id, 4);
                        break;
                    default: 
                        return rank;
                }
                ranks.Add(id, rank);
            }
            return ranks[id];
        }

        public bool AddTaxiToRank(Taxi taxi, int rankId)
        {

            if (!string.IsNullOrEmpty(taxi.Destination))
            {
                return false; // Taxi already has a destination set
            }

            // Check if the taxi already exists in any rank
            foreach (var rank in ranks.Values)
            {
                if (rank.TaxiSpace.Contains(taxi))
                {
                    return false; // Taxi already exists in another rank
                }
            }

            Rank rankToAdd = FindRank(rankId);
            if (rankToAdd != null)
            {
                // Check if the taxi already exists in the rank
                if (!rankToAdd.TaxiSpace.Contains(taxi))
                {
                    return rankToAdd.AddTaxi(taxi);
                }
                else
                {
                    return false; // Taxi already exists in the rank
                }
            }
            return false; // Rank not found
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
