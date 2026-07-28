using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Domain.Common
{
    public abstract class AuditableEntity : AggregateRoot
    {
        protected AuditableEntity()
        {
            
        }
        public DateTime CreatedOnUtc { get; private set; }
        public DateTime? LastModifiedOnUtc { get; private set; }

        public string? CreatedBy { get; private set; }

        public string? LastModifiedBy { get; private set; }

        public byte[] RowVersion { get; private set; } = Array.Empty<byte>();

        public void SetCreatedAudit(string createdBy)
        {
            CreatedOnUtc = DateTime.UtcNow;
            CreatedBy = createdBy;
        }

        public void SetModifiedAudit(string modifiedBy)
        {
            LastModifiedOnUtc = DateTime.UtcNow;
            LastModifiedBy = modifiedBy;
        }
    }
}
