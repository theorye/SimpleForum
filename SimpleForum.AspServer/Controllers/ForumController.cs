using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleForum.AspServer.Models;
using SimpleForum.DataAccess;

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

            DbAccess dataAccess = dbAccess.RunQuery("SELECT * FROM [dbo].[Forums]");

            try
            {
                dbAccess.ExecuteReader();

                if(dbAccess.DataReader.HasRows)
                {
                    while (dbAccess.DataReader.Read())
                    {
                        FI.Title = dbAccess.DataReader["Title"].ToString();
                        FI.Description = dbAccess.DataReader["Description"].ToString();
                    }
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally 
            {
                dbAccess.Close();
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