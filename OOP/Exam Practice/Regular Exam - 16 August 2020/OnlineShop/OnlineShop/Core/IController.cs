namespace OnlineShop.Core
{
    public interface IController
    {
        string AddComputer(string computerType, int id, string manufacturer, string model, decimal price);

        string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType);

        string RemovePeripheral(string peripheralType, int computerId);

        string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation);

        string RemoveComponent(string componentType, int computerId);

        string BuyComputer(int id);

        string BuyBest(decimal budget);

        string GetComputerData(int id);
    }
}