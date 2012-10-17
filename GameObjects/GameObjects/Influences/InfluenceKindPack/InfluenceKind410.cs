﻿namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind410 : InfluenceKind
    {
        private float rate;


        public override void ApplyInfluenceKind(Troop troop)
        {
            troop.RateOfOffence += this.rate;
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

        public override void PurifyInfluenceKind(Troop troop)
        {
            troop.RateOfOffence -= this.rate;
        }

    }
}

