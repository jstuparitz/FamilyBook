using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Blob;

namespace FamilyBook.AzureStorageAdapter.Photo
{
    public interface IPhotoRepository
    {
        //void SavePhoto(Photo photo);
        Task SavePhoto(Photo photo);
    }

    public class PhotoRepository : IPhotoRepository
    {
        private readonly CloudBlobClient _client;

        public PhotoRepository(CloudBlobClient client)
        {
            _client = client;
        }

        //public void SavePhoto(Photo photo)
        //{
        //    CloudBlobContainer blobContainer = _client.GetContainerReference("1photos");
        //    CloudBlockBlob blob = blobContainer.GetBlockBlobReference(photo.Id.ToString());
        //    blob.UploadFromByteArray(photo.PhotoImage, 0, photo.PhotoImage.Length);
        //    var uri = blob.Uri.ToString();
        //}

        public async Task SavePhoto(Photo photo)
        {
            CloudBlobContainer blobContainer = _client.GetContainerReference("1photos");
            CloudBlockBlob blob = blobContainer.GetBlockBlobReference(photo.Id);
            await blob.UploadFromByteArrayAsync(photo.PhotoImage, 0, photo.PhotoImage.Length);
        }
    }
}