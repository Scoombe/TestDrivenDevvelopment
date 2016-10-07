using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInfo
{
    public class StockInformation
    {
        //constrructors
        #region constructor
        public StockInformation(int userID,string password, string symbol)
        {
            //variables
            bool isAuthenticated;
            string stockInfo;
            string upperSymbol;
            string validString;
            validString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ01234565789";
            string[] stockInfoSplit;
            //assigning values
            StubWebServiceClass webservice = new StubWebServiceClass();
            isAuthenticated = webservice.authenticate(userID, password);
            //checking that the username and password are authentic
            if (isAuthenticated)
            {
                upperSymbol = symbol.ToUpper(); 
                //to complete add symbol athentication here and the if for the avaiable
                for (int i = 0; i < symbol.Length; i++)
                {
                    if (!validString.Contains(upperSymbol[i]))
                    {
                        throw new Exception("Invalid symbol format");
                    }
                }
                available = true;
                stockInfo = webservice.getStockInfo(symbol);
                //checking that the stock info is not equal to No such symbol meanning that the symbol doesn't exist
                //in the dummy webservice we have set the only symbol that doesn't exist to notexists
                if (stockInfo == "No such symbol exists")
                {
                    exists = false;
                }
                else
                {
                    //splitting the returned stockinfo from the web service to get at the info one by one.
                    stockInfoSplit = stockInfo.Split(',');
                    this.symbol = symbol;
                    exists = true;
                    companyName = stockInfoSplit[1];
                    //can throw an exception if incorectly formatted
                    currentPrice = Int32.Parse(stockInfoSplit[2]);
                    //can throw an exception if incorectly formatted
                    numberOfSharesOutstanding = Int32.Parse(stockInfoSplit[3]);
                }

            }
            else
            {
                companyName = "Not allowed";
                this.symbol = " ";
                available = false;
                exists = false;
                currentPrice = 0;
                numberOfSharesOutstanding = 0;
            }
       
        }
        #endregion

        #region properties
        //variables
        private int _marketCapitilisationInMillions;
        //properties
        public string symbol { get; private set; }
        public bool available { get; private set; }    
        public bool exists { get; private set; }
        public string companyName { get; private set; }
        public int currentPrice { get; private set; }
        public int numberOfSharesOutstanding { get; private set; }
        //the get returns the outstanding shares times the price
        public int marketCapitilisationInMillions {get
            {
                decimal tempMarketCap;
                tempMarketCap = (decimal)numberOfSharesOutstanding * (decimal)currentPrice;
                tempMarketCap = tempMarketCap / 1000000;
                _marketCapitilisationInMillions = Convert.ToInt32(Math.Floor(tempMarketCap));               
                return _marketCapitilisationInMillions;
            }
            private set{ _marketCapitilisationInMillions = value; }
        }
        #endregion

        #region methods
        //methods
        public string toString()
        {
            return companyName + "[" + symbol + "]" + currentPrice;
        }
        #endregion
    }
}
