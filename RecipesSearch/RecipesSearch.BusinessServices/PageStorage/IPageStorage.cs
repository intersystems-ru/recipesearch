﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipesSearch.Data.Models;
using RecipesSearch.Data.Views;

namespace RecipesSearch.BusinessServices.PageStorage
{
    public interface IPageStorage : IDisposable
    {
        bool SaveSitePage(
            SitePage sitePage,
            bool processKeywords,
            int extendedKeywordsMinWordCount,
            bool extendedKeywordsUseFilter,
            bool updateSpellcheckDict,
            bool buildTf,
            string tfBuilderName);

        List<SiteInfo> GetSitesInfo();

        bool DeletePages(int siteId);

        bool DeletePages();
    }
}
