using Autofac;
using RecycleApp.RecycleApiService;
using RecycleApp.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecycleApp.Settings;

namespace RecycleApp.Autofac
{
    internal class RecycleModule : Module
    {
	    private readonly AppSettings _settings;

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
        }
    }
}
