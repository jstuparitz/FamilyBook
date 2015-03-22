using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;
using NUnit.Framework;

namespace FamilyBook.AzureStorageAdapter.IntegrationTests
{
    [SetUpFixture]
    public class TestClient
    {
        public static CloudBlobClient BlobClient;
        public static CloudQueueClient QueueClient;
        public static CloudTableClient TableClient;

        [SetUp]
        public void Setup()
        {
            CloudStorageAccount devStorageAccount = CloudStorageAccount.DevelopmentStorageAccount;
            BlobClient = devStorageAccount.CreateCloudBlobClient();
            TableClient = devStorageAccount.CreateCloudTableClient();
            QueueClient = devStorageAccount.CreateCloudQueueClient();
        }
    }
}