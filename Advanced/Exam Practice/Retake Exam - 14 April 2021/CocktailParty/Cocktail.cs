using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private List<Ingredient> ingredients;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            ingredients = new List<Ingredient>();
        }
        public int CurrentAlcoholLevel => ingredients.Sum(x => x.Alcohol);

        public void Add(Ingredient ingredient) /*- adds the entity if there isn't an Ingredient with the same name and if there is enough space in terms of quantity and alcohol.*/
        {
            if (!ingredients.Contains(ingredients.Find(x=>x.Name == ingredient.Name)) &&
                CurrentAlcoholLevel + ingredient.Alcohol <= MaxAlcoholLevel)
            {
                ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name) /*- removes an Ingredient from the cocktail with the given name, if such exists and returns bool if the deletion is successful.*/
        {
            Ingredient toRemove = ingredients.FirstOrDefault(x => x.Name == name);

            if (toRemove == null)
            {
                return false;
            }
            ingredients.Remove(toRemove);
            return true;
        }

        public Ingredient FindIngredient(string name) /*- returns an Ingredient with the given name.If it doesn't exist, return null.*/
        {
            return ingredients.FirstOrDefault(x => x.Name == name);
        }
        public Ingredient GetMostAlcoholicIngredient()/*– returns the Ingredient with most Alcohol.*/
        {
            int max = ingredients.Select(x => x.Alcohol).Max();
            var mostAlcoholic = ingredients.Find(ingredient => ingredient.Alcohol == max);
           
            return mostAlcoholic;
        }

        public string Report() /*- returns information about the Cocktail and the Ingredients inside it in the following format:*/
            //"Cocktail: {name} - Current Alcohol Level: {CurrentAlcoholLevel}
            //{Ingredient1 }
            //{Ingredient2 }… "
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            foreach (var ingredient in ingredients)
            {
                output.AppendLine(ingredient.ToString());
            }

            return output.ToString().TrimEnd();
        }


    }
}
