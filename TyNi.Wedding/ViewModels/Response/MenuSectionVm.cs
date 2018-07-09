using System.Collections.Generic;

namespace TyNi.Wedding.ViewModels.Response
{
    public class MenuSectionVm
    {
        public int id { get; set; }
        public decimal price { get; set; }
        public string name { get; set; }
        public int? parentId { get; set; }
        public int? menuId { get; set; }
    }
}