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

using Mango.PDD.DDJB.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mango.PDD.DDJB.Request
{
    /// <summary>
    /// 拼多多系统级请求参数
    /// </summary>
    public abstract class BasePddRequest<T> : IPddRequest<T>
        where T : BasePddResponse
    {
        /// <summary>
        /// API接口名称
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// POP分配给应用的Client_Id
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// 授权的token
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public string Timestamp { get; set; } = DateTime.Now.Ticks.ToString();

        /// <summary>
        /// 响应格式
        /// </summary>
        public string DataType { get; set; } = "JSON";

        /// <summary>
        /// API协议版本号
        /// </summary>
        public string Version { get; set; } = "V1";

        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }

        public string GetApiName()
        {
            return Type;
        }

        public string GetAppKey()
        {
            return ClientId;
        }

        public virtual IDictionary<string, string> GetParameters()
        {
            var param = new SortedDictionary<string, string>();
            param.Add("type", Type);
            param.Add("client_id", ClientId);
            if (!string.IsNullOrEmpty(AccessToken))
            {
                param.Add("access_token", AccessToken);
            }
            param.Add("timestamp", Timestamp);
            param.Add("data_type", DataType);
            param.Add("version", Version);

            return param;
        }

        public void SetClientId(string clientId)
        {
            ClientId = clientId;
        }
    }

    /// <summary>
    /// 拼多多请求类基础接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPddRequest<T>
        where T : BasePddResponse
    {
        /// <summary>
        /// 获取api名
        /// </summary>
        /// <returns></returns>
        string GetApiName();

        /// <summary>
        /// 获取请求参数键值对
        /// </summary>
        /// <returns></returns>
        IDictionary<string, string> GetParameters();

        string GetAppKey();
        void SetClientId(string clientId);
    }
}
