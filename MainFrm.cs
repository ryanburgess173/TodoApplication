using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TodoApplication
{
    public partial class mainWindow : Form
    {
        private DatabaseManipulator dm;
        private Session session;
        public mainWindow(string username)
        {
            try
            {
                InitializeComponent();
                session = new Session(username);
                this.dm = session.getDatabaseManipulator();
                initializeTable(this.dm.getConnection());
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
            this.dm.setSQL("EXECUTE getTodosForUser @username = '" + this.session.getUser() + "';");
            string result = this.dm.executeQueryScript();
            MessageBox.Show(result);
            updateTable(this.dm.getDataReader(), 6);
            this.dm.closeDataReader();
        }
        private void btnInsertTodo_Click(object sender, EventArgs e)
        {
            String name = this.entryTodoName.Text;
            String description = this.entryTodoDescription.Text;
            String user = this.session.getUser();
            String datetime = this.entryTodoDateTime.Text;
            Todo todo = new Todo(name, description, user, datetime);
            this.dm.setSQL("INSERT INTO Todos(Name, Description, UserCreatedBy, DateTime) VALUES('"+name+"', '"+description+"', '"+user+"', '"+datetime+"',)");
            string result = this.dm.executeInsertScript();
            MessageBox.Show(result);
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
            string result = dm.executeQueryScript();
            MessageBox.Show(result);
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
            initializeTable(this.dm.getConnection());
        }
    }
}
