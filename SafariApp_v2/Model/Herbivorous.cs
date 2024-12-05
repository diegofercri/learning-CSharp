using System;
using System.Collections.Generic;

namespace SafariApp_v2.Model
{
    internal class Herbivorous : Animal
    {
        public Herbivorous(Safari safari) : base(safari) { }

        /// <summary>
        /// Defines the types of food an herbivore can consume.
        /// </summary>
        /// <returns>A list containing Plant.</returns>
        protected override List<Type> GetFoodTypes()
        {
            return new List<Type> { typeof(Plant) };
        }
    }
}
