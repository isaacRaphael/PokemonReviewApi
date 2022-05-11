using PokemonReviewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonReviewApp.Contracts
{
    public interface IPokemonRepostory
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemon(string name);
        Pokemon GetPokemon(int pokeId);
        int GetPokemonRating(int Id);
        bool PokemonExists(int pokeId);
    }
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Pokemon> GetPokemonByCategory(int categoryId);
        bool CategoryExists(int categoryId);

    }

    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        Country GetCountryByOwner(int ownerId);
        ICollection<Owner> GetOwnersByCountry(int countryId);
        bool CountryExists(int countryId);
    }
}
