using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kurdi.Inventory.Core.Entities.SalesOrderAggregate
{
    [Table(name: "sales_orders")]
    public class SalesOrder : IAggregateRoot
    {
        public int Id { get; set; }
        public double totalPrice { get; set; }
        public double Discount { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public SalesOrderStatus Status { get; set; }
        public List<SalesOrderProduct> SalesOrderProducts { get; set; } = new List<SalesOrderProduct>();
    } 
}