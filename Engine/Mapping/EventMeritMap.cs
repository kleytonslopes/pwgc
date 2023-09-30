using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Engine.Entities;

namespace Engine.Mapping
{
    class EventMeritMap : ClassMap<EventMerit>
    {
        public EventMeritMap() 
        {
            Table("data_event_merit");
            Id(x => x.ID).Column("evme_id");
            Map(x => x.NickCharacter).Column("evme_nick_character");
            Map(x => x.FirstMerit).Column("evme_first_merit");
            Map(x => x.LastMerit).Column("evme_last_merit");
            Map(x => x.FirstOwner).Column("evme_first_owner");
            Map(x => x.LastOwner).Column("evme_last_owner");
        }
    }
}