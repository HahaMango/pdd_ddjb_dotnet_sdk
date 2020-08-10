using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Mango.PDD.DDJB.Response
{
    /// <summary>
    /// 多多进宝推广链接生成响应
    /// </summary>
    public class PddUrlGenerateResponse : BasePddResponse
    {
        [JsonPropertyName("goods_promotion_url_list")]
        public List<GoodsPromotionUrlItem> GoodsPromotionUrlList { get; set; }

        public class GoodsPromotionUrlItem
        {
            /// <summary>
            /// 唤醒拼多多app的推广短链接
            /// </summary>
            [JsonPropertyName("mobile_short_url")]
            public string MobileShortUrl { get; set; }

            /// <summary>
            /// 唤醒拼多多app的推广长链接
            /// </summary>
            [JsonPropertyName("mobile_url")]
            public string MobileUrl { get; set; }

            /// <summary>
            /// qq小程序信息
            /// </summary>
            [JsonPropertyName("qq_app_info")]
            public QqAppInfo QqAppInfo { get; set; }

            /// <summary>
            /// schema的链接
            /// </summary>
            [JsonPropertyName("schema_url")]
            public string SchemaUrl { get; set; }

            /// <summary>
            /// 推广短链接
            /// </summary>
            [JsonPropertyName("short_url")]
            public string ShortUrl { get; set; }

            /// <summary>
            /// 推广长链接
            /// </summary>
            [JsonPropertyName("url")]
            public string Url { get; set; }

            /// <summary>
            /// 微博推广短链接
            /// </summary>
            [JsonPropertyName("weibo_app_web_view_short_url")]
            public string WeiboAppWebViewShortUrl { get; set; }

            /// <summary>
            /// 微博推广链接
            /// </summary>
            [JsonPropertyName("weibo_app_web_view_url")]
            public string WeiboAppWebViewUrl { get; set; }

            /// <summary>
            /// 小程序信息
            /// </summary>
            [JsonPropertyName("we_app_info")]
            public WeAppInfo WeAppInfo { get; set; }

            /// <summary>
            /// 唤起微信app推广短链接
            /// </summary>
            [JsonPropertyName("we_app_web_view_short_url")]
            public string WeAppWebViewShortUrl { get; set; }

            /// <summary>
            /// 唤起微信app推广链接
            /// </summary>
            [JsonPropertyName("we_app_web_view_url")]
            public string WeAppWebViewUrl { get; set; }
        }

        public class QqAppInfo
        {
            /// <summary>
            /// 拼多多小程序id
            /// </summary>
            [JsonPropertyName("app_id")]
            public string AppId { get; set; }

            /// <summary>
            /// Banner图
            /// </summary>
            [JsonPropertyName("banner_url")]
            public string BannerUrl { get; set; }

            /// <summary>
            /// 描述
            /// </summary>
            [JsonPropertyName("desc")]
            public string Desc { get; set; }

            /// <summary>
            /// 小程序path值
            /// </summary>
            [JsonPropertyName("page_path")]
            public string PagePath { get; set; }

            /// <summary>
            /// 小程序icon
            /// </summary>
            [JsonPropertyName("qq_app_icon_url")]
            public string QqAppIconUrl { get; set; }

            /// <summary>
            /// 来源名
            /// </summary>
            [JsonPropertyName("source_display_name")]
            public string SourceDisplayName { get; set; }

            /// <summary>
            /// 小程序标题
            /// </summary>
            [JsonPropertyName("title")]
            public string Title { get; set; }

            [JsonPropertyName("user_name")]
            public string UserName { get; set; }
        }

        public class WeAppInfo
        {
            /// <summary>
            /// 拼多多小程序id
            /// </summary>
            [JsonPropertyName("app_id")]
            public string AppId { get; set; }

            /// <summary>
            /// Banner图
            /// </summary>
            [JsonPropertyName("banner_url")]
            public string BannerUrl { get; set; }

            /// <summary>
            /// 描述
            /// </summary>
            [JsonPropertyName("desc")]
            public string Desc { get; set; }

            /// <summary>
            /// 小程序path值
            /// </summary>
            [JsonPropertyName("page_path")]
            public string PagePath { get; set; }

            /// <summary>
            /// 来源名
            /// </summary>
            [JsonPropertyName("source_display_name")]
            public string SourceDisplayName { get; set; }

            /// <summary>
            /// 小程序标题
            /// </summary>
            [JsonPropertyName("title")]
            public string Title { get; set; }

            /// <summary>
            /// 用户名
            /// </summary>
            [JsonPropertyName("user_name")]
            public string UserName { get; set; }

            /// <summary>
            /// 小程序图片
            /// </summary>
            [JsonPropertyName("we_app_icon_url")]
            public string WeAppIconUrl { get; set; }
        }
    }
}
