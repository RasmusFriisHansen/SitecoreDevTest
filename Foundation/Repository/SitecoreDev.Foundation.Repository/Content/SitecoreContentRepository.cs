using System;
using Glass.Mapper.Sc;
using Sitecore.Diagnostics;
using SitecoreDev.Foundation.Model;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Data;

namespace SitecoreDev.Foundation.Repository.Content
{
    public class SitecoreContentRepository : IContentRepository
    {
        private readonly ISitecoreContext _sitecoreContext;

        public SitecoreContentRepository()
        {
            _sitecoreContext = new SitecoreContext();
        }
        public virtual T GetContentItem<T>(string contentGuid) where T : class,
          ICmsEntity
        {
            Assert.ArgumentNotNullOrEmpty(contentGuid, "contentGuid");
            return _sitecoreContext.GetItem<T>(Guid.Parse(contentGuid));
        }

        public virtual IEnumerable<T> GetChildren<T>(string parentGuid) where T : class, ICmsEntity
        {
            Assert.ArgumentNotNullOrEmpty(parentGuid, "parentGuid");
            var parentItem = _sitecoreContext.Database.GetItem(ID.Parse(parentGuid));
            var childrenItems = parentItem.GetChildren();
            if (childrenItems == null || childrenItems.Count == 0)
                return Enumerable.Empty<T>();
            else
                return childrenItems.Select(c => _sitecoreContext.Cast<T>(c));
        }
    }
}