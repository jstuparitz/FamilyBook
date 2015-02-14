using System.Net.Http;
using FamilyBook.REST.Infrastructure;

namespace FamilyBook.REST.Controllers
{
    public class PhotoLinkFactory : LinkFactory<PhotoController>
    {
        public PhotoLinkFactory(HttpRequestMessage request) : base(request)
        {
        }
    }
}