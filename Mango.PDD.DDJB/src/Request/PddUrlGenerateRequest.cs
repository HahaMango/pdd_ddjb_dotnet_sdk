using Mango.PDD.DDJB.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mango.PDD.DDJB.Request
{
    /// <summary>
    /// 多多进宝推广连接生成请求
    /// </summary>
    public class PddUrlGenerateRequest : BasePddRequest<PddUrlGenerateResponse>
    {
        public PddUrlGenerateRequest()
        {
            base.Type = "pdd.ddk.goods.promotion.url.generate";
        }

        /// <summary>
        /// 自定义参数，json
        /// </summary>
        public string CustomParameters { get; set; }

        /// <summary>
        /// 是否生成店铺收藏券推广链接
        /// </summary>
        public bool? GenerateMallCollectCoupon { get; set; }

        /// <summary>
        /// 是否生成qq小程序
        /// </summary>
        public bool? GenerateQqApp { get; set; }

        /// <summary>
        /// 是否返回 schema URL
        /// </summary>
        public bool? GenerateSchemaUrl { get; set; }

        /// <summary>
        /// 是否生成短链接，true-是，false-否
        /// </summary>
        public bool? GenerateShortUrl { get; set; }

        /// <summary>
        /// 是否生成唤起微信客户端链接，true-是，false-否，默认false
        /// </summary>
        public bool? GenerateWeappWebview { get; set; }

        /// <summary>
        /// 是否生成微博推广链接
        /// </summary>
        public bool? GenerateWeiboappWebview { get; set; }

        /// <summary>
        /// 是否生成小程序推广
        /// </summary>
        public bool? GenerateWeApp { get; set; }

        /// <summary>
        /// 商品ID，仅支持单个查询
        /// </summary>
        public List<long> GoodsIdList { get; set; }

        /// <summary>
        /// true--生成多人团推广链接 false--生成单人团推广链接（默认false）
        /// 1、单人团推广链接：用户访问单人团推广链接，可直接购买商品无需拼团。
        /// 2、多人团推广链接：用户访问双人团推广链接开团，若用户分享给他人参团，则开团者和参团者的佣金均结算给推手
        /// </summary>
        public bool? MultiGroup { get; set; }

        /// <summary>
        /// 推广位ID
        /// </summary>
        public string Pid { get; set; }

        /// <summary>
        /// 搜索id，建议填写，提高收益。来自pdd.ddk.goods.recommend.get、pdd.ddk.goods.search、pdd.ddk.top.goods.list.query等接口
        /// </summary>
        public string SearchId { get; set; }

        /// <summary>
        /// 招商多多客ID
        /// </summary>
        public long? ZsDuoId { get; set; }

        /// <summary>
        /// 直播间id列表，如果生成直播间推广链接该参数必填，goods_id_list填[1]
        /// </summary>
        public List<string> RoomIdList { get; set; }

        /// <summary>
        /// 直播预约id列表，如果生成直播间预约推广链接该参数必填，goods_id_list填[1]，room_id_list不填
        /// </summary>
        public List<string> TargetIdList { get; set; }

        public override IDictionary<string, string> GetParameters()
        {
            var param = base.GetParameters();
            param.Add("custom_parameters", CustomParameters);
            param.Add("generate_mall_collect_coupon", GenerateMallCollectCoupon?.ToString());
            param.Add("generate_qq_app", GenerateQqApp?.ToString());
            param.Add("generate_schema_url", GenerateSchemaUrl?.ToString());
            param.Add("generate_short_url", GenerateShortUrl?.ToString());
            param.Add("generate_weapp_webview", GenerateWeappWebview?.ToString());
            param.Add("generate_weiboapp_webview", GenerateWeiboappWebview?.ToString());
            param.Add("generate_we_app", GenerateWeApp?.ToString());
            param.Add("goods_id_list", GoodsIdList?.ToJson());
            param.Add("multi_group", MultiGroup?.ToString());
            param.Add("p_id", Pid);
            param.Add("search_id", SearchId);
            param.Add("zs_duo_id", ZsDuoId?.ToString());
            param.Add("room_id_list", RoomIdList?.ToJson());
            param.Add("target_id_list", TargetIdList?.ToJson());
            return param;
        }
    }
}
