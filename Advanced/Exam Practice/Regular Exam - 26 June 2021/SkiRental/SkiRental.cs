using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;
        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Ski>();
        }

        public void Add(Ski ski)
        {
            if (data.Count < Capacity)
            {
                data.Add(ski);
            }
        }/*– adds an entity to the data if there is an empty slot for the Ski.*/

        public bool Remove(string manufacturer, string model)
        {
            return data.Remove(data.Find(ski => ski.Manufacturer == manufacturer && ski.Model == model));
        }/* – removes the Ski by given manufacturer and model, if such exists, and returns bool.*/

        public Ski GetNewestSki()
        {
            if (data.Count == 0)
            {
                return null;
            }

            int latestYear = 0;
            foreach (var ski in data)
            {
                if (ski.Year > latestYear)
                {
                    latestYear = ski.Year;
                }
            }

            Ski newest = data.Find(ski => ski.Year == latestYear);
            return newest;
        }/*– returns the newest Ski(by year) or null if there are no Skis stored.*/

        public Ski GetSki(string manufacturer, string model)
        {
           Ski searched = data.Find(ski => ski.Manufacturer == manufacturer && ski.Model == model);
           if (searched == null)
           {
               return null;
           }
           return searched;
        }/* – returns the Ski with the given manufacturer and model or null if there is no such Ski.*/

        public string GetStatistics()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"The skis stored in {Name}:");

            for (int i = 0; i < data.Count - 1; i++)
            {
                output.AppendLine(data[i].ToString());
            }

            output.Append(data[Count - 1].ToString());
            return output.ToString();
        }/*– returns a string in the following format:*/
        //o	"The skis stored in {Ski Rental Name}:

    }
}
