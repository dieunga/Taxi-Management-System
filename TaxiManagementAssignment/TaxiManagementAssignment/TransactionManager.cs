using System.Collections.Generic;
using System;

public class TransactionManager
{
    private List<Transaction> transactions = new List<Transaction>();

    public void RecordDrop(int taxiNum, bool pricePaid)
    {
        transactions.Add(new DropTransaction(DateTime.Now, taxiNum, pricePaid));
    }

    public void RecordJoin(int taxiNum, int rankId)
    {
        transactions.Add(new JoinTransaction(DateTime.Now, taxiNum, rankId));
    }

    public void RecordLeave(int rankId, Taxi taxi)
    {
        transactions.Add(new LeaveTransaction(DateTime.Now, rankId, taxi));
    }

    public List<Transaction> GetAllTransactions()
    {
        return transactions;
    }
}