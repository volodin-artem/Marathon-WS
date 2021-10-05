
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Timers;
using System.Windows.Threading;
using Marathon.ModelContext;

namespace Marathon
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		TimeSpan totalTime;
		public MainWindow()
		{
			InitializeComponent();
			
			UsingContext.db = new MarathonDbContext();
			
			Frames.mainFrame = mainFrame;
			
			mainFrame.Navigate(new MainPage());
			
			DispatcherTimer timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(1);
			
			timer.Start();
			
			timer.Tick += timer_Tick;
		}

		void timer_Tick(object sender, EventArgs e)
		{
			DateTime marathonStart = new DateTime(2020,11,24,6,0,0);
			totalTime = marathonStart - DateTime.Now;
			textTimer.Text = totalTime.Days+" дней "+totalTime.Hours+" часов и "+totalTime.Minutes+" минут до начала марафона!";
		}
	}
}