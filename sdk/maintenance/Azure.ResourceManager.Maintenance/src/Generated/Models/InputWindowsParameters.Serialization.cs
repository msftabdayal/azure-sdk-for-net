// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Maintenance.Models
{
    public partial class InputWindowsParameters : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(KbNumbersToExclude))
            {
                writer.WritePropertyName("kbNumbersToExclude");
                writer.WriteStartArray();
                foreach (var item in KbNumbersToExclude)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(KbNumbersToInclude))
            {
                writer.WritePropertyName("kbNumbersToInclude");
                writer.WriteStartArray();
                foreach (var item in KbNumbersToInclude)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(ClassificationsToInclude))
            {
                writer.WritePropertyName("classificationsToInclude");
                writer.WriteStartArray();
                foreach (var item in ClassificationsToInclude)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(ExcludeKbsRequiringReboot))
            {
                writer.WritePropertyName("excludeKbsRequiringReboot");
                writer.WriteBooleanValue(ExcludeKbsRequiringReboot.Value);
            }
            writer.WriteEndObject();
        }

        internal static InputWindowsParameters DeserializeInputWindowsParameters(JsonElement element)
        {
            Optional<IList<string>> kbNumbersToExclude = default;
            Optional<IList<string>> kbNumbersToInclude = default;
            Optional<IList<string>> classificationsToInclude = default;
            Optional<bool> excludeKbsRequiringReboot = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("kbNumbersToExclude"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    kbNumbersToExclude = array;
                    continue;
                }
                if (property.NameEquals("kbNumbersToInclude"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    kbNumbersToInclude = array;
                    continue;
                }
                if (property.NameEquals("classificationsToInclude"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    classificationsToInclude = array;
                    continue;
                }
                if (property.NameEquals("excludeKbsRequiringReboot"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    excludeKbsRequiringReboot = property.Value.GetBoolean();
                    continue;
                }
            }
            return new InputWindowsParameters(Optional.ToList(kbNumbersToExclude), Optional.ToList(kbNumbersToInclude), Optional.ToList(classificationsToInclude), Optional.ToNullable(excludeKbsRequiringReboot));
        }
    }
}
