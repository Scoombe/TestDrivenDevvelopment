using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInfo
{
    class StubWebServiceClass: IWebServiceClass
    {
        //this is the dummy authenticate, usin the real webservice there would be authentication
        //in this instance I will just use a dummmy and only return Not allowed in certain instances. 
        //I have decided to do this as the webservice will be written by someone else and testing the webservice 
        //authentication of the password might be pointless depending on how the other person writes it.
        public bool authenticate(int userID, string password)
        {
            if(userID >9999 || userID < 1  || password == "dodgypassword")
            {
                return false;
            }
            return true; 
        }
        public string getStockInfo(string symbol)
        {
            if (symbol == "notexist"){
                return "No such symbol";
            }
            if (symbol == "dodgysymbol")
            {
                return symbol + "," + "asd" + "," + "asdd" + "," + "asdasd" + ",";
            }
            return symbol + "," + "QA" + "," + 1000000 + ","+ 5000 + ",";
        }
    }
}
