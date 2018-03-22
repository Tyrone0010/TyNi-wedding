using TyNi.Wedding.AuthApi.DomainModels.Base;

namespace TyNi.Wedding.AuthApi.DomainModels.Quote
{
    public class MenuType: BaseModel
    {
        public new int Id { get; set; }
        public string TypeName { get; set; }
        public string Title { get; set; }
    }
}