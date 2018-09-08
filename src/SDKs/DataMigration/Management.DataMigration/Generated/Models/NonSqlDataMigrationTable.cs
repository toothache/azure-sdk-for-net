// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.DataMigration.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Defines metadata for table to be migrated
    /// </summary>
    public partial class NonSqlDataMigrationTable
    {
        /// <summary>
        /// Initializes a new instance of the NonSqlDataMigrationTable class.
        /// </summary>
        public NonSqlDataMigrationTable()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the NonSqlDataMigrationTable class.
        /// </summary>
        /// <param name="sourceName">Source table name</param>
        public NonSqlDataMigrationTable(string sourceName = default(string))
        {
            SourceName = sourceName;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets source table name
        /// </summary>
        [JsonProperty(PropertyName = "sourceName")]
        public string SourceName { get; set; }

    }
}