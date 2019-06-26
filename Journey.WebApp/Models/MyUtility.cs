using Journey.WebApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        public static async Task<TravelerPhoto> UploadPhoto(JourneyDBContext _context, HttpClient _httpClient, Options _options,  IFormFile upload, long albumId)
        {
            if (upload != null && upload.Length > 0)
            {
                var imagesUrl = _options.ApiUrl;

                using (var image = new StreamContent(upload.OpenReadStream()))
                {
                    image.Headers.ContentType = new MediaTypeHeaderValue(upload.ContentType);

                    var response = await _httpClient.PostAsync(imagesUrl, image);

                    if (response != null && response.IsSuccessStatusCode)
                    {
                        var travelerPhoto = new TravelerPhoto
                        {
                            FilePath = response.Headers.Location.AbsoluteUri,
                            Thumbnail = ThumbnailURI(response.Headers.Location.AbsoluteUri),
                            DateAdded = response.Headers.Date.Value.LocalDateTime,
                        };

                        _context.Add(travelerPhoto);
                        
                        var albumPhoto = new AlbumPhoto
                        {
                            AlbumId = albumId,
                            PhotoId = travelerPhoto.Id,
                            SequenceNumber = 0,
                            DateAdded = travelerPhoto.DateAdded,
                        };
                        _context.Add(albumPhoto);

                        return travelerPhoto;
                    }        
                }
            }
            throw new Exception();
        }

        private static string ThumbnailURI(string uri)
        {
            var sb = new StringBuilder(uri);
            sb.Replace("images", "images-thumbnails");
            return sb.ToString();
        }
    }
}
