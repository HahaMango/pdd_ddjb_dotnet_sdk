using Mango.PDD.DDJB.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mango.PDD.DDJB.Request
{
    /// <summary>
    /// 多多进宝最后更新时间段增量同步推广订单请求
    /// </summary>
    public class PddOrderListIncrementGetRequest : BasePddRequest<PddOrderListIncrementGetResponse>
    {
        public PddOrderListIncrementGetRequest()
        {
            Type = "pdd.ddk.order.list.increment.get";
        }

        /// <summary>
        /// 查询结束时间，和开始时间相差不能超过24小时。note：此时间为时间戳，指格林威治时间 1970 年01 月 01 日 00 时 00 分 00 秒(北京时间 1970 年 01 月 01 日 08 时 00 分 00 秒)起至现在的总秒数
        /// </summary>
        public long EndUpdateTime { get; set; }

        /// <summary>
        /// 第几页，从1到10000，默认1，注：使用最后更新时间范围增量同步时，必须采用倒序的分页方式（从最后一页往回取）才能避免漏单问题。
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// 返回的每页结果订单数，默认为100，范围为10到100，建议使用40~50，可以提高成功率，减少超时数量。
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// 是否返回总数，默认为true，如果指定false, 则返回的结果中不包含总记录数，通过此种方式获取增量数据，效率在原有的基础上有80%的提升。
        /// </summary>
        public bool? ReturnCount { get; set; }

        /// <summary>
        /// 最近90天内多多进宝商品订单更新时间--查询时间开始。note：此时间为时间戳，指格林威治时间 1970 年01 月 01 日 00 时 00 分 00 秒(北京时间 1970 年 01 月 01 日 08 时 00 分 00 秒)起至现在的总秒数
        /// </summary>
        public long StartUpdateTime { get; set; }

        /// <summary>
        /// 订单类型：1-推广订单；2-直播间订单
        /// </summary>
        public int? QueryOrderType { get; set; }

        public override IDictionary<string, string> GetParameters()
        {
            var param = base.GetParameters();
            param.Add("end_update_time", EndUpdateTime.ToString());
            param.Add("page", Page?.ToString());
            param.Add("page_size", PageSize?.ToString());
            param.Add("return_count", ReturnCount?.ToString());
            param.Add("start_update_time", StartUpdateTime.ToString());
            param.Add("query_order_type", QueryOrderType?.ToString());
            return param;
        }
    }
}
