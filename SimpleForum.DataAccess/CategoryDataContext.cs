﻿using SimpleForum.Domain.Forum;
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

            List<Category> categoryList;

            try
            {
                dataAccess.DataAdapter.Fill(dt);

                categoryList = dt.AsEnumerable().Select(x => new Category
                {
                    Id = x.Field<int>("id"),
                    Title = x.Field<string>("Title")           
                }).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return categoryList;
        }

        public List<Category> GetOne(int id)
        {
            DbAccess dataAccess = dbAccess.InitializeQuery($"SELECT * FROM [dbo].[Categories] WHERE [Id] = '{id}'");
            var dt = new DataTable();

            List<Category> categoryList;

            try
            {
                dataAccess.DataAdapter.Fill(dt);

                categoryList = dt.AsEnumerable().Select(x => new Category
                {
                    Id = x.Field<int>("id"),
                    Title = x.Field<string>("Title")
                }).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return categoryList;
        }

        public void Create(string title)
        {
            DbAccess dataAccess = dbAccess.InitializeQuery("INSERT INTO[dbo].[Categories]([Title]) VALUES('" + title + "');");
            var dt = new DataTable();

            try
            {
                dataAccess.DataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Category category)
        {
            DbAccess dataAccess = dbAccess.InitializeQuery($"UPDATE [dbo].[Categories] SET [Title] ='{category.Title}' WHERE [Id] = '{category.Id}'");
            var dt = new DataTable();

            try
            {
                dataAccess.DataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            DbAccess dataAccess = dbAccess.InitializeQuery($"DELETE FROM [dbo].[Categories] WHERE [Id] = '{id}'");
            var dt = new DataTable();

            try
            {
                dataAccess.DataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
