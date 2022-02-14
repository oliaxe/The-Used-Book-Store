﻿namespace UsedBookStore.API.Models
{
    public class OrderCreateModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public int CustomerId { get; set; }
    }
}
