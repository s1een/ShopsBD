using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace ShopsDB
{
    public partial class Form1 : Form
    {

        private SqlConnection sqlConnection;
        private SqlDataAdapter sqlDataAdapter;
        private SqlCommandBuilder sqlBuilder;
        private DataSet dataSet;
        private bool newShop;
        private bool fieldFound;

        public Form1()
        {
            InitializeComponent();
        }

        // Загрузка данных из файла
        private void LoadData()
        {
            try
            {
                sqlDataAdapter = new SqlDataAdapter("SELECT *, 'Delete' as [Command] FROM Shops", sqlConnection);

                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();

                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Shops");
                dataGridView1.DataSource = dataSet.Tables["Shops"];
                dataGridView1.Columns["id"].ReadOnly = true;
                ((DataGridViewTextBoxColumn)dataGridView1.Columns["Building_number"]).MaxInputLength = 6;
                ((DataGridViewTextBoxColumn)dataGridView1.Columns["Phone_number"]).MaxInputLength = 10;
                ((DataGridViewTextBoxColumn)dataGridView1.Columns["Cellphone_number_1"]).MaxInputLength = 10;
                ((DataGridViewTextBoxColumn)dataGridView1.Columns["Cellphone_number_2"]).MaxInputLength = 10;


                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[7, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Загрузка данных при запуске приложения
        private void Form1_Load(object sender, EventArgs e)
        {
            string path = @"Data Source=.\SQLEXPRESS;Initial Catalog=Shops;Integrated Security=True";
            sqlConnection = new SqlConnection(path);
            sqlConnection.Open();
            SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM Shops", sqlConnection);
            Int32 count = (Int32)comm.ExecuteScalar();
            if (count < 1)
            {
                if (File.Exists(@"shops_excel.xlsx"))
                    ImportDataBase();
                else MessageBox.Show("Data file not found, empty table was created.", "Creating", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            LoadData();
            

            
            sqlConnection.Close();
        }
        // Импорт данных из файла
        private void ImportDataBase()
        {
            try
            {
                string path = @"Data Source=.\SQLEXPRESS;Initial Catalog=Shops;Integrated Security=True";
                sqlConnection = new SqlConnection(path);
                string fileName = @"shops_excel.xlsx";
                var sheetName = "Аркуш2";
                DataTable data = new DataTable();
                using (System.Data.OleDb.OleDbConnection myConnection =
                    new System.Data.OleDb.OleDbConnection(
                        "Provider = Microsoft.ACE.OLEDB.12.0;" +
                        "data source = '" + fileName + "';" +
                        "Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\" "))
                {
                    using (System.Data.OleDb.OleDbDataAdapter import =
                        new System.Data.OleDb.OleDbDataAdapter("select * from [" + sheetName + "$]", myConnection))
                    {
                        import.Fill(data);
                    }
                }

                sqlConnection.Open();   
                using (SqlBulkCopy BC = new SqlBulkCopy(sqlConnection))
                {
                    BC.DestinationTableName = "dbo" + "." + "Shops";
                    foreach (var column in data.Columns)
                        BC.ColumnMappings.Add(column.ToString(), column.ToString());
                    BC.WriteToServer(data);
                }
                sqlConnection.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Обновление данных в таблице
        private void UpdateData()
        {
            try
            {
                dataSet.Tables["Shops"].Clear();
                sqlDataAdapter.Fill(dataSet, "Shops");
                dataGridView1.DataSource = dataSet.Tables["Shops"];

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[7, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Работа с полями таблицы(удаление,редактирование,добавление)
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 7)
                {

                    string task = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                    int rowIndex;
                    string path = @"Data Source=.\SQLEXPRESS;Initial Catalog=Shops;Integrated Security=True";

                    switch (task)
                    {
                        case "Insert":
                            try
                            {
                                sqlConnection = new SqlConnection(path);
                                sqlConnection.Open();
                                sqlDataAdapter = new SqlDataAdapter("SELECT *, 'Delete' as [Command] FROM Shops", sqlConnection);
                                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
                                dataSet = new DataSet();

                                sqlDataAdapter.Fill(dataSet, "Shops");
                                rowIndex = dataGridView1.Rows.Count - 2;

                                DataRow row = dataSet.Tables["Shops"].NewRow();
                                row["Street_name"] = dataGridView1.Rows[rowIndex].Cells["Street_name"].Value;
                                row["Building_number"] = dataGridView1.Rows[rowIndex].Cells["Building_number"].Value;
                                row["Phone_number"] = dataGridView1.Rows[rowIndex].Cells["Phone_number"].Value;
                                row["Cellphone_number_1"] = dataGridView1.Rows[rowIndex].Cells["Cellphone_number_1"].Value;
                                row["Cellphone_number_2"] = dataGridView1.Rows[rowIndex].Cells["Cellphone_number_2"].Value;
                                row["Name"] = dataGridView1.Rows[rowIndex].Cells["Name"].Value;

                                dataSet.Tables["Shops"].Rows.Add(row);
                                dataGridView1.Rows[e.RowIndex].Cells[7].Value = "Delete";

                                sqlDataAdapter.Update(dataSet, "Shops");
                                sqlConnection.Close();

                                newShop = false;
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("'address' and 'name' fields cannot be empty", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            UpdateData();
                            break;
                             
                        case "Update":
                            sqlConnection = new SqlConnection(path);
                            sqlConnection.Open();
                            sqlDataAdapter = new SqlDataAdapter("SELECT *, 'Delete' as [Command] FROM Shops", sqlConnection);
                            sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
                            dataSet = new DataSet();

                            sqlDataAdapter.Fill(dataSet, "Shops");

                            int r = dataGridView1.CurrentCell.RowIndex;

                            int db_id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["id"].Value);
                            dataSet.Tables["Shops"].Rows[db_id - 1]["Street_name"] = dataGridView1.Rows[r].Cells["Street_name"].Value;
                            dataSet.Tables["Shops"].Rows[db_id - 1]["Building_number"] = dataGridView1.Rows[r].Cells["Building_number"].Value;
                            dataSet.Tables["Shops"].Rows[db_id - 1]["Phone_number"] = dataGridView1.Rows[r].Cells["Phone_number"].Value;
                            dataSet.Tables["Shops"].Rows[db_id - 1]["Cellphone_number_1"] = dataGridView1.Rows[r].Cells["Cellphone_number_1"].Value;
                            dataSet.Tables["Shops"].Rows[db_id - 1]["Cellphone_number_2"] = dataGridView1.Rows[r].Cells["Cellphone_number_2"].Value;
                            dataSet.Tables["Shops"].Rows[db_id - 1]["Name"] = dataGridView1.Rows[r].Cells["Name"].Value;
                            
                            sqlDataAdapter.Update(dataSet, "Shops");

                            dataGridView1.Rows[e.RowIndex].Cells[7].Value = "Delete";
                            sqlConnection.Close();
                            break;
                        case "Delete":
                            if (MessageBox.Show("Do you want to delete a store?", "Deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                == DialogResult.Yes)
                            {
                                rowIndex = e.RowIndex;
                                dataGridView1.Rows.RemoveAt(rowIndex);
                                dataSet.Tables["Shops"].Rows[rowIndex].Delete();
                                sqlDataAdapter.Update(dataSet, "Shops"); 
                                UpdateData();
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Добавление новой записи в базу данных
        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (!newShop)
                {
                    newShop = true;
                    int lastRow = dataGridView1.RowCount - 2;
                    DataGridViewRow row = dataGridView1.Rows[lastRow];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[7, lastRow] = linkCell;
                    row.Cells["Command"].Value = "Insert";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Обновление поля таблицы
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newShop == false)
                {
                    int rowIndex = dataGridView1.SelectedCells[0].RowIndex;

                    DataGridViewRow editingRow = dataGridView1.Rows[rowIndex];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[7, rowIndex] = linkCell;
                    editingRow.Cells["Command"].Value = "Update";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Проверка полей на корректность
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(InputControl);

            if (dataGridView1.CurrentCell.ColumnIndex == 3 ||
                dataGridView1.CurrentCell.ColumnIndex == 4 ||
                dataGridView1.CurrentCell.ColumnIndex == 5)
            { 
                    TextBox textBox = e.Control as TextBox; 
                if (textBox!= null)
                {
                    textBox.KeyPress += new KeyPressEventHandler(InputControl);
                }
            }
        }
        // Загрузка данных из файла
        private void LoadDB_Click(object sender, EventArgs e)
        {
            try
            {
                sqlConnection.Open();

                sqlDataAdapter = new SqlDataAdapter("TRUNCATE  TABLE Shops", sqlConnection);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Shops");
                dataGridView1.DataSource = dataSet.Tables["Shops"];

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (File.Exists(@"shops_excel.xlsx"))
            {
                ImportDataBase();
                LoadData();
            }
            else
                LoadData();

        }
        // Сохранение данных в файл
        private void SaveDB_Click(object sender, EventArgs e)
        {
            string fileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" +
    "ExportShops.xlsx";

            Excel.Application xlsApp;
            Excel.Workbook xlsWorkbook;
            Excel.Worksheet xlsWorksheet;
            object misValue = System.Reflection.Missing.Value;
            // Если файл существует - удаляем
            try
            {
                FileInfo oldFile = new FileInfo(fileName);
                if (oldFile.Exists)
                {
                    File.SetAttributes(oldFile.FullName, FileAttributes.Normal);
                    oldFile.Delete();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing old Excel report: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            try
            {
                xlsApp = new Excel.Application();
                xlsWorkbook = xlsApp.Workbooks.Add(misValue);
                xlsWorksheet = (Excel.Worksheet)xlsWorkbook.Sheets[1];

                string path = @"Data Source=.\SQLEXPRESS;Initial Catalog=Shops;Integrated Security=True";
                sqlConnection = new SqlConnection(path);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Shops", sqlConnection);
                SqlDataReader dr = cmd.ExecuteReader();

                xlsWorksheet.Cells[1, 1] = "id";
                xlsWorksheet.Cells[1, 2] = "Street_name";
                xlsWorksheet.Cells[1, 3] = "Building_number";
                xlsWorksheet.Cells[1, 4] = "Phone_number";
                xlsWorksheet.Cells[1, 5] = "Cell_phone_number_1";
                xlsWorksheet.Cells[1, 6] = "Cell_phone_number_2";
                xlsWorksheet.Cells[1, 7] = "Name";

                int i = 2;
                if (dr.HasRows)
                {

                    for (int j = 0; j < dr.FieldCount; ++j)
                    {
                        xlsWorksheet.Cells[i, j + 1] = dr.GetName(j);
                    }
                    ++i;
                }

                i = 2;
                while (dr.Read())
                {
                    for (int j = 1; j <= dr.FieldCount; ++j)
                        xlsWorksheet.Cells[i, j] = dr.GetValue(j - 1);
                    ++i;
                }

                Excel.Range range = xlsWorksheet.get_Range("A1", "I" + (i + 2).ToString());
                range.Columns.AutoFit();


                xlsWorkbook.SaveAs(fileName, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue,
                                    misValue, misValue,
                                    Excel.XlSaveAsAccessMode.xlExclusive, Excel.XlSaveConflictResolution.xlLocalSessionChanges,
                                    misValue, misValue, misValue, misValue);
                xlsWorkbook.Close(true, misValue, misValue);
                xlsApp.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsWorksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsWorkbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsApp);

                MessageBox.Show("The file is saved on your desktop!", "Save Data Base", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Поиск по таблице
        private void SearchDB_button_Click(object sender, EventArgs e)
        {
            fieldFound = false;
            string filter = "" + SearchDB_textBox.Text.Trim();
            if (filter != "")
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                        {
                            if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(filter))
                            {
                                fieldFound = true;
                                break;
                            }

                            if (j == dataGridView1.ColumnCount-1)
                            {
                                dataGridView1.Rows[i].Selected = true;
                            }
                        }
                            
                }
            if (fieldFound == true)
            {
                fieldFound = false;
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.RemoveAt(row.Index);
                }
                dataGridView1.Refresh();

            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows[row.Index].Selected = false;
                }
                MessageBox.Show("The information you entered was not found!", "Searching", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
        }
        // Проверка данных на корректность
        private void InputControl(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }
        // Удаление всех данных из таблицы
        private void ClearDB_button_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"Data Source=.\SQLEXPRESS;Initial Catalog=Shops;Integrated Security=True";
                sqlConnection = new SqlConnection(path);
                sqlConnection.Open();

                sqlDataAdapter = new SqlDataAdapter("TRUNCATE  TABLE Shops", sqlConnection);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);


                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Shops");
                dataGridView1.DataSource = dataSet.Tables["Shops"];

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadData();
        }
        // Запуск пользовательского мануала
        private void UserManual_button_Click(object sender, EventArgs e)
        {
            string filename = "user_manual.pdf";
            System.Diagnostics.Process.Start(filename);
        }
        // Запуск формы с информацией о разработчике
        private void DevInfo_button_Click(object sender, EventArgs e)
        {
            DeveloperForm developerForm = new DeveloperForm();
            developerForm.Show();
        }
        // Обновление базы данных
        private void UpdateDB_button_Click(object sender, EventArgs e)
        {
            UpdateData();
        }
    }
}
