using System;
using Microsoft.AspNetCore.Mvc;
using Clockwork.API.Models;
using System.Collections.Generic;

namespace Clockwork.API.Controllers
{
    [Route("api/[controller]")]
    public class CurrentTimeController : Controller
    {
        // GET api/currenttime
        [HttpPost]
        public IActionResult Post(string timeZone)
        {
            var utcTime = DateTime.UtcNow;
            var ip = this.HttpContext.Connection.RemoteIpAddress.ToString();
            TimeZoneInfo timeInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
            var serverTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, timeInfo);
            var returnVal = new CurrentTimeQuery
            {
                UTCTime = utcTime,
                ClientIp = ip,
                Time = serverTime,
                TimeZone = timeZone
            };

            using (var db = new ClockworkContext())
            {
                db.CurrentTimeQueries.Add(returnVal);
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine();
                foreach (var CurrentTimeQuery in db.CurrentTimeQueries)
                {
                    Console.WriteLine(" - {0}", CurrentTimeQuery.UTCTime);
                }
            }

            return Ok(returnVal);
        }

        [HttpGet]
        [Route("List")]
        public List<CurrentTimeQuery> List()
        {
            var list = new List<CurrentTimeQuery>();
            using (var db = new ClockworkContext())
            {
                foreach (var currentTimeQuery in db.CurrentTimeQueries)
                {
                    list.Add(currentTimeQuery);
                }
            }
            return list;
        }
    }
}
