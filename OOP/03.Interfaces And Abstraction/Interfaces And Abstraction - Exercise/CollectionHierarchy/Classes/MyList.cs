using CollectionHierarchy.Interfaces;

namespace CollectionHierarchy.Classes
{
    public class MyList : AddAndRemoveCollection, IAddAndRemove
    {
        public MyList()
        {
        }

        public int Used => List.Count;

        public override string Remove()
        {
            string firstItem = List[0];
            List.RemoveAt(0);
            return firstItem;
        }
    }
}
