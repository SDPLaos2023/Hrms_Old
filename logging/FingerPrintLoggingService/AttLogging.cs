using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
//using Newtonsoft.Json;
using System.Timers;

using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace FingerPrintLoggingService
{

    public class AttLogging
    {
        private readonly Timer _timer;
        private readonly ILog _logger = LogManager.GetLogger(typeof(AttLogging));

        public zkemkeeper.CZKEMClass axCZKEM1 = new zkemkeeper.CZKEMClass();
        private bool bIsConnected;
        private int iMachineNumber = 1;
        public AttLogging()
        {

            var ini = new IniFile();
            ini.Load("config.ini");
            var milisecond = ini["WORKSTATION"]["INTERVAL"].ToString();
            _logger.Info(milisecond);
            _timer = new Timer(int.Parse(milisecond))
            {
                AutoReset = true
            };

            _timer.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            _logger.Info("TimerElapsed");
            var isConnected = this.connectDevice();
            if (isConnected)
            {
                var logs = this.DownloadLog();
                _logger.Info("Data from download " + JsonConvert.SerializeObject(logs));
                this.UploadData(logs);
            }

            _logger.Info("Now : " + DateTime.Now.ToLongDateString());

        }

        private void UploadData(DataTable logs)
        {
            _logger.Info("Uploading Data at : " + DateTime.Now.ToLongDateString());

            var att = new List<Attlog>();
            var ini = new IniFile();
            ini.Load("config.ini");
            string fpid = ini["WORKSTATION"]["FPID"].ToString();
            var isActualDate = ini["WORKSTATION"]["ACTUALDATE"].ToString();
            var bday = ini["WORKSTATION"]["BACKDATE"].ToString();
            if (isActualDate.Equals("1"))
            {
                _logger.Info(string.Format("Data on actual date and backdate {0} day(s)", int.Parse(bday) * -1));

                var today = DateTime.Now.Date;
                var yesterday = DateTime.Now.AddDays(int.Parse(bday));

                var dv = logs.DefaultView;
                dv.RowFilter = string.Format("col_date>=#{0}# and col_date <=#{1}#",
                    yesterday.ToString("yyyy/MM/dd 00:00"), today.ToString("yyyy/MM/dd 23:59:00"));
                _logger.Debug("dv " + JsonConvert.SerializeObject(dv.ToTable()));
                var tbLogs = dv.ToTable();
                _logger.Debug("tbLogs " + JsonConvert.SerializeObject(tbLogs));
                _logger.Debug("count " + tbLogs.Rows.Count);

                //if (dv.Count <= 0)
                //{
                //    _logger.Info("No Data To Upload");
                //    return;
                //}

                foreach (DataRow item in tbLogs.Rows)
                {
                    var attDate = DateTime.Parse(item["col_date"].ToString());
                    var attTime = DateTime.Parse(item["col_date"].ToString());// DateTime.Parse();
                    var attLog = new Attlog
                    {
                        FpId = fpid,
                        FpUserId = item["col_fp_user_id"].ToString(),
                        AttCode = item["col_code"].ToString(),
                        AttDate = attDate.Date,
                        AttTime = attTime.TimeOfDay
                    };
                    att.Add(attLog);

                }
                _logger.Debug("row to upload " + JsonConvert.SerializeObject(att));

            }
            else
            {
                _logger.Info("Data on all date");

                foreach (DataRow item in logs.Rows)
                {
                    var attDate = DateTime.Parse(item["col_date"].ToString());
                    var attTime = DateTime.Parse(item["col_date"].ToString());
                    var attLog = new Attlog
                    {
                        FpId = fpid,
                        FpUserId = item["col_fp_user_id"].ToString(),
                        AttCode = item["col_code"].ToString(),
                        AttDate = attDate,
                        AttTime = attTime.TimeOfDay
                    };
                    att.Add(attLog);
                }
                _logger.Debug("row to upload " + JsonConvert.SerializeObject(att));

            }

            _logger.Info(string.Format("Data A1 {0} Counting : {1}", DateTime.Now, att.Count));
            try
            {
                _logger.Info("Sending data at : " + DateTime.Now.ToLongDateString());

                string baseUrl = ini["WORKSTATION"]["BASEURL"].ToString();
                var url = string.Format("{0}{1}", baseUrl, "api/Timesheets/upload");
                _logger.Info("url: " + url);

                //var t = new Attlog
                //{
                //    FpId = fpid,
                //    FpUserId = "0000",
                //    AttCode = "0",
                //    AttDate = DateTime.Now.Date,
                //    AttTime = DateTime.Now.TimeOfDay
                //};
                //att.Add(t);

                StringContent content = new StringContent(JsonConvert.SerializeObject(att), Encoding.UTF8, "application/json");
                //var resp = 
                this.ServiceClient(url, content);
                //Console.WriteLine(resp);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _logger.Error("Exception as : " + ex.Message);
            }
        }

        private void ServiceClient(string url, StringContent content)
        {

            try
            {
                using (var client = new HttpClient())
                {
                    var ini = new IniFile();
                    ini.Load("config.ini");
                    string baseUrl = ini["WORKSTATION"]["BASEURL"].ToString();
                    client.BaseAddress = new Uri(baseUrl);
                    var fullUrl = string.Format("{0}{1}", baseUrl, "api/Timesheets/upload");

                    using (var resp = client.PostAsync(fullUrl, content))
                    {
                        System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                        var result = resp.Result;
                        var rs = result.Content.ReadAsStringAsync().Result;
                        _logger.Info("response : " + rs);

                        if (!result.IsSuccessStatusCode)
                        {
                            _logger.Error(string.Format("{0} ({1})", (int)result.StatusCode, result.ReasonPhrase));
                            Console.WriteLine("{0} ({1})", (int)result.StatusCode, result.ReasonPhrase);
                        }
                    }



                    //"api/Timesheets/upload"
                    //using (var response = client.PostAsync(url, content))
                    //{
                    //    var result = response.Result;
                    //    return result.Content.ReadAsStringAsync().Result;
                    //}

                    //HttpResponseMessage response = client.PostAsync("api/Timesheets/upload", content).Result;
                    //var dto = "";
                    //if (response.IsSuccessStatusCode)
                    //{
                    //    dto = response.Content.ReadAsStringAsync().Result;
                    //    _logger.Info(">>" + dto);
                    //}
                    //else
                    //{
                    //    _logger.Error(string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase));
                    //    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    //}
                    //return dto;

                }
            }
            catch (AggregateException err)
            {
                foreach (var errInner in err.InnerExceptions)
                {
                    _logger.Error(errInner); //this will call ToString() on the inner execption and get you message, stacktrace and you could perhaps drill down further into the inner exception of it if necessary 
                }
                //return null;
            }
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    _logger.Error("Exception as : " + ex.Message);
            //    return null;
            //}

        }


        private DataTable DownloadLog()
        {
            //File.AppendAllLines(@"\var\log.txt", new string[] { "downloadLog" });
            _logger.Info("Downloading");
            //int idwTMachineNumber = 0;
            string idwEnrollNumber = "";
            //int idwEMachineNumber = 0;
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


            DataTable table = new DataTable();
            table.Columns.Add("col_id");
            table.Columns.Add("col_fp_id");
            table.Columns.Add("col_fp_user_id");
            table.Columns.Add("col_date");
            table.Columns.Add("col_time");
            table.Columns.Add("col_code");

            //var row = table.NewRow();
            //row["col_id"] = iGLCount;
            //row["col_fp_id"] = iMachineNumber;
            //row["col_fp_user_id"] = "1901241";//idwEnrollNumber;
            //row["col_date"] =DateTime.Parse(DateTime.Now.AddHours(2).ToString("yyyy/MM/dd 00:00"));
            //row["col_time"] = DateTime.Now.TimeOfDay;
            //row["col_code"] = 0;

            //table.Rows.InsertAt(row, 0);
            //row = table.NewRow();
            //row["col_id"] = iGLCount;
            //row["col_fp_id"] = iMachineNumber;
            //row["col_fp_user_id"] = "1901241";//idwEnrollNumber;
            //row["col_date"] = DateTime.Parse(DateTime.Now.Date.AddDays(-1).Date.ToString("yyyy/MM/dd 00:00"));
            //row["col_time"] = DateTime.Now.AddHours(2).TimeOfDay;
            //row["col_code"] = 0;

            //table.Rows.InsertAt(row, 1);

            //row = table.NewRow();
            //row["col_id"] = iGLCount;
            //row["col_fp_id"] = iMachineNumber;
            //row["col_fp_user_id"] = "1901241";// idwEnrollNumber;
            //row["col_date"] = DateTime.Parse(DateTime.Now.Date.AddDays(-2).Date.ToString("yyyy/MM/dd 00:00"));
            //row["col_time"] = DateTime.Now.AddHours(2).TimeOfDay;
            //row["col_code"] = 0;

            //table.Rows.InsertAt(row, 2);



            //return table;

            Console.WriteLine(iMachineNumber);
            var isEnabled = axCZKEM1.EnableDevice(iMachineNumber, false);//disable the device
            Console.WriteLine(isEnabled);
            Console.WriteLine(axCZKEM1.ReadGeneralLogData(iMachineNumber));

            if (axCZKEM1.ReadGeneralLogData(iMachineNumber))
            {

                //read all the attendance records to the memory
                _logger.Info("Reading all records");

                try
                {

                    while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out idwEnrollNumber, out idwVerifyMode, out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkCode))//get records from the memory
                    {
                        iGLCount++;
                        var date = new DateTime(idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond);
                        var time = date.ToString("t");
                        //Console.WriteLine(date);
                        //Console.WriteLine(time);

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

                    //return table;


                }
                catch (Exception ex)
                {
                    _logger.Error("Read Error");
                    _logger.Error(ex.Message);
                }

            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);

                if (idwErrorCode != 0)
                {
                    Console.WriteLine("Reading data from terminal failed,ErrorCode: " + idwErrorCode.ToString(), "Error");

                    _logger.Error("Reading data from terminal failed,ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    Console.WriteLine("No data from terminal returns!", "Error");
                    _logger.Warn("No data from terminal returns!");
                }
            }
            axCZKEM1.EnableDevice(iMachineNumber, true);//enable the device
            return table;
        }

        private bool connectDevice()
        {

            _logger.Info("start connect deviec");

            int idwErrorCode = 0;

            var ini = new IniFile();
            ini.Load("config.ini");

            var ip = ini["WORKSTATION"]["IP"].ToString();
            var port = ini["WORKSTATION"]["PORT"].ToString();

            _logger.Info("connecting deviec");

            bIsConnected = axCZKEM1.Connect_Net(ip, Convert.ToInt32(port));
            axCZKEM1.EnableDevice(iMachineNumber, true);//enable the device
            Console.WriteLine(bIsConnected);
            if (bIsConnected)
            {
                _logger.Info("connected");

                iMachineNumber = 1;//In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
                axCZKEM1.RegEvent(iMachineNumber, 65535);
                //Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)

                //axCZKEM1.Disconnect();

                return true;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                Console.WriteLine("Error Can't Get Device");
                _logger.Error("Error Can't Get Device");
            }
            return false;
        }

        public void Start()
        {
            _timer.Start();
            _logger.Info("timer start : " + DateTime.Now.ToLongDateString());

        }

        public void Stop()
        {
            _timer.Stop();
            _logger.Info("timer stop : " + DateTime.Now.ToLongDateString());
        }
    }
}
