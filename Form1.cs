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
        const string USERNAME = "ryan";
        public mainWindow()
        {
            try
            {
                InitializeComponent();
                Session session = new Session();
                initializeTable(session.getDatabaseManipulator().getConnection());
            }
            catch(SqlException e)
            {
                Console.WriteLine(e);
            }
        }
        private void initializeTable(SqlConnection conn)
        {
            this.dataGridView1.ColumnCount = 6;
            this.dataGridView1.Columns[0].Name = "Todo ID";
            this.dataGridView1.Columns[1].Name = "Name";
            this.dataGridView1.Columns[1].Width = 150;
            this.dataGridView1.Columns[2].Name = "Description";
            this.dataGridView1.Columns[2].Width = 350;
            this.dataGridView1.Columns[3].Name = "User";
            this.dataGridView1.Columns[4].Name = "Date & Time";
            this.dataGridView1.Columns[4].Width = 120;
            this.dataGridView1.Columns[5].Name = "Completed? (1=yes, 0=no)";
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Refresh();
            dm.setSQL("EXECUTE getTodosForUser @username = '"+USERNAME+"';");
            dm.executeScript();
            updateTable(dm.getDataReader(), 6);
            dm.closeDataReader();
        }
        private void btnInsertTodo_Click(object sender, EventArgs e)
        {
            String name = this.entryTodoName.Text;
            String description = this.entryTodoDescription.Text;
            String user = this.entryUser.Text;
            String datetime = this.entryTodoDateTime.Text;
            Todo todo = new Todo(name, description, user, datetime);
        }
        private void updateTable(SqlDataReader dataReader, int columnCount)
        {
            int counter = 0;
            while (dataReader.Read())
            {
                this.dataGridView1.Rows.Add();
                for (int i = 0; i < columnCount; i++)
                {
                    this.dataGridView1.Rows[counter].Cells[i].Value = dataReader.GetValue(i);
                }
                counter++;
            }
        }

        private void btnGroupByUser_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Refresh();
            dm.setSQL("EXECUTE groupByUsers;");
            dm.executeScript();
            this.dataGridView1.ColumnCount = 2;
            this.dataGridView1.Columns[0].Name = "User";
            this.dataGridView1.Columns[1].Name = "Tasks Count";
            updateTable(dm.getDataReader(), 2);
            dm.closeDataReader();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Refresh();
            initializeTable(dm.getConn());
        }
    }
}
