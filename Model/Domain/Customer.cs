using Model.Core;

namespace Model.Domain
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public double Discount { get; set; }
        public double MininalAmmountForDiscount { get; set; }
    }
}
