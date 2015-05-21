using CityInfoWithLayerArchitectureApp.DAL;
using CityInfoWithLayerArchitectureApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CityInfoWithLayerArchitectureApp.BLL
{
    class Manager
    {

        Gateway gateway = new Gateway();

        public string Save(City aCity)
        { 
        
            if(aCity.cityName.Length < 4)
            {
                return "City Name at least 4 character long !";
            }
            else if (gateway.IsCityNameExists(aCity.cityName))
            {
                return "City Name Already Exists !";
            }
            else
            {
                if (gateway.Save(aCity)> 0)
                {
                return "Successfully Saved !";
                }
                else
                {
                return "Save failed !";
                }
            }
        }



        public List<City> GetCityList(List<City> cityList)
        {

            
            return gateway.ShowAllCity(cityList);
                
        }

        public string UpdateCity(City aCity)
        {
            if (gateway.UpdateCity(aCity) > 0)
            {
                return "Update Successfully !";

            }
            else
            {
                return "Not Updated !";
            }   
               
           
        }



        public List<City> GetSearchCityListByCity(List<City> cityList,string search)
        {


            return gateway.SearchByCity(cityList,search);

        }

        public List<City> GetSearchCityListByCountry(List<City> cityList, string search)
        {


            return gateway.SearchByCountry(cityList, search);

        }
        
    }
 }

