using BigWord.Data.Context;
using BigWord.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace BigWord.Controllers
{
    public class SearchController(WordsDbContext context) : Controller
    {

        [HttpGet]
        public IActionResult Index(string query)
        {
            if (query != null && string.IsNullOrWhiteSpace(query))
            {
                ViewBag.Message = "Please enter a search term.";
                return View(new List<Word>());
            }

            else if (query != null && !string.IsNullOrWhiteSpace(query))
            {
                List<Word> results = context.Words
                        .Where(w => w.Value.ToLower().Contains(query.ToLower()))
                        .OrderBy(w => w.Value)
                        .ToList();

                return View(results);
            }

            return View();
        }

    }
}
