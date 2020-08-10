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
using System.Text.Json.Serialization;

namespace Mango.PDD.DDJB.Request
{
    /// <summary>
    /// 拼多多商品搜索请求
    /// </summary>
    public class PddGoodsSearchRequest : BasePddRequest<PddGoodsSearchResponse>
    {
        public PddGoodsSearchRequest()
        {
            Type = "pdd.ddk.goods.search";
        }

        /// <summary>
        /// 商品活动标记数组，例：[4,7]，4-秒杀 7-百亿补贴等
        /// </summary>
        public List<int> ActivityTags { get; set; }

        /// <summary>
        /// 商品类目ID，使用pdd.goods.cats.get接口获取
        /// </summary>
        public long? CatId { get; set; }

        /// <summary>
        /// 自定义参数
        /// </summary>
        public string CustomParameters { get; set; }

        /// <summary>
        /// 商品ID列表
        /// </summary>
        public long[] GoodsIdList { get; set; }

        /// <summary>
        /// 是否品牌
        /// </summary>
        public bool? IsBrandGoods { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// 翻页时建议填写前页返回的list_id值
        /// </summary>
        public string ListId { get; set; }

        /// <summary>
        /// 店铺类型，1-个人，2-企业，3-旗舰店，4-专卖店，5-专营店，6-普通店（未传为全部）
        /// </summary>
        public int? MerchantType { get; set; }

        /// <summary>
        /// 店铺类型数组
        /// </summary>
        public int[] MerchantTypeList { get; set; }

        /// <summary>
        /// 商品标签类目ID，使用pdd.goods.opt.get获取
        /// </summary>
        public long? OptId { get; set; }

        /// <summary>
        /// 默认值1，商品分页数
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// 默认100，每页商品数量
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// 推广位id
        /// </summary>
        public string Pid { get; set; }

        /// <summary>
        /// 筛选范围列表
        /// </summary>
        public List<RangeItem> RangeList { get; set; }

        /// <summary>
        /// 排序方式:0-综合排序;1-按佣金比率升序;2-按佣金比例降序;3-按价格升序;4-按价格降序;5-按销量升序;6-按销量降序;7-优惠券金额排序升序;8-优惠券金额排序降序;9-券后价升序排序;10-券后价降序排序;
        /// 11-按照加入多多进宝时间升序;12-按照加入多多进宝时间降序;13-按佣金金额升序排序;14-按佣金金额降序排序;15-店铺描述评分升序;16-店铺描述评分降序;17-店铺物流评分升序;18-店铺物流评分降序;19-店铺服务评分升序;
        /// 20-店铺服务评分降序;27-描述评分击败同类店铺百分比升序，28-描述评分击败同类店铺百分比降序，29-物流评分击败同类店铺百分比升序，
        /// 30-物流评分击败同类店铺百分比降序，31-服务评分击败同类店铺百分比升序，32-服务评分击败同类店铺百分比降序
        /// </summary>
        public int? SortType { get; set; }

        /// <summary>
        /// 是否只返回优惠券的商品，false返回所有商品，true只返回有优惠券的商品
        /// </summary>
        public bool? WithCoupon { get; set; }

        public class RangeItem
        {
            /// <summary>
            /// 区间的开始值
            /// </summary>
            [JsonPropertyName("range_from")]
            public long RangeFrom { get; set; }

            /// <summary>
            /// 0，最小成团价 1，券后价 2，佣金比例 3，优惠券价格 4，广告创建时间 5，销量 6，佣金金额 7，店铺描述分 8，店铺物流分 9，店铺服务分 10， 店铺描述分击败同行业百分比
            /// 11， 店铺物流分击败同行业百分比 12，店铺服务分击败同行业百分比 13，商品分 17 ，优惠券/最小团购价 18，过去两小时pv 19，过去两小时销量
            /// </summary>
            [JsonPropertyName("range_id")]
            public int RangeId { get; set; }

            /// <summary>
            /// 区间的结束值
            /// </summary>
            [JsonPropertyName("range_to")]
            public long RangeTo { get; set; }
        }

        public override IDictionary<string, string> GetParameters()
        {
            var param = base.GetParameters();
            param.Add("activity_tags", ActivityTags?.ToJson());
            param.Add("cat_id", CatId?.ToString());
            param.Add("custom_parameters", CustomParameters);
            param.Add("goods_id_list", GoodsIdList?.ToJson());
            param.Add("is_brand_goods", IsBrandGoods?.ToString());
            param.Add("keyword", Keyword);
            param.Add("list_id", ListId);
            param.Add("merchant_type", MerchantType?.ToString());
            param.Add("merchant_type_list", MerchantTypeList?.ToJson());
            param.Add("opt_id", OptId?.ToString());
            param.Add("page", Page?.ToString());
            param.Add("page_size", PageSize?.ToString());
            param.Add("pid", Pid);
            param.Add("sort_type", SortType?.ToString());
            param.Add("with_coupon", WithCoupon?.ToString());
            param.Add("range_list", RangeList?.ToJson());
            return param;
        }
    }
}
