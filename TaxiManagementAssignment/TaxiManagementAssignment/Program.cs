using System;

public class Program
{
    static void Main(string[] args)
    {
        RankManager rankMgr = new RankManager();
        TaxiManager taxiMgr = new TaxiManager();
        TransactionManager transactionMgr = new TransactionManager();
        UserUI ui = new UserUI(rankMgr, taxiMgr, transactionMgr);

        // Simulate some operations
        ui.TaxiJoinsRank(1, 101);
        ui.TaxiJoinsRank(2, 101);
        ui.TaxiLeavesRank(101, "Downtown", 20.0);
        ui.TaxiDropsFare(1, true);

        Console.WriteLine(string.Join("\n", ui.ViewFinancialReport()));
        Console.WriteLine(string.Join("\n", ui.ViewTaxiLocations()));
        Console.WriteLine(string.Join("\n", ui.ViewTransactionLog()));
    }
}
