﻿namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect500 : EventEffectKind
    {
        private int type;

        public override void ApplyEffectKind(Person person, Event e)
        {
            Treasure t = person.Scenario.Treasures.GetGameObject(type) as Treasure;
            if (t.BelongedPerson != null)
            {
                t.BelongedPerson.LoseTreasure(t);
            }
            person.ReceiveTreasure(t);
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.type = int.Parse(parameter);
            }
            catch
            {
            }
        }
    }
}

