// 代码生成时间: 2025-09-04 17:17:22
 * It follows C# best practices for maintainability and scalability.
 */

using System;
using System.IO;
using System.Data;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelGenerator
{
    public class ExcelGenerator
    {
        // Method to create an Excel file and save it
        public void CreateExcelFile(string filePath, DataTable dataTable)
        {
            try
            {
                // Create a new Excel application
                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = false;

                // Add a new workbook
                Excel.Workbook workbook = excelApp.Workbooks.Add();

                // Add a new worksheet
                Excel._Worksheet worksheet = workbook.Sheets[1];

                // Convert the DataTable to Excel Range
                worksheet.Cells[1, 1] = dataTable;

                // Save the Excel file
                workbook.SaveAs(filePath);

                // Clean up
                workbook.Close(false);
                excelApp.Quit();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the process
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        // Method to create a DataTable from a list of objects
        private DataTable CreateDataTable<T>(List<T> list) where T : class
        {
            DataTable dataTable = new DataTable();

            // Get the properties of the object type
            System.Reflection.PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                dataTable.Columns.Add(property.Name);
            }

            // Add the objects to the DataTable
            foreach (var item in list)
            {
                DataRow row = dataTable.NewRow();
                foreach (var property in properties)
                {
                    row[property.Name] = property.GetValue(item)?.ToString();
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        // Method to generate an Excel file from a list of objects
        public void GenerateExcelFromList<T>(string filePath, List<T> list) where T : class
        {
            DataTable dataTable = CreateDataTable(list);
            CreateExcelFile(filePath, dataTable);
        }
    }
}
