using System;
using System.Collections.Generic;
using System.Text;
using Mango.PDD.DDJB.Response;

namespace Mango.PDD.DDJB.Request
{
    /// <summary>
    /// 多多进宝用时间段查询推广订单请求
    /// </summary>
    public class PddOrderListRangeGetRequest : BasePddRequest<PddOrderListRangeGetResponse>
    {
        public PddOrderListRangeGetRequest()
        {
            Type = "pdd.ddk.order.list.range.get";
        }

        /// <summary>
        /// 支付结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 上一次的迭代器id(第一次不填)
        /// </summary>
        public string LastOrderId { get; set; }

        /// <summary>
        /// 每次请求多少条，建议300
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// 支付起始时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 订单类型：1-推广订单；2-直播间订单
        /// </summary>
        public int? QueryOrderType { get; set; }

        public override IDictionary<string, string> GetParameters()
        {
            var param = base.GetParameters();
            param.Add("end_time", EndTime.ToString("yyyy-MM-dd HH:mm:ss"));
            param.Add("last_order_id", LastOrderId);
            param.Add("page_size", PageSize?.ToString());
            param.Add("start_time", StartTime.ToString("yyyy-MM-dd HH:mm:ss"));
            param.Add("query_order_type", QueryOrderType?.ToString());
            return param;
        }
    }
}
