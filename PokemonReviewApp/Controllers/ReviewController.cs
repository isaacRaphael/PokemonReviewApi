using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Contracts;
using PokemonReviewApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository reviewRepository;
        private readonly IMapper mapper;

        public ReviewController(IReviewRepository reviewRepository,
                                IMapper mapper)
        {
            this.reviewRepository = reviewRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        public ActionResult<ICollection<ReviewDto>> GetReviews()
        {
            var reviews = reviewRepository.GetReviews();
            if (!reviews.Any())
                return NotFound();

            return Ok(mapper.Map<ICollection<ReviewDto>>(reviews));
        }

        [HttpGet("{id}")]
        public ActionResult<ReviewDto> GetReview(int id)
        {
            
            if (!reviewRepository.ReviewExists(id))
                return NotFound();

            return Ok(mapper.Map<ReviewDto>(reviewRepository.GetReview(id)));
        }

        [HttpGet("GetReviewsOfAPokemon/{pokeId}")]
        public ActionResult<ICollection<ReviewDto>> GetReviewsOfAPokemon(int pokeId)
        {
            var reviews = reviewRepository.GetReviewsOfAPokemon(pokeId);
            if (!reviews.Any())
                return NotFound();

            return Ok(mapper.Map<ICollection<ReviewDto>>(reviews));
        }
    }
}
