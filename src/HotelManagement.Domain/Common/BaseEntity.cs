using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Domain.Common
{
    /// <summary>
    /// Base class for all domain entities.
    /// </summary>
    public abstract class BaseEntity : IEquatable<BaseEntity>
    {
        protected BaseEntity()
        {
            
        }
        public Guid Id { get; protected set; }

        public bool Equals(BaseEntity? other)
        {
            if (other is null)
                return false;


            if(ReferenceEquals(this, other)) 
                return true;

            if(GetType()  != other.GetType()) 
                return false;

            return Id == other.Id;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as BaseEntity);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GetType(), Id);
        }

        public static bool operator ==(BaseEntity? left, BaseEntity? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BaseEntity? left, BaseEntity? right)
        {
            return !Equals(left, right);
        }
    }
}
