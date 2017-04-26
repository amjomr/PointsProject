using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace PointsProject.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }
        public int TotalPoints { get; set; }


        public List<Auction> Auction { get; set; }

    }
}