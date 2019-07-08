using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace TheOne
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region MyRegion
            //Thread threadWatch = null; //负责监听客户端的线程 
            //Socket socketWatch = null; //负责监听客户端的套接字
            ////定义一个套接字用于监听客户端发来的信息  包含3个参数(IP4寻址协议,流式连接,TCP协议)  
            //socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            ////服务端发送信息 需要1个IP地址和端口号  
            //IPAddress ipaddress = IPAddress.Parse("127.0.0.1"); //获取文本框输入的IP地址  

            ////将IP地址和端口号绑定到网络节点endpoint上   
            //IPEndPoint endpoint = new IPEndPoint(ipaddress, 8081); //获取文本框上输入的端口号  

            ////监听绑定的网络节点  
            //socketWatch.Bind(endpoint);

            ////将套接字的监听队列长度限制为20  
            //socketWatch.Listen(20);
            ////创建一个监听线程   
            ////threadWatch = new Thread(WatchConnecting);

            ////将窗体线程设置为与后台同步  
            ////threadWatch.IsBackground = true;

            ////启动线程  
            ////threadWatch.Start();

            //try
            //{

            //        socketWatch.Connect(endpoint);
            //        Console.WriteLine("连接{0}成功!", endpoint);
            //         socketWatch.Close();
            //}
            //catch (SocketException e)
            //{
            //    Console.WriteLine("连接{0}失败", endpoint);
            //}
            ////启动线程后 txtMsg文本框显示相应提示  
            //Console.WriteLine("开始监听客户端传来的信息!");



            //Thread th = new Thread(Listen);
            //th.IsBackground = true;
            //th.Start(socketWatch);

            //Console.WriteLine("hello world!");
            ////新建一个套接字Socket即创建Socket
            ////Socket（AddressFamily.InterNetwork， SocketType.Stream， ProtocolType.Tcp） ”这一行创建了一个套接字， 它的3个参数分别代表地址族、 套接字类型和协议。 地址族指明是使用IPv4还是IPv6， 含义如表6-8所示， 本例中使用的是IPv4， 即InterNetwork
            //Socket listenfd = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ////Bind指定套接字的IP和端口
            ////listenfd.Bind（ipEp） 将给listenfd套接字绑定IP和端口。 示例程序中绑定的是本地地址“127.0.0.1”和1234号端口。 127.0.0.1是回送地址， 指本地机， 一般用于测试。 读者也可以设置成真实的IP地址， 然后在两台电脑上分别运行客户端和服务端程序。
            //IPAddress ipAdr = IPAddress.Parse("39.105.2.189");//根据IP地址创建IPAddress对象，如IPAddress.Parse("192.168.1.1")

            //IPEndPoint ipEp = new IPEndPoint(ipAdr, 8081);//用IPAddress指定的地址和端口号初始化
            //                                              //服务端通过listenfd.Listen（0） 开启监听， 等待客户端连接。 参数backlog指定队列中最多可容纳等待接受的连接数， 0表示不限制
            //listenfd.Bind(ipEp); //IP和端口应该是可配置

            ////listenfd.Connect(ipEp);
            //listenfd.Listen(1024);
            //Console.WriteLine("连接{0}成功!", ipEp);
            ////listenfd.Close();

            //Console.WriteLine("[服务器]启动成功");
            //while (true)
            //{
            //    //Accept
            //    //开启监听后， 服务器调用listenfd.Accept（） 接收客户端连接。 本例使用的所有Socket方法都是阻塞方法， 也就是说当没有客户端连接时， 服务器程序会卡在listenfd.Accept（） 处， 而不会往下执行， 直到
            //    //接收了客户端的连接。 Accept返回一个新客户端的Socket， 对于服务器来说， 它有一个监听Socket（例子中的listenfd） 用来接收（Accept） 客户端的连接， 对每个客户端来说还有一个专门的Socket（例子中的
            //    //connfd） 用来处理该客户端的数据
            //    Socket connfd = listenfd.Accept();
            //    Console.WriteLine("[服务器]Accept");
            //    //Recv
            //    //服务器通过connfd.Receive接收客户端数据， Receive也是阻塞方法， 没有收到客户端数据时， 程序将卡在Receive处， 而不会往下执行。 Receive带有一个byte[]类型的参数， 它将存储接收到的数据， Receive
            //    //的返回值则指明接收到的数据的长度。 之后使用System.Text.Encoding.UTF8.GetString（readBuff， 0， count） 将byte[] 数组转换成字符串显示在屏幕上。
            //    byte[] readBuff = new byte[1024];
            //    int count = connfd.Receive(readBuff);
            //    string str = System.Text.Encoding.UTF8.GetString(readBuff, 0, count);
            //    Console.WriteLine("[服务器接收]" + str);
            //    //Send
            //    //服务器通过connfd.Send发送数据， 它接受一个byte[]类型的参数指明要发送的内容。 Send的返回值指明发送数据的长度（例子中没有使用） 。 服务器程序用System.Text.Encoding.Default.GetBytes（字符串）
            //    //把字符串转换成byte[] 数组， 然后发送给客户端（且会在字符串前面加上“serv echo”） 
            //    byte[] bytes = System.Text.Encoding.Default.GetBytes("serv echo" + str);
            //    connfd.Send(bytes);

            //}






            //BuildWebHost(args).Run();

            #endregion

            try
            {
                BuildWebHost(args).Run();
                //BuildWebHost(null).Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                if (e is System.IO.IOException)
                    Console.WriteLine("端口可能被占用，请检测端口号： netstat -ano|findstr（Windows） netstat -lnp|grep(Linux)");
            }
        }

        //public static IWebHost BuildWebHost(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>()
        //        .Build();
        public static IWebHost BuildWebHost(string[] args)
        {
            //string ipAddress = "121.14.64.155";
            ////string ipAddress = "39.105.2.189";
            //int portNum = 3724;
            //IPAddress ip = IPAddress.Parse(ipAddress);
            //IPEndPoint point = new IPEndPoint(ip, portNum);
            //try
            //{

            //    using (Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            //    {
            //        sock.Connect(point);
            //        Console.WriteLine("连接{0}成功!", point);
            //        //if (sock=true)
            //        //{

            //        //}
            //        sock.Close();
            //    }
            //}
            //catch (SocketException e)
            //{
            //    Console.WriteLine("连接{0}失败", point);
            //}
            //var settings = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json")
            //    .Build();
            //var webPort = settings["WebOption:WebPort"];
          
            return WebHost.CreateDefaultBuilder(args)
                .UseUrls($@"http://*:5005")
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();
        }

       



    }
}
