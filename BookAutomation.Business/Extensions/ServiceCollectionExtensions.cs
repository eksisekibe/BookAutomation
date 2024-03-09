﻿using AutoMapper;
using BookAutomation.Business.Abstract;
using BookAutomation.Business.Concrete;
using BookAutomation.Business.Profiles;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAutomation.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessLayer(this IServiceCollection services)
        {

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ICategoryService, CategoryService>();
            var mapperConfig = new MapperConfiguration(mc =>
            {

                mc.AddProfile(new UserProfile());
                mc.AddProfile(new BookProfile());
                mc.AddProfile(new CategoryProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
