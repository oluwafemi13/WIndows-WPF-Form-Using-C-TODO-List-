using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ApplicationToDo
{
    class DbTodo
    {
        public static SqlConnection GetConnection()
        {
            string connection = @"Data Source=LAPTOP-01CQPF63\SQLEXPRESS;Initial Catalog=TODODatabase;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connection);
            try
            {
                sqlConnection.Open();
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Error Connecting to Database"+ ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return sqlConnection;
        }

        public static void AddTask(Task tsk)
        {
            string insert = "INSERT INTO TODOTable VALUES (@TaskTitle, @TaskDescription, @TaskDate)";
            SqlConnection conn = GetConnection();
            SqlCommand cmd = new SqlCommand(insert, conn);
            //worry about the next line
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@TaskTitle", SqlDbType.VarChar).Value = tsk.Title;
            cmd.Parameters.Add("@TaskDescription", SqlDbType.VarChar).Value = tsk.Description;
            cmd.Parameters.Add("@TaskDate", SqlDbType.DateTime).Value = tsk.Date;
           
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully","Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (SqlException ex)
            {

                MessageBox.Show("Error Updating Database"+ ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }


        public static void UpdateTask(Task tsk, string id)
        {
            string update = "UPDATE TODOTable SET Title = @TaskTitle, Description = @TaskDescription, Date_Time = @TaskDate WHERE  task_id = @TaskID ";
            SqlConnection conn = GetConnection();
            SqlCommand cmd = new SqlCommand(update, conn);
            //worry about the next line
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@TaskTitle", SqlDbType.VarChar).Value = tsk.Title;
            cmd.Parameters.Add("@TaskDescription", SqlDbType.VarChar).Value = tsk.Description;
            cmd.Parameters.Add("@TaskDate", SqlDbType.DateTime).Value = tsk.Date;
            cmd.Parameters.Add("@TaskID", SqlDbType.VarChar).Value = id;
            
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (SqlException ex)
            {

                MessageBox.Show("Error Inserting into Database" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        public static void DeleteTask(string id)
        {
            string sql = "DELETE FROM TODOTable WHERE Task_id = @TaskID";
            SqlConnection conn = GetConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            //worry about the next line
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@TaskID", SqlDbType.VarChar).Value =id;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (SqlException ex)
            {

                MessageBox.Show("Error Deleting from Database" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        public static void DisplayAndSearch(String query, DataGridView dgv)
        {
            string sql = query;
            SqlConnection connection = GetConnection();
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            dataAdapter.Fill(tbl);
            dgv.DataSource = tbl;
            connection.Close();


        }
    }
}
