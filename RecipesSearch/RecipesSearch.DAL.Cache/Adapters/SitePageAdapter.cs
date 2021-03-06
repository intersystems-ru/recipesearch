﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using InterSystems.Data.CacheClient;
using RecipesSearch.DAL.Cache.Adapters.Base;
using RecipesSearch.DAL.Cache.Utilities;
using RecipesSearch.Data.Models;
using RecipesSearch.Data.Views;

namespace RecipesSearch.DAL.Cache.Adapters
{
    public class SitePageAdapter : CacheAdapter
    {
        public bool AddSitePage(
            SitePage sitePage, 
            bool enableKeywordsProcessing,
            int extendedKeywordsMinWordCount,
            bool extendedKeywordsUseFilter,
            bool updateSpellcheckDict,
            bool buildTf, 
            string tfBuilderName)
        {
            EnsureConnectionOpened();

            var command = new CacheCommand(GetFullProcedureName("SitePage_Upsert"), CacheConnection);
            command.CommandType = CommandType.StoredProcedure;

            // !!!Order is important
            // It must match order of the parameters in the Cache sproc

            command.Parameters.Add("URL", sitePage.URL);
            command.Parameters.Add("Keywords", sitePage.Keywords); 
            command.Parameters.Add("RecipeName", sitePage.RecipeName);
            command.Parameters.Add("Description", sitePage.Description ?? String.Empty);
            command.Parameters.Add("Ingredients", sitePage.Ingredients);
            command.Parameters.Add("RecipeInstructions", sitePage.RecipeInstructions);
            command.Parameters.Add("AdditionalData", sitePage.AdditionalData ?? String.Empty);
            command.Parameters.Add("ImageUrl", sitePage.ImageUrl ?? String.Empty);
            command.Parameters.Add("Category", sitePage.Category ?? String.Empty);
            command.Parameters.Add("Rating", sitePage.Rating);
            command.Parameters.Add("CommentsCount", sitePage.CommentsCount);

            var siteIdParemeter = new CacheParameter("SiteId", CacheDbType.Int);
            siteIdParemeter.Value = sitePage.SiteID;
            command.Parameters.Add(siteIdParemeter);

            var processKeywordsParemeter = new CacheParameter("ProcessKeywords", CacheDbType.Bit);
            processKeywordsParemeter.Value = enableKeywordsProcessing;
            command.Parameters.Add(processKeywordsParemeter);

            var updateSpellcheckDictParameter = new CacheParameter("UpdateSpellcheckDict", CacheDbType.Bit);
            updateSpellcheckDictParameter.Value = updateSpellcheckDict;
            command.Parameters.Add(updateSpellcheckDictParameter);

            var buildTfParameter = new CacheParameter("BuildTf", CacheDbType.Bit);
            buildTfParameter.Value = buildTf;
            command.Parameters.Add(buildTfParameter);
 
            command.Parameters.Add("TfBuilderName", tfBuilderName);

            command.Parameters.Add("ExtendedKeywordsMinWordCount", extendedKeywordsMinWordCount);

            var userFilterParameter = new CacheParameter("ExtendedKeywordsUseFilter", CacheDbType.Bit);
            userFilterParameter.Value = extendedKeywordsUseFilter;
            command.Parameters.Add(userFilterParameter);

            return command.ExecuteNonQuery() != 0;
        }

        public List<SiteInfo> GetSitesInfo()
        {
            var command = new CacheCommand(GetFullProcedureName("SitePage_GetRecordsBySiteId"), CacheConnection);
            command.CommandType = CommandType.StoredProcedure;

            var dataReader = command.ExecuteReader();

            var sitesInfo = ObjectMapper.Map<SiteInfo>(dataReader);

            return sitesInfo;
        }

        public bool DeleteSiteRecords(int siteId)
        {
            var command = new CacheCommand(GetFullProcedureName("SitePage_DeleteRecordsForSiteId"), CacheConnection);
            command.CommandType = CommandType.StoredProcedure;

            var parameters = ParametersBuilder.BuildParametersFromObject(new { SiteId = siteId });
            AddSqlParameters(command, parameters);

            return command.ExecuteNonQuery() != 0;
        }

        public bool DeleteSitesRecords()
        {
            var command = new CacheCommand(GetFullProcedureName("SitePage_DeleteSitesRecords"), CacheConnection);
            command.CommandType = CommandType.StoredProcedure;

            return command.ExecuteNonQuery() != 0;
        }
    }
}
