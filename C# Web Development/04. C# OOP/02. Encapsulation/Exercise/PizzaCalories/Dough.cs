using System;

namespace PizzaCalories
{
    public class Dough
    {
        //---------------------------Fields---------------------------
        private string flourType;
        private string bakingTechnique;
        private double weight;

        //---------------------------Properties---------------------------
        public string FlourType
        {
            get => this.flourType;

            private set
            {
                string flour = value.ToLower();

                if (flour != "white" && flour != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value.ToLower();
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;

            private set
            {
                string technique = value.ToLower();

                if (technique != "crispy" && technique != "chewy" && technique != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value.ToLower();
            }
        }

        public double Weight
        {
            get => this.weight;

            private set
            {
                if (value <= 0 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        public double Calories
        {
            get => this.CalculateCalories();
        }

        //---------------------------Constructors---------------------------
        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        //---------------------------Methods---------------------------
        private double CalculateCalories()
        {
            double flourModifier = 0;

            switch (this.FlourType)
            {
                case "white":
                    flourModifier = 1.5;
                    break;
                case "wholegrain":
                    flourModifier = 1.0;
                    break;
            }

            double bakingTechniqueModifier = 0;

            switch (this.BakingTechnique)
            {
                case "crispy":
                    bakingTechniqueModifier = 0.9;
                    break;
                case "chewy":
                    bakingTechniqueModifier = 1.1;
                    break;
                case "homemade":
                    bakingTechniqueModifier = 1.0;
                    break;
            }

            return (2 * this.Weight) * flourModifier * bakingTechniqueModifier;
        }
    }
}
