using System;
using System.IO;
using FamilyBook.AzureStorageAdapter.Photo;
using NUnit.Framework;

namespace FamilyBook.AzureStorageAdapter.IntegrationTests
{
    [TestFixture]
    public class PhotoRepositoryTests : TestBase
    {
        [Test]
        public void Test()
        {
            //Arrange
            byte[] picture =
                File.ReadAllBytes(@"C:\Code\FamilyBook\FamilyBook.AzureStorageAdapter.IntegrationTests\testimage.jpg");
            IPhotoRepository photoRepository = new PhotoRepository(BlobClient);
            var photo = new Photo.Photo {Id = Guid.NewGuid(), PhotoImage = picture};

            //Act
            photoRepository.SavePhoto(photo);

            //Assert
        }
    }
}