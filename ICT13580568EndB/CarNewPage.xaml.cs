using System;
using System.Collections.Generic;
using ICT13580568EndB.Models;

using Xamarin.Forms;

namespace ICT13580568EndB
{
    public partial class CarNewPage : ContentPage
    {
        Car car;
        public CarNewPage(Car car=null)
        {
            InitializeComponent();
            this.car = car;

            addCar.Clicked += AddCar_Clicked;
            cancelCar.Clicked += CancelCar_Clicked;

            cateoryPicker.Items.Add("2door");
			cateoryPicker.Items.Add("4door");

            brandPicker.Items.Add("handa");
            brandPicker.Items.Add("manna");
            brandPicker.Items.Add("Toyota");

            colorPicker.Items.Add("red");
            colorPicker.Items.Add("blue");

            provincePicker.Items.Add("bangkok");
            provincePicker.Items.Add("Samutprakram");

            mileSlider.ValueChanged += MileSlider_ValueChanged;
            yearStepper.ValueChanged += YearStepper_ValueChanged;


			if (car != null)
			{
				titleLabel.Text = "edit car";
				cateoryPicker.SelectedItem = car.CateoryCar;
                brandPicker.SelectedItem = car.Brand;
                colorPicker.SelectedItem = car.Color;
                provincePicker.SelectedItem = car.Province;
                grandEntry.Text = car.Grand;

                yearLabel.Text = car.Year;
                priceEntry.Text = car.Price.ToString();
                mileLabel.Text = car.Km.ToString();
                detailEditor.Text = car.Description;
                phoneEntry.Text = car.Numberphone;


				
			}


        }

       async void AddCar_Clicked(object sender, EventArgs e)
        {
			var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการบันทึกใช่หรือไม่", "ใช่", "ไม่ใช่");
			if (isOk)
			{


				if (car == null)
				{
					car = new Car();
					car.CateoryCar = cateoryPicker.SelectedItem.ToString();
					car.Brand = brandPicker.SelectedItem.ToString();
					car.Color = colorPicker.SelectedItem.ToString();
					car.Province = provincePicker.SelectedItem.ToString();
                    car.Grand = grandEntry.Text;

                    car.Price = decimal.Parse(priceEntry.Text);
					car.Year = yearLabel.Text;
                    car.Km = decimal.Parse(mileLabel.Text);
					car.Description = detailEditor.Text;
					car.Numberphone = phoneEntry.Text;


					var id = App.DbHelper.AddProduct(car);
					await DisplayAlert("บันทึกสำเร็จ", "รหัสรถของท่าน #" + id, "ตกลง");
				}
				else
				{


					car.CateoryCar = cateoryPicker.SelectedItem.ToString();
					car.Brand = brandPicker.SelectedItem.ToString();
					car.Color = colorPicker.SelectedItem.ToString();
					car.Province = provincePicker.SelectedItem.ToString();
					car.Grand = grandEntry.Text;

					car.Price = decimal.Parse(priceEntry.Text);
					car.Year = yearLabel.Text;
					car.Km = decimal.Parse(mileLabel.Text);
					car.Description = detailEditor.Text;
					car.Numberphone = phoneEntry.Text;
					var id = App.DbHelper.UpdateProduct(car);
					await DisplayAlert("บันทึกสำเร็จ", "แก้ไขข้อมูลเรียบร้อย", "ตกลง");

				}

				await Navigation.PopModalAsync();



			}


		}

        void CancelCar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        void MileSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            mileLabel.Text = e.NewValue.ToString();
        }

        void YearStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            yearLabel.Text = e.NewValue.ToString();
        }
    }
}
