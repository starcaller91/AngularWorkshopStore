using Model.Core;

namespace Model.Domain
{
    public class Article : Entity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
    }
}
