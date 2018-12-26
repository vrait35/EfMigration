using System.Collections.Generic;

namespace Migration
{
    public class Cart : Entity
    {
        public virtual User User { get; set; }
        public string Login { get; set; }
        public virtual ICollection<Item> Items { get; set; } = new List<Item>();
    }
}