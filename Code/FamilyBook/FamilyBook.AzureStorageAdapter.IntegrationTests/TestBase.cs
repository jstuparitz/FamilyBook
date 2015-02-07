using System;
using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;
using NUnit.Framework;

namespace FamilyBook.AzureStorageAdapter.IntegrationTests
{
    [SetUpFixture]
    public class TestBase
    {
        protected static CloudBlobClient BlobClient;
        protected static CloudQueueClient QueueClient;
        protected static CloudTableClient TableClient;

        [SetUp]
        public void Setup()
        {
            //Create a storage account class using the credentials
            var creds = new StorageCredentials(ConfigurationManager.AppSettings["AccountName"], ConfigurationManager.AppSettings["StorageAccountKey"]);
            var account = new CloudStorageAccount(creds, false);

            //Create a storage account using a connection string
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);

            CloudStorageAccount devStorageAccount = CloudStorageAccount.DevelopmentStorageAccount;
            BlobClient = devStorageAccount.CreateCloudBlobClient();
            TableClient = devStorageAccount.CreateCloudTableClient();
            QueueClient = devStorageAccount.CreateCloudQueueClient();

            string storageAccountName = "familybooktest";
            //string queueEndpointUri = "http://" + storageAccountName + ".queue.core.windows.net";
            //var uri = new Uri(queueEndpointUri);
            //QueueClient = new CloudQueueClient(uri, creds);
        }
    }
}