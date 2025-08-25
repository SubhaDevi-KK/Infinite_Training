using System.Web.Mvc;
using Question2.Models;
using Question2.Repository;

namespace Question2.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _repo;

        public MovieController()
        {
            _repo = new MovieRepository();
        }

        public ActionResult Index()
        {
            var movies = _repo.GetAll();
            return View(movies);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            var movie = _repo.GetById(id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Delete(int id)
        {
            var movie = _repo.GetById(id);
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult MoviesByYear(int year)
        {
            var movies = _repo.GetByYear(year);
            return View("Index", movies);
        }

        public ActionResult MoviesByDirector(string directorName)
        {
            var movies = _repo.GetByDirector(directorName);
            return View("Index", movies);
        }
    }
}

