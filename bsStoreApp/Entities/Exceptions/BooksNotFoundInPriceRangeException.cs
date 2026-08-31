namespace Entities.Exceptions
{
    public class BooksNotFoundInPriceRangeException : NotFoundException
    {
        public BooksNotFoundInPriceRangeException()
            : base("No books were found in the range you entered.")
        {
        }
    }
}
