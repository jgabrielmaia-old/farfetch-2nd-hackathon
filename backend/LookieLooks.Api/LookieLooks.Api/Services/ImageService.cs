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
        //private readonly IMongoRepository<Domain.Image> _imageRepository;
        public ImageService(IMongoRepository<Domain.Game> gameRepository, IMongoRepository<Domain.Vote> voteRepository, IMongoRepository<Domain.User> userRepository)
        {
            //_imageRepository = imageRepository;
        }
        public Task<IDictionary<int, IEnumerable<string>>> GetImagesAsync(int productId)
        {
            //TODO - get Images from API where productId = productId
            //IEnumerable<string> ImageList = 
            throw new NotImplementedException();
        }
    }
}
