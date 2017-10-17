using System;
using System.Collections.Generic;
using SitecoreDev.Feature.Articles.Models;

namespace SitecoreDev.Feature.Articles.Repositories
{
  public class FakeBlogCommentRepository : ICommentRepository
  {
    public IEnumerable<IComment> GetComments(string blogId)
    {
      var comments = new List<IComment>();
      comments.Add(new BlogComment()
      {
        Name = "Jack",
        Comment = "Haha, you are a funny guy writing that much about her butt!",
        DatePosted = DateTime.Parse("05/12/2016")
      });
      comments.Add(new BlogComment()
      {
        Name = "Jane",
        Comment = "Stop writing so much about her ass, thats not nice. You should not give her that much compliments about the ass!",
        DatePosted = DateTime.Parse("03/12/2016")
      });
      return comments;
    }
  }
}