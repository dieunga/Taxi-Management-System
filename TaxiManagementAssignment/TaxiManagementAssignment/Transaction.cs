using System;

public abstract class Transaction
{
    public DateTime TransactionDatetime { get; private set; }
    public string TransactionType { get; private set; }

    public Transaction(string type, DateTime dt)
    {
        TransactionType = type;
        TransactionDatetime = dt;
    }

    public override string ToString()
    {
        return $"{TransactionType} at {TransactionDatetime}";
    }
}

public class JoinTransaction : Transaction
{
    public int TaxiNum;
    public int RankId;

    public JoinTransaction(DateTime dt, int taxiNum, int rankId)
        : base("Join", dt)
    {
        TaxiNum = taxiNum;
        RankId = rankId;
    }

    public override string ToString()
    {
        return base.ToString() + $" - Taxi {TaxiNum} joined Rank {RankId}";
    }
}

public class LeaveTransaction : Transaction
{
    public int TaxiNum;
    public int RankId;
    public string Destination;
    public double AgreedPrice;

    public LeaveTransaction(DateTime dt, int rankId, Taxi taxi)
        : base("Leave", dt)
    {
        TaxiNum = taxi.Number;
        RankId = rankId;
        Destination = taxi.Destination;
        AgreedPrice = taxi.CurrentFare;
    }

    public override string ToString()
    {
        return base.ToString() + $" - Taxi {TaxiNum} left Rank {RankId} for {Destination} at {AgreedPrice}";
    }
}

public class DropTransaction : Transaction
{
    public int TaxiNum;
    public bool PriceWasPaid;

    public DropTransaction(DateTime dt, int taxiNum, bool priceWasPaid)
        : base("Drop", dt)
    {
        TaxiNum = taxiNum;
        PriceWasPaid = priceWasPaid;
    }

    public override string ToString()
    {
        return base.ToString() + $" - Taxi {TaxiNum} drop fare with payment status: {PriceWasPaid}";
    }
}
