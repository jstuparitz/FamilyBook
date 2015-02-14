using System;
using System.Collections.Generic;


namespace FamilyBook.REST.Controllers
{
    public class PhotoState
    {
        public PhotoState()
        {
            Links = new List<Models.Link>();
        }

        public string Id { get; set; }
        public byte[] PhotoImage { get; set; }
        public IList<Models.Link> Links { get; private set; } 
    }
}