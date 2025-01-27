// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.DataMigration.Models
{
    public partial class FileShare : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(UserName))
            {
                writer.WritePropertyName("userName");
                writer.WriteStringValue(UserName);
            }
            if (Optional.IsDefined(Password))
            {
                writer.WritePropertyName("password");
                writer.WriteStringValue(Password);
            }
            writer.WritePropertyName("path");
            writer.WriteStringValue(Path);
            writer.WriteEndObject();
        }

        internal static FileShare DeserializeFileShare(JsonElement element)
        {
            Optional<string> userName = default;
            Optional<string> password = default;
            string path = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("userName"))
                {
                    userName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("password"))
                {
                    password = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("path"))
                {
                    path = property.Value.GetString();
                    continue;
                }
            }
            return new FileShare(userName.Value, password.Value, path);
        }
    }
}
