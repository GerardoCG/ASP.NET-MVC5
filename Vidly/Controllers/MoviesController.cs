using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Models.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {

            var genderTypes = _context.GenderTypes.ToList();
            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                GenderTypes = genderTypes
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var vieModel = new MovieFormViewModel
                {
                    Movie = movie,
                    GenderTypes = _context.GenderTypes.ToList()
                };
                return View("MovieForm", vieModel);
            }

            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);

                //Mapper.Map(customer, customerInDb);

                movieInDb.Name = movie.Name;
                movieInDb.GenderType = movie.GenderType;
            }
            _context.SaveChanges();

            return RedirectToAction("ListMovies", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                GenderTypes = _context.GenderTypes.ToList()
            };
            return View("MovieForm", viewModel);
        }

        // GET: Random
        public ActionResult ListMovies()
        {
            var movies = _context.Movies.Include(c => c.GenderType).ToList();
            return View(movies);
        }


        public ActionResult Details(int Id)
        {
            Movie movie = _context.Movies.Include(c => c.GenderType).SingleOrDefault(x => x.Id == Id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year+"/"+month);
        }
    }
}