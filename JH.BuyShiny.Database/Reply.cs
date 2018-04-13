using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JH.BuyShiny.Database
{
    public class Reply
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Post Post { get; set; }
        public User User { get; set; }
        public DateTime ReplyTimeUtc { get; set; }
        public string Message { get; set; }
        public int UpVotes { get; set; }
        public int DownVotes { get; set; }
        public bool TradeVerified { get; set; } // Will be used for feedback
    }
}
