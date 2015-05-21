using CityInfoWithLayerArchitectureApp.BLL;
using CityInfoWithLayerArchitectureApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CityInfoWithLayerArchitectureApp
{
    public partial class CityUI : Form
    {
        public CityUI()
        {
            InitializeComponent();
        }
        Manager manager = new Manager();

        bool isUpdateMode = false;
        int selectedCityId = 0;
        private void saveButton_Click(object sender, EventArgs e)
        {
            City aCity = new City();

            aCity.cityName = nameTextBox.Text;
            aCity.About = aboutTextBox.Text;
            aCity.Country = countryTextBox.Text;

           
            if (isUpdateMode)
            {
                MessageBox.Show(manager.UpdateCity(aCity));

                List<City> cityList = new List<City>();
                cityListView.Items.Clear();

                foreach (var City in manager.GetCityList(cityList))
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = City.cityId.ToString();
                    item.SubItems.Add(City.cityName);
                    item.SubItems.Add(City.About);
                    item.SubItems.Add(City.Country);

                    cityListView.Items.Add(item);
                }

                saveButton.Text = "Save";
                GetTextBoxesClear();
                nameTextBox.Enabled = true;

            }
            else
            {
                MessageBox.Show(manager.Save(aCity));
            }



        }

        

        private void CityUI_Load(object sender, EventArgs e)
        {
            List<City> cityList = new List<City>();

            cityListView.Items.Clear();

            foreach (var City in manager.GetCityList(cityList))
            {
                ListViewItem item = new ListViewItem();
                item.Text = City.cityId.ToString();
                item.SubItems.Add(City.cityName);
                item.SubItems.Add(City.About);
                item.SubItems.Add(City.Country);

                cityListView.Items.Add(item);
            }
        }

        

        private void cityListView_DoubleClick(object sender, EventArgs e)
        {

            ListViewItem item = cityListView.SelectedItems[0];
            selectedCityId = Convert.ToInt16(item.Text.ToString());



            nameTextBox.Text = item.SubItems[1].Text;
            aboutTextBox.Text = item.SubItems[2].Text;
            countryTextBox.Text = item.SubItems[3].Text;

            isUpdateMode = true;
            saveButton.Text = "Update";
            nameTextBox.Enabled = false;
            //  MessageBox.Show(manager.UpdateCity(aCity));


        }

        private void GetTextBoxesClear()
        {
            nameTextBox.Clear();
            aboutTextBox.Clear();
            countryTextBox.Clear();
        }
      
    }
}
