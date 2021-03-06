﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PointsProject.Models;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;

namespace PointsProject.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        static string[] Scopes = { CalendarService.Scope.CalendarReadonly };

        public ActionResult Index()
        {
            var model = new UpcomingEventsViewModel();
            var folder = System.Web.HttpContext.Current.Server.MapPath("~/Content/MyGoogleStorage");
            UserCredential credential;
            var path = Server.MapPath("~/App_Data/client_secret.json");
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { CalendarService.Scope.CalendarReadonly },
                    "user", CancellationToken.None,
                    new FileDataStore(folder)).Result;
            }

            var initializer = new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "lcsc-points-system",
            };
            var service = new CalendarService(initializer);
            var eventGroups = new List<CalendarEventGroup>();
            string[] calendarIDs = new string[6] { "0rn5mgclnhc7htmh0ht0cc5pgk@group.calendar.google.com", "l9qpkh5gb7dhjqv8nm0mn098fk@group.calendar.google.com", "d6jbgjhudph2mpef1cguhn4g9g@group.calendar.google.com", "m6h2d5afcjfnmaj8qr7o96q89c@group.calendar.google.com", "gqv0n6j15pppdh0t8adgc1n1ts@group.calendar.google.com", "h4j413d3q0uftb2crk0t92jjlc@group.calendar.google.com" };
            //in order of "Academics", "Student Activities", "Warrior Athletics", "Entertainment", "Residence Life","Campus Rec" 
            string[] calidentity = new string[6] { "Academics", "Student Activities", "Warrior Athletics", "Entertainment", "Residence Life", "Campus Rec" };
            string[] calendarpoints = new string[6] { "700points", "600point", "500points", "400points", "300points", "200points" };
            //this calendarpoints are string because I was lazy enough to do some work on Event.cshtml file.
            //if we want to change back to int, then we need to change to int[]  new int[6],
            // and go to CalendarEventGroup.cs in the model, change "public string points" to "public int points"
            for (int i = 0; i < calendarIDs.Length; i++)
            {
                EventsResource.ListRequest request = service.Events.List(calendarIDs[i]);
                request.TimeMin = DateTime.Now;
                request.ShowDeleted = false;
                request.SingleEvents = true;
                //request.MaxResults = 3;
                request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
                Events events = request.Execute();

                // chng

                if (events.Items != null && events.Items.Count > 0)
                {
                    foreach (var eventItem in events.Items)
                    {

                        string when = eventItem.Start.DateTime.ToString();
                        string allsum = eventItem.Summary.ToString();
                        string htmlink = eventItem.HtmlLink;
                        DateTime actualschedule;
                        if (String.IsNullOrEmpty(when))
                        {
                            when = eventItem.Start.Date;
                            actualschedule = Convert.ToDateTime(when);
                        }
                        else
                        {
                            actualschedule = Convert.ToDateTime(when);
                        }


                        eventGroups.Add(new CalendarEventGroup
                        {

                            Events = allsum,
                            startdate = actualschedule,
                            points = calendarpoints[i],
                            fromcalendar = calidentity[i],
                            thelink = htmlink,

                        });

                    }
                }
            }
            eventGroups.Sort((x, y) => x.startdate.CompareTo(y.startdate));
            var firstFiveItems = eventGroups.Take(5);
            //if you want shorter version of list of events, use firstFiveItems, instead of eventGroups on one line below
            model.EventGroups = eventGroups;
            //if we want to return multiple models, we need to either make another model that nests the other model
            //or there might be different solution. 
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}