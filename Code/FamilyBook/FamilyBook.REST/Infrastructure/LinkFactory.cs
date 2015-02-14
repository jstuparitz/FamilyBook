﻿using System;
using System.Net.Http;
using System.Web.Http.Routing;
using FamilyBook.REST.Models;

namespace FamilyBook.REST.Infrastructure
{
    public abstract class LinkFactory
    {
        private const string DefaultApi = "DefaultApi";
        private readonly string _controllerName;
        private readonly UrlHelper _urlHelper;

        protected LinkFactory(HttpRequestMessage request, Type controllerType)
        {
            _urlHelper = new UrlHelper(request);
            _controllerName = GetControllerName(controllerType);
        }

        private string GetControllerName(Type controllerType)
        {
            string name = controllerType.Name;
            return name.Substring(0, name.Length - "controller".Length).ToLower();
        }

        protected Link GetLink<TController>(string rel, object id, string action, string route = DefaultApi)
        {
            Uri uri = GetUri(new {controller = GetControllerName(typeof (TController)), id, action}, route);
            return new Link {Action = action, Href = uri, Rel = rel};
        }

        protected Uri GetUri(object routeValues, string route = DefaultApi)
        {
            return new Uri(_urlHelper.Link(route, routeValues));
        }


        public Link Self(string id, string route = DefaultApi)
        {
            return new Link {Rel = Rels.Self, Href = GetUri(new {controller = _controllerName, id}, route)};
        }

        public class Rels
        {
            public const string Self = "self";
        }
    }

    public abstract class LinkFactory<TController> : LinkFactory
    {
        public LinkFactory(HttpRequestMessage request) : base(request, typeof (TController))
        {
        }
    }
}