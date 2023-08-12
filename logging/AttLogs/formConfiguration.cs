using FileMdb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace AttLogs
{
    public partial class formConfiguration : Form
    {
        public formConfiguration()
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

            this.textBox1.Text = fpid;
            this.textBox3.Text = port;
            this.textBox4.Text = mac;
            this.textBox2.Text = ip;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.saveConfiguration();
        }

        private void saveConfiguration()
        {
            var ini = new IniFile();
            ini.Load("config.ini");

            ini["WORKSTATION"]["IP"] = this.textBox2.Text;
            ini["WORKSTATION"]["PORT"] = this.textBox3.Text;
            ini["WORKSTATION"]["MAC"] = this.textBox4.Text;
            ini["WORKSTATION"]["FPID"] = this.textBox1.Text;
            ini.Save("config.ini");

        }

        static HttpClient client = new HttpClient();


        private async Task getDevice()

        {
            try
            {
                var ini = new IniFile();
                ini.Load("config.ini");
                string baseUrl = ini["WORKSTATION"]["BASEURL"].ToString();

                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                Fp device = null;
                var utl = "api/FpDevices/" + this.textBox1.Text.Trim();
                HttpResponseMessage response = await client.GetAsync(utl);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    device = JsonConvert.DeserializeObject<Fp>(content);
                    this.textBox2.Text = device.ipAddress;
                    this.textBox3.Text = device.port;
                    this.textBox4.Text = device.mac;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
            }


        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await this.getDevice();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.TestConnectDevice();
        }

        public zkemkeeper.CZKEMClass axCZKEM1 = new zkemkeeper.CZKEMClass();

        private void TestConnectDevice()
        {

            var ini = new IniFile();
            ini.Load("config.ini");

            string ip = ini["WORKSTATION"]["IP"].ToString();
            string port = ini["WORKSTATION"]["PORT"].ToString();
            string mac = ini["WORKSTATION"]["MAC"].ToString();
            string fpid = ini["WORKSTATION"]["FPID"].ToString();

            int idwErrorCode = 0;

            Cursor = Cursors.WaitCursor;


            bool bIsConnected = axCZKEM1.Connect_Net(ip, Convert.ToInt32(port));
            int iMachineNumber = 1;
            Console.WriteLine(bIsConnected);
            if (bIsConnected)
            {

                iMachineNumber = 1;//In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
                axCZKEM1.RegEvent(iMachineNumber, 65535);//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)

                MessageBox.Show("ສາມາດເຊື່ອມຕໍ່ອຸປະກອນໄດ້");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Unable to connect the device,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }
    }
}
