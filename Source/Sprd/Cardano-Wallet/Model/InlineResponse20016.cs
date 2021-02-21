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
    /// The status of the SMASH server. Possible values are:  health                  | description - --                     | - -- &#x60;\&quot;available\&quot;&#x60;           | server is awaiting your requests &#x60;\&quot;unavailable\&quot;&#x60;         | server is running, but currently unavailable, try again in a short time &#x60;\&quot;unreachable\&quot;&#x60;         | server could not be reached or didn&#x27;t return a health status &#x60;\&quot;no_smash_configured\&quot;&#x60; | SMASH is currently not configured, adjust the Settings first 
    /// </summary>
    [DataContract]
        public partial class InlineResponse20016 :  IEquatable<InlineResponse20016>, IValidatableObject
    {
        /// <summary>
        /// Defines Health
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
                public enum HealthEnum
        {
            /// <summary>
            /// Enum Available for value: available
            /// </summary>
            [EnumMember(Value = "available")]
            Available = 1,
            /// <summary>
            /// Enum Unavailable for value: unavailable
            /// </summary>
            [EnumMember(Value = "unavailable")]
            Unavailable = 2,
            /// <summary>
            /// Enum Unreachable for value: unreachable
            /// </summary>
            [EnumMember(Value = "unreachable")]
            Unreachable = 3,
            /// <summary>
            /// Enum Nosmashconfigured for value: no_smash_configured
            /// </summary>
            [EnumMember(Value = "no_smash_configured")]
            Nosmashconfigured = 4        }
        /// <summary>
        /// Gets or Sets Health
        /// </summary>
        [DataMember(Name="health", EmitDefaultValue=false)]
        public HealthEnum Health { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="InlineResponse20016" /> class.
        /// </summary>
        /// <param name="health">health (required).</param>
        public InlineResponse20016(HealthEnum health = default(HealthEnum))
        {
            // to ensure "health" is required (not null)
            if (health == null)
            {
                throw new InvalidDataException("health is a required property for InlineResponse20016 and cannot be null");
            }
            else
            {
                this.Health = health;
            }
        }
        

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InlineResponse20016 {\n");
            sb.Append("  Health: ").Append(Health).Append("\n");
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
            return this.Equals(input as InlineResponse20016);
        }

        /// <summary>
        /// Returns true if InlineResponse20016 instances are equal
        /// </summary>
        /// <param name="input">Instance of InlineResponse20016 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InlineResponse20016 input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Health == input.Health ||
                    (this.Health != null &&
                    this.Health.Equals(input.Health))
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
                if (this.Health != null)
                    hashCode = hashCode * 59 + this.Health.GetHashCode();
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
