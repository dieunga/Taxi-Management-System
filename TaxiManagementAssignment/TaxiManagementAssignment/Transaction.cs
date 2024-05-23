using System;
using System.Security.Cryptography.X509Certificates;
using System.Linq; 

namespace TaxiManagementAssignment
{
    public abstract class Transaction
    {
        private DateTime transactionDatetime;
        private string transactionType;

        public DateTime TransactionDatetime { get { return transactionDatetime; } }
        public string TransactionType { get { return transactionType; } }

        public Transaction(string type, DateTime dt)
        {
            transactionType = type;
            transactionDatetime = dt;
        }

        public override string ToString()
        {
            return $"{transactionType} at {transactionDatetime}";
        }
    }
    public class JoinTransaction : Transaction
    {
        private int taxiNum;
        private int rankId;

        public int TaxiNum { get { return taxiNum; } }  
        public int RankId { get { return rankId; } }

        public JoinTransaction(DateTime dt, int taxiNum, int rankId)
            : base("Join", dt)
        {
            this.taxiNum = taxiNum;
            this.rankId = rankId;
        }

        public override string ToString()
        {
            return $"{TransactionDatetime.ToString("dd/MM/yyyy HH:mm")} {TransactionType}      - Taxi {TaxiNum} in rank {RankId}";
        }
    }

    public class LeaveTransaction : Transaction
    {
        private int taxiNum;
        private int rankId;
        private string destination;
        private double agreedPrice;

        public int TaxiNum { get { return taxiNum; } }
        public int RankId { get { return rankId; } }
        public string Destination { get { return destination; } }
        public double AgreedPrice { get { return agreedPrice; } }

        public LeaveTransaction(DateTime dt, int rankId, Taxi taxi)
            : base("Leave", dt)
        {
            taxiNum = taxi.Number;
            this.rankId = rankId;
            destination = taxi.Destination;
            agreedPrice = taxi.CurrentFare;
        }

        public override string ToString()
        {
            return $"{TransactionDatetime.ToString("dd/MM/yyyy HH:mm")} {TransactionType,-9} - Taxi {TaxiNum} from rank {RankId} to {Destination} for £{AgreedPrice:F2}";
        }
    }

    public class DropTransaction : Transaction
    {
        private int taxiNum;
        private bool priceWasPaid;

        public int TaxiNum { get { return taxiNum; } }
        public bool PriceWasPaid { get { return priceWasPaid; } }

        public DropTransaction(DateTime dt, int taxiNum, bool priceWasPaid)
            : base("Drop fare", dt)
        {
            this.taxiNum = taxiNum;
            this.priceWasPaid = priceWasPaid;
        }

        public override string ToString()
        {
            string paymentStatus = PriceWasPaid ? "price was paid" : "price was not paid";
            return $"{TransactionDatetime.ToString("dd/MM/yyyy HH:mm")} Drop fare - Taxi {TaxiNum}, {paymentStatus}";
        }
    }

}
