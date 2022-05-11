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
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository countryRepository;
        private readonly IMapper mapper;

        public CountryController(ICountryRepository countryRepository, IMapper mapper)
        {
            this.countryRepository = countryRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<ICollection<CountryDto>> GetCountries()
        {
            return Ok(mapper.Map<ICollection<CountryDto>>(countryRepository.GetCountries()));
        }

        [HttpGet("{id}")]
        public ActionResult<CountryDto> GetCountry(int id)
        {
            if (!countryRepository.CountryExists(id))
                return NotFound();

            return Ok(mapper.Map<CountryDto>(countryRepository.GetCountry(id)));
        }

        [HttpGet("/CountryByOwner/{ownerId}")]
        public ActionResult<CountryDto> GetCountryByOwner(int ownerId)
        {
            var country = countryRepository.GetCountryByOwner(ownerId);
            if (country is null)
                return NotFound();

            return Ok(mapper.Map<CountryDto>(country));
        }


        [HttpGet("/OwnerByCountry/{countryId}")]
        public ActionResult<OwnerDto> GetOwnersByCountry(int countryId)
        {
            var owners = countryRepository.GetOwnersByCountry(countryId);
            if (owners is null || !owners.Any())
                return NotFound();

            return Ok(mapper.Map<ICollection<OwnerDto>>(owners));
        }
    }
}
