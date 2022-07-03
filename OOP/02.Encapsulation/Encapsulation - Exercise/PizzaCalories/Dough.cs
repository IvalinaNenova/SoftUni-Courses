using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Dough
    {
        private Dictionary<string, double> flourTypeCalories = new Dictionary<string, double>
        {
            {"white", 1.5},
            {"wholegrain", 1},
        };

        private Dictionary<string, double> bakingTechniqueCalories = new Dictionary<string, double>
        {
            {"crispy", 0.9},
            {"chewy", 1.1},
            {"homemade", 1},
        };
        private const int CaloriesPerGram = 2;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public double Calories =>
            CaloriesPerGram * Weight * flourTypeCalories[this.FlourType.ToLower()] *
            bakingTechniqueCalories[this.BakingTechnique.ToLower()];

        public string FlourType
        {
            get => flourType;
            private set
            {
                if (!flourTypeCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => bakingTechnique;
            private set
            {
                if (!bakingTechniqueCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                bakingTechnique = value;
            }
        }

        public double Weight
        {
            get => weight;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                weight = value;
            }
        }
    }
}
