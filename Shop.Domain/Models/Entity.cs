﻿namespace Shop.Domain.Models
{
    public abstract class Entity
    {
        public virtual int Id { get; protected set; }
    }
}
