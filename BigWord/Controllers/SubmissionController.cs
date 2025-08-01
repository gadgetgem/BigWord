using BigWord.BL.Services;
using BigWord.Data.Context;
using BigWord.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace BigWord.Controllers
{
    public class SubmissionController(WordsDbContext context, IValidWordService validWordService) : Controller
    {
        [HttpGet]
        public IActionResult Submit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(string input)
        {
            string validWord = validWordService.GetLongestValidWord(input);

            if (string.IsNullOrEmpty(validWord))
            {
                ViewBag.Error = $"No valid word found in {input}."
                    + Environment.NewLine +
                    "Must be at least 8 characters, contain uppercase, lowercase, digit, and no repeating characters.";
                return View();
            }
            if (context.Words.Any(w => w.Value.ToLower() == validWord.ToLower()))
            {
                ViewBag.Error = "Word already exists.";
                return View();
            }

            Word word = new Word { Value = validWord };
            context.Words.Add(word);
            context.SaveChanges();

            ViewBag.Success = $"Word '{validWord}' submitted successfully!";
            return View();
        }
    }
}
