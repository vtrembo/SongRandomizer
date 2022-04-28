using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongRandomizer.MVVM.Model
{
    public class ReleaseGroup
    {
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
