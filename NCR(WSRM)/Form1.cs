using NCR_WSRM_.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NCR_WSRM_
{
    public partial class Form1 : Form
    {
        ClsSettings setting = new ClsSettings();
        public int TimeElapsed { get; set; }
        private static string Argsprams { get; set; }
        public Form1(string[] args)
        {
            InitializeComponent();
            if (args.Length > 0)
            {
                Argsprams = args[0];
            }
            else
            {
                Argsprams = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if (File.Exists("config\\dbsettings.txt") & File.Exists("config\\ftpsettings.txt"))
            {
                setting.LoadSettings();
                btnUpload.Enabled = true;
            }
            else
            {
                btnUpload.Enabled = false;
            }
            if (Argsprams != "")
            {
                Uploading();
                Environment.Exit(0); 
            }
        }
        private void btnUpload_Click(object sender, EventArgs e)
        {
            Uploading();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void showstatus(string str)
        {
            var itm = str;
            listBox1.Items.Add(itm);
            listBox1.Refresh();
        }
        private void Uploading()
        {
            
            #region WSRM Stores
            //TimeElapsed = ClsSettings.UpTime * 60;
            showstatus("Connecting to Database");
            FileStream stream = new FileStream("config\\cat.txt", FileMode.Open, FileAccess.Read);
            string value;
            using (StreamReader streamReader = new StreamReader(stream, Encoding.UTF8))
            {
                value = streamReader.ReadToEnd();
            }
            ClsCategories[] array = JsonConvert.DeserializeObject<ClsCategories[]>(value);
            string text = "";
            ClsCategories[] array2 = array;
            ClsCategories[] array3 = array2;
            foreach (ClsCategories clsCategories in array3)
            {
                text = ((text.Length <= 0) ? (text + "'" + clsCategories.CategoryName + "'") : (text + ",'" + clsCategories.CategoryName + "'"));
            }
            if (text.Length > 0)
            {
                text = " and I.CATEG_COD in (" + text + ")";
            }
            if (array.ToList().Any((ClsCategories a) => a.CatId == "9999" && a.Select == 1))
            {
                text += " OR I.CATEG_COD IS NULL";
            }
            string text2 = "";
            if (setting.StockedItems == 1)
            {
                text2 = "  And I.QTY_ON_HND > 0";
            }
            string text3 = Environment.MachineName.ToString();
            string connectionString = setting.ConnectionString;
            string storeId = setting.StoreId;
            string fTPLocation = setting.FTPLocation;
            string ftpTax = setting.FtpTax;
            #region Previous NCR WSRM query
            // string text4 = "SELECT DISTINCT '" + storeId + "' AS StoreId, '#'+LTRIM(REPLACE(B.BARCOD, '/', '')) AS Upc, CAST(I.QTY_ON_HND AS INT) AS Qty, '#'+LTRIM(I.ITEM_NO) AS Sku,";
            // text4 += " ISNULL(I.STK_UNIT,'') AS DefaultUom,ISNULL(I.ALT_1_NUMER,0) as ALT_1_NUMER, ISNULL(I.ALT_1_UNIT,'') AS ALT_1_UNIT,ISNULL(I.ALT_3_NUMER,0) AS ALT_3_NUMER,ISNULL(I.ALT_3_UNIT,'') AS ALT_3_UNIT,";
            // text4 += " REPLACE(LTRIM(RTRIM(I.DESCR)), ',', ' ') AS StoreProductName,REPLACE(LTRIM(RTRIM(I.DESCR)), ',', ' ') AS StoreDescription,";
            //// text4 = text4 + " ISNULL(I.PRC_1,0) AS Price1,ISNULL(I.ALT_1_PRC_1,0) as Price2,ISNULL(I.ALT_3_PRC_1,0) as Price3, '' AS Sprice, '' AS Start, '' AS [End], '" + ftpTax + "' AS Tax,";
            // text4 = text4 + " ISNULL(p.PRC_1,0) AS Price1,ISNULL(p.ALT_1_PRC_1,0) as Price2,ISNULL(p.ALT_3_PRC_1,0) as Price3, '' AS Sprice, '' AS Start, '' AS [End], '" + ftpTax + "' AS Tax,";//Changed on 10/15/2025
            // text4 += " '' AS AltUpc1, '' AS AltUpc2, '' AS AltUpc3, '' AS AltUpc4, '' AS AltUpc5, ICC.DESCR as pcat, I.Subcat_Cod as pcat1, '' as pcat2, '' as region, '' as country ";
            // text4 += " FROM VI_IM_ITEM_WITH_INV I ";
            // text4 += " LEFT JOIN VI_IM_CELL_PRC_1 p on p.ITEM_NO = I.ITEM_NO ";//Added on 10/15/2025
            // text4 += " LEFT JOIN IM_BARCOD B ON B.ITEM_NO = I.ITEM_NO ";
            // text4 += " LEFT JOIN IM_CATEG_COD ICC ON I.CATEG_COD = ICC.CATEG_COD ";
            // text4 += " WHERE B.BARCOD != '' AND B.BARCOD IS NOT NULL ";
            // //text4 = text4 + " AND I.Loc_ID = '" + fTPLocation + "'" + text2 + text;
            // text4 = text4 + " AND p.STK_LOC_ID = '" + fTPLocation + "'" + " AND I.Loc_ID = '" + fTPLocation + "'" + text2;// + text;//Changed on 10/15/2025
            #endregion

            #region Updated NCR WSRM Query on 25/01/2026
            string text4 ="SELECT DISTINCT '" + storeId + "' AS StoreId, " +"'#'+LTRIM(REPLACE(B.BARCOD, '/', '')) AS Upc, " +"CAST(I.QTY_ON_HND AS INT) AS Qty, " +"'#'+LTRIM(I.ITEM_NO) AS Sku, " +"I.PREF_UNIT_NUMER AS PackSize, " +"I.PREF_UNIT_NAM AS UOM, " +"I.PREF_UNIT_PRC_1 AS Price, " +"I.CATEG_COD, " +"I.MIX_MATCH_COD, " +"I.IS_DISCNTBL, " +
"REPLACE(LTRIM(RTRIM(I.DESCR)), ',', ' ') AS StoreProductName, " +
"REPLACE(LTRIM(RTRIM(I.DESCR)), ',', ' ') AS StoreDescription, " +
"'" + ftpTax + "' AS Tax, " +
"ICC.DESCR AS pcat, " +
"ICC.DESCR_UPR AS pcat1, '' as pcat2, '' as region, '' as country " +

"FROM VI_IM_ITEM_WITH_INV I " +
"LEFT JOIN IM_BARCOD B ON B.ITEM_NO = I.ITEM_NO " +
"LEFT JOIN IM_CATEG_COD ICC ON I.CATEG_COD = ICC.CATEG_COD " +
"WHERE B.BARCOD IS NOT NULL AND B.BARCOD <> '' " +
"AND I.Loc_ID = '" + fTPLocation + "' " + text2;
            #endregion
            SqlConnection sqlConnection = new SqlConnection(setting.ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(text4, sqlConnection);
            sqlConnection.Open();
            sqlCommand.CommandTimeout = 0;
            sqlCommand.ExecuteNonQuery();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            DataTable dataTable2 = new DataTable();
            DataTable dataTable3 = new DataTable();
            List<ProductModel> list = new List<ProductModel>();
            List<Fullname> list2 = new List<Fullname>();
            #region previous NCR WSRM foreach loop
            //foreach (DataRow row in dataTable.Rows)
            //{
            //    ProductModel productModel = new ProductModel();
            //    Fullname fullname = new Fullname();
            //    List<int> list3 = new List<int>();
            //    List<string> list4 = new List<string>();
            //    List<decimal> list5 = new List<decimal>();
            //    try
            //    {
            //        int storeID = Convert.ToInt32(row["StoreId"]);
            //        string upc = row["Upc"].ToString();
            //        string sku = row["Sku"].ToString();
            //        int num = Convert.ToInt32(row["Qty"]);
            //        string text5 = row["Storeproductname"].ToString();
            //        string text6 = row["Storeproductname"].ToString();
            //        decimal num2 = Convert.ToDecimal(row["Price1"]);
            //        decimal num3 = Convert.ToDecimal(row["Price2"]);
            //        decimal num4 = Convert.ToDecimal(row["Price3"]);
            //        int num5 = Convert.ToInt32(row["ALT_1_NUMER"]);
            //        int num6 = Convert.ToInt32(row["ALT_3_NUMER"]);
            //        string text7 = row["ALT_1_UNIT"].ToString();
            //        string text8 = row["ALT_3_UNIT"].ToString();
            //        string text9 = row["DefaultUom"].ToString();
            //        string value2 = row["Tax"].ToString();
            //        string pcat = row["pcat"].ToString();
            //        string pcat2 = row["pcat1"].ToString();
            //        if (num2 != 0m && num3 != 0m && num4 != 0m)
            //        {
            //            list5.Add(Convert.ToDecimal(row["Price2"]));
            //            list5.Add(Convert.ToDecimal(row["Price3"]));
            //            if (num5 != 0)
            //            {
            //                list3.Add(Convert.ToInt32(num5));
            //            }
            //            if (num6 != 0)
            //            {
            //                list3.Add(Convert.ToInt32(num6));
            //            }
            //            if (text7 != "")
            //            {
            //                list4.Add(text7.ToString());
            //            }
            //            if (text8 != "")
            //            {
            //                list4.Add(text8.ToString());
            //            }
            //        }
            //        if (num2 != 0m && num3 == 0m && num4 != 0m)
            //        {
            //            list5.Add(Convert.ToDecimal(row["Price3"]));
            //            if (num6 != 0)
            //            {
            //                list3.Add(Convert.ToInt32(num6));
            //            }
            //            if (text8 != "")
            //            {
            //                list4.Add(text8.ToString());
            //            }
            //        }
            //        if (num2 != 0m && num3 != 0m && num4 == 0m)
            //        {
            //            list5.Add(Convert.ToDecimal(row["Price2"]));
            //            if (num5 != 0)
            //            {
            //                list3.Add(Convert.ToInt32(num5));
            //            }
            //            if (text7 != "")
            //            {
            //                list4.Add(text7.ToString());
            //            }
            //        }
            //        if (num2 != 0m && num3 == 0m && num4 == 0m)
            //        {
            //            list5.Add(Convert.ToDecimal(row["Price1"]));
            //            list3.Add(1);
            //            if (text9 != "")
            //            {
            //                list4.Add(text9.ToString());
            //            }
            //        }
            //        for (int num7 = 0; num7 < list5.Count; num7++)
            //        {
            //            int num8 = Convert.ToInt32(num / list3[num7]);
            //            ProductModel productModel2 = new ProductModel
            //            {
            //                StoreID = storeID,
            //                upc = upc,
            //                sku = sku,
            //                pack = ((num7 >= list3.Count) ? 1 : list3[num7]),
            //                uom = ((num7 < list4.Count) ? list4[num7] : text9),
            //                Qty = num8,
            //                StoreProductName = text5,
            //                StoreDescription = text5,
            //                Price = list5[num7],
            //                sprice = 0m,
            //                Start = "",
            //                End = "",
            //                Tax = Convert.ToDecimal(value2),
            //                altupc1 = "",
            //                altupc2 = "",
            //                altupc3 = "",
            //                altupc4 = "",
            //                altupc5 = ""
            //            };
            //            Fullname item = new Fullname
            //            {
            //                pname = text5,
            //                pdesc = text5,
            //                upc = upc,
            //                sku = sku,
            //                Price = productModel2.Price,
            //                uom = productModel2.uom,
            //                pack = productModel2.pack,
            //                pcat = pcat,
            //                pcat1 = pcat2,
            //                pcat2 = "",
            //                country = "",
            //                region = ""
            //            };
            //            if (productModel2.Price > 0m && productModel2.uom != "EACH-EX" && productModel2.uom != "4-6 PACK-EX" && productModel2.uom != "2-12 PACK-EX")
            //            {
            //                list.Add(productModel2);
            //                list2.Add(item);
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}
            #endregion
            #region Updated NCR WSRM foreach loop on 25/01/2026
            foreach (DataRow row in dataTable.Rows)
            {
                ProductModel productModel = new ProductModel();
                Fullname fullname = new Fullname();

                try
                {
                    int storeID = Convert.ToInt32(row["StoreId"]);
                    string upc = row["Upc"].ToString();
                    string sku = row["Sku"].ToString();
                    int qty = Convert.ToInt32(row["Qty"]);

                    int pack = row["PackSize"] == DBNull.Value ? 1 : Convert.ToInt32(row["PackSize"]);
                    string uom = row["UOM"]?.ToString();
                    decimal price = row["Price"] == DBNull.Value ? 0m : Convert.ToDecimal(row["Price"]);

                    int categCod = row["CATEG_COD"] == DBNull.Value ? 0 : Convert.ToInt32(row["CATEG_COD"]);
                    string mixMatch = row["MIX_MATCH_COD"] == DBNull.Value ? "": row["MIX_MATCH_COD"].ToString().Trim().ToUpper();


                    string isDbDiscountableRaw = row["IS_DISCNTBL"] == DBNull.Value ? "" : row["IS_DISCNTBL"].ToString().Trim().ToUpper();

                    int isDbDiscountable = 0;

                    if (
                        isDbDiscountableRaw == "1" ||
                        isDbDiscountableRaw == "Y" ||
                        isDbDiscountableRaw == "T" ||
                        isDbDiscountableRaw == "TRUE"
                    )
                    {
                        isDbDiscountable = 1;
                    }

                    string name = row["StoreProductName"].ToString();
                    decimal tax = Convert.ToDecimal(row["Tax"]);
                    string pcat = row["pcat"].ToString();
                    string pcat1 = row["pcat1"].ToString();
                    int finalDiscountable = 0;

                    if (
                        (categCod == 150 || categCod == 152 || categCod == 154) &&
                        mixMatch == "W01" &&
                        isDbDiscountable == 1
                    )
                    {
                        finalDiscountable = 1;
                    }
                    if (price > 0)
                    {
                        ProductModel product = new ProductModel
                        {
                            StoreID = storeID,
                            upc = upc,
                            sku = sku,
                            Qty = qty,
                            pack = pack,
                            uom = uom,
                            StoreProductName = name,
                            StoreDescription = name,
                            Price = price,
                            Discountable = finalDiscountable,
                            Tax = tax
                        };

                        Fullname item = new Fullname
                        {
                            pname = name,
                            pdesc = name,
                            upc = upc,
                            sku = sku,
                            Price = price,
                            uom = uom,
                            pack = pack,
                            pcat = pcat,
                            pcat1 = pcat1,
                            pcat2 = "",
                            country = "",
                            region = ""
                        };

                        list.Add(product);
                        list2.Add(item);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            #endregion
            #region old logic 
            //List<ProductModel> productList = (from p in list
            //                                  group p by new { p.sku, p.Price } into @group
            //                                  select @group.First()).ToList();
            //List<Fullname> productList2 = (from p in list2
            //                               group p by new { p.sku, p.Price } into @group
            //                               select @group.First()).ToList();
            #endregion
            #region new include 
            List<ProductModel> productList = list;
            List<Fullname> productList2 = list2;
            #endregion
            showstatus("Generating csv file");
            string text10 = GenerateCSV.GenerateCSVproductt(productList);
            string text11 = GenerateCSV.GenerateCSVfull(productList2);
            showstatus(Convert.ToString(text10));
            showstatus(Convert.ToString(text11));
            showstatus("Uploading " + text11);
            showstatus("Uploading " + text10);
            Upload("Upload//" + text10);
            Upload("Upload//" + text11);
            showstatus("Upload completed");
            if (File.Exists("Upload//" + text11))
            {
                File.Delete("Upload//" + text11);
            }
            if (File.Exists("Upload//" + text10))
            {
                File.Delete("Upload//" + text10);
            }
            #endregion
            #region NCR
            //TimeElapsed = ClsSettings.UpTime * 60;
            //showstatus("Connecting to Database");
            //FileStream streamNCR = new FileStream("config\\cat.txt", FileMode.Open, FileAccess.Read);
            //string textNCR;
            //using (StreamReader streamReader = new StreamReader(streamNCR, Encoding.UTF8))
            //{
            //    textNCR = streamReader.ReadToEnd();
            //}
            //ClsCategories[] arrayNCR = JsonConvert.DeserializeObject<ClsCategories[]>(textNCR);
            //string text2NCR = "";
            //ClsCategories[] array2NCR = arrayNCR;
            //foreach (ClsCategories clsCategories in array2NCR)
            //{
            //    text2NCR = ((text2NCR.Length <= 0) ? (text2NCR + "'" + clsCategories.CategoryName + "'") : (text2NCR + ",'" + clsCategories.CategoryName + "'"));
            //}
            //if (text2NCR.Length > 0)
            //{
            //    text2NCR = " and I.CATEG_COD in (" + text2NCR + ")";
            //}
            //if (arrayNCR.ToList().Any((ClsCategories a) => a.CatId == "9999" && a.Select == 1))
            //{
            //    text2NCR += " OR I.CATEG_COD IS NULL";
            //}
            //string text3NCR = "";
            //if (setting.StockedItems == 1)
            //{
            //    text3NCR = "  And I.QTY_ON_HND > 0"; // For WSRM stores
            //    //text3 = "  And QTY > 0";   // For 12330 store
            //}
            //string text4NCR = Environment.MachineName.ToString();
            //string connectionStringNCR = setting.ConnectionString;
            //string storeIdNCR = setting.StoreId;
            //string fTPLocationNCR = setting.FTPLocation;
            //string ftpTaxNCR = setting.FtpTax;
            //#region WSRM stores Query
            //string query = "SELECT DISTINCT '" + storeIdNCR + "' AS StoreId, '#'+LTRIM(REPLACE(B.BARCOD, '/', '')) AS Upc, CAST(I.QTY_ON_HND AS INT) AS Qty, '#'+LTRIM(I.ITEM_NO) AS Sku,";
            //query += " ISNULL(I.STK_UNIT,'') AS DefaultUom,ISNULL(I.ALT_1_NUMER,0) as ALT_1_NUMER, ISNULL(I.ALT_1_UNIT,'') AS ALT_1_UNIT,ISNULL(I.ALT_3_NUMER,0) AS ALT_3_NUMER,ISNULL(I.ALT_3_UNIT,'') AS ALT_3_UNIT,";
            //query += " REPLACE(LTRIM(RTRIM(I.DESCR)), ',', ' ') AS StoreProductName,REPLACE(LTRIM(RTRIM(I.DESCR)), ',', ' ') AS StoreDescription,";
            //query = query + " ISNULL(I.PRC_1,0) AS Price1,ISNULL(I.ALT_1_PRC_1,0) as Price2,ISNULL(I.ALT_3_PRC_1,0) as Price3, '' AS Sprice, '' AS Start, '' AS [End], '" + ftpTaxNCR + "' AS Tax,";
            //query += " '' AS AltUpc1, '' AS AltUpc2, '' AS AltUpc3, '' AS AltUpc4, '' AS AltUpc5, ICC.DESCR as pcat, I.Subcat_Cod as pcat1, '' as pcat2, '' as region, '' as country ";
            //query += " FROM VI_IM_ITEM_WITH_INV I ";
            //query += " LEFT JOIN IM_BARCOD B ON B.ITEM_NO = I.ITEM_NO ";
            //query += " LEFT JOIN IM_CATEG_COD ICC ON I.CATEG_COD = ICC.CATEG_COD ";
            //query += " WHERE B.BARCOD != '' AND B.BARCOD IS NOT NULL ";
            //query += " AND I.Loc_ID = '" + fTPLocationNCR + "'" + text3NCR + text2NCR;
            #endregion

            #region Yankee's Stores
            ////string query = "SELECT DISTINCT '" + storeId + "' AS StoreId, '#'+LTRIM(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(UPC, '/', ''), ',', ''), '=', ''), '.', ''), '`', '')) AS Upc , CAST(QTY AS INT) AS Qty, '#'+LTRIM(ITEM_NO) AS Sku, ";
            ////query += " ISNULL(UNIT,'') AS pack, ISNULL(UNIT,'') AS uom, REPLACE(LTRIM(RTRIM(NAME)), ',', ' ') AS StoreProductName, REPLACE(LTRIM(RTRIM(NAME)), ',', ' ') AS StoreDescription, ";
            ////query += " ISNULL(PRICE,0) AS Price, 0 AS sprice, '' as startdate, '' as enddate, '" + ftpTax + "' AS Tax,  ";
            ////query += " '' AS altupc1, '' AS altupc2, '' AS altupc3, '' AS altupc4, '' AS altupc5, 0 as deposit ";
            ////query += " from USER_ITEMS_DOORDASH ";
            ////query += " WHERE UPC != '' AND UPC IS NOT NULL ";
            ////query += text3;

            ////string query3 = "SELECT REPLACE(LTRIM(RTRIM(NAME)), ',', ' ') AS pname, REPLACE(LTRIM(RTRIM(NAME)), ',', ' ') AS pdesc, ";
            ////query3 += "";
            ////string query2 = " SELECT DISTINCT '" + storeId + "' AS StoreId, '#'+LTRIM(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(UPC, '/', ''), ',', ''), '=', ''), '.', ''), '`', '')) AS Upc , CAST(QTY AS INT) AS Qty, '#'+LTRIM(ITEM_NO) AS Sku,";
            ////query2 += " ISNULL(UNIT,'') AS pack, REPLACE(LTRIM(RTRIM(NAME)), ',', ' ') AS StoreProductName,REPLACE(LTRIM(RTRIM(NAME)), ',', ' ') AS StoreDescription, ";
            ////query2 += "ISNULL(PRICE,0) AS Price, '' AS Sprice, '' as start, '' as end,'" + ftpTax + "' AS Tax ";
            ////query2 += " '' AS AltUpc1, '' AS AltUpc2, '' AS AltUpc3, '' AS AltUpc4, '' AS AltUpc5, '' as deposit ";
            ////query2 += " from USER_ITEMS_DOORDASH ";
            ////query2 += " WHERE UPC != '' AND UPC IS NOT NULL ";
            //#endregion
            //SqlConnection con;
            //con = new SqlConnection(setting.ConnectionString);
            //SqlCommand cmd = new SqlCommand(query, con);
            ////SqlCommand cmd1 = new SqlCommand(query2, con);
            //con.Open();
            //cmd.CommandTimeout = 0;
            ////cmd1.CommandTimeout = 0;
            //cmd.ExecuteNonQuery();
            //showstatus("Executed");
            ////cmd1.ExecuteNonQuery();

            //SqlDataAdapter adp = new SqlDataAdapter(cmd);
            ////SqlDataAdapter da = new SqlDataAdapter(cmd1);
            //DataTable dtresult = new DataTable();
            //DataTable dt = new DataTable();
            //adp.Fill(dtresult);
            ////da.Fill(dt);
            ////foreach (DataRow row in dtresult.Rows)
            ////{
            ////    row["pack"] = getpack(row["StoreProductName"].ToString());
            ////}
            //#region
            ////#region For 12330 store Query
            ////string text5 = "SELECT DISTINCT '" + storeId + "' AS StoreId, '#'+LTRIM(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(UPC, '/', ''), ',', ''), '=', ''), '.', ''), '`', '')) AS Upc , CAST(QTY AS INT) AS Qty, '#'+LTRIM(ITEM_NO) AS Sku,";
            ////text5 += " ISNULL(SIZE,'') AS DefaultUom,'' as ALT_1_NUMER, '' AS ALT_1_UNIT,'' AS ALT_3_NUMER,'' AS ALT_3_UNIT,";
            ////text5 += " REPLACE(LTRIM(RTRIM(NAME)), ',', ' ') AS StoreProductName,REPLACE(LTRIM(RTRIM(NAME)), ',', ' ') AS StoreDescription,";
            ////text5 = text5 + " ISNULL(PRICE,0) AS Price1,0 as Price2,0 as Price3, '' AS Sprice, '' AS Start, '' AS [End], '" + ftpTax + "' AS Tax,";
            ////text5 += " '' AS AltUpc1, '' AS AltUpc2, '' AS AltUpc3, '' AS AltUpc4, '' AS AltUpc5,''  as pcat,''  as pcat1, '' as pcat2, '' as region, '' as country ";
            ////text5 += " FROM USER_ITEMS_DOORDASH  ";
            //////text5 += " LEFT JOIN IM_BARCOD B ON B.ITEM_NO = I.ITEM_NO ";
            //////text5 += " LEFT JOIN IM_CATEG_COD ICC ON II.CATEG_COD = ICC.CATEG_COD ";
            ////text5 += " WHERE UPC != '' AND UPC IS NOT NULL ";
            ////#endregion
            //////text5 = text5 + " AND I.Loc_ID = '" + fTPLocation + "'" + text3 + text2;
            ////text5 = text5 +  text3;
            //////string text6 = "SELECT '#'+ITEM_NO as item_No, PRC_1 from IM_prc where Loc_id = '*' ";
            ////SqlConnection sqlConnection = new SqlConnection(setting.ConnectionString);
            ////SqlCommand sqlCommand = new SqlCommand(text5, sqlConnection);
            ////sqlConnection.Open();
            ////sqlCommand.CommandTimeout = 0;
            ////sqlCommand.ExecuteNonQuery();
            ////SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            ////DataTable dataTable = new DataTable();
            ////sqlDataAdapter.Fill(dataTable);
            ////DataTable dataTable2 = new DataTable();
            ////DataTable dataTable3 = new DataTable();
            ////List<ProductModel> list = new List<ProductModel>();
            ////List<Fullname> list2 = new List<Fullname>();
            ////foreach (DataRow row in dataTable.Rows)
            ////{
            ////    ProductModel productModel = new ProductModel();
            ////    Fullname fullname = new Fullname();
            ////    List<int> list3 = new List<int>();
            ////    List<string> list4 = new List<string>();
            ////    List<decimal> list5 = new List<decimal>();
            ////    try
            ////    {
            ////        int storeID = Convert.ToInt32(row["StoreId"]);
            ////        string upc = row["Upc"].ToString();
            ////        string sku = row["Sku"].ToString();
            ////        int num = Convert.ToInt32(row["Qty"]);
            ////        string text7 = row["Storeproductname"].ToString();
            ////        string text8 = row["Storeproductname"].ToString();
            ////        decimal num2 = Convert.ToDecimal(row["Price1"]);
            ////        decimal num3 = Convert.ToDecimal(row["Price2"]);
            ////        decimal num4 = Convert.ToDecimal(row["Price3"]);
            ////        int num5 = Convert.ToInt32(row["ALT_1_NUMER"]);
            ////        int num6 = Convert.ToInt32(row["ALT_3_NUMER"]);
            ////        string text9 = row["ALT_1_UNIT"].ToString();
            ////        string text10 = row["ALT_3_UNIT"].ToString();
            ////        string text11 = row["DefaultUom"].ToString();
            ////        string value = row["Tax"].ToString();
            ////        string pcat = row["pcat"].ToString();
            ////        string pcat2 = row["pcat1"].ToString();
            ////        if (num2 != 0m && num3 != 0m && num4 != 0m)
            ////        {
            ////            list5.Add(Convert.ToDecimal(row["Price2"]));
            ////            list5.Add(Convert.ToDecimal(row["Price3"]));
            ////            if (num5 != 0)
            ////            {
            ////                list3.Add(Convert.ToInt32(num5));
            ////            }
            ////            if (num6 != 0)
            ////            {
            ////                list3.Add(Convert.ToInt32(num6));
            ////            }
            ////            if (text9 != "")
            ////            {
            ////                list4.Add(text9.ToString());
            ////            }
            ////            if (text10 != "")
            ////            {
            ////                list4.Add(text10.ToString());
            ////            }
            ////        }
            ////        if (num2 != 0m && num3 == 0m && num4 != 0m)
            ////        {
            ////            list5.Add(Convert.ToDecimal(row["Price3"]));
            ////            if (num6 != 0)
            ////            {
            ////                list3.Add(Convert.ToInt32(num6));
            ////            }
            ////            if (text10 != "")
            ////            {
            ////                list4.Add(text10.ToString());
            ////            }
            ////        }
            ////        if (num2 != 0m && num3 != 0m && num4 == 0m)
            ////        {
            ////            list5.Add(Convert.ToDecimal(row["Price2"]));
            ////            if (num5 != 0)
            ////            {
            ////                list3.Add(Convert.ToInt32(num5));
            ////            }
            ////            if (text9 != "")
            ////            {
            ////                list4.Add(text9.ToString());
            ////            }
            ////        }
            ////        if (num2 != 0m && num3 == 0m && num4 == 0m)
            ////        {
            ////            list5.Add(Convert.ToDecimal(row["Price1"]));
            ////            list3.Add(1);
            ////            if (text11 != "")
            ////            {
            ////                list4.Add(text11.ToString());
            ////            }
            ////        }
            ////        for (int j = 0; j < list5.Count; j++)
            ////        {
            ////            int num7 = Convert.ToInt32(num / list3[j]);
            ////            if (upc.Length > 5)
            ////            {
            ////                ProductModel productModel2 = new ProductModel
            ////                {
            ////                    StoreID = storeID,
            ////                    upc = upc,
            ////                    sku = sku,
            ////                    pack = ((j >= list3.Count) ? 1 : list3[j]),
            ////                    uom = ((j < list4.Count) ? list4[j] : text11),
            ////                    Qty = num7,
            ////                    StoreProductName = text7,
            ////                    StoreDescription = text7,
            ////                    Price = list5[j],
            ////                    sprice = 0m,
            ////                    Start = "",
            ////                    End = "",
            ////                    Tax = Convert.ToDecimal(value),
            ////                    altupc1 = "",
            ////                    altupc2 = "",
            ////                    altupc3 = "",
            ////                    altupc4 = "",
            ////                    altupc5 = ""
            ////                };
            ////                Fullname item = new Fullname
            ////                {
            ////                    pname = text7,
            ////                    pdesc = text7,
            ////                    upc = upc,
            ////                    sku = sku,
            ////                    Price = productModel2.Price,
            ////                    uom = productModel2.uom,
            ////                    pack = productModel2.pack,
            ////                    pcat = pcat,
            ////                    pcat1 = pcat2,
            ////                    pcat2 = "",
            ////                    country = "",
            ////                    region = ""
            ////                };
            ////                if (productModel2.Price > 0m && productModel2.uom != "EACH-EX" && productModel2.uom != "4-6 PACK-EX" && productModel2.uom != "2-12 PACK-EX")
            ////                {
            ////                    list.Add(productModel2);
            ////                    list2.Add(item);
            ////                }
            ////            }
            ////        }
            ////    }
            ////    catch (Exception ex)
            ////    {
            ////        Console.WriteLine(ex.Message);
            ////    }
            ////}
            ////List<ProductModel> productList = (from p in list
            ////                                  group p by new { p.sku, p.Price } into @group
            ////                                  select @group.First()).ToList();
            ////List<Fullname> productList2 = (from p in list2
            ////                               group p by new { p.sku, p.Price } into @group
            ////                               select @group.First()).ToList();
            ////string text12 = GenerateCSV.GenerateCSVproductt(productList);
            ////string text13 = GenerateCSV.GenerateCSVfull(productList2);
            //#endregion
            //showstatus("Generating csv file");
            //string text12 = GenerateCSV.GenerateCSV1(dtresult);
            ////string text13 = GenerateCSV.GenerateCSV2(dt);
            //showstatus(Convert.ToString(text12));
            ////showstatus(Convert.ToString(text13));
            ////showstatus("Uploading " + text13);
            //showstatus("Uploading " + text12);
            //Upload("Upload//" + text12);
            ////Upload("Upload//" + text13);
            //showstatus("Upload completed");
            ////if (File.Exists("Upload//" + text13))
            ////{
            ////    File.Delete("Upload//" + text13);
            ////}
            //if (File.Exists("Upload//" + text12))
            //{
            //    File.Delete("Upload//" + text12);
            //}
            #endregion
        }
        private string Upload(string filename)
        {
            EncryptDecrypt ed = new EncryptDecrypt();
            string ftpServerIp = setting.FTPServer;
            string ftpUserName = setting.FTPUserName;
            string ftpPassword = ed.Decrypt(setting.FTPPwd, "ASI");
            FileInfo file = new FileInfo(filename);

            // Check if file exists
            if (!file.Exists)
            {
                MessageBox.Show("File not found: " + filename);
                return "Failed";
            }

            // Ensure correct FTP URL format
            Uri ftpUri;
            try
            {
                ftpUri = new Uri($"ftp://{ftpServerIp}/{setting.FTPUpFolder}/{file.Name}");
            }
            catch (UriFormatException ex)
            {
                MessageBox.Show("Invalid FTP URL format: " + ex.Message);
                return "Failed";
            }

            FtpWebRequest reqFTP;
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(ftpUri);

            // Provide the WebPermission Credentials
            reqFTP.Credentials = new NetworkCredential(ftpUserName, ftpPassword);

            // By default KeepAlive is true, where the control connection is not closed after a command is executed.
            reqFTP.KeepAlive = false;

            // Specify the command to be executed.
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;

            // Specify the data transfer type.
            reqFTP.UseBinary = true;

            // Notify the server about the size of the uploaded file
            reqFTP.ContentLength = file.Length;

            // The buffer size is set to 2kb
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;

            // Opens a file stream (System.IO.FileStream) to read the file to be uploaded
            FileStream fs = file.OpenRead();
            try
            {
                // Stream to which the file to be uploaded is written
                Stream strm = reqFTP.GetRequestStream();

                // Read from the file stream 2kb at a time
                contentLen = fs.Read(buff, 0, buffLength);

                // While there is still data to read, upload it
                while (contentLen != 0)
                {
                    // Write content from the file stream to the FTP upload stream
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }

                // Close the file stream and the Request Stream
                strm.Close();
                fs.Close();

                showstatus("Upload " + filename + " completed.");
                return "SUCCESS";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error uploading file: " + ex.Message, "Upload Error");
            }
            return "Failed";
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            FormSetting fs = new FormSetting();
            fs.ShowDialog();
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Current = Cursors.Default;
        }
        public int getpack(string prodName)
        {
            prodName = prodName.ToUpper();
            var regexMatch = Regex.Match(prodName, @"((?<Result>\d+)PK| (?<Result>\d+)\sPACK)");
            var prodPack = regexMatch.Groups["Result"].Value;
            if (prodPack.Length > 0)
            {
                int outVal = 0;
                int.TryParse(prodPack.Replace("$", ""), out outVal);
                return outVal;
            }
            return 1;
        }
        public string getVolume(string prodName)
        {
            prodName = prodName.ToUpper();
            var regexMatch = Regex.Match(prodName, @"(?<Result>\d+)ML| (?<Result>\d+)LTR| (?<Result>\d+)OZ | (?<Result>\d+)L|(?<Result>\d+)OZ");
            var prodPack = regexMatch.Groups["Result"].Value;
            if (prodPack.Length > 0)
            {
                return regexMatch.ToString();
            }
            return "";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
