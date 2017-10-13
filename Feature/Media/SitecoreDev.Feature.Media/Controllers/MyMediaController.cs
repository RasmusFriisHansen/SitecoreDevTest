﻿using System;
using System.Web.Mvc;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Resources.Media;
using SitecoreDev.Feature.Media.Repositories;
using SitecoreDev.Feature.Media.ViewModels;

namespace SitecoreDev.Feature.Media.Controllers
{
  public class MyMediaController : Controller
  {
    private readonly IMediaRepository _repository;
    public MyMediaController()
    {
      _repository = new SitecoreMediaRepository();
    }
    public ViewResult HeroSlider()
    {
      var viewModel = new HeroSliderViewModel();

      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var contentItem = _repository.GetItem(
          RenderingContext.Current.Rendering.DataSource);
        if (contentItem != null)
        {
          var heroImagesField = new MultilistField(
            contentItem.Fields["Hero Images"]);
          if (heroImagesField != null)
          {
            var items = heroImagesField.GetItems();
            var itemCounter = 0;
            foreach (var item in items)
            {
              var mediaItem = (MediaItem)item;
              viewModel.HeroImages.Add(new HeroSliderImageViewModel()
              {
                MediaUrl = MediaManager.GetMediaUrl(mediaItem),
                AltText = mediaItem.Alt,
                IsActive = itemCounter == 0
              });
              itemCounter++;
            }
          }
        }
      }
      return View(viewModel);
    }
  }
}

      /*
      // Old media Controller from Chapter 4
      public class MyMediaController : SitecoreController
      {
        public ViewResult HeroSlider()
        {
          Item contentItem = null;
          var database = Context.Database;
          if (database != null && !String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
          {
            contentItem = database.GetItem(
              new Sitecore.Data.ID(RenderingContext.Current.Rendering.DataSource));
          }
          return View(contentItem);
        }
      }
      */
    