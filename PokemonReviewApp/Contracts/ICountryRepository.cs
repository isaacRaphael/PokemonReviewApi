﻿using PokemonReviewApp.Models;
using System.Collections.Generic;

namespace PokemonReviewApp.Contracts
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        Country GetCountryByOwner(int ownerId);
        ICollection<Owner> GetOwnersByCountry(int countryId);
        bool CountryExists(int countryId);
        bool CreateCountry(Country country);
        bool Save();
    }
}
