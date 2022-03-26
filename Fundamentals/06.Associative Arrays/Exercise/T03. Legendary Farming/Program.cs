using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace T03._Legendary_Farming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> legendaryItems = new Dictionary<string, string>
            {
                {"shards","Shadowmourne" },
                {"fragments", "Valanyr" },
                {"motes", "Dragonwrath" }
            };

            Dictionary<string, int> keyMaterials = new Dictionary<string, int>()
                {   
                    { "shards", 0 },
                    { "motes", 0 },
                    { "fragments", 0 }
                };

            Dictionary<string, int> junkMaterials = new Dictionary<string, int>();

            string legendaryItem = string.Empty;

            while (legendaryItem == "")
            {
                string[] foundMaterials = Console.ReadLine().Split();

                for (int i = 0; i < foundMaterials.Length; i += 2)
                {
                    int quantity = int.Parse(foundMaterials[i]);
                    string materialName = foundMaterials[i + 1].ToLower();

                    CollectItems(quantity, materialName, keyMaterials, junkMaterials);

                    if (keyMaterials.ContainsKey(materialName))
                    {
                        bool isItemFound = CheckIfItemFound(keyMaterials, materialName);

                        if (isItemFound)
                        {
                            legendaryItem = legendaryItems[materialName];
                            break;
                        }
                    }
                }
            }

            Console.WriteLine($"{legendaryItem} obtained!");

            foreach (var item in keyMaterials)
            {
                Console.WriteLine($"{item.Key.ToLower()}: {item.Value}");
            }

            foreach (var item in junkMaterials)
            {
                Console.WriteLine($"{item.Key.ToLower()}: {item.Value}");
            }
        }

        private static bool CheckIfItemFound(Dictionary<string, int> keyMaterials, string materialName)
        {
            if (keyMaterials[materialName] >= 250)
            {
                keyMaterials[materialName] -= 250;
                return true;
            }

            return false;
        }

        public static void CollectItems(int quantity, string material, Dictionary<string, int> keyMaterials, Dictionary<string, int> junkMaterials)
        {
            if (keyMaterials.ContainsKey(material))
            {
                keyMaterials[material] += quantity;
            }
            else
            {
                if (!junkMaterials.ContainsKey(material))
                {
                    junkMaterials.Add(material, 0);
                }

                junkMaterials[material] += quantity;
            }
        }
    }
}
