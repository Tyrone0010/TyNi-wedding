
using System;

namespace TyNi.Wedding.ViewModels.Request
{
    public class CalculateQuoteModel
    {
        public DateTime WeddingDate { get; set; }
        public int VenueId { get; set; }
        public int AdultNumbers { get; set; }
        public int ChildNumbers { get; set; }
        public int TeenNumbers { get; set; }
        public int EveningNumbers { get; set; }
        public int[] MenuSections { get; set; }
    }
}