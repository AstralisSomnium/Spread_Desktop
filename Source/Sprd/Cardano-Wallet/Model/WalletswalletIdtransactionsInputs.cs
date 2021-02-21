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
    /// WalletswalletIdtransactionsInputs
    /// </summary>
    [DataContract]
        public partial class WalletswalletIdtransactionsInputs :  IEquatable<WalletswalletIdtransactionsInputs>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WalletswalletIdtransactionsInputs" /> class.
        /// </summary>
        /// <param name="address">address.</param>
        /// <param name="amount">amount.</param>
        /// <param name="assets">A flat list of assets..</param>
        /// <param name="id">A unique identifier for this transaction (required).</param>
        /// <param name="index">index (required).</param>
        public WalletswalletIdtransactionsInputs(string address = default(string), WalletswalletIdpaymentfeesAmount amount = default(WalletswalletIdpaymentfeesAmount), List<WalletsAssetsAvailable> assets = default(List<WalletsAssetsAvailable>), string id = default(string), int? index = default(int?))
        {
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new InvalidDataException("id is a required property for WalletswalletIdtransactionsInputs and cannot be null");
            }
            else
            {
                this.Id = id;
            }
            // to ensure "index" is required (not null)
            if (index == null)
            {
                throw new InvalidDataException("index is a required property for WalletswalletIdtransactionsInputs and cannot be null");
            }
            else
            {
                this.Index = index;
            }
            this.Address = address;
            this.Amount = amount;
            this.Assets = assets;
        }
        
        /// <summary>
        /// Gets or Sets Address
        /// </summary>
        [DataMember(Name="address", EmitDefaultValue=false)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or Sets Amount
        /// </summary>
        [DataMember(Name="amount", EmitDefaultValue=false)]
        public WalletswalletIdpaymentfeesAmount Amount { get; set; }

        /// <summary>
        /// A flat list of assets.
        /// </summary>
        /// <value>A flat list of assets.</value>
        [DataMember(Name="assets", EmitDefaultValue=false)]
        public List<WalletsAssetsAvailable> Assets { get; set; }

        /// <summary>
        /// A unique identifier for this transaction
        /// </summary>
        /// <value>A unique identifier for this transaction</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Index
        /// </summary>
        [DataMember(Name="index", EmitDefaultValue=false)]
        public int? Index { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class WalletswalletIdtransactionsInputs {\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  Assets: ").Append(Assets).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Index: ").Append(Index).Append("\n");
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
            return this.Equals(input as WalletswalletIdtransactionsInputs);
        }

        /// <summary>
        /// Returns true if WalletswalletIdtransactionsInputs instances are equal
        /// </summary>
        /// <param name="input">Instance of WalletswalletIdtransactionsInputs to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WalletswalletIdtransactionsInputs input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Address == input.Address ||
                    (this.Address != null &&
                    this.Address.Equals(input.Address))
                ) && 
                (
                    this.Amount == input.Amount ||
                    (this.Amount != null &&
                    this.Amount.Equals(input.Amount))
                ) && 
                (
                    this.Assets == input.Assets ||
                    this.Assets != null &&
                    input.Assets != null &&
                    this.Assets.SequenceEqual(input.Assets)
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Index == input.Index ||
                    (this.Index != null &&
                    this.Index.Equals(input.Index))
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
                if (this.Address != null)
                    hashCode = hashCode * 59 + this.Address.GetHashCode();
                if (this.Amount != null)
                    hashCode = hashCode * 59 + this.Amount.GetHashCode();
                if (this.Assets != null)
                    hashCode = hashCode * 59 + this.Assets.GetHashCode();
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Index != null)
                    hashCode = hashCode * 59 + this.Index.GetHashCode();
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
