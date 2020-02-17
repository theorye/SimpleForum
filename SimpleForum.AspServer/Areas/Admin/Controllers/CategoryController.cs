using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleForum.DataAccess;
using SimpleForum.Domain.Forum;

namespace SimpleForum.AspServer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly DbAccess dbAccess;

        public CategoryController(DbAccess dbAccess)
        {
            this.dbAccess = dbAccess;
        }

        // GET
        public IActionResult Index()
        {    

            List<Category> model = new CategoryDataContext(dbAccess).Read();
            return View(model);
        }

        // GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            List<Category> model = new CategoryDataContext(dbAccess).GetOne(id);
            
            if (model.Count() == 0)
            {
                return NotFound();
            }
            //List<Category> model = new CategoryDataContext(dbAccess).GetOne(id);


            return View(model[0]);
        }

        public IActionResult Edit(int id)
        {
            List<Category> model = new CategoryDataContext(dbAccess).GetOne(id);
            if (model.Count() == 0)
            {
                return NotFound();
            }

            return View(model[0]);
        }

        public IActionResult Delete(int id)
        {
            List<Category> model = new CategoryDataContext(dbAccess).GetOne(id);

            if (model.Count() == 0)
            {
                return NotFound();
            }

            return View(model[0]);
        }

        // Actions

        // POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
               new CategoryDataContext(dbAccess).Create(category.Title);

                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                new CategoryDataContext(dbAccess).Update(category);


                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            new CategoryDataContext(dbAccess).Delete(id);


            return RedirectToAction(nameof(Index));
        }

    }
}