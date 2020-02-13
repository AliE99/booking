using System.Collections.Generic;
using System;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Booking.Models;
using System.Linq;
namespace Booking.Controllers
{
    [Route ("/shows")]
    [ApiController]
    public class ShowsController:Controller
    {
        private readonly AppDbContext _context;
        public int MaximumPrice=100;
        public  TimeSpan MinimumTime  = new TimeSpan(0,30,0);
        public TimeSpan MaximumTime=new TimeSpan(2,0,0);
        public ShowsController(AppDbContext context)
        {
            _context =context;
        }
        [HttpPost]
        public ActionResult <string> CreateShow([FromBody]Show show)
        {  

            var testShow =_context.Shows.Find(show.Id);

            if(testShow!=null)
            {
                Console.WriteLine("conflict request id");
                return Conflict();
            }

            if(show.StartTime.Hour>=show.EndTime.Hour)
            {
                Console.WriteLine("bad request time");
                return BadRequest();
            }

            if(show.Price < 0)
            {
                Console.WriteLine("bad request price");
                return BadRequest();
            }

            if(show.StartTime<=DateTime.Now)
            {
                Console.WriteLine("bad request starttime<now");
                return BadRequest();
            }

            var salonId=_context.Salons.Find(show.SalonId);

            if(salonId==null)
            {
                Console.WriteLine("bad request salon id null");
                return BadRequest();
            }

            char[] titleCharacters=show.Title.ToCharArray();

            if(titleCharacters.Length>10)
            {
                Console.WriteLine("bad request charachter length");
                return BadRequest();
            }
            if(show.Price>MaximumPrice)
            {
                Console.WriteLine("bad request maximum price");
                return BadRequest();
            }

            var showTime=show.EndTime-show.StartTime;

            if(showTime<MinimumTime||showTime>MaximumTime)
            {
                Console.WriteLine("bad request minimum maximum time");
                return BadRequest();

            }

            bool hasConflict = DefinedShowHaveConflict(show);

            if(hasConflict)
            {
                Console.WriteLine("conflict request salon");
                return Conflict();
            }

            _context.Shows.Add(show);
            _context.SaveChanges();
            return Ok();
        }
        
        public bool DefinedShowHaveConflict(Show show){

            IEnumerable<Show> query =
               from Var in _context.Shows.AsEnumerable()
               where ShowsTimeHaveConflict(Var,show)
               select Var;
            foreach(var VARIABLE in query)
            {
                if(VARIABLE.SalonId == show.SalonId)
                {
                        return true;
                }
            }
            return false;
        }
        public bool ShowsTimeHaveConflict([FromQuery]Show show1, Show show2)
        {
            if(show1.StartTime.Date==show2.StartTime.Date)
            {
                if(show1.StartTime.Hour<=show2.StartTime.Hour&&show2.StartTime<=show1.EndTime)
                {
                    return true;
                }
                if(show1.StartTime.Hour<=show2.EndTime.Hour&&show2.EndTime.Hour<=show1.EndTime.Hour)
                {
                    return true;
                }
                if(show1.StartTime.Hour<=show2.StartTime.Hour&& show1.EndTime.Hour>=show2.EndTime.Hour)
                {
                    return true;
                }
                if(show2.StartTime.Hour<=show1.StartTime.Hour&&show2.EndTime.Hour>=show1.EndTime.Hour)
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;

            }
        }
        
    }
}