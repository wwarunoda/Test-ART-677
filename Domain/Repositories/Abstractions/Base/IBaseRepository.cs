using Domain.Entities.Base;
using Domain.EntityFilters.Base;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Abstractions.Base
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        //Basic Entity Operations
        Task<IEnumerable<Actual>> GetByStateAsync(List<int> arrStates, CommuneType communeType);
    }
}
