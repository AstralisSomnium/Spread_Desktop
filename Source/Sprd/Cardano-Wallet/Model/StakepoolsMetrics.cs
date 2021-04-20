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
    /// StakepoolsMetrics
    /// </summary>
    [DataContract]
        public partial class StakepoolsMetrics :  IEquatable<StakepoolsMetrics>, IValidatableObject
    {

        public StakepoolsMetrics(){}
        /// <summary>
        /// Initializes a new instance of the <see cref="StakepoolsMetrics" /> class.
        /// </summary>
        /// <param name="nonMyopicMemberRewards">nonMyopicMemberRewards (required).</param>
        /// <param name="relativeStake">relativeStake (required).</param>
        /// <param name="saturation">Saturation-level of the pool based on the desired number of pools aimed by the network. A value above &#x60;1&#x60; indicates that the pool is saturated.  The &#x60;non_myopic_member_rewards&#x60; take oversaturation into account, as specified by the [specs](https://hydra.iohk.io/job/Cardano/cardano-ledger-specs/delegationDesignSpec/latest/download-by-type/doc-pdf/delegation_design_spec).  The saturation is based on the live &#x60;relative_stake&#x60;. The saturation at the end of epoch e, will affect the rewards paid out at the end of epoch e+3.  (required).</param>
        /// <param name="producedBlocks">producedBlocks (required).</param>
        public StakepoolsMetrics(StakepoolsMetricsNonMyopicMemberRewards nonMyopicMemberRewards = default(StakepoolsMetricsNonMyopicMemberRewards), StakepoolsMetricsRelativeStake relativeStake = default(StakepoolsMetricsRelativeStake), decimal? saturation = default(decimal?), StakepoolsMetricsProducedBlocks producedBlocks = default(StakepoolsMetricsProducedBlocks))
        {
            // to ensure "nonMyopicMemberRewards" is required (not null)
            if (nonMyopicMemberRewards == null)
            {
                throw new InvalidDataException("nonMyopicMemberRewards is a required property for StakepoolsMetrics and cannot be null");
            }
            else
            {
                this.NonMyopicMemberRewards = nonMyopicMemberRewards;
            }
            // to ensure "relativeStake" is required (not null)
            if (relativeStake == null)
            {
                throw new InvalidDataException("relativeStake is a required property for StakepoolsMetrics and cannot be null");
            }
            else
            {
                this.RelativeStake = relativeStake;
            }
            // to ensure "saturation" is required (not null)
            if (saturation == null)
            {
                throw new InvalidDataException("saturation is a required property for StakepoolsMetrics and cannot be null");
            }
            else
            {
                this.Saturation = saturation;
            }
            // to ensure "producedBlocks" is required (not null)
            if (producedBlocks == null)
            {
                throw new InvalidDataException("producedBlocks is a required property for StakepoolsMetrics and cannot be null");
            }
            else
            {
                this.ProducedBlocks = producedBlocks;
            }
        }
        
        /// <summary>
        /// Gets or Sets NonMyopicMemberRewards
        /// </summary>
        [DataMember(Name="non_myopic_member_rewards", EmitDefaultValue=false)]
        public StakepoolsMetricsNonMyopicMemberRewards NonMyopicMemberRewards { get; set; }

        /// <summary>
        /// Gets or Sets RelativeStake
        /// </summary>
        [DataMember(Name="relative_stake", EmitDefaultValue=false)]
        public StakepoolsMetricsRelativeStake RelativeStake { get; set; }

        /// <summary>
        /// Saturation-level of the pool based on the desired number of pools aimed by the network. A value above &#x60;1&#x60; indicates that the pool is saturated.  The &#x60;non_myopic_member_rewards&#x60; take oversaturation into account, as specified by the [specs](https://hydra.iohk.io/job/Cardano/cardano-ledger-specs/delegationDesignSpec/latest/download-by-type/doc-pdf/delegation_design_spec).  The saturation is based on the live &#x60;relative_stake&#x60;. The saturation at the end of epoch e, will affect the rewards paid out at the end of epoch e+3. 
        /// </summary>
        /// <value>Saturation-level of the pool based on the desired number of pools aimed by the network. A value above &#x60;1&#x60; indicates that the pool is saturated.  The &#x60;non_myopic_member_rewards&#x60; take oversaturation into account, as specified by the [specs](https://hydra.iohk.io/job/Cardano/cardano-ledger-specs/delegationDesignSpec/latest/download-by-type/doc-pdf/delegation_design_spec).  The saturation is based on the live &#x60;relative_stake&#x60;. The saturation at the end of epoch e, will affect the rewards paid out at the end of epoch e+3. </value>
        [DataMember(Name="saturation", EmitDefaultValue=false)]
        public decimal? Saturation { get; set; }

        /// <summary>
        /// Gets or Sets ProducedBlocks
        /// </summary>
        [DataMember(Name="produced_blocks", EmitDefaultValue=false)]
        public StakepoolsMetricsProducedBlocks ProducedBlocks { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StakepoolsMetrics {\n");
            sb.Append("  NonMyopicMemberRewards: ").Append(NonMyopicMemberRewards).Append("\n");
            sb.Append("  RelativeStake: ").Append(RelativeStake).Append("\n");
            sb.Append("  Saturation: ").Append(Saturation).Append("\n");
            sb.Append("  ProducedBlocks: ").Append(ProducedBlocks).Append("\n");
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
            return this.Equals(input as StakepoolsMetrics);
        }

        /// <summary>
        /// Returns true if StakepoolsMetrics instances are equal
        /// </summary>
        /// <param name="input">Instance of StakepoolsMetrics to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(StakepoolsMetrics input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.NonMyopicMemberRewards == input.NonMyopicMemberRewards ||
                    (this.NonMyopicMemberRewards != null &&
                    this.NonMyopicMemberRewards.Equals(input.NonMyopicMemberRewards))
                ) && 
                (
                    this.RelativeStake == input.RelativeStake ||
                    (this.RelativeStake != null &&
                    this.RelativeStake.Equals(input.RelativeStake))
                ) && 
                (
                    this.Saturation == input.Saturation ||
                    (this.Saturation != null &&
                    this.Saturation.Equals(input.Saturation))
                ) && 
                (
                    this.ProducedBlocks == input.ProducedBlocks ||
                    (this.ProducedBlocks != null &&
                    this.ProducedBlocks.Equals(input.ProducedBlocks))
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
                if (this.NonMyopicMemberRewards != null)
                    hashCode = hashCode * 59 + this.NonMyopicMemberRewards.GetHashCode();
                if (this.RelativeStake != null)
                    hashCode = hashCode * 59 + this.RelativeStake.GetHashCode();
                if (this.Saturation != null)
                    hashCode = hashCode * 59 + this.Saturation.GetHashCode();
                if (this.ProducedBlocks != null)
                    hashCode = hashCode * 59 + this.ProducedBlocks.GetHashCode();
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
