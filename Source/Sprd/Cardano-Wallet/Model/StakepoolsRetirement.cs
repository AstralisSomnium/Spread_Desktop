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
    /// The epoch in which a stake pool retires.  May be omitted if the wallet hasn&#x27;t yet found a retirement certificate for this stake pool. 
    /// </summary>
    [DataContract]
        public partial class StakepoolsRetirement :  IEquatable<StakepoolsRetirement>, IValidatableObject
    {
        public StakepoolsRetirement(){}
        /// <summary>
        /// Initializes a new instance of the <see cref="StakepoolsRetirement" /> class.
        /// </summary>
        /// <param name="epochNumber">An epoch is a time period which is divided into slots. (required).</param>
        /// <param name="epochStartTime">epochStartTime (required).</param>
        public StakepoolsRetirement(int? epochNumber = default(int?), string epochStartTime = default(string))
        {
            // to ensure "epochNumber" is required (not null)
            if (epochNumber == null)
            {
                throw new InvalidDataException("epochNumber is a required property for StakepoolsRetirement and cannot be null");
            }
            else
            {
                this.EpochNumber = epochNumber;
            }
            // to ensure "epochStartTime" is required (not null)
            if (epochStartTime == null)
            {
                throw new InvalidDataException("epochStartTime is a required property for StakepoolsRetirement and cannot be null");
            }
            else
            {
                this.EpochStartTime = epochStartTime;
            }
        }
        
        /// <summary>
        /// An epoch is a time period which is divided into slots.
        /// </summary>
        /// <value>An epoch is a time period which is divided into slots.</value>
        [DataMember(Name="epoch_number", EmitDefaultValue=false)]
        public int? EpochNumber { get; set; }

        /// <summary>
        /// Gets or Sets EpochStartTime
        /// </summary>
        [DataMember(Name="epoch_start_time", EmitDefaultValue=false)]
        public string EpochStartTime { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StakepoolsRetirement {\n");
            sb.Append("  EpochNumber: ").Append(EpochNumber).Append("\n");
            sb.Append("  EpochStartTime: ").Append(EpochStartTime).Append("\n");
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
            return this.Equals(input as StakepoolsRetirement);
        }

        /// <summary>
        /// Returns true if StakepoolsRetirement instances are equal
        /// </summary>
        /// <param name="input">Instance of StakepoolsRetirement to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(StakepoolsRetirement input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.EpochNumber == input.EpochNumber ||
                    (this.EpochNumber != null &&
                    this.EpochNumber.Equals(input.EpochNumber))
                ) && 
                (
                    this.EpochStartTime == input.EpochStartTime ||
                    (this.EpochStartTime != null &&
                    this.EpochStartTime.Equals(input.EpochStartTime))
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
                if (this.EpochNumber != null)
                    hashCode = hashCode * 59 + this.EpochNumber.GetHashCode();
                if (this.EpochStartTime != null)
                    hashCode = hashCode * 59 + this.EpochStartTime.GetHashCode();
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
