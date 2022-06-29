using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationToDo
{
    
    class Task
    {
       public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

       


        public Task(string title, string description, DateTime date)
        {
            this.Title = title;
            this.Description = description;
            this.Date = date;
            
        }
    }
   
 }

