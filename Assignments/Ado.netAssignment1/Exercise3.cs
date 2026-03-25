using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Ado.netAssignment1
{
    internal class Exercise3
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=LAPTOP-I4FPJV3B\\SQLEXPRESS;Initial Catalog=Ado.NetAssignment1;Integrated Security=True;TrustServerCertificate=True";

            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Products", conn);
            DataSet ds = new DataSet();

            adapter.Fill(ds, "Products");
            DataTable table = ds.Tables["Products"];

            int choice;

            do
            {
                Console.WriteLine("\n1. Display Products");
                Console.WriteLine("2. Add Product");
                Console.WriteLine("3. Update Product Price");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Save Changes to DB");
                Console.WriteLine("0. Exit");

                Console.Write("Enter choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        foreach (DataRow row in table.Rows)
                        {
                            if (row.RowState != DataRowState.Deleted)
                            {
                                Console.WriteLine($"{row["ProductId"]} | {row["ProductName"]} | {row["Price"]} | {row["Stock"]}");
                            }
                        }
                        break;

                    case 2:
                        DataRow newRow = table.NewRow();

                        Console.Write("Enter Name: ");
                        newRow["ProductName"] = Console.ReadLine();

                        Console.Write("Enter Price: ");
                        newRow["Price"] = decimal.Parse(Console.ReadLine());

                        Console.Write("Enter Stock: ");
                        newRow["Stock"] = int.Parse(Console.ReadLine());

                        table.Rows.Add(newRow);
                        Console.WriteLine("Added (offline)");
                        break;

                    case 3:
                        Console.Write("Enter ProductId to update: ");
                        int uid = int.Parse(Console.ReadLine());

                        foreach (DataRow row in table.Rows)
                        {
                            if (row.RowState != DataRowState.Deleted && row["ProductId"] != DBNull.Value && Convert.ToInt32(row["ProductId"]) == uid)
                            {
                                Console.Write("Enter new price: ");
                                row["Price"] = decimal.Parse(Console.ReadLine());
                            }
                        }
                        Console.WriteLine("Updated (offline)");
                        break;

                    case 4:
                        Console.Write("Enter ProductId to delete: ");
                        int did = int.Parse(Console.ReadLine());

                        foreach (DataRow row in table.Rows)
                        {
                            if (row.RowState != DataRowState.Deleted && row["ProductId"] != DBNull.Value && Convert.ToInt32(row["ProductId"]) == did)
                            {
                                row.Delete();
                            }
                        }
                        Console.WriteLine("Deleted (offline)");
                        break;

                    case 5:
                        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                        adapter.Update(ds, "Products");
                        Console.WriteLine("Changes saved to database!");
                        break;
                }

            } while (choice != 0);
        }
    }
    }
