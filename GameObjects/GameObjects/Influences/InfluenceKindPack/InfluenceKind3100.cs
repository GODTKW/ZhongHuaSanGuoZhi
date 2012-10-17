﻿namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind3100 : InfluenceKind
    {
        private int multiple = 1;

        public override void ApplyInfluenceKind(Architecture architecture)
        {
            architecture.MultipleOfTraining += this.multiple - 1;
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.multiple = int.Parse(parameter);
            }
            catch
            {
            }
        }

        public override void PurifyInfluenceKind(Architecture architecture)
        {
            architecture.MultipleOfTraining -= this.multiple - 1;
        }

        public override double AIFacilityValue(Architecture a)
        {
            return (a.FrontLine ? this.multiple : 0.01) * (a.FrontLine ? 2 : 1) * (a.HostileLine ? 2 : 1) * (a.CriticalHostile ? 2 : 1);
        }
    }
}

