using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JH.BuyShiny.Database
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string PasswordHash { get; set; }
        public DateTime Created { get; set; }
        public bool Active { get; set; }
        public bool EmailVerified { get; set; }
        public virtual Timezone Timezone { get; set; }
        public virtual ICollection<UserRole> Roles { get; set; }
    }
}
