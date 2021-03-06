﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipesSearch.BusinessServices.Logging;
using RecipesSearch.BusinessServices.SqlRepositories.Base;
using RecipesSearch.DAL.Cache.Adapters;

namespace RecipesSearch.BusinessServices.SqlRepositories
{
    public class PageStatsRepository : SqlRepositoryBase
    {
        public int GetTfIdfStatistic()
        {
            try
            {
                using (var cacheAdapter = new TfIdfAdapter())
                {
                    return cacheAdapter.GetTfIdfStatistic();
                }
            }
            catch (Exception exception)
            {
                LoggerWrapper.LogError("PageStatsRepository.GetTfIdfStatistic() failed", exception);
                return -1;
            }
        }

        public int GetTfStatistic()
        {
            try
            {
                using (var cacheAdapter = new TfIdfAdapter())
                {
                    return cacheAdapter.GetTfStatistic();
                }
            }
            catch (Exception exception)
            {
                LoggerWrapper.LogError("PageStatsRepository.GetTfStatistic() failed", exception);
                return -1;
            }
        }

        public int GetIdfStatistic()
        {
            try
            {
                using (var cacheAdapter = new TfIdfAdapter())
                {
                    return cacheAdapter.GetIdfStatistic();
                }
            }
            catch (Exception exception)
            {
                LoggerWrapper.LogError("PageStatsRepository.GetIdfStatistic() failed", exception);
                return -1;
            }
        }

        public int GetCountOfRecipesWithEmptyClusters()
        {
            try
            {
                using (var cacheAdapter = new TfIdfAdapter())
                {
                    return cacheAdapter.GetCountOfRecipesWithEmptyCLusters();
                }
            }
            catch (Exception exception)
            {
                LoggerWrapper.LogError("PageStatsRepository.GetCountOfRecipesWithEmptyClusters() failed", exception);
                return -1;
            }
        }

        public int GetNearestResultsStatistic()
        {
            try
            {
                using (var cacheAdapter = new SimilarResultsAdapter())
                {
                    return cacheAdapter.GetNearestResultsStatistic();
                }
            }
            catch (Exception exception)
            {
                LoggerWrapper.LogError("PageStatsRepository.GetNearestResultsStatistic() failed", exception);
                return -1;
            }
        }
    }
}
