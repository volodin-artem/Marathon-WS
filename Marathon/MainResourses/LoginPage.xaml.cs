
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Linq;
using Marathon.ModelContext;

namespace Marathon
{
	/// <summary>
	/// Interaction logic for LoginPage.xaml
	/// </summary>
	public partial class LoginPage : Page
	{
		public LoginPage()
		{
			InitializeComponent();
		}
		void ButtonLogin_Click(object sender, RoutedEventArgs e)
		{
			if(!String.IsNullOrEmpty(boxEmail.Text) && !String.IsNullOrEmpty(boxPaswword.Password)){
				var user =	UsingContext.db.User.FirstOrDefault(x => x.Email == boxEmail.Text && x.Password == boxPaswword.Password);
				if(user != null){
			 	
			 	switch(user.RoleId){
						case "R":
							Frames.mainFrame.Navigate(new RunnerMenuPage(user.Runner.First()));
							break;
						case "A":
							Frames.mainFrame.Navigate(new AdminMenuPage());
							break;
							case "C":
							Frames.mainFrame.Navigate(new CoordinatorMenuPage());
							break;
			 	}
			 }
			 else{
					MessageBox.Show("Пользователь не найден!","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
			 }
			}
			else{
				MessageBox.Show("Заполните все поля!","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
			}

		}
		void ButtonCancel_Click(object sender, RoutedEventArgs e)
		{
			Frames.mainFrame.Navigate(new MainPage());
		}
		void ButtonBack_Click(object sender, RoutedEventArgs e)
		{
			Frames.mainFrame.GoBack();
		}
	}
}