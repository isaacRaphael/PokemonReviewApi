using PokemonReviewApp.Contracts;
using PokemonReviewApp.Data;
using PokemonReviewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonReviewApp.Repositories
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly AppDbContext context;

        public ReviewerRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Reviewer GetReviewer(int reviewerId)
        {
            return context.Reviewers.FirstOrDefault(r => r.Id == reviewerId);
        }

        public ICollection<Reviewer> GetReviewers()
        {
            return context.Reviewers.ToList();
        }

        public ICollection<Review> GetReviewsByReviewer(int reviewerId)
        {
            return context.Reviews.Where(r => r.Reviewer.Id == reviewerId).ToList();
        }

        public bool ReviewerExists(int id)
        {
            return context.Reviewers.Any(r => r.Id == id);
        }
    }
}
