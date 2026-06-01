namespace Entities.ResquestFeatures
{
    public class BookPrametrs : RequestParametres
    {
        public uint MinPrice { get; set; }
        public uint MaxPrice { get; set; }
        public bool ValidPriceRnage => MaxPrice > MinPrice;
        public String? SearchTerm {  get; set; }
    }
}

