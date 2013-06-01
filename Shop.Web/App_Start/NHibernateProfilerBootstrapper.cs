using System;
using System.IO;
using System.Web.Http;
using HibernatingRhinos.Profiler.Production;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Shop.Web.App_Start.NHibernateProfilerProductionBootstrapper), "PreStart")]
namespace Shop.Web.App_Start
{
	public static class NHibernateProfilerProductionBootstrapper
	{
		public static void PreStart()
		{
			// Initialize the profiler with the production profiling feature. 
			// Production profiling let's you let you see profiling information remotely using the following URL: http://your-server/profiler/profiler.html
			string license = GetResource("Shop.Web.App_Start.NHibernateProfilerLicense.xml");
			ProductionProfiling.Initialize(license, GlobalConfiguration.Configuration);
		}
		
		private static string GetResource(string sourcesResource)
		{
			using (var sourceCodeStream = typeof(NHibernateProfilerProductionBootstrapper).Assembly.GetManifestResourceStream(sourcesResource))
			{
				if (sourceCodeStream == null)
					throw new InvalidOperationException(string.Format("Resource file is missing: {0}", sourcesResource));
				return new StreamReader(sourceCodeStream).ReadToEnd();
			}
		}
	}
}

