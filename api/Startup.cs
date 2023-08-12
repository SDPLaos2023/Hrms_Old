 using hrm_api.Data.attendance;
using hrm_api.Data.auth;
using hrm_api.Data.hr;
using hrm_api.Services;
using hrm_api.Services.Interfaces;
using hrm_api.Services.Interfaces.attendance;
using hrm_api.Services.Interfaces.auth;
using hrm_api.Services.Interfaces.hr;
using log4net.Config;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MySqlConnector;
using System;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace hrm_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
            XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));

        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder
                                      .AllowAnyOrigin()
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                                  });
            });
            //.WithOrigins("http://localhost","http://localhost:4200")

            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });

            services.AddControllers().AddNewtonsoftJson(option =>
            {
                option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddMvc(option => option.EnableEndpointRouting = false).AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "hrm_api", Version = "v1" });
            });

            services.AddSingleton<IConfiguration>(Configuration);
            var key = Configuration["Keys:secret"];
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    ValidateIssuer = false,
                    ValidateAudience = false

                };
            });
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddTransient<IJwtAuthenticationManager, JwtAuthenticationManager>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IDepartmentServices, DepartmentServices>();
            services.AddTransient<IDivisionServices, DivisionServices>();
            services.AddTransient<ISectionServices, SectionServices>();
            services.AddTransient<IPositionServices, PositionServices>();
            services.AddTransient<INationalyAndRaceServices, NationalyAndRaceServices>();
            services.AddTransient<IBloodGroupServices, BloodGroupServices>();
            services.AddTransient<ICountryServices, CountryServices>();
            services.AddTransient<IMaritalStatusServices, MaritalStatusServices>();
            services.AddTransient<IWorkingTypeServices, WorkingTypeServices>();
            services.AddTransient<IEmployeeTypeServices, EmployeeTypeServices>();
            services.AddTransient<IEducationDegreeTypeServices, EducationDegreeTypeServices>();
            services.AddTransient<ISalaryTypeServices, SalaryTypeServices>();
            services.AddTransient<IContractTypeServices, ContractTypeServices>();
            services.AddTransient<IResignationReasonServices, ResignationReasonServices>();
            services.AddTransient<IEmployeeLevelServices, EmployeeLevelServices>();
            services.AddTransient<IEmployeeGroupServices, EmployeeGroupServices>();
            services.AddTransient<IEmployeeCategoryServices, EmployeeCategoryServices>();
            services.AddTransient<IProvinceServices, ProvinceServices>();
            services.AddTransient<IDistrictServices, DistrictServices>();
            services.AddTransient<IBankInfoServices, BankInfoServices>();
            services.AddTransient<ICurrencyServices, CurrencyServices>();
            services.AddTransient<ISalaryPayTypeServices, SalaryPayTypeServices>();
            services.AddTransient<ITransactionTypeServices, TransactionTypeServices>();
            services.AddTransient<IInstitutionServices, InstitutionServices>();
            services.AddTransient<IEmployeeServices, EmployeeServices>();
            services.AddTransient<IEmployeeFamilyContactServices, EmployeeFamilyContactServices>();
            services.AddTransient<IEmployeeContactServices, EmployeeContactServices>();
            services.AddTransient<IEmployeeContractServices, EmployeeContractServices>();
            services.AddTransient<IEmployeeProbationServices, EmployeeProbationServices>();
            services.AddTransient<IEmployeeEduHistoryServices, EmployeeEduHistoryServices>();
            services.AddTransient<IEmployeeClassificationServices, EmployeeClassificationServices>();
            services.AddTransient<IEmployeeEmploymentServices, EmployeeEmploymentServices>();
            services.AddTransient<IEmployeeSalaryServices, EmployeeSalaryServices>();
            services.AddTransient<IEmployeeLeaveSettingServices, EmployeeLeaveSettingServices>();
            services.AddTransient<IAnnualLeaveTypeServices, AnnualLeaveTypeServices>();
            services.AddTransient<IEmployeeInsuranceServices, EmployeeInsuranceServices>();
            services.AddTransient<IEmployeeIdentityServices, EmployeeIdentityServices>();
            services.AddTransient<IEmployeeAllowanceServices, EmployeeAllowanceServices>();
            services.AddTransient<IIdentityTypeServices, IdentityTypeServices>();
            services.AddTransient<IAllowanceServices, AllowanceServices>();
            services.AddTransient<IEmployeeHealthHistoryServices, EmployeeHealthHistoryServices>();
            services.AddTransient<IEmployeeTransactionServices, EmployeeTransactionServices>();
            services.AddTransient<IDeviceManagerServices, DeviceManagerServices>();
            services.AddTransient<IDeviceUsersServices, DeviceUsersServices>();
            services.AddTransient<IDeviceUserFingerMappingServices, DeviceUserFingerMappingServices>();
            services.AddTransient<ITimesheetService, TimesheetServices>();
            services.AddTransient<ITimetableServices, TimetableServices>();
            services.AddTransient<IHolidaySettingServices, HolidaySettingServices>();
            services.AddTransient<IUserServices, UserServices>();
            services.AddTransient<IRuleServices, RuleServices>();
            services.AddTransient<IRuleItemServices, RuleItemsServices>();
            services.AddTransient<IPageMasterServices, PageMasterServices>();
            services.AddTransient<IRoleServices, RoleServices>();


            services.AddTransient<MySqlConnection>(_ => new MySqlConnection(Configuration["ConnectionStrings:Default"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "hrm_api v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),@"storage")),
                RequestPath = new PathString("/storage")
            });
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //var webSocketOptions = new WebSocketOptions()
            //{
            //    KeepAliveInterval = TimeSpan.FromSeconds(120),
            //};
            //webSocketOptions.AllowedOrigins.Add("https://localhost:44301");
            //webSocketOptions.AllowedOrigins.Add("https://localhost:5001");
            //webSocketOptions.AllowedOrigins.Add("http://localhost:5000");

            //app.UseWebSockets(webSocketOptions);

            //app.UseWebSockets();
            //app.Use(async (context, next) =>
            //{
            //    if (context.Request.Path == "/ws")
            //    {
            //        if (context.WebSockets.IsWebSocketRequest)
            //        {
            //            using (WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync())
            //            {
            //                await Echo(context, webSocket);
            //            }
            //        }
            //        else
            //        {
            //            context.Response.StatusCode = 400;
            //        }
            //    }
            //    else
            //    {
            //        await next();
            //    }

            //});
        }

        //private async Task Echo(HttpContext context, WebSocket webSocket)
        //{
        //    var buffer = new byte[1024 * 4];
        //    WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        //    while (!result.CloseStatus.HasValue)
        //    {
        //        await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, result.Count), result.MessageType, result.EndOfMessage, CancellationToken.None);

        //        result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        //    }
        //    await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        //}
    }
}
