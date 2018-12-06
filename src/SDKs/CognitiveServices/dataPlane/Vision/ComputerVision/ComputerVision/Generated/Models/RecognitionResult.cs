// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class RecognitionResult
    {
        /// <summary>
        /// Initializes a new instance of the RecognitionResult class.
        /// </summary>
        public RecognitionResult()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the RecognitionResult class.
        /// </summary>
        public RecognitionResult(IList<Line> lines, int? page = default(int?), double? width = default(double?), double? height = default(double?), double? clockwiseOrientation = default(double?))
        {
            Lines = lines;
            Page = page;
            Width = width;
            Height = height;
            ClockwiseOrientation = clockwiseOrientation;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lines")]
        public IList<Line> Lines { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "page")]
        public int? Page { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "width")]
        public double? Width { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "height")]
        public double? Height { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "clockwiseOrientation")]
        public double? ClockwiseOrientation { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Lines == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Lines");
            }
        }
    }
}
