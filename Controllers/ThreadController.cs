using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleMessageBoard.Data;
using SampleMessageBoard.Models;
using SampleMessageBoard.ViewModels;

namespace SampleMessageBoard.Controllers
{
    public class ThreadController : Controller
    {
        private ApplicationDBContext _db;

        public ThreadController(ApplicationDBContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Index(int id)
        {
            var posts = _db.Posts.Where(p => p.ThreadId == id).ToList();
            return View(posts);
        }
        [HttpGet]
        public IActionResult Reply()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Reply(int id, PostViewModel newPost)
        {
            _db.Posts.Add(new Post()
            {
                ThreadId = id,
                Content = newPost.Content,
                AuthorUsername = newPost.Username,
                PublishDate = DateTime.Now
            });
            _db.SaveChanges();

            return RedirectToAction(actionName: "Index", routeValues: new { id = id });
        }
    }
}
