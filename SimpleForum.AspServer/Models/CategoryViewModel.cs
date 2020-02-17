using SimpleForum.Domain.Forum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleForum.AspServer.Models
{
    public class CategoryViewModel
    {
        public IEnumerable<Category> Category { get; set; }
    }
}
