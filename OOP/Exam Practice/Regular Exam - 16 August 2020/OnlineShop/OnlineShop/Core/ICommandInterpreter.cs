namespace OnlineShop.Core
{
    public interface ICommandInterpreter
    {
        string ExecuteCommand(string[] data, IController controller);
    }
}