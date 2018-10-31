using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using dojodachi.Models;
using Newtonsoft.Json;

namespace dojodachi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("pal")==null){
                Pal pal = new Pal();
                string jsonpal = JsonConvert.SerializeObject(pal);
                HttpContext.Session.SetString("pal",jsonpal);
                ViewBag.pal=pal;
            }
            else{
                string old = HttpContext.Session.GetString("pal");
                Pal pal = JsonConvert.DeserializeObject<Pal>(old);
                ViewBag.pal = pal;
            }
            return View("index");
        }
        [HttpPost("action")]
        public IActionResult Action(string action){
            string newpal=HttpContext.Session.GetString("pal");
            Pal pal = JsonConvert.DeserializeObject<Pal>(newpal); 

            if(action=="Feed"){
                pal.feed();
            }
            if(action=="Play"){
                pal.play();
            }
            if(action=="Work"){
                pal.work();
            }
            if(action=="Sleep"){
                pal.sleep();
            }
            if(pal.happiness <1 || pal.fullness<1){
                pal.status="your pal is dead";
            }
            if(pal.happiness >99 && pal.fullness>99 && pal.energy > 99){
                pal.status="you won the game, Good job!";
            }
            string jsonpal= JsonConvert.SerializeObject(pal);
            HttpContext.Session.SetString("pal",jsonpal);
            return RedirectToAction("index");
        }

    }
}
