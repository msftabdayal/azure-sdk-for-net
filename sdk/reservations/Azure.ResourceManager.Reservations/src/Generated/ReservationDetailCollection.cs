// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Reservations
{
    /// <summary>
    /// A class representing a collection of <see cref="ReservationDetailResource" /> and their operations.
    /// Each <see cref="ReservationDetailResource" /> in the collection will belong to the same instance of <see cref="ReservationOrderResource" />.
    /// To get a <see cref="ReservationDetailCollection" /> instance call the GetReservationDetails method from an instance of <see cref="ReservationOrderResource" />.
    /// </summary>
    public partial class ReservationDetailCollection : ArmCollection, IEnumerable<ReservationDetailResource>, IAsyncEnumerable<ReservationDetailResource>
    {
        private readonly ClientDiagnostics _reservationDetailReservationClientDiagnostics;
        private readonly ReservationRestOperations _reservationDetailReservationRestClient;

        /// <summary> Initializes a new instance of the <see cref="ReservationDetailCollection"/> class for mocking. </summary>
        protected ReservationDetailCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ReservationDetailCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ReservationDetailCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _reservationDetailReservationClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Reservations", ReservationDetailResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ReservationDetailResource.ResourceType, out string reservationDetailReservationApiVersion);
            _reservationDetailReservationRestClient = new ReservationRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, reservationDetailReservationApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ReservationOrderResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ReservationOrderResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Get specific `Reservation` details.
        /// Request Path: /providers/Microsoft.Capacity/reservationOrders/{reservationOrderId}/reservations/{reservationId}
        /// Operation Id: Reservation_Get
        /// </summary>
        /// <param name="reservationId"> Id of the Reservation Item. </param>
        /// <param name="expand"> Supported value of this query is renewProperties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ReservationDetailResource>> GetAsync(Guid reservationId, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _reservationDetailReservationClientDiagnostics.CreateScope("ReservationDetailCollection.Get");
            scope.Start();
            try
            {
                var response = await _reservationDetailReservationRestClient.GetAsync(Guid.Parse(Id.Name), reservationId, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ReservationDetailResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get specific `Reservation` details.
        /// Request Path: /providers/Microsoft.Capacity/reservationOrders/{reservationOrderId}/reservations/{reservationId}
        /// Operation Id: Reservation_Get
        /// </summary>
        /// <param name="reservationId"> Id of the Reservation Item. </param>
        /// <param name="expand"> Supported value of this query is renewProperties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ReservationDetailResource> Get(Guid reservationId, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _reservationDetailReservationClientDiagnostics.CreateScope("ReservationDetailCollection.Get");
            scope.Start();
            try
            {
                var response = _reservationDetailReservationRestClient.Get(Guid.Parse(Id.Name), reservationId, expand, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ReservationDetailResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List `Reservation`s within a single `ReservationOrder`.
        /// Request Path: /providers/Microsoft.Capacity/reservationOrders/{reservationOrderId}/reservations
        /// Operation Id: Reservation_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ReservationDetailResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ReservationDetailResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ReservationDetailResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _reservationDetailReservationClientDiagnostics.CreateScope("ReservationDetailCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _reservationDetailReservationRestClient.ListAsync(Guid.Parse(Id.Name), cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ReservationDetailResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ReservationDetailResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _reservationDetailReservationClientDiagnostics.CreateScope("ReservationDetailCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _reservationDetailReservationRestClient.ListNextPageAsync(nextLink, Guid.Parse(Id.Name), cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ReservationDetailResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// List `Reservation`s within a single `ReservationOrder`.
        /// Request Path: /providers/Microsoft.Capacity/reservationOrders/{reservationOrderId}/reservations
        /// Operation Id: Reservation_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ReservationDetailResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ReservationDetailResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ReservationDetailResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _reservationDetailReservationClientDiagnostics.CreateScope("ReservationDetailCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _reservationDetailReservationRestClient.List(Guid.Parse(Id.Name), cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ReservationDetailResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ReservationDetailResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _reservationDetailReservationClientDiagnostics.CreateScope("ReservationDetailCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _reservationDetailReservationRestClient.ListNextPage(nextLink, Guid.Parse(Id.Name), cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ReservationDetailResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// List of all the revisions for the `Reservation`.
        /// Request Path: /providers/Microsoft.Capacity/reservationOrders/{reservationOrderId}/reservations/{reservationId}/revisions
        /// Operation Id: Reservation_ListRevisions
        /// </summary>
        /// <param name="reservationId"> Id of the Reservation Item. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ReservationDetailResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ReservationDetailResource> GetRevisionsAsync(Guid reservationId, CancellationToken cancellationToken = default)
        {
            async Task<Page<ReservationDetailResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _reservationDetailReservationClientDiagnostics.CreateScope("ReservationDetailCollection.GetRevisions");
                scope.Start();
                try
                {
                    var response = await _reservationDetailReservationRestClient.ListRevisionsAsync(Guid.Parse(Id.Name), reservationId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ReservationDetailResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ReservationDetailResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _reservationDetailReservationClientDiagnostics.CreateScope("ReservationDetailCollection.GetRevisions");
                scope.Start();
                try
                {
                    var response = await _reservationDetailReservationRestClient.ListRevisionsNextPageAsync(nextLink, Guid.Parse(Id.Name), reservationId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ReservationDetailResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// List of all the revisions for the `Reservation`.
        /// Request Path: /providers/Microsoft.Capacity/reservationOrders/{reservationOrderId}/reservations/{reservationId}/revisions
        /// Operation Id: Reservation_ListRevisions
        /// </summary>
        /// <param name="reservationId"> Id of the Reservation Item. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ReservationDetailResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ReservationDetailResource> GetRevisions(Guid reservationId, CancellationToken cancellationToken = default)
        {
            Page<ReservationDetailResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _reservationDetailReservationClientDiagnostics.CreateScope("ReservationDetailCollection.GetRevisions");
                scope.Start();
                try
                {
                    var response = _reservationDetailReservationRestClient.ListRevisions(Guid.Parse(Id.Name), reservationId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ReservationDetailResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ReservationDetailResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _reservationDetailReservationClientDiagnostics.CreateScope("ReservationDetailCollection.GetRevisions");
                scope.Start();
                try
                {
                    var response = _reservationDetailReservationRestClient.ListRevisionsNextPage(nextLink, Guid.Parse(Id.Name), reservationId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ReservationDetailResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Checks to see if the resource exists in azure.
        /// Request Path: /providers/Microsoft.Capacity/reservationOrders/{reservationOrderId}/reservations/{reservationId}
        /// Operation Id: Reservation_Get
        /// </summary>
        /// <param name="reservationId"> Id of the Reservation Item. </param>
        /// <param name="expand"> Supported value of this query is renewProperties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> ExistsAsync(Guid reservationId, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _reservationDetailReservationClientDiagnostics.CreateScope("ReservationDetailCollection.Exists");
            scope.Start();
            try
            {
                var response = await _reservationDetailReservationRestClient.GetAsync(Guid.Parse(Id.Name), reservationId, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /providers/Microsoft.Capacity/reservationOrders/{reservationOrderId}/reservations/{reservationId}
        /// Operation Id: Reservation_Get
        /// </summary>
        /// <param name="reservationId"> Id of the Reservation Item. </param>
        /// <param name="expand"> Supported value of this query is renewProperties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Exists(Guid reservationId, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _reservationDetailReservationClientDiagnostics.CreateScope("ReservationDetailCollection.Exists");
            scope.Start();
            try
            {
                var response = _reservationDetailReservationRestClient.Get(Guid.Parse(Id.Name), reservationId, expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ReservationDetailResource> IEnumerable<ReservationDetailResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ReservationDetailResource> IAsyncEnumerable<ReservationDetailResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
