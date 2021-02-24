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
    ///  If and when each era started or will start.  The object is keyed by era names. The values either describe the epoch boundary when the era starts (can be in the future or in the past), or are null if not yet confirmed on-chain.  If you need to know the current era, see the &#x60;node_era&#x60; field of &#x60;GET /network/information&#x60;.  &gt; Due to complications with our current tooling, we cannot mark the era names &gt; as required, but the keys are in fact always present. 
    /// </summary>
    [DataContract]
        public partial class ApiEraInfo :  IEquatable<ApiEraInfo>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiEraInfo" /> class.
        /// </summary>
        /// <param name="byron">byron.</param>
        /// <param name="shelley">shelley.</param>
        /// <param name="allegra">allegra.</param>
        /// <param name="mary">mary.</param>
        public ApiEraInfo(WalletsDelegationChangesAt byron = default(WalletsDelegationChangesAt), WalletsDelegationChangesAt shelley = default(WalletsDelegationChangesAt), WalletsDelegationChangesAt allegra = default(WalletsDelegationChangesAt), WalletsDelegationChangesAt mary = default(WalletsDelegationChangesAt))
        {
            this.Byron = byron;
            this.Shelley = shelley;
            this.Allegra = allegra;
            this.Mary = mary;
        }
        
        /// <summary>
        /// Gets or Sets Byron
        /// </summary>
        [DataMember(Name="byron", EmitDefaultValue=false)]
        public WalletsDelegationChangesAt Byron { get; set; }

        /// <summary>
        /// Gets or Sets Shelley
        /// </summary>
        [DataMember(Name="shelley", EmitDefaultValue=false)]
        public WalletsDelegationChangesAt Shelley { get; set; }

        /// <summary>
        /// Gets or Sets Allegra
        /// </summary>
        [DataMember(Name="allegra", EmitDefaultValue=false)]
        public WalletsDelegationChangesAt Allegra { get; set; }

        /// <summary>
        /// Gets or Sets Mary
        /// </summary>
        [DataMember(Name="mary", EmitDefaultValue=false)]
        public WalletsDelegationChangesAt Mary { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ApiEraInfo {\n");
            sb.Append("  Byron: ").Append(Byron).Append("\n");
            sb.Append("  Shelley: ").Append(Shelley).Append("\n");
            sb.Append("  Allegra: ").Append(Allegra).Append("\n");
            sb.Append("  Mary: ").Append(Mary).Append("\n");
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
            return this.Equals(input as ApiEraInfo);
        }

        /// <summary>
        /// Returns true if ApiEraInfo instances are equal
        /// </summary>
        /// <param name="input">Instance of ApiEraInfo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ApiEraInfo input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Byron == input.Byron ||
                    (this.Byron != null &&
                    this.Byron.Equals(input.Byron))
                ) && 
                (
                    this.Shelley == input.Shelley ||
                    (this.Shelley != null &&
                    this.Shelley.Equals(input.Shelley))
                ) && 
                (
                    this.Allegra == input.Allegra ||
                    (this.Allegra != null &&
                    this.Allegra.Equals(input.Allegra))
                ) && 
                (
                    this.Mary == input.Mary ||
                    (this.Mary != null &&
                    this.Mary.Equals(input.Mary))
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
                if (this.Byron != null)
                    hashCode = hashCode * 59 + this.Byron.GetHashCode();
                if (this.Shelley != null)
                    hashCode = hashCode * 59 + this.Shelley.GetHashCode();
                if (this.Allegra != null)
                    hashCode = hashCode * 59 + this.Allegra.GetHashCode();
                if (this.Mary != null)
                    hashCode = hashCode * 59 + this.Mary.GetHashCode();
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