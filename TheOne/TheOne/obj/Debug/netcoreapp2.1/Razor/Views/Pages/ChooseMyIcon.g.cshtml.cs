#pragma checksum "E:\MYone\TheOne\TheOne\Views\Pages\ChooseMyIcon.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8bd2d0da63b8fcafa8d8e07ed57f942e74cffbdc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(TheOne.Pages.Views_Pages_ChooseMyIcon), @"mvc.1.0.view", @"/Views/Pages/ChooseMyIcon.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Pages/ChooseMyIcon.cshtml", typeof(TheOne.Pages.Views_Pages_ChooseMyIcon))]
namespace TheOne.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "E:\MYone\TheOne\TheOne\Views\Pages\_ViewImports.cshtml"
using TheOne;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8bd2d0da63b8fcafa8d8e07ed57f942e74cffbdc", @"/Views/Pages/ChooseMyIcon.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4df3820839c7370c706394adaf7d22624f91927e", @"/Views/Pages/_ViewImports.cshtml")]
    public class Views_Pages_ChooseMyIcon : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Load.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "E:\MYone\TheOne\TheOne\Views\Pages\ChooseMyIcon.cshtml"
  
    ViewData["Title"] = "选择图标";
    //Layout = "~/Views/Shared/_Master.cshtml";
    // Layout = "~/Views/Shared/_Layoutfra.cshtml";


#line default
#line hidden
            BeginContext(144, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Heads", async() => {
                BeginContext(161, 256, true);
                WriteLiteral(@"
    <style>
        /*body, html, form {
            overflow: auto;
        }
            
        .iconfont {
            font-size: 36px !important;
        }*/
        .layui-fixbar {
            /*display: none;*/
        }
    </style>
");
                EndContext();
                BeginContext(545, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(606, 13832, true);
            WriteLiteral(@"<div class=""site-content"" style=""overflow-y:auto"">
    <ul class=""site-doc-icon"">

        <li>
            <i class=""layui-icon"">&#xe601;</i>
            <div class=""name"">硬盘</div>
            <div class=""code"">&amp;#xe601;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe613;</i>
            <div class=""name"">同步中</div>
            <div class=""code"">&amp;#xe613;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe70b;</i>
            <div class=""name"">网络设备</div>
            <div class=""code"">&amp;#xe70b;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe6e5;</i>
            <div class=""name"">状态</div>
            <div class=""code"">&amp;#xe6e5;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe658;</i>
            <div class=""name"">区域</div>
            <div class=""code"">&amp;#xe658;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe62b;</i>
            <div class=""name");
            WriteLiteral(@""">评论</div>
            <div class=""code"">&amp;#xe62b;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe7e5;</i>
            <div class=""name"">配置管理</div>
            <div class=""code"">&amp;#xe7e5;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe623;</i>
            <div class=""name"">安全</div>
            <div class=""code"">&amp;#xe623;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe603;</i>
            <div class=""name"">信号</div>
            <div class=""code"">&amp;#xe603;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe605;</i>
            <div class=""name"">配置</div>
            <div class=""code"">&amp;#xe605;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe817;</i>
            <div class=""name"">品牌 (1)</div>
            <div class=""code"">&amp;#xe817;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe670;</i>
            <div class=""name"">品牌");
            WriteLiteral(@"</div>
            <div class=""code"">&amp;#xe670;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe64c;</i>
            <div class=""name"">实时</div>
            <div class=""code"">&amp;#xe64c;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe60b;</i>
            <div class=""name"">智能箱1</div>
            <div class=""code"">&amp;#xe60b;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe75d;</i>
            <div class=""name"">字典</div>
            <div class=""code"">&amp;#xe75d;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe694;</i>
            <div class=""name"">评论</div>
            <div class=""code"">&amp;#xe694;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe61d;</i>
            <div class=""name"">自定义</div>
            <div class=""code"">&amp;#xe61d;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe746;</i>
            <div class=""name"">发现1</div>");
            WriteLiteral(@"
            <div class=""code"">&amp;#xe746;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe635;</i>
            <div class=""name"">告警</div>
            <div class=""code"">&amp;#xe635;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe631;</i>
            <div class=""name"">工单</div>
            <div class=""code"">&amp;#xe631;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe604;</i>
            <div class=""name"">人员</div>
            <div class=""code"">&amp;#xe604;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe624;</i>
            <div class=""name"">消息</div>
            <div class=""code"">&amp;#xe624;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe602;</i>
            <div class=""name"">应用</div>
            <div class=""code"">&amp;#xe602;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe6dc;</i>
            <div class=""name"">公告</div>
        ");
            WriteLiteral(@"    <div class=""code"">&amp;#xe6dc;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe600;</i>
            <div class=""name"">点赞</div>
            <div class=""code"">&amp;#xe600;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe62f;</i>
            <div class=""name"">点赞</div>
            <div class=""code"">&amp;#xe62f;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe645;</i>
            <div class=""name"">升级</div>
            <div class=""code"">&amp;#xe645;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe611;</i>
            <div class=""name"">项目</div>
            <div class=""code"">&amp;#xe611;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe612;</i>
            <div class=""name"">文件</div>
            <div class=""code"">&amp;#xe612;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe66b;</i>
            <div class=""name"">拓扑图</div>
            <div ");
            WriteLiteral(@"class=""code"">&amp;#xe66b;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe607;</i>
            <div class=""name"">下载</div>
            <div class=""code"">&amp;#xe607;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe649;</i>
            <div class=""name"">公告</div>
            <div class=""code"">&amp;#xe649;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe616;</i>
            <div class=""name"">文件</div>
            <div class=""code"">&amp;#xe616;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe619;</i>
            <div class=""name"">系统配置</div>
            <div class=""code"">&amp;#xe619;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe61c;</i>
            <div class=""name"">用户角色配置</div>
            <div class=""code"">&amp;#xe61c;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe646;</i>
            <div class=""name"">信号 (1)</div>
            <div ");
            WriteLiteral(@"class=""code"">&amp;#xe646;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe711;</i>
            <div class=""name"">主机</div>
            <div class=""code"">&amp;#xe711;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe618;</i>
            <div class=""name"">区域</div>
            <div class=""code"">&amp;#xe618;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe621;</i>
            <div class=""name"">停电</div>
            <div class=""code"">&amp;#xe621;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe60e;</i>
            <div class=""name"">发出</div>
            <div class=""code"">&amp;#xe60e;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe610;</i>
            <div class=""name"">收到</div>
            <div class=""code"">&amp;#xe610;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe6dd;</i>
            <div class=""name"">问题</div>
            <div class=""cod");
            WriteLiteral(@"e"">&amp;#xe6dd;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe690;</i>
            <div class=""name"">求和</div>
            <div class=""code"">&amp;#xe690;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe61e;</i>
            <div class=""name"">设备</div>
            <div class=""code"">&amp;#xe61e;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe61f;</i>
            <div class=""name"">工单2</div>
            <div class=""code"">&amp;#xe61f;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe620;</i>
            <div class=""name"">季</div>
            <div class=""code"">&amp;#xe620;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe622;</i>
            <div class=""name"">周</div>
            <div class=""code"">&amp;#xe622;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe625;</i>
            <div class=""name"">日</div>
            <div class=""code"">&amp;#xe6");
            WriteLiteral(@"25;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe626;</i>
            <div class=""name"">月</div>
            <div class=""code"">&amp;#xe626;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe627;</i>
            <div class=""name"">周期</div>
            <div class=""code"">&amp;#xe627;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe628;</i>
            <div class=""name"">年</div>
            <div class=""code"">&amp;#xe628;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe62a;</i>
            <div class=""name"">无电</div>
            <div class=""code"">&amp;#xe62a;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe62e;</i>
            <div class=""name"">无网</div>
            <div class=""code"">&amp;#xe62e;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe643;</i>
            <div class=""name"">设备管理</div>
            <div class=""code"">&amp;#xe643;</div>");
            WriteLiteral(@"
        </li>

        <li>
            <i class=""layui-icon"">&#xe608;</i>
            <div class=""name"">谷歌</div>
            <div class=""code"">&amp;#xe608;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe632;</i>
            <div class=""name"">卡口</div>
            <div class=""code"">&amp;#xe632;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe633;</i>
            <div class=""name"">录像</div>
            <div class=""code"">&amp;#xe633;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe634;</i>
            <div class=""name"">资产</div>
            <div class=""code"">&amp;#xe634;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe636;</i>
            <div class=""name"">网络设备</div>
            <div class=""code"">&amp;#xe636;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe637;</i>
            <div class=""name"">受控资产</div>
            <div class=""code"">&amp;#xe637;</div>
     ");
            WriteLiteral(@"   </li>

        <li>
            <i class=""layui-icon"">&#xe639;</i>
            <div class=""name"">状态</div>
            <div class=""code"">&amp;#xe639;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe63a;</i>
            <div class=""name"">业务</div>
            <div class=""code"">&amp;#xe63a;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe63b;</i>
            <div class=""name"">类型</div>
            <div class=""code"">&amp;#xe63b;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe63c;</i>
            <div class=""name"">项目</div>
            <div class=""code"">&amp;#xe63c;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe63d;</i>
            <div class=""name"">单位</div>
            <div class=""code"">&amp;#xe63d;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe629;</i>
            <div class=""name"">关键</div>
            <div class=""code"">&amp;#xe629;</div>
        </li>
");
            WriteLiteral(@"
        <li>
            <i class=""layui-icon"">&#xe62d;</i>
            <div class=""name"">工具</div>
            <div class=""code"">&amp;#xe62d;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe630;</i>
            <div class=""name"">结构</div>
            <div class=""code"">&amp;#xe630;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe638;</i>
            <div class=""name"">报警</div>
            <div class=""code"">&amp;#xe638;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe63e;</i>
            <div class=""name"">动力环境</div>
            <div class=""code"">&amp;#xe63e;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe63f;</i>
            <div class=""name"">平均</div>
            <div class=""code"">&amp;#xe63f;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe640;</i>
            <div class=""name"">上传</div>
            <div class=""code"">&amp;#xe640;</div>
        </li>

      ");
            WriteLiteral(@"  <li>
            <i class=""layui-icon"">&#xe641;</i>
            <div class=""name"">拓扑</div>
            <div class=""code"">&amp;#xe641;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe642;</i>
            <div class=""name"">目录</div>
            <div class=""code"">&amp;#xe642;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe644;</i>
            <div class=""name"">卡口抓拍</div>
            <div class=""code"">&amp;#xe644;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe647;</i>
            <div class=""name"">卡口综合</div>
            <div class=""code"">&amp;#xe647;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe648;</i>
            <div class=""name"">通道</div>
            <div class=""code"">&amp;#xe648;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe64a;</i>
            <div class=""name"">品牌型号</div>
            <div class=""code"">&amp;#xe64a;</div>
        </li>

        <l");
            WriteLiteral(@"i>
            <i class=""layui-icon"">&#xe64b;</i>
            <div class=""name"">任务计划</div>
            <div class=""code"">&amp;#xe64b;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe64d;</i>
            <div class=""name"">事务计划</div>
            <div class=""code"">&amp;#xe64d;</div>
        </li>

        <li>
            <i class=""layui-icon"">&#xe64e;</i>
            <div class=""name"">原始数据</div>
            <div class=""code"">&amp;#xe64e;</div>
        </li>
    </ul>
</div>
");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(14455, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(14461, 36, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "af4d629c484441ecaad8238a8eda4cb4", async() => {
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
                BeginContext(14497, 541, true);
                WriteLiteral(@"
    <script type=""text/javascript"">
        $("".site-doc-icon li"").on(""click"", function () {
            console.log($(this).find("".code"").text());
            var iconVAL = $(this).find("".code"").text();
            var pname = GetQueryString('name');
            var pshow = GetQueryString('show');
            console.log(pname);
            console.log(pshow);
            parent.$(""#"" + pname).val(iconVAL);
            parent.$(""#"" + pshow).html(iconVAL);
            //parent.layer.closeAll();
        });
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
