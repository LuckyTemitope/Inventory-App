using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Lab_03
{
    public partial class Storage : System.Web.UI.Page
    {

        public string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            inventoryList.Visible = false;
        }

        protected void loadBtn_Click(object sender, EventArgs e)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                string id = idTxt.Text;
                string name = nameTxt.Text;

                connection.Open();

                if(id == "" && name == "")
                {
                    messageLbl.Text = "Please input an ID or a Product Name";
                }else if(id != "")
                {
                    // Load all the values based on the ID provided
                    string query = $"SELECT * FROM productInventory WHERE id = {id}";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        nameTxt.Text = reader["Name"].ToString();
                        priceTxt.Text = reader["Price"].ToString();
                        quantityTxt.Text = reader["Quantity"].ToString();

                        messageLbl.Text = "Product loaded Successfully!";
                    }
                    else
                    {
                        messageLbl.Text = "Product not Found!";
                    }
                } else
                {
                    try
                    {
                        // Load all the values based on the Product Name provided
                        string query = $"SELECT * FROM productInventory WHERE name='{name}'";
                        SqlCommand cmd = new SqlCommand(query, connection);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            idTxt.Text = reader["id"].ToString();
                            priceTxt.Text = reader["Price"].ToString();
                            quantityTxt.Text = reader["Quantity"].ToString();

                            messageLbl.Text = "Product loaded Successfully!";
                        }
                        else
                        {
                            messageLbl.Text = "Product not Found!";
                        }
                    } catch(Exception ex)
                    {
                        messageLbl.Text = "Error loading Product!";
                    }
                    
                }
               
            }
        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {
           /* if(IsValid)
            {*/
                try
                            {
                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {

                                    connection.Open();

                                    string name = nameTxt.Text;
                                    string price = priceTxt.Text;
                                    string quantity = quantityTxt.Text;

                                    if ((name != "") && (price != "") && (quantity != ""))
                                    {
                                        string query = $"INSERT INTO productInventory VALUES ('{name}', '{price}', '{quantity}')";
                                        SqlCommand command = new SqlCommand(query, connection);
                                        command.ExecuteNonQuery();

                                        messageLbl.Text = "Inventory added succesfully!";
                                    }
                                    else
                                    {
                                        Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Error adding Inventory');", true);
                                    }

                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
            /*}*/
           
        }

        protected void clearBtn_Click(object sender, EventArgs e)
        {
            idTxt.Text = "";
            nameTxt.Text = "";
            priceTxt.Text = "";
            quantityTxt.Text = "";
            messageLbl.Text = "Message";
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
           /* if(IsValid)
            {*/
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string id = idTxt.Text;
                    string name = nameTxt.Text;
                    string price = priceTxt.Text;
                    string quantity = quantityTxt.Text;

                    try
                    {
                        string query = $"UPDATE productInventory SET name='{name}', price={price}, quantity={quantity} WHERE Id={id}";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();

                        messageLbl.Text = "Inventory updated Successfully";

                    
                    } catch(Exception ex)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Error", $"alert('Error updating inventory! {ex.Message}');", true);
                    }
               
                }
            /*}*/
        }

        protected void viewBtn_Click(object sender, EventArgs e)
        {
            inventoryList.Visible = true;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM productInventory";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                inventoryList.DataSource = reader;
                inventoryList.DataBind();
            }
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string id = idTxt.Text;

                try
                {
                    string query = $"DELETE FROM productInventory WHERE id={id}";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();

                    messageLbl.Text = "Inventory deleted successfully";
                } catch
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('Error deleting inventory!');", true);
                }

            }

        }
    }
} 