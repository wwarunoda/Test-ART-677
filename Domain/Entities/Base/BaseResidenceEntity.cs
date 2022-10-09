
namespace Domain.Entities.Base
{
    public class BaseResidenceEntity
    {
        private decimal _population;
        private decimal _household;
        public virtual string Id { get; set; }
        public int State { get; set; }
        public decimal Population { get { return Math.Round(_population, 2); } set { _population = value; } }
        public decimal Household { get { return Math.Round(_household, 2); } set { _household = value; } }
    }
}
