namespace Shop.Domain.Models
{
    public class Image : Entity
    {
        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual User User { get; set; }
    }
}