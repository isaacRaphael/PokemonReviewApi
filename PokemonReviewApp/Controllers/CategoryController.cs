﻿using AutoMapper;
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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<ICollection<CategoryDto>> GetCategory()
        {
            return Ok(mapper.Map<ICollection<CategoryDto>>(categoryRepository.GetCategories()));
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryDto> GetCategoryById(int id)
        {
            var category = categoryRepository.GetCategory(id);
            if (category is null)
                return NotFound();

            return Ok(mapper.Map<CategoryDto>(category));
        }

        [HttpGet("Pokemons/{categoryId}")]
        public ActionResult<ICollection<PokemonDto>> GetPokemonByCategory(int categoryId)
        {
            if (!categoryRepository.CategoryExists(categoryId))
                return NotFound();
            var pokemons = categoryRepository.GetPokemonByCategory(categoryId);
            return pokemons is null ? NotFound() : Ok(mapper.Map<ICollection<PokemonDto>>(pokemons));
        }


    }
}
