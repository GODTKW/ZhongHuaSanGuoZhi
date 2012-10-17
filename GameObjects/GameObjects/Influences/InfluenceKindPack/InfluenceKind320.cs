﻿namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind320 : InfluenceKind
    {
        private int combatMethodID;

        public override void ApplyInfluenceKind(Troop troop)
        {
            troop.CombatMethods.AddCombatMethod(troop.Scenario.GameCommonData.AllCombatMethods.GetCombatMethod(this.combatMethodID));
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.combatMethodID = int.Parse(parameter);
            }
            catch
            {
            }
        }

        public override void PurifyInfluenceKind(Troop troop)
        {
            troop.CombatMethods.RemoveCombatMethod(troop.Scenario.GameCommonData.AllCombatMethods.GetCombatMethod(this.combatMethodID));
        }
    }
}

