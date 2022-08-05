namespace EasterRaces.Utilities.Messages
{
    public static class ExceptionMessages
    {
        public const string InvalidModel = "Model {0} cannot be less than {1} symbols.";
     
        public const string InvalidName = "Name {0} cannot be less than {1} symbols.";
  
        public const string InvalidHorsePower = "Invalid horse power: {0}.";
    
        public const string InvalidNumberOfLaps = "Laps cannot be less than {0}.";

        public const string DriversExists = "Driver {0} is already created.";
        
        public const string DriverAlreadyAdded = "Driver {0} is already added in {1} race.";
               
        public const string DriverNotFound = "Driver {0} could not be found.";
               
        public const string DriverNotParticipate = "Driver {0} could not participate in race.";
            
        public const string DriverInvalid = "Driver cannot be null.";
           
        public const string CarExists = "Car {0} is already create.";
       
        public const string CarInvalid = "Car cannot be null.";
     
        public const string CarNotFound = "Car {0} could not be found.";
         
        public const string RaceNotFound = "Race {0} could not be found.";
      
        public const string RaceExists = "Race {0} is already created.";
    
        public const string RaceInvalid = "Race {0} cannot start with less than {1} participants.";
    }
}
