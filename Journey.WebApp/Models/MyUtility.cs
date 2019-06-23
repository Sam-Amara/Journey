using Journey.WebApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Journey.WebApp.Models
{
    public class MyUtility
    {
        public static async Task<int> CityFindOrAdd(JourneyDBContext _context, City cityToFind)
        {
            var name = cityToFind.CityName.Trim();
            var state = cityToFind.CityState?.Trim() ?? "";
            var country = cityToFind.Country.Trim();

            var city = await _context.City.FirstOrDefaultAsync(c => c.CityName.Equals(name, StringComparison.OrdinalIgnoreCase)
                                                               && ((string.IsNullOrEmpty(c.CityState) && string.IsNullOrEmpty(state))
                                                               || c.CityState.Equals(state, StringComparison.OrdinalIgnoreCase))
                                                               && c.Country.Equals(country, StringComparison.OrdinalIgnoreCase));

            if (city == null)
            {
                city = new City()
                {
                    CityName = name,
                    CityState = state,
                    Country = country
                };

                _context.Add(city);
                await _context.SaveChangesAsync();
            }

            return city.Id;
        }
    }
}
