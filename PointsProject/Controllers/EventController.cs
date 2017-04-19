﻿
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Web.Mvc;
using System.Web;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

using Microsoft.Owin.Security;
using Google.Apis.Auth.OAuth2.Responses;
using PointsProject.Models;
using System.Diagnostics;

namespace PointsProject.Controllers
{
 //   [Authorize]
    public class EventController : Controller
    {
        private readonly IDataStore dataStore = new FileDataStore(GoogleWebAuthorizationBroker.Folder);
        static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        // this is change for testing git


        // GET: /Calendar/UpcomingEvents
        public ActionResult Event()
        {


            var model = new UpcomingEventsViewModel();

            UserCredential credential;
            var path = Server.MapPath("~/App_Data/client_secret.json");
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.Load(stream).Secrets,
                Scopes,
                "LookIAmAUniqueUser",
                CancellationToken.None,
                new FileDataStore("Drive.Auth.Store")).Result;
            }

            var initializer = new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "PointsProject",
            };
            var service = new CalendarService(initializer);
            string[] calendarIDs = new string[6] { "0rn5mgclnhc7htmh0ht0cc5pgk@group.calendar.google.com", "l9qpkh5gb7dhjqv8nm0mn098fk@group.calendar.google.com", "d6jbgjhudph2mpef1cguhn4g9g@group.calendar.google.com", "m6h2d5afcjfnmaj8qr7o96q89c@group.calendar.google.com", "gqv0n6j15pppdh0t8adgc1n1ts@group.calendar.google.com", "h4j413d3q0uftb2crk0t92jjlc@group.calendar.google.com" };
            //in order of "Academics", "Student Activities", "Warrior Athletics", "Entertainment", "Residence Life","Campus Rec" 
            int[] calendarpoints = new int[6] { 700, 600, 500, 400, 300, 200 };
            EventsResource.ListRequest request = service.Events.List("l9qpkh5gb7dhjqv8nm0mn098fk@group.calendar.google.com");
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
            Events events = request.Execute();
            var eventGroups = new List<CalendarEventGroup>();
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    string when = eventItem.Start.DateTime.ToString();
                    string allsum = eventItem.Summary.ToString();

                    if (String.IsNullOrEmpty(when))
                    {
                        when = eventItem.Start.Date;
                    }
                    eventGroups.Add(new CalendarEventGroup
                    {
                        GroupTitle = when,
                        Events = allsum,
                    });

                }
            }


            model.EventGroups = eventGroups;
            return View(model);


        }
    }
}