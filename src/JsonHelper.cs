/*--------------------------------------------------------------------------
//
//  Copyright 2020 Chiva Chen
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//
--------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mango.PDD.DDJB
{
    /// <summary>
    /// JSON序列化帮助类
    /// </summary>
    public static class JsonHelper
    {
        private static JsonSerializerOptions _options;

        static JsonHelper()
        {
            _options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
        }

        /// <summary>
        /// 对象转json字符串 异步
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <returns></returns>
        public static async Task<string> ToJsonAsync<T>(this T o)
            where T : class
        {
            return await o.ToJsonAsync<T>(_options);
        }

        /// <summary>
        /// 对象转json字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ToJson<T>(this T o)
            where T : class
        {
            return o.ToJson<T>(_options);
        }

        /// <summary>
        /// 对象转utf8格式json字符传
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ToJsonUtf8<T>(this T o)
            where T : class
        {
            return o.ToJsonUtf8<T>(_options);
        }

        /// <summary>
        /// 通过配置，对象转json字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string ToJson<T>(this T o, JsonSerializerOptions options)
            where T : class
        {
            if (o == null)
            {
                throw new ArgumentNullException(nameof(o));
            }
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return JsonSerializer.Serialize<T>(o, options);
        }

        /// <summary>
        /// 通过配置，对象转utf8格式json字符传
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string ToJsonUtf8<T>(this T o, JsonSerializerOptions options)
            where T : class
        {
            if (o == null)
            {
                throw new ArgumentNullException(nameof(o));
            }
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            var utf8Bytes = JsonSerializer.SerializeToUtf8Bytes<T>(o, options);
            return Encoding.UTF8.GetString(utf8Bytes);
        }

        /// <summary>
        /// 通过配置，对象转json字符串 异步
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static async Task<string> ToJsonAsync<T>(this T o, JsonSerializerOptions options)
            where T : class
        {
            if (o == null)
            {
                throw new ArgumentNullException(nameof(o));
            }
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            string json = null;

            using (var steam = new MemoryStream())
            {
                await JsonSerializer.SerializeAsync<T>(steam, o);
                using (var reader = new StreamReader(steam))
                {
                    json = await reader.ReadToEndAsync();
                }
            }

            return json;
        }

        /// <summary>
        /// json字符串反序列化为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static async Task<T> ToObjectAsync<T>(this string source)
            where T : class
        {
            return await ToObjectAsync<T>(source, _options);
        }

        /// <summary>
        /// 通过配置，json字符串反序列化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static async Task<T> ToObjectAsync<T>(this string source, JsonSerializerOptions options)
            where T : class
        {
            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            var o = JsonSerializer.Deserialize<T>(source, options);
            return await Task.FromResult(o);
        }
    }
}
