﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace SitecoreDev.Feature.Media.ViewModels
{
  public class HeroSliderViewModel
  {
    public List<HeroSliderImageViewModel> HeroImages { get; set; } = new List<HeroSliderImageViewModel>();
    public int ImageCount => HeroImages.Count;
    public bool HasImages => ImageCount > 0;
    public bool IsInExperienceEditorMode { get; set; }
    public string ParentGuid { get; set; }
    public int SlideInterval { get; set; }
    public bool IsSliderIntervalSet { get { return SlideInterval > 0; } }

  }
}