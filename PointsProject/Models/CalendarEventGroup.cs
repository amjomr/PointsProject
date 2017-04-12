using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Google.Apis.Calendar.v3.Data;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PointsProject.Models
{
    public class CalendarEventGroup
    {
        /// <summary>
        /// Gets or sets a string to show above the group of events.
        /// </summary>
        [Required]
        public string GroupTitle { get; set; }
        /// <summary>
        /// Gets or sets a sequence of calendar events to show under the group title.
        /// </summary>
        [Required]
        public string Events { get; set; }
    }
}