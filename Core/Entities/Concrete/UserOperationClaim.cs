using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class UserOperationClaim : BaseEntity, IEntity
    {
        public Guid UserId { get; set; }
        public Guid OperationClaimId { get; set; }
    }

}
