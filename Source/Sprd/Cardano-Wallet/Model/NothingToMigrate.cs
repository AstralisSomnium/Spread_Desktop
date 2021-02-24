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
    /// NothingToMigrate
    /// </summary>
    [DataContract]
        public partial class NothingToMigrate :  IEquatable<NothingToMigrate>, IValidatableObject
    {
        /// <summary>
        /// Defines Code
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
                public enum CodeEnum
        {
            /// <summary>
            /// Enum Migrate for value: nothing_to_migrate
            /// </summary>
            [EnumMember(Value = "nothing_to_migrate")]
            Migrate = 1        }
        /// <summary>
        /// Gets or Sets Code
        /// </summary>
        [DataMember(Name="code", EmitDefaultValue=false)]
        public CodeEnum Code { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="NothingToMigrate" /> class.
        /// </summary>
        /// <param name="message">May occur when trying to migrate a wallet that is empty or full of dust. (required).</param>
        /// <param name="code">code (required).</param>
        public NothingToMigrate(string message = default(string), CodeEnum code = default(CodeEnum))
        {
            // to ensure "message" is required (not null)
            if (message == null)
            {
                throw new InvalidDataException("message is a required property for NothingToMigrate and cannot be null");
            }
            else
            {
                this.Message = message;
            }
            // to ensure "code" is required (not null)
            if (code == null)
            {
                throw new InvalidDataException("code is a required property for NothingToMigrate and cannot be null");
            }
            else
            {
                this.Code = code;
            }
        }
        
        /// <summary>
        /// May occur when trying to migrate a wallet that is empty or full of dust.
        /// </summary>
        /// <value>May occur when trying to migrate a wallet that is empty or full of dust.</value>
        [DataMember(Name="message", EmitDefaultValue=false)]
        public string Message { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class NothingToMigrate {\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
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
            return this.Equals(input as NothingToMigrate);
        }

        /// <summary>
        /// Returns true if NothingToMigrate instances are equal
        /// </summary>
        /// <param name="input">Instance of NothingToMigrate to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NothingToMigrate input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Message == input.Message ||
                    (this.Message != null &&
                    this.Message.Equals(input.Message))
                ) && 
                (
                    this.Code == input.Code ||
                    (this.Code != null &&
                    this.Code.Equals(input.Code))
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
                if (this.Message != null)
                    hashCode = hashCode * 59 + this.Message.GetHashCode();
                if (this.Code != null)
                    hashCode = hashCode * 59 + this.Code.GetHashCode();
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