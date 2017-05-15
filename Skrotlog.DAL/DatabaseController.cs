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
                    string name = reader["CustomerName"].ToString();
                    string country = reader["Country"].ToString();
                    return new Customer(name, country);
                }
            }

            return null;
        }

        public List<Contract> GetContracts()
        {
            List<Contract> contracts = new List<Contract>();
        
            using (MySqlConnection con = new MySqlConnection(connectionString.ToString()))
            {
                string query = "SELECT ContractId, CustomerId, CreationDate, Currency, Initials, Active FROM Contract";
                MySqlCommand cmd = new MySqlCommand(query, con);

                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int contractId = int.Parse(reader["ContractId"].ToString());
                    int customerId = int.Parse(reader["CustomerId"].ToString());
                    Customer customer = GetCustomer(customerId);
                    DateTime date = DateTime.Parse(reader["CreationDate"].ToString());
                    string currencyString = reader["Currency"].ToString();
                    Currency currency = (Currency)Enum.Parse(typeof(Currency), currencyString);
                    string initials = reader["Initials"].ToString();

                    Contract contract = new Contract(customer, date, currency, initials);
                    contract.Id = contractId;

                    contract.ContractLines = GetContractLines(contractId);
                }
            }

            return contracts;
        }

        public List<Contract> GetContracts(string customerName)
        {
            return GetContracts().FindAll(x => x.Customer.Name == customerName);
        }

        public List<ContractLine> GetContractLines(int id)
        {
            List<ContractLine> contractLines = new List<ContractLine>();

            using(MySqlConnection con = new MySqlConnection(connectionString.ToString()))
            {
                string query = "SELECT MaterialId, Price, TotalAmount, DeliveredAmount, LineComment, Active FROM ContractLine WHERE ContractLineId=" + id;
                MySqlCommand cmd = new MySqlCommand(query, con);

                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int materialId = int.Parse(reader["MaterialId"].ToString());
                    Material m = GetMaterial(materialId);
                    decimal price = decimal.Parse(reader["Price"].ToString());
                    int amount = int.Parse(reader["TotalAmount"].ToString());
                    int delivered = int.Parse(reader["DeliveredAmount"].ToString());
                    bool active = bool.Parse(reader["Active"].ToString());
                    string comment = reader["LineComment"].ToString();

                    ContractLine c = new ContractLine(m, price, amount, delivered, active, comment);
                    contractLines.Add(c);
                }
            }

            return contractLines;
        }

        public Material GetMaterial(int id)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString.ToString()))
            {
                string query = "SELECT MaterialType, Designation FROM Material WHERE MaterialId=" + id;
                MySqlCommand cmd = new MySqlCommand(query, con);

                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    return new Material(reader["MaterialType"].ToString(), reader["Designation"].ToString());
                }
            }

            return null;
        }
    }
}
