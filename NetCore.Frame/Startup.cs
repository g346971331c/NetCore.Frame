using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NetCore.Frame.Filter;
using NetCore.Frame.Profile;
using NetCore.Repository;
using NetCore.Services.AutoFacExtension;

namespace NetCore.Frame
{
    public class Startup
    {

        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            #region swagger 配置
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Demo", Version = "v1" });
                //获取xml文件名
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //添加控制器层注释，true 表示显示控制器注释
                c.IncludeXmlComments(xmlPath, true);
                //本地验证访问权限X-token 参数过滤器
                c.OperationFilter<GlobalHttpHeaderOperationFilter>();
            });

            #endregion


            #region 数据库相关
            var dbType = Configuration.GetSection("AppSetting.DbType").Value;
            if (dbType == Define.DBTYPE_SQLSERVER)
            {
                services.AddDbContext<DataDBContext>(options => options.UseSqlServer(GetConnectionStrings()));

                //services.AddDbContext<DataDBContext>(options => options.UseSqlServer(GetConnectionStrings(), opt =>
                //opt.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: new int[] { 2 })));
            }
            else
            {

            }
            #endregion

            #region Redis


            #endregion
            // services.AddAutoMapper(typeof(AutoMapperConfig));

            //控制器方法过滤器
            services.AddControllers(option =>
            {
                option.Filters.Add<ApiFilter>();
            });

            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            //添加启用ui 才能通过浏览器访问api 的swagger界面
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NetCore.Frame.Gan v1");
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            AutofacExt.InitAutoFac(builder);
        }

        private string GetConnectionStrings()
        {
            string conn = Configuration.GetSection("ConnectionStrings.DbContext").Value.Replace("##", " ");
            return conn;
        }
    }
}
