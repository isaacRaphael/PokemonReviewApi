using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Contracts;
using PokemonReviewApp.DTOs;
using PokemonReviewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewerController : ControllerBase
    {
        private readonly IReviewerRepository reviewerRepository;
        private readonly IMapper mapper;

        public ReviewerController(IReviewerRepository reviewerRepository, IMapper mapper)
        {
            this.reviewerRepository = reviewerRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<ICollection<ReviewerDto>> GetReviewers()
        {
            var reviwers = reviewerRepository.GetReviewers();
            if (!reviwers.Any())
                return NotFound();
            return Ok(mapper.Map<ICollection<ReviewerDto>>(reviwers));
        }

        [HttpGet("{id}")]
        public ActionResult<ReviewerDto> GetReviewer(int id)
        {
            if (!reviewerRepository.ReviewerExists(id))
                return NotFound();

            return Ok(mapper.Map<ReviewerDto>(reviewerRepository.GetReviewer(id)));
        }


        [HttpGet("GetReviewsByReviewer/{reviewerId}")]
        public ActionResult<ICollection<ReviewDto>> GetReviewsByReviewer(int reviewerId)
        {
            var reviews = reviewerRepository.GetReviewsByReviewer(reviewerId);
            if (!reviews.Any())
                return NotFound();

            return Ok(mapper.Map<ICollection<ReviewDto>>(reviews));
        }
    }
}
