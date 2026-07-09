using bookdemo.Models;

namespace bookdemo.Data
{
    public static class ApplicationContextcs
    {
        public static List<Book> Books { get; set; }
        static ApplicationContextcs()
        {
            Books = new List<Book>()
            {
                new Book(){Id=1, Title="Simyacı",Price=210},
                new Book(){Id=2, Title="KüçükPrens",Price=150},
                new Book(){Id=3, Title="Hacivat ve Karagöz",Price=180}
            };
        }
    }
}