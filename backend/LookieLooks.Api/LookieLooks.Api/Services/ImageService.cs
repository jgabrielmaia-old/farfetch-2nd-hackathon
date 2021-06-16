using LookieLooks.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LookieLooks.Api.Services
{
    public class ImageService : IImageService
    {
        public Task<IDictionary<int, IEnumerable<string>>> GetImagesAsync(int productId)
        {
            //TODO - get Images from API where productId = productId
            throw new NotImplementedException();
        }
    }
}
