using System.Collections.Generic;

namespace TyNi.Wedding.ViewModels.Response
{
    public class MenuVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MenuType { get; set; }
        public bool IsRequired { get; set; }
        public List<TopMenuSectionVm> TopMenuSections { get; set; }

        public MenuVm()
        {
            TopMenuSections = new List<TopMenuSectionVm>();
        }
    }
}