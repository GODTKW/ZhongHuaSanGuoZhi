﻿namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind3400 : InfluenceKind
    {
        private float rate = 1f;

        public override void ApplyInfluenceKind(Architecture architecture)
        {
            architecture.RateOfFoodReduceRate -= this.rate;
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.rate = float.Parse(parameter);
            }
            catch
            {
            }
        }

        public override void PurifyInfluenceKind(Architecture architecture)
        {
            architecture.RateOfFoodReduceRate += this.rate;
        }

        public override double AIFacilityValue(Architecture a)
        {
            return (a.Food * Math.Pow(1 - a.FoodReduceDayRate, 30) - a.ExpectedFood) / 100000.0;
        }
    }
}

