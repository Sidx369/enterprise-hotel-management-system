using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Domain.Common
{
    public abstract class AuditableEntity : AggregateRoot
    {
        public DateTime CreatedOnUtc { get; protected set; } = DateTime.UtcNow;
        public DateTime? UpdatedOnUtc { get; protected set; }

        public string? CreatedBy { get; protected set; }

        public string? UpdatedBy { get; protected set; }

        public byte[] RowVersion { get; protected set; } = Array.Empty<byte>();

        public void MarkUpdated(string user)
        {
            UpdatedOnUtc = DateTime.UtcNow;
            UpdatedBy = user;
        }
    }
}
