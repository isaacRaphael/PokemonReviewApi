using PokemonReviewApp.Models;
using System.Collections.Generic;

namespace PokemonReviewApp.Contracts
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        Owner GetOwner(int ownerId);
        ICollection<Owner> GetOwnerOfAPokemon(int pokeId);
        ICollection<Pokemon> GetPokemonByOwner(int ownerId);
        bool OwnerExits(int ownerId);
    }
}
