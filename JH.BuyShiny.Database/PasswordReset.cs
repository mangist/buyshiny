using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JH.BuyShiny.Database
{
    public class PasswordReset
    {
        [Key]
        public string Code { get; set; }
        public DateTime ResetRequestDate { get; set; }
        public DateTime? ActivatedDate { get; set; }
        public User User { get; set; }
    }
}
