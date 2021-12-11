using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Arcaptcha
{
    public class ArcaptchaWebSite
    {
        private static readonly HttpClient client = new HttpClient();
        private const string uri = "https://api.arcaptcha.ir/arcaptcha/api/verify";
        private string siteKey = string.Empty;
        private string secretKey = string.Empty;

        public static ArcaptchaWebSite Create(string siteKey, string secretKey)
        {
            return new ArcaptchaWebSite() { siteKey = siteKey, secretKey = secretKey };
        }

        public async Task<bool> ValidateCaptchaAsync(string challengeID)
        {

            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation");
            client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            var jsonInString = string.Format("{\'site_key\': \'{0}\', \'secret_key\': \'{1}\', \'challenge_id\': \'{2}\'}",
                this.siteKey, this.secretKey, challengeID);

            var response = await client.PostAsync(uri, new StringContent(jsonInString, Encoding.UTF8, "application/json"));
            return response.IsSuccessStatusCode;
        }
    }
}
