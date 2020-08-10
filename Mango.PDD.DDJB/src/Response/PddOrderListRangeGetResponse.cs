using Mango.PDD.DDJB.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Mango.PDD.DDJB.Response
{
    /// <summary>
    /// 多多进宝用时间段查询推广订单响应
    /// </summary>
    public class PddOrderListRangeGetResponse : BasePddResponse
    {
        [JsonPropertyName("last_order_id")]
        public string LastOrderId { get; set; }

        /// <summary>
        /// 多多进宝推广位对象列表
        /// </summary>
        [JsonPropertyName("order_list")]
        public List<OrderListResponse> OrderList { get; set; }

        public class OrderListResponse
        {
            /// <summary>
            /// 是否是 cpa 新用户，1表示是，0表示否
            /// </summary>
            [JsonPropertyName("cpa_new")]
            public int CpaNew { get; set; }

            /// <summary>
            /// 自定义参数
            /// </summary>
            [JsonPropertyName("custom_parameters")]
            public string CustomParameters { get; set; }

            /// <summary>
            /// 订单审核失败原因
            /// </summary>
            [JsonPropertyName("fail_reason")]
            public string FailReason { get; set; }

            /// <summary>
            /// 商品ID
            /// </summary>
            [JsonPropertyName("goods_id")]
            public long GoodsId { get; set; }

            /// <summary>
            /// 商品标题
            /// </summary>
            [JsonPropertyName("goods_name")]
            public string GoodsName { get; set; }

            /// <summary>
            /// 订单中sku的单件价格，单位为分
            /// </summary>
            [JsonPropertyName("goods_price")]
            public long GoodsPrice { get; set; }

            /// <summary>
            /// 购买商品的数量
            /// </summary>
            [JsonPropertyName("goods_quantity")]
            public long GoodsQuantity { get; set; }

            /// <summary>
            /// 商品缩略图
            /// </summary>
            [JsonPropertyName("goods_thumbnail_url")]
            public string GoodsThumbnailUrl { get; set; }

            /// <summary>
            /// 实际支付金额，单位为分
            /// </summary>
            [JsonPropertyName("order_amount")]
            public long OrderAmount { get; set; }

            /// <summary>
            /// 订单生成时间，UNIX时间戳
            /// </summary>
            [JsonPropertyName("order_create_time")]
            public long OrderCreateTime { get; set; }

            /// <summary>
            /// 成团时间
            /// </summary>
            [JsonPropertyName("order_group_success_time")]
            public long OrderGroupSuccessTime { get; set; }

            /// <summary>
            /// 最后更新时间
            /// </summary>
            [JsonPropertyName("order_modify_at")]
            public long OrderModifyAt { get; set; }

            /// <summary>
            /// 支付时间
            /// </summary>
            [JsonPropertyName("order_pay_time")]
            public long OrderPayTime { get; set; }

            /// <summary>
            /// 推广订单编号
            /// </summary>
            [JsonPropertyName("order_sn")]
            public string OrderSn { get; set; }

            /// <summary>
            /// 订单状态： -1 未支付; 0-已支付；1-已成团；2-确认收货；3-审核成功；4-审核失败（不可提现）；5-已经结算；8-非多多进宝商品（无佣金订单）
            /// </summary>
            [JsonPropertyName("order_status")]
            public int OrderStatus { get; set; }

            /// <summary>
            /// 订单状态描述
            /// </summary>
            [JsonPropertyName("order_status_desc")]
            public string OrderStatusDesc { get; set; }

            /// <summary>
            /// 审核时间
            /// </summary>
            [JsonPropertyName("order_verify_time")]
            public long OrderVerifyTime { get; set; }

            /// <summary>
            /// 佣金金额，单位为分
            /// </summary>
            [JsonPropertyName("promotion_amount")]
            public long PromotionAmount { get; set; }

            /// <summary>
            /// 佣金比例，千分比
            /// </summary>
            [JsonPropertyName("promotion_rate")]
            public long PromotionRate { get; set; }

            /// <summary>
            /// 推广位ID
            /// </summary>
            [JsonPropertyName("p_id")]
            public string Pid { get; set; }

            /// <summary>
            /// 订单类型：0：领券页面， 1： 红包页， 2：领券页， 3： 题页
            /// </summary>
            [JsonPropertyName("type")]
            public int Type { get; set; }

            /// <summary>
            /// 商品一~四级类目ID列表
            /// </summary>
            [JsonPropertyName("cat_ids")]
            public List<long> CatIds { get; set; }

            /// <summary>
            /// 多多客工具id
            /// </summary>
            [JsonPropertyName("auth_duo_id")]
            public long AuthDuoId { get; set; }

            /// <summary>
            /// 结算批次号
            /// </summary>
            [JsonPropertyName("batch_no")]
            public string BatchNo { get; set; }

            /// <summary>
            /// 成团编号
            /// </summary>
            [JsonPropertyName("group_id")]
            public long GroupId { get; set; }

            /// <summary>
            /// order_receive_time
            /// </summary>
            [JsonPropertyName("order_receive_time")]
            public long OrderReceiveTime { get; set; }

            /// <summary>
            /// 结算时间
            /// </summary>
            [JsonPropertyName("order_settle_time")]
            public long OrderSettleTime { get; set; }

            /// <summary>
            /// 招商多多客id
            /// </summary>
            [JsonPropertyName("zs_duo_id")]
            public long ZsDuoId { get; set; }

            /// <summary>
            /// 是否直推 ，1表示是，0表示否
            /// </summary>
            [JsonPropertyName("is_direct")]
            public int IsDirect { get; set; }

            /// <summary>
            /// 直播间订单推广duoId
            /// </summary>
            [JsonPropertyName("sep_duo_id")]
            public long SepDuoId { get; set; }

            /// <summary>
            /// 直播间推广佣金
            /// </summary>
            [JsonPropertyName("sep_market_fee")]
            public int SepMarketFee { get; set; }

            /// <summary>
            /// 直播间订单推广位
            /// </summary>
            [JsonPropertyName("sep_pid")]
            public string SepPid { get; set; }

            /// <summary>
            /// 直播间推广佣金比例
            /// </summary>
            [JsonPropertyName("sep_rate")]
            public int SepRate { get; set; }

            /// <summary>
            /// 直播间推广自定义参数
            /// </summary>
            [JsonPropertyName("sep_parameters")]
            public string SepParameters { get; set; }
        }
    }
}
