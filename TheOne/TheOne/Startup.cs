using DapperExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;



namespace TheOne
{
    public class Startup
    {
        private readonly WebOption _webOption;
        public Startup(IConfiguration configuration, IOptions<WebOption> webOptionAccessor)
        {
            Configuration = configuration;
            _webOption = webOptionAccessor.Value;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //ע�����ݿ����� 
            //services.Add(new ServiceDescriptor(typeof(IDatabase), new Database(new MySqlConnection(Configuration.GetConnectionString("DefaultConnection")))));
            services.AddDapperDataBase(ESqlDialect.MySQL,
                () => new MySqlConnection(Configuration.GetConnectionString("DefaultConnection")), true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            //app.UseMvc();

            //����Ĭ�Ϸ���
            app.UseMvc(routtes => {
                routtes.MapRoute(name: "Areas", template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routtes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                //routtes.MapRoute(
                //    name: "default",
                //    template: "{controller=Home}/{action=Index}/{id?}");
            });
            //Redirect(_webOption.LoginUrl);
        }

    }
    //��վ����ѡ��ʵ��
    public class WebOption
    {
        public string DefaultUrl { get; set; }

        public string IFrameUrl { get; set; }

        public string LoginUrl { get; set; }

        public string ErroUrl { get; set; }

        public string NoAuthUrl { get; set; }

        public string NoLicUrl { get; set; }

        public string NoFoundUrl { get; set; }

        public string NoAccessUrl { get; set; }

        public string ConfigRole { get; set; }

        //�ļ�����·��
        public string DownloadUrl { get; set; }

        //���������ɫ
        public string SuperUser { get; set; }
    }
}
