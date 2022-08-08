using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public override double OverallPerformance
        {
            get
            {
                if (!components.Any())
                {
                    return base.OverallPerformance;
                }

                return base.OverallPerformance + components.Average(c => c.OverallPerformance);
            }
        }

        public override decimal Price => base.Price + components.Sum(c => c.Price) + peripherals.Sum(p => p.Price);

        public IReadOnlyCollection<IComponent> Components => components;

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals;

        public void AddComponent(IComponent component)
        {
            if (Components.Any(c => c.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name,
                    this.GetType().Name, this.Id));
            }

            components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (components.All(c => c.GetType().Name != componentType))
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }

            IComponent componentToRemove = components.First(c => c.GetType().Name == componentType);
            components.Remove(componentToRemove);

            return componentToRemove;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(p => p.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral,
                    peripheral.GetType().Name, this.GetType().Name, this.Id));
            }

            peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (peripherals.All(p => p.GetType().Name != peripheralType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType,
                    this.GetType().Name, this.Id));
            }

            var peripheralToRemove = peripherals.First(p => p.GetType().Name == peripheralType);
            peripherals.Remove(peripheralToRemove);

            return peripheralToRemove;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendLine($" Components ({this.Components.Count}):");

            foreach (var component in Components)
            {
                sb.AppendLine($"  {component.ToString()}");
            }

            double peripheralOP = peripherals.Any() ? peripherals.Average(p => p.OverallPerformance) : 0;
            sb.AppendLine(
                $" Peripherals ({peripherals.Count}); Average Overall Performance ({peripheralOP:f2}):");

            foreach (var peripheral in peripherals)
            {
                sb.AppendLine($"  {peripheral.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
