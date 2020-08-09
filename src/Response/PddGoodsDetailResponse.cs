using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Mango.PDD.DDJB.Response
{
    /// <summary>
    /// 多多进宝商品详情响应
    /// </summary>
    public class PddGoodsDetailResponse : BasePddResponse
    {
        /// <summary>
        /// 多多进宝商品对象列表
        /// </summary>
        [JsonPropertyName("goods_details")]
        public List<GoodsDetailItem> GoodsDetails { get; set; }

        public class GoodsDetailItem
        {
            /// <summary>
            /// 商品类目ID，使用pdd.goods.cats.get接口获取
            /// </summary>
            [JsonPropertyName("category_id")]
            public long CategoryId { get; set; }

            /// <summary>
            /// 商品类目名称
            /// </summary>
            [JsonPropertyName("category_name")]
            public string CategoryName { get; set; }

            /// <summary>
            /// 商品类目ID，使用pdd.goods.cats.get接口获取
            /// </summary>
            [JsonPropertyName("cat_id")]
            public long CatId { get; set; }

            /// <summary>
            /// 商品一~四级类目ID列表
            /// </summary>
            [JsonPropertyName("cat_ids")]
            public List<long> CatIds { get; set; }

            /// <summary>
            /// 店铺收藏券id
            /// </summary>
            [JsonPropertyName("clt_cpn_batch_sn")]
            public string CltCpnBatchSn { get; set; }

            /// <summary>
            /// 店铺收藏券面额,单位为分
            /// </summary>
            [JsonPropertyName("clt_cpn_discount")]
            public long CltCpnDiscount { get; set; }

            /// <summary>
            /// 店铺收藏券截止时间
            /// </summary>
            [JsonPropertyName("clt_cpn_end_time")]
            public long CltCpnEndTime { get; set; }

            /// <summary>
            /// 店铺收藏券使用门槛价格,单位为分
            /// </summary>
            [JsonPropertyName("clt_cpn_min_amt")]
            public long CltCpnMinAmt { get; set; }

            /// <summary>
            /// 店铺收藏券总量
            /// </summary>
            [JsonPropertyName("clt_cpn_quantity")]
            public long CltCpnQuantity { get; set; }

            /// <summary>
            /// 店铺收藏券剩余量
            /// </summary>
            [JsonPropertyName("clt_cpn_remain_quantity")]
            public long CltCpnRemainQuantity { get; set; }

            /// <summary>
            /// 店铺收藏券起始时间
            /// </summary>
            [JsonPropertyName("clt_cpn_start_time")]
            public long CltCpnStartTime { get; set; }

            /// <summary>
            /// 优惠券面额，单位为分
            /// </summary>
            [JsonPropertyName("coupon_discount")]
            public long CouponDiscount { get; set; }

            /// <summary>
            /// 优惠券失效时间，UNIX时间戳
            /// </summary>
            [JsonPropertyName("coupon_end_time")]
            public long CouponEndTime { get; set; }

            /// <summary>
            /// 优惠券门槛价格，单位为分
            /// </summary>
            [JsonPropertyName("coupon_min_order_amount")]
            public long CouponMinOrderAmount { get; set; }

            /// <summary>
            /// 优惠券剩余数量
            /// </summary>
            [JsonPropertyName("coupon_remain_quantity")]
            public long CouponRemainQuantity { get; set; }

            /// <summary>
            /// 优惠券生效时间，UNIX时间戳
            /// </summary>
            [JsonPropertyName("coupon_start_time")]
            public long CouponStartTime { get; set; }

            /// <summary>
            /// 优惠券总数量
            /// </summary>
            [JsonPropertyName("coupon_total_quantity")]
            public long CouponTotalQuantity { get; set; }

            /// <summary>
            /// 创建时间（unix时间戳）
            /// </summary>
            [JsonPropertyName("create_at")]
            public long CreateAt { get; set; }

            /// <summary>
            /// 描述分
            /// </summary>
            [JsonPropertyName("desc_txt")]
            public string DescTxt { get; set; }

            /// <summary>
            /// 商品描述
            /// </summary>
            [JsonPropertyName("goods_desc")]
            public string GoodsDesc { get; set; }

            /// <summary>
            /// 商品轮播图
            /// </summary>
            [JsonPropertyName("goods_gallery_urls")]
            public List<string> GoodsGalleryUrls { get; set; }

            /// <summary>
            /// 商品Id
            /// </summary>
            [JsonPropertyName("goods_id")]
            public long GoodsId { get; set; }

            /// <summary>
            /// 商品主图 
            /// </summary>
            [JsonPropertyName("goods_image_url")]
            public string GoodsImageUrl { get; set; }

            /// <summary>
            /// 商品名称
            /// </summary>
            [JsonPropertyName("goods_name")]
            public string GoodsName { get; set; }

            /// <summary>
            /// 商品缩略图
            /// </summary>
            [JsonPropertyName("goods_thumbnail_url")]
            public string GoodsThumbnailUrl { get; set; }

            /// <summary>
            /// 商品是否有优惠券 true-有，false-没有
            /// </summary>
            [JsonPropertyName("has_coupon")]
            public bool HasCoupon { get; set; }

            /// <summary>
            /// 是否有店铺券
            /// </summary>
            [JsonPropertyName("has_mall_coupon")]
            public bool HasMallCoupon { get; set; }

            /// <summary>
            /// 物流分
            /// </summary>
            [JsonPropertyName("lgst_txt")]
            public string LgstTxt { get; set; }

            /// <summary>
            /// 店铺券折扣
            /// </summary>
            [JsonPropertyName("mall_coupon_discount_pct")]
            public int MallCouponDiscountPct { get; set; }

            /// <summary>
            /// 店铺券结束使用时间
            /// </summary>
            [JsonPropertyName("mall_coupon_end_time")]
            public long MallCouponEndTime { get; set; }

            /// <summary>
            /// 最大使用金额
            /// </summary>
            [JsonPropertyName("mall_coupon_max_discount_amount")]
            public int MallCouponMaxDiscountAmount { get; set; }

            /// <summary>
            /// 最小使用金额
            /// </summary>
            [JsonPropertyName("mall_coupon_min_order_amount")]
            public int MallCouponMinOrderAmount { get; set; }

            /// <summary>
            /// 店铺券余量
            /// </summary>
            [JsonPropertyName("mall_coupon_remain_quantity")]
            public long MallCouponRemainQuantity { get; set; }

            /// <summary>
            /// 店铺券开始使用时间
            /// </summary>
            [JsonPropertyName("mall_coupon_start_time")]
            public long MallCouponStartTime { get; set; }

            /// <summary>
            /// 店铺券总量
            /// </summary>
            [JsonPropertyName("mall_coupon_total_quantity")]
            public long MallCouponTotalQuantity { get; set; }

            /// <summary>
            /// 该商品所在店铺是否参与全店推广，0：否，1：是
            /// </summary>
            [JsonPropertyName("mall_cps")]
            public int MallCps { get; set; }

            /// <summary>
            /// 店铺id
            /// </summary>
            [JsonPropertyName("mall_id")]
            public long MallId { get; set; }

            /// <summary>
            /// 店铺名字
            /// </summary>
            [JsonPropertyName("mall_name")]
            public string MallName { get; set; }

            /// <summary>
            /// 店铺类型，1-个人，2-企业，3-旗舰店，4-专卖店，5-专营店，6-普通店
            /// </summary>
            [JsonPropertyName("merchant_type")]
            public int MerchantType { get; set; }

            /// <summary>
            /// 最小拼团价（单位为分）
            /// </summary>
            [JsonPropertyName("min_group_price")]
            public long MinGroupPrice { get; set; }

            /// <summary>
            /// 最小单买价格（单位为分）
            /// </summary>
            [JsonPropertyName("min_normal_price")]
            public long MinNormalPrice { get; set; }

            /// <summary>
            /// 快手专享
            /// </summary>
            [JsonPropertyName("only_scene_auth")]
            public bool OnlySceneAuth { get; set; }

            /// <summary>
            /// 商品标签ID，使用pdd.goods.opts.get接口获取
            /// </summary>
            [JsonPropertyName("opt_id")]
            public long OptId { get; set; }

            /// <summary>
            /// 商品标签id
            /// </summary>
            [JsonPropertyName("opt_ids")]
            public List<long> OptIds { get; set; }

            /// <summary>
            /// 商品标签名
            /// </summary>
            [JsonPropertyName("opt_name")]
            public string OptName { get; set; }

            /// <summary>
            /// 推广计划类型 3:定向 4:招商
            /// </summary>
            [JsonPropertyName("plan_type")]
            public int PlanType { get; set; }

            /// <summary>
            /// 佣金比例，千分比
            /// </summary>
            [JsonPropertyName("promotion_rate")]
            public long PromotionRate { get; set; }

            /// <summary>
            /// 已售卖件数
            /// </summary>
            [JsonPropertyName("sales_tip")]
            public string SalesTip { get; set; }

            /// <summary>
            /// 服务标签: 4-送货入户并安装,5-送货入户,6-电子发票,9-坏果包赔,11-闪电退款,12-24小时发货,
            /// 13-48小时发货,17-顺丰包邮,18-只换不修,19-全国联保,20-分期付款,24-极速退款,
            /// 25-品质保障,26-缺重包退,27-当日发货,28-可定制化,29-预约配送,1000001-正品发票,
            /// 1000002-送货入户并安装
            /// </summary>
            [JsonPropertyName("service_tags")]
            public List<long> ServiceTags { get; set; }

            /// <summary>
            /// 服务分
            /// </summary>
            [JsonPropertyName("serv_txt")]
            public string ServTxt { get; set; }

            /// <summary>
            /// 招商团长id
            /// </summary>
            [JsonPropertyName("zs_duo_id")]
            public long ZsDuoId { get; set; }

            /// <summary>
            /// 商品视频url
            /// </summary>
            [JsonPropertyName("video_urls")]
            public List<string> VideoUrls { get; set; }
        }
    }
}
