using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace TaxiManagementAssignment
{
    public class UserUI
    {
        private RankManager rankMgr;
        private TaxiManager taxiMgr;
        private TransactionManager transactionMgr;

        public UserUI(RankManager rkMgr, TaxiManager txMgr, TransactionManager trMgr)
        {
            rankMgr = rkMgr;
            taxiMgr = txMgr;
            transactionMgr = trMgr;
        }

        public List<string> TaxiJoinsRank(int taxiNum, int rankId)
        {
            Taxi taxi = taxiMgr.FindTaxi(taxiNum);
            if (taxi == null)
            {
                taxi = taxiMgr.CreateTaxi(taxiNum);
            }
            if (rankMgr.AddTaxiToRank(taxi, rankId))
            {
                transactionMgr.RecordJoin(taxiNum, rankId);
                return new List<string> { $"Taxi {taxiNum} has joined rank {rankId}." };
            }
            return new List<string> { $"Taxi {taxiNum} has not joined rank {rankId}." };
        }

        public List<string> TaxiLeavesRank(int rankId, string destination, double agreedPrice)
        {
            Taxi taxi = rankMgr.FrontTaxiInRankTakesFare(rankId, destination, agreedPrice);
            if (taxi != null)
            {
                transactionMgr.RecordLeave(rankId, taxi);
                return new List<string> { $"Taxi {taxi.GetNumber()} has left rank {rankId} to take a fare to {destination} for £{agreedPrice:0.00}." };
            }
            return new List<string> { $"Taxi has not left rank {rankId}." };
        }

        public List<string> TaxiDropsFare(int taxiNum, bool pricePaid)
        {
            Taxi taxi = taxiMgr.FindTaxi(taxiNum);
            List<string> notification = new List<string>();

            if (!string.IsNullOrEmpty(taxi.Destination))
            {
                if (pricePaid)
                {
                    taxi.DropFare(pricePaid);
                    transactionMgr.RecordDrop(taxiNum, pricePaid);
                    string message = $"Taxi {taxiNum} has dropped its fare and the price was paid.";
                    notification.Add(message);
                }
                else
                {
                    string message = $"Taxi {taxiNum} has dropped its fare and the price was not paid.";
                    notification.Add(message);
                }
            }
            else
            {
                 notification.Add($"Taxi {taxiNum} has not dropped its fare.");
            }

            return notification;
        }

        public List<string> ViewFinancialReport()
        {
            var taxis = taxiMgr.GetAllTaxis();
            double total = taxis.Values.Sum(t => t.GetTotalMoneyPaid());
            return new List<string> { $"Total money paid to all taxis: {total}" };
        }

        public List<string> ViewTaxiLocations()
        {
            var taxis = taxiMgr.GetAllTaxis();
            var results = new List<string>
            {
                $"Taxi locations",
                $"=============="
            };


            if (taxis == null || taxis.Count == 0)
            {
                results.Add("No taxis");

            }
            else 
            {
                foreach (var taxi in taxis.Values)
                {
                    if (taxi.Destination != "")
                    {
                        results.Add($"Taxi {taxi.GetNumber()} is on the road to {taxi.GetDestination()}");
                    }
                    else
                    {
                        if (taxi.Location == Taxi.ON_ROAD)
                        {
                            results.Add($"Taxi {taxi.GetNumber()} is on the road");
                        }
                        else
                        {
                            results.Add($"Taxi {taxi.GetNumber()} is in rank {taxi.Rank.Id}");
                        }
                    }
                }

            }
            

            return results;
        }

        public List<string> ViewTransactionLog()
        {
            var transactions = transactionMgr.GetAllTransactions();
            var taxis = taxiMgr.GetAllTaxis();
            var results = new List<string>
            {
                $"Financial report",
                $"================"
            };

            if (taxis == null || taxis.Count == 0)
            {
                results.Add("No taxis, so no money taken");

            }

            return results;
        }
    }

}