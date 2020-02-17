using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleForum.AspServer.Models;
using SimpleForum.DataAccess;

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

            DbAccess dataAccess = dbAccess.RunQuery("SELECT * FROM [dbo].[Categories]");

            try
            {
                dbAccess.ExecuteReader();
                while (dbAccess.DataReader.Read())
                {
                    cM.Title = dbAccess.DataReader["Title"].ToString();
                    cM.Description = dbAccess.DataReader["Description"].ToString();
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

            return View(cM);
        }
    }
}