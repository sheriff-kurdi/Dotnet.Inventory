using System;

namespace Kurdi.Inventory.Core.Exceptions
{
    public class NegativeStockTransactionException()
        : Exception(string.Format("Transaction leeds to negative stock has been disabled"));
}
