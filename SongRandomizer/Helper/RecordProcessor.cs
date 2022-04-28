using SongRandomizer.MVVM.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SongRandomizer.Helper
{
    public class RecordProcessor
    {
        public static readonly HttpClient _HttpClient = new HttpClient();


        public static async Task<string> LoadRecording(string randomWord)
        {
            string url = $"https://musicbrainz.org/ws/2/recording?query={randomWord}&limit=1&inc=artist-credits+releases&fmt=json";
            using (var request = new HttpRequestMessage(HttpMethod.Get, new Uri(url)))
            {
                request.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml");
                request.Headers.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
                request.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
                request.Headers.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");

                using (var response = await _HttpClient.SendAsync(request).ConfigureAwait(false))
                {
                    response.EnsureSuccessStatusCode();
                    using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    using (var decompressedStream = new GZipStream(responseStream, CompressionMode.Decompress))
                    using (var streamReader = new StreamReader(decompressedStream))
                    {
                        return await streamReader.ReadToEndAsync().ConfigureAwait(false);
                    }
                }
            }
        }

        /*public static async Task<Recording[]> LoadRecording(string randomWord)
        {
            string url = $"https://musicbrainz.org/ws/2/recording?query={randomWord}&limit=1&inc=artist-credits+releases&fmt=json";

            using (HttpResponseMessage response = await ApiHelper.apiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    RecordResult result = await response.Content.ReadAsAsync<RecordResult>();
                    return result.recordings;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }*/
    }
}
