using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Repositories;
using Easter.Utilities.Messages;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;

        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = null;

            switch (bunnyType)
            {
                case "HappyBunny":
                    bunny = new HappyBunny(bunnyName);
                    break;
                case "SleepyBunny":
                    bunny = new SleepyBunny(bunnyName);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            bunnies.Add(bunny);

            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            var targetBunny = bunnies.FindByName(bunnyName);

            if (targetBunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            targetBunny.AddDye(new Dye(power));

            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);

            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            var suitableBunnies = bunnies.Models
                .Where(b => b.Energy >= 50)
                .OrderByDescending(b => b.Energy)
                .ToList();

            if (!suitableBunnies.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            IEgg eggToColor = eggs.FindByName(eggName);
            Workshop workshop = new Workshop();

            foreach (var suitableBunny in suitableBunnies)
            {
                workshop.Color(eggToColor, suitableBunny);

                if (suitableBunny.Energy == 0)
                {
                    bunnies.Remove(suitableBunny);
                }
                if (eggToColor.IsDone() == true)
                {
                    break;
                }
            }

            return eggToColor.IsDone() == true
                ? string.Format(OutputMessages.EggIsDone, eggName)
                : string.Format(OutputMessages.EggIsNotDone, eggName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            int coloredEggs = eggs.Models.Count(e => e.IsDone() == true);

            sb.AppendLine($"{coloredEggs} eggs are done!");
            sb.AppendLine($"Bunnies info:");

            foreach (var bunny in bunnies.Models)
            {
                int countDyesNotFinished = bunny.Dyes.Count(d => d.IsFinished() == false);

                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {countDyesNotFinished} not finished");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
