using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;
using MySql.Data.Common;
using frame.Models;

namespace frame.Data
{
    public class BookStoreContext
    {   

        public MySqlConnection GetConnection() {
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "localhost";
            conn_string.UserID = "root";
            conn_string.Password = "";
            conn_string.Database = "websitebansach";
            conn_string.Port = 3306;
            // conn_string.ConvertZeroDateTime = true;
            // conn_string.AllowZeroDateTime = true;
            MySqlConnection cnn = new MySqlConnection(conn_string.ToString());
            return cnn;
        }
        public List<Book> GetAllBook() {
            List<Book> list = new List<Book>();
        
            MySqlConnection cnn = GetConnection();
            try {
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from book",cnn);
                using ( var reader = cmd.ExecuteReader()) {
                    while(reader.Read()) {
                        if(reader["id_Discount"].ToString() != null){
                            list.Add(new Book() {
                            idBook = reader["id_Book"].ToString(),
                            nameBook = reader["name_Book"].ToString(),
                            imgBook = reader["img_Book"].ToString(),
                            desBook = reader["describe_Book"].ToString(),
                            summaryBook =reader["summary_Book"].ToString(),
                            priceBook = float.Parse(reader["price_Book"].ToString(),System.Globalization.CultureInfo.InvariantCulture),
                            idCategory = reader["id_Category"].ToString(),
                            amountBook = Convert.ToInt32(reader["amount_Book"].ToString()),
                            publishingYear = Convert.ToInt32(reader["publishing_Year"].ToString()),
                            pageCount = Convert.ToInt32(reader["page_Count"].ToString()),
                            publisherBook = reader["publisher_Book"].ToString(),
                            idAuthor = reader["id_Author"].ToString(),
                            idDiscount = reader["id_Discount"].ToString(),
                            imgBackBook = reader["imgback_Book"].ToString()
                            });
                        }else {
                            list.Add(new Book() {
                            idBook = reader["id_Book"].ToString(),
                            nameBook = reader["name_Book"].ToString(),
                            imgBook = reader["img_Book"].ToString(),
                            desBook = reader["describe_Book"].ToString(),
                            summaryBook =reader["summary_Book"].ToString(),
                            priceBook = float.Parse(reader["price_Book"].ToString(),System.Globalization.CultureInfo.InvariantCulture),
                            idCategory = reader["id_Category"].ToString(),
                            amountBook = Convert.ToInt32(reader["amount_Book"].ToString()),
                            publishingYear = Convert.ToInt32(reader["publishing_Year"].ToString()),
                            pageCount = Convert.ToInt32(reader["page_Count"].ToString()),
                            publisherBook = reader["publisher_Book"].ToString(),
                            idAuthor = reader["id_Author"].ToString(),
                            idDiscount = null,
                            imgBackBook = reader["imgback_Book"].ToString()
                            });
                        }
                        
                    }
                }
                cnn.Close();
            } catch(Exception ex) {
                Console.WriteLine("Can not open connection ! "+ ex.Message);
            }
            return list;
        }

        //category
        public List<Category> GetAllCategory() {
            List<Category> list = new List<Category>();

            MySqlConnection cnn = GetConnection();

            try {
                cnn.Open();
                
                MySqlCommand cmd = new MySqlCommand("select * from category",cnn);
                using ( var reader = cmd.ExecuteReader()) {
                     while(reader.Read()) {
                        list.Add(new Category() {
                            idCategory = reader["id_Category"].ToString(),
                            nameCategory = reader["name_Category"].ToString()
                        });
                    }
                }
                cnn.Close();
            } catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }

            return list;
        }
        //author
        public List<Author> GetAllAuthor() {
            List<Author> list = new List<Author>();

            MySqlConnection cnn = GetConnection();

            try {
                cnn.Open();
                
                MySqlCommand cmd = new MySqlCommand("select * from author",cnn);
                using ( var reader = cmd.ExecuteReader()) {
                     while(reader.Read()) {
                        list.Add(new Author() {
                            idAuthor= reader["id_Author"].ToString(),
                            nameAuthor = reader["name_Author"].ToString(),
                            imgAuthor = reader["img_Author"].ToString(),
                            describeAuthor = reader["describe_Author"].ToString()
                        });
                    }
                }
                cnn.Close();
            } catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }

            return list;
        }
        //discount
        public List<Discount> GetAllDiscount() {
            List<Discount> list = new List<Discount>();

            MySqlConnection cnn = GetConnection();

            try {
                cnn.Open();
                
                MySqlCommand cmd = new MySqlCommand("select * from discount",cnn);
                using ( var reader = cmd.ExecuteReader()) {
                     while(reader.Read()) {
                        list.Add(new Discount() {
                            idDiscount= reader["id_Discount"].ToString(),
                            nameDiscount = reader["name_Discount"].ToString(),
                            quantityDis = int.Parse(reader["quantity_Discount"].ToString()),
                            dateStart = DateTime.Parse(reader["date_start"].ToString()),
                            dateEnd = DateTime.Parse(reader["date_end"].ToString()),
                            numberDiscount = int.Parse(reader["number_Discount"].ToString()),
                            status = reader["status"].ToString()
                        });
                    }
                }
                cnn.Close();
            } catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }

            return list;
        }

        public void DeleteDiscount(String id)
        {
            string sql = "update discount set status = N'false' where id_Discount= '"+id+"'";
            MySqlConnection conn= GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql,conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }

        public void AddDiscount(Discount dis){
            string sql = "INSERT INTO discount VALUES (N'"+ dis.idDiscount + "',N'" + dis.nameDiscount + "'," + dis.quantityDis + ",N'" + dis.dateStart +"',N'"+dis.dateEnd+"',"+dis.numberDiscount+",N'true')";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();           
            cmd.Dispose();
            conn.Close();
        }
        //customer
        public List<Customer> GetAllCustomer() {
            List<Customer> list = new List<Customer>();

            MySqlConnection cnn = GetConnection();

            try {
                cnn.Open();
                
                MySqlCommand cmd = new MySqlCommand("select * from customer",cnn);
                using ( var reader = cmd.ExecuteReader()) {
                     while(reader.Read()) {
                        list.Add(new Customer() {
                            idCustomer= reader["id_Customer"].ToString(),
                            nameCustomer = reader["name_Customer"].ToString(),
                            phoneCustomer = reader["phone_Cus"].ToString(),
                            idShip = reader["id_Ship"].ToString(),
                            addCus = reader["address_Customer"].ToString(),
                            idUser = int.Parse(reader["id_User"].ToString()),
                            status = reader["status"].ToString()
                        });
                    }
                }
                cnn.Close();
            } catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }

            return list;
        }
         public void AddCustomer(Customer cus){
            string sql = "INSERT INTO customer VALUES (N'"+ cus.idCustomer + "',N'" + cus.nameCustomer + "'," + cus.phoneCustomer + ",N'" + cus.idShip +"',N'"+cus.addCus+"',N'"+cus.idUser+"',N'true')";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();           
            cmd.Dispose();
            conn.Close();
        }

         public void DeleteCustomer(String idCus) {
            string sql = "update customer set status = N'false' where id_Customer= '"+idCus+"'";
            MySqlConnection conn= GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql,conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }
        //supplier
        public void DeleteSupplier(String id)
        {
            string sql = "update supplier set status = N'false' where id_Supplier= '"+id+"'";
            MySqlConnection conn= GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql,conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }
        //user
        public List<User> GetAllUser() {
            List<User> list =  new List<User>();
            MySqlConnection cnn = GetConnection();
            try {
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from user",cnn);
                using( var reader = cmd.ExecuteReader()) {
                    while(reader.Read()) {
                        list.Add(new User() {
                            idUser = int.Parse(reader["id_User"].ToString()),
                            email = reader["email"].ToString(),
                            password = reader["password"].ToString(),
                            role = reader["role"].ToString()
                        });
                    }
                }
                cnn.Close();
            }catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }

            return list;
        }
        //shipping
        public List<Shipping> GetAllShipping() {
            List<Shipping> list = new List<Shipping>();

            MySqlConnection cnn = GetConnection();
            try {
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from shipping",cnn);
                using( var reader = cmd.ExecuteReader()) {
                    while(reader.Read()) {
                        list.Add(new Shipping() {

                            idShip = reader["id_Ship"].ToString(),
                            country = reader["country"].ToString(),
                            charge = float.Parse(reader["charge"].ToString())
                        });
                    }
                }
                cnn.Close();
            }catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }
            return list;
        }
        //Employee
        public List<Employee> GetAllemployee() {
            List<Employee> list = new List<Employee>();

            MySqlConnection cnn = GetConnection();

            try {
                cnn.Open();
                
                MySqlCommand cmd = new MySqlCommand("select * from employee",cnn);
                using ( var reader = cmd.ExecuteReader()) {
                     while(reader.Read()) {
                        list.Add(new Employee() {
                            idEmployee= reader["id_Employee"].ToString(),
                            nameEmployee = reader["name_Employee"].ToString(),
                            phoneEmployee= reader["phone_Employee"].ToString(),
                            addEmployee = reader["address_Employee"].ToString(),
                            idUser = int.Parse(reader["id_User"].ToString()),
                            status = reader["status"].ToString()
                        });
                    }
                }
                cnn.Close();
            } catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }

            return list;
        }

         public void AddEmployee(Employee emp){
            string sql = "INSERT INTO employee VALUES (N'"+ emp.idEmployee + "',N'" + emp.nameEmployee + "'," + emp.phoneEmployee + ",N'" + emp.addEmployee +"',N'"+emp.idUser+"',N'true')";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();           
            cmd.Dispose();
            conn.Close();
        }
        public void DeleteEmployee(String idEmp) {
            string sql1 = "update employee set status = N'false' where id_Employee = '"+idEmp+"'";
            MySqlConnection conn= GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql1,conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }
    
    }
}