using System;
using System.Collections.Generic;
using Shop.Domain.Models.Enum;

namespace Shop.Domain.Models
{
    public class User : Entity
    {
        public User()
        {
            this.Photos = new List<Image>();
            this.Birthday = DateTime.Now;
        }

        public virtual string Login { get; set; }

        public virtual string Email { get; set; }

        public virtual string Password { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual Gender Gender { get; set; }

        public virtual DateTime Birthday { get; set; }

        public virtual string City { get; set; }

        public virtual string Address { get; set; }

        public virtual Image Avatar { get; set; }

        public virtual IList<Image> Photos { get; set; }  
    }
}
