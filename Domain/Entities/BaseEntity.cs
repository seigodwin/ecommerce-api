using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }
        public bool IsDeleted { get; private set; } = false;
        public string DeletedBy { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }


        protected BaseEntity(Guid id)
        {
            Id = id;
        }

        //EF CORE
        protected BaseEntity() : this(Guid.NewGuid())
        {
            
        }

        public void MarkAsDeleted(string deletedBy , DateTime deletedAt)
        {
            IsDeleted = true;
            DeletedBy = deletedBy;
            DeletedAt = deletedAt;
        }

        public void setCreatedAt(DateTime createdAt)
        {
            CreatedAt = createdAt;
        }

        public void setUpdatedAt(DateTime updatedAt)
        {
            UpdatedAt = updatedAt;
        }
    }
}
