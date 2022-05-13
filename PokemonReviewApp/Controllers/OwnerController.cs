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
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerRepository ownerRepository;
        private readonly IMapper mapper;

        public OwnerController(IOwnerRepository ownerRepository, IMapper mapper)
        {
            this.ownerRepository = ownerRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<ICollection<OwnerDto>> GetOwners()
        {
            var owners = ownerRepository.GetOwners();
            if (owners == null || owners.Count() == 0)
                return NotFound();

            return Ok(mapper.Map<ICollection<OwnerDto>>(owners));
        }

        [HttpGet("{id}")]
        public ActionResult<OwnerDto> GetOwner(int id)
        {
            var owner = ownerRepository.GetOwner(id);
            if (owner == null)
                return NotFound();
            return Ok(mapper.Map<OwnerDto>(owner));
        }
        [HttpGet("PokemonsByOwner/{ownerId}")]
        public ActionResult<ICollection<PokemonDto>> GetPokemonByOwner(int ownerId)
        {
            var pokemon = ownerRepository.GetPokemonByOwner(ownerId);
            if (!pokemon.Any())
                return NotFound();
            return Ok(mapper.Map<ICollection<PokemonDto>>(pokemon));
        }

        [HttpGet("OwnerOfPokemon/{pokeId}")]
        public ActionResult<ICollection<OwnerDto>> GetOwnerOfAPokemon(int pokeId)
        {
            var owners = ownerRepository.GetOwnerOfAPokemon(pokeId);
            if (!owners.Any())
                return NotFound();
            return Ok(mapper.Map<ICollection<OwnerDto>>(owners));
        }
    }
}
