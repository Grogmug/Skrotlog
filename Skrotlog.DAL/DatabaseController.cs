using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using Skrotlog.Domain;

namespace Skrotlog.DAL
{
    public class DatabaseController
    {
        MySqlConnectionStringBuilder connectionString;

        public DatabaseController()
        {
            connectionString = new MySqlConnectionStringBuilder();
            connectionString.Server = "mysql2.gigahost.dk";
            connectionString.UserID = "skrotpriser";
            connectionString.Password = "mellemrum252100";
            connectionString.Database = "skrotpriser_log";
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using(MySqlConnection con = new MySqlConnection(connectionString.ToString()))
            {
                string query = "SELECT CustomerName, Country FROM Customer";
                MySqlCommand cmd = new MySqlCommand(query, con);

                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Customer c = new Customer(reader["CustomerName"].ToString(), reader["Country"].ToString());
                    customers.Add(c);
                }
            }

            return customers;
        }

        private Customer GetCustomer(string name)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString.ToString()))
            {
                string query = "SELECT CustomerName, Country FROM Customer WHERE CustomerName=" + name;
                MySqlCommand cmd = new MySqlCommand(query, con);

                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    return new Customer(reader["CustomerName"].ToString(), reader["Country"].ToString());
                }
            }

            return null;
        }

        private Customer GetCustomer(int id)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString.ToString()))
            {
                string query = "SELECT CustomerName, Country FROM Customer WHERE CustomerId=" + id;
                MySqlCommand cmd = new MySqlCommand(query, con);

                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    return new Customer(reader["CustomerName"].ToString(), reader["Country"].ToString());
                }
            }

            return null;
        }

        public List<Contract> GetContracts()
        {
            List<Contract> contracts = new List<Contract>();

            using (MySqlConnection con = new MySqlConnection(connectionString.ToString()))
            {
                string query = "";
                MySqlCommand cmd = new MySqlCommand(query, con);

                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                }
            }

            return contracts;
        }

        public List<Contract> GetContracts(string customerName)
        {
            return GetContracts().FindAll(x => x.Customer.Name == customerName);
        }

        private List<ContractLine> GetContractLines(int id)
        {
            List<ContractLine> contractLines = new List<ContractLine>();

            using(MySqlConnection con = new MySqlConnection(connectionString.ToString()))
            {
                string query = "";
                MySqlCommand cmd = new MySqlCommand(query, con);

                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                }
            }

            return contractLines;
        }
    }
}
