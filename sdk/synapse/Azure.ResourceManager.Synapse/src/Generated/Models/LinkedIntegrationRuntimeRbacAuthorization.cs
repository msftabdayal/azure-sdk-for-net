// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.Synapse.Models
{
    /// <summary> The role based access control (RBAC) authorization type integration runtime. </summary>
    public partial class LinkedIntegrationRuntimeRbacAuthorization : LinkedIntegrationRuntimeType
    {
        /// <summary> Initializes a new instance of LinkedIntegrationRuntimeRbacAuthorization. </summary>
        /// <param name="resourceId"> The resource identifier of the integration runtime to be shared. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceId"/> is null. </exception>
        public LinkedIntegrationRuntimeRbacAuthorization(string resourceId)
        {
            Argument.AssertNotNull(resourceId, nameof(resourceId));

            ResourceId = resourceId;
            AuthorizationType = "RBAC";
        }

        /// <summary> Initializes a new instance of LinkedIntegrationRuntimeRbacAuthorization. </summary>
        /// <param name="authorizationType"> The authorization type for integration runtime sharing. </param>
        /// <param name="resourceId"> The resource identifier of the integration runtime to be shared. </param>
        internal LinkedIntegrationRuntimeRbacAuthorization(string authorizationType, string resourceId) : base(authorizationType)
        {
            ResourceId = resourceId;
            AuthorizationType = authorizationType ?? "RBAC";
        }

        /// <summary> The resource identifier of the integration runtime to be shared. </summary>
        public string ResourceId { get; set; }
    }
}
