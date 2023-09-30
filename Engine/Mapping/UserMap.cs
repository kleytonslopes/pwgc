using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Engine.Entities;

namespace Engine.Mapping
{
    class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("data_usuario");
            Id(x => x.ID).Column("u_id");
            Map(x => x.Login).Column("u_login");
            Map(x => x.Password).Column("u_pwd");
            Map(x => x.Name).Column("u_name");
            Map(x => x.Nick).Column("u_nick");
            Map(x => x.Email).Column("u_email");
            Map(x => x.Permission).Column("u_permission");
            Map(x => x.LastLogin).Column("u_last_entrance");
            Map(x => x.Blocked).Column("u_blocked");
        }
    }
}
/*
    u_id int(10) AI PK 
    u_nick varchar(50) 
    u_login varchar(50) 
    u_pwd varchar(50) 
    u_email varchar(150) 
    u_name varchar(150) 
u_target varchar(50) 
u_warning varchar(2048) 
    u_permission int(11) 
u_level int(10) 
u_exp_min int(100) 
u_exp_max int(100) 
u_online varchar(1) 
u_last_entrance datetime
*/
