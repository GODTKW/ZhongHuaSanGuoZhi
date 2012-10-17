﻿namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect330 : EventEffectKind
    {
        public override void ApplyEffectKind(Person person, Event e)
        {
            person.PersonalTitle.Influences.PurifyInfluence(person);
            person.PersonalTitle = null;
        }
    }
}

