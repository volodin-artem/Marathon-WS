
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Marathon.ModelContext;
using System.Linq;

namespace Marathon
{
	/// <summary>
	/// Interaction logic for CharityWatchWindow.xaml
	/// </summary>
	public partial class CharityWatchWindow : Window
	{
		public CharityWatchWindow(Charity charity)
		{
			InitializeComponent();
			
			charityName.Text = charity.CharityName;
			
			textCharityDesc.Text = charity.CharityDescription;
			
			BitmapImage image = new BitmapImage();
			image.BeginInit();
			image.UriSource = new Uri(@"Images/" + charity.CharityLogo,UriKind.Relative);
			image.EndInit();
			
			charityImage.ImageSource = image;
		}
	}
}