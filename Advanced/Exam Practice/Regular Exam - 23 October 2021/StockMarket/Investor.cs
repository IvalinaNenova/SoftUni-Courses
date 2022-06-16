using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> portfolio;

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            this.portfolio = new List<Stock>();
        }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public int Count => portfolio.Count;

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && this.MoneyToInvest >= stock.PricePerShare)
            {
                MoneyToInvest -= stock.PricePerShare;
                portfolio.Add(stock);
            }
        } 
        public string SellStock(string companyName, decimal sellPrice)
        {
            var stock = portfolio.FirstOrDefault(s => s.CompanyName == companyName);

            if (stock == null)
            {
                return $"{companyName} does not exist.";
            }
            if (sellPrice < stock.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }

            this.MoneyToInvest += sellPrice;
            portfolio.Remove(stock);
            return $"{companyName} was sold.";
        }
        public Stock FindStock(string companyName)
        {
            return portfolio.FirstOrDefault(s => s.CompanyName == companyName);
        }
        public Stock FindBiggestCompany()
        {
            if (!portfolio.Any())
            {
                return null;
            }
            decimal biggestCompanyValue = decimal.MinValue;
            foreach (var stock in portfolio)
            {
                if (stock.MarketCapitalization > biggestCompanyValue)
                {
                    biggestCompanyValue = stock.MarketCapitalization;
                }
            }

            return portfolio.Find(s => s.MarketCapitalization == biggestCompanyValue);
        }

        public string InvestorInformation()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            for (int i = 0; i < portfolio.Count-1; i++)
            {
                output.AppendLine(portfolio[i].ToString());
            }
            output.Append(portfolio[Count - 1].ToString());
            return output.ToString();
        }
    }
}
