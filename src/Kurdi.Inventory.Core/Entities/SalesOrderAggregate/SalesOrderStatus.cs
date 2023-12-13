using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kurdi.Inventory.Core.Entities.SalesOrderAggregate
{
    [Table(name: "sales_order_status")]
    public class SalesOrderStatus
    {
        [Column(name: "id")]
        public int Id { get; set; }
        [Column(name: "name")]
        public string Name { get; set; }
    }
}