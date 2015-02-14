using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.Net.Http;

namespace FamilyBook.REST.Infrastructure
{
    public static class UriExtensions
    {
        public static dynamic GetQueryStringObject(this Uri uri)
        {
            NameValueCollection qsValues = uri.ParseQueryString();
            IDictionary<string, object> obj = new ExpandoObject();
            foreach (string key in qsValues.Keys)
            {
                string val = qsValues[key];
                if (val.IndexOf(",") > -1)
                {
                    string[] values = val.Split(',');
                    obj[key] = values;
                }
                else
                    obj[key] = val;
            }
            return obj;
        }
    }
}