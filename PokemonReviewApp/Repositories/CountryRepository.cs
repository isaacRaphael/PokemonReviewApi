using PokemonReviewApp.Contracts;
using PokemonReviewApp.Data;
using PokemonReviewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonReviewApp.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext context;

        public CountryRepository(AppDbContext context)
        {
            this.context = context;
        }
        public bool CountryExists(int countryId)
        {
            return context.Countries.Any(c => c.Id == countryId);
        }

        public ICollection<Country> GetCountries()
        {
            return context.Countries.ToList();
        }

        public Country GetCountry(int id)
        {
            return context.Countries.FirstOrDefault(c => c.Id == id);
        }

        public Country GetCountryByOwner(int ownerId)
        {
            //return context.Owners.FirstOrDefault(o => o.Id == ownerId).Country;
            return context.Owners.Where(o => o.Id == ownerId).Select(o => o.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersByCountry(int countryId)
        {
            return context.Owners.Where(o => o.Country.Id == countryId).ToList();
        }
    }
}
