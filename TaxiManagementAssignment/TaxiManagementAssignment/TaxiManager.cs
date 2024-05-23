using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TaxiManagementAssignment
{
    public class TaxiManager
    {
        private SortedDictionary<int, Taxi> taxis = new SortedDictionary<int, Taxi>();

        public Taxi CreateTaxi(int taxiNum)
        {
            if (!taxis.ContainsKey(taxiNum))
            {
                Taxi newTaxi = new Taxi(taxiNum);
                taxis.Add(taxiNum, newTaxi);
                return newTaxi;
            }
            return taxis[taxiNum];
        }

        public Taxi FindTaxi(int taxiNum)
        {
            taxis.TryGetValue(taxiNum, out Taxi taxi);
            return taxi;
        }

        public SortedDictionary<int, Taxi> GetAllTaxis()
        {
            return taxis;
        }
    }
}
