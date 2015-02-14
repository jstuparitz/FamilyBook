using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using FamilyBook.AzureStorageAdapter.Photo;
using FamilyBook.REST.Infrastructure;

namespace FamilyBook.REST.Controllers
{
    public class PhotoController : ApiController
    {
        private readonly PhotoLinkFactory _photoLinkFactory;
        private readonly IStateFactory<Photo, PhotoState> _stateFactory; 
        private readonly IPhotoRepository _photoRepository;

        public PhotoController(IPhotoRepository photoRepository, PhotoLinkFactory photoLinkFactory)
        {
            _photoRepository = photoRepository;
            _photoLinkFactory = photoLinkFactory;
        }

        public async Task<HttpResponseMessage> Get(string id)
        {
            var photo = await _photoRepository.FindPhoto(id);
            if (photo == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK, _stateFactory.Create(photo));
        }

        public async Task<HttpResponseMessage> Post(dynamic newPhoto)
        {
            var photo = new Photo { Id = Guid.NewGuid().ToString(), PhotoImage = newPhoto.PhotoImage };
            await _photoRepository.SavePhoto(photo);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = _photoLinkFactory.Self(photo.Id).Href;
            return response;
        }
    }
}