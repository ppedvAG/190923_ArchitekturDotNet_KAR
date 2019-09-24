using System.Collections.Generic;

namespace ppedv.UniversalBookManager.Domain
{
    public class Store : Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual HashSet<Inventory> Inventory { get; set; } = new HashSet<Inventory>();
    }

}
