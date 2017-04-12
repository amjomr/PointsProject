using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PointsProject.Models
{

    /// <summary>
    /// A view model for the UpcomingEvents view.
    /// </summary>
    public class UpcomingEventsViewModel
    {
        /// <summary>
        /// Gets or sets a sequence of event groups to display.
        /// </summary>
        [Required]
        public IEnumerable<CalendarEventGroup> EventGroups { get; set; }
        
    }

   
}