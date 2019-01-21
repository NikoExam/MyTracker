using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTracker.Models;
using MyTracker.ViewModels;

namespace MyTracker.Controllers
{
    public class MoviesController : Controller
    {

        public ActionResult Movies()
        {

            var movies = new List<Movie>
            {
                new Movie{Name="Shrek"},
                new Movie{Name="Wall-e"}
            };

            var viewModel = new MovieViewModel
            {
                Movies = movies
            };

            return View(viewModel);
            
        }
       
        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
         public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/"+month);
        }
        public ActionResult Edit(int id)
        {
            return Content("id="+id);
        }

        //movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return Content(String.Format("pageIndex={0}&sortBy={1}",pageIndex,sortBy));
        }

        
    }
}