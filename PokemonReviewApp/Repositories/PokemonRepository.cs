using PokemonReviewApp.Contracts;
using PokemonReviewApp.Data;
using PokemonReviewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonReviewApp.Repositories
{
    public class PokemonRepository : IPokemonRepostory
    {
        private readonly AppDbContext context;

        public PokemonRepository(AppDbContext context)
        {
            this.context = context;
        }

        public bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            
            var OwnerEntity = context.Owners.Where(a => a.Id == ownerId).FirstOrDefault();
            var CategoryEntity = context.Set<Category>().Where(a => a.Id == categoryId).FirstOrDefault();

            var pokemonOwner = new PokemonOwner()
            {
                Owner = OwnerEntity,
                Pokemon = pokemon
            };
            context.Add(pokemonOwner);

            var pokemonCategory = new PokemonCategory
            {
                Category = CategoryEntity,
                Pokemon = pokemon
            };
            context.Add(pokemonCategory);
            context.Add(pokemon);
            
            return Save();
         
        }

        public Pokemon GetPokemon(string name)
        {
            return context.Pokemons.Where(p => p.Name.ToLower() == name.ToLower()).FirstOrDefault();
        }

        public Pokemon GetPokemon(int pokeId)
        {
            return context.Pokemons.Where(p => p.Id == pokeId).FirstOrDefault();
        }

        public int GetPokemonRating(int Id)
        {
            var review = context.Reviews.Where(r => r.Pokemon.Id == Id);

            if (!review.Any())
                return 0;

            var rating = (review.Sum(r => r.Rating) / review.Count());
            return rating;
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return context.Pokemons.ToList();
        }

        public bool PokemonExists(int pokeId)
        {
            return context.Pokemons.Any(p => p.Id == pokeId);
        }

        public bool Save()
        {
            var save = context.SaveChanges();
            return save > 0;
        }
    }
}
