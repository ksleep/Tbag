#pragma checksum "E:\MYone\TheOne\TheOne\Areas\Dais\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5371975f43dde21186bdd930cde30adb7fb1c5ac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Dais_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Dais/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Dais/Views/Home/Index.cshtml", typeof(AspNetCore.Areas_Dais_Views_Home_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5371975f43dde21186bdd930cde30adb7fb1c5ac", @"/Areas/Dais/Views/Home/Index.cshtml")]
    public class Areas_Dais_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/layui/layui.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "E:\MYone\TheOne\TheOne\Areas\Dais\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "呆售";
    // Layout = "~/Views/Shared/_Master.cshtml";
    //Layout = "~/Views/Shared/_Layoutfra.cshtml";

#line default
#line hidden
            DefineSection("Heads", async() => {
                BeginContext(155, 275, true);
                WriteLiteral(@"

    <style>
        .righTop {
            margin: 0 auto;
            float: right;
        }

        .table {
            overflow: hidden;
            height: 100%;
        }

        .layui-tab-content {
            padding: 0;
        }
    </style>
");
                EndContext();
            }
            );
            BeginContext(433, 199, true);
            WriteLiteral("<div class=\"table-style\" style=\"margin-top: 10px;\">\r\n    <blockquote class=\"btnPosition\">\r\n        <div class=\"layui-inline btnLeft\" style=\"text-align: center; display:inline-block; width: 100%; \">\r\n");
            EndContext();
            BeginContext(785, 35, true);
            WriteLiteral("        </div>\r\n    </blockquote>\r\n");
            EndContext();
            BeginContext(1505, 401, true);
            WriteLiteral(@"    <table class=""layui-table"" style=""height: 100px;"" id=""bodyTable"" lay-skin=""nob"" lay-data=""{id:'bodyTable'}"" lay-filter=""bodyTableFilter""></table>
</div>

<script type=""text/html"" id=""Type"">
    {{#  if((d.Type.charAt(d.Type.length - 1))  != ""】""){ }}
    <span style=""color:orange;"">{{ d.Type }}】</span>
    {{#  } else{ }}
    <span style=""color:orange;"">{{ d.Type }}</span>
    {{# } }}
");
            EndContext();
            BeginContext(1989, 204, true);
            WriteLiteral("</script>\r\n<script type=\"text/html\" id=\"host\">\r\n    {{#  var fn1 = function(){ return d.host;}; }}\r\n    <a  href=\"javascript:void(0);\" lay-event=\"edit\" class=\"layui-table-link\">{{ fn1()}}</a>\r\n</script>\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2210, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(2216, 44, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ca943a3b7c344110a026eb371d1093b1", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2260, 6941, true);
                WriteLiteral(@"
    <script type=""text/javascript"">

        var colsArry = [
            //{ field: 'id', sort: true, title: '序号' },
            //{ field: 'inum', sort: true, title: '编号' },
            //{ field: 'name', sort: true, width: 300, title: '标题' },
            //{ field: 'type', sort: true, width: 150, title: '类型' },
            //{ field: 'host', sort: true, width: 300, title: '链接', templet: '#host' }
            { field: 'id', sort: true, title: '序号',  width: 80 },
            { field: 'name', sort: true, title: '标题', width: 900 },
            { field: 'type', sort: true, title: '类型', width: 100 },
            { field: 'host', sort: true, width: 300, title: '链接', templet: '#host' }

        ];
        var sortData = { field: 'ID', type: 'desc' }

        loadGrid();
        function loadGrid() {
            layui.use('table',
                function () {
                    var table = layui.table;
                    var form = layui.form;

                    //排序事件
               ");
                WriteLiteral(@"     table.on('sort(bodyTableFilter)',
                        function (data) {
                            sortData = data;
                            loadGrid();
                        });

                    //数据加载
                    var tableWhere = {
                        sortField: sortData.field,
                        sortType: sortData.type,
                        name: $(""#searchName"").val()
                    }
                   // renderTable('#bodyTable', '/Dais/Home/GetData', 'full-5', colsArry, tableWhere, '');
                    renderTable('#bodyTable', '/Dais/Home/PostFunction', 'full-5', colsArry, tableWhere, '');
                    //table.render({
                    //    elem: '#bodyTable'
                    //    , url: '/Dais/Home/PostFunction'
                    //    //, cellMinWidth: 200 
                    //    // ,id:'checkTable'
                    //    , height: 'full-5'
                    //    , method: 'post'
                    //    ");
                WriteLiteral(@", limit: 30
                    //    , limits: [30, 50, 100, 300, 500]
                    //    , skin: 'nob'//line （行边框风格）   row （列边框风格）   nob （无边框风格）
                    //    , width: 'auto' //全局定义常规单元格的最小宽度，layui 2.2.1 新增
                    //    , page: true
                    //    , size: 'sm'
                    //    //, minWidth: 200
                    //    , initSort: sortData
                    //    , cols: [colsArry]
                    //    , even: true //开启隔行背景
                    //    , where: tableWhere,
                    //    done: ''
                    //});
                    table.on('tool(bodyTableFilter)', function (obj) {
                        var data = obj.data;
                        if (obj.event === 'edit') {
                            //console.log(""222"" + data.host);
                            //window.open(""www."" + data.host);
                            var host = ""http://www."" + data.host;
                            window.open(host, '_");
                WriteLiteral(@"blank');
                        }
                        //else if (obj.event === 'del') {
                        //    layer.confirm(""确认删除该数据吗？"", { icon: 3, title: '提示' },
                        //        function (index) {      //确认后执行的操作
                        //            $.ajax({
                        //                type: ""POST"",
                        //                dataType: ""json"",
                        //                url: ""/Monitor/Bayonet/DeleteBayonet"",
                        //                data: { id: data.编码 },
                        //                success: function (data) {
                        //                    if (data) {
                        //                        ShowTip(""删除成功"", 6);
                        //                        CloseMessage();
                        //                    }
                        //                }
                        //            });
                        //        });
                 ");
                WriteLiteral(@"       //}
                        //else if (obj.event === 'detail') {
                        //    var index = layer.open({
                        //        type: 2,
                        //        title: '详细信息',
                        //        content: '/Monitor/Bayonet/DetailDict?id=' + data.编码,
                        //        area: ['1010px', '500px'],
                        //        maxmin: true,
                        //        success: function (layero, index) {
                        //            //隐藏打开窗口按钮
                        //            var body = layer.getChildFrame('body', index);
                        //            setPageDisabled(body);
                        //        }

                        //    });
                        //    layer.full(index);
                        //}
                    });
                });
        }
        layui.use('element', function () {
            var element = layui.element; //导航的hover效果、二级菜单等功能，需要依赖element模块
");
                WriteLiteral(@"
            //var layer = layer.ui;
            ////监听导航点击
            //element.on('nav(demo)', function (elem) {
            //    //console.log(elem)
            //    //var iframeP = window.parent.document.getElementById(""ContentWindow1"");
            //    //$(iframeP).attr('src', url)
            //    layer.msg(""2333"" + elem.text());
            //});
        });
        function Goother(host) {
            console.log(host);
        }

        //var UID = ""UB9B38174E""; // 测试用 用户ID，请更换成您自己的用户ID
        //var KEY = ""6zwtzgq7t8iszozn""; // 测试用key，请更换成您自己的 Key
        //var API = ""http://api.seniverse.com/v3/weather/now.json""; // 获取天气实况
        //var LOCATION = ""beijing""; // 除拼音外，还可以使用 v3 id、汉语等形式
        //// 获取当前时间戳
        //var ts = Math.floor((new Date()).getTime() / 1000);
        //// 构造验证参数字符串
        //var str = ""ts="" + ts + ""&uid="" + UID;
        //// 使用 HMAC-SHA1 方式，以 API 密钥（key）对上一步生成的参数字符串（raw）进行加密
        //// 并将加密结果用 base64 编码，并做一个 urlencode，得到签名 sig
        //var si");
                WriteLiteral(@"g = CryptoJS.HmacSHA1(str, KEY).toString(CryptoJS.enc.Base64);
        //sig = encodeURIComponent(sig);
        //str = str + ""&sig="" + sig;
        //// 构造最终请求的 url
        //var url = API + ""?location="" + LOCATION + ""&"" + str + ""&callback=foo"";
        //console.log(url)
        //// 直接发送请求进行调用，手动处理回调函数
        //$.getJSON(url, function (data) {
        //    console.log(data);
        //    var obj = document.getElementById('content');
        //    var weather = data.results[0];
        //    var text = [];
        //    text.push(""Location: "" + weather.location.path);
        //    text.push(""Weather: "" + weather.now.text);
        //    text.push(""Temperature: "" + weather.now.temperature);
        //    obj.innerText = text.join(""\n"")
        //});
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
