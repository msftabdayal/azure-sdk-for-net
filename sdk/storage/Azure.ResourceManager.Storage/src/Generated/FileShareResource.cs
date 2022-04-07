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
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    /// <summary>
    /// A Class representing a FileShare along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="FileShareResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetFileShareResource method.
    /// Otherwise you can get one from its parent resource <see cref="FileServiceResource" /> using the GetFileShare method.
    /// </summary>
    public partial class FileShareResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="FileShareResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string shareName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/default/shares/{shareName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _fileShareClientDiagnostics;
        private readonly FileSharesRestOperations _fileShareRestClient;
        private readonly FileShareData _data;

        /// <summary> Initializes a new instance of the <see cref="FileShareResource"/> class for mocking. </summary>
        protected FileShareResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "FileShareResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal FileShareResource(ArmClient client, FileShareData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="FileShareResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal FileShareResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _fileShareClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Storage", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string fileShareApiVersion);
            _fileShareRestClient = new FileSharesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, fileShareApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Storage/storageAccounts/fileServices/shares";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual FileShareData Data
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

        /// <summary>
        /// Gets properties of a specified share.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/default/shares/{shareName}
        /// Operation Id: FileShares_Get
        /// </summary>
        /// <param name="expand"> Optional, used to expand the properties within share&apos;s properties. Valid values are: stats. Should be passed as a string with delimiter &apos;,&apos;. </param>
        /// <param name="xMsSnapshot"> Optional, used to retrieve properties of a snapshot. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<FileShareResource>> GetAsync(string expand = null, string xMsSnapshot = null, CancellationToken cancellationToken = default)
        {
            using var scope = _fileShareClientDiagnostics.CreateScope("FileShareResource.Get");
            scope.Start();
            try
            {
                var response = await _fileShareRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Name, expand, xMsSnapshot, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FileShareResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets properties of a specified share.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/default/shares/{shareName}
        /// Operation Id: FileShares_Get
        /// </summary>
        /// <param name="expand"> Optional, used to expand the properties within share&apos;s properties. Valid values are: stats. Should be passed as a string with delimiter &apos;,&apos;. </param>
        /// <param name="xMsSnapshot"> Optional, used to retrieve properties of a snapshot. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<FileShareResource> Get(string expand = null, string xMsSnapshot = null, CancellationToken cancellationToken = default)
        {
            using var scope = _fileShareClientDiagnostics.CreateScope("FileShareResource.Get");
            scope.Start();
            try
            {
                var response = _fileShareRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Name, expand, xMsSnapshot, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FileShareResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes specified share under its account.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/default/shares/{shareName}
        /// Operation Id: FileShares_Delete
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="xMsSnapshot"> Optional, used to delete a snapshot. </param>
        /// <param name="include"> Optional. Valid values are: snapshots, leased-snapshots, none. The default value is snapshots. For &apos;snapshots&apos;, the file share is deleted including all of its file share snapshots. If the file share contains leased-snapshots, the deletion fails. For &apos;leased-snapshots&apos;, the file share is deleted included all of its file share snapshots (leased/unleased). For &apos;none&apos;, the file share is deleted if it has no share snapshots. If the file share contains any snapshots (leased or unleased), the deletion fails. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, string xMsSnapshot = null, string include = null, CancellationToken cancellationToken = default)
        {
            using var scope = _fileShareClientDiagnostics.CreateScope("FileShareResource.Delete");
            scope.Start();
            try
            {
                var response = await _fileShareRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Name, xMsSnapshot, include, cancellationToken).ConfigureAwait(false);
                var operation = new StorageArmOperation(response);
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
        /// Deletes specified share under its account.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/default/shares/{shareName}
        /// Operation Id: FileShares_Delete
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="xMsSnapshot"> Optional, used to delete a snapshot. </param>
        /// <param name="include"> Optional. Valid values are: snapshots, leased-snapshots, none. The default value is snapshots. For &apos;snapshots&apos;, the file share is deleted including all of its file share snapshots. If the file share contains leased-snapshots, the deletion fails. For &apos;leased-snapshots&apos;, the file share is deleted included all of its file share snapshots (leased/unleased). For &apos;none&apos;, the file share is deleted if it has no share snapshots. If the file share contains any snapshots (leased or unleased), the deletion fails. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, string xMsSnapshot = null, string include = null, CancellationToken cancellationToken = default)
        {
            using var scope = _fileShareClientDiagnostics.CreateScope("FileShareResource.Delete");
            scope.Start();
            try
            {
                var response = _fileShareRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Name, xMsSnapshot, include, cancellationToken);
                var operation = new StorageArmOperation(response);
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
        /// Updates share properties as specified in request body. Properties not mentioned in the request will not be changed. Update fails if the specified share does not already exist. 
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/default/shares/{shareName}
        /// Operation Id: FileShares_Update
        /// </summary>
        /// <param name="data"> Properties to update for the file share. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<Response<FileShareResource>> UpdateAsync(FileShareData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _fileShareClientDiagnostics.CreateScope("FileShareResource.Update");
            scope.Start();
            try
            {
                var response = await _fileShareRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Name, data, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new FileShareResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates share properties as specified in request body. Properties not mentioned in the request will not be changed. Update fails if the specified share does not already exist. 
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/default/shares/{shareName}
        /// Operation Id: FileShares_Update
        /// </summary>
        /// <param name="data"> Properties to update for the file share. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual Response<FileShareResource> Update(FileShareData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _fileShareClientDiagnostics.CreateScope("FileShareResource.Update");
            scope.Start();
            try
            {
                var response = _fileShareRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Name, data, cancellationToken);
                return Response.FromValue(new FileShareResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Restore a file share within a valid retention days if share soft delete is enabled
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/default/shares/{shareName}/restore
        /// Operation Id: FileShares_Restore
        /// </summary>
        /// <param name="deletedShare"> The DeletedShare to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="deletedShare"/> is null. </exception>
        public virtual async Task<Response> RestoreAsync(DeletedShare deletedShare, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(deletedShare, nameof(deletedShare));

            using var scope = _fileShareClientDiagnostics.CreateScope("FileShareResource.Restore");
            scope.Start();
            try
            {
                var response = await _fileShareRestClient.RestoreAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Name, deletedShare, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Restore a file share within a valid retention days if share soft delete is enabled
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/default/shares/{shareName}/restore
        /// Operation Id: FileShares_Restore
        /// </summary>
        /// <param name="deletedShare"> The DeletedShare to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="deletedShare"/> is null. </exception>
        public virtual Response Restore(DeletedShare deletedShare, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(deletedShare, nameof(deletedShare));

            using var scope = _fileShareClientDiagnostics.CreateScope("FileShareResource.Restore");
            scope.Start();
            try
            {
                var response = _fileShareRestClient.Restore(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Name, deletedShare, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The Lease Share operation establishes and manages a lock on a share for delete operations. The lock duration can be 15 to 60 seconds, or can be infinite.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/default/shares/{shareName}/lease
        /// Operation Id: FileShares_Lease
        /// </summary>
        /// <param name="parameters"> Lease Share request body. </param>
        /// <param name="xMsSnapshot"> Optional. Specify the snapshot time to lease a snapshot. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<LeaseShareResponse>> LeaseAsync(LeaseShareRequest parameters = null, string xMsSnapshot = null, CancellationToken cancellationToken = default)
        {
            using var scope = _fileShareClientDiagnostics.CreateScope("FileShareResource.Lease");
            scope.Start();
            try
            {
                var response = await _fileShareRestClient.LeaseAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Name, parameters, xMsSnapshot, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The Lease Share operation establishes and manages a lock on a share for delete operations. The lock duration can be 15 to 60 seconds, or can be infinite.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/default/shares/{shareName}/lease
        /// Operation Id: FileShares_Lease
        /// </summary>
        /// <param name="parameters"> Lease Share request body. </param>
        /// <param name="xMsSnapshot"> Optional. Specify the snapshot time to lease a snapshot. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<LeaseShareResponse> Lease(LeaseShareRequest parameters = null, string xMsSnapshot = null, CancellationToken cancellationToken = default)
        {
            using var scope = _fileShareClientDiagnostics.CreateScope("FileShareResource.Lease");
            scope.Start();
            try
            {
                var response = _fileShareRestClient.Lease(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Name, parameters, xMsSnapshot, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
