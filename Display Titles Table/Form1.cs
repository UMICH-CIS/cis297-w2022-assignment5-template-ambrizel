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

        /// <summary>
        /// Intialize Components
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads information from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {/*
            //load Authors table ordered by LastName then FirstName
            dbcontext.Titles
                .OrderBy(titles => titles.ISBN)
                .Load();
            //specify datasource for authorBindingSource
            titleBindingSource.DataSource = dbcontext.Titles.Local;*/
            dbcontext.Titles.OrderBy(titles => titles.Title1).Load();

            titleBindingSource.DataSource = dbcontext.Titles.Local;
        }

        private void titleDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Called when the user presses the Search Button
        /// Displays only the books with the user searched for book titles from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BookeTitlebutton_Click(object sender, EventArgs e)
        {
            titleBindingSource.DataSource = dbcontext.Titles.Local.Where(title => title.Title1.Contains(findTextBox.Text)).OrderBy(title => title.Title1);
            titleBindingSource.MoveFirst();
        }

        /// <summary>
        /// Called when the user presses the Reset Table Button
        /// Displays all the books from the database again - it resets the table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Resetbutton_Click(object sender, EventArgs e)
        {
            dbcontext.Titles.OrderBy(titles => titles.Title1).Load();

            titleBindingSource.DataSource = dbcontext.Titles.Local;
        }
    }
}
