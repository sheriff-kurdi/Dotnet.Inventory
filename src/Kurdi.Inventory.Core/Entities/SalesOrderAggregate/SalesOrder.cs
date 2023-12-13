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
        [Column(name: "id")]
        public int Id { get; set; }
        [Column(name: "total_price")]
        public double totalPrice { get; set; }
        [Column(name: "discount")]
        public double Discount { get; set; }
        [ForeignKey("Status")]
        [Column(name: "status_id")]
        public int StatusId { get; set; }
        public SalesOrderStatus Status { get; set; }
        public List<SalesOrderProduct> SalesOrderProducts { get; set; } = new List<SalesOrderProduct>();
    } 
}