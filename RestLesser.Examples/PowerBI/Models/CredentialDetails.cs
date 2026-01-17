using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RestLesser.Examples.PowerBI.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EncryptedConnection
    {
        Encrypted,
        NotEncrypted
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum EncryptionAlgorithm
    {
        None,
        [JsonProperty(PropertyName = "RSA-OAEP")]
        RSAOAEP
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum PrivacyLevel
    {
        None,
        Organizational,
        Private,
        Public
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum CredentialType
    {
        Anonymous,
        Basic,
        Key,
        OAuth2,
        Windows
    }

    public class CredentialDetails
    {
        [JsonProperty(PropertyName = "credentialType")]
        public CredentialType CredentialType { get; set; }

        [JsonProperty(PropertyName = "credentials")]
        public string? Credentials { get; set; }

        [JsonProperty(PropertyName = "encryptedConnection")]
        public EncryptedConnection EncryptedConnection { get; set; }

        [JsonProperty(PropertyName = "encryptionAlgorithm")]
        public EncryptionAlgorithm EncryptionAlgorithm { get; set; }

        [JsonProperty(PropertyName = "privacyLevel")]
        public PrivacyLevel PrivacyLevel { get; set; }

        [JsonProperty(PropertyName = "useCallerAADIdentity")]
        public bool UseCallerAADIdentity { get; set; }

        [JsonProperty(PropertyName = "useEndUserOAuth2Credentials")]
        public bool UseEndUserOAuth2Credentials { get; set; }
    }

    public class UpdateDatasource
    {
        [JsonProperty(PropertyName = "credentialDetails")]
        public CredentialDetails? CredentialDetails { get; set; }
    }
}
