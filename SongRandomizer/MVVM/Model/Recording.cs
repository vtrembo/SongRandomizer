using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongRandomizer.MVVM.Model
{
    public class Recording
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("artist-credit")]
        public ArtistCredit[] artistCredits { get; set; }

        [JsonProperty("releases")]
        public Release[]  release { get; set; }
    }
}
