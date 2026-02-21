using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Biohazard.BioRand.RE7.Extensions {
    internal static class JsonExtensions {
        public static string ToJson(this object o, bool indented = true, bool camelCase = false) {
            return JsonSerializer.Serialize(
                o, new JsonSerializerOptions() {
                    Converters = { new JsonStringEnumConverter() },
                    PropertyNamingPolicy = camelCase ? JsonNamingPolicy.CamelCase : null,
                    WriteIndented = indented
                })!;
        }

        public static T DeserializeJson<T>(this byte[] json, bool camelCase = false) {
            return JsonSerializer.Deserialize<T>(
                json, new JsonSerializerOptions() {
                    Converters = { new JsonStringEnumConverter() },
                    ReadCommentHandling = JsonCommentHandling.Skip,
                    PropertyNamingPolicy = camelCase ? JsonNamingPolicy.CamelCase : null
                })!;
        }

        public static T DeserializeJson<T>(this string json, bool camelCase = false) {
            return JsonSerializer.Deserialize<T>(
                json, new JsonSerializerOptions() {
                    Converters = { new JsonStringEnumConverter() },
                    ReadCommentHandling = JsonCommentHandling.Skip,
                    PropertyNamingPolicy = camelCase ? JsonNamingPolicy.CamelCase : null
                })!;
        }

        public static bool? GetBooleanProperty(this JsonElement element, string name) {
            return element.TryGetProperty(name, out var value) ? value.GetBoolean() : null;
        }

        public static int? GetInt32Property(this JsonElement element, string name) {
            return element.TryGetProperty(name, out var value) ? value.GetInt32() : null;
        }

        public static string? GetStringProperty(this JsonElement element, string name) {
            return element.TryGetProperty(name, out var value) ? value.GetString() : null;
        }

        public static object? GetValue(this JsonElement element) {
            return element.ValueKind switch {
                JsonValueKind.True => true,
                JsonValueKind.False => true,
                JsonValueKind.Number => element.GetDouble(),
                JsonValueKind.Null => null,
                _ => throw new NotSupportedException()
            };
        }
    }
}
