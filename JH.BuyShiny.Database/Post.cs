using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JH.BuyShiny.Database
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime PostTimeUtc { get; set; }
        public User User { get; set; }
        public PostTypes PostType { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImageUrl { get; set; }
        public PostStatuses Status { get; set; }
        public int UpVotes { get; set; }
        public int DownVotes { get; set; }

    }
}
