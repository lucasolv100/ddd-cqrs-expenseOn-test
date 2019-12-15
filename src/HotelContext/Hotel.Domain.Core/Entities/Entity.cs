using System;
using Flunt.Notifications;

namespace Hotel.Domain.Core.Entities
{
    public abstract class Entity : Notifiable
    {
        public int Id { get; protected set; }
        public DateTime CreateDate { get; protected set; }
        public DateTime? EditDate { get; protected set; }
        public DateTime? DeleteDate { get; protected set; }
    }
}