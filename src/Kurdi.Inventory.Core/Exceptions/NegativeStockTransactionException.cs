using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kurdi.Inventory.Core.Exceptions
{
    public class NegativeStockTransactionException : Exception
    {

        public NegativeStockTransactionException() : base(String.Format("Transaction leeds to negative stock has been disabled"))
        {

        }
    }
}
