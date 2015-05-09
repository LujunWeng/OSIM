using OSIM.Core.Persistence;
using OSIM.Core.Entities;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Ninject.Modules;
using Ninject.Activation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Tool.hbm2ddl;
using OSIM.Core.Persistence.Mappings;


namespace OSIM.IntegrationTests
{
    class IntegrationTestModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IItemTypeRepository>().To<ItemTypeRepository>();
            Bind<ISessionFactory>().ToProvider(new IntegrationTestSessionFactoryProvider());
        }
    }

    public class IntegrationTestSessionFactoryProvider : Provider<ISessionFactory>
    {
        protected override ISessionFactory CreateInstance(IContext context)
        {
            var sessionFactory =
                    Fluently.Configure()
                            .Database(MySQLConfiguration.Standard.ConnectionString(
                                c => c.Server("localhost")
                                      .Database("osim.dev")
                                      .Username("root")
                                      .Password("beimian")))
                            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ItemTypeMap>().ExportTo(@"C:\Temp"))
                            .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                            .BuildSessionFactory();
            return sessionFactory;
                                            
        }
    }
}
