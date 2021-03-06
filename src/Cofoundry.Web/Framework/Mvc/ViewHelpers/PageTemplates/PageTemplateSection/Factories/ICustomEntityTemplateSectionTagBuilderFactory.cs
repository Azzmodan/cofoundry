﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Cofoundry.Web
{
    /// <summary>
    /// Factory that enables ICustomEntityTemplateSectionTagBuilderFactory implementation to be swapped out.
    /// </summary>
    /// <remarks>
    /// The factory is required because the HtmlHelper cannot be injected
    /// </remarks>
    public interface ICustomEntityTemplateSectionTagBuilderFactory
    {
        ICustomEntityTemplateSectionTagBuilder<TModel> Create<TModel>(
            HtmlHelper htmlHelper,
            ICustomEntityDetailsPageViewModel<TModel> customEntityViewModel,
            string sectionName
            )
            where TModel : ICustomEntityDetailsDisplayViewModel
            ;
    }
}
