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
    /// ApiAddressInspectPointer
    /// </summary>
    [DataContract]
        public partial class ApiAddressInspectPointer :  IEquatable<ApiAddressInspectPointer>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiAddressInspectPointer" /> class.
        /// </summary>
        /// <param name="slotNum">slotNum (required).</param>
        /// <param name="transactionIndex">transactionIndex (required).</param>
        /// <param name="outputIndex">outputIndex (required).</param>
        public ApiAddressInspectPointer(int? slotNum = default(int?), int? transactionIndex = default(int?), int? outputIndex = default(int?))
        {
            // to ensure "slotNum" is required (not null)
            if (slotNum == null)
            {
                throw new InvalidDataException("slotNum is a required property for ApiAddressInspectPointer and cannot be null");
            }
            else
            {
                this.SlotNum = slotNum;
            }
            // to ensure "transactionIndex" is required (not null)
            if (transactionIndex == null)
            {
                throw new InvalidDataException("transactionIndex is a required property for ApiAddressInspectPointer and cannot be null");
            }
            else
            {
                this.TransactionIndex = transactionIndex;
            }
            // to ensure "outputIndex" is required (not null)
            if (outputIndex == null)
            {
                throw new InvalidDataException("outputIndex is a required property for ApiAddressInspectPointer and cannot be null");
            }
            else
            {
                this.OutputIndex = outputIndex;
            }
        }
        
        /// <summary>
        /// Gets or Sets SlotNum
        /// </summary>
        [DataMember(Name="slot_num", EmitDefaultValue=false)]
        public int? SlotNum { get; set; }

        /// <summary>
        /// Gets or Sets TransactionIndex
        /// </summary>
        [DataMember(Name="transaction_index", EmitDefaultValue=false)]
        public int? TransactionIndex { get; set; }

        /// <summary>
        /// Gets or Sets OutputIndex
        /// </summary>
        [DataMember(Name="output_index", EmitDefaultValue=false)]
        public int? OutputIndex { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ApiAddressInspectPointer {\n");
            sb.Append("  SlotNum: ").Append(SlotNum).Append("\n");
            sb.Append("  TransactionIndex: ").Append(TransactionIndex).Append("\n");
            sb.Append("  OutputIndex: ").Append(OutputIndex).Append("\n");
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
            return this.Equals(input as ApiAddressInspectPointer);
        }

        /// <summary>
        /// Returns true if ApiAddressInspectPointer instances are equal
        /// </summary>
        /// <param name="input">Instance of ApiAddressInspectPointer to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ApiAddressInspectPointer input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.SlotNum == input.SlotNum ||
                    (this.SlotNum != null &&
                    this.SlotNum.Equals(input.SlotNum))
                ) && 
                (
                    this.TransactionIndex == input.TransactionIndex ||
                    (this.TransactionIndex != null &&
                    this.TransactionIndex.Equals(input.TransactionIndex))
                ) && 
                (
                    this.OutputIndex == input.OutputIndex ||
                    (this.OutputIndex != null &&
                    this.OutputIndex.Equals(input.OutputIndex))
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
                if (this.SlotNum != null)
                    hashCode = hashCode * 59 + this.SlotNum.GetHashCode();
                if (this.TransactionIndex != null)
                    hashCode = hashCode * 59 + this.TransactionIndex.GetHashCode();
                if (this.OutputIndex != null)
                    hashCode = hashCode * 59 + this.OutputIndex.GetHashCode();
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