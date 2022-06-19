using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailParty
{
    public class Ingredient
    {
        public string Name { get; set; }

        public int Alcohol { get; set; }

        public int Quantity { get; set; }
        public Ingredient(string name, int alcohol, int quantity)
        {
            Name = name;
            Alcohol = alcohol;
            Quantity = quantity;
        }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Ingredient: {Name}");
            output.AppendLine($"Quantity: {Quantity}");
            output.AppendLine($"Alcohol: {Alcohol}");
            return output.ToString().TrimEnd();
        }
    }
}
