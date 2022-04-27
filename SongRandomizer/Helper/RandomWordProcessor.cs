using SongRandomizer.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SongRandomizer.Helper
{
    public class RandomWordProcessor
    {
        public static async Task<RandomWord> loadRandomWord ()
        {
            string url = "https://random-words-api.vercel.app/word";

            using (HttpResponseMessage response = await ApiHelper.apiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    RandomWord[] randomWord = await response.Content.ReadAsAsync<RandomWord[]>();
                    return randomWord[0];
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
