using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace SupportWebApp.Models
{
    public class SupportMessage
    {
        [JsonPropertyName("id")]
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "Navn skal udfyldes")]
        [JsonPropertyName("name")]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "E-mail skal udfyldes"), EmailAddress(ErrorMessage = "Ugyldig e-mailadresse")]
        [JsonPropertyName("email")]
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Telefonnummer skal udfyldes")]
        [JsonPropertyName("phone")]
        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Beskrivelse skal udfyldes")]
        [JsonPropertyName("description")]
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Kategori skal vælges")]
        [JsonPropertyName("category")]
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; } = string.Empty;

        [JsonPropertyName("dateTime")]
        [JsonProperty(PropertyName = "dateTime")]
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}