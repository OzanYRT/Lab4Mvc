using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab4Cities.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab4Cities.Data
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                GetCities()
            );
            modelBuilder.Entity<Province>().HasData(
                GetProvinces()
            );
        }

        public static List<City> GetCities()
        {
            List<City> cities = new List<City>()
            {
                new City() { CityId=1, CityName="Vancouver", Population=625218, ProvinceCode="BC" },
                new City() { CityId=2, CityName="Delta", Population=110848, ProvinceCode="BC" },
                new City() { CityId=3, CityName="Kelowna", Population=132084, ProvinceCode="BC" },
                new City() { CityId=4, CityName="Montréal", Population=3675219, ProvinceCode="QC" },
                new City() { CityId=5, CityName="Sherbrooke", Population=151157, ProvinceCode="QC" },
                new City() { CityId=6, CityName="Gatineau", Population=271569, ProvinceCode="QC" },
                new City() { CityId=7, CityName="Ottowa", Population=994837, ProvinceCode="ON" },
                new City() { CityId=8, CityName="Toronto", Population=2930023, ProvinceCode="ON" },
                new City() { CityId=9, CityName="Hamilton", Population=579200, ProvinceCode="ON" },
            };

            return cities;
        }

        public static List<Province> GetProvinces()
        {
            List<Province> provinces = new List<Province>()
            {
                new Province() { ProvinceCode="BC", ProvinceName="British Columbia" },
                new Province() { ProvinceCode="QC", ProvinceName="Quebec" },
                new Province() { ProvinceCode="ON", ProvinceName="Ontario" },
            };

            return provinces;
        }
    }
}