using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FamilyBook.AzureStorageAdapter.Photo;
using FamilyBook.REST.Infrastructure;

namespace FamilyBook.REST.Controllers
{
    public class PhotoStateFactory : IStateFactory<Photo, PhotoState>
    {
        private readonly PhotoLinkFactory _links;

        public PhotoStateFactory(PhotoLinkFactory links)
        {
            _links = links;
        }

        public PhotoState Create(Photo photo)
        {
            var model = new PhotoState
            {
                Id = photo.Id,
                PhotoImage = photo.PhotoImage
            };

            //add hypermedia
            model.Links.Add(_links.Self(photo.Id));
            return model;
        }
    }
}