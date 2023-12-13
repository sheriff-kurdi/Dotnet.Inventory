using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Kurdi.Inventory.Core.Entities
{
    [Owned]
    public class TimeStamps
    {
        [Column(name: "created_at")]
        public DateTime CreatedAt { get; set; }
        [Column(name: "updated_at")]
        public DateTime UpdatedAt { get; set; }
        [Column(name: "deleted_at")]
        public DateTime DeletedAt { get; set; }
    }
}