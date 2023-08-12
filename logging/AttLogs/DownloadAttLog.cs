using FileMdb;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace AttLogs
{
    public partial class DownloadAttLog : Form
    {
        public zkemkeeper.CZKEMClass axCZKEM1 = new zkemkeeper.CZKEMClass();
        private bool bIsConnected;
        private int iMachineNumber = 1;

        public DownloadAttLog()
        {
            InitializeComponent();
            this.LoadConfiguration();
        }

        private void LoadConfiguration()
        {
            var ini = new IniFile();
            ini.Load("config.ini");

            string ip = ini["WORKSTATION"]["IP"].ToString();
            string port = ini["WORKSTATION"]["PORT"].ToString();
            string mac = ini["WORKSTATION"]["MAC"].ToString();
            string fpid = ini["WORKSTATION"]["FPID"].ToString();

            this.textBox1.Text = ip;
            this.textBox2.Text = port;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }

            int idwTMachineNumber = 0;
            string idwEnrollNumber = "";
            int idwEMachineNumber = 0;
            int idwVerifyMode = 0;
            int idwInOutMode = 0;
            int idwYear = 0;
            int idwMonth = 0;
            int idwDay = 0;
            int idwHour = 0;
            int idwMinute = 0;
            int idwSecond = 0;
            int idwWorkCode = 0;

            int idwErrorCode = 0;
            int iGLCount = 0;
            int iIndex = 0;

            Cursor = Cursors.WaitCursor;
            Console.WriteLine(iMachineNumber);
            var isEnabled = axCZKEM1.EnableDevice(iMachineNumber, false);//disable the device
            Console.WriteLine(isEnabled);
            //Console.WriteLine(axCZKEM1.ReadGeneralLogData(iMachineNumber));


            DataTable table = new DataTable();
            table.Columns.Add("col_id");
            table.Columns.Add("col_fp_id");
            table.Columns.Add("col_fp_user_id");
            table.Columns.Add("col_date");
            table.Columns.Add("col_time");
            table.Columns.Add("col_code");
            //Console.WriteLine("Create table");





            //var row = table.NewRow();
            //row["col_id"] = 1;
            //row["col_fp_id"] = 1;
            //row["col_fp_user_id"] = "1901241";//idwEnrollNumber;
            //row["col_date"] = DateTime.Parse(DateTime.Now.AddHours(2).ToString("yyyy/MM/dd 00:00"));
            //row["col_time"] = DateTime.Now.TimeOfDay;
            //row["col_code"] = 0;

            //table.Rows.InsertAt(row, 0);
            //Console.WriteLine("row 1");

            //row = table.NewRow();
            //row["col_id"] = 2;
            //row["col_fp_id"] = 1;
            //row["col_fp_user_id"] = "1901241";//idwEnrollNumber;
            //row["col_date"] = DateTime.Parse(DateTime.Now.Date.AddDays(-1).Date.ToString("yyyy/MM/dd 00:00"));
            //row["col_time"] = DateTime.Now.AddHours(2).TimeOfDay;
            //row["col_code"] = 0;

            //table.Rows.InsertAt(row, 1);
            //Console.WriteLine("row 2");


            //row = table.NewRow();
            //row["col_id"] = 3;
            //row["col_fp_id"] = 1;
            //row["col_fp_user_id"] = "1901241";// idwEnrollNumber;
            //row["col_date"] = DateTime.Parse(DateTime.Now.Date.AddDays(-2).Date.ToString("yyyy/MM/dd 00:00"));
            //row["col_time"] = DateTime.Now.AddHours(2).TimeOfDay;
            //row["col_code"] = 0;

            //table.Rows.InsertAt(row, 2);
            //Console.WriteLine("row 3");



            //var ini = new IniFile();
            //ini.Load("config.ini");
            //string fpid = ini["WORKSTATION"]["FPID"].ToString();
            //var isActualDate = ini["WORKSTATION"]["ACTUALDATE"].ToString();
            //var bday = ini["WORKSTATION"]["BACKDATE"].ToString();
            //if (this.checkBox1.Checked)
            //{

            //    var today = DateTime.Now.Date;
            //    var yesterday = DateTime.Now.AddDays(int.Parse(bday));


            //    var dv = table.DefaultView;
            //    dv.RowFilter = string.Format("col_date>=#{0}# and col_date <=#{1}#",
            //        yesterday.ToString("yyyy/MM/dd 00:00"), today.ToString("yyyy/MM/dd 23:59:00"));
            //    //.Debug("dv " + JsonConvert.SerializeObject(dv.ToTable()));
            //    var tbLogs = dv.ToTable();

            //    table = tbLogs;

            //}

            //dataGridView1.AutoGenerateColumns = false;

            //dataGridView1.DataSource = table;
            //Cursor = Cursors.Default;

            //return;


            if (axCZKEM1.ReadGeneralLogData(iMachineNumber))//read all the attendance records to the memory
            {

                while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out idwEnrollNumber, out idwVerifyMode, out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkCode))//get records from the memory
                {
                    iGLCount++;
                    var date = new DateTime(idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond);
                    var time = date.ToString("t");
                    Console.WriteLine(date);
                    Console.WriteLine(time);

                    var row = table.NewRow();
                    row["col_id"] = iGLCount;
                    row["col_fp_id"] = iMachineNumber;
                    row["col_fp_user_id"] = idwEnrollNumber;
                    row["col_date"] = date;
                    row["col_time"] = time;
                    row["col_code"] = idwInOutMode;

                    table.Rows.InsertAt(row, iIndex);

                    iIndex++;
                }

                var ini = new IniFile();
                ini.Load("config.ini");
                string fpid = ini["WORKSTATION"]["FPID"].ToString();
                var isActualDate = ini["WORKSTATION"]["ACTUALDATE"].ToString();
                var bday = ini["WORKSTATION"]["BACKDATE"].ToString();

                var today = DateTime.Now.Date;
                var yesterday = DateTime.Now.AddDays(int.Parse(bday));




                if (this.checkBox1.Checked)
                {

                    var dv = table.DefaultView;
                    dv.RowFilter = string.Format("col_date>=#{0}# and col_date <=#{1}#",
                        yesterday.ToString("yyyy/MM/dd 00:00"), today.ToString("yyyy/MM/dd 23:59:00"));
                    //.Debug("dv " + JsonConvert.SerializeObject(dv.ToTable()));
                    var tbLogs = dv.ToTable();


                    table = tbLogs;
                }


                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = table;

            }
            else
            {
                Cursor = Cursors.Default;
                axCZKEM1.GetLastError(ref idwErrorCode);

                if (idwErrorCode != 0)
                {
                    MessageBox.Show("Reading data from terminal failed,ErrorCode: " + idwErrorCode.ToString(), "Error");
                }
                else
                {
                    MessageBox.Show("No data from terminal returns!", "Error");
                }
            }



            //while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out idwEnrollNumber, out idwVerifyMode, out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkCode))//get records from the memory
            //{
            //    iGLCount++;
            //    var date = new DateTime(idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond);
            //    var time = date.ToString("t");
            //    Console.WriteLine(date);
            //    Console.WriteLine(time);

            //    var row = table.NewRow();
            //    row["col_id"] = iGLCount;
            //    row["col_fp_id"] = iMachineNumber;
            //    row["col_fp_user_id"] = idwEnrollNumber;
            //    row["col_date"] = date;
            //    row["col_time"] = time;
            //    row["col_code"] = idwInOutMode;

            //    table.Rows.InsertAt(row, iIndex);

            //    iIndex++;
            //}
            //dataGridView1.DataSource = table;



            axCZKEM1.EnableDevice(iMachineNumber, true);//enable the device
            Cursor = Cursors.Default;
        }
        static HttpClient client = new HttpClient();

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
            {
                MessageBox.Show("IP and Port cannot be null", "Error");
                return;
            }
            int idwErrorCode = 0;

            Cursor = Cursors.WaitCursor;
            if (btnConnect.Text == "Connected")
            {
                axCZKEM1.Disconnect();
                bIsConnected = false;
                btnConnect.Text = "Connect";
                label3.Text = "State : Connect";
                Cursor = Cursors.Default;
                return;
            }

            var ini = new IniFile();
            ini.Load("config.ini");

            string ip = ini["WORKSTATION"]["IP"].ToString();
            string port = ini["WORKSTATION"]["PORT"].ToString();

            bIsConnected = axCZKEM1.Connect_Net(ip, Convert.ToInt32(port));
            Console.WriteLine(bIsConnected);
            if (bIsConnected)
            {
                btnConnect.Text = "Connected";
                btnConnect.Refresh();
                label3.Text = "State: Connected";
                iMachineNumber = 1;//In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
                axCZKEM1.RegEvent(iMachineNumber, 65535);//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)

            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Unable to connect the device,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            var att = new List<Attlog>();
            var ini = new IniFile();
            ini.Load("config.ini");
            string fpid = ini["WORKSTATION"]["FPID"].ToString();

            if (this.checkBox1.Checked)
            {
                Console.WriteLine("actual date");

                var today = DateTime.Now.Date;
                foreach (DataGridViewRow item in this.dataGridView1.Rows)
                {
                    var attDate = DateTime.Parse(item.Cells["col_date"].Value.ToString());
                    var attTime = DateTime.Parse(item.Cells["col_date"].Value.ToString());
                    Console.WriteLine("date fp: " + attDate.Date + " today:" + today);
                    Console.WriteLine("the same date: " + attDate.Date + " today:" + today);
                    //int res = DateTime.Compare(d1, d2);
                    Console.WriteLine(attDate.Date);
                    var attLog = new Attlog
                    {
                        FpId = fpid,
                        FpUserId = item.Cells["col_fp_user_id"].Value.ToString(),
                        AttCode = item.Cells["col_code"].Value.ToString(),
                        AttDate = attDate,
                        AttTime = attTime.TimeOfDay
                    };
                    att.Add(attLog);

                    //if (DateTime.Compare(attDate.Date,today.Date) ==0)
                    //{


                    //}
                }
                Console.WriteLine(att.Count);

            }
            else
            {

                foreach (DataGridViewRow item in this.dataGridView1.Rows)
                {
                    var attDate = DateTime.Parse(item.Cells["col_date"].Value.ToString());
                    var attTime = DateTime.Parse(item.Cells["col_date"].Value.ToString());

                    Console.WriteLine(attDate.Date);
                    var attLog = new Attlog
                    {
                        FpId = fpid,
                        FpUserId = item.Cells["col_fp_user_id"].Value.ToString(),
                        AttCode = item.Cells["col_code"].Value.ToString(),
                        AttDate = attDate,
                        AttTime = attTime.TimeOfDay
                    };
                    att.Add(attLog);
                }
                Console.WriteLine(att.Count);

            }

            try
            {

                //var t = new Attlog {
                //    FpId = fpid,
                //    FpUserId = "0000",
                //    AttCode ="0",
                //    AttDate =DateTime.Now.Date,
                //    AttTime = DateTime.Now.TimeOfDay
                //};
                //att.Add(t);



                string baseUrl = ini["WORKSTATION"]["BASEURL"].ToString();
                var url = string.Format("{0}{1}", baseUrl, "api/Timesheets/upload");
                StringContent content = new StringContent(JsonConvert.SerializeObject(att), Encoding.UTF8, "application/json");
                var resp = this.ServiceClient(url, content);
                Console.WriteLine(resp);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
            }
            Cursor = Cursors.Default;

        }

        private string ServiceClient(string url, StringContent content)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    using (var response = client.PostAsync(url, content))
                    {
                        var result = response.Result;
                        return result.Content.ReadAsStringAsync().Result;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
