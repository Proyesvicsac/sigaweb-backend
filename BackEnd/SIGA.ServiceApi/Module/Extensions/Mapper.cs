﻿using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SIGA.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGA.ServiceApi.Module.Extensions
{
    public static class Mapper
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services) 
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingsProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
