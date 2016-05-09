using System;
using System.Collections.Generic;

using Xamarin.Forms;
using RockMvvmForms;
using LegalMee.Services;
using LegalMee.Helpers;

namespace LegalMee
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent ();
			RegisterServices ();
			RegisterViews ();
			InitSettings ();
			LoadInitPage ();
		}

		private void RegisterServices()
		{
			
			RockServiceLocator.Current.Register<IFileService, FileService> ();
			RockServiceLocator.Current.Register<IFaqsService, FaqsService> ();

		}

		private void RegisterViews()
		{
			ViewFactory.Register<TutorialViewModel, TutorialView> ();
			ViewFactory.Register<FaqsViewModel, FaqsView> ();
		}

		private void InitSettings()
		{
			Settings.AppName = "LegalMee";
			Settings.Colectivo = "seguros";
			Settings.AppUserPlatform = "CONSULTA_ABOGADO";
		}

		private void LoadInitPage()
		{
			MainPage = new RockNavigationPageService<FaqsViewModel> ().Create ();
		}


	}
}

