using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Contracts;
using PokemonReviewApp.Data;
using PokemonReviewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonReviewApp.Repositories
{

    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext context;

        public ReviewRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Review GetReview(int reviewId)
        {
            return context.Reviews.FirstOrDefault(r => r.Id == reviewId);
        }

        public ICollection<Review> GetReviews()
        {
            return context.Reviews.ToList();
        }

        public ICollection<Review> GetReviewsOfAPokemon(int pokeId)
        {
            return context.Pokemons.Where(p => p.Id == pokeId).Include(x => x.Reviews).FirstOrDefault().Reviews;
            //return context.Reviews.Where(r => r.Pokemon.Id == pokeId).ToList();
        }

        public bool ReviewExists(int reviewId)
        {
            return context.Reviews.Any(r => r.Id == reviewId);
        }
    }
}
