using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JH.BuyShiny.Database
{
    public class UserVerify
    {
        [Key]
        public string Token { get; set; }
        public User User { get; set; }
        public DateTime ExpirationDateUtc { get; set; }
        public DateTime? VerifiedAtUtc { get; set; }
   }
}
