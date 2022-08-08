using System;
using System.Linq;
using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;

namespace OnlineShop.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string ExecuteCommand(string[] data, IController controller)
        {
            string command = data[0];

            if (!Enum.TryParse(command, out CommandType commandType))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidCommand);
            }

            string msg = null;
            string[] clearData = data.Skip(1).ToArray();

            switch (commandType)
            {
                case CommandType.AddComputer:
                    msg = AddComputer(clearData, controller);
                    break;
                case CommandType.AddPeripheral:
                    msg = AddPeripheral(clearData, controller);
                    break;
                case CommandType.RemovePeripheral:
                    msg = RemovePeripheral(clearData, controller);
                    break;
                case CommandType.AddComponent:
                    msg = AddComponent(clearData, controller);
                    break;
                case CommandType.RemoveComponent:
                    msg = RemoveComponent(clearData, controller);
                    break;
                case CommandType.BuyComputer:
                    msg = BuyComputer(clearData, controller);
                    break;
                case CommandType.BuyBestComputer:
                    msg = BuyBestComputer(clearData, controller);
                    break;
                case CommandType.GetComputerData:
                    msg = GetComputerData(clearData, controller);
                    break;
                case CommandType.Close:
                    Environment.Exit(0);
                    break;
            }

            return msg;
        }

        private string GetComputerData(string[] data, IController controller)
        {
            int id = int.Parse(data[0]);

            string msg = controller.GetComputerData(id);
            return msg;
        }

        private string BuyBestComputer(string[] data, IController controller)
        {
            decimal price = decimal.Parse(data[0]);

            return controller.BuyBest(price);
        }

        private string BuyComputer(string[] data, IController controller)
        {
            int id = int.Parse(data[0]);

            return controller.BuyComputer(id);
        }

        private string RemoveComponent(string[] data, IController controller)
        {
            string productType = data[0];
            int computerId = int.Parse(data[1]);

            return controller.RemoveComponent(productType, computerId);
        }

        private string AddComponent(string[] data, IController controller)
        {
            int computerId = int.Parse(data[0]);
            int id = int.Parse(data[1]);
            string productType = data[2];
            string manufacturer = data[3];
            string model = data[4];
            decimal price = decimal.Parse(data[5]);
            double overallPerformance = double.Parse(data[6]);
            int generation = int.Parse(data[7]);

            return controller.AddComponent(computerId, id, productType, manufacturer, model, price,
                overallPerformance, generation);
        }

        private string RemovePeripheral(string[] data, IController controller)
        {
            string productType = data[0];
            int computerId = int.Parse(data[1]);

            return controller.RemovePeripheral(productType, computerId);
        }

        private string AddPeripheral(string[] data, IController controller)
        {
            int computerId = int.Parse(data[0]);
            int id = int.Parse(data[1]);
            string productType = data[2];
            string manufacturer = data[3];
            string model = data[4];
            decimal price = decimal.Parse(data[5]);
            double overallPerformance = double.Parse(data[6]);
            string connectionType = data[7];

            return controller.AddPeripheral(computerId, id, productType, manufacturer, model, price,
                overallPerformance, connectionType);
        }

        private string AddComputer(string[] data, IController controller)
        {
            string computerType = data[0];
            int id = int.Parse(data[1]);
            string manufacturer = data[2];
            string model = data[3];
            decimal price = decimal.Parse(data[4]);

            return controller.AddComputer(computerType, id, manufacturer, model, price);
        }
    }
}