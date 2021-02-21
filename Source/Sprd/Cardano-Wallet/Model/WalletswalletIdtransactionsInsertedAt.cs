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
    /// &lt;span style&#x3D;\&quot;position: relative; left: 35px; top: -21px; vertical-align: middle; background-color: rgba(142, 142, 220, 0.05); color: rgba(50, 50, 159, 0.9); margin: 0 5px; padding: 0 5px; border: 1px solid rgba(50, 50, 159, 0.1); line-height: 20px; font-size: 13px; border-radius: 2px;\&quot;&gt; &lt;strong&gt;if:&lt;/strong&gt; status &#x3D;&#x3D; in_ledger &lt;/span&gt;&lt;br/&gt; Absolute time at which the transaction was inserted in a block. 
    /// </summary>
    [DataContract]
        public partial class WalletswalletIdtransactionsInsertedAt :  IEquatable<WalletswalletIdtransactionsInsertedAt>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WalletswalletIdtransactionsInsertedAt" /> class.
        /// </summary>
        /// <param name="absoluteSlotNumber">The 0-based slot index starting from genesis of the blockchain. (required).</param>
        /// <param name="slotNumber">The zero-based slot index within an epoch. (required).</param>
        /// <param name="epochNumber">An epoch is a time period which is divided into slots. (required).</param>
        /// <param name="time">time (required).</param>
        /// <param name="height">height (required).</param>
        public WalletswalletIdtransactionsInsertedAt(int? absoluteSlotNumber = default(int?), int? slotNumber = default(int?), int? epochNumber = default(int?), string time = default(string), WalletsTipHeight height = default(WalletsTipHeight))
        {
            // to ensure "absoluteSlotNumber" is required (not null)
            if (absoluteSlotNumber == null)
            {
                throw new InvalidDataException("absoluteSlotNumber is a required property for WalletswalletIdtransactionsInsertedAt and cannot be null");
            }
            else
            {
                this.AbsoluteSlotNumber = absoluteSlotNumber;
            }
            // to ensure "slotNumber" is required (not null)
            if (slotNumber == null)
            {
                throw new InvalidDataException("slotNumber is a required property for WalletswalletIdtransactionsInsertedAt and cannot be null");
            }
            else
            {
                this.SlotNumber = slotNumber;
            }
            // to ensure "epochNumber" is required (not null)
            if (epochNumber == null)
            {
                throw new InvalidDataException("epochNumber is a required property for WalletswalletIdtransactionsInsertedAt and cannot be null");
            }
            else
            {
                this.EpochNumber = epochNumber;
            }
            // to ensure "time" is required (not null)
            if (time == null)
            {
                throw new InvalidDataException("time is a required property for WalletswalletIdtransactionsInsertedAt and cannot be null");
            }
            else
            {
                this.Time = time;
            }
            // to ensure "height" is required (not null)
            if (height == null)
            {
                throw new InvalidDataException("height is a required property for WalletswalletIdtransactionsInsertedAt and cannot be null");
            }
            else
            {
                this.Height = height;
            }
        }
        
        /// <summary>
        /// The 0-based slot index starting from genesis of the blockchain.
        /// </summary>
        /// <value>The 0-based slot index starting from genesis of the blockchain.</value>
        [DataMember(Name="absolute_slot_number", EmitDefaultValue=false)]
        public int? AbsoluteSlotNumber { get; set; }

        /// <summary>
        /// The zero-based slot index within an epoch.
        /// </summary>
        /// <value>The zero-based slot index within an epoch.</value>
        [DataMember(Name="slot_number", EmitDefaultValue=false)]
        public int? SlotNumber { get; set; }

        /// <summary>
        /// An epoch is a time period which is divided into slots.
        /// </summary>
        /// <value>An epoch is a time period which is divided into slots.</value>
        [DataMember(Name="epoch_number", EmitDefaultValue=false)]
        public int? EpochNumber { get; set; }

        /// <summary>
        /// Gets or Sets Time
        /// </summary>
        [DataMember(Name="time", EmitDefaultValue=false)]
        public string Time { get; set; }

        /// <summary>
        /// Gets or Sets Height
        /// </summary>
        [DataMember(Name="height", EmitDefaultValue=false)]
        public WalletsTipHeight Height { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class WalletswalletIdtransactionsInsertedAt {\n");
            sb.Append("  AbsoluteSlotNumber: ").Append(AbsoluteSlotNumber).Append("\n");
            sb.Append("  SlotNumber: ").Append(SlotNumber).Append("\n");
            sb.Append("  EpochNumber: ").Append(EpochNumber).Append("\n");
            sb.Append("  Time: ").Append(Time).Append("\n");
            sb.Append("  Height: ").Append(Height).Append("\n");
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
            return this.Equals(input as WalletswalletIdtransactionsInsertedAt);
        }

        /// <summary>
        /// Returns true if WalletswalletIdtransactionsInsertedAt instances are equal
        /// </summary>
        /// <param name="input">Instance of WalletswalletIdtransactionsInsertedAt to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WalletswalletIdtransactionsInsertedAt input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.AbsoluteSlotNumber == input.AbsoluteSlotNumber ||
                    (this.AbsoluteSlotNumber != null &&
                    this.AbsoluteSlotNumber.Equals(input.AbsoluteSlotNumber))
                ) && 
                (
                    this.SlotNumber == input.SlotNumber ||
                    (this.SlotNumber != null &&
                    this.SlotNumber.Equals(input.SlotNumber))
                ) && 
                (
                    this.EpochNumber == input.EpochNumber ||
                    (this.EpochNumber != null &&
                    this.EpochNumber.Equals(input.EpochNumber))
                ) && 
                (
                    this.Time == input.Time ||
                    (this.Time != null &&
                    this.Time.Equals(input.Time))
                ) && 
                (
                    this.Height == input.Height ||
                    (this.Height != null &&
                    this.Height.Equals(input.Height))
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
                if (this.AbsoluteSlotNumber != null)
                    hashCode = hashCode * 59 + this.AbsoluteSlotNumber.GetHashCode();
                if (this.SlotNumber != null)
                    hashCode = hashCode * 59 + this.SlotNumber.GetHashCode();
                if (this.EpochNumber != null)
                    hashCode = hashCode * 59 + this.EpochNumber.GetHashCode();
                if (this.Time != null)
                    hashCode = hashCode * 59 + this.Time.GetHashCode();
                if (this.Height != null)
                    hashCode = hashCode * 59 + this.Height.GetHashCode();
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
