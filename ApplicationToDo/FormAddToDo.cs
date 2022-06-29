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
    public partial class FormAddToDo : Form
    {
        private readonly Application _parent;
        public string id, title, description;

       /* public FormAddToDo()
        {
        }
*/
        public void Clear()
        {
            textBoxTitle.Text = richTextBoxDescription.Text= string.Empty;
        }

        public FormAddToDo(Application parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void UpdateInfo()
        {
            labelUpdate.Text = "Update Task";
            textBoxTitle.Text = title;
            buttonAdd.Text = "update";
            richTextBoxDescription.Text = description;
            

        }

       /* private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {

        }*/

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxTitle.Text.Trim().Length <=1)
            {
                MessageBox.Show(" Title to Short(>1)");
                return;
            }
            if (richTextBoxDescription.Text.Trim().Length <= 1)
            {
                MessageBox.Show(" Description to Short(>1)");
                return;
            }
           /* if (monthCalendar.Text.Trim().Length ==0)
            {
                MessageBox.Show("Calendar is Empty");
                return;
            }*/
            if(buttonAdd.Text == "Add")
            {
                Task task = new Task(textBoxTitle.Text.Trim(), richTextBoxDescription.Text.Trim(), monthCalendar.SelectionStart);
                DbTodo.AddTask(task);
                Clear();
                
            }

            if(buttonAdd.Text == "update")
            {
                Task task = new Task(textBoxTitle.Text.Trim(), richTextBoxDescription.Text.Trim(), monthCalendar.SelectionStart);
                DbTodo.UpdateTask(task, id);
            }
            _parent.Display();



        }

       /* private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }*/
    }
}
