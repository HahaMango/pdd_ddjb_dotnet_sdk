# pdd_ddjb_dotnet_sdk
多多进宝（拼多多客）dotnet SDK

[![Build Status](https://dev.azure.com/q932104843/Mango.PDD.DDJB/_apis/build/status/HahaMango.pdd_ddjb_dotnet_sdk?branchName=master)](https://dev.azure.com/q932104843/Mango.PDD.DDJB/_build/latest?definitionId=8&branchName=master)

目前提供5个常用的多多进宝API封装，以后增加更多或大家可以为该项目贡献更多的API

拼多多开放平台文档 [拼多多开放平台](https://open.pinduoduo.com/application/document/api?id=pdd.ddk.goods.detail)

## 环境

该包在`netstandard2.0`下编译，能满足最低`.net core 2.0`版本和`.net framework 4.6.1`版本。

## 安装使用

在包管理器中使用如下命令进行安装，或者在VS中直接在Nuget包管理中搜索`Mango.PDD.DDJB`安装。

```powershell
Install-Package Mango.PDD.DDJB -Version 1.0.3
```

在代码中使用。

```csharp
//url为拼多多接口URL
var client = new PDDClient(url,clientId,clientSecret);

var req = new PddGoodsDetailRequest
{
    GoodsIdList = new List<long>{ 1517186492 }
};
var rsp = await client.ExecuteAsync(req)
//拿到响应rsp进行业务处理...
```

## pdd.ddk.goods.detail

多多进宝商品详情查询请求

## pdd.ddk.goods.search

拼多多商品搜索请求

## pdd.ddk.order.list.increment.get

多多进宝最后更新时间段增量同步推广订单请求

## pdd.ddk.order.list.range.get

多多进宝用时间段查询推广订单请求

## pdd.ddk.goods.promotion.url.generate

多多进宝推广连接生成请求