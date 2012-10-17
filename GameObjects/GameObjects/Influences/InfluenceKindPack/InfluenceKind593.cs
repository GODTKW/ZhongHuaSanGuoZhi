﻿namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind593 : InfluenceKind
    {


        public override void ApplyInfluenceKind(Troop troop)
        {
            troop.LowerLevelInformationWhileInvestigated = true;
        }

        public override void PurifyInfluenceKind(Troop troop)
        {
            troop.LowerLevelInformationWhileInvestigated = false;
        }
    }
}

