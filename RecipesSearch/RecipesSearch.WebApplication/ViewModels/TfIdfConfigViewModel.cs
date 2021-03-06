﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RecipesSearch.Data.Models;
using RecipesSearch.SearchEngine.Clusters.Base;
using System;

namespace RecipesSearch.WebApplication.ViewModels
{
    public class TfIdfConfigViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [Display(Name = "Tf builder to use")]
        public string TfBuilderName { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [Display(Name = "Idf builder to use")]
        public string IdfBuilderName { get; set; }

        [Display(Name = "Last used Tf builder")]
        public string LastUsedTfBuilder { get; set; }

        [Display(Name = "Last used Idf builder")]
        public string LastUsedIdfBuilder { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Must be a natural number")]
        [Display(Name = "Count of nearest results to find")]
        public int SimilarResultsCount { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [Display(Name = "Use recipes from the same category only.")]
        public bool SimilarResultsSameCategoryOnly { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [Display(Name = "Clustering method")]
        public string ClustersBuilder { get; set; }

        [Display(Name = "Clustering options (<key>: <value>)")]
        public string ClusteringParameters { get; set; }

        public List<string> AvailableTfBuilders { get; set; }

        public List<string> AvailableIdfBuilders { get; set; }

        public List<string> AvailableClustersBuilders { get; set; }

        public static TfIdfConfig GetEntity(TfIdfConfigViewModel viewModel)
        {
            return new TfIdfConfig
            {
                Id = viewModel.Id,
                TfBuilderName = viewModel.TfBuilderName,
                IdfBuilderName = viewModel.IdfBuilderName,
                LastUsedIdfBuilder = viewModel.LastUsedIdfBuilder,
                LastUsedTfBuilder = viewModel.LastUsedTfBuilder,
                SimilarResultsCount = viewModel.SimilarResultsCount,
                SimilarResultsSameCategoryOnly = viewModel.SimilarResultsSameCategoryOnly,
                ClustersBuilder = (int)Enum.Parse(typeof(ClusterBuilders), viewModel.ClustersBuilder),
                ClusteringParameters = viewModel.ClusteringParameters
            };
        }

        public static TfIdfConfigViewModel GetViewModel(
            TfIdfConfig entity, 
            List<string> availableTfBuilders,
            List<string> availableIdfBuilders,
            List<string> availableClustersBuilder)
        {
            return new TfIdfConfigViewModel
            {
                Id = entity.Id,
                TfBuilderName = entity.TfBuilderName,
                IdfBuilderName = entity.IdfBuilderName,
                LastUsedIdfBuilder = entity.LastUsedIdfBuilder,
                LastUsedTfBuilder = entity.LastUsedTfBuilder,
                AvailableTfBuilders = availableTfBuilders,
                AvailableIdfBuilders = availableIdfBuilders,
                SimilarResultsCount = entity.SimilarResultsCount,
                SimilarResultsSameCategoryOnly = entity.SimilarResultsSameCategoryOnly,
                ClustersBuilder = ((ClusterBuilders)entity.ClustersBuilder).ToString(),
                ClusteringParameters = entity.ClusteringParameters,
                AvailableClustersBuilders = availableClustersBuilder
            };
        }
    }
}
