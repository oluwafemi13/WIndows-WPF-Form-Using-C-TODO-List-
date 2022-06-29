using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationToDo
{
    public partial class Application : Form
    {
        FormAddToDo form;
        public Application()
        {
            InitializeComponent();
            form = new FormAddToDo(this);
        }

        public void Display()
        {
            DbTodo.DisplayAndSearch("SELECT task_id, Title, Description, Date_Time FROM TODOTable", dataGridView);
            
        }

        public void buttonNew_Click(object sender, EventArgs e)
        {
            form.Clear();
            //FormAddToDo formAdd = new FormAddToDo(this);
            form.ShowDialog();
        }

        private void Application_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DbTodo.DisplayAndSearch("SELECT task_id, Title, Description, Date_Time FROM TODOTable WHERE Title LIKE '%"+textBoxSearch.Text+"%' ", dataGridView);
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                //this is to edit
                form.Clear();
                form.id = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.description = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.title = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.UpdateInfo();
                form.ShowDialog();

                
                return;
            }
            if(e.ColumnIndex == 1)
            {
                //this is to delete
                if (MessageBox.Show("Are you sure you want to delete?", "information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                    DbTodo.DeleteTask(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display();
            }
            return;
        }

       

        /* private void Application_Load(object sender, EventArgs e)
         {
             // TODO: This line of code loads data into the 'tODODatabaseDataSet.TODOTable' table. You can move, or remove it, as needed.
             this.tODOTableTableAdapter.Fill(this.tODODatabaseDataSet.TODOTable);

         }*/
    }
}
