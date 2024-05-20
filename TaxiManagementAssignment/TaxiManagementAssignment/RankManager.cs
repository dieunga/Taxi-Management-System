using System.Collections.Generic;

public class RankManager
{
    private Dictionary<int, Rank> ranks = new Dictionary<int, Rank>();

    public Rank FindRank(int rankId)
    {
        ranks.TryGetValue(rankId, out Rank rank);
        return rank;
    }

    public bool AddTaxiToRank(Taxi taxi, int rankId)
    {
        Rank rank = FindRank(rankId);
        if (rank != null)
        {
            return rank.AddTaxi(taxi);
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