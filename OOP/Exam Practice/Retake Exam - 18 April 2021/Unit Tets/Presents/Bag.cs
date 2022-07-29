namespace Presents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Bag
    {
        private List<Present> presents;

        public Bag()
        {
            this.presents = new List<Present>();
        }

        public string Create(Present present)
        {
            if (present == null)
            {
                throw new ArgumentNullException("Present is null");
            }
            else if (this.presents.Any(p => p == present))
            {
                throw new InvalidOperationException("This present already exists!");
            }

            this.presents.Add(present);

            return $"Successfully added present {present.Name}.";
        }

        public bool Remove(Present present)
        {
            return this.presents.Remove(present);
        }

        public Present GetPresentWithLeastMagic()
        {
            Present present = this.presents.OrderBy(p => p.Magic).First();

            return present;
        }

        public Present GetPresent(string name)
        {
            Present present = this.presents.FirstOrDefault(p => p.Name == name);

            return present;
        }

        public IReadOnlyCollection<Present> GetPresents()
        {
            return this.presents.AsReadOnly();
        }
    }
}
