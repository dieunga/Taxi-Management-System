//using System;
//using System.Collections.Generic;
//using System.Runtime.CompilerServices;
//using System.Text;

//namespace TaxiManagementAssignment
//{
//    public class Taxi
//    {
//        private int Number;
//        public static string IN_RANK;
//        public static string ON_ROAD;
//        private double CurrentFare;
//        private string Destination;
//        private string Location;
//        private Rank Rank = null;
//        private double TotalMoneyPaid;
//        public Rank rank { get { return Rank; } set { if (value == null) { throw new Exception("Rank cannot be null"); } else Rank = value; } } 
//        public int number { get { return Number; } }
//        public double currentFare { get { return CurrentFare; } }
//        public string destination { get { return Destination; } }
//        public string location { get { return Location; } }
//        public double totalMoneyPaid {  get { return TotalMoneyPaid; } }

//        public Taxi(int num)
//        {
//            Number = num;
//            CurrentFare = 0;
//            Destination = string.Empty;
//            Location = "ON_ROAD";
//            Rank = new Rank();
//            IN_RANK = "in rank";
//            ON_ROAD = "on the road";
//            TotalMoneyPaid = 0;
//        }

//        public void AddFare(string Destination, double agreedPrice)
//        {

//        }

//        public void setRank(Rank val) { }
//    }
//}
using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
    public class Taxi
    {
        public int Number;
        public double CurrentFare;
        public string Destination;
        public static string ON_ROAD = "on the road";
        public string Location = ON_ROAD;
        public static string in_rank = "in rank";
        private Rank rank = null;
        public string AddFare;
        public double TotalMoneyPaid;
        public Rank Rank
        {
            get { return rank; }
            set
            {
                if (value == null)
                { throw new Exception("Rank cannot be null"); }
                rank = value;
            }

        }

        public Taxi(int num)
        {
            Number = num;
            CurrentFare = 0;
            Destination = string.Empty;
            Location = ON_ROAD;
            TotalMoneyPaid = 0;
        }
    }
}