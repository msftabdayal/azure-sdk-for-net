// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.ServiceLinker.Models
{
    internal partial class UnknownTargetServiceBase : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("type");
            writer.WriteStringValue(TargetServiceType.ToString());
            writer.WriteEndObject();
        }

        internal static UnknownTargetServiceBase DeserializeUnknownTargetServiceBase(JsonElement element)
        {
            TargetServiceType type = "Unknown";
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"))
                {
                    type = new TargetServiceType(property.Value.GetString());
                    continue;
                }
            }
            return new UnknownTargetServiceBase(type);
        }
    }
}
