Imports System;
Imports System.IO;
Imports System.Web.Http;
Imports HibernatingRhinos.Profiler.Production

<assembly: WebActivator.PreApplicationStartMethod(typeof($rootnamespace$.App_Start.NHibernateProfilerProductionBootstrapper), "PreStart")>
Namespace App_Start
	Public Class NHibernateProfilerProductionBootstrapper
        Public Shared Sub PreStart()
            ' Initialize the profiler with the production profiling feature. 
			' Production profiling let's you let you see profiling information remotely using the following URL: http://your-server/profiler/profiler.html
			Dim license As String = GetResource("$rootnamespace$.App_Start.NHibernateProfilerLicense.xml")
			ProductionProfiling.Initialize(license, GlobalConfiguration.Configuration)
        End Sub
		
		Private Shared Function GetResource(sourcesResource As String) As String
			Using sourceCodeStream = GetType(NHibernateProfilerProductionBootstrapper).Assembly.GetManifestResourceStream(sourcesResource)
				If sourceCodeStream Is Nothing Then
					Throw New InvalidOperationException(String.Format("Resource file is missing: {0}", sourcesResource))
				End If
				Return New StreamReader(sourceCodeStream).ReadToEnd()
			End Using
		End Function
    End Class
End Namespace

