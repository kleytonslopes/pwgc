using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Engine.Entities;

namespace Engine.Mapping
{
    class CharacterMap : ClassMap<Character>
    {
        public CharacterMap()
        {
            Table("data_char");
            Id(x => x.Id).Column("ch_id");
            Map(x => x.Nick).Column("ch_nick");
            Map(x => x.Grade).Column("ch_grade");
            Map(x => x.Level).Column("ch_level");
            Map(x => x.Status).Column("ch_status");
            //Map(x => x.Title).Column("ch_title");
            Map(x => x.Office).Column("ch_office");
            Map(x => x.Merit).Column("ch_merit");
            Map(x => x.Entry).Column("ch_entrance");
            Map(x => x.Updated).Column("ch_update");
            //Map(x => x.TrialCount).Column("ch_trial");
            //Map(x => x.ContributionCount).Column("ch_contribution");
            Map(x => x.OtherChar).Column("ch_othercharacter");
            Map(x => x.Owner).Column("ch_owner");
            Map(x => x.LevelEntrance).Column("ch_level_entrance");
            Map(x => x.Recruter).Column("ch_recruter");
            Map(x => x.OwnerEntrance).Column("ch_owner_register");
            Map(x => x.LastLevel).Column("ch_last_level");
            Map(x => x.LastMerit).Column("ch_last_merit");
            Map(x => x.LastUpdated).Column("ch_last_update");
            Map(x => x.LastStatus).Column("ch_last_status");
            //Map(x => x.LastTrial).Column("ch_last_trial");
            Map(x => x.LastOwner).Column("ch_last_owner");
            //Map(x => x.MeritWinnings).Column("ch_merit_count");
            Map(x => x.Observation).Column("ch_observation");
            Map(x => x.Reborn).Column("ch_reborn");
            Map(x => x.Idicated).Column("ch_indicator");
            Map(x => x.Rank).Column("ch_rank");
            Map(x => x.Visible).Column("ch_show");
            Map(x => x.EventMerit).Column("ch_event_merit");
        }
    }
}

/*
ch_id int(11) AI PK 
ch_nick varchar(25) 
ch_grade varchar(50) 
ch_level varchar(3) 
ch_status varchar(50) 
ch_title varchar(10) 
ch_office varchar(10) 
ch_merit varchar(10) 
ch_entrance datetime 
ch_update datetime 
ch_trial varchar(10) 
ch_contribution varchar(10) 
ch_othercharacter varchar(10) 
ch_owner varchar(50) 
ch_level_entrance varchar(3) 
ch_recruter varchar(50) 
ch_owner_register varchar(9) 
ch_last_level varchar(3) 
ch_last_merit varchar(10) 
ch_last_update datetime 
ch_last_status varchar(50) 
ch_last_trial varchar(10) 
ch_last_owner varchar(50) 
ch_merit_count varchar(10) 
ch_observation varchar(2048) 
ch_reborn varchar(45) 
ch_indicator varchar(45) 
ch_rank varchar(150)

    ch_id int(11) AI PK 
    ch_name varchar(40) 
    ch_level int(11) 
    ch_class varchar(45) 
    ch_status varchar(45) 
    ch_merit int(11) 
    ch_office varchar(45) 
    ch_owner varchar(45) 
    ch_ownerregister varchar(45) 
    ch_lastowner varchar(45) 
    ch_laststatus varchar(45) 
    ch_lastlevel int(11) 
    ch_lastmerit int(11) 
    ch_reborn varchar(45) 
    ch_rank varchar(45) 
    ch_crimping varchar(45) 
    ch_indicator varchar(45) 
    ch_othercharid int(11) 
    ch_observation varchar(2048) 
    ch_levelentrance int(11) 
    ch_entrance datetime 
    ch_update datetime 
    ch_lastupdate datetime




*/
