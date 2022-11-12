using Microsoft.AspNetCore.Mvc;
using MVC_Proj.Models;
using MVC_Proj.Models.Entites;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Proj.Controllers
{
    public class CitiesController : Controller
    {
        //This is a field we call of the context insted of initalising a new instence of it everytime we call the controller
        private readonly ApplicationDBContext _context;

        //This is a constuctor that applies DI
        public CitiesController(ApplicationDBContext context)
        {
            _context = context;
        }

       
        public IActionResult Index()
        {           
            var citiesList = _context.Cities.ToList();
            ViewBag.MyViewBag = "Actions";
            return View(citiesList);
        }

        public IActionResult IndexAPI()
        {
            var citiesList = _context.Cities.ToList();
            return Json(citiesList);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Cities cities) 
        {
            cities.createdDate = DateTime.Now;
            _context.Add(cities);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var data = _context.Cities.Where(x => x.CityID == id).SingleOrDefault();
            return View(data);
        }


        [HttpPost]
        public IActionResult Update(Cities cities, int id)
        {
            try
            {
                var data = _context.Cities.FirstOrDefault(x => x.CityID == id);
                //if (data != null)
                //{
                    data.Name = cities.Name;
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                //}
                //else
                //{
                //    return View();
                //}
            }
            catch(Exception ex)
            {
                return NotFound();
            }

           
            
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _context.Cities.Find(id);
            return View(data);
        }


        [HttpPost]
        public IActionResult Delete(Cities cities, int id)
        {
            var data = _context.Cities.FirstOrDefault(x => x.CityID == id);
            if (data != null)
            {
                //check if element in the list meets the condition
                var checkRef = _context.Persons.Any(x => x.Address == data.CityID);

                if (checkRef)
                {
                    return View("../Shared/Error");                   
                }
                else
                {
                    _context.Cities.Remove(data);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }

            }
            else
            {
                return View();
            }

        }


    }
}
