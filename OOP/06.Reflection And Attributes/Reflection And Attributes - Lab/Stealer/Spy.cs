using System.Linq;
using System.Reflection;

namespace Stealer
{
    using System;
    using System.Text;

    public class Spy
    {
        public string StealFieldInfo(string className, params string[] requestedFields)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Public |
                                                                    BindingFlags.NonPublic |
                                                                    BindingFlags.Static |
                                                                    BindingFlags.Instance);

            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {classType.FullName}");

            foreach (var field in classFields.Where(field => requestedFields.Contains(field.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }


    }
}
