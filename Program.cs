using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace FileConverter
{
	class Program
	{
		static void Main(string[] args)
		{
			HostFactory.Run(serviceConfig =>
			{
				serviceConfig.Service<ConverterService>(serviceIntance =>
				{
					serviceIntance.ConstructUsing(() => new ConverterService());
					serviceIntance.WhenStarted(execute => execute.Start());
					serviceIntance.WhenStopped(execute => execute.Stop());

					serviceIntance.WhenPaused(execute => execute.Pause());
					serviceIntance.WhenContinued(execute => execute.Continue());

					
				});

				serviceConfig.EnableServiceRecovery(recoveryOption =>
				{
					recoveryOption.RestartService(1);
					recoveryOption.RestartService(1);
					recoveryOption.RestartService(1);

				});

				serviceConfig.EnablePauseAndContinue();
				serviceConfig.SetServiceName("ConvertedService");
				serviceConfig.SetDisplayName("File Converter");
				serviceConfig.SetDescription("Demo Service");

				serviceConfig.StartAutomatically();
			});

		}
	}
}
