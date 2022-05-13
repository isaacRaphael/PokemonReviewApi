using PokemonReviewApp.Models;
using System.Collections.Generic;

namespace PokemonReviewApp.Contracts
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReview(int reviewId);
        ICollection<Review> GetReviewsOfAPokemon(int pokeId);
        bool ReviewExists(int reviewId);
    }
}
