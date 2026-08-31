namespace Entities.ResquestFeatures
{
    public class BookPrametrs : RequestParametres
    {
        public uint MinPrice { get; set; } = 0;
        public uint MaxPrice { get; set; } = 1000;
        public bool ValidPriceRnage => MaxPrice > MinPrice;
        public String? SearchTerm {  get; set; }

        public BookPrametrs()
        {
            OrderBy = "id";
        }
    }
}

