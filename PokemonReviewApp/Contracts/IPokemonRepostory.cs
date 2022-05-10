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
}
