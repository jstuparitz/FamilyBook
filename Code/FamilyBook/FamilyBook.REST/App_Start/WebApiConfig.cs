using System;
using System.Configuration;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using FamilyBook.AzureStorageAdapter.Photo;
using FamilyBook.REST.Controllers;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;

namespace FamilyBook.REST
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );
            ConfigureAutofac(config);
        }

        public static void ConfigureAutofac(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(typeof (PhotoRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
            builder.RegisterApiControllers(typeof (PhotoController).Assembly);

            builder.RegisterType<PhotoLinkFactory>().InstancePerLifetimeScope();

            //Create a storage account class using the credentials
            var creds = new StorageCredentials(ConfigurationManager.AppSettings["AccountName"],
                ConfigurationManager.AppSettings["StorageAccountKey"]);
            var account = new CloudStorageAccount(creds, true);

            //Create a storage account using a connection string
            CloudStorageAccount cloudStorageAccount =
                CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
            cloudStorageAccount.CreateCloudBlobClient();
            //string queueEndpointUri = "https://" + ConfigurationManager.AppSettings["AccountName"] + ".blob.core.windows.net";
            //var uri = new Uri(queueEndpointUri);

            builder.Register(c => cloudStorageAccount.CreateCloudBlobClient()).As<CloudBlobClient>().InstancePerLifetimeScope();
            builder.RegisterHttpRequestMessage(config);
            IContainer container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

    }
}