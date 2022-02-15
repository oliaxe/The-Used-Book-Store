﻿namespace UsedBookStore.Web.Models.ViewModels
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public BookModel BookForm { get; set; }
        public IEnumerable<BookModel> Books { get; set; }
        public AppUser User { get; set; }

    }
}
