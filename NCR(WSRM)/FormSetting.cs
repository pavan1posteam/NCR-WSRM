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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NCR_WSRM_
{
    public partial class FormSetting : Form
    {
        SqlConnection cn = null;
        SqlDataAdapter da = null;
        DataTable dt = null;
        SqlCommand cmd = null;
        ClsSettings setting = new ClsSettings();
        DataTable dtCat;
        public FormSetting()
        {
            InitializeComponent();
        }
        private void FormSetting_Load(object sender, EventArgs e)
        {
            AddHeaderCheckBox();
            HeaderCheckBox.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);

            if (File.Exists("config\\dbsettings.txt") && File.Exists("config\\ftpsettings.txt"))
            {
                setting.LoadSettings();

                txtDBServer.Text = setting.DbServer;
                txtUserName.Text = setting.DbUserName;
                txtPassword.Text = setting.DbPassword;
                txtDatabase.Text = setting.DbDatabase;
                checkBox1.Checked = setting.DbIntegratedSecurity;

                EncryptDecrypt ED = new EncryptDecrypt();
                txtStoreId.Text = setting.StoreId == null ? "0" : setting.StoreId;
                txtFtpPwd.Text = setting.FTPPwd == null ? "" : ED.Decrypt(setting.FTPPwd, "ASI");
                txtServer.Text = setting.FTPServer;
                txtFtpUserName.Text = setting.FTPUserName;
                txtUpFolder.Text = setting.FTPUpFolder;
                txtFtpLocation.Text = setting.FTPLocation;
                txtTax.Text = setting.FtpTax;

                //if (ClsSettings.UpTime == 0)
                //{
                //    txtUploadTimer.Value = 10m;
                //}
                //else
                //{
                //    txtUploadTimer.Value = ClsSettings.UpTime;
                //}
                if (setting.StockedItems == 0)
                {
                    chkStocked.Checked = false;
                }
                else
                {
                    chkStocked.Checked = true;
                }
            }


            if (File.Exists("config\\cat.txt"))
            {
                LoadCategory();
            }
        }
        private void btnDbSave_Click_1(object sender, EventArgs e)
        {
            bool val = false;
            if (checkBox1.Checked)
            {
                if (txtDBServer.Text.Trim().Length == 0 || txtDatabase.Text.Trim().Length == 0)
                {
                    MessageBox.Show("All Fields Are Mandatory!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    val = true;
                }
            }
            else
            {
                if (txtDBServer.Text.Trim().Length == 0 || txtUserName.Text.Trim().Length == 0 || txtPassword.Text.Trim().Length == 0 || txtDatabase.Text.Trim().Length == 0)
                {
                    MessageBox.Show("All Fields Are Mandatory!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (!val)
            {
                ClsDbSettings clsdb = new ClsDbSettings();
                clsdb.Server = txtDBServer.Text;
                clsdb.UserName = txtUserName.Text;
                clsdb.Password = txtPassword.Text;
                clsdb.Database = txtDatabase.Text;
                clsdb.IntegratedSecurity = checkBox1.Checked;

                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(@"config\dbsettings.txt"))
                using (JsonTextWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, clsdb);
                    sw.Close();
                    writer.Close();
                }
            }

            setting.LoadSettings();
            lblDbStatus.Text = "Saved Successfully";
        }

        private void btnFTPSave_Click(object sender, EventArgs e)
        {
            if (txtStoreId.Text.Trim().Length == 0 || txtServer.Text.Trim().Length == 0 || txtFtpUserName.Text.Trim().Length == 0 || this.txtFtpPwd.Text.Trim().Length == 0 || txtUpFolder.Text.Trim().Length == 0)
            {
                MessageBox.Show("All fields Are Mandatory !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                EncryptDecrypt ed = new EncryptDecrypt();
                ClsFTPSettings ftpsetting = new ClsFTPSettings();
                ftpsetting.StoreID = txtStoreId.Text;
                ftpsetting.FtpServer = txtServer.Text;
                ftpsetting.FtpUserName = txtFtpUserName.Text;
                ftpsetting.FtpPassword = ed.Encrypt(txtFtpPwd.Text, "ASI");
                ftpsetting.UpFolder = txtUpFolder.Text;
                ftpsetting.FtpLocation = txtFtpLocation.Text;
                ftpsetting.StockedItems = (int)chkStocked.CheckState;
                //ftpsetting.UpTime = (int)txtUploadTimer.Value;
                ftpsetting.FtpTax = txtTax.Text;

                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(@"config\ftpsettings.txt"))
                using (JsonTextWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, ftpsetting);
                    sw.Close();
                    writer.Close();
                }
            }
            ClsSettings setting = new ClsSettings();
            setting.LoadSettings();
            lblFtpStatus.Text = "Saved Successfully!!";
        }

        private void btnCatSave_Click(object sender, EventArgs e)
        {
            dt = ((DataView)dataGridView1.DataSource).ToTable();
            if (dt != null)
            {
                var query = from r in dt.AsEnumerable()
                            where (r.Field<Int32>("Select") == 1)
                            select new
                            {
                                Select = r["Select"],
                                CatID = r["CatId"],
                                CategoryName = r["Description"]
                            };
                if (query.Count() == 0)
                {
                    MessageBox.Show("Select Category", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    JsonSerializer serializer = new JsonSerializer();
                    using (StreamWriter sw = new StreamWriter(@"config\cat.txt"))
                    using (JsonTextWriter writer = new JsonTextWriter(sw))
                    {
                        serializer.Serialize(writer, query);
                        sw.Close();
                        writer.Close();
                    }
                }
                lblCatStatus.Text = "Saved Successfully!";
            }
        }
        CheckBox HeaderCheckBox = null;
        bool IsHeaderCheckBoxClicked = false;
        private void AddHeaderCheckBox()
        {
            HeaderCheckBox = new CheckBox();
            HeaderCheckBox.Size = new Size(15, 15);
            // Add checkBox into the GridView
            this.dataGridView1.Controls.Add(HeaderCheckBox);
        }
        private void HeaderCheckBoxClick(CheckBox HCheckBox)
        {
            IsHeaderCheckBoxClicked = true;
            foreach (DataGridViewRow dgvr in dataGridView1.Rows)
            {
                ((DataGridViewCheckBoxCell)dgvr.Cells["Select"]).Value = HCheckBox.Checked;
                dataGridView1.RefreshEdit();
                IsHeaderCheckBoxClicked = false;
            }
        }
        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender);
        }

        private void LoadCategory()
        {
            FileStream stream = new FileStream("config\\cat.txt", FileMode.Open, FileAccess.Read);
            string text;
            using (StreamReader streamReader = new StreamReader(stream, Encoding.UTF8))
            {
                text = streamReader.ReadToEnd();
            }
            ClsCategories[] array = JsonConvert.DeserializeObject<ClsCategories[]>(text);
            try
            {
                dt = new DataTable();
                dataGridView1.AutoGenerateColumns = false;
                string text2 = Environment.MachineName.ToString();
                ClsSettings clsSettings = new ClsSettings();
                string connectionString = clsSettings.ConnectionString;
                cn = new SqlConnection(connectionString);
                cmd = new SqlCommand(" Select Distinct 0 as [Select], CATEG_COD AS CatId,  DESCR  AS Description from IM_CATEG_COD ", cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                cn.Close();
                if (array != null)
                {
                    ClsCategories[] array2 = array;
                    foreach (ClsCategories clsCategories in array2)
                    {
                        DataRow dataRow = dt.Select("CatId='" + clsCategories.CatId.ToString() + "'").FirstOrDefault();
                        if (dataRow != null)
                        {
                            dataRow["Select"] = 1;
                        }
                    }
                }
                dataGridView1.ColumnCount = 3;
                dataGridView1.Columns[0].Name = "Select";
                dataGridView1.Columns[0].HeaderText = "Select";
                dataGridView1.Columns[0].DataPropertyName = "Select";
                dataGridView1.Columns[1].Name = "CatId";
                dataGridView1.Columns[1].HeaderText = "Category Id";
                dataGridView1.Columns[1].DataPropertyName = "CatId";
                dataGridView1.Columns[2].Name = "Description";
                dataGridView1.Columns[2].HeaderText = "Category Name";
                dataGridView1.Columns[2].DataPropertyName = "Description";
                dataGridView1.Columns[2].Width = 300;
                dataGridView1.DataSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUploadTimer_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
