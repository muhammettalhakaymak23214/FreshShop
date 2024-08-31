﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshShop.Model.Entity
{
    public class ProductComment : BaseEntity
    {
        public int? ProductId { get; set; }
        public int? UserId { get; set; }
        public DateTime? CommentDate { get; set; }
        public string? Comment { get; set; }

        public virtual Product? Product { get; set; }

        public virtual User? User { get; set; }


    }
}
