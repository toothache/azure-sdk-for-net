// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.ApplicationInsights.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The browser timing information
    /// </summary>
    public partial class EventsBrowserTimingInfo
    {
        /// <summary>
        /// Initializes a new instance of the EventsBrowserTimingInfo class.
        /// </summary>
        public EventsBrowserTimingInfo()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the EventsBrowserTimingInfo class.
        /// </summary>
        /// <param name="urlPath">The path of the URL</param>
        /// <param name="urlHost">The host of the URL</param>
        /// <param name="name">The name of the page</param>
        /// <param name="url">The url of the page</param>
        /// <param name="totalDuration">The total duration of the load</param>
        /// <param name="performanceBucket">The performance bucket of the
        /// load</param>
        /// <param name="networkDuration">The network duration of the
        /// load</param>
        /// <param name="sendDuration">The send duration of the load</param>
        /// <param name="receiveDuration">The receive duration of the
        /// load</param>
        /// <param name="processingDuration">The processing duration of the
        /// load</param>
        public EventsBrowserTimingInfo(string urlPath = default(string), string urlHost = default(string), string name = default(string), string url = default(string), long? totalDuration = default(long?), string performanceBucket = default(string), long? networkDuration = default(long?), long? sendDuration = default(long?), long? receiveDuration = default(long?), long? processingDuration = default(long?))
        {
            UrlPath = urlPath;
            UrlHost = urlHost;
            Name = name;
            Url = url;
            TotalDuration = totalDuration;
            PerformanceBucket = performanceBucket;
            NetworkDuration = networkDuration;
            SendDuration = sendDuration;
            ReceiveDuration = receiveDuration;
            ProcessingDuration = processingDuration;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the path of the URL
        /// </summary>
        [JsonProperty(PropertyName = "urlPath")]
        public string UrlPath { get; set; }

        /// <summary>
        /// Gets or sets the host of the URL
        /// </summary>
        [JsonProperty(PropertyName = "urlHost")]
        public string UrlHost { get; set; }

        /// <summary>
        /// Gets or sets the name of the page
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the url of the page
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the total duration of the load
        /// </summary>
        [JsonProperty(PropertyName = "totalDuration")]
        public long? TotalDuration { get; set; }

        /// <summary>
        /// Gets or sets the performance bucket of the load
        /// </summary>
        [JsonProperty(PropertyName = "performanceBucket")]
        public string PerformanceBucket { get; set; }

        /// <summary>
        /// Gets or sets the network duration of the load
        /// </summary>
        [JsonProperty(PropertyName = "networkDuration")]
        public long? NetworkDuration { get; set; }

        /// <summary>
        /// Gets or sets the send duration of the load
        /// </summary>
        [JsonProperty(PropertyName = "sendDuration")]
        public long? SendDuration { get; set; }

        /// <summary>
        /// Gets or sets the receive duration of the load
        /// </summary>
        [JsonProperty(PropertyName = "receiveDuration")]
        public long? ReceiveDuration { get; set; }

        /// <summary>
        /// Gets or sets the processing duration of the load
        /// </summary>
        [JsonProperty(PropertyName = "processingDuration")]
        public long? ProcessingDuration { get; set; }

    }
}