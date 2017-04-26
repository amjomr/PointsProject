using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PointsProject.Models
{
    public class ProfileModels
    {
        //Info about them (Table: Points)
        public string email { get; set; }
        public int totalPoints { get; set; }
        public int availablePoints { get; set; }

        //where they have been or where they have swiped their card (Table: checkins)
        public DateTime date { get; set; }
        public string location { get; set; }
        public float period { get; set; }

        //Displaying what they have purchased (Table: purchases)
        public string item { get; set; }
        public int pointsSpent { get; set; }


    }
}