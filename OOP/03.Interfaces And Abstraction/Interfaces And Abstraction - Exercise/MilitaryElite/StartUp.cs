using MilitaryElite.Classes;
using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, ISoldier> soldiers = new Dictionary<string, ISoldier>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] soldierInfo = input.Split(' ');

                string rankOfSoldier = soldierInfo[0];
                string id = soldierInfo[1];
                string firstName = soldierInfo[2];
                string lastName = soldierInfo[3];
                decimal salary = decimal.Parse(soldierInfo[4]);

                switch (rankOfSoldier)
                {
                    case "Private":
                    {
                        Private @private = new Private(id, firstName, lastName, salary);
                        soldiers[id] = @private;
                        break;
                    }
                    case "LieutenantGeneral":
                    {
                        LieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                        for (int i = 5; i < soldierInfo.Length; i++)
                        {
                            string idToLookFor = soldierInfo[i];
                            IPrivate @private = soldiers[idToLookFor] as IPrivate;
                            lieutenantGeneral.Privates.Add(@private);
                        }

                        soldiers[id] = lieutenantGeneral;
                        break;
                    }
                    case "Engineer":
                    {
                        string corpsAsString = soldierInfo[5];

                        if (!Enum.IsDefined(typeof(Corps), corpsAsString))
                        {
                            input = Console.ReadLine();
                            continue;
                        }
                    
                        IEngineer engineer = new Engineer(id, firstName, lastName, salary, Enum.Parse<Corps>(corpsAsString));

                        for (int i = 6; i < soldierInfo.Length; i+=2)
                        {
                            string partName = soldierInfo[i];
                            int hoursWorked = int.Parse(soldierInfo[i + 1]);

                            Repair repair = new Repair(partName, hoursWorked);
                            engineer.Repairs.Add(repair);
                        }
                    
                        soldiers[id] = engineer;
                        break;
                    }
                    case "Commando":
                    {
                        string corpsAsString = soldierInfo[5];

                        if (!Enum.IsDefined(typeof(Corps), corpsAsString))
                        {
                            input = Console.ReadLine();
                            continue;
                        }

                        ICommando commando = new Commando(id, firstName, lastName, salary, Enum.Parse<Corps>(corpsAsString));

                        for (int i = 6; i < soldierInfo.Length; i+=2)
                        {
                            string codeName = soldierInfo[i];
                            string statusAsString = soldierInfo[i + 1];

                            if (Enum.IsDefined(typeof(Status), statusAsString))
                            {
                                IMission mission = new Mission(codeName, Enum.Parse<Status>(statusAsString));
                                commando.Missions.Add(mission);
                            }
                        }

                        soldiers[id] = commando;
                        break;
                    }
                    case "Spy":
                    {
                        int codeNumber = int.Parse(salary.ToString());
                        ISpy spy = new Spy(id, firstName, lastName, codeNumber);

                        soldiers[id] = spy;
                        break;
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier.Value.ToString());
            }
        }
    }
}
