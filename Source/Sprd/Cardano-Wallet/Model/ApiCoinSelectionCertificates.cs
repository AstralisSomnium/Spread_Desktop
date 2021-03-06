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
    /// A delegation certificate  Only for &#x27;join_pool&#x27; the &#x27;pool&#x27; property is required. 
    /// </summary>
    [DataContract]
        public partial class ApiCoinSelectionCertificates :  IEquatable<ApiCoinSelectionCertificates>, IValidatableObject
    {
        /// <summary>
        /// Defines CertificateType
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
                public enum CertificateTypeEnum
        {
            /// <summary>
            /// Enum Joinpool for value: join_pool
            /// </summary>
            [EnumMember(Value = "join_pool")]
            Joinpool = 1,
            /// <summary>
            /// Enum Quitpool for value: quit_pool
            /// </summary>
            [EnumMember(Value = "quit_pool")]
            Quitpool = 2,
            /// <summary>
            /// Enum Registerrewardaccount for value: register_reward_account
            /// </summary>
            [EnumMember(Value = "register_reward_account")]
            Registerrewardaccount = 3        }
        /// <summary>
        /// Gets or Sets CertificateType
        /// </summary>
        [DataMember(Name="certificate_type", EmitDefaultValue=false)]
        public CertificateTypeEnum CertificateType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiCoinSelectionCertificates" /> class.
        /// </summary>
        /// <param name="certificateType">certificateType (required).</param>
        /// <param name="pool">A unique identifier for the pool..</param>
        /// <param name="rewardAccountPath">rewardAccountPath (required).</param>
        public ApiCoinSelectionCertificates(CertificateTypeEnum certificateType = default(CertificateTypeEnum), string pool = default(string), List<string> rewardAccountPath = default(List<string>))
        {
            // to ensure "certificateType" is required (not null)
            if (certificateType == null)
            {
                throw new InvalidDataException("certificateType is a required property for ApiCoinSelectionCertificates and cannot be null");
            }
            else
            {
                this.CertificateType = certificateType;
            }
            // to ensure "rewardAccountPath" is required (not null)
            if (rewardAccountPath == null)
            {
                throw new InvalidDataException("rewardAccountPath is a required property for ApiCoinSelectionCertificates and cannot be null");
            }
            else
            {
                this.RewardAccountPath = rewardAccountPath;
            }
            this.Pool = pool;
        }
        

        /// <summary>
        /// A unique identifier for the pool.
        /// </summary>
        /// <value>A unique identifier for the pool.</value>
        [DataMember(Name="pool", EmitDefaultValue=false)]
        public string Pool { get; set; }

        /// <summary>
        /// Gets or Sets RewardAccountPath
        /// </summary>
        [DataMember(Name="reward_account_path", EmitDefaultValue=false)]
        public List<string> RewardAccountPath { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ApiCoinSelectionCertificates {\n");
            sb.Append("  CertificateType: ").Append(CertificateType).Append("\n");
            sb.Append("  Pool: ").Append(Pool).Append("\n");
            sb.Append("  RewardAccountPath: ").Append(RewardAccountPath).Append("\n");
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
            return this.Equals(input as ApiCoinSelectionCertificates);
        }

        /// <summary>
        /// Returns true if ApiCoinSelectionCertificates instances are equal
        /// </summary>
        /// <param name="input">Instance of ApiCoinSelectionCertificates to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ApiCoinSelectionCertificates input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.CertificateType == input.CertificateType ||
                    (this.CertificateType != null &&
                    this.CertificateType.Equals(input.CertificateType))
                ) && 
                (
                    this.Pool == input.Pool ||
                    (this.Pool != null &&
                    this.Pool.Equals(input.Pool))
                ) && 
                (
                    this.RewardAccountPath == input.RewardAccountPath ||
                    this.RewardAccountPath != null &&
                    input.RewardAccountPath != null &&
                    this.RewardAccountPath.SequenceEqual(input.RewardAccountPath)
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
                if (this.CertificateType != null)
                    hashCode = hashCode * 59 + this.CertificateType.GetHashCode();
                if (this.Pool != null)
                    hashCode = hashCode * 59 + this.Pool.GetHashCode();
                if (this.RewardAccountPath != null)
                    hashCode = hashCode * 59 + this.RewardAccountPath.GetHashCode();
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
