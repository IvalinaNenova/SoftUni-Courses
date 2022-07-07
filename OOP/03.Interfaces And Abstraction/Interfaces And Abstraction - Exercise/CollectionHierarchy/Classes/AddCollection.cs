using CollectionHierarchy.Interfaces;
using System.Collections.Generic;

namespace CollectionHierarchy.Classes
{
    public class AddCollection : IAddCollection
    {
        private List<string> list;

        public AddCollection()
        {
            list = new List<string>(100);
        }

        public List<string> List
        {
            get => list;
            set => list = value;
        }

        public virtual int Add(string item)
        {
            list.Add(item);
            return list.Count - 1;
        }
    }
}
