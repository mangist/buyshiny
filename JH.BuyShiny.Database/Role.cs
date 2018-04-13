using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JH.BuyShiny.Database
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<UserRole> Users { get; set; }
    }
}
