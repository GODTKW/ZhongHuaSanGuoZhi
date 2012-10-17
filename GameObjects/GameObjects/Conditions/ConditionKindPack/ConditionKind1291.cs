﻿namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind1291 : ConditionKind
    {
        public override bool CheckConditionKind(Troop troop)
        {
            return ((troop.WillArchitecture != null) && (troop.WillArchitecture.BelongedFaction != null));
        }
    }
}

