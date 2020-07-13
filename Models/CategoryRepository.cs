using System;
using System.Collections.Generic;

namespace ShowWatch.Models
{
    public class CategoryRepository : ICategoryReposirory
    {
        private readonly AppDbContext context;

        public CategoryRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Category> Gets()
        {
            return context.Categories;
        }
    }
}
