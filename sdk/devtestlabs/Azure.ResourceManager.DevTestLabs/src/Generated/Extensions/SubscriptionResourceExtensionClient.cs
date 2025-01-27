// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.DevTestLabs
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    internal partial class SubscriptionResourceExtensionClient : ArmResource
    {
        private ClientDiagnostics _devTestLabLabsClientDiagnostics;
        private LabsRestOperations _devTestLabLabsRestClient;
        private ClientDiagnostics _devTestLabGlobalScheduleGlobalSchedulesClientDiagnostics;
        private GlobalSchedulesRestOperations _devTestLabGlobalScheduleGlobalSchedulesRestClient;

        /// <summary> Initializes a new instance of the <see cref="SubscriptionResourceExtensionClient"/> class for mocking. </summary>
        protected SubscriptionResourceExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SubscriptionResourceExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SubscriptionResourceExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics DevTestLabLabsClientDiagnostics => _devTestLabLabsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.DevTestLabs", DevTestLabResource.ResourceType.Namespace, Diagnostics);
        private LabsRestOperations DevTestLabLabsRestClient => _devTestLabLabsRestClient ??= new LabsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(DevTestLabResource.ResourceType));
        private ClientDiagnostics DevTestLabGlobalScheduleGlobalSchedulesClientDiagnostics => _devTestLabGlobalScheduleGlobalSchedulesClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.DevTestLabs", DevTestLabGlobalScheduleResource.ResourceType.Namespace, Diagnostics);
        private GlobalSchedulesRestOperations DevTestLabGlobalScheduleGlobalSchedulesRestClient => _devTestLabGlobalScheduleGlobalSchedulesRestClient ??= new GlobalSchedulesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(DevTestLabGlobalScheduleResource.ResourceType));

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary>
        /// List labs in a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.DevTestLab/labs
        /// Operation Id: Labs_ListBySubscription
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($select=defaultStorageAccount)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DevTestLabResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DevTestLabResource> GetDevTestLabsAsync(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<DevTestLabResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = DevTestLabLabsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetDevTestLabs");
                scope.Start();
                try
                {
                    var response = await DevTestLabLabsRestClient.ListBySubscriptionAsync(Id.SubscriptionId, expand, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DevTestLabResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = DevTestLabLabsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetDevTestLabs");
                scope.Start();
                try
                {
                    var response = await DevTestLabLabsRestClient.ListBySubscriptionNextPageAsync(nextLink, Id.SubscriptionId, expand, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// List labs in a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.DevTestLab/labs
        /// Operation Id: Labs_ListBySubscription
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($select=defaultStorageAccount)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DevTestLabResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DevTestLabResource> GetDevTestLabs(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            Page<DevTestLabResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = DevTestLabLabsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetDevTestLabs");
                scope.Start();
                try
                {
                    var response = DevTestLabLabsRestClient.ListBySubscription(Id.SubscriptionId, expand, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DevTestLabResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = DevTestLabLabsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetDevTestLabs");
                scope.Start();
                try
                {
                    var response = DevTestLabLabsRestClient.ListBySubscriptionNextPage(nextLink, Id.SubscriptionId, expand, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// List schedules in a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.DevTestLab/schedules
        /// Operation Id: GlobalSchedules_ListBySubscription
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($select=status)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DevTestLabGlobalScheduleResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DevTestLabGlobalScheduleResource> GetDevTestLabGlobalSchedulesAsync(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<DevTestLabGlobalScheduleResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = DevTestLabGlobalScheduleGlobalSchedulesClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetDevTestLabGlobalSchedules");
                scope.Start();
                try
                {
                    var response = await DevTestLabGlobalScheduleGlobalSchedulesRestClient.ListBySubscriptionAsync(Id.SubscriptionId, expand, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabGlobalScheduleResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DevTestLabGlobalScheduleResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = DevTestLabGlobalScheduleGlobalSchedulesClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetDevTestLabGlobalSchedules");
                scope.Start();
                try
                {
                    var response = await DevTestLabGlobalScheduleGlobalSchedulesRestClient.ListBySubscriptionNextPageAsync(nextLink, Id.SubscriptionId, expand, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabGlobalScheduleResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// List schedules in a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.DevTestLab/schedules
        /// Operation Id: GlobalSchedules_ListBySubscription
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($select=status)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DevTestLabGlobalScheduleResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DevTestLabGlobalScheduleResource> GetDevTestLabGlobalSchedules(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            Page<DevTestLabGlobalScheduleResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = DevTestLabGlobalScheduleGlobalSchedulesClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetDevTestLabGlobalSchedules");
                scope.Start();
                try
                {
                    var response = DevTestLabGlobalScheduleGlobalSchedulesRestClient.ListBySubscription(Id.SubscriptionId, expand, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabGlobalScheduleResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DevTestLabGlobalScheduleResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = DevTestLabGlobalScheduleGlobalSchedulesClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetDevTestLabGlobalSchedules");
                scope.Start();
                try
                {
                    var response = DevTestLabGlobalScheduleGlobalSchedulesRestClient.ListBySubscriptionNextPage(nextLink, Id.SubscriptionId, expand, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabGlobalScheduleResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
