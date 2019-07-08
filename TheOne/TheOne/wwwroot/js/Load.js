
////表格数据加载
function renderTable(elem, url, height, cols, where, done, sortData) {

    var table = layui.table;
    table.render({
        elem: elem
        , url: url
        //, cellMinWidth: 200 
        // ,id:'checkTable'
        , height: height
        , method: 'post'
        , limit: 30
        , limits: [30, 50, 100, 300, 500]
        , skin: 'line'//line （行边框风格）   row （列边框风格）   nob （无边框风格）
        , width: 'auto' //全局定义常规单元格的最小宽度，layui 2.2.1 新增
        , page: true
        , size: 'sm'
        //, minWidth: 200
        , initSort: sortData
        , cols: [cols]
        , even: true //开启隔行背景
        , where: where,
        done: done
    });
}
function ShowPage(url, ele) {
    //$('#ContentWindow').attr("src", url);
    //$("#MainMenu li").removeClass("menuHover");
    //$("#" + ele.id).addClass("menuHover");
    //if (localStorage.getItem('bankShen') == 'red') {
    //    var idName = ele.id;
    //    switch (idName) {
    //        case "统计评价":
    //            $(".menuarea li span.newMaiService").css('background-position', '-40px 0px')
    //            $(".menuarea li span.newMonitor").css('background-position', '-20px 0px')
    //            $(".menuarea li span.newStaEvaluation").css('background-position', '-60px -20px')
    //            break;
    //        case "知识库":
    //            $(".menuarea li span.newMonitor").css('background-position', '-20px 0px')
    //            $(".menuarea li span.newStaEvaluation").css('background-position', '-60px 0px')
    //            $(".menuarea li span.newMaiService").css('background-position', '-40px -20px')
    //            break;
    //    }
    //}



}
function ShowPageCon(url) {
    console.log(url);
    //var iframeP = window.parent.document.getElementById("ContentWindow1");
    //$(iframeP).attr('src', url)
    console.log(iframeP);
}
//获取URL参数
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg); //获取url中"?"符后的字符串并正则匹配
    var context = "";
    if (r != null)
        context = r[2];
    reg = null;
    r = null;
    return context == null || context == "" || context == "undefined" ? "" : context;
}
//基础ajax调用函数
//url为传输数据路径
//successFun为数据获取成功后调用函数,传入数据为obj
//data为传入后台的参数
//dataType为传回的数据
function ajaxFucHelper(url, successFun, data, dataType) {
    if (arguments[3] === '' || arguments[3] === undefined) {
        dataType = "json";
    }
    $.ajax({
        type: "POST",
        dataType: dataType,
        async: true,
        url: url,
        data: data,
        success: function (obj) {
            successFun(obj);
        }
    });
}

//laytpl   url:请求路径，data:请求路径所带参数，elmId:元素id，temId：模板id，func：方法，方法有一个参数（data），返回数据
function layui_Tpl(url, data, elmId, temId, func) {
    var arg4 = (arguments[4] != undefined);
    layui.use('laytpl', function () {
        var laytpl = layui.laytpl;
        var TplFSucFun = function (data) {
            var tempConId = document.getElementById(temId);
            var getTpl = tempConId.innerHTML;
            var content = document.getElementById(elmId);
            laytpl(getTpl).render(data, function (html) {
                content.innerHTML = html;
            });
            if (arg4) {
                func(data);
            }
        }
        ajaxFucHelper(url, TplFSucFun, data, "json");
    });
}
