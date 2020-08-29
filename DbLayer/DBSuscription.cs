using Microsoft.Extensions.DependencyInjection;
using ModelsLayer.Models.Promises;
using ModelsLayer.Models.Resolves;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsLayer
{
    public static class DBSuscription
    {
        public static void SuscriveModels(IServiceCollection services)
        {
            services.AddScoped<IUserDB, UserResolution>();
        }
    }
}
