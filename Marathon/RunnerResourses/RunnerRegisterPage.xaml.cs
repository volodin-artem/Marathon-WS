
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Linq;
using Marathon.ModelContext;
using Marathon.MainResourses;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace Marathon.MainResourses
{
	/// <summary>
	/// Interaction logic for RunnerRegisterPage.xaml
	/// </summary>
	public partial class RunnerRegisterPage : Page
	{
		public RunnerRegisterPage()
		{
			InitializeComponent();
			
			comboGenders.ItemsSource = UsingContext.db.Gender.ToList();
			
			List<Country> countries = UsingContext.db.Country.ToList();
			
			for (int i = 0; i < countries.Count(); i++) {
				ComboBoxItem item = new ComboBoxItem();
				item.Content = countries[i].CountryName;
				item.Tag = countries[i].CountryCode;
				comboCountries.Items.Add(item);
			}
		}
		void ButtonSearchImage_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog imageDialog = new OpenFileDialog();
			imageDialog.Multiselect = false;
			imageDialog.Title = "Выберите фото";
			imageDialog.Filter = "Файлы изображений (.bmp, .jpg, .png, .jpeg)|*.bmp;*.jpg;*.png;*.jpeg";
			imageDialog.ShowDialog();
			
			if (!String.IsNullOrEmpty(imageDialog.FileName)) {
				imagePath.Text = imageDialog.FileName;
				BitmapImage image = new BitmapImage();
				image.BeginInit();
				image.UriSource = new Uri(imageDialog.FileName);
				image.EndInit();
				profileImage.Source = image;
			}
		}
		void ButtonBack_Click(object sender, RoutedEventArgs e)
		{
			Frames.mainFrame.GoBack();
		}
		
		bool passwordIsValid;
		void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
		{
			char[] text = "QWERTYUIOPASDFGHJKLZXCVBNM".ToCharArray();
			char[] numbers = "1234567890".ToCharArray();
			char[] specialSymbls = "!@#$%^".ToCharArray();
			
			 if(passwordBox.Password.Length > 6 && passwordBox.Password.IndexOfAny(text) >= 0 && passwordBox.Password.IndexOfAny(numbers) >=0 && passwordBox.Password.IndexOfAny(specialSymbls) >=0 && passwordBox.Password == passwordBoxRepeat.Password)
			{
				passwordIsValid = true;
			} else
				passwordIsValid = false;
		}
		
		//need check 4 empty strings email,name etc.
		//need check 4 correct email and date
		void ButtonRegister_Click(object sender, RoutedEventArgs e)
		{
			if(passwordIsValid && ((2020 - dateBornPicker.SelectedDate.Value.Year) >= 11 || (DateTime.Now.Month - dateBornPicker.SelectedDate.Value.Month >= 0 && 2020 - dateBornPicker.SelectedDate.Value.Year >= 10 && DateTime.Now.Day - dateBornPicker.SelectedDate.Value.Day > 0))){
				
				User newUser = new User{
					Email = boxEmail.Text,
					Password = passwordBox.Password,
					FirstName = boxFirstName.Text,
					LastName = boxLastName.Text,
					RoleId = "R"
				};
				UsingContext.db.User.Add(newUser);
				UsingContext.db.SaveChanges();
				
				Runner newRunner = new Runner{
					Email = boxEmail.Text,
					Gender = (comboGenders.SelectedValue as Gender).Gender1,
					DateOfBirth = dateBornPicker.SelectedDate.Value,
					CountryCode = (comboCountries.SelectedValue as ComboBoxItem).Tag.ToString()
				};
				Frames.mainFrame.Navigate(new RunnerResourses.RegisterForEventPage(newRunner));
			} else
				MessageBox.Show("Проверьте правильность заполнения полей и даты рождения\nВам должно быть не менее 10 лет!");
		}
		void ButtonCancel_Click(object sender, RoutedEventArgs e)
		{
			Frames.mainFrame.GoBack();
		}
	}
}