using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleForum.DataAccess;
using SimpleForum.Domain.Forum;

namespace SimpleForum.AspServer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ForumController : Controller
    {
        private readonly DbAccess dbAccess;

        public ForumController(DbAccess dbAccess)
        {
            this.dbAccess = dbAccess;
        }

        public IActionResult Index()
        {
            List<Forum> model = new ForumDataContext(dbAccess).Read();

            return View(model);
        }

        // GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        // POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Forum forum)
        {
            if (ModelState.IsValid)
            {
                new ForumDataContext(dbAccess).Create(forum);

                return RedirectToAction(nameof(Index));
            }
            return View(forum);
        }
    }
}