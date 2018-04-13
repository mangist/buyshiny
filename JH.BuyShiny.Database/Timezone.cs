using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JH.BuyShiny.Database
{
    public class Timezone
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public int UtcOffsetMinutes { get; set; }
    }
}
