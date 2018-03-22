using TyNi.Wedding.AuthApi.DomainModels.Base;

namespace TyNi.Wedding.AuthApi.DomainModels.Quote
{
    public class MenuItem: BaseModel
    {
        public virtual MenuItemType MenuItemType { get; set; }

        public string Title { get; set; }
        public byte[] Thumbnail { get; set; }
    }
}