﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreDev.Foundation.Model;

namespace SitecoreDev.Feature.Articles.Models
{
  public interface IArticle : ICmsEntity
  {
    Guid Id { get; }
    string Title { get; }
    string Body { get; }
  }
}
