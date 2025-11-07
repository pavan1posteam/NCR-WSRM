using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NCR_WSRM_.Model
{
    class GenerateCSV
    {
        public static string GenerateCSVproductt(List<ProductModel> productList)
        {
            StringBuilder sb = new StringBuilder();
            try
            {

                if (productList == null || productList.Count == 0)
                    return string.Empty;

                // Add the headers based on property names of Product class
                var properties = typeof(ProductModel).GetProperties();
                int totalColumns = properties.Length;
                int count = 1;

                foreach (var prop in properties)
                {
                    sb.Append(prop.Name); // Using the property name as the header

                    if (count != totalColumns)
                    {
                        sb.Append(",");
                    }

                    count++;
                }


                sb.AppendLine();

                // Loop through the list and add data for each product
                foreach (var product in productList)
                {
                    int x = 0;
                    foreach (var prop in properties)
                    {

                        var value = prop.GetValue(product, null)?.ToString() ?? string.Empty;

                        // Escape commas and quotes in the values
                        if (value.Contains(",") || value.Contains("\""))
                        {
                            value = '"' + value.Replace("\"", "\"\"") + '"';
                        }

                        sb.Append(value);

                        if (x != totalColumns - 1)
                        {
                            sb.Append(",");
                        }

                        x++;
                    }

                    sb.AppendLine();
                }

                // Create the file name               
                ClsSettings setting = new ClsSettings();
                string filename = "PRODUCT" + setting.StoreId + DateTime.Now.ToString("yyyyMMddhhmmss") + ".csv";
                File.WriteAllText(Path.Combine("Upload", filename), sb.ToString());

                return filename;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "";
        }

        public static string GenerateCSVfull(List<Fullname> productList)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                if (productList == null || productList.Count == 0)
                    return string.Empty;

                // Add the headers based on property names of Product class
                var properties = typeof(Fullname).GetProperties();
                int totalColumns = properties.Length;
                int count = 1;

                foreach (var prop in properties)
                {
                    sb.Append(prop.Name); // Using the property name as the header

                    if (count != totalColumns)
                    {
                        sb.Append(",");
                    }

                    count++;
                }

                sb.AppendLine();

                // Loop through the list and add data for each product
                foreach (var product in productList)
                {
                    int x = 0;
                    foreach (var prop in properties)
                    {
                        var value = prop.GetValue(product, null)?.ToString() ?? string.Empty;

                        // Escape commas and quotes in the values
                        if (value.Contains(",") || value.Contains("\""))
                        {
                            value = '"' + value.Replace("\"", "\"\"") + '"';
                        }

                        sb.Append(value);

                        if (x != totalColumns - 1)
                        {
                            sb.Append(",");
                        }

                        x++;
                    }

                    sb.AppendLine();
                }

                // Create the file name
                ClsSettings setting = new ClsSettings();
                string filename = "Fullname" + setting.StoreId + DateTime.Now.ToString("yyyyMMddhhmmss") + ".csv";
                File.WriteAllText(Path.Combine("Upload", filename), sb.ToString());

                return filename;
            }
            catch (Exception)
            {
                // Handle the error (e.g., logging)
            }
            return "";
        }

        

        public static string GenerateCSV1(DataTable dt)
        {
            ClsSettings clsSettings = new ClsSettings();
            StringBuilder sb = new StringBuilder();
            try
            {
                int count = 1;
                int totalColumns = dt.Columns.Count;
                foreach (DataColumn dr in dt.Columns)
                {
                    sb.Append(dr.ColumnName);

                    if (count != totalColumns)
                    {
                        sb.Append(",");
                    }

                    count++;
                }
                sb.AppendLine();

                string value = String.Empty;
                foreach (DataRow dr in dt.Rows)
                {
                    for (int x = 0; x < totalColumns; x++)
                    {
                        value = dr[x].ToString();

                        if (value.Contains(",") || value.Contains("\""))
                        {
                            value = '"' + value.Replace("\"", "\"\"") + '"';
                        }

                        sb.Append(value);

                        if (x != (totalColumns - 1))
                        {
                            sb.Append(",");
                        }
                    }

                    sb.AppendLine();
                }
                string filename = "product" + clsSettings.StoreId + DateTime.Now.ToString("yyyyMMddhhmmss") + ".csv";

                File.WriteAllText("Upload\\" + filename, sb.ToString());

                return filename;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "";
        }
        public static string GenerateCSV2(DataTable dt)
        {
            ClsSettings clsSettings = new ClsSettings();
            StringBuilder sb = new StringBuilder();
            try
            {
                int count = 1;
                int totalColumns = dt.Columns.Count;
                foreach (DataColumn dr in dt.Columns)
                {
                    sb.Append(dr.ColumnName);

                    if (count != totalColumns)
                    {
                        sb.Append(",");
                    }

                    count++;
                }

                sb.AppendLine();

                string value = String.Empty;
                foreach (DataRow dr in dt.Rows)
                {
                    for (int x = 0; x < totalColumns; x++)
                    {
                        value = dr[x].ToString();

                        if (value.Contains(",") || value.Contains("\""))
                        {
                            value = '"' + value.Replace("\"", "\"\"") + '"';
                        }

                        sb.Append(value);

                        if (x != (totalColumns - 1))
                        {
                            sb.Append(",");
                        }
                    }

                    sb.AppendLine();
                }
                string FullName = "FullName" + clsSettings.StoreId + DateTime.Now.ToString("yyyyMMddhhmmss") + ".csv";

                File.WriteAllText("Upload\\" + FullName, sb.ToString());

                return FullName;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "";
        }
    }
}
