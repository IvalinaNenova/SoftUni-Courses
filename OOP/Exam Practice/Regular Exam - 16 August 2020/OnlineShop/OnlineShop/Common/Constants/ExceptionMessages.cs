namespace OnlineShop.Common.Constants
{
    public static class ExceptionMessages
    {
        public const string InvalidCommand = "Command is invalid.";
        
        public const string InvalidProductId = "Id can not be less or equal than 0.";
        
        public const string InvalidManufacturer = "Manufacturer can not be empty.";
        
        public const string InvalidModel = "Model can not be empty.";
        
        public const string InvalidPrice = "Price can not be less or equal than 0.";

        public const string InvalidOverallPerformance = "Overall Performance can not be less or equal than 0.";
        
        public const string ExistingComponent = "Component {0} already exists in {1} with Id {2}.";
        
        public const string ExistingPeripheral = "Peripheral {0} already exists in {1} with Id {2}.";
       
        public const string NotExistingComponent = "Component {0} does not exist in {1} with Id {2}.";
        
        public const string NotExistingPeripheral = "Peripheral {0} does not exist in {1} with Id {2}.";

        public const string NotExistingComputerId = "Computer with this id does not exist.";

        public const string InvalidComputerType = "Computer type is invalid.";

        public const string ExistingComputerId = "Computer with this id already exists.";

        public const string InvalidPeripheralType = "Peripheral type is invalid.";

        public const string ExistingPeripheralId = "Peripheral with this id already exists.";

        public const string InvalidComponentType = "Component type is invalid.";

        public const string ExistingComponentId = "Component with this id already exists.";

        public const string CanNotBuyComputer = "Can't buy a computer with a budget of ${0}.";

    }
}
