using System;

namespace TyNi.Wedding.ViewModels.Response
{
    public class PackageVm
    {
        public string Name { get; set; }
        public string RateDescription { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public string Blurb { get; set; }
        public string ImageUrl { get; set; }
        public string Day { get; set; }
    }
}