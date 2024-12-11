using System.Collections.Generic;
using System;

namespace SafariApp_v2.Model
{
    internal class Omnivorous : Animal
    {
        public Omnivorous(int turn) : base(turn) { }

        /// <summary>
        /// Defines the types of food an omnivore can consume.
        /// </summary>
        /// <returns>A list containing Plant and Herbivorous.</returns>
        protected override List<Type> GetFoodTypes()
        {
            return new List<Type> { typeof(Plant), typeof(Gazelle) };
        }
    }
}
