using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        //Next, write a C# class Bakery that has data (a collection, which stores the entity Employee). All entities inside the repository have the same properties. Also, the Bakery class should have those properties:
        //•	Name: string
        //•	Capacity: int
        public string Name { get; set; }

        public int Capacity { get; set; }
        //    Getter Count – returns the number of employees
        public int Count => data.Count;

        //•	Field data – collection that holds added Employees
        private List<Employee> data;

        //    The class constructor should receive name and capacity, also it should initialize the data with a new instance of the collection.Implement the following features:
        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Employee>();
        }

        public void Add(Employee employee)//– adds an entity to the data if there is room for him/her.
        {
            if (Count < Capacity)
            {
                data.Add(employee);
            }
        }

        public bool Remove(string name)//– removes an employee by given name, if such exists, and returns bool.
        {
            return data.Remove(data.Find(e => e.Name == name));
        }

        public Employee GetOldestEmployee() //– returns the oldest employee.
        {
            int biggestAge = data.Select(e => e.Age).Max();
            return data.Find(e => e.Age == biggestAge);
        }

        public Employee GetEmployee(string name)//– returns the employee with the given name.
        {
            return data.Find(e => e.Name == name);
        }
        public string Report() /*– returns a string in the following format:*/
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"Employees working at Bakery {Name}:");

            foreach (var employee in data)
            {
                output.AppendLine(employee.ToString());
            }

            return output.ToString().TrimEnd();
        }
    }
}
