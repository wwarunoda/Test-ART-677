using Domain.Entities.Base;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntityFilters.Base 
{
    public abstract  class BaseEntityFilter<T> where T : BaseResidenceEntity
    {
        public string CreatedBy { get; set; }
        public DateTime? CreatedAtFrom { get; set; }
        public DateTime? CreatedAtTo { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAtFrom { get; set; }
        public DateTime? UpdatedAtTo { get; set; }
        public bool? Deleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAtFrom { get; set; }
        public DateTime? DeletedAtTo { get; set; }

        public  virtual Expression<Func<T, bool>> Filter()
        {

            var predicate = PredicateBuilder.New<T>(true);


            //createdBy id ==
            //createdAt, updatedAt,deletedAt, calledAt =  time between
            //type, status ==            

            return predicate;
        }
    }
}
