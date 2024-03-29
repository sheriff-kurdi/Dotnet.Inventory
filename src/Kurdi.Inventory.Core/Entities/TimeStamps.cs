﻿using System;
using Microsoft.EntityFrameworkCore;

namespace Kurdi.Inventory.Core.Entities
{
    [Owned]
    public class TimeStamps
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}