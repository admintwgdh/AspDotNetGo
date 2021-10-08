using AspDotNetGo.Common;
using AspDotNetGo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyLogin.WebApi.Utility.AutoMapper;

namespace AspDotNetGo
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //EFCoreContext efContext = new EFCoreContext();
            services.AddDbContext<EFCoreContext>();

            IFreeSql fsql = new FreeSql.FreeSqlBuilder()
                            .UseConnectionString(FreeSql.DataType.MySql, Configuration["ConnectionStrings:MySQL"]) //����д��json�ļ�
                            .UseAutoSyncStructure(true) //�Զ�ͬ��ʵ��ṹ�����ݿ⣬FreeSql����ɨ����򼯣�ֻ��CRUDʱ�Ż����ɱ�
                            .Build(); //����ض���� Singleton ����ģʽ
            services.AddSingleton(fsql);
            services.AddControllers();
            services.AddSwaggerGen();
            //CustomAutoMapperProfile aa = new CustomAutoMapperProfile<Student, StudentDto>("", "");
            //services.AddAutoMapper(typeof(CustomAutoMapperProfile));
            //services.AddAutoMapper(typeof(CustomAutoMapperProfile<,>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
