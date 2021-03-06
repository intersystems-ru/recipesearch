﻿using RecipesSearch.Data.Framework;
using RecipesSearch.Data.Models.Base;

namespace RecipesSearch.Data.Models
{
    [CachePackage(Constants.DefaultCachePackage)]
    public class SearchSettings : Entity
    {
        public int ResultsOnPage { get; set; }

        public int SuggestionsCount { get; set; }

        public int ResultsForGraphView { get; set; }

        public int DefaultResultsView { get; set; }

        public bool EnableSpellchecking { get; set; }

        public bool EnableSpellcheckingForSuggest { get; set; }

        public bool OnlineTfIdfEnabled { get; set; }

        public bool UseClusters { get; set; }

        public bool SkipIrrelevantResults { get; set; }

        public bool FilterSearchQuery { get; set; }

        public int MaxOnlineIdfRecipesCount { get; set; }

        public string OnlineTfIdfBuilderName { get; set; }

        public int OnlineTfIdfSimilarResultsCount { get; set; }

        public bool SeparateClustersOnGraphView { get; set; }

        public bool OnlySearchResultsWhenUsingClusters { get; set; }

        public bool UseCache { get; set; }

        public int CacheTimeout { get; set; }
    }
}
