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
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepostory prepo;
        private readonly IMapper mapper;


        public PokemonController(IPokemonRepostory prepo, IMapper mapper)
        {
            this.prepo = prepo;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<ICollection<PokemonDto>> GetPokemons()
        {   var pokemons = mapper.Map<List<PokemonDto>>(prepo.GetPokemons());
            return Ok(pokemons);
        }

        [HttpGet("{id}")]
        public ActionResult<PokemonDto> GetPokemon(int id)
        {
            if (!prepo.PokemonExists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var pokemon = mapper.Map<PokemonDto>(prepo.GetPokemon(id));
            return Ok(pokemon);
        }

        [HttpGet("{id}/rating")]
        public ActionResult<int> GetPokemonRating(int id)
        {
            if (!prepo.PokemonExists(id))
                return NotFound();
             
            var rating = prepo.GetPokemonRating(id);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(rating);
        }
    }
}
