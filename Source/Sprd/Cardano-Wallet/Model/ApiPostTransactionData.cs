/* 
 * Cardano Wallet Backend API
 *
 * <p align=\"right\"><img style=\"position: relative; top: -10em; margin-bottom: -12em;\" width=\"20%\" src=\"https://cardanodocs.com/img/cardano.png\"></img></p> 
 *
 * OpenAPI spec version: 2021.2.15
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// ApiPostTransactionData
    /// </summary>
    [DataContract]
        public partial class ApiPostTransactionData :  IEquatable<ApiPostTransactionData>, IValidatableObject
    {
        /// <summary>
        /// When provided, instruments the server to automatically withdraw rewards from the source wallet when they are deemed sufficient (i.e. they contribute to the balance for at least as much as they cost).  As a consequence, the resulting transaction may or may not have a withdrawal object. Summarizing:  withdrawal field | reward balance | result - --              | - --            | - -- &#x60;null&#x60;           | too small      | ✓ no withdrawals generated &#x60;null&#x60;           | big enough     | ✓ no withdrawals generated &#x60;\&quot;self\&quot;&#x60;         | too small      | ✓ no withdrawals generated &#x60;\&quot;self\&quot;&#x60;         | big enough     | ✓ withdrawal generated 
        /// </summary>
        /// <value>When provided, instruments the server to automatically withdraw rewards from the source wallet when they are deemed sufficient (i.e. they contribute to the balance for at least as much as they cost).  As a consequence, the resulting transaction may or may not have a withdrawal object. Summarizing:  withdrawal field | reward balance | result - --              | - --            | - -- &#x60;null&#x60;           | too small      | ✓ no withdrawals generated &#x60;null&#x60;           | big enough     | ✓ no withdrawals generated &#x60;\&quot;self\&quot;&#x60;         | too small      | ✓ no withdrawals generated &#x60;\&quot;self\&quot;&#x60;         | big enough     | ✓ withdrawal generated </value>
        [JsonConverter(typeof(StringEnumConverter))]
                public enum WithdrawalEnum
        {
            /// <summary>
            /// Enum Self for value: self
            /// </summary>
            [EnumMember(Value = "self")]
            Self = 1        }
        /// <summary>
        /// When provided, instruments the server to automatically withdraw rewards from the source wallet when they are deemed sufficient (i.e. they contribute to the balance for at least as much as they cost).  As a consequence, the resulting transaction may or may not have a withdrawal object. Summarizing:  withdrawal field | reward balance | result - --              | - --            | - -- &#x60;null&#x60;           | too small      | ✓ no withdrawals generated &#x60;null&#x60;           | big enough     | ✓ no withdrawals generated &#x60;\&quot;self\&quot;&#x60;         | too small      | ✓ no withdrawals generated &#x60;\&quot;self\&quot;&#x60;         | big enough     | ✓ withdrawal generated 
        /// </summary>
        /// <value>When provided, instruments the server to automatically withdraw rewards from the source wallet when they are deemed sufficient (i.e. they contribute to the balance for at least as much as they cost).  As a consequence, the resulting transaction may or may not have a withdrawal object. Summarizing:  withdrawal field | reward balance | result - --              | - --            | - -- &#x60;null&#x60;           | too small      | ✓ no withdrawals generated &#x60;null&#x60;           | big enough     | ✓ no withdrawals generated &#x60;\&quot;self\&quot;&#x60;         | too small      | ✓ no withdrawals generated &#x60;\&quot;self\&quot;&#x60;         | big enough     | ✓ withdrawal generated </value>
        [DataMember(Name="withdrawal", EmitDefaultValue=false)]
        public WithdrawalEnum? Withdrawal { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiPostTransactionData" /> class.
        /// </summary>
        /// <param name="passphrase">The wallet&#x27;s master passphrase. (required).</param>
        /// <param name="payments">A list of target outputs (required).</param>
        /// <param name="withdrawal">When provided, instruments the server to automatically withdraw rewards from the source wallet when they are deemed sufficient (i.e. they contribute to the balance for at least as much as they cost).  As a consequence, the resulting transaction may or may not have a withdrawal object. Summarizing:  withdrawal field | reward balance | result - --              | - --            | - -- &#x60;null&#x60;           | too small      | ✓ no withdrawals generated &#x60;null&#x60;           | big enough     | ✓ no withdrawals generated &#x60;\&quot;self\&quot;&#x60;         | too small      | ✓ no withdrawals generated &#x60;\&quot;self\&quot;&#x60;         | big enough     | ✓ withdrawal generated .</param>
        /// <param name="metadata">**⚠️ WARNING ⚠️**  _Please note that metadata provided in a transaction will be stored on the blockchain forever. Make sure not to include any sensitive data, in particular personally identifiable information (PII)._  Extra application data attached to the transaction.  Cardano allows users and developers to embed their own authenticated metadata when submitting transactions. Metadata can be expressed as a JSON object with some restrictions:  1. All top-level keys must be integers between &#x60;0&#x60; and &#x60;2^64 - 1&#x60;.  2. Each metadata value is tagged with its type.  3. Strings must be at most 64 bytes when UTF-8 encoded.  4. Bytestrings are hex-encoded, with a maximum length of 64 bytes.  Metadata aren&#x27;t stored as JSON on the Cardano blockchain but are instead stored using a compact binary encoding (CBOR).  The binary encoding of metadata values supports three simple types:  * Integers in the range &#x60;-(2^64 - 1)&#x60; to &#x60;2^64 - 1&#x60; * Strings (UTF-8 encoded) * Bytestrings  And two compound types:  * Lists of metadata values * Mappings from metadata values to metadata values  It is possible to transform any JSON object into this schema.  However, if your application uses floating point values, they will need to be converted somehow, according to your requirements. Likewise for &#x60;null&#x60; or &#x60;bool&#x60; values. When reading metadata from chain, be aware that integers may exceed the javascript numeric range, and may need special \&quot;bigint\&quot; parsing. .</param>
        /// <param name="timeToLive">timeToLive.</param>
        public ApiPostTransactionData(string passphrase = default(string), List<WalletswalletIdpaymentfeesPayments> payments = default(List<WalletswalletIdpaymentfeesPayments>), WithdrawalEnum? withdrawal = default(WithdrawalEnum?), Dictionary<string, TransactionMetadataValue> metadata = default(Dictionary<string, TransactionMetadataValue>), WalletswalletIdpaymentfeesTimeToLive timeToLive = default(WalletswalletIdpaymentfeesTimeToLive))
        {
            // to ensure "passphrase" is required (not null)
            if (passphrase == null)
            {
                throw new InvalidDataException("passphrase is a required property for ApiPostTransactionData and cannot be null");
            }
            else
            {
                this.Passphrase = passphrase;
            }
            // to ensure "payments" is required (not null)
            if (payments == null)
            {
                throw new InvalidDataException("payments is a required property for ApiPostTransactionData and cannot be null");
            }
            else
            {
                this.Payments = payments;
            }
            this.Withdrawal = withdrawal;
            this.Metadata = metadata;
            this.TimeToLive = timeToLive;
        }
        
        /// <summary>
        /// The wallet&#x27;s master passphrase.
        /// </summary>
        /// <value>The wallet&#x27;s master passphrase.</value>
        [DataMember(Name="passphrase", EmitDefaultValue=false)]
        public string Passphrase { get; set; }

        /// <summary>
        /// A list of target outputs
        /// </summary>
        /// <value>A list of target outputs</value>
        [DataMember(Name="payments", EmitDefaultValue=false)]
        public List<WalletswalletIdpaymentfeesPayments> Payments { get; set; }


        /// <summary>
        /// **⚠️ WARNING ⚠️**  _Please note that metadata provided in a transaction will be stored on the blockchain forever. Make sure not to include any sensitive data, in particular personally identifiable information (PII)._  Extra application data attached to the transaction.  Cardano allows users and developers to embed their own authenticated metadata when submitting transactions. Metadata can be expressed as a JSON object with some restrictions:  1. All top-level keys must be integers between &#x60;0&#x60; and &#x60;2^64 - 1&#x60;.  2. Each metadata value is tagged with its type.  3. Strings must be at most 64 bytes when UTF-8 encoded.  4. Bytestrings are hex-encoded, with a maximum length of 64 bytes.  Metadata aren&#x27;t stored as JSON on the Cardano blockchain but are instead stored using a compact binary encoding (CBOR).  The binary encoding of metadata values supports three simple types:  * Integers in the range &#x60;-(2^64 - 1)&#x60; to &#x60;2^64 - 1&#x60; * Strings (UTF-8 encoded) * Bytestrings  And two compound types:  * Lists of metadata values * Mappings from metadata values to metadata values  It is possible to transform any JSON object into this schema.  However, if your application uses floating point values, they will need to be converted somehow, according to your requirements. Likewise for &#x60;null&#x60; or &#x60;bool&#x60; values. When reading metadata from chain, be aware that integers may exceed the javascript numeric range, and may need special \&quot;bigint\&quot; parsing. 
        /// </summary>
        /// <value>**⚠️ WARNING ⚠️**  _Please note that metadata provided in a transaction will be stored on the blockchain forever. Make sure not to include any sensitive data, in particular personally identifiable information (PII)._  Extra application data attached to the transaction.  Cardano allows users and developers to embed their own authenticated metadata when submitting transactions. Metadata can be expressed as a JSON object with some restrictions:  1. All top-level keys must be integers between &#x60;0&#x60; and &#x60;2^64 - 1&#x60;.  2. Each metadata value is tagged with its type.  3. Strings must be at most 64 bytes when UTF-8 encoded.  4. Bytestrings are hex-encoded, with a maximum length of 64 bytes.  Metadata aren&#x27;t stored as JSON on the Cardano blockchain but are instead stored using a compact binary encoding (CBOR).  The binary encoding of metadata values supports three simple types:  * Integers in the range &#x60;-(2^64 - 1)&#x60; to &#x60;2^64 - 1&#x60; * Strings (UTF-8 encoded) * Bytestrings  And two compound types:  * Lists of metadata values * Mappings from metadata values to metadata values  It is possible to transform any JSON object into this schema.  However, if your application uses floating point values, they will need to be converted somehow, according to your requirements. Likewise for &#x60;null&#x60; or &#x60;bool&#x60; values. When reading metadata from chain, be aware that integers may exceed the javascript numeric range, and may need special \&quot;bigint\&quot; parsing. </value>
        [DataMember(Name="metadata", EmitDefaultValue=false)]
        public Dictionary<string, TransactionMetadataValue> Metadata { get; set; }

        /// <summary>
        /// Gets or Sets TimeToLive
        /// </summary>
        [DataMember(Name="time_to_live", EmitDefaultValue=false)]
        public WalletswalletIdpaymentfeesTimeToLive TimeToLive { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ApiPostTransactionData {\n");
            sb.Append("  Passphrase: ").Append(Passphrase).Append("\n");
            sb.Append("  Payments: ").Append(Payments).Append("\n");
            sb.Append("  Withdrawal: ").Append(Withdrawal).Append("\n");
            sb.Append("  Metadata: ").Append(Metadata).Append("\n");
            sb.Append("  TimeToLive: ").Append(TimeToLive).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as ApiPostTransactionData);
        }

        /// <summary>
        /// Returns true if ApiPostTransactionData instances are equal
        /// </summary>
        /// <param name="input">Instance of ApiPostTransactionData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ApiPostTransactionData input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Passphrase == input.Passphrase ||
                    (this.Passphrase != null &&
                    this.Passphrase.Equals(input.Passphrase))
                ) && 
                (
                    this.Payments == input.Payments ||
                    this.Payments != null &&
                    input.Payments != null &&
                    this.Payments.SequenceEqual(input.Payments)
                ) && 
                (
                    this.Withdrawal == input.Withdrawal ||
                    (this.Withdrawal != null &&
                    this.Withdrawal.Equals(input.Withdrawal))
                ) && 
                (
                    this.Metadata == input.Metadata ||
                    this.Metadata != null &&
                    input.Metadata != null &&
                    this.Metadata.SequenceEqual(input.Metadata)
                ) && 
                (
                    this.TimeToLive == input.TimeToLive ||
                    (this.TimeToLive != null &&
                    this.TimeToLive.Equals(input.TimeToLive))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Passphrase != null)
                    hashCode = hashCode * 59 + this.Passphrase.GetHashCode();
                if (this.Payments != null)
                    hashCode = hashCode * 59 + this.Payments.GetHashCode();
                if (this.Withdrawal != null)
                    hashCode = hashCode * 59 + this.Withdrawal.GetHashCode();
                if (this.Metadata != null)
                    hashCode = hashCode * 59 + this.Metadata.GetHashCode();
                if (this.TimeToLive != null)
                    hashCode = hashCode * 59 + this.TimeToLive.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
