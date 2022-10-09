using Domain.Entities.Base;
using Domain.Enums;


namespace Domain.Repositories.Abstractions.Base
{
    public interface IBaseRepository<T> where T : BaseResidenceEntity
    {
        //Basic Entity Operations
        Task<IEnumerable<T>> GetByStateAsync(List<int> arrStates, CommuneType communeType);
    }
}
