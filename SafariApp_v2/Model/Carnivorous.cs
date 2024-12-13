using System;
using System.Collections.Generic;

namespace SafariApp_v2.Model
{
    internal class Carnivorous : Animal
    {
        public Carnivorous(int turn) : base(turn) { }

        /// <summary>
        /// Defines the types of food a carnivore can consume.
        /// </summary>
        /// <returns>A list containing Herbivorous.</returns>
        protected override List<Type> GetFoodTypes()
        {
            return new List<Type> { typeof(Gazelle), typeof(Elephant) /* Examen 1 */ };
        }
    }
}
