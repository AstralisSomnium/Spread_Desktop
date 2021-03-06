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
    /// ApiPostRedemptionFeeData
    /// </summary>
    [DataContract]
        public partial class ApiPostRedemptionFeeData :  IEquatable<ApiPostRedemptionFeeData>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiPostRedemptionFeeData" /> class.
        /// </summary>
        /// <param name="payments">A list of target outputs (required).</param>
        /// <param name="withdrawal">When provided, attempts to withdraw rewards from the default stake address corresponding to the given mnemonic.  Should the rewards be null or too small to be worth withdrawing (i.e. the cost of adding them into the transaction is more than their own intrinsic value), the server will reject the request with a &#x60;withdrawal_not_worth&#x60; error.  withdrawal field    | reward balance | result - --                 | - --            | - -- any recovery phrase | too small      | x Error 403 &#x60;withdrawal_not_worth&#x60; any recovery phrase | big enough     | ✓ withdrawal generated  (required).</param>
        public ApiPostRedemptionFeeData(List<WalletswalletIdpaymentfeesPayments> payments = default(List<WalletswalletIdpaymentfeesPayments>), List<string> withdrawal = default(List<string>))
        {
            // to ensure "payments" is required (not null)
            if (payments == null)
            {
                throw new InvalidDataException("payments is a required property for ApiPostRedemptionFeeData and cannot be null");
            }
            else
            {
                this.Payments = payments;
            }
            // to ensure "withdrawal" is required (not null)
            if (withdrawal == null)
            {
                throw new InvalidDataException("withdrawal is a required property for ApiPostRedemptionFeeData and cannot be null");
            }
            else
            {
                this.Withdrawal = withdrawal;
            }
        }
        
        /// <summary>
        /// A list of target outputs
        /// </summary>
        /// <value>A list of target outputs</value>
        [DataMember(Name="payments", EmitDefaultValue=false)]
        public List<WalletswalletIdpaymentfeesPayments> Payments { get; set; }

        /// <summary>
        /// When provided, attempts to withdraw rewards from the default stake address corresponding to the given mnemonic.  Should the rewards be null or too small to be worth withdrawing (i.e. the cost of adding them into the transaction is more than their own intrinsic value), the server will reject the request with a &#x60;withdrawal_not_worth&#x60; error.  withdrawal field    | reward balance | result - --                 | - --            | - -- any recovery phrase | too small      | x Error 403 &#x60;withdrawal_not_worth&#x60; any recovery phrase | big enough     | ✓ withdrawal generated 
        /// </summary>
        /// <value>When provided, attempts to withdraw rewards from the default stake address corresponding to the given mnemonic.  Should the rewards be null or too small to be worth withdrawing (i.e. the cost of adding them into the transaction is more than their own intrinsic value), the server will reject the request with a &#x60;withdrawal_not_worth&#x60; error.  withdrawal field    | reward balance | result - --                 | - --            | - -- any recovery phrase | too small      | x Error 403 &#x60;withdrawal_not_worth&#x60; any recovery phrase | big enough     | ✓ withdrawal generated </value>
        [DataMember(Name="withdrawal", EmitDefaultValue=false)]
        public List<string> Withdrawal { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ApiPostRedemptionFeeData {\n");
            sb.Append("  Payments: ").Append(Payments).Append("\n");
            sb.Append("  Withdrawal: ").Append(Withdrawal).Append("\n");
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
            return this.Equals(input as ApiPostRedemptionFeeData);
        }

        /// <summary>
        /// Returns true if ApiPostRedemptionFeeData instances are equal
        /// </summary>
        /// <param name="input">Instance of ApiPostRedemptionFeeData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ApiPostRedemptionFeeData input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Payments == input.Payments ||
                    this.Payments != null &&
                    input.Payments != null &&
                    this.Payments.SequenceEqual(input.Payments)
                ) && 
                (
                    this.Withdrawal == input.Withdrawal ||
                    this.Withdrawal != null &&
                    input.Withdrawal != null &&
                    this.Withdrawal.SequenceEqual(input.Withdrawal)
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
                if (this.Payments != null)
                    hashCode = hashCode * 59 + this.Payments.GetHashCode();
                if (this.Withdrawal != null)
                    hashCode = hashCode * 59 + this.Withdrawal.GetHashCode();
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
