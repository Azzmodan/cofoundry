﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Cofoundry.Core.DependencyInjection;
using Cofoundry.Core.Validation;

namespace Cofoundry.Core.Configuration
{
    /// <summary>
    /// An InjectionFactory for transforming application configuration files into settings objects.
    /// </summary>
    /// <typeparam name="TSettings">Type of settings object to instantiate</typeparam>
    public interface IConfigurationSettingsFactory<TSettings> : IInjectionFactory<TSettings> where TSettings : IConfigurationSettings, new()
    {
    }
}
