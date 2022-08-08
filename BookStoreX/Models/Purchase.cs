using System;

namespace BookStoreX.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public string PersonName { get; set; }
        public string PersonAddress { get; set; }
        public int BookId { get; set; }

        public DateTime PurchaseDate { get; set; }

    }
}
