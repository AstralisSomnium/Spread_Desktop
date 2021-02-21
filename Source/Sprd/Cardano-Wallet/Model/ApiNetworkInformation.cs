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
    /// ApiNetworkInformation
    /// </summary>
    [DataContract]
        public partial class ApiNetworkInformation :  IEquatable<ApiNetworkInformation>, IValidatableObject
    {
        /// <summary>
        /// Defines NodeEra
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
                public enum NodeEraEnum
        {
            /// <summary>
            /// Enum Byron for value: byron
            /// </summary>
            [EnumMember(Value = "byron")]
            Byron = 1,
            /// <summary>
            /// Enum Shelley for value: shelley
            /// </summary>
            [EnumMember(Value = "shelley")]
            Shelley = 2,
            /// <summary>
            /// Enum Allegra for value: allegra
            /// </summary>
            [EnumMember(Value = "allegra")]
            Allegra = 3,
            /// <summary>
            /// Enum Mary for value: mary
            /// </summary>
            [EnumMember(Value = "mary")]
            Mary = 4        }
        /// <summary>
        /// Gets or Sets NodeEra
        /// </summary>
        [DataMember(Name="node_era", EmitDefaultValue=false)]
        public NodeEraEnum NodeEra { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiNetworkInformation" /> class.
        /// </summary>
        /// <param name="syncProgress">syncProgress (required).</param>
        /// <param name="nodeTip">nodeTip (required).</param>
        /// <param name="networkTip">networkTip.</param>
        /// <param name="nextEpoch">nextEpoch.</param>
        /// <param name="nodeEra">nodeEra (required).</param>
        public ApiNetworkInformation(ApiNetworkInformationSyncProgress syncProgress = default(ApiNetworkInformationSyncProgress), ApiNetworkInformationNodeTip nodeTip = default(ApiNetworkInformationNodeTip), ApiNetworkInformationNetworkTip networkTip = default(ApiNetworkInformationNetworkTip), WalletsDelegationChangesAt nextEpoch = default(WalletsDelegationChangesAt), NodeEraEnum nodeEra = default(NodeEraEnum))
        {
            // to ensure "syncProgress" is required (not null)
            if (syncProgress == null)
            {
                throw new InvalidDataException("syncProgress is a required property for ApiNetworkInformation and cannot be null");
            }
            else
            {
                this.SyncProgress = syncProgress;
            }
            // to ensure "nodeTip" is required (not null)
            if (nodeTip == null)
            {
                throw new InvalidDataException("nodeTip is a required property for ApiNetworkInformation and cannot be null");
            }
            else
            {
                this.NodeTip = nodeTip;
            }
            // to ensure "nodeEra" is required (not null)
            if (nodeEra == null)
            {
                throw new InvalidDataException("nodeEra is a required property for ApiNetworkInformation and cannot be null");
            }
            else
            {
                this.NodeEra = nodeEra;
            }
            this.NetworkTip = networkTip;
            this.NextEpoch = nextEpoch;
        }
        
        /// <summary>
        /// Gets or Sets SyncProgress
        /// </summary>
        [DataMember(Name="sync_progress", EmitDefaultValue=false)]
        public ApiNetworkInformationSyncProgress SyncProgress { get; set; }

        /// <summary>
        /// Gets or Sets NodeTip
        /// </summary>
        [DataMember(Name="node_tip", EmitDefaultValue=false)]
        public ApiNetworkInformationNodeTip NodeTip { get; set; }

        /// <summary>
        /// Gets or Sets NetworkTip
        /// </summary>
        [DataMember(Name="network_tip", EmitDefaultValue=false)]
        public ApiNetworkInformationNetworkTip NetworkTip { get; set; }

        /// <summary>
        /// Gets or Sets NextEpoch
        /// </summary>
        [DataMember(Name="next_epoch", EmitDefaultValue=false)]
        public WalletsDelegationChangesAt NextEpoch { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ApiNetworkInformation {\n");
            sb.Append("  SyncProgress: ").Append(SyncProgress).Append("\n");
            sb.Append("  NodeTip: ").Append(NodeTip).Append("\n");
            sb.Append("  NetworkTip: ").Append(NetworkTip).Append("\n");
            sb.Append("  NextEpoch: ").Append(NextEpoch).Append("\n");
            sb.Append("  NodeEra: ").Append(NodeEra).Append("\n");
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
            return this.Equals(input as ApiNetworkInformation);
        }

        /// <summary>
        /// Returns true if ApiNetworkInformation instances are equal
        /// </summary>
        /// <param name="input">Instance of ApiNetworkInformation to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ApiNetworkInformation input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.SyncProgress == input.SyncProgress ||
                    (this.SyncProgress != null &&
                    this.SyncProgress.Equals(input.SyncProgress))
                ) && 
                (
                    this.NodeTip == input.NodeTip ||
                    (this.NodeTip != null &&
                    this.NodeTip.Equals(input.NodeTip))
                ) && 
                (
                    this.NetworkTip == input.NetworkTip ||
                    (this.NetworkTip != null &&
                    this.NetworkTip.Equals(input.NetworkTip))
                ) && 
                (
                    this.NextEpoch == input.NextEpoch ||
                    (this.NextEpoch != null &&
                    this.NextEpoch.Equals(input.NextEpoch))
                ) && 
                (
                    this.NodeEra == input.NodeEra ||
                    (this.NodeEra != null &&
                    this.NodeEra.Equals(input.NodeEra))
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
                if (this.SyncProgress != null)
                    hashCode = hashCode * 59 + this.SyncProgress.GetHashCode();
                if (this.NodeTip != null)
                    hashCode = hashCode * 59 + this.NodeTip.GetHashCode();
                if (this.NetworkTip != null)
                    hashCode = hashCode * 59 + this.NetworkTip.GetHashCode();
                if (this.NextEpoch != null)
                    hashCode = hashCode * 59 + this.NextEpoch.GetHashCode();
                if (this.NodeEra != null)
                    hashCode = hashCode * 59 + this.NodeEra.GetHashCode();
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
