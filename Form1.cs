using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Display_Titles_Table
{
    public partial class Form1 : Form
    {
        //Entity Framework DbContext
        private BooksExamples.BooksEntities dbcontext = new BooksExamples.BooksEntities();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //load Authors table ordered by LastName then FirstName
            dbcontext.Titles
                .OrderBy(titles => titles.ISBN)
                .Load();
            //specify datasource for authorBindingSource
            titleBindingSource.DataSource = dbcontext.Titles.Local;
        }

        private void titleDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
