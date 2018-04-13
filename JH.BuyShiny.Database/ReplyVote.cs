using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JH.BuyShiny.Database
{
    public class ReplyVote
    {
        [Key]
        public int ReplyId { get; set; }
        public Reply Reply { get; set; }
        [Key]
        public int UserId { get; set; }
        public User User { get; set; }
        public bool Up { get; set; }
        public bool Down { get; set; }
    }
}
