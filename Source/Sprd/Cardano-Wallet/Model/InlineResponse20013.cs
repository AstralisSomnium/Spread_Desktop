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
    /// InlineResponse20013
    /// </summary>
    [DataContract]
        public partial class InlineResponse20013 :  IEquatable<InlineResponse20013>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InlineResponse20013" /> class.
        /// </summary>
        /// <param name="genesisBlockHash">The hash of genesis block (required).</param>
        /// <param name="blockchainStartTime">blockchainStartTime (required).</param>
        /// <param name="slotLength">slotLength (required).</param>
        /// <param name="epochLength">epochLength (required).</param>
        /// <param name="securityParameter">securityParameter (required).</param>
        /// <param name="activeSlotCoefficient">activeSlotCoefficient (required).</param>
        /// <param name="decentralizationLevel">decentralizationLevel (required).</param>
        /// <param name="desiredPoolNumber">desiredPoolNumber (required).</param>
        /// <param name="minimumUtxoValue">minimumUtxoValue (required).</param>
        /// <param name="eras">eras (required).</param>
        public InlineResponse20013(string genesisBlockHash = default(string), string blockchainStartTime = default(string), ApiNetworkParametersSlotLength slotLength = default(ApiNetworkParametersSlotLength), ApiNetworkParametersEpochLength epochLength = default(ApiNetworkParametersEpochLength), WalletsTipHeight securityParameter = default(WalletsTipHeight), ApiNetworkParametersActiveSlotCoefficient activeSlotCoefficient = default(ApiNetworkParametersActiveSlotCoefficient), ApiNetworkParametersActiveSlotCoefficient decentralizationLevel = default(ApiNetworkParametersActiveSlotCoefficient), int? desiredPoolNumber = default(int?), WalletswalletIdpaymentfeesAmount minimumUtxoValue = default(WalletswalletIdpaymentfeesAmount), ApiNetworkParametersEras eras = default(ApiNetworkParametersEras))
        {
            // to ensure "genesisBlockHash" is required (not null)
            if (genesisBlockHash == null)
            {
                throw new InvalidDataException("genesisBlockHash is a required property for InlineResponse20013 and cannot be null");
            }
            else
            {
                this.GenesisBlockHash = genesisBlockHash;
            }
            // to ensure "blockchainStartTime" is required (not null)
            if (blockchainStartTime == null)
            {
                throw new InvalidDataException("blockchainStartTime is a required property for InlineResponse20013 and cannot be null");
            }
            else
            {
                this.BlockchainStartTime = blockchainStartTime;
            }
            // to ensure "slotLength" is required (not null)
            if (slotLength == null)
            {
                throw new InvalidDataException("slotLength is a required property for InlineResponse20013 and cannot be null");
            }
            else
            {
                this.SlotLength = slotLength;
            }
            // to ensure "epochLength" is required (not null)
            if (epochLength == null)
            {
                throw new InvalidDataException("epochLength is a required property for InlineResponse20013 and cannot be null");
            }
            else
            {
                this.EpochLength = epochLength;
            }
            // to ensure "securityParameter" is required (not null)
            if (securityParameter == null)
            {
                throw new InvalidDataException("securityParameter is a required property for InlineResponse20013 and cannot be null");
            }
            else
            {
                this.SecurityParameter = securityParameter;
            }
            // to ensure "activeSlotCoefficient" is required (not null)
            if (activeSlotCoefficient == null)
            {
                throw new InvalidDataException("activeSlotCoefficient is a required property for InlineResponse20013 and cannot be null");
            }
            else
            {
                this.ActiveSlotCoefficient = activeSlotCoefficient;
            }
            // to ensure "decentralizationLevel" is required (not null)
            if (decentralizationLevel == null)
            {
                throw new InvalidDataException("decentralizationLevel is a required property for InlineResponse20013 and cannot be null");
            }
            else
            {
                this.DecentralizationLevel = decentralizationLevel;
            }
            // to ensure "desiredPoolNumber" is required (not null)
            if (desiredPoolNumber == null)
            {
                throw new InvalidDataException("desiredPoolNumber is a required property for InlineResponse20013 and cannot be null");
            }
            else
            {
                this.DesiredPoolNumber = desiredPoolNumber;
            }
            // to ensure "minimumUtxoValue" is required (not null)
            if (minimumUtxoValue == null)
            {
                throw new InvalidDataException("minimumUtxoValue is a required property for InlineResponse20013 and cannot be null");
            }
            else
            {
                this.MinimumUtxoValue = minimumUtxoValue;
            }
            // to ensure "eras" is required (not null)
            if (eras == null)
            {
                throw new InvalidDataException("eras is a required property for InlineResponse20013 and cannot be null");
            }
            else
            {
                this.Eras = eras;
            }
        }
        
        /// <summary>
        /// The hash of genesis block
        /// </summary>
        /// <value>The hash of genesis block</value>
        [DataMember(Name="genesis_block_hash", EmitDefaultValue=false)]
        public string GenesisBlockHash { get; set; }

        /// <summary>
        /// Gets or Sets BlockchainStartTime
        /// </summary>
        [DataMember(Name="blockchain_start_time", EmitDefaultValue=false)]
        public string BlockchainStartTime { get; set; }

        /// <summary>
        /// Gets or Sets SlotLength
        /// </summary>
        [DataMember(Name="slot_length", EmitDefaultValue=false)]
        public ApiNetworkParametersSlotLength SlotLength { get; set; }

        /// <summary>
        /// Gets or Sets EpochLength
        /// </summary>
        [DataMember(Name="epoch_length", EmitDefaultValue=false)]
        public ApiNetworkParametersEpochLength EpochLength { get; set; }

        /// <summary>
        /// Gets or Sets SecurityParameter
        /// </summary>
        [DataMember(Name="security_parameter", EmitDefaultValue=false)]
        public WalletsTipHeight SecurityParameter { get; set; }

        /// <summary>
        /// Gets or Sets ActiveSlotCoefficient
        /// </summary>
        [DataMember(Name="active_slot_coefficient", EmitDefaultValue=false)]
        public ApiNetworkParametersActiveSlotCoefficient ActiveSlotCoefficient { get; set; }

        /// <summary>
        /// Gets or Sets DecentralizationLevel
        /// </summary>
        [DataMember(Name="decentralization_level", EmitDefaultValue=false)]
        public ApiNetworkParametersActiveSlotCoefficient DecentralizationLevel { get; set; }

        /// <summary>
        /// Gets or Sets DesiredPoolNumber
        /// </summary>
        [DataMember(Name="desired_pool_number", EmitDefaultValue=false)]
        public int? DesiredPoolNumber { get; set; }

        /// <summary>
        /// Gets or Sets MinimumUtxoValue
        /// </summary>
        [DataMember(Name="minimum_utxo_value", EmitDefaultValue=false)]
        public WalletswalletIdpaymentfeesAmount MinimumUtxoValue { get; set; }

        /// <summary>
        /// Gets or Sets Eras
        /// </summary>
        [DataMember(Name="eras", EmitDefaultValue=false)]
        public ApiNetworkParametersEras Eras { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InlineResponse20013 {\n");
            sb.Append("  GenesisBlockHash: ").Append(GenesisBlockHash).Append("\n");
            sb.Append("  BlockchainStartTime: ").Append(BlockchainStartTime).Append("\n");
            sb.Append("  SlotLength: ").Append(SlotLength).Append("\n");
            sb.Append("  EpochLength: ").Append(EpochLength).Append("\n");
            sb.Append("  SecurityParameter: ").Append(SecurityParameter).Append("\n");
            sb.Append("  ActiveSlotCoefficient: ").Append(ActiveSlotCoefficient).Append("\n");
            sb.Append("  DecentralizationLevel: ").Append(DecentralizationLevel).Append("\n");
            sb.Append("  DesiredPoolNumber: ").Append(DesiredPoolNumber).Append("\n");
            sb.Append("  MinimumUtxoValue: ").Append(MinimumUtxoValue).Append("\n");
            sb.Append("  Eras: ").Append(Eras).Append("\n");
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
            return this.Equals(input as InlineResponse20013);
        }

        /// <summary>
        /// Returns true if InlineResponse20013 instances are equal
        /// </summary>
        /// <param name="input">Instance of InlineResponse20013 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InlineResponse20013 input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.GenesisBlockHash == input.GenesisBlockHash ||
                    (this.GenesisBlockHash != null &&
                    this.GenesisBlockHash.Equals(input.GenesisBlockHash))
                ) && 
                (
                    this.BlockchainStartTime == input.BlockchainStartTime ||
                    (this.BlockchainStartTime != null &&
                    this.BlockchainStartTime.Equals(input.BlockchainStartTime))
                ) && 
                (
                    this.SlotLength == input.SlotLength ||
                    (this.SlotLength != null &&
                    this.SlotLength.Equals(input.SlotLength))
                ) && 
                (
                    this.EpochLength == input.EpochLength ||
                    (this.EpochLength != null &&
                    this.EpochLength.Equals(input.EpochLength))
                ) && 
                (
                    this.SecurityParameter == input.SecurityParameter ||
                    (this.SecurityParameter != null &&
                    this.SecurityParameter.Equals(input.SecurityParameter))
                ) && 
                (
                    this.ActiveSlotCoefficient == input.ActiveSlotCoefficient ||
                    (this.ActiveSlotCoefficient != null &&
                    this.ActiveSlotCoefficient.Equals(input.ActiveSlotCoefficient))
                ) && 
                (
                    this.DecentralizationLevel == input.DecentralizationLevel ||
                    (this.DecentralizationLevel != null &&
                    this.DecentralizationLevel.Equals(input.DecentralizationLevel))
                ) && 
                (
                    this.DesiredPoolNumber == input.DesiredPoolNumber ||
                    (this.DesiredPoolNumber != null &&
                    this.DesiredPoolNumber.Equals(input.DesiredPoolNumber))
                ) && 
                (
                    this.MinimumUtxoValue == input.MinimumUtxoValue ||
                    (this.MinimumUtxoValue != null &&
                    this.MinimumUtxoValue.Equals(input.MinimumUtxoValue))
                ) && 
                (
                    this.Eras == input.Eras ||
                    (this.Eras != null &&
                    this.Eras.Equals(input.Eras))
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
                if (this.GenesisBlockHash != null)
                    hashCode = hashCode * 59 + this.GenesisBlockHash.GetHashCode();
                if (this.BlockchainStartTime != null)
                    hashCode = hashCode * 59 + this.BlockchainStartTime.GetHashCode();
                if (this.SlotLength != null)
                    hashCode = hashCode * 59 + this.SlotLength.GetHashCode();
                if (this.EpochLength != null)
                    hashCode = hashCode * 59 + this.EpochLength.GetHashCode();
                if (this.SecurityParameter != null)
                    hashCode = hashCode * 59 + this.SecurityParameter.GetHashCode();
                if (this.ActiveSlotCoefficient != null)
                    hashCode = hashCode * 59 + this.ActiveSlotCoefficient.GetHashCode();
                if (this.DecentralizationLevel != null)
                    hashCode = hashCode * 59 + this.DecentralizationLevel.GetHashCode();
                if (this.DesiredPoolNumber != null)
                    hashCode = hashCode * 59 + this.DesiredPoolNumber.GetHashCode();
                if (this.MinimumUtxoValue != null)
                    hashCode = hashCode * 59 + this.MinimumUtxoValue.GetHashCode();
                if (this.Eras != null)
                    hashCode = hashCode * 59 + this.Eras.GetHashCode();
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
