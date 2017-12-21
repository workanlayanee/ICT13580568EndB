using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ICT13580568EndB.Models;

namespace ICT13580568EndB
{
	public partial class MainPage : ContentPage
	{

		public MainPage()
		{
			InitializeComponent();

			newButton.Clicked += NewButton_Clicked;
		}
		void LoadData()
		{
			productListView.ItemsSource = App.DbHelper.GetCars();
		}
		protected override void OnAppearing()
		{
			LoadData();
		}
		void NewButton_Clicked(object sender, EventArgs e)
		{
            Navigation.PushModalAsync(new CarNewPage());
		}

		async void Delete_Clicked(object sender, System.EventArgs e)
		{
			var button = sender as MenuItem;
			var car = button.CommandParameter as Car;
			var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการลบใช่มั้ย", "ใช่", "ไม่ใช่");
		}

		void Edit_Clicked(object sender, System.EventArgs e)
		{

			var button = sender as MenuItem;
			var car = button.CommandParameter as Car;
			Navigation.PushModalAsync(new CarNewPage(car));
		}
	}
}