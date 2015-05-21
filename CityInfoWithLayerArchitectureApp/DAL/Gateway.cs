using CityInfoWithLayerArchitectureApp.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CityInfoWithLayerArchitectureApp.DAL
{
    class Gateway
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CityConDB"].ConnectionString;

        public int Save(City aCity)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO City VALUES ('" + aCity.cityName + "','" + aCity.About + "','" + aCity.Country + "')";

            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();

            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }


        public bool IsCityNameExists(string cityName)
        {
            bool isCityNameExists = false;

            SqlConnection connection = new SqlConnection(connectionString);
            string query ="Select * from City where Name='"+cityName+"'";
              SqlCommand command = new SqlCommand(query,connection);
               connection.Open();
               SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    isCityNameExists = true;
                    break;
                }
                reader.Close();
                connection.Close();
              return isCityNameExists;
        }

        public List<City> ShowAllCity(List<City> cityList)
        {
            cityList = new List<City>();

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from City";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            
            while(reader.Read())
            {
                City cities = new City();

                cities.cityId=int.Parse(reader["id"].ToString());
                cities.cityName=reader["Name"].ToString();
                cities.About=reader["About"].ToString();
                cities.Country=reader["Country"].ToString();

                cityList.Add(cities);
            
            }

            reader.Close();
            connection.Close();

            return cityList;

        }

        public int UpdateCity(City aCity)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Update City SET About='" + aCity.About + "', Country='" + aCity.Country + "' WHERE Name ='"+aCity.cityName+"'";

            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected= command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
            
        }

        public List<City> SearchByCity(List<City> Cities,string search)
        {
            Cities = new List<City>();


            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT Name,About,Country From City WHERE Name LIKE '" + search + "%'";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                City cities1 = new City();

                cities1.cityName = reader["Name"].ToString();
                cities1.About = reader["About"].ToString();
                cities1.Country = reader["Country"].ToString();

                Cities.Add(cities1);

            }

            reader.Close();
            connection.Close();

            return Cities;
        }

        public List<City> SearchByCountry(List<City> Cities, string search)
        {
            Cities = new List<City>();


            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT Name,About,Country From City WHERE Country LIKE '" + search + "%'";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                City cities2 = new City();

                cities2.cityName = reader["Name"].ToString();
                cities2.About = reader["About"].ToString();
                cities2.Country = reader["Country"].ToString();

                Cities.Add(cities2);

            }

            reader.Close();
            connection.Close();

            return Cities;
        }
    }
}



           

        
        
        
        
 