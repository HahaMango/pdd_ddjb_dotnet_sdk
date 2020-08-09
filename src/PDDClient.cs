/*----------------------------------------------------------------
// Copyright (C) 2020 广州天美联盟网络科技有限公司
// 版权所有。
//
// 文件名：PDDClient
// 文件功能描述：
//  拼多多API客户端实现类
//
// 创建者：陈子华
// 创建时间：2020-07-25 13:26
// 
//----------------------------------------------------------------*/

using Mango.PDD.DDJB.Request;
using Mango.PDD.DDJB.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mango.PDD.DDJB
{
    /// <summary>
    /// 拼多多API客户端实现类
    /// </summary>
    public class PDDClient : IPDDClient
    {
        private readonly string _url;
        private readonly string _clientId;
        private readonly string _clientSecret;

        public PDDClient(
            string url,
            string clientId,
            string clientSecret)
        {
            _url = url;
            _clientId = clientId;
            _clientSecret = clientSecret;
        }

        /// <summary>
        /// 执行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<T> ExecuteAsync<T>(IPddRequest<T> request) where T : BasePddResponse
        {
            if(request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            request.SetClientId(_clientId);
            var param = request.GetParameters();
            var sign = GetSign(param, _clientSecret);
            param.Add("sign", sign);

            byte[] postData = Encoding.UTF8.GetBytes(GetQueryString(param));

            HttpWebRequest pddrequest = (HttpWebRequest)WebRequest.Create(_url);
            pddrequest.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
            pddrequest.KeepAlive = true;
            pddrequest.Timeout = 30 * 1000;
            pddrequest.Method = "POST";
            pddrequest.ContentLength = postData.Length;
            Stream stream = pddrequest.GetRequestStream();
            stream.Write(postData, 0, postData.Length);
            stream.Flush();
            stream.Close();
            HttpWebResponse response = (HttpWebResponse)pddrequest.GetResponse();
            Stream backStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(backStream, Encoding.GetEncoding("UTF-8"));
            var result = sr.ReadToEnd();
            sr.Close();
            backStream.Close();
            response.Close();
            pddrequest.Abort();

            using (var jObject = JsonDocument.Parse(result))
            {
                var root = jObject.RootElement;

                var iserror = root.TryGetProperty("error_response",out var error);
                if (iserror)
                {
                    var errorJson = error.ToString();
                    var r = await errorJson.ToObjectAsync<T>();
                    r.IsError = true;
                    return r;
                }

                var value = root[0].ToString();
                var resultJson = await value.ToObjectAsync<T>();

                return await Task.FromResult(resultJson);
            }
        }

        /// <summary>
        /// 生成签名
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        private string GetSign(IDictionary<string,string> parameters,string secret)
        {
            var query = new StringBuilder();
            query.Append(secret);
            foreach(var param in parameters)
            {
                if (!string.IsNullOrEmpty(param.Key) && !string.IsNullOrEmpty(param.Value))
                {
                    query.Append(param.Key);
                    query.Append(param.Value);
                }
            }

            query.Append(secret);
            MD5 md5 = MD5.Create();
            var bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(query.ToString()));

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                result.Append(bytes[i].ToString("X2"));
            }

            return result.ToString();
        }

        /// <summary>
        /// 生成请求字符串
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private string GetQueryString(IDictionary<string,string> parameters)
        {
            var result = new StringBuilder("");
            var singleQuery = new List<string>();
            foreach(var param in parameters)
            {
                if (!string.IsNullOrEmpty(param.Key) && !string.IsNullOrEmpty(param.Value))
                {
                    singleQuery.Add($"{param.Key}={Uri.EscapeDataString(param.Value)}");
                }
            }
            var maxIndex = singleQuery.Count - 1;
            for(var i = 0; i < singleQuery.Count; i++)
            {
                if(i < maxIndex)
                {
                    result.Append(singleQuery[i]).Append("&");
                }
                else
                {
                    result.Append(singleQuery[i]);
                }
            }
            return result.ToString();
        }
    }
}
