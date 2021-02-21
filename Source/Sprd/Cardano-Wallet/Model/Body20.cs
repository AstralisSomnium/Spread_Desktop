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
    /// Body20
    /// </summary>
    [DataContract]
        public partial class Body20 :  IEquatable<Body20>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Body20" /> class.
        /// </summary>
        /// <param name="passphrase">The wallet&#x27;s master passphrase. (required).</param>
        /// <param name="addresses">The recipient addresses. (required).</param>
        public Body20(string passphrase = default(string), List<string> addresses = default(List<string>))
        {
            // to ensure "passphrase" is required (not null)
            if (passphrase == null)
            {
                throw new InvalidDataException("passphrase is a required property for Body20 and cannot be null");
            }
            else
            {
                this.Passphrase = passphrase;
            }
            // to ensure "addresses" is required (not null)
            if (addresses == null)
            {
                throw new InvalidDataException("addresses is a required property for Body20 and cannot be null");
            }
            else
            {
                this.Addresses = addresses;
            }
        }
        
        /// <summary>
        /// The wallet&#x27;s master passphrase.
        /// </summary>
        /// <value>The wallet&#x27;s master passphrase.</value>
        [DataMember(Name="passphrase", EmitDefaultValue=false)]
        public string Passphrase { get; set; }

        /// <summary>
        /// The recipient addresses.
        /// </summary>
        /// <value>The recipient addresses.</value>
        [DataMember(Name="addresses", EmitDefaultValue=false)]
        public List<string> Addresses { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Body20 {\n");
            sb.Append("  Passphrase: ").Append(Passphrase).Append("\n");
            sb.Append("  Addresses: ").Append(Addresses).Append("\n");
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
            return this.Equals(input as Body20);
        }

        /// <summary>
        /// Returns true if Body20 instances are equal
        /// </summary>
        /// <param name="input">Instance of Body20 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Body20 input)
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
                    this.Addresses == input.Addresses ||
                    this.Addresses != null &&
                    input.Addresses != null &&
                    this.Addresses.SequenceEqual(input.Addresses)
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
                if (this.Addresses != null)
                    hashCode = hashCode * 59 + this.Addresses.GetHashCode();
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
