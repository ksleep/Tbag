#pragma checksum "E:\MYone\TheOne\TheOne\Areas\Tieba\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "979f22d4b04b262244e81c08f19cb21333c69486"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Tieba_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Tieba/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Tieba/Views/Home/Index.cshtml", typeof(AspNetCore.Areas_Tieba_Views_Home_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"979f22d4b04b262244e81c08f19cb21333c69486", @"/Areas/Tieba/Views/Home/Index.cshtml")]
    public class Areas_Tieba_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "E:\MYone\TheOne\TheOne\Areas\Tieba\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "第二页面";
    //Layout = "~/Views/Shared/_Layoutfra.cshtml";

#line default
#line hidden
            DefineSection("Heads", async() => {
                BeginContext(107, 207, true);
                WriteLiteral("\r\n\r\n    <style>\r\n        .righTop {\r\n            margin: 0 auto;\r\n            float: right;\r\n        }\r\n\r\n        .table {\r\n            overflow: hidden;\r\n            height: 100%;\r\n        }\r\n    </style>\r\n");
                EndContext();
            }
            );
            BeginContext(317, 199, true);
            WriteLiteral("<div class=\"table-style\" style=\"margin-top: 10px;\">\r\n    <blockquote class=\"btnPosition\">\r\n        <div class=\"layui-inline btnLeft\" style=\"text-align: center; display:inline-block; width: 100%; \">\r\n");
            EndContext();
            BeginContext(669, 44, true);
            WriteLiteral("        </div>\r\n       \r\n    </blockquote>\r\n");
            EndContext();
            BeginContext(1398, 382, true);
            WriteLiteral(@"
</div>
<table class=""layui-table"" style=""height: 100px;"" id=""bodyTable"" lay-data=""{id:'bodyTable'}"" lay-filter=""bodyTableFilter""></table>
<script type=""text/html"" id=""Type"">
    {{#  if((d.Type.charAt(d.Type.length - 1))  != ""】""){ }}
    <span style=""color:orange;"">{{ d.Type }}】</span>
    {{#  } else{ }}
    <span style=""color:orange;"">{{ d.Type }}</span>
    {{# } }}
");
            EndContext();
            BeginContext(1863, 358, true);
            WriteLiteral(@"</script>
<script type=""text/html"" id=""Link"">
    <a href=""{{d.Link}}"" class=""layui-table-link"" target=""_blank"">{{ d.Link }}</a>
</script>
<script type=""text/html"" id=""Time"">
    {{#  if((d.Time)  != null){ }}
    <span style=""color:forestgreen;"">{{ d.Time }}】</span>
    {{#  } else{ }}
    <span style=""color:forestgreen;"">--</span>
    {{# } }}
");
            EndContext();
            BeginContext(2304, 11, true);
            WriteLiteral("</script>\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2332, 4500, true);
                WriteLiteral(@"
    <script type=""text/javascript"">
        var colsArry = [
            { field: 'ID', sort: true, title: '序号' },
            { field: 'Title', sort: true, title: '标题', width: 220 },
            { field: 'Link', sort: true, title: '链接', templet: '#Link', width: 200 },
            { field: 'Type', sort: true, title: '类型', templet: '#Type', width: 80 },
            { field: 'Time', sort: true, title: '时间', templet: '#Time', width: 200 }

        ];
        var sortData = { field: 'ID', type: 'desc' }

        loadGrid();
        function loadGrid() {
            layui.use('table',
                function () {
                    var table = layui.table;
                    var form = layui.form;

                    //排序事件
                    table.on('sort(bodyTableFilter)',
                        function (data) {
                            sortData = data;
                            loadGrid();
                        });

                    //数据加载
                    var ta");
                WriteLiteral(@"bleWhere = {
                        sortField: sortData.field,
                        sortType: sortData.type,
                        name: $(""#searchName"").val()
                    }
                    renderTable('#bodyTable', '/Tieba/Home/GetData', 'full-5', colsArry, tableWhere, '');



                });
        }
        layui.use('element', function () {
            var element = layui.element; //导航的hover效果、二级菜单等功能，需要依赖element模块

            //监听导航点击
            //element.on('nav(demo)', function (elem) {
            //    //console.log(elem)
            //    layer.msg(elem.text());
            //});
        });



        //setInterval(refreshColor, 20000);

        function refreshColor() {
            var myDate = new Date();
            //console.log(""当前小时shu"" + myDate.getHours());
            console.log(""当前小时---"" + myDate.getHours());
            console.log(""当前分钟---"" + myDate.getMinutes());
        }

        //var myWeather = (function () {
        //    ");
                WriteLiteral(@"var funShun = ""https://api.thinkpage.cn/v3/weather/now.json?location=Fushun&callback=showWeather&""
        //    return {
        //        el: {},
        //        init: function () {
        //            var that = this;
        //            $.extend(that.el, {
        //                'nowWeather': $('.now-weather'),
        //                'nowTemperature': $('.now-temperature')
        //            })
        //        },
        //        getUrl: function () {
        //            var time = Math.round(new Date().getTime() / 1000);
        //            var str = ""ts="" + time + ""&ttl=30&uid=UF4C86B626"";
        //            var hash = CryptoJS.HmacSHA1(str, ""nvczde0rd9tkkr3o"");
        //            var base = hash.toString(CryptoJS.enc.Base64);
        //            var sig = encodeURIComponent(base);
        //            var url = funShun + str + ""&sig="" + sig;
        //            return url;
        //        },
        //        getWeather: function () {
        //   ");
                WriteLiteral(@"         var that = this;
        //            console.log(that.el.nowWeather)
        //            $.ajax({
        //                url: that.getUrl(),
        //                jsonp: 'callback',
        //                jsonpCallback: 'showWeather',
        //                success: function (data) {
        //                    function showWeather(data) {
        //                        that.el.nowWeather.html(data.results[0].now.text)
        //                        that.el.nowTemperature.html(data.results[0].now.temperature)
        //                        $.cookie('weather', JSON.stringify(data))
        //                    }
        //                    eval(data);
        //                }
        //            })
        //        },
        //        rundev: function () {
        //            this.init();
        //            this.getWeather();
        //            //if ($.cookie('weather') != '') {
        //            //    var weather = $.parseJSON($.co");
                WriteLiteral(@"okie('weather'))
        //            //    this.el.nowWeather.html(weather.results[0].now.text)
        //            //    this.el.nowTemperature.html(weather.results[0].now.temperature)
        //            //} else {
        //            //    this.getWeather();
        //            //}
        //        }
        //    }
        //})()
        //myWeather.rundev();
    </script>

");
                EndContext();
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
