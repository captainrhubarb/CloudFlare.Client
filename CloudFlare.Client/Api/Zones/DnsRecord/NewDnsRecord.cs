﻿using System;
using CloudFlare.Client.Api.Parameters.Data;
using CloudFlare.Client.Attributes;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Extensions;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones.DnsRecord
{
    public class NewDnsRecord : NewDnsRecordBase
    {
        /// <summary>
        /// Name of the record
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Content of the record
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// Used with some records like MX and SRV to determine priority.
        /// If you do not supply a priority for an MX record, a default value of 0 will be set
        /// </summary>
        [JsonProperty("priority")]
        public int? Priority { get; set; }
        
        /// <summary>
        /// DNS record type
        /// </summary>
        [JsonProperty("type")]
        public new DnsRecordType Type
        {
            get
            {
                return base.Type;
            }
            set
            {
                value.EnsureIsNotDataType();
                base.Type = value;
            }
        }
    }

    public class NewDnsRecord<T> : NewDnsRecordBase
        where T : class, IData
    {
        /// <summary>
        /// Data of the record
        /// </summary>
        [JsonProperty("data")]
        public T Data { get; set; }

        /// <summary>
        /// DNS record type
        /// </summary>
        [JsonProperty("type")]
        public new DnsRecordType Type
        {
            get
            {
                return base.Type;
            }
            set
            {
                value.EnsureIsDataType();
                base.Type = value;
            }
        }
    }
}