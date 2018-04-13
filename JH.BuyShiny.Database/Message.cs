using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JH.BuyShiny.Database
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public User Sender { get; set; }
        public User Recipient { get; set; }
        public DateTime SentTimeUtc { get; set; }
        [StringLength(100)]
        public string Subject { get; set; }
        [StringLength(10000)]
        public string Body { get; set; }
        public bool Read { get; set; }
    }
}
