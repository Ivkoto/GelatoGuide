﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GelatoGuide.Data;
using GelatoGuide.Data.Models;
using GelatoGuide.Services.Places.Models;

namespace GelatoGuide.Services.Places;

public class PlaceService : IPlaceService
{
    private readonly GelatoGuideDbContext data;
    private readonly IMapper mapper;

    public PlaceService(GelatoGuideDbContext data, IMapper mapper)
    {
        this.data = data;
        this.mapper = mapper;
    }

    public IEnumerable<PlaceServiceModel> AllPlaces()
        =>
            this.data.Places
                .Select(place => new PlaceServiceModel()
                {
                    Id = place.Id,
                    Name = place.Name,
                    WebsiteLink = place.WebsiteLink,
                    SinceYear = place.SinceYear,
                    Country = place.Country,
                    City = place.City,
                    Address = place.Address,
                    DateCreated = place.DateCreated
                })
                .ToList();

    public PlaceServiceModel PlaceById(string id)
    {
        var isIdExist = this.data.Places.Any(p => p.Id == id);

        if (!isIdExist)
        {
            return null;
        }

        var curPlace = this.data.Places.First(p => p.Id == id);
        var placeDetails = this.mapper.Map<PlaceServiceModel>(curPlace);

        return placeDetails;
    }

    public bool IsPlaceExist(string id)
        => this.data.Places.Any(p => p.Id == id);

    public void CreatePlace(PlaceServiceModel place)
    {
        var curPlace = this.mapper.Map<Place>(place);

        curPlace.Id = Guid.NewGuid().ToString();
        curPlace.DateCreated = DateTime.Now;

        this.data.Add(curPlace);
        this.data.SaveChanges();
    }

    public void UpdatePlace(PlaceServiceModel model)
    {
        var place = this.data.Places.FirstOrDefault(p => p.Id == model.Id);

        if (place == null) return;

        place.Name = model.Name;
        place.Description = model.Description;
        place.MainImageUrl = model.MainImageUrl;
        place.SinceYear = model.SinceYear;
        place.LogoUrl = model.LogoUrl;
        place.WebsiteLink = model.WebsiteLink;
        place.Country = model.Country;
        place.City = model.City;
        place.Location = model.Location;
        place.Address = model.Address;
        place.TakeawayUrl = model.TakeawayUrl;
        place.FoodpandaUrl = model.FoodpandaUrl;
        place.GlovoUrl = model.GlovoUrl;
        place.FacebookUrl = model.FacebookUrl;
        place.InstagramUrl = model.InstagramUrl;
        place.TwitterUrl = model.TwitterUrl;
        place.Images = model.Images;

        this.data.SaveChanges();
    }

    public void DeletePlace(string id)
    {
        var curPlace = this.data.Places.First(p => p.Id == id);

        if (curPlace != null)
        {
            this.data.Places.Remove(curPlace);
            this.data.SaveChanges();
        }
    }

    public AllPlacesServiceModel AllPlaces(
        string searchTerm, string country, string city,
        int currentPage, int placesPerPage)
    {
        var placesQuery = this.data.Places.AsQueryable();

        //if no places in the database
        if (!placesQuery.Any())
        {
            return null;
        }

        //filter query if any search text have been imputed
        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            placesQuery = placesQuery.Where(p =>
                p.Name.ToLower().Contains(searchTerm.ToLower()) ||
                p.Description.ToLower().Contains(searchTerm.ToLower()) ||
                p.SinceYear.ToString().Contains(searchTerm.ToLower()) ||
                p.City.ToLower().Contains(searchTerm.ToLower()) ||
                p.Country.ToLower().Contains(searchTerm.ToLower()));
        }

        //filter query if country have been selected
        if (!string.IsNullOrWhiteSpace(country))
        {
            placesQuery = placesQuery.Where(p =>
                p.Country == country);
        }

        //filter query if city have been selected
        if (!string.IsNullOrWhiteSpace(city))
        {
            placesQuery = placesQuery.Where(p =>
                p.City.ToLower() == city.ToLower());
        }

        //restrict receiving query with page value lower than 1
        if (currentPage < 1)
        {
            currentPage = 1;
        }

        //restrict viewing empty pages and non existing pages
        var totalPlaces = placesQuery.Count();
        var maxPagesCount = (int)Math.Ceiling((double)totalPlaces / placesPerPage);
        if (currentPage > maxPagesCount)
        {
            currentPage = maxPagesCount;
        }

        List<PlaceServiceModel> places;

        //if no results after search
        if (!placesQuery.Any())
        {
            places = new List<PlaceServiceModel>();
        }
        else
        {
            places = placesQuery
                .OrderByDescending(p => p.DateCreated)
                .Skip((currentPage - 1) * placesPerPage)
                .Take(placesPerPage)
                .Select(p => new PlaceServiceModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    MainImageUrl = p.MainImageUrl,
                    WebsiteLink = p.WebsiteLink,
                    SinceYear = p.SinceYear,
                    LogoUrl = p.LogoUrl,
                    Images = p.Images
                        .Select(img => new Image()
                        {
                            Url = img.Url,
                            PlaceId = img.PlaceId
                        }).ToList(),
                    FacebookUrl = p.FacebookUrl,
                    InstagramUrl = p.InstagramUrl,
                    TwitterUrl = p.TwitterUrl,
                    GlovoUrl = p.GlovoUrl,
                    FoodpandaUrl = p.FoodpandaUrl,
                    TakeawayUrl = p.TakeawayUrl,
                    Country = p.Country,
                    City = p.City,
                    Address = p.Address,
                    Location = p.Location,
                    DateCreated = p.DateCreated
                })
                .ToList();
        }

        var result = new AllPlacesServiceModel()
        {
            Places = places,
            Cities = this.AllCities(),
            Countries = this.AllCountries(),
            TotalPlaces = totalPlaces,
            SearchTerm = searchTerm,
            Country = country,
            City = city,
            CurrentPage = currentPage
        };

        return result;
    }

    public int TotalPlacesCount()
        => this.data.Places.Count();

    public IEnumerable<string> AllCities()
        => this.data.Places
            .Select(p => p.City)
            .Distinct()
            .OrderBy(c => c)
            .ToList();

    public IEnumerable<string> AllCountries()
        => this.data.Places
            .Select(p => p.Country)
            .Distinct()
            .OrderBy(c => c)
            .ToList();

    public bool IsPlaceNameExist(string name)
        => this.data.Places
            .Any(p => p.Name == name);
}