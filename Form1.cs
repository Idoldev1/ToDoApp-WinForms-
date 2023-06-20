using System.Data;

namespace TodoWF;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }


    DataTable todoList = new DataTable();
    bool isEditing = false; 
    private void TodoList_Load( object sender, EventArgs e)
    {
        // Create columns
        todoList.Columns.Add("Title");
        todoList.Columns.Add("Description");

        // Point our datagridview to our datasource
        toDoListView.DataSource = todoList;
    }

    private void newButton_Click(object sender, EventArgs e)
    {
        titleTextBox.Text = "";
        descriptionTextbox.Text = "";
    }

    private void editButton_Click(object sender, EventArgs e)
    {
        isEditing = true;
        titleTextBox.Text = todoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[0].ToString();
        descriptionTextBox.Text = todoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[1].ToString();

    }

    private void deleteButton_Click(object sender, EventArgs e)
    {
        try
        {
            todoList.Rows[toDoListView.CurrentCell.RowIndex].Delete();
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error  " + ex);
        }
    }

    private void saveButton_Click(object sender, EventArgs e)
    {
        if(isEditing)
        {
            todoList.Rows[toDoListView.CurrentCell.RowIndex] ["Title"] = titleTextBox.Text;
            todoList.Rows[toDoListView.CurrentCell.RowIndex] ["Description"] = descriptioTextBox.Text;
        }
        else
        {
            todoList.Rows.Add(titleTextBox.Text, descriptionTextBox.Text);
        }
        // Clear fields
        titleTextBox.Text = "";
        descriptionTextBox.Text = "";
        isEditing = false;
    }
}
