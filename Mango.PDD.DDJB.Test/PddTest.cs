using Mango.PDD.DDJB.Response;
using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Mango.PDD.DDJB.Test
{
    public class PddTest
    {
        /// <summary>
        /// ¥ÌŒÛœÏ”¶≤‚ ‘
        /// </summary>
        [Fact]
        public async void ErrorResponseTest()
        {
            var jsonfile = new StreamReader(new FileStream("ErrorResponse.json", FileMode.Open),Encoding.UTF8);
            var jsonstring = jsonfile.ReadToEnd();
            using (var reader = JsonDocument.Parse(jsonstring))
            {
                var root = reader.RootElement;

                var iserror = root.TryGetProperty("error_response", out var error);
                if (iserror)
                {
                    var errorJson = error.ToString();
                    var r = await errorJson.ToObjectAsync<BasePddResponse>();
                    r.IsError = true;

                    Assert.True(r.IsError);
                }
            }
        }

        /// <summary>
        /// …Ã∆∑À—À˜œÏ”¶≤‚ ‘
        /// </summary>
        [Fact]
        public async void PddGoodsSearchResponseTest()
        {
            var response = await GetObjectFromResponse<PddGoodsSearchResponse>("PddGoodsSearchResponse.json");
            Assert.NotNull(response);
            Assert.False(response.IsError);
            Assert.Equal(166939, response.TotalCount);
        }


        private async Task<T> GetObjectFromResponse<T>(string jsonPath)
            where T: BasePddResponse
        {
            var jsonfile = new StreamReader(new FileStream(jsonPath, FileMode.Open), Encoding.UTF8);
            var jsonstring = jsonfile.ReadToEnd();
            using (var jObject = JsonDocument.Parse(jsonstring))
            {
                var root = jObject.RootElement;

                var iserror = root.TryGetProperty("error_response", out var error);
                if (iserror)
                {
                    var errorJson = error.ToString();
                    var r = await errorJson.ToObjectAsync<T>();
                    r.IsError = true;
                    return r;
                }

                var value = default(string);
                foreach (var s in root.EnumerateObject())
                {
                    value = s.Value.ToString();
                    break;
                }
                var resultJson = await value.ToObjectAsync<T>();

                return resultJson;
            }
        }
    }
}
