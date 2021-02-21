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
    /// Body21
    /// </summary>
    [DataContract]
        public partial class Body21 :  IEquatable<Body21>, IValidatableObject
    {
        /// <summary>
        /// Script validation level. Required validation sifts off scripts that would not be accepted by the ledger. Recommended level filters out scripts that do not pass required validation and additionally when:   * &#x27;all&#x27; is non-empty   * there are redundant timelocks in a given level   * there are no duplicated verification keys in a given level   * &#x27;at_least&#x27; coeffcient is positive   * &#x27;all&#x27;, &#x27;any&#x27; are non-empty and &#x60;&#x27;at_least&#x27; has no less elements in the list      than the coeffcient after timelocks are filtered out. 
        /// </summary>
        /// <value>Script validation level. Required validation sifts off scripts that would not be accepted by the ledger. Recommended level filters out scripts that do not pass required validation and additionally when:   * &#x27;all&#x27; is non-empty   * there are redundant timelocks in a given level   * there are no duplicated verification keys in a given level   * &#x27;at_least&#x27; coeffcient is positive   * &#x27;all&#x27;, &#x27;any&#x27; are non-empty and &#x60;&#x27;at_least&#x27; has no less elements in the list      than the coeffcient after timelocks are filtered out. </value>
        [JsonConverter(typeof(StringEnumConverter))]
                public enum ValidationEnum
        {
            /// <summary>
            /// Enum Required for value: required
            /// </summary>
            [EnumMember(Value = "required")]
            Required = 1,
            /// <summary>
            /// Enum Recommended for value: recommended
            /// </summary>
            [EnumMember(Value = "recommended")]
            Recommended = 2        }
        /// <summary>
        /// Script validation level. Required validation sifts off scripts that would not be accepted by the ledger. Recommended level filters out scripts that do not pass required validation and additionally when:   * &#x27;all&#x27; is non-empty   * there are redundant timelocks in a given level   * there are no duplicated verification keys in a given level   * &#x27;at_least&#x27; coeffcient is positive   * &#x27;all&#x27;, &#x27;any&#x27; are non-empty and &#x60;&#x27;at_least&#x27; has no less elements in the list      than the coeffcient after timelocks are filtered out. 
        /// </summary>
        /// <value>Script validation level. Required validation sifts off scripts that would not be accepted by the ledger. Recommended level filters out scripts that do not pass required validation and additionally when:   * &#x27;all&#x27; is non-empty   * there are redundant timelocks in a given level   * there are no duplicated verification keys in a given level   * &#x27;at_least&#x27; coeffcient is positive   * &#x27;all&#x27;, &#x27;any&#x27; are non-empty and &#x60;&#x27;at_least&#x27; has no less elements in the list      than the coeffcient after timelocks are filtered out. </value>
        [DataMember(Name="validation", EmitDefaultValue=false)]
        public ValidationEnum? Validation { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Body21" /> class.
        /// </summary>
        /// <param name="payment">payment.</param>
        /// <param name="stake">stake.</param>
        /// <param name="validation">Script validation level. Required validation sifts off scripts that would not be accepted by the ledger. Recommended level filters out scripts that do not pass required validation and additionally when:   * &#x27;all&#x27; is non-empty   * there are redundant timelocks in a given level   * there are no duplicated verification keys in a given level   * &#x27;at_least&#x27; coeffcient is positive   * &#x27;all&#x27;, &#x27;any&#x27; are non-empty and &#x60;&#x27;at_least&#x27; has no less elements in the list      than the coeffcient after timelocks are filtered out. .</param>
        public Body21(OneOfbody21Payment payment = default(OneOfbody21Payment), OneOfbody21Stake stake = default(OneOfbody21Stake), ValidationEnum? validation = default(ValidationEnum?))
        {
            this.Payment = payment;
            this.Stake = stake;
            this.Validation = validation;
        }
        
        /// <summary>
        /// Gets or Sets Payment
        /// </summary>
        [DataMember(Name="payment", EmitDefaultValue=false)]
        public OneOfbody21Payment Payment { get; set; }

        /// <summary>
        /// Gets or Sets Stake
        /// </summary>
        [DataMember(Name="stake", EmitDefaultValue=false)]
        public OneOfbody21Stake Stake { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Body21 {\n");
            sb.Append("  Payment: ").Append(Payment).Append("\n");
            sb.Append("  Stake: ").Append(Stake).Append("\n");
            sb.Append("  Validation: ").Append(Validation).Append("\n");
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
            return this.Equals(input as Body21);
        }

        /// <summary>
        /// Returns true if Body21 instances are equal
        /// </summary>
        /// <param name="input">Instance of Body21 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Body21 input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Payment == input.Payment ||
                    (this.Payment != null &&
                    this.Payment.Equals(input.Payment))
                ) && 
                (
                    this.Stake == input.Stake ||
                    (this.Stake != null &&
                    this.Stake.Equals(input.Stake))
                ) && 
                (
                    this.Validation == input.Validation ||
                    (this.Validation != null &&
                    this.Validation.Equals(input.Validation))
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
                if (this.Payment != null)
                    hashCode = hashCode * 59 + this.Payment.GetHashCode();
                if (this.Stake != null)
                    hashCode = hashCode * 59 + this.Stake.GetHashCode();
                if (this.Validation != null)
                    hashCode = hashCode * 59 + this.Validation.GetHashCode();
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
