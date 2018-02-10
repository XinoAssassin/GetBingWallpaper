using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GetBingWallpaper
{

    public class Data
    {

        [JsonProperty("enddate")]
        public string Enddate { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("bmiddle_pic")]
        public object BmiddlePic { get; set; }

        [JsonProperty("original_pic")]
        public object OriginalPic { get; set; }

        [JsonProperty("thumbnail_pic")]
        public object ThumbnailPic { get; set; }
    }

    public class Status
    {

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class NewJson
    {

        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

}
