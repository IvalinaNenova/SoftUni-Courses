namespace OnlineShop.Common.Constants
{
    public static class SuccessMessages
    {
        public const string AddedComputer = "Computer with id {0} added successfully.";
        
        public const string AddedPeripheral = "Peripheral {0} with id {1} added successfully in computer with id {2}.";

        public const string RemovedPeripheral = "Successfully removed {0} with id {1}.";

        public const string AddedComponent = "Component {0} with id {1} added successfully in computer with id {2}.";

        public const string RemovedComponent = "Successfully removed {0} with id {1}.";
        
        public const string ProductToString = "Overall Performance: {0}. Price: {1} - {2}: {3} {4} (Id: {5})";

        public const string ComponentToString = " Generation: {0}";

        public const string PeripheralToString = " Connection Type: {0}";

        public const string ComputerComponentsToString = "Components ({0}):";
        
        public const string ComputerPeripheralsToString = "Peripherals ({0}); Average Overall Performance ({1}):";
    }
}