using PokemonReviewApp.Models;
using System.Collections.Generic;

namespace PokemonReviewApp.Contracts
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> GetReviewers();
        Reviewer GetReviewer(int reviewerId);
        ICollection<Review> GetReviewsByReviewer(int reviewerId);
        bool ReviewerExists(int id);
    }
}
