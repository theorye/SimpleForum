using SimpleForum.Domain.Forum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SimpleForum.DataAccess
{
    public class CategoryDataContext
    {
        private readonly DbAccess dbAccess;

        public CategoryDataContext(DbAccess dbAccess)
        {
            this.dbAccess = dbAccess;
        }

        public List<Category> Read()
        {
            DbAccess dataAccess = dbAccess.InitializeQuery("SELECT * FROM [dbo].[Categories]");
            var dt = new DataTable();

            List<Category> forumList;

            try
            {
                dataAccess.DataAdapter.Fill(dt);

                forumList = dt.AsEnumerable().Select(x => new Category
                {
                    Id = x.Field<int>("id"),
                    Title = x.Field<string>("Title")           
                }).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return forumList;
        }
    }
}
