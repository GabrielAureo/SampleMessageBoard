using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleMessageBoard.Data;
using SampleMessageBoard.Models;

namespace SampleMessageBoard.Controllers
{
    public class ForumController : Controller
    {
        private ApplicationDBContext _db;

        public ForumController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Thread> threadList = _db.Threads;
            return View(threadList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ViewModels.ThreadViewModel threadViewModel)
        {
            var newThread = new Thread()
            {
                Title = threadViewModel.Title
            };
            _db.Threads.Add(newThread);
            _db.SaveChanges();
            var newPost = new Post()
            {
                Content = threadViewModel.FirstPostContent,
                ThreadId = newThread.Id,
                PublishDate = DateTime.Now,
                AuthorUsername = threadViewModel.Username
            };
            _db.Posts.Add(newPost);

            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
