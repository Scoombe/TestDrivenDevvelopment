using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInfo
{
    interface IWebServiceClass
    {
        bool authenticate(int userID, string password);
        string getStockInfo(string symbol);
    }
}
