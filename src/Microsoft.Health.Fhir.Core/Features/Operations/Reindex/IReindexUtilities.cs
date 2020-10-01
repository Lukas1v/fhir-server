﻿// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Health.Fhir.Core.Features.Search;

namespace Microsoft.Health.Fhir.Core.Features.Operations.Reindex
{
    public interface IReindexUtilities
    {
        /// <summary>
        /// For each result in a batch of resources this will extract new search params
        /// Then compare those to the old values to determine if an update is needed
        /// Needed updates will be committed in a batch
        /// </summary>
        /// <param name="results">The resource batch to process</param>
        /// <param name="searchParamHash">the current hash value of the search parameters</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A Task</returns>
        Task ProcessSearchResultsAsync(SearchResult results, string searchParamHash, CancellationToken cancellationToken);

        /// <summary>
        /// Sets the search parameters to enabled when a reindex job successfully completes
        /// </summary>
        /// <param name="searchParameterUris">The list of search parameter Uris</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>true if successfull, or false with error message is unsuccessfull</returns>
        Task<(bool, string)> UpdateSearchParameters(IReadOnlyCollection<string> searchParameterUris, CancellationToken cancellationToken);
    }
}
