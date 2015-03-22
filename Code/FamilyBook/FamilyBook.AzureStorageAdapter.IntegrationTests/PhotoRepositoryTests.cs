using System;
using System.IO;
using System.Threading.Tasks;
using FamilyBook.AzureStorageAdapter.Photo;
using NUnit.Framework;

namespace FamilyBook.AzureStorageAdapter.IntegrationTests
{
    [TestFixture]
    public class PhotoRepositoryTests
    {
        [Test]
        public async Task Test()
        {
            //Arrange
            byte[] picture =
                File.ReadAllBytes(@"C:\Code\FamilyBook\FamilyBook.AzureStorageAdapter.IntegrationTests\testimage.jpg");
            IPhotoRepository photoRepository = new PhotoRepository(TestClient.BlobClient);
            var id = Guid.NewGuid().ToString();
            var photo = new Photo.Photo {Id = id, PhotoImage = picture};

            //Act
            await photoRepository.SavePhoto(photo);

            //Assert
            var getPhoto = photoRepository.FindPhoto(id);
            Assert.IsNotEmpty(getPhoto.Result.PhotoImage);
        }
    }
}