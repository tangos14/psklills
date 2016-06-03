using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

class MySQLCommands
{
    static String connectionString = "datasource=localhost;port=3306;username=root;password=root;database=mydatabase;";
    public static bool TestConnection()
    {
        using (MySqlConnection connect = new MySqlConnection(connectionString))
        {
            try
            {
                connect.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public static DataTable GetTable(string query)
    {
        using (MySqlConnection connect = new MySqlConnection(connectionString))
        {
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connect))
            {
                using (DataTable table = new DataTable())
                {
                    try
                    {
                        connect.Open();
                        adapter.Fill(table);
                        return table;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "An error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }
            }
        }
    }


    public static string GetValue(string query)
    {
        using (MySqlConnection connect = new MySqlConnection(connectionString))
        {
            using (MySqlCommand command = new MySqlCommand(query, connect))
            {
                try
                {
                    connect.Open();
                    return command.ExecuteScalar().ToString() + string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "An error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }
    }



    public static bool DoesExist(string query)
    {
        using (MySqlConnection connect = new MySqlConnection(connectionString))
        {
            using (MySqlCommand command = new MySqlCommand(query, connect))
            {
                try
                {
                    connect.Open();

                    MySqlDataReader reader;
                    reader = command.ExecuteReader();
                    return reader.Read();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "An error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
    }



    public static long Insert(string query)
    {
        using (MySqlConnection connect = new MySqlConnection(connectionString))
        {
            using (MySqlCommand command = new MySqlCommand(query, connect))
            {
                try
                {
                    connect.Open();
                    command.ExecuteNonQuery();
                    return command.LastInsertedId;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "An error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
            }
        }
    }



    public static void Update(string query)
    {

        using (MySqlConnection connect = new MySqlConnection(connectionString))
        {
            using (MySqlCommand command = new MySqlCommand(query, connect))
            {
                try
                {
                    connect.Open();
                    command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "An error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    public static void Delete(string query)
    {

        using (MySqlConnection connect = new MySqlConnection(connectionString))
        {
            using (MySqlCommand command = new MySqlCommand(query, connect))
            {
                try
                {
                    connect.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "An error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
