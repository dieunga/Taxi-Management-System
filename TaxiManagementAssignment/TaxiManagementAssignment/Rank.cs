using System.Collections.Generic;

public class Rank
{
    public int Id { get; private set; }
    public int NumberOfTaxiSpaces 
    public List<Taxi> TaxiSpace 

    public Rank(int rankId, int numberOfTaxiSpaces)
    {
        Id = rankId;
        NumberOfTaxiSpaces = numberOfTaxiSpaces;
        TaxiSpace = new List<Taxi>();
    }

    public bool AddTaxi(Taxi taxi)
    {
        if (TaxiSpace.Count < NumberOfTaxiSpaces)
        {
            TaxiSpace.Add(taxi);
            return true;
        }
        return false;
    }

    public Taxi FrontTaxiTakesFare(string destination, double agreedPrice)
    {
        if (TaxiSpace.Count > 0)
        {
            Taxi frontTaxi = TaxiSpace[0];
            frontTaxi.AddFare(destination, agreedPrice);
            TaxiSpace.RemoveAt(0);
            return frontTaxi;
        }
        return null;
    }
}
