﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Cofoundry.Domain;

namespace Cofoundry.Web
{
    /// <summary>
    /// Data model representing a single line of text, without formatting
    /// </summary>
    public class SingleLineTextDataModel : IPageModuleDataModel
    {
        [Required]
        [Display(Name = "Text", Description = "Normally just text but basic HTML is accepted.")]
        [AllowHtml]
        //[Searchable]
        public string Text { get; set; }

    }
}