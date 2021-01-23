using Back.Repository;
using Back.Repository.Interface;
using Back.Services;
using Back.Services.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Linq;
using WebApi.Data;

namespace Back
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors();

            services.AddResponseCompression(opt =>
            {
                opt.Providers.Add<GzipCompressionProvider>();
                opt.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/json" });
            });

            services.AddControllers();

            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API GER_EPI", Version = "V1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                  new OpenApiSecurityScheme
                  {
                    Reference = new OpenApiReference
                    {
                      Type = ReferenceType.SecurityScheme,
                      Id = "Bearer"
                    }
                    },
                    new string[] { }
                  }
                    });
            });

            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("connectionStrings")));

            services.AddScoped<DataContext, DataContext>();

            services.AddTransient<ICargoServices, CargoServices>();
            services.AddTransient<ICargoRepository, CargoRepository>();

            services.AddTransient<ICategoriaServices, CategoriaServices>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();

            services.AddTransient<ICentro_CustoServices, Centro_CustoServices>();
            services.AddTransient<ICentro_CustoRepository, Centro_CustoRepository>();

            services.AddTransient<IClassificacaoServices, ClassificacaoServices>();
            services.AddTransient<IClassificacaoRepository, ClassificacaoRepository>();

            services.AddTransient<IClassificacaoServices, ClassificacaoServices>();
            services.AddTransient<IClassificacaoRepository, ClassificacaoRepository>();

            services.AddTransient<IDivisaoServices, DivisaoServices>();
            services.AddTransient<IDivisaoRepository, DivisaoRepository>();
            
            services.AddTransient<IEmpresaServices, EmpresaServices>();
            services.AddTransient<IEmpresaRepository, EmpresaRepository>();

            services.AddTransient<IEntradaServices, EntradaServices>();
            services.AddTransient<IEntradaRepository, EntradaRepository>();

            services.AddTransient<IFamiliaServices, FamiliaServices>();
            services.AddTransient<IFamiliaRepository, FamiliaRepository>();

            services.AddTransient<IFornecedorServices, FornecedorServices>();
            services.AddTransient<IFornecedorRepository, FornecedorRepository>();

            services.AddTransient<IEntrega_MobileServices, Entrega_MobileServices>();
            services.AddTransient<IEntrega_MobileRepository, Entrega_MobileRepository>();

            services.AddTransient<IEPI_EntregueServices, EPI_EntregueServices>();
            services.AddTransient<IEPI_EntregueRepository, EPI_EntregueRepository>();

            services.AddTransient<IEquipamentoServices, EquipamentoServices>();
            services.AddTransient<IEquipamentoRepository, EquipamentoRepository>();

            services.AddTransient<IGrade_TamanhoServices, Grade_TamanhoServices>();
            services.AddTransient<IGrade_TamanhoRepository, Grade_TamanhoRepository>();

            services.AddTransient<IGSEServices, GSEServices>();
            services.AddTransient<IGSERepository, GSERepository>();

            services.AddTransient<IIntegranteServices, IntegranteServices>();
            services.AddTransient<IIntegranteRepository, IntegranteRepository>();

            services.AddTransient<IIntegranteBiometriaServices, IntegranteBiometriaServices>();
            services.AddTransient<IIntegranteBiometriaRepository, IntegranteBiometriaRepository>();

            services.AddTransient<ILocalServices, LocalServices>();
            services.AddTransient<ILocalRepository, LocalRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo JWT Api");
            });
        }
    }
}
