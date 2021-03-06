﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cofoundry.Core.Configuration;
using Cofoundry.Core.DependencyInjection;

namespace Cofoundry.Core.EntityFramework
{
    public class EntityFrameworkDependencyRegistration : IDependencyRegistration
    {
        public void Register(IContainerRegister container)
        {
            container
                .RegisterType<IEntityFrameworkSqlExecutor, EntityFrameworkSqlExecutor>()
                .RegisterType<ITransactionScopeFactory, TransactionScopeFactory>()
                .RegisterType<ISqlParameterFactory, SqlParameterFactory>()
                ;
        }
    }
}
