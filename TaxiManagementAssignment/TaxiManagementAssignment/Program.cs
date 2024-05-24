using System;
using System.Collections.Generic;

namespace TaxiManagementAssignment
{
  
    public class Program
    {
        private UserUI ui;
        public UserUI Ui { get { return ui; } }
        public static void Main(string[] args)
        {
            RankManager rankMgr = new RankManager();
            TaxiManager taxiMgr = new TaxiManager();
            TransactionManager transactionMgr = new TransactionManager();
            UserUI ui = new UserUI(rankMgr, taxiMgr, transactionMgr);

            Program program = new Program(ui);
            program.DisplayMenu();
        }

        public Program(UserUI userUI)
        {
            ui = userUI;
        }

        private void DisplayMenu()
        {
            Console.WriteLine("Welcome to Taxi Management System");
            Console.WriteLine("1. Display Menu");
            Console.WriteLine("2. View Financial Report");
            Console.WriteLine("3. View Taxi Locations");
            Console.WriteLine("4. View Transaction Log");
            Console.WriteLine("5. Exit");

            int choice = ReadInteger("Enter your choice: ");
            switch (choice)
            {
                case 1:
                    DisplayMenu();
                    break;
                case 2:
                    ViewFinancialReport();
                    break;
                case 3:
                    ViewTaxiLocations();
                    break;
                case 4:
                    ViewTransactionLog();
                    break;
                case 5:
                    Console.WriteLine("Exiting program...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    DisplayMenu();
                    break;
            }
        }
        private void DisplayResults(List<string> results)
        {
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }

        private void ViewFinancialReport()
        {
            Console.WriteLine(string.Join("\n", ui.ViewFinancialReport()));
        }

        private void ViewTaxiLocations()
        {
            Console.WriteLine(string.Join("\n", ui.ViewTaxiLocations()));
        }

        private void ViewTransactionLog()
        {
            Console.WriteLine(string.Join("\n", ui.ViewTransactionLog()));
        }

        private double ReadDouble(string prompt)
        {
            Console.WriteLine(prompt);
            return double.Parse(Console.ReadLine());
        }

        private int ReadInteger(string prompt)
        {
            Console.WriteLine(prompt);
            return int.Parse(Console.ReadLine());
        }

        private string ReadString(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }

        private void TaxiDropsFare()
        {
            Console.WriteLine("Enter your taxi number : ");
            int taxiNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Have you paid: ");
            bool pricePaid = Convert.ToBoolean(Console.ReadLine());

            ui.TaxiDropsFare(taxiNum, pricePaid);
        }

        private void TaxiJoinsRank()
        {
            Console.WriteLine("Enter taxi number: ");
            int taxiNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter rank number: ");
            int rankNumber = int.Parse(Console.ReadLine());

            ui.TaxiJoinsRank(taxiNumber, rankNumber);
        }

        private void TaxiLeavesRank()
        {
            Console.WriteLine("Enter rank number: ");
            int rankNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter destination: ");
            string destination = Console.ReadLine();
            Console.WriteLine("Enter fare: ");
            double fare = double.Parse(Console.ReadLine());

            ui.TaxiLeavesRank(rankNumber, destination, fare);
        }

    }
}

