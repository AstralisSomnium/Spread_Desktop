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
    /// Byron wallet&#x27;s current balance(s)
    /// </summary>
    [DataContract]
        public partial class ByronwalletsBalance :  IEquatable<ByronwalletsBalance>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ByronwalletsBalance" /> class.
        /// </summary>
        /// <param name="available">available (required).</param>
        /// <param name="total">total (required).</param>
        public ByronwalletsBalance(ByronwalletsBalanceAvailable available = default(ByronwalletsBalanceAvailable), ByronwalletsBalanceTotal total = default(ByronwalletsBalanceTotal))
        {
            // to ensure "available" is required (not null)
            if (available == null)
            {
                throw new InvalidDataException("available is a required property for ByronwalletsBalance and cannot be null");
            }
            else
            {
                this.Available = available;
            }
            // to ensure "total" is required (not null)
            if (total == null)
            {
                throw new InvalidDataException("total is a required property for ByronwalletsBalance and cannot be null");
            }
            else
            {
                this.Total = total;
            }
        }
        
        /// <summary>
        /// Gets or Sets Available
        /// </summary>
        [DataMember(Name="available", EmitDefaultValue=false)]
        public ByronwalletsBalanceAvailable Available { get; set; }

        /// <summary>
        /// Gets or Sets Total
        /// </summary>
        [DataMember(Name="total", EmitDefaultValue=false)]
        public ByronwalletsBalanceTotal Total { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ByronwalletsBalance {\n");
            sb.Append("  Available: ").Append(Available).Append("\n");
            sb.Append("  Total: ").Append(Total).Append("\n");
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
            return this.Equals(input as ByronwalletsBalance);
        }

        /// <summary>
        /// Returns true if ByronwalletsBalance instances are equal
        /// </summary>
        /// <param name="input">Instance of ByronwalletsBalance to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ByronwalletsBalance input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Available == input.Available ||
                    (this.Available != null &&
                    this.Available.Equals(input.Available))
                ) && 
                (
                    this.Total == input.Total ||
                    (this.Total != null &&
                    this.Total.Equals(input.Total))
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
                if (this.Available != null)
                    hashCode = hashCode * 59 + this.Available.GetHashCode();
                if (this.Total != null)
                    hashCode = hashCode * 59 + this.Total.GetHashCode();
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
