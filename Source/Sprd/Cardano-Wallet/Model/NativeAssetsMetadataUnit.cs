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
    /// Defines a larger unit for the asset, in the same way Ada is the larger unit of Lovelace. 
    /// </summary>
    [DataContract]
        public partial class NativeAssetsMetadataUnit :  IEquatable<NativeAssetsMetadataUnit>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NativeAssetsMetadataUnit" /> class.
        /// </summary>
        /// <param name="decimals">The number of digits after the decimal point.  (required).</param>
        /// <param name="name">The human-readable name for the larger unit of the asset. Used for display in user interfaces.  (required).</param>
        public NativeAssetsMetadataUnit(int? decimals = default(int?), string name = default(string))
        {
            // to ensure "decimals" is required (not null)
            if (decimals == null)
            {
                throw new InvalidDataException("decimals is a required property for NativeAssetsMetadataUnit and cannot be null");
            }
            else
            {
                this.Decimals = decimals;
            }
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new InvalidDataException("name is a required property for NativeAssetsMetadataUnit and cannot be null");
            }
            else
            {
                this.Name = name;
            }
        }
        
        /// <summary>
        /// The number of digits after the decimal point. 
        /// </summary>
        /// <value>The number of digits after the decimal point. </value>
        [DataMember(Name="decimals", EmitDefaultValue=false)]
        public int? Decimals { get; set; }

        /// <summary>
        /// The human-readable name for the larger unit of the asset. Used for display in user interfaces. 
        /// </summary>
        /// <value>The human-readable name for the larger unit of the asset. Used for display in user interfaces. </value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class NativeAssetsMetadataUnit {\n");
            sb.Append("  Decimals: ").Append(Decimals).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
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
            return this.Equals(input as NativeAssetsMetadataUnit);
        }

        /// <summary>
        /// Returns true if NativeAssetsMetadataUnit instances are equal
        /// </summary>
        /// <param name="input">Instance of NativeAssetsMetadataUnit to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NativeAssetsMetadataUnit input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Decimals == input.Decimals ||
                    (this.Decimals != null &&
                    this.Decimals.Equals(input.Decimals))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
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
                if (this.Decimals != null)
                    hashCode = hashCode * 59 + this.Decimals.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
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