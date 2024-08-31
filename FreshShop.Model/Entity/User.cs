﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshShop.Model.Entity
{
    public class User : BaseEntity
    {
        public User() {
            Comments = new HashSet<ProductComment>();
        }

        public DateTime? RegisterDate { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ProductPhoto { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<ProductComment> Comments { get; set; }
    }
}
