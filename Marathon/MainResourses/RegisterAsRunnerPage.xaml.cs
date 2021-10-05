
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Marathon.MainResourses
{
	/// <summary>
	/// Interaction logic for RegisterAsRunnerPage.xaml
	/// </summary>
	public partial class RegisterAsRunnerPage : Page
	{
		public RegisterAsRunnerPage()
		{
			InitializeComponent();
		}
		void ButtonBack_Click(object sender, RoutedEventArgs e)
		{
			Frames.mainFrame.GoBack();
		}
		void ButtonLogin_Click(object sender, RoutedEventArgs e)
		{
			Frames.mainFrame.Navigate(new LoginPage());
		}
		void ButtonRunnerAuth_Click(object sender, RoutedEventArgs e)
		{
			Frames.mainFrame.Navigate(new LoginPage());
		}
		void ButtonRegister_Click(object sender, RoutedEventArgs e)
		{
			Frames.mainFrame.Navigate(new RunnerRegisterPage());
		}
	}
}