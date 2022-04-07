// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Cdn.Models;

namespace Azure.ResourceManager.Cdn
{
    /// <summary>
    /// A Class representing an AfdRuleSet along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct an <see cref="AfdRuleSetResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetAfdRuleSetResource method.
    /// Otherwise you can get one from its parent resource <see cref="ProfileResource" /> using the GetAfdRuleSet method.
    /// </summary>
    public partial class AfdRuleSetResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="AfdRuleSetResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string ruleSetName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/ruleSets/{ruleSetName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _afdRuleSetClientDiagnostics;
        private readonly AfdRuleSetsRestOperations _afdRuleSetRestClient;
        private readonly AfdRuleSetData _data;

        /// <summary> Initializes a new instance of the <see cref="AfdRuleSetResource"/> class for mocking. </summary>
        protected AfdRuleSetResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "AfdRuleSetResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal AfdRuleSetResource(ArmClient client, AfdRuleSetData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="AfdRuleSetResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal AfdRuleSetResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _afdRuleSetClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Cdn", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string afdRuleSetApiVersion);
            _afdRuleSetRestClient = new AfdRuleSetsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, afdRuleSetApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly Core.ResourceType ResourceType = "Microsoft.Cdn/profiles/ruleSets";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual AfdRuleSetData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary> Gets a collection of AfdRuleResources in the AfdRuleSet. </summary>
        /// <returns> An object representing collection of AfdRuleResources and their operations over a AfdRuleResource. </returns>
        public virtual AfdRuleCollection GetAfdRules()
        {
            return GetCachedClient(Client => new AfdRuleCollection(Client, Id));
        }

        /// <summary>
        /// Gets an existing delivery rule within a rule set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/ruleSets/{ruleSetName}/rules/{ruleName}
        /// Operation Id: AfdRules_Get
        /// </summary>
        /// <param name="ruleName"> Name of the delivery rule which is unique within the endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<AfdRuleResource>> GetAfdRuleAsync(string ruleName, CancellationToken cancellationToken = default)
        {
            return await GetAfdRules().GetAsync(ruleName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets an existing delivery rule within a rule set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/ruleSets/{ruleSetName}/rules/{ruleName}
        /// Operation Id: AfdRules_Get
        /// </summary>
        /// <param name="ruleName"> Name of the delivery rule which is unique within the endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<AfdRuleResource> GetAfdRule(string ruleName, CancellationToken cancellationToken = default)
        {
            return GetAfdRules().Get(ruleName, cancellationToken);
        }

        /// <summary>
        /// Gets an existing AzureFrontDoor rule set with the specified rule set name under the specified subscription, resource group and profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/ruleSets/{ruleSetName}
        /// Operation Id: AfdRuleSets_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<AfdRuleSetResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _afdRuleSetClientDiagnostics.CreateScope("AfdRuleSetResource.Get");
            scope.Start();
            try
            {
                var response = await _afdRuleSetRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AfdRuleSetResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets an existing AzureFrontDoor rule set with the specified rule set name under the specified subscription, resource group and profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/ruleSets/{ruleSetName}
        /// Operation Id: AfdRuleSets_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AfdRuleSetResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _afdRuleSetClientDiagnostics.CreateScope("AfdRuleSetResource.Get");
            scope.Start();
            try
            {
                var response = _afdRuleSetRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AfdRuleSetResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes an existing AzureFrontDoor rule set with the specified rule set name under the specified subscription, resource group and profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/ruleSets/{ruleSetName}
        /// Operation Id: AfdRuleSets_Delete
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _afdRuleSetClientDiagnostics.CreateScope("AfdRuleSetResource.Delete");
            scope.Start();
            try
            {
                var response = await _afdRuleSetRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new CdnArmOperation(_afdRuleSetClientDiagnostics, Pipeline, _afdRuleSetRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes an existing AzureFrontDoor rule set with the specified rule set name under the specified subscription, resource group and profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/ruleSets/{ruleSetName}
        /// Operation Id: AfdRuleSets_Delete
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _afdRuleSetClientDiagnostics.CreateScope("AfdRuleSetResource.Delete");
            scope.Start();
            try
            {
                var response = _afdRuleSetRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new CdnArmOperation(_afdRuleSetClientDiagnostics, Pipeline, _afdRuleSetRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks the quota and actual usage of endpoints under the given CDN profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/ruleSets/{ruleSetName}/usages
        /// Operation Id: AfdRuleSets_ListResourceUsage
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="CdnUsage" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<CdnUsage> GetResourceUsageAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<CdnUsage>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _afdRuleSetClientDiagnostics.CreateScope("AfdRuleSetResource.GetResourceUsage");
                scope.Start();
                try
                {
                    var response = await _afdRuleSetRestClient.ListResourceUsageAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<CdnUsage>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _afdRuleSetClientDiagnostics.CreateScope("AfdRuleSetResource.GetResourceUsage");
                scope.Start();
                try
                {
                    var response = await _afdRuleSetRestClient.ListResourceUsageNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
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
        /// Checks the quota and actual usage of endpoints under the given CDN profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/ruleSets/{ruleSetName}/usages
        /// Operation Id: AfdRuleSets_ListResourceUsage
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="CdnUsage" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<CdnUsage> GetResourceUsage(CancellationToken cancellationToken = default)
        {
            Page<CdnUsage> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _afdRuleSetClientDiagnostics.CreateScope("AfdRuleSetResource.GetResourceUsage");
                scope.Start();
                try
                {
                    var response = _afdRuleSetRestClient.ListResourceUsage(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<CdnUsage> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _afdRuleSetClientDiagnostics.CreateScope("AfdRuleSetResource.GetResourceUsage");
                scope.Start();
                try
                {
                    var response = _afdRuleSetRestClient.ListResourceUsageNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
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
