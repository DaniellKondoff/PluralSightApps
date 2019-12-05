using Api.Utils;
using Logic.AppServices;
using Logic.Decorators;
using Logic.Dtos;
using Logic.Interfaces;
using Logic.Students;
using Logic.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using static Logic.AppServices.DisenrollCommand;
using static Logic.AppServices.EditPersonalInfoCommand;
using static Logic.AppServices.EnrollCommand;
using static Logic.AppServices.GetListQuery;
using static Logic.AppServices.RegisterCommand;
using static Logic.AppServices.TransferEnrollmentCommand;
using static Logic.AppServices.UnregisterCommand;

namespace Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var commandsConnectionString = new CommandsConnectionString(Configuration["ConnectionString"]);
            var queriesConnectionString = new CommandsConnectionString(Configuration["QueriesConnectionString"]);
            services.AddSingleton(commandsConnectionString);
            services.AddSingleton(queriesConnectionString);
            services.AddSingleton(new SessionFactory(Configuration["ConnectionString"]));
            services.AddTransient<UnitOfWork>();
            services.AddTransient<ICommandHandler<EditPersonalInfoCommand>>(provider =>
                new DatabaseRetryDecorator<EditPersonalInfoCommand>(
                    new EditPersonalInfoCommandHandler(provider.GetService<SessionFactory>())));
            services.AddTransient<ICommandHandler<RegisterCommand>, RegisterCommandHandler>();
            services.AddTransient<ICommandHandler<UnregisterCommand>, UnregisterCommandHandler>();
            services.AddTransient<ICommandHandler<EnrollCommand>, EnrollComandHandler>();
            services.AddTransient<ICommandHandler<TransferEnrollmentCommand>, TransferEnrollmentCommandHandler>();
            services.AddTransient<ICommandHandler<DisenrollCommand>, DisenrollCommandHandler>();
            services.AddTransient<IQueryHandler<GetListQuery, List<StudentDto>>, GetListQueryHandler>();
            services.AddSingleton<Messages>();
            //services.AddHandlers();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandler>();
            app.UseMvc();
        }
    }
}
