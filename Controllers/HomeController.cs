using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wedding.Models;
using Microsoft.AspNetCore.Http; 
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace wedding.Controllers
{

    public class HomeController : Controller
    {
        private MyContext dbContext;

        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("new")]
        public IActionResult UserToDB(RegisterForm regData)
        {

            if ( dbContext.Users.Any(u => u.Email == regData.Email))
                ModelState.AddModelError("Email", "Email already in use");
            if (!ModelState.IsValid)
                return View("Index");

            User newUser = new User();
            newUser.FirstName = regData.FirstName;
            newUser.LastName = regData.LastName;
            newUser.Email = regData.Email;
            var Hasher = new PasswordHasher<RegisterForm>();
            newUser.Password = Hasher.HashPassword(regData, regData.Password);
            dbContext.Add(newUser);
            dbContext.SaveChanges();
            System.Console.WriteLine($"MADE IT TO USERTODB CONTROLLER! New user id = {newUser.UserID}");

            HttpContext.Session.SetInt32("user", newUser.UserID);
            return RedirectToAction("dashboard");
        }
        [HttpPost("login/process")]
        public IActionResult LogInUser(LoginForm loginData)
        {
            var match = dbContext.Users
                .FirstOrDefault(u => u.Email == loginData.Email);
            if (match == null)
                ModelState.AddModelError("Email", "Invalid email or password");
            var Hasher = new PasswordHasher<LoginForm>();
            var result = Hasher
                .VerifyHashedPassword(
                    loginData, match.Password, loginData.Password
                );
            if (result == 0)
                ModelState.AddModelError("Email", "Invalid email or password");
            if (!ModelState.IsValid)
                return View("Index");
            
            int userID = match.UserID;
            HttpContext.Session.SetInt32("user", userID);
            return RedirectToAction("dashboard");
        }

        [Route("dashboard")]
        [HttpGet]
        public IActionResult Dashboard()
        {
            if (!HttpContext.Session.Keys.Contains("user"))
                return Redirect("/");
            List<Wedding> AllWeddings = dbContext.Weddings
                .Include(e => e.Guests)
                .ThenInclude(att => att.User)
                .ThenInclude(u => u.WeddingstoAttend)
                .ToList();
            List<Display> AllDisplays = new List<Display>();
            User thisUser = dbContext.Users
                .SingleOrDefault(u =>
                    u.UserID == HttpContext.Session.GetInt32("user"));
            foreach (Wedding e in AllWeddings)
            {
                Display thisDisaplay = new Display();
                thisDisaplay.DisplayID = e.WeddingID;
                thisDisaplay.Couple = $"{e.WedderOne} & {e.WedderTwo}";
                thisDisaplay.Date = e.Date;
                thisDisaplay.Address = e.Address;
                thisDisaplay.Guests = new List<User>();
                if (e.Creator == thisUser)
                    thisDisaplay.IsHosting = true;
                else
                    thisDisaplay.IsHosting = false;
                bool found = false;
                foreach (Associate a in e.Guests)
                {
                    thisDisaplay.Guests.Add(a.User);
                }
                foreach (User g in thisDisaplay.Guests)
                {
                    if (g.UserID == thisUser.UserID)
                    {
                        thisDisaplay.IsAttending = true;
                        found = true;
                    }
                }
                if (!found)
                    thisDisaplay.IsAttending = false;
                AllDisplays.Add(thisDisaplay);
            }
            return View(AllDisplays);
        }

        [Route("newwedding")]
        [HttpGet]
        public IActionResult NewWedding()
        {
            return View("NewWedding");
        }

        [Route("WeddingToDB")]
        [HttpPost]
        public IActionResult DisplayToDB(WeddingForm FormData)
        {
            if (!HttpContext.Session.Keys.Contains("user"))
                return RedirectToAction("Logout","User");
            if (!ModelState.IsValid)
                return View("WeddingForm");
            User host = dbContext.Users
                .SingleOrDefault(u =>
                    u.UserID == HttpContext.Session.GetInt32("user"));       
        
            Wedding newWedding = new Wedding();
            //     WedderOne = FormData.WedderOne,
            //     WedderTwo = FormData.WedderTwo,
            //     Date = FormData.Date,
            //     Address = FormData.Address
            // };

            newWedding.WedderOne = FormData.WedderOne;
            newWedding.WedderTwo = FormData.WedderTwo;
            newWedding.Date = FormData.Date;
            newWedding.Address = FormData.Address;
            newWedding.CreatedAt = DateTime.Now;
            newWedding.UpdatedAt = DateTime.Now;
            newWedding.UserID = host.UserID;
            dbContext.Weddings.Add(newWedding);
            dbContext.SaveChanges();
            
            return RedirectToAction("Dashboard");
        }

        [HttpGet("wedding/{id}")]
        public IActionResult WeddingInfo(int id)
        {
            if (!HttpContext.Session.Keys.Contains("user"))
                return RedirectToAction("Logout", "User");
            Wedding thisWedding = dbContext.Weddings
                .Include(e => e.Guests)
                .ThenInclude(att => att.User)
                .SingleOrDefault(e => e.WeddingID == id);
            Display thisDisplay = new Display();
            thisDisplay.Couple = $"{thisWedding.WedderOne} & {thisWedding.WedderTwo}";
            thisDisplay.Date = thisWedding.Date;
            string[] Address = thisWedding.Address.Split(" ");
            string AddressURLEscaped = string.Join("+", Address);
            thisDisplay.Address = 
                "https://maps.googleapis.com/maps/api/staticmap?" +
                "&size=600x400" +
                $"&markers={AddressURLEscaped}" +
                "&key=AIzaSyDJPcoUQGa4y5WZMVTWAm9u_GJ2xv9_JaY";
            thisDisplay.Guests = new List<User>();
            foreach (Associate g in thisWedding.Guests)
                thisDisplay.Guests.Add(g.User);

            return View("ShowWedding", thisDisplay);
        }
        [HttpGet("join/{id}")]
        public IActionResult JoinEvent(int id)
        {
            if (!HttpContext.Session.Keys.Contains("user"))
                return RedirectToAction("Logout");
            User thisUser = dbContext.Users
                .SingleOrDefault(u =>
                    u.UserID == HttpContext.Session.GetInt32("user"));
            Wedding thisWedding = dbContext.Weddings
                .SingleOrDefault(e => e.WeddingID == id);
            Associate newAtt = new Associate();
            newAtt.Wedding= thisWedding;
            newAtt.User = thisUser;
            dbContext.Assosiates.Add(newAtt);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }

        [HttpGet("leave/{id}")]
        public IActionResult LeaveEvent(int id)
        {
            if (!HttpContext.Session.Keys.Contains("user"))
                return RedirectToAction("Logout", "User");
            Associate cancellation = dbContext.Assosiates
                .SingleOrDefault(a =>
                    a.UserID == HttpContext.Session.GetInt32("user")
                        && a.WeddingID == id);
            dbContext.Assosiates.Remove(cancellation);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("delete/{id}")]
        public IActionResult DestroyWedding(int id)
        {
            if (!HttpContext.Session.Keys.Contains("user"))
                return RedirectToAction("Logout", "User");
            Wedding thisWedding = dbContext.Weddings
                .SingleOrDefault(e => e.WeddingID == id);
            dbContext.Weddings.Remove(thisWedding);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }









    }
}
