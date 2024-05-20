using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;


public class Taxi
{
    public int Number { get; private set; }
    public double CurrentFare { get; private set; }
    public string Destination { get; private set; } = "";
    public string Location { get; private set; } = ON_ROAD;
    public double TotalMoneyPaid { get; private set; } = 0;
    public Rank rank { get { return Rank; } set { if (value == null) { throw new Exception("Rank cannot be null"); } else Rank = value; } }

    public const string IN_RANK = "in rank";
    public const string ON_ROAD = "on the road";

    public Taxi(int taxiNum)
    {
        Number = taxiNum;
    }

    public void AddFare(string destination, double agreedPrice)
    {
        Destination = destination;
        CurrentFare = agreedPrice;
    }

    public void DropFare(bool priceWasPaid)
    {
        if (priceWasPaid)
        {
            TotalMoneyPaid += CurrentFare;
        }
        Destination = "";
        CurrentFare = 0;
        Location = ON_ROAD;
    }
}
