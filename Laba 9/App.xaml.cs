using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Laba_9
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
		public static List<CultureInfo> Languages { get; } = new List<CultureInfo>();

		public App()
		{
			Languages.Clear();
			Languages.Add(new CultureInfo("en-US")); //Нейтральная культура для этого проекта
			Languages.Add(new CultureInfo("ru-RU"));
		}

		/// <summary>
		/// Событие для оповещения всех окон приложения
		/// </summary>
		public static event EventHandler LanguageChanged;

		public static CultureInfo Language
		{
			get
			{
				return System.Threading.Thread.CurrentThread.CurrentUICulture;
			}
			set
			{
				if (value == null) throw new ArgumentNullException("Null is invalid value!");
				if (value == System.Threading.Thread.CurrentThread.CurrentUICulture) return;

				//1. Меняем язык приложения:
				System.Threading.Thread.CurrentThread.CurrentUICulture = value;

				//2. Создаём ResourceDictionary для новой культуры
				ResourceDictionary dict = new ResourceDictionary();
				switch (value.Name)
				{
					case "ru-RU":
						dict.Source = new Uri(String.Format("Resources/lang.{0}.xaml", value.Name), UriKind.Relative);
						break;
					default:
						dict.Source = new Uri("Resources/lang.xaml", UriKind.Relative);
						break;
				}

				//3. Находим старый ResourceDictionary и удаляем его и добавляем новую ResourceDictionary
				ResourceDictionary oldDict = (from d in Application.Current.Resources.MergedDictionaries
											  where d.Source != null && d.Source.OriginalString.StartsWith("Resources/lang.")
											  select d).First();
				if (oldDict != null)
				{
					int ind = Application.Current.Resources.MergedDictionaries.IndexOf(oldDict);
					Application.Current.Resources.MergedDictionaries.Remove(oldDict);
					Application.Current.Resources.MergedDictionaries.Insert(ind, dict);
				}
				else
				{
					Application.Current.Resources.MergedDictionaries.Add(dict);
				}

				//4. Вызываем евент для оповещения всех окон.
				LanguageChanged(Application.Current, new EventArgs());
			}
		}

		/// <summary>
		/// Флаг активности ночной темы
		/// </summary>
		static bool darkTheme;

		public static bool DarkTheme
		{
			get
			{
				return darkTheme;
			}
			set
			{
				if (value == darkTheme) return;

				//1. Создаём ResourceDictionary для новой темы
				ResourceDictionary dict = new ResourceDictionary();
				switch (value)
				{
					case true:
						dict.Source = new Uri("Themes/dark.xaml", UriKind.Relative);
						break;
					default:
						dict.Source = new Uri("Themes/light.xaml", UriKind.Relative);
						break;
				}

				//2. Находим старый ResourceDictionary, удаляем его и добавляем новый ResourceDictionary
				ResourceDictionary oldDict = (from d in Application.Current.Resources.MergedDictionaries
											  where d.Source != null && d.Source.OriginalString.StartsWith($"Themes/")
											  select d).First();
				if (oldDict != null)
				{
					int ind = Application.Current.Resources.MergedDictionaries.IndexOf(oldDict);
					Application.Current.Resources.MergedDictionaries.Remove(oldDict);
					Application.Current.Resources.MergedDictionaries.Insert(ind, dict);
				}
				else
				{
					Application.Current.Resources.MergedDictionaries.Add(dict);
				}

				//1. Меняем тему:
				darkTheme = value;
			}
		}
	}
}
