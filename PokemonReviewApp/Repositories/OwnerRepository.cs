using PokemonReviewApp.Contracts;
using PokemonReviewApp.Data;
using PokemonReviewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonReviewApp.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly AppDbContext context;

        public OwnerRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Owner GetOwner(int ownerId)
        {
            return context.Owners.Find(ownerId);
        }

        public ICollection<Owner> GetOwnerOfAPokemon(int pokeId)
        {
            return context.PokemonOwners.Where(po => po.PokemonId == pokeId).Select(x => x.Owner).ToList();
        }

        public ICollection<Owner> GetOwners()
        {
            return context.Owners.ToList();
        }

        public ICollection<Pokemon> GetPokemonByOwner(int ownerId)
        {
            return context.PokemonOwners.Where(po => po.OwnerId == ownerId).Select(x => x.Pokemon).ToList();
        }

        public bool OwnerExits(int ownerId)
        {
            return context.Owners.Any(o => o.Id == ownerId);
        }
    }
}
