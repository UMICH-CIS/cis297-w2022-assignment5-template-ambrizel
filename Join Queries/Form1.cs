using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Join_Queries
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Intialize Components
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        private void PrinttextBox_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Prints in each of the ways specified
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            var databaseInput = new BooksExamples.BooksEntities();

            // Part A
            var a =
                from author in databaseInput.Authors
                from textbook in author.Titles
                orderby textbook.Title1
                select new { author.FirstName, author.LastName, textbook.Title1 };

            PrinttextBox.AppendText("Sorted by Title:");
            foreach (var element in a)
            {
                PrinttextBox.AppendText($"\r\n\t{element.FirstName,-10} " + $"{element.LastName,-10} {element.Title1,-10}");
            }


            // Part B
            var b =
             from textbook in databaseInput.Titles
             from author in textbook.Authors
             orderby textbook.Title1, author.LastName, author.FirstName
             select new { author.FirstName, author.LastName, textbook.Title1 };

            PrinttextBox.AppendText("\r\n\r\nSorted by Title: \r\nThen Authors Sorted Alphabetically by Author Last Then First Name:");
            foreach (var element in b)
            {
                PrinttextBox.AppendText($"\r\n\t{element.FirstName,-10} " + $"{element.LastName,-10} {element.Title1}");
            }


            // Part C
            var c =
                from textbook in databaseInput.Titles
                orderby textbook.Title1
                select new
                {
                    Name = textbook.Title1,
                    title = from author in textbook.Authors
                            orderby author.LastName, author.FirstName
                            select author.FirstName + " " + author.LastName
                };

            PrinttextBox.AppendText("\r\n\r\nSorted by Title: \r\nAuthors Grouped by Title: \r\nThen Authors Sorted Alphabetically by Author Last Then First Name:");
            foreach (var textbook in c)
            {
                // display author's name
                PrinttextBox.AppendText($"\r\n\t{textbook.Name}:");

                // display titles written by that author
                foreach (var title in textbook.title)
                {
                    PrinttextBox.AppendText($"\r\n\t\t{title}");
                }
            }
        }
    }
}
