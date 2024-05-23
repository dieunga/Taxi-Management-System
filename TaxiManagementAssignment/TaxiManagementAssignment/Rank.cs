using System.Collections.Generic;

namespace TaxiManagementAssignment
{
    public class Rank
    {
        private int id;
        private int numberOfTaxiSpaces;
        private List<Taxi> taxiSpace;

        public int Id { get { return id; } }
        public int NumberOfTaxiSpaces { get { return numberOfTaxiSpaces; } }
        public List<Taxi> TaxiSpace { get { return taxiSpace; } }

        public Rank(int rankId, int numberOfTaxiSpaces)
        {
            id = rankId;
            this.numberOfTaxiSpaces = numberOfTaxiSpaces;
            taxiSpace = new List<Taxi>();
        }

        public bool AddTaxi(Taxi taxi)
        {
            if (taxiSpace.Count < numberOfTaxiSpaces)
            {
                taxiSpace.Add(taxi);
                taxi.Rank = this;
                return true;
            }
            return false;
        }

        public Taxi FrontTaxiTakesFare(string destination, double agreedPrice)
        {
            if (taxiSpace.Count > 0)
            {
                Taxi frontTaxi = TaxiSpace[0];
                frontTaxi.AddFare(destination, agreedPrice);
                taxiSpace.RemoveAt(0);
                return frontTaxi;
            }
            return null;
        }
    }

}
