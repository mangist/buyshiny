using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JH.BuyShiny.Database
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        public Reply Reply { get; set; }
        public User User { get; set; } // Target user
        public DateTime FeedbackTimeUtc { get; set; }
        public int Counter { get; set; }
        [Range(1, 5)]
        public int StarRating { get; set; }
        [StringLength(500)]
        public string Comment { get; set; }
    }
}
