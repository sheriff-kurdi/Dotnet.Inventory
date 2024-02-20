using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kurdi.Inventory.Core.Entities.SalesOrderAggregate
{
    [Table(name: "sales_orders")]
    public class SalesOrder : IAggregateRoot
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public double Discount { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public SalesOrderStatus Status { get; set; }
        public List<SalesOrderProduct> SalesOrderProducts { get; set; } = [];
    }
}