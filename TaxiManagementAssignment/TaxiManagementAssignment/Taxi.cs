using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TaxiManagementAssignment
{
    public class Taxi
    {
        private int number;
        public static string IN_RANK = "in rank";
        public static string ON_ROAD = "on the road";
        private double currentFare;
        private string destination;
        private string location;
        private Rank rank;
        private double totalMoneyPaid;
        public Rank Rank 
        { 
            get 
            { 
                return rank; 
            } 
            set { 
                if (value == null) 
                { 
                    throw new Exception("Rank cannot be null"); 
                } 
                else 
                    rank = value; } 
        }
        public int Number { get { return number; } }
        public double CurrentFare { get { return currentFare; } }
        public string Destination { get { return destination; } }
        public string Location { get { return location; } }
        public double TotalMoneyPaid { get { return totalMoneyPaid; } }

        public Taxi(int num)
        {
            number = num;
            currentFare = 0;
            destination = string.Empty;
            location = ON_ROAD;
            rank = null;
            totalMoneyPaid = 0;
        }

        public void AddFare(string destination, double agreedPrice)
        {
            this.destination = destination;
            currentFare = agreedPrice;
        }

        public void setRank(Rank val) { }
    }
}