namespace Domain.Entities
{
    using System;

    public abstract class Entity<TKey>
    {
        public TKey Id { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
