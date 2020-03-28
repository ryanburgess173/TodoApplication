using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TodoApplication
{
    public partial class mainWindow : Form
    {
        private Session session;
        public mainWindow(string username)
        {
            try
            {
                InitializeComponent();
                this.session = new Session(username);
                initializeTable(this.session.getDatabaseManipulator().getConnection());
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
            this.session.getDatabaseManipulator().setSQL("EXECUTE getTodosForUser @username = '" + this.session.getUser() + "';");
            string result = this.session.getDatabaseManipulator().executeQueryScript();
            MessageBox.Show(result);
            updateTable(this.session.getDatabaseManipulator().getDataReader(), 6);
            this.session.getDatabaseManipulator().closeDataReader();
            this.session.getDatabaseManipulator().newDataReader();
        }
        private void btnInsertTodo_Click(object sender, EventArgs e)
        {
            String name = this.entryTodoName.Text;
            String description = this.entryTodoDescription.Text;
            String user = this.session.getUser();
            String datetime = this.entryTodoDateTime.Text;
            if (!name.Equals("") && !description.Equals("") && !datetime.Equals(""))
            {
                Todo todo = new Todo(name, description, user, datetime);
                this.session.getDatabaseManipulator().setSQL("INSERT INTO dbo.Todos(Name, Description, UserCreatedBy, DateTime) VALUES('" + name + "', '" + description + "', '" + user + "', '" + datetime + "');");
                string result = this.session.getDatabaseManipulator().executeInsertScript();
                Console.WriteLine(result);
                this.entryTodoName.Text = "";
                this.entryTodoDescription.Text = "";
                this.entryTodoDateTime.Text = "";
                this.updateTable(this.session.getDatabaseManipulator().getDataReader(), 6);
            }
            else
            {
                MessageBox.Show("Finish filling in the info to insert a Todo!", "Error");
            }
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
            this.session.getDatabaseManipulator().setSQL("EXECUTE groupByUsers;");
            string result = this.session.getDatabaseManipulator().executeQueryScript();
            Console.WriteLine(result);
            this.dataGridView1.ColumnCount = 2;
            this.dataGridView1.Columns[0].Name = "User";
            this.dataGridView1.Columns[1].Name = "Tasks Count";
            updateTable(this.session.getDatabaseManipulator().getDataReader(), 2);
            this.session.getDatabaseManipulator().closeDataReader();
            this.session.getDatabaseManipulator().newDataReader();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Refresh();
            initializeTable(this.session.getDatabaseManipulator().getConnection());
        }
    }
}
