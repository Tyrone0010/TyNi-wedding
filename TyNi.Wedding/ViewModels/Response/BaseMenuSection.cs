using System.Collections.Generic;

namespace TyNi.Wedding.ViewModels.Response
{
    public class BaseMenuSection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ChildMenuSectionVm> ChildMenuSections { get; set; }

        public BaseMenuSection()
        {
            ChildMenuSections = new List<ChildMenuSectionVm>();
        }
    }
}