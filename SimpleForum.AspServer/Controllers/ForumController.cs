using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleForum.AspServer.Models;
using SimpleForum.DataAccess;
using SimpleForum.Domain.Forum;

namespace SimpleForum.AspServer.Controllers
{
    public class ForumController : Controller
    {
        private readonly DbAccess dbAccess;

        public ForumController(DbAccess dbAccess)
        {
            this.dbAccess = dbAccess;
        }

        public IActionResult Index()
        {
            ForumModel FI = new ForumModel();


            //Connection = new SqlConnection(UniversalConnectionString);
            //var adapter = new SqlDataAdapter("SELECT * FROM [dbo].[Forums]", Connection);
            //var ds = new DataTable();
            //adapter.Fill(ds);

            //List<Forum> list = ds.AsEnumerable().Select(x => new Forum
            //{
            //    Id = x.Field<int>("id"),
            //    Title = x.Field<string>("Title"),
            //    Description = x.Field<string>("Description")
            //}).ToList();

            //return this;

            DbAccess dataAccess = dbAccess.InitializeQuery("SELECT * FROM [dbo].[Forums]");
            var dt = new DataTable();


            try
            {
                dataAccess.DataAdapter.Fill(dt);

                List<Forum> forumList = dt.AsEnumerable().Select(x => new Forum
                {
                    Id = x.Field<int>("id"),
                    Title = x.Field<string>("Title"),
                    Description = x.Field<string>("Description")
                }).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return View(FI);
        }

        public IActionResult Create()
        {
            return View();
        }

  /*      // POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create()*/
    }
}