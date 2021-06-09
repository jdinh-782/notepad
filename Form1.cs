using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notepad
{
    public partial class Form1 : Form
    {
        DataTable table;

        public Form1()
        {
            InitializeComponent();
        }

        //intiialize a table for the DataTable in the form
        private void Form1_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add("title", typeof(String));
            table.Columns.Add("notes", typeof(String));

            dataTable.DataSource = table;

            dataTable.Columns["title"].Width = 80;
            dataTable.Columns["notes"].Width = 125;
        }

        //save the note when uesr clicks the 'Save' button
        private void saveButton_Click(object sender, EventArgs e)
        {
            table.Rows.Add(titleTextBox.Text, noteTextBox.Text);

            newButton_Click(sender, e);
        }

        private void noteTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        //delete a certain note when user clicks the 'Delete' button
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (table.Rows.Count >= 1)
            {
                int rowIndex = dataTable.CurrentCell.RowIndex;

                table.Rows[rowIndex].Delete();
            }
        }

        //load a specific note when user clicks the 'Load' button
        private void loadButton_Click(object sender, EventArgs e)
        {
            int rowIndex = dataTable.CurrentCell.RowIndex;

            if (rowIndex >= 0)
            {
                titleTextBox.Text = table.Rows[rowIndex].ItemArray[0].ToString();
                noteTextBox.Text = table.Rows[rowIndex].ItemArray[1].ToString();
            }
        }

        //clear both text boxes when user clicks the 'New' button
        private void newButton_Click(object sender, EventArgs e)
        {
            titleTextBox.Clear();
            noteTextBox.Clear();
        }
    }
}
