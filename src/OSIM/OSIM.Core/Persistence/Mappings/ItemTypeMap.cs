using FluentNHibernate.Mapping;
using OSIM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIM.Core.Persistence.Mappings
{
    public class ItemTypeMap : ClassMap<ItemType>
    {
        public ItemTypeMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
        }
    }
}
