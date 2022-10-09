
namespace Domain.Entities.Base
{
    public class BaseEntity
    {
        public virtual string Id { get; set; }
        public int State { get; set; }
        public decimal Population { get; set; }
        public decimal Household { get; set; }
    }
}
