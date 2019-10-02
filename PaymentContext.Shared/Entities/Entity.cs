using System;
using Flunt.Notifications;

namespace PaymentContext.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        protected Entity()
        {
            this.id = Guid.NewGuid();
        }

        public Guid id { get; set; }
    }
}