using System;
using System.Collections.Generic;
using System.Text;
using Mango.PDD.DDJB.Response;

namespace Mango.PDD.DDJB.Request
{
    /// <summary>
    /// 多多进宝商品详情查询请求
    /// </summary>
    public class PddGoodsDetailRequest : BasePddRequest<PddGoodsDetailResponse>
    {
        public PddGoodsDetailRequest()
        {
            Type = "pdd.ddk.goods.detail";
        }

        /// <summary>
        /// 自定义参数
        /// </summary>
        public string CustomParameters { get; set; }

        /// <summary>
        /// 商品ID，仅支持单个查询。例如：[123456]
        /// </summary>
        public List<long> GoodsIdList { get; set; }

        /// <summary>
        /// 推广位id
        /// </summary>
        public string Pid { get; set; }

        /// <summary>
        /// 佣金优惠券对应推广类型，3：专属 4：招商
        /// </summary>
        public int? PlanType { get; set; }

        /// <summary>
        /// 搜索id，建议填写，提高收益。来自pdd.ddk.goods.recommend.get、pdd.ddk.goods.search、pdd.ddk.top.goods.list.query等接口
        /// </summary>
        public string SearchId { get; set; }

        /// <summary>
        /// 招商多多客ID
        /// </summary>
        public long? ZsDuoId { get; set; }

        public override IDictionary<string, string> GetParameters()
        {
            var param = base.GetParameters();
            param.Add("custom_parameters", CustomParameters);
            param.Add("goods_id_list", GoodsIdList?.ToJson());
            param.Add("pid", Pid);
            param.Add("plan_type", PlanType?.ToString());
            param.Add("search_id", SearchId);
            param.Add("zs_duo_id", ZsDuoId?.ToString());
            return param;
        }
    }
}
