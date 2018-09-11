using System;
using System.Collections.Generic;

namespace TyNi.Wedding.ViewModels.Response
{
    public class QuoteSummaryVm
    {
        public string VenueName { get; set; }
        public decimal VenuePrice { get; set; }
        public DateTime WeddingDate { get; set; }

        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                foreach (var menuSummaryVm in Menus)
                {
                    totalPrice += menuSummaryVm.Price;
                }

                totalPrice += VenuePrice;
                return totalPrice;
            }
        }

        public List<MenuSummaryVm> Menus { get; set; }

        public QuoteSummaryVm()
        {
            Menus = new List<MenuSummaryVm>();
        }
    }
}