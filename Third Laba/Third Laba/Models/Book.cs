﻿namespace Third_Laba.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Descryption { get; set; }
        public int? AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
