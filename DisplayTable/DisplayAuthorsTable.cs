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

namespace DisplayTable
{
    public partial class DisplayAuthorsTable : Form
    {
        private bool searchActive = true;
        public DisplayAuthorsTable()
        {
            InitializeComponent();
        }

        //Entity Framework DbContext
        private BooksExamples.BooksEntities dbcontext = new BooksExamples.BooksEntities();
        //load data from database into DataGridView
        private void DisplayAuthorsTable_Load(object sender, EventArgs e)
        {
            //load Authors table ordered by LastName then FirstName
            dbcontext.Authors
                .OrderBy(author => author.LastName)
                .ThenBy(author => author.FirstName)
                .Load();
            //specify datasource for authorBindingSource
            authorBindingSource.DataSource = dbcontext.Authors.Local;
        }

        /// <summary>
        /// Sets for screen refresh after user click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void authorBindingNavigator_RefreshItems(object sender, EventArgs e)
        {
            if (searchActive == true)
            {
                //load Authors table ordered by LastName then FirstName
                dbcontext.Authors
                    .OrderBy(author => author.LastName)
                    .ThenBy(author => author.FirstName)
                    .Load();
                //specify datasource for authorBindingSource
                authorBindingSource.DataSource = dbcontext.Authors.Local;
            }
        }

        /// <summary>
        /// binds the author to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void authorBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate();
            authorBindingSource.EndEdit();
            try
            {
                dbcontext.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                MessageBox.Show("FirstName and LastName must contain values", "Entity Validation Exception");
            }
        }

        private void authorDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Called when the user presses the Search Button
        /// Displays only the authors with the user searched for last name from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Searchbutton_Click(object sender, EventArgs e)
        {
            searchActive = false;
            authorBindingSource.DataSource = dbcontext.Authors.Local.Where(author => author.LastName.StartsWith(findTextBox.Text)).OrderBy(author => author.LastName).ThenBy(author => author.FirstName);
            authorBindingSource.MoveFirst();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DisplayAuthorsTable_Load_1(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Called when the user presses the Reset Table Button
        /// Displays all the authors from the database again - it resets the table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            searchActive = true;
            //load Authors table ordered by LastName then FirstName
            dbcontext.Authors
                .OrderBy(author => author.LastName)
                .ThenBy(author => author.FirstName)
                .Load();
            //specify datasource for authorBindingSource
            authorBindingSource.DataSource = dbcontext.Authors.Local;
        }
    }
}
