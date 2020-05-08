using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace frame.Models
{
    public class Customer
    {
        public string idCustomer {get;set;}
        public string nameCustomer { get; set;}
        public string phoneCustomer { get; set; }
        public string idShip { get; set; }
        public string addCus { get; set; }
        public int idUser { get; set; }
        public string status { get; set; }

    }
}