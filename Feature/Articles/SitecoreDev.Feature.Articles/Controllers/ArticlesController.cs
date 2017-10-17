using System;
using System.Web.Mvc;
using Sitecore.Mvc.Presentation;
using SitecoreDev.Feature.Articles.Models;
using SitecoreDev.Feature.Articles.Services;
using SitecoreDev.Feature.Articles.ViewModels;

namespace SitecoreDev.Feature.Articles.Controllers
{
  public class ArticlesController : Controller
  {
    private readonly IContentService _contentService;
    private readonly ICommentService _commentService;
    private readonly IHandleOffensiveWords _textEditOffensiveWords;

    public ArticlesController(IContentService contentService, ICommentService commentService, RemoveOffensiveWords textEditOffensiveWords)
    {
      _contentService = contentService ?? throw new ArgumentNullException(nameof(contentService));
      _commentService = commentService ?? throw new ArgumentNullException(nameof(commentService));
      _textEditOffensiveWords = textEditOffensiveWords ?? throw new ArgumentNullException(nameof(textEditOffensiveWords));
    }
    public ViewResult BlogPost()
    {
      var viewModel = new BlogPostViewModel();
      if (!String.IsNullOrEmpty(
        RenderingContext.Current.Rendering.DataSource))
      {
        var blogContent = _contentService.GetArticleContent(RenderingContext.Current.Rendering.DataSource);
        if (blogContent != null)
        {
          viewModel.Title = _textEditOffensiveWords.Handle(blogContent.Title); // blogContent.Title;
          viewModel.Body = _textEditOffensiveWords.Handle(blogContent.Body); //blogContent.Body;

          var comments = _commentService.GetComments(blogContent.Id.ToString());
          if (comments != null)
          {
            foreach (var comment in comments)
            {
              viewModel.Comments.Add(new BlogCommentViewModel()
              {
                Name = comment.Name,
                Comment = _textEditOffensiveWords.Handle(comment.Comment),
                DatePosted = comment.DatePosted
              });
            }
          }
        }
      }
      return View(viewModel);
    }
  }
}