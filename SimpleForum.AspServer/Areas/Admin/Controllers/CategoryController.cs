using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleForum.AspServer.Models;
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

        public IActionResult Index()
        {
            CategoryModel cM = new CategoryModel();

            var list = new CategoryDataContext(dbAccess).Read();

            return View(cM);
        }
    }
}