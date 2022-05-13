using PokemonReviewApp.Models;
using System.Collections.Generic;

namespace PokemonReviewApp.Contracts
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Pokemon> GetPokemonByCategory(int categoryId);
        bool CategoryExists(int categoryId);
        bool CreateCategory(Category category);
        bool Save();

    }
}
