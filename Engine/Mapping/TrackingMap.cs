using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Engine.Entities;

namespace Engine.Mapping
{
    class TrackingMap : ClassMap<Tracking>
    {
        public TrackingMap()
        {
            Table("data_rastreio");
            Id(x => x.ID).Column("ras_id");
            Map(x => x.Action).Column("ras_action");
            Map(x => x.DateTrack).Column("ras_date");
            Map(x => x.UserID).Column("ras_userid");
            Map(x => x.UserName).Column("ras_username");
            Map(x => x.CharacterID).Column("ras_charir");
            Map(x => x.CharacterName).Column("ras_charname");
            Map(x => x.CharacterLevel).Column("ras_charlevel");
            Map(x => x.CharacterLastLevel).Column("ras_charlastlevel");
            Map(x => x.CharacterClass).Column("ras_chargrade");
            Map(x => x.CharacterLastClass).Column("ras_charlastgrade");
            Map(x => x.CharacterStatus).Column("ras_charstatus");
            Map(x => x.CharacterLastStatus).Column("ras_charlaststatus");
            Map(x => x.CharacterMerit).Column("ras_charmerit");
            Map(x => x.CharacterLastMerit).Column("ras_charlastmerit");
        }      
    }
}
/*
 ras_id int(11) PK 
ras_action varchar(45) 
ras_date datetime 
ras_userid int(11) 
ras_charir varchar(45) 
ras_charname varchar(45) 
ras_charlevel int(11) 
ras_charlastlevel int(11) 
ras_chargrade varchar(45) 
ras_charlastgrade varchar(45) 
ras_charstatus varchar(45) 
ras_charlaststatus varchar(45) 
ras_charmerit int(11) 
ras_charlastmerit int(11)
 */