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
    /// Information about the stake pool. 
    /// </summary>
    [DataContract]
        public partial class StakepoolsMetadata :  IEquatable<StakepoolsMetadata>, IValidatableObject
    {
        public StakepoolsMetadata(){}
        /// <summary>
        /// Initializes a new instance of the <see cref="StakepoolsMetadata" /> class.
        /// </summary>
        /// <param name="ticker">ticker (required).</param>
        /// <param name="name">name (required).</param>
        /// <param name="description">description.</param>
        /// <param name="homepage">homepage (required).</param>
        public StakepoolsMetadata(string ticker = default(string), string name = default(string), string description = default(string), string homepage = default(string))
        {
            // to ensure "ticker" is required (not null)
            if (ticker == null)
            {
                throw new InvalidDataException("ticker is a required property for StakepoolsMetadata and cannot be null");
            }
            else
            {
                this.Ticker = ticker;
            }
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new InvalidDataException("name is a required property for StakepoolsMetadata and cannot be null");
            }
            else
            {
                this.Name = name;
            }
            // to ensure "homepage" is required (not null)
            if (homepage == null)
            {
                throw new InvalidDataException("homepage is a required property for StakepoolsMetadata and cannot be null");
            }
            else
            {
                this.Homepage = homepage;
            }
            this.Description = description;
        }
        
        /// <summary>
        /// Gets or Sets Ticker
        /// </summary>
        [DataMember(Name="ticker", EmitDefaultValue=false)]
        public string Ticker { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Homepage
        /// </summary>
        [DataMember(Name="homepage", EmitDefaultValue=false)]
        public string Homepage { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StakepoolsMetadata {\n");
            sb.Append("  Ticker: ").Append(Ticker).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Homepage: ").Append(Homepage).Append("\n");
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
            return this.Equals(input as StakepoolsMetadata);
        }

        /// <summary>
        /// Returns true if StakepoolsMetadata instances are equal
        /// </summary>
        /// <param name="input">Instance of StakepoolsMetadata to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(StakepoolsMetadata input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Ticker == input.Ticker ||
                    (this.Ticker != null &&
                    this.Ticker.Equals(input.Ticker))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Homepage == input.Homepage ||
                    (this.Homepage != null &&
                    this.Homepage.Equals(input.Homepage))
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
                if (this.Ticker != null)
                    hashCode = hashCode * 59 + this.Ticker.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.Homepage != null)
                    hashCode = hashCode * 59 + this.Homepage.GetHashCode();
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
