using System.ComponentModel.DataAnnotations.Schema;


namespace Kurdi.Inventory.Core.Entities.SalesOrderAggregate
{
    [Table(name: "sales_order_status")]
    public class SalesOrderStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}