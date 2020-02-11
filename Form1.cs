using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TodoApplication
{
    public partial class mainWindow : Form
    {
        public mainWindow()
        {
            try
            {
                InitializeComponent();
                string connectionString = @"Data Source=DESKTOP-U4J07QN\SQLEXPRESS;Integrated Security=False;Initial Catalog=Todos;User ID=sa;Password=programmer;";
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                MessageBox.Show("Connection Open !");

                SqlCommand command;
                SqlDataReader dataReader;
                String sql = "";
                sql = "SELECT * FROM Todos;";
                command = new SqlCommand(sql, conn);
                dataReader = command.ExecuteReader();
                outputData(dataReader);

                conn.Close();
            }
            catch(SqlException e)
            {
                Console.WriteLine(e);
            }
        }
        private void outputData(SqlDataReader dataReader)
        {
            this.dataGridView1.ColumnCount = 6;
            this.dataGridView1.Columns[0].Name = "Todo ID";
            this.dataGridView1.Columns[1].Name = "Name";
            this.dataGridView1.Columns[2].Name = "Description";
            this.dataGridView1.Columns[3].Name = "User";
            this.dataGridView1.Columns[4].Name = "Date & Time";
            this.dataGridView1.Columns[5].Name = "Completed? (1=yes, 0=no)";
            int counter = 0;
            while (dataReader.Read())
            {
                this.dataGridView1.Rows.Add();
                for(int i=0; i<6; i++)
                {
                    this.dataGridView1.Rows[counter].Cells[i].Value = dataReader.GetValue(i);
                }
                counter++;
            }
        }
        private void btnInsertTodo_Click(object sender, EventArgs e)
        {
            
        }
    }
}
