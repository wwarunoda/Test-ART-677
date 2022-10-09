using Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Estimate : BaseResidenceEntity
    {
        [Key]
        public override string Id { get; set; } = Guid.NewGuid().ToString();
        public string? District { get; set; }

    }
}