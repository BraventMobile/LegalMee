// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace LegalMee.Helpers
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
  {
		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}

		#region AppName

		private const string AppNameKey = "LegalMee";
		private static readonly string AppNameDefault = string.Empty;

		public static string AppName
		{
			get
			{
				return AppSettings.GetValueOrDefault(AppNameKey, AppNameDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(AppNameKey, value);
			}
		}

		#endregion

		#region Colectivo

		private const string ColectivoKey = "Banca";
		private static readonly string ColectivoDefault = string.Empty;

		public static string Colectivo
		{
			get
			{
				return AppSettings.GetValueOrDefault(ColectivoKey, ColectivoDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(ColectivoKey, value);
			}
		}

		#endregion

		#region AppUserPlatform

		private const string AppUserPlatformKey = "TESTAPPS";
		private static readonly string AppUserPlatformDefault = string.Empty;

		public static string AppUserPlatform
		{
			get
			{
				return AppSettings.GetValueOrDefault(AppUserPlatformKey, AppUserPlatformDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(AppUserPlatformKey, value);
			}
		}

		#endregion


		#region AppVersion

		private const string AppVersionKey = "AppVersionKey";
		private static readonly string AppVersionDefault = string.Empty;

		public static string AppVersion
		{
			get
			{
				return AppSettings.GetValueOrDefault(AppVersionKey, AppVersionDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(AppVersionKey, value);
			}
		}

		#endregion

  }
}