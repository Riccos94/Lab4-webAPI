using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json.Serialization;

namespace web_API
{
    
    public class Post
    {
        [property: JsonPropertyName("html_url")]
        public string? Html_url { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }
        
        [JsonPropertyName("homepage")]
        public string? Homepage { get; set; }

        [JsonPropertyName("watchers")]
        public int Watchers { get; set; }

        [JsonPropertyName("pushed_at")]
        public string? Pushed_at { get; set; }
    
        public override string ToString()
        {
            return $"Name: {this.Name} \nHomepage: {this.Homepage} \nHtml_url: {this.Html_url} \nDescription: {this.Description} \nWatchers: {this.Watchers} \nPushed at: {this.Pushed_at  }";

        }    
        
    }

    public class ZipResponse
    {
        [JsonPropertyName("post code")]
        public string? PostCode { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("places")]
        public List<Place>? Places { get; set; }

        public override string ToString()
        {
            if (Places != null && Places.Count > 0)
            {
                var place = Places[0];
                return $"Post code: {this.PostCode} \nLatitude: {place.Latitude} \nLongitude: {place.Longitude}";
            }
            return $"Post code: {this.PostCode} \nLatitude: N/A \nLongitude: N/A";
        }
    }

    public class Place
    {
        [JsonPropertyName("latitude")]
        public string? Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public string? Longitude { get; set; }

        [JsonPropertyName("place name")]
        public string? PlaceName { get; set; }

        [JsonPropertyName("state")]
        public string? State { get; set; }
    }



}


     
 //"html_url": "https://github.com/dotnet/android-samples",
 //"description": "A collection of .NET for Android sample projects",
 //"name": "android-samples",
 //"homepage": "https://dotnet.microsoft.com/apps/mobile",
 //"watchers": 11274,
 //"pushed_at": "2025-11-21T18:05:48Z",