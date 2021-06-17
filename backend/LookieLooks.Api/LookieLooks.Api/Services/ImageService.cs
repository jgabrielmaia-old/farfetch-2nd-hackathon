using LookieLooks.Api.Interfaces;
using LookieLooks.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LookieLooks.Api.Services
{
    public class ImageService : IImageService
    {
        private readonly IMongoRepository<Domain.Product> _productRepository;
        public ImageService(IMongoRepository<Domain.Game> gameRepository,  IMongoRepository<Domain.Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public Dictionary<int, IEnumerable<string>> GetImagesAsync(int productId)
        {
            IEnumerable<string> ImageList = _productRepository.FindById(productId.ToString()).ImagesLink;
            Dictionary<int, IEnumerable<string>> productImages = new Dictionary<int, IEnumerable<string>>
            {
                { productId, ImageList }
            };
            return productImages;
        }
    }
}
