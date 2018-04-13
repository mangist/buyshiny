using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JH.BuyShiny.Database
{
    public class PostRead
    {
        [Key]
        public int PostId { get; set; }
        public Post Post { get; set; }
        [Key]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
