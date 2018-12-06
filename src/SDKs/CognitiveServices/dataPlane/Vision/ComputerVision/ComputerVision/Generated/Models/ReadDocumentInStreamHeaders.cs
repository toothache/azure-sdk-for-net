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
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Defines headers for ReadDocumentInStream operation.
    /// </summary>
    public partial class ReadDocumentInStreamHeaders
    {
        /// <summary>
        /// Initializes a new instance of the ReadDocumentInStreamHeaders
        /// class.
        /// </summary>
        public ReadDocumentInStreamHeaders()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ReadDocumentInStreamHeaders
        /// class.
        /// </summary>
        /// <param name="operationLocation">URL to query for status of the
        /// operation. The operation ID will expire in 48 hours. </param>
        public ReadDocumentInStreamHeaders(string operationLocation = default(string))
        {
            OperationLocation = operationLocation;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets URL to query for status of the operation. The
        /// operation ID will expire in 48 hours.
        /// </summary>
        [JsonProperty(PropertyName = "Operation-Location")]
        public string OperationLocation { get; set; }

    }
}
