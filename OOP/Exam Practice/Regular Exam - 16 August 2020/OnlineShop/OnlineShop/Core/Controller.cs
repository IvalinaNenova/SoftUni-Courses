using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private ICollection<IComputer> computers;
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;

        public Controller()
        {
            computers = new List<IComputer>();
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }
        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computers.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            IComputer computer;
            switch (computerType)
            {
                case nameof(ComputerType.DesktopComputer):
                    computer = new DesktopComputer(id, manufacturer, model, price);
                    break;
                case nameof(ComputerType.Laptop):
                    computer = new Laptop(id, manufacturer, model, price);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            computers.Add(computer);

            return string.Format(SuccessMessages.AddedComputer, computer.Id);
        }
        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price,
            double overallPerformance, int generation)
        {
            if (components.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            IComponent component;

            switch (componentType)
            {
                case nameof(ComponentType.CentralProcessingUnit):
                    component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case nameof(ComponentType.Motherboard):
                    component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case nameof(ComponentType.PowerSupply):
                    component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case nameof(ComponentType.RandomAccessMemory):
                    component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case nameof(ComponentType.SolidStateDrive):
                    component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case nameof(ComponentType.VideoCard):
                    component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            var targetComputer = ValidateComputerDoesExist(computerId);
            targetComputer.AddComponent(component);
            components.Add(component);

            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            var targetComputer = ValidateComputerDoesExist(computerId);
            var removed = targetComputer.RemoveComponent(componentType);
            components.Remove(removed);

            return string.Format(SuccessMessages.RemovedComponent, componentType, removed.Id);
        }
        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price,
            double overallPerformance, string connectionType)
        {
            if (peripherals.Any(p => p.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            IPeripheral peripheral;

            switch (peripheralType)
            {
                case nameof(PeripheralType.Headset):
                    peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case nameof(PeripheralType.Keyboard):
                    peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case nameof(PeripheralType.Monitor):
                    peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case nameof(PeripheralType.Mouse):
                    peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            var targetComputer = ValidateComputerDoesExist(computerId);
            targetComputer.AddPeripheral(peripheral);
            peripherals.Add(peripheral);

            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            var targetComputer = ValidateComputerDoesExist(computerId);
            var removed = targetComputer.RemovePeripheral(peripheralType);
            peripherals.Remove(removed);

            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, removed.Id);
        }
        public string BuyComputer(int id)
        {
            var targetComputer = ValidateComputerDoesExist(id);

            computers.Remove(targetComputer);
            return targetComputer.ToString();
        }

        public string BuyBest(decimal budget)
        {
            var orderedByPerformance = computers.OrderByDescending(c => c.OverallPerformance);
            IComputer bestComputer = null;

            foreach (var computer in orderedByPerformance)
            {
                if (computer.Price <= budget)
                {
                    bestComputer = computer;
                    break;
                }
            }
            if (bestComputer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            computers.Remove(bestComputer);
            return bestComputer.ToString();
        }

        public string GetComputerData(int id)
        {
            var targetComputer = ValidateComputerDoesExist(id);
            return targetComputer.ToString();
        }

        private IComputer ValidateComputerDoesExist(int id)
        {
            if (computers.All(c => c.Id != id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            return computers.First(c => c.Id == id);
        }
    }
}
