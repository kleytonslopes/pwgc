using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Engine.Entities;

namespace Engine.Mapping
{
    class ConfigMap : ClassMap<Config>
    {
        public ConfigMap()
        {
            Table("data_infor");
            Id(x => x.ID).Column("inf_id");
            Map(x => x.Code).Column("inf_param");
            Map(x => x.Description).Column("inf_message");
            Map(x => x.Target).Column("inf_target");
            Map(x => x.Observation).Column("inf_observation");
        }
    }
}
