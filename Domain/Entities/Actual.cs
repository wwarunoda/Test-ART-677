using Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Actual : BaseResidenceEntity
    {
        [Key]
        public override string Id { get; set; } = Guid.NewGuid().ToString();
    }
}