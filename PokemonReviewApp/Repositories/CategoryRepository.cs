using PokemonReviewApp.Contracts;
using PokemonReviewApp.Data;
using PokemonReviewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonReviewApp.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext context;

        public CategoryRepository(AppDbContext context)
        {
            this.context = context;
        }
        public bool CategoryExists(int categoryId)
        {
            return context.Set<Category>().Any(c => c.Id == categoryId);
        }

        public bool CreateCategory(Category category)
        {
            context.Add(category) ;
            return Save();
        }

        public ICollection<Category> GetCategories()
        {
            return context.Set<Category>().ToList();
        }

        public Category GetCategory(int id)
        {
            return context.Set<Category>().FirstOrDefault(c => c.Id == id);
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
           return  context.PokemonCategories.Where(pc => pc.CategoryId == categoryId).Select(pc => pc.Pokemon).ToList();
        }

        public bool Save()
        {
            var save = context.SaveChanges();
            return save > 0;
        }
    }
}
