using System;

namespace FamilyBook.AzureStorageAdapter.Photo
{
    public class Photo
    {
        public Guid Id { get; set; }

        public byte[] PhotoImage { get; set; }
    }
}