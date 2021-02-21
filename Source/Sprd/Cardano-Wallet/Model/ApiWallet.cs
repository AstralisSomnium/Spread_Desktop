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
    /// ApiWallet
    /// </summary>
    [DataContract]
        public partial class ApiWallet :  IEquatable<ApiWallet>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiWallet" /> class.
        /// </summary>
        /// <param name="id">A unique identifier for the wallet (required).</param>
        /// <param name="addressPoolGap">Number of consecutive unused addresses allowed.  **IMPORTANT DISCLAIMER:** Using values other than &#x60;20&#x60; automatically makes your wallet invalid with regards to BIP-44 address discovery. It means that you **will not** be able to fully restore your wallet in a different software which is strictly following BIP-44.  Beside, using large gaps is **not recommended** as it may induce important performance degradations. Use at your own risks.  (required) (default to 20).</param>
        /// <param name="balance">balance (required).</param>
        /// <param name="assets">assets (required).</param>
        /// <param name="delegation">delegation (required).</param>
        /// <param name="name">name (required).</param>
        /// <param name="passphrase">passphrase.</param>
        /// <param name="state">state (required).</param>
        /// <param name="tip">tip (required).</param>
        public ApiWallet(string id = default(string), int? addressPoolGap = 20, WalletsBalance balance = default(WalletsBalance), WalletsAssets assets = default(WalletsAssets), WalletsDelegation delegation = default(WalletsDelegation), string name = default(string), WalletsPassphrase passphrase = default(WalletsPassphrase), WalletsState state = default(WalletsState), WalletsTip tip = default(WalletsTip))
        {
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new InvalidDataException("id is a required property for ApiWallet and cannot be null");
            }
            else
            {
                this.Id = id;
            }
            // to ensure "addressPoolGap" is required (not null)
            if (addressPoolGap == null)
            {
                throw new InvalidDataException("addressPoolGap is a required property for ApiWallet and cannot be null");
            }
            else
            {
                this.AddressPoolGap = addressPoolGap;
            }
            // to ensure "balance" is required (not null)
            if (balance == null)
            {
                throw new InvalidDataException("balance is a required property for ApiWallet and cannot be null");
            }
            else
            {
                this.Balance = balance;
            }
            // to ensure "assets" is required (not null)
            if (assets == null)
            {
                throw new InvalidDataException("assets is a required property for ApiWallet and cannot be null");
            }
            else
            {
                this.Assets = assets;
            }
            // to ensure "delegation" is required (not null)
            if (delegation == null)
            {
                throw new InvalidDataException("delegation is a required property for ApiWallet and cannot be null");
            }
            else
            {
                this.Delegation = delegation;
            }
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new InvalidDataException("name is a required property for ApiWallet and cannot be null");
            }
            else
            {
                this.Name = name;
            }
            // to ensure "state" is required (not null)
            if (state == null)
            {
                throw new InvalidDataException("state is a required property for ApiWallet and cannot be null");
            }
            else
            {
                this.State = state;
            }
            // to ensure "tip" is required (not null)
            if (tip == null)
            {
                throw new InvalidDataException("tip is a required property for ApiWallet and cannot be null");
            }
            else
            {
                this.Tip = tip;
            }
            this.Passphrase = passphrase;
        }
        
        /// <summary>
        /// A unique identifier for the wallet
        /// </summary>
        /// <value>A unique identifier for the wallet</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// Number of consecutive unused addresses allowed.  **IMPORTANT DISCLAIMER:** Using values other than &#x60;20&#x60; automatically makes your wallet invalid with regards to BIP-44 address discovery. It means that you **will not** be able to fully restore your wallet in a different software which is strictly following BIP-44.  Beside, using large gaps is **not recommended** as it may induce important performance degradations. Use at your own risks. 
        /// </summary>
        /// <value>Number of consecutive unused addresses allowed.  **IMPORTANT DISCLAIMER:** Using values other than &#x60;20&#x60; automatically makes your wallet invalid with regards to BIP-44 address discovery. It means that you **will not** be able to fully restore your wallet in a different software which is strictly following BIP-44.  Beside, using large gaps is **not recommended** as it may induce important performance degradations. Use at your own risks. </value>
        [DataMember(Name="address_pool_gap", EmitDefaultValue=false)]
        public int? AddressPoolGap { get; set; }

        /// <summary>
        /// Gets or Sets Balance
        /// </summary>
        [DataMember(Name="balance", EmitDefaultValue=false)]
        public WalletsBalance Balance { get; set; }

        /// <summary>
        /// Gets or Sets Assets
        /// </summary>
        [DataMember(Name="assets", EmitDefaultValue=false)]
        public WalletsAssets Assets { get; set; }

        /// <summary>
        /// Gets or Sets Delegation
        /// </summary>
        [DataMember(Name="delegation", EmitDefaultValue=false)]
        public WalletsDelegation Delegation { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Passphrase
        /// </summary>
        [DataMember(Name="passphrase", EmitDefaultValue=false)]
        public WalletsPassphrase Passphrase { get; set; }

        /// <summary>
        /// Gets or Sets State
        /// </summary>
        [DataMember(Name="state", EmitDefaultValue=false)]
        public WalletsState State { get; set; }

        /// <summary>
        /// Gets or Sets Tip
        /// </summary>
        [DataMember(Name="tip", EmitDefaultValue=false)]
        public WalletsTip Tip { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ApiWallet {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  AddressPoolGap: ").Append(AddressPoolGap).Append("\n");
            sb.Append("  Balance: ").Append(Balance).Append("\n");
            sb.Append("  Assets: ").Append(Assets).Append("\n");
            sb.Append("  Delegation: ").Append(Delegation).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Passphrase: ").Append(Passphrase).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  Tip: ").Append(Tip).Append("\n");
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
            return this.Equals(input as ApiWallet);
        }

        /// <summary>
        /// Returns true if ApiWallet instances are equal
        /// </summary>
        /// <param name="input">Instance of ApiWallet to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ApiWallet input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.AddressPoolGap == input.AddressPoolGap ||
                    (this.AddressPoolGap != null &&
                    this.AddressPoolGap.Equals(input.AddressPoolGap))
                ) && 
                (
                    this.Balance == input.Balance ||
                    (this.Balance != null &&
                    this.Balance.Equals(input.Balance))
                ) && 
                (
                    this.Assets == input.Assets ||
                    (this.Assets != null &&
                    this.Assets.Equals(input.Assets))
                ) && 
                (
                    this.Delegation == input.Delegation ||
                    (this.Delegation != null &&
                    this.Delegation.Equals(input.Delegation))
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
                    this.State == input.State ||
                    (this.State != null &&
                    this.State.Equals(input.State))
                ) && 
                (
                    this.Tip == input.Tip ||
                    (this.Tip != null &&
                    this.Tip.Equals(input.Tip))
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
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.AddressPoolGap != null)
                    hashCode = hashCode * 59 + this.AddressPoolGap.GetHashCode();
                if (this.Balance != null)
                    hashCode = hashCode * 59 + this.Balance.GetHashCode();
                if (this.Assets != null)
                    hashCode = hashCode * 59 + this.Assets.GetHashCode();
                if (this.Delegation != null)
                    hashCode = hashCode * 59 + this.Delegation.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Passphrase != null)
                    hashCode = hashCode * 59 + this.Passphrase.GetHashCode();
                if (this.State != null)
                    hashCode = hashCode * 59 + this.State.GetHashCode();
                if (this.Tip != null)
                    hashCode = hashCode * 59 + this.Tip.GetHashCode();
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
