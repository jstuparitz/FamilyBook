using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using FamilyBook.AzureStorageAdapter.Photo;

namespace FamilyBook.RESTAdapter.Controllers
{
    public class PhotoController : ApiController
    {
        private readonly IPhotoRepository _photoRepository;

        public PhotoController(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        public async Task<HttpResponseMessage> Get(string id)
        {
        }

        public async Task<HttpResponseMessage> Post(dynamic newPhoto)
        {
            var photo = new Photo() {Id = Guid.NewGuid(), PhotoImage = newPhoto.photo};
            await _photoRepository.SavePhoto(photo)
        }
    }
}