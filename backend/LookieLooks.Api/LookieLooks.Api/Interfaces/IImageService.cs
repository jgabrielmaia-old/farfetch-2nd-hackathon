using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LookieLooks.Api.Interfaces
{
    public interface IImageService
    {
        public Task<IDictionary<int, IEnumerable<string>>> GetImagesAsync(int productId);
    }
}
