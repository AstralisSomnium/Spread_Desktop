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
    /// ApiByronWalletRandomPostData
    /// </summary>
    [DataContract]
        public partial class ApiByronWalletRandomPostData :  IEquatable<ApiByronWalletRandomPostData>, IValidatableObject
    {
        /// <summary>
        /// Defines Style
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
                public enum StyleEnum
        {
            /// <summary>
            /// Enum Random for value: random
            /// </summary>
            [EnumMember(Value = "random")]
            Random = 1        }
        /// <summary>
        /// Gets or Sets Style
        /// </summary>
        [DataMember(Name="style", EmitDefaultValue=false)]
        public StyleEnum? Style { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiByronWalletRandomPostData" /> class.
        /// </summary>
        /// <param name="style">style.</param>
        /// <param name="name">name (required).</param>
        /// <param name="passphrase">A master passphrase to lock and protect the wallet for sensitive operation (e.g. sending funds) (required).</param>
        /// <param name="mnemonicSentence">A list of mnemonic words (required).</param>
        public ApiByronWalletRandomPostData(StyleEnum? style = default(StyleEnum?), string name = default(string), string passphrase = default(string), List<string> mnemonicSentence = default(List<string>))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new InvalidDataException("name is a required property for ApiByronWalletRandomPostData and cannot be null");
            }
            else
            {
                this.Name = name;
            }
            // to ensure "passphrase" is required (not null)
            if (passphrase == null)
            {
                throw new InvalidDataException("passphrase is a required property for ApiByronWalletRandomPostData and cannot be null");
            }
            else
            {
                this.Passphrase = passphrase;
            }
            // to ensure "mnemonicSentence" is required (not null)
            if (mnemonicSentence == null)
            {
                throw new InvalidDataException("mnemonicSentence is a required property for ApiByronWalletRandomPostData and cannot be null");
            }
            else
            {
                this.MnemonicSentence = mnemonicSentence;
            }
            this.Style = style;
        }
        

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// A master passphrase to lock and protect the wallet for sensitive operation (e.g. sending funds)
        /// </summary>
        /// <value>A master passphrase to lock and protect the wallet for sensitive operation (e.g. sending funds)</value>
        [DataMember(Name="passphrase", EmitDefaultValue=false)]
        public string Passphrase { get; set; }

        /// <summary>
        /// A list of mnemonic words
        /// </summary>
        /// <value>A list of mnemonic words</value>
        [DataMember(Name="mnemonic_sentence", EmitDefaultValue=false)]
        public List<string> MnemonicSentence { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ApiByronWalletRandomPostData {\n");
            sb.Append("  Style: ").Append(Style).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Passphrase: ").Append(Passphrase).Append("\n");
            sb.Append("  MnemonicSentence: ").Append(MnemonicSentence).Append("\n");
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
            return this.Equals(input as ApiByronWalletRandomPostData);
        }

        /// <summary>
        /// Returns true if ApiByronWalletRandomPostData instances are equal
        /// </summary>
        /// <param name="input">Instance of ApiByronWalletRandomPostData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ApiByronWalletRandomPostData input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Style == input.Style ||
                    (this.Style != null &&
                    this.Style.Equals(input.Style))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Passphrase == input.Passphrase ||
                    (this.Passphrase != null &&
                    this.Passphrase.Equals(input.Passphrase))
                ) && 
                (
                    this.MnemonicSentence == input.MnemonicSentence ||
                    this.MnemonicSentence != null &&
                    input.MnemonicSentence != null &&
                    this.MnemonicSentence.SequenceEqual(input.MnemonicSentence)
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
                if (this.Style != null)
                    hashCode = hashCode * 59 + this.Style.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Passphrase != null)
                    hashCode = hashCode * 59 + this.Passphrase.GetHashCode();
                if (this.MnemonicSentence != null)
                    hashCode = hashCode * 59 + this.MnemonicSentence.GetHashCode();
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