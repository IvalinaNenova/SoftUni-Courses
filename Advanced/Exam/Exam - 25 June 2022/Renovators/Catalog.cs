using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private readonly List<Renovator> renovators;
        
        public string Name { get; set; }

        public int NeededRenovators { get; set; }

        public string Project { get; set; }
        
        public int Count => renovators.Count;
        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            renovators = new List<Renovator>(neededRenovators);
        }
        public string AddRenovator(Renovator renovator) 
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            else if (Count == NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            else if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            Renovator renovatorToRemove = renovators.FirstOrDefault(x => x.Name == name);
            if (renovatorToRemove == null) return false;
            renovators.Remove(renovatorToRemove);
            return true;

        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            return renovators.RemoveAll(r => r.Type == type);
        }
        public 	Renovator HireRenovator(string name) 
        {
            return renovators.FirstOrDefault(r => r.Name == name);
           
        }

        public List<Renovator> PayRenovators(int days)
        {
            return renovators.FindAll(r => r.Days >= days).ToList();
        }
        public string Report()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"Renovators available for Project {Project}:");
            
            foreach (var renovator in renovators.Where(r=>r.Hired == false))
            {
                output.AppendLine(renovator.ToString());
            }

            return output.ToString().TrimEnd();
        }
    }
}
