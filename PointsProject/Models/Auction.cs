using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PointsProject.Models
{
    public class Auction
    {
        [Key]
        public int AuctionId { get; set; }
        public int UserId { get; set; }
        [MaxLength(128)]
        public string Title { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
        public int HighestBid { get; set; }
        public byte[] Image { get; set; }
        public bool IsActive { get; set; }


        //public List<User> Users { get; set; }
    }
}