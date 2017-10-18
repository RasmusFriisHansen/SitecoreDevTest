using System;
using System.Web.Mvc;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Resources.Media;
using SitecoreDev.Feature.Media.Repositories;
using SitecoreDev.Feature.Media.ViewModels;
using SitecoreDev.Foundation.Repository.Context;
using Glass.Mapper.Sc;
using SitecoreDev.Feature.Media.Services;
using System.Linq;

namespace SitecoreDev.Feature.Media.Controllers
{
    public class MyMediaController : Controller
    {
        private readonly IMediaContentService _mediaContentService;
        private readonly IContextWrapper _contextWrapper;
        private readonly IGlassHtml _glassHtml;
        public MyMediaController(IContextWrapper contextWrapper, IMediaContentService mediaContentService)
        {
            _contextWrapper = contextWrapper;
            _mediaContentService = mediaContentService;
        }
        public ViewResult HeroSlider()
        {
            var viewModel = new HeroSliderViewModel();
            if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                var contentItem = _mediaContentService.GetHeroSliderContent(RenderingContext.Current.Rendering.DataSource);
                foreach (var slide in contentItem?.Slides)
                {
                    viewModel.HeroImages.Add(new HeroSliderImageViewModel()
                    {
                        Id = slide.Id.ToString(),
                        MediaUrl = slide.Image?.Src,
                        AltText = slide.Image?.Alt
                    });
                }

                var firstItem = viewModel.HeroImages.FirstOrDefault();
                firstItem.IsActive = true;
                viewModel.ParentGuid = contentItem.Id.ToString();
            }
            var parameterValue = _contextWrapper.GetParameterValue("Slide Interval in Milliseconds");

            int interval = 0;
            if (int.TryParse(parameterValue, out interval))
                viewModel.SlideInterval = interval;

            viewModel.IsInExperienceEditorMode = _contextWrapper.IsExperienceEditor;
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
