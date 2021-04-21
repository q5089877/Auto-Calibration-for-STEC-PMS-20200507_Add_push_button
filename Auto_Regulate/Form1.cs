using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Collections;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace Auto_Calibration
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        #region Variable

        static string _p_u = "p u \n\r";
        static string _p_d = "p d \n\r";

        int equal_0 = 0, equal_1 = 0, equal_2 = 0, equal_3 = 0, equal_4 = 0, equal_5 = 0, equal_6 = 0, equal_7 = 0;

        // string[] PMS_data = new string[10];
        int equal_8, equal_9; // record "=" appear count 
        //int _appear = 0;
        int Counter_pl6_pl7 = 0;
        string str_RS232_receiver = "";
        string model = "";
        string PMS_record_file_name;

        Boolean has_send_nurse_right = false;
        Boolean receive_232 = false;
        Boolean Send_ph1_ph7 = true;
        Boolean Send_g_8 = true;
        Boolean Send_g_9 = true;
        Boolean Calibration_0_7_OK = false;
        Boolean Calibration_8_OK = false;
        Boolean Calibration_9_OK = false;

        Boolean has_compare_sensor0 = false;
        Boolean has_compare_sensor1 = false;
        Boolean has_compare_sensor2 = false;
        Boolean has_compare_sensor3 = false;
        Boolean has_compare_sensor4 = false;
        Boolean has_compare_sensor5 = false;
        Boolean has_compare_sensor6 = false;
        Boolean has_compare_sensor7 = false;

        Boolean has_finish_calibtation = false;

        //int calibration_sensor0_count = 0;
        //int calibration_sensor1_count = 0;
        //int calibration_sensor2_count = 0;
        //int calibration_sensor3_count = 0;
        //int calibration_sensor4_count = 0;
        //int calibration_sensor5_count = 0;
        //int calibration_sensor6_count = 0;
        //int calibration_sensor7_count = 0;


        string PMS_dir = "";
        string PMS_file = "";
        Boolean has_start = false;
        FileInfo fi;
        StringBuilder sb;
        DirectoryInfo dirInfo;
        FileSystemWatcher _watch = new FileSystemWatcher();

        string fileName = "C:\\temp\\temp";

        string sensor_0_value, sensor_1_value, sensor_2_value, sensor_3_value, sensor_4_value, sensor_5_value,
          sensor_6_value, sensor_7_value, sensor_8_value, sensor_9_value;

        string PMS_log0_value, PMS_log1_value, PMS_log2_value, PMS_log3_value, PMS_log4_value, PMS_log5_value, PMS_log6_value,
            PMS_log7_value, PMS_log8_value, PMS_log9_value;

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

    

        private void Form1_Load(object sender, EventArgs e)
        {
            Close_flash_loader();
            Load_RS232();
            backgroundWorker_Sensor.WorkerReportsProgress = true;
            backgroundWorker_Sensor.RunWorkerAsync();
            textBox1.Text = "1. 確定氣管全部未接，並執行完歸零按鈕" + "\r\n\r\n";
            textBox1.Text += "2. 氣管全部接上後，按下Start Calibration鈕";
            cbx_model.SelectedIndex = 1;
            this.Location = new Point(1025, 0);
            this.Size = new Size(335, 725);

            MyFileSystemWatcher();
        }

     

        private void backgroundWorker_Sensor_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                backgroundWorker_Sensor.ReportProgress(1);
                Thread.Sleep(300);
            }
        }

        private void backgroundWorker_Sensor_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                if (textBox2.Text.Length > 4700)
                {
                    textBox2.Text = "";
                }

                if (str_RS232_receiver.Length < 200) //RS232 Receive length = 170
                {
                    sensor_0_value = "0";
                    sensor_1_value = "0";
                    sensor_2_value = "0";
                    sensor_3_value = "0";
                    sensor_4_value = "0";
                    sensor_5_value = "0";
                    sensor_6_value = "0";
                    sensor_7_value = "0";
                    sensor_8_value = "0";
                    sensor_9_value = "0";

                    //Copy PMS file to new path        
                    if (has_start)
                    {
                        try
                        {
                            File.Copy(PMS_record_file_name, fileName, true);
                            string PMS_string = Get_last_line(fileName);
                            string[] PMS_value = PMS_string.Split('\t');

                            PMS_log0_value = PMS_value[4]; //LC
                            PMS_log1_value = PMS_value[14]; //H 5改為14
                            PMS_log2_value = PMS_value[6]; //SA
                            PMS_log3_value = PMS_value[7]; //SB
                            PMS_log4_value = PMS_value[8]; //BA
                            PMS_log5_value = PMS_value[9]; //BB
                            PMS_log6_value = PMS_value[15]; //LA 10改為15
                            PMS_log7_value = PMS_value[11]; //LB
                            PMS_log8_value = PMS_value[12]; //TR
                            PMS_log9_value = PMS_value[13]; //TL

                            PMS_log0_value = Math.Round(Convert.ToDouble(PMS_log0_value), 1).ToString();
                            PMS_log1_value = Math.Round(Convert.ToDouble(PMS_log1_value), 1).ToString();
                            PMS_log2_value = Math.Round(Convert.ToDouble(PMS_log2_value), 1).ToString();
                            PMS_log3_value = Math.Round(Convert.ToDouble(PMS_log3_value), 1).ToString();
                            PMS_log4_value = Math.Round(Convert.ToDouble(PMS_log4_value), 1).ToString();
                            PMS_log5_value = Math.Round(Convert.ToDouble(PMS_log5_value), 1).ToString();
                            PMS_log6_value = Math.Round(Convert.ToDouble(PMS_log6_value), 1).ToString();
                            PMS_log7_value = Math.Round(Convert.ToDouble(PMS_log7_value), 1).ToString();
                            PMS_log8_value = Math.Round(Convert.ToDouble(PMS_log8_value), 1).ToString();
                            PMS_log9_value = Math.Round(Convert.ToDouble(PMS_log9_value), 1).ToString();
                        }
                        catch
                        { }
                    }

                    if (has_finish_calibtation)
                    {
                        has_finish_calibtation = false;
                        textBox1.Text = "1. 確定氣管全部未接，並執行完歸零按鈕" + "\r\n\r\n";
                        textBox1.Text += "2. 氣管全部接上後，按下Start Calibration鈕";
                    }
                    textBox2.Text += str_RS232_receiver;

                    try
                    {
                        equal_0 = str_RS232_receiver.IndexOf("=", 0);
                        sensor_0_value = str_RS232_receiver.Substring(equal_0 - 4, 4);

                        equal_1 = str_RS232_receiver.IndexOf("=", equal_0 + 1);
                        sensor_1_value = str_RS232_receiver.Substring(equal_1 - 4, 4);

                        equal_2 = str_RS232_receiver.IndexOf("=", equal_1 + 1);
                        sensor_2_value = str_RS232_receiver.Substring(equal_2 - 4, 4);

                        equal_3 = str_RS232_receiver.IndexOf("=", equal_2 + 1);
                        sensor_3_value = str_RS232_receiver.Substring(equal_3 - 4, 4);

                        equal_4 = str_RS232_receiver.IndexOf("=", equal_3 + 1);
                        sensor_4_value = str_RS232_receiver.Substring(equal_4 - 4, 4);

                        equal_5 = str_RS232_receiver.IndexOf("=", equal_4 + 1);
                        sensor_5_value = str_RS232_receiver.Substring(equal_5 - 4, 4);

                        equal_6 = str_RS232_receiver.IndexOf("=", equal_5 + 1);
                        sensor_6_value = str_RS232_receiver.Substring(equal_6 - 4, 4);

                        equal_7 = str_RS232_receiver.IndexOf("=", equal_6 + 1);
                        sensor_7_value = str_RS232_receiver.Substring(equal_7 - 4, 4);
                    }
                    catch { }

                    MatchCollection MatchCollection1;
                    Regex Regex1 = new Regex("=");//搜尋字元是=
                    try
                    {
                        if (Calibration_8_OK == false)
                        {
                            MatchCollection1 = Regex1.Matches(str_RS232_receiver);
                            if (MatchCollection1.Count == 9)
                            {
                                equal_8 = str_RS232_receiver.IndexOf(" ", equal_7 + 3);
                                sensor_8_value = str_RS232_receiver.Substring(equal_8 + 2, 4);
                                lbl_sensor8.Text = "Sensor8: " + sensor_8_value;
                                lbl_PMS8.Text = "PMS8: " + PMS_log8_value;
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Sensor8");
                    }
                    try
                    {
                        if (Calibration_8_OK)
                        {
                            MatchCollection1 = Regex1.Matches(str_RS232_receiver);
                            if (MatchCollection1.Count == 9)
                            {
                                equal_9 = str_RS232_receiver.IndexOf(" ", 84);
                                sensor_9_value = str_RS232_receiver.Substring(equal_9 + 1, 4);
                                lbl_sensor9.Text = "Sensor9: " + sensor_9_value;
                                lbl_PMS9.Text = "PMS9: " + PMS_log9_value;
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Sensor9");
                    }

                    //for DED LabView
                    lbl_sensor0.Text = "Sensor0: " + sensor_0_value;
                    lbl_sensor1.Text = "Sensor1: " + sensor_1_value;
                    lbl_sensor2.Text = "Sensor2: " + sensor_2_value;
                    lbl_sensor3.Text = "Sensor3: " + sensor_3_value;
                    lbl_sensor4.Text = "Sensor4: " + sensor_4_value;
                    lbl_sensor5.Text = "Sensor5: " + sensor_5_value;
                    lbl_sensor6.Text = "Sensor6: " + sensor_6_value;
                    lbl_sensor7.Text = "Sensor7: " + sensor_7_value;

                    lbl_PMS0.Text = "PMS0: " + PMS_log0_value;
                    lbl_PMS1.Text = "PMS1: " + PMS_log1_value;
                    lbl_PMS2.Text = "PMS2: " + PMS_log2_value;
                    lbl_PMS3.Text = "PMS3: " + PMS_log3_value;
                    lbl_PMS4.Text = "PMS4: " + PMS_log4_value;
                    lbl_PMS5.Text = "PMS5: " + PMS_log5_value;
                    lbl_PMS6.Text = "PMS6: " + PMS_log6_value;
                    lbl_PMS7.Text = "PMS7: " + PMS_log7_value;
                    lbl_PMS8.Text = "PMS8: " + PMS_log8_value;
                    lbl_PMS9.Text = "PMS9: " + PMS_log9_value;
                }
            }
            catch
            {

            }
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            try
            {
                //get files quantity
                int files_quantity = 0;
                foreach (string fname in System.IO.Directory.GetFiles(tbx_dir_path.Text))
                {
                    files_quantity++;
                }

                //get create file name             
                string[] files_date = new string[files_quantity];
                int temp1 = 0;
                foreach (string fname in System.IO.Directory.GetFiles(tbx_dir_path.Text))
                {
                    FileInfo fi = new FileInfo(fname);
                    files_date[temp1] = fi.LastWriteTime.ToString("yyyyMMddHHmm");
                    temp1++;
                }

                Array.Sort(files_date);

                string file_date = files_date[files_quantity - 1];

                //get file name                
                foreach (string fname in System.IO.Directory.GetFiles(tbx_dir_path.Text))
                {
                    FileInfo fi2 = new FileInfo(fname);
                    if (fi2.LastWriteTime.ToString("yyyyMMddHHmm") == file_date)
                    {
                        PMS_record_file_name = fi2.FullName;
                        has_start = true;
                    }
                }


                //建立log檔案             
                File_path2 = @"C:\temp\" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".txt";
                if (!System.IO.File.Exists(File_path2))
                {
                    using (System.IO.FileStream fs = System.IO.File.Create(File_path2))
                    {

                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            MessageBox.Show("確定機型選對!!");
            serialPort1.Close();
            serialPort1.Open();

            //回傳版本
            receive_232 = true;
            string power_off1 = "version?" + " \n\r";
            byte[] ASCII_power_off1 = Encoding.ASCII.GetBytes(power_off1);
            serialPort1.Write(ASCII_power_off1, 0, ASCII_power_off1.Length);
            Thread.Sleep(100);

            DialogResult myResult = MessageBox.Show("確定機型是否選對!!", "確定機型是否選對!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (myResult == DialogResult.Yes)
            {
                textBox1.Text = "開始校準中,請隨時查看是否有彈出視窗";

                //serialPort2.Close();
                try
                {
                    serialPort2.Open();
                }
               catch
                {
                    MessageBox.Show("");
                }

                                    //Reset initial
                Counter_pl6_pl7 = 0;
                str_RS232_receiver = "";
                has_send_nurse_right = false;
                Send_ph1_ph7 = true;
                Send_g_8 = true;
                Send_g_9 = true;
                Calibration_0_7_OK = false;
                Calibration_8_OK = false;
                Calibration_9_OK = false;
                has_compare_sensor0 = false;
                has_compare_sensor1 = false;
                has_compare_sensor2 = false;
                has_compare_sensor3 = false;
                has_compare_sensor4 = false;
                has_compare_sensor5 = false;
                has_compare_sensor6 = false;
                has_compare_sensor7 = false;

                receive_232 = true;

                string _start_sned_0 = "diag.diag 0 \n\r";
                string _start_sned_1 = "diag.echo 1 \n\r";
                string _start_sned_2 = "diag.disp.alarm 1 \n\r";
                string _start_sned_3 = "diag.disp.audio 1 \n\r";
                string _start_sned_4 = "diag.disp.sens.mode 0x2222222222 \n\r";
                string _start_sned_5 = "diag.disp 1 \n\r";
                string _start_sned_6 = "diag.prof.setting reset\n\r";

                byte[] ASCIIbytes0 = Encoding.ASCII.GetBytes(_start_sned_0);
                byte[] ASCIIbytes1 = Encoding.ASCII.GetBytes(_start_sned_1);
                byte[] ASCIIbytes2 = Encoding.ASCII.GetBytes(_start_sned_2);
                byte[] ASCIIbytes3 = Encoding.ASCII.GetBytes(_start_sned_3);
                byte[] ASCIIbytes4 = Encoding.ASCII.GetBytes(_start_sned_4);
                byte[] ASCIIbytes5 = Encoding.ASCII.GetBytes(_start_sned_5);
                byte[] ASCIIbytes6 = Encoding.ASCII.GetBytes(_start_sned_6);

                serialPort1.Write(ASCIIbytes0, 0, ASCIIbytes0.Length);
                Thread.Sleep(30);

                serialPort1.Write(ASCIIbytes1, 0, ASCIIbytes1.Length);
                Thread.Sleep(30);
                serialPort1.Write(ASCIIbytes2, 0, ASCIIbytes2.Length);
                Thread.Sleep(30);
                serialPort1.Write(ASCIIbytes3, 0, ASCIIbytes3.Length);
                Thread.Sleep(30);
                serialPort1.Write(ASCIIbytes4, 0, ASCIIbytes4.Length);
                Thread.Sleep(30);
                serialPort1.Write(ASCIIbytes5, 0, ASCIIbytes5.Length);
                Thread.Sleep(30);
                serialPort1.Write(ASCIIbytes6, 0, ASCIIbytes6.Length);
                Thread.Sleep(30);
                serialPort1.Write(ASCIIbytes6, 0, ASCIIbytes6.Length);
                Thread.Sleep(30);
                serialPort1.Write(ASCIIbytes6, 0, ASCIIbytes6.Length);
                Thread.Sleep(30);

                byte[] ASCII_p_u = Encoding.ASCII.GetBytes(_p_u);
                serialPort1.Write(ASCII_p_u, 0, ASCII_p_u.Length);
                Thread.Sleep(1000);
            }
            else if (myResult == DialogResult.No)
            {
                //按了否

            }
        }

        #region Excel Related

        //void initailExcel()
        //{
        //    //檢查PC有無Excel在執行
        //    bool flag = false;
        //    foreach (var item in Process.GetProcesses())
        //    {
        //        if (item.ProcessName == "EXCEL")
        //        {
        //            flag = true;
        //            break;
        //        }
        //    }

        //    if (!flag)
        //    {
        //        this._Excel = new Excel.Application();
        //    }
        //    else
        //    {
        //        object obj = Marshal.GetActiveObject("Excel.Application");//引用已在執行的Excel
        //        _Excel = obj as Excel.Application;
        //    }
        //    this._Excel.Visible = true;//設false效能會比較好
        //}

        //object[,] Read_Excel()
        //{
        //    // string path = @"d:\temp\123.xls";
        //    string path = PMS_file;
        //    book = _Excel.Workbooks.Open(path, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);//開啟舊檔案
        //    sheet = (Excel.Worksheet)book.Sheets[1];

        //    Excel.Range _range1 = sheet.Cells.get_Range("A2", "Q2");

        //    object[,] excel_data = (object[,])_range1.Value;   //get range's value 

        //    foreach (var item in Process.GetProcesses())
        //    {
        //        if (item.ProcessName == "EXCEL")
        //        {
        //            item.CloseMainWindow();
        //        }
        //    }
        //    return excel_data;
        //}

        #endregion

        private void cbx_RS232_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
                serialPort1.BaudRate = 115200;
                serialPort1.PortName = cbx_RS232.SelectedItem.ToString();
                serialPort1.Open();
            }
            catch
            {
                MessageBox.Show("請選擇其它COM PORT");
            }
        }

        string File_path = "";
        string File_path2 = "";
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                if (receive_232)
                {
                    //Protection pressure is too high
                    try
                    {
                        if (Convert.ToDouble(PMS_log0_value) > 80 || Convert.ToDouble(PMS_log1_value) > 40 || Convert.ToDouble(PMS_log2_value) > 70 ||
                            Convert.ToDouble(PMS_log3_value) > 70 || Convert.ToDouble(PMS_log4_value) > 70 || Convert.ToDouble(PMS_log5_value) > 70 ||
                            Convert.ToDouble(PMS_log6_value) > 40 || Convert.ToDouble(PMS_log7_value) > 40 || Convert.ToDouble(PMS_log8_value) > 100
                            || Convert.ToDouble(PMS_log9_value) > 100)
                        {
                            string power_off = "sim.key 2" + " \n\r";
                            byte[] ASCII_power_off = Encoding.ASCII.GetBytes(power_off);
                            serialPort1.Write(ASCII_power_off, 0, ASCII_power_off.Length);
                            Thread.Sleep(50);
                            MessageBox.Show("壓大過大, 停止校正!!請檢查相關元件");
                        }
                    }
                    catch { }

                    Thread.Sleep(20);
                    int _232_count = serialPort1.BytesToRead;   //有多少
                    byte[] Buffer = new byte[_232_count];   //new多少byte 陣列
                    if (_232_count > 0)
                    {
                        serialPort1.Read(Buffer, 0, _232_count);    //有多少就讀入多少
                        str_RS232_receiver = System.Text.Encoding.Default.GetString(Buffer);




                       





                        if (str_RS232_receiver.Length < 200)
                        {
                            //顯示版本
                            if (str_RS232_receiver.Contains("Rev"))
                            {
                                receive_232 = false;
                                MessageBox.Show(str_RS232_receiver);
                            }

                            MatchCollection MatchCollection1;
                            Regex Regex1 = new Regex("=");//搜尋字元是=
                            MatchCollection1 = Regex1.Matches(str_RS232_receiver);

                            if (model == "C100")
                            {
                                #region   for C100


                                # region Calibration Sensor 0~4
                                if (MatchCollection1.Count == 5 && Calibration_0_7_OK == false) //appear 8 times
                                {
                                    //Create temp file.
                                    File_path = @"C:\temp\temp.txt";
                                    //建立檔案
                                    if (!System.IO.File.Exists(File_path))
                                    {
                                        using (System.IO.FileStream fs = System.IO.File.Create(File_path))
                                        {

                                        }
                                    }

                                    if (Send_ph1_ph7)
                                    {
                                        # region Send ph 1 log~ph 7 log
                                        Thread.Sleep(8000);
                                        Send_ph1_to_ph4();
                                        Send_ph1_ph7 = false;
                                        Thread.Sleep(20000);
                                        #endregion
                                    }
                                    else
                                    {
                                        //   Send_pl1_pl7 = true;
                                        # region Send g 0 log,pl 1 log~pl 4 log

                                        // LC - 1
                                        Double LC = Convert.ToDouble(PMS_log0_value);
                                        LC = LC;

                                        string str_g_0_log = "g 0 " + LC.ToString() + "\n\r";
                                        byte[] _g_0_value = Encoding.ASCII.GetBytes(str_g_0_log);

                                        if (has_compare_sensor0 == false)
                                        {
                                            serialPort1.Write(_g_0_value, 0, _g_0_value.Length);
                                            Thread.Sleep(1000);
                                        }
                                        string str_pl_1_log = "pl 1 " + PMS_log1_value + "\n\r";
                                        byte[] _pl_1_value = Encoding.ASCII.GetBytes(str_pl_1_log);

                                        if (has_compare_sensor1 == false)
                                        {
                                            serialPort1.Write(_pl_1_value, 0, _pl_1_value.Length);
                                            Thread.Sleep(1000);
                                        }

                                        string str_pl_2_log = "pl 2 " + PMS_log2_value + "\n\r";
                                        byte[] _pl_2_value = Encoding.ASCII.GetBytes(str_pl_2_log);

                                        if (has_compare_sensor2 == false)
                                        {
                                            serialPort1.Write(_pl_2_value, 0, _pl_2_value.Length);
                                            Thread.Sleep(1000);
                                        }

                                        string str_pl_3_log = "pl 3 " + PMS_log4_value + "\n\r";
                                        byte[] _pl_3_value = Encoding.ASCII.GetBytes(str_pl_3_log);

                                        if (has_compare_sensor3 == false)
                                        {
                                            serialPort1.Write(_pl_3_value, 0, _pl_3_value.Length);
                                            Thread.Sleep(1000);
                                        }

                                        string str_pl_4_log = "pl 4 " + PMS_log7_value + "\n\r";
                                        byte[] _pl_4_value = Encoding.ASCII.GetBytes(str_pl_4_log);

                                        if (has_compare_sensor4 == false)
                                        {
                                            serialPort1.Write(_pl_4_value, 0, _pl_4_value.Length);
                                            Thread.Sleep(1000);
                                        }

                                        #endregion

                                        #region Compare Sensor 0~7

                                        if (has_compare_sensor0 == false)
                                        {
                                            if ((Convert.ToDouble(sensor_0_value) <= (Convert.ToDouble(PMS_log0_value) + 0.5)) &&
                                      (Convert.ToDouble(sensor_0_value) >= (Convert.ToDouble(PMS_log0_value) - 0.5)))
                                            {
                                                has_compare_sensor0 = true;
                                            }
                                        }


                                        if (has_compare_sensor1 == false)
                                        {
                                            if ((Convert.ToDouble(sensor_1_value) <= (Convert.ToDouble(PMS_log1_value) + 0.5)) &&
                                                  (Convert.ToDouble(sensor_1_value) >= (Convert.ToDouble(PMS_log1_value) - 0.5)))
                                            {
                                                has_compare_sensor1 = true;
                                            }
                                        }


                                        if (has_compare_sensor2 == false)
                                        {
                                            if ((Convert.ToDouble(sensor_2_value) <= (Convert.ToDouble(PMS_log2_value) + 0.5)) &&
                                               (Convert.ToDouble(sensor_2_value) >= (Convert.ToDouble(PMS_log2_value) - 0.5)))
                                            {
                                                has_compare_sensor2 = true;
                                            }
                                        }


                                        if (has_compare_sensor3 == false)
                                        {
                                            if ((Convert.ToDouble(sensor_3_value) <= (Convert.ToDouble(PMS_log4_value) + 0.5)) &&
                                              (Convert.ToDouble(sensor_3_value) >= (Convert.ToDouble(PMS_log4_value) - 0.5)))
                                            {
                                                has_compare_sensor3 = true;
                                            }
                                        }


                                        if (has_compare_sensor4 == false)
                                        {
                                            if ((Convert.ToDouble(sensor_4_value) <= (Convert.ToDouble(PMS_log7_value) + 0.5)) &&
                                               (Convert.ToDouble(sensor_4_value) >= (Convert.ToDouble(PMS_log7_value) - 0.5)))
                                            {
                                                has_compare_sensor4 = true;
                                            }
                                        }



                                        if (has_compare_sensor0 && has_compare_sensor1 && has_compare_sensor2
                                            && has_compare_sensor3 && has_compare_sensor4)
                                        {
                                            Calibration_0_7_OK = true;


                                            StreamWriter sw = new StreamWriter(File_path, true);
                                            sw.WriteLine("sensor Value Low");
                                            sw.WriteLine(sensor_0_value + "\t" + sensor_1_value + "\t" + sensor_2_value + "\t" + sensor_3_value +
                                                "\t" + sensor_4_value);

                                            sw.WriteLine("PMS Value Low");
                                            sw.WriteLine(PMS_log0_value + "\t" + PMS_log1_value + "\t" + PMS_log2_value + "\t" + PMS_log4_value +
                                                "\t" + PMS_log7_value);
                                            ;
                                            sw.WriteLine("PMS -------------------------------------------------------------------------");
                                            sw.Close();

                                            //   MessageBox.Show("Sensor 0~7校正完成,請按下床身右斜鍵");
                                            if (has_send_nurse_right == false)
                                            {
                                                has_send_nurse_right = true;
                                                string str_right = "sim.key 16" + "\n\r";
                                                byte[] str_right_value = Encoding.ASCII.GetBytes(str_right);
                                                serialPort1.Write(str_right_value, 0, str_right_value.Length);
                                                Thread.Sleep(20001);
                                            }
                                        }
                                        else
                                        {

                                        }

                                        #endregion
                                    }
                                    Thread.Sleep(1000);
                                }

                                #region for o u
                                if (Counter_pl6_pl7 < 200)
                                {
                                    Counter_pl6_pl7++;
                                }
                                else
                                {
                                    string str_o_u_6 = "o u 6 " + PMS_log6_value + "\n\r";
                                    byte[] _o_u_6_value = Encoding.ASCII.GetBytes(str_o_u_6);
                                    serialPort1.Write(_o_u_6_value, 0, _o_u_6_value.Length);
                                    Thread.Sleep(30);
                                    string str_o_u_7 = "o u 7 " + PMS_log7_value + "\n\r";
                                    byte[] _o_u_7_value = Encoding.ASCII.GetBytes(str_o_u_7);
                                    serialPort1.Write(_o_u_7_value, 0, _o_u_7_value.Length);
                                    Thread.Sleep(30);
                                    //  MessageBox.Show("6");     
                                    Counter_pl6_pl7 = Counter_pl6_pl7 - 10;
                                }
                                #endregion

                                #endregion

                                #region    Calibration Sensor 6

                                if (MatchCollection1.Count == 6 && Send_g_9 == true && Calibration_8_OK == true) //appear 10 times
                                {
                                    Send_g_9 = false;
                                    string str_g_9 = "g 9 " + PMS_log9_value + "\n\r";
                                    byte[] _g_9_value = Encoding.ASCII.GetBytes(str_g_9);
                                    if (Convert.ToDouble(PMS_log8_value) < 80 && Convert.ToDouble(PMS_log8_value) > 50)
                                    {
                                        serialPort1.Write(_g_9_value, 0, _g_9_value.Length);
                                        Thread.Sleep(500);
                                    }
                                }

                                if (MatchCollection1.Count == 6 && Calibration_9_OK == false && Calibration_8_OK == true) //appear 10 times
                                {
                                    string str_g_9 = "g 9 " + PMS_log9_value + "\n\r";
                                    byte[] _g_9_value = Encoding.ASCII.GetBytes(str_g_9);
                                    Send_g_8 = false;

                                    // compare Log and MCU +-3%                         
                                    if ((Convert.ToDouble(sensor_5_value) <= (Convert.ToDouble(PMS_log9_value) + 1.5)) &&
                                        (Convert.ToDouble(sensor_5_value) >= (Convert.ToDouble(PMS_log9_value) - 1.5)))
                                    {
                                        Calibration_9_OK = true; //Sensor Calibration OK
                                        //Write temp file.
                                        File_path = @"C:\temp\temp.txt";
                                        StreamWriter sw = new StreamWriter(File_path, true);
                                        sw.WriteLine("sensor6 Value: " + sensor_5_value);
                                        sw.WriteLine("PMS9 Value: " + PMS_log9_value);
                                        sw.Close();

                                        //Send save command to MCU
                                        string str_save_command = "cal.sav " + "\n\r";
                                        byte[] _save_command = Encoding.ASCII.GetBytes(str_save_command);
                                        serialPort1.Write(_save_command, 0, _save_command.Length);
                                        Thread.Sleep(50);
                                        receive_232 = false;
                                        MessageBox.Show("全部校正完畢");
                                        has_start = false;
                                        has_finish_calibtation = true;
                                    }
                                    else
                                    {
                                        if (Convert.ToDouble(PMS_log8_value) < 80 && Convert.ToDouble(PMS_log8_value) > 50)
                                        {
                                            serialPort1.Write(_g_9_value, 0, _g_9_value.Length);
                                            Thread.Sleep(50);
                                        }
                                    }
                                }
                                #endregion

                                #region    Calibration Sensor 5

                                if (MatchCollection1.Count == 6 && Send_g_8 == true) //appear 9 times
                                {
                                    Send_g_8 = false;
                                    string str_g_8 = "g 8 " + PMS_log8_value + "\n\r";
                                    byte[] _g_8_value = Encoding.ASCII.GetBytes(str_g_8);
                                    if (Convert.ToDouble(PMS_log8_value) < 80 && Convert.ToDouble(PMS_log8_value) > 50)
                                    {
                                        serialPort1.Write(_g_8_value, 0, _g_8_value.Length);
                                        Thread.Sleep(500);
                                    }
                                }

                                if (MatchCollection1.Count == 6 && Calibration_8_OK == false) //appear 9 times
                                {
                                    string str_g_8 = "g 8 " + PMS_log8_value + "\n\r";
                                    byte[] _g_8_value = Encoding.ASCII.GetBytes(str_g_8);
                                    Send_g_8 = false;

                                    // compare Log and MCU +-3%                         
                                    if ((Convert.ToDouble(sensor_5_value) <= (Convert.ToDouble(PMS_log8_value) + 1.5)) &&
                                        (Convert.ToDouble(sensor_5_value) >= (Convert.ToDouble(PMS_log8_value) - 1.5)))
                                    {
                                        Calibration_8_OK = true; //Sensor Calibration OK       

                                        //Write temp file.
                                        File_path = @"C:\temp\temp.txt";
                                        StreamWriter sw = new StreamWriter(File_path, true);
                                        sw.WriteLine("sensor5 Value: " + sensor_5_value);
                                        sw.WriteLine("PMS8 Value: " + PMS_log8_value);
                                        sw.WriteLine("-----------------------------------------------");
                                        sw.Close();

                                        //  MessageBox.Show("Sensor 8校正完成,請按下床左斜鍵");
                                        string str_left = "sim.key 18" + "\n\r";
                                        byte[] str_left_value = Encoding.ASCII.GetBytes(str_left);
                                        serialPort1.Write(str_left_value, 0, str_left_value.Length);
                                        Thread.Sleep(35000);
                                    }
                                    else
                                    {
                                        if (Convert.ToDouble(PMS_log8_value) < 80 && Convert.ToDouble(PMS_log8_value) > 45)
                                        {
                                            serialPort1.Write(_g_8_value, 0, _g_8_value.Length);
                                            Thread.Sleep(50);
                                        }
                                    }

                                }
                                #endregion

                                #endregion
                            }

                            if (model == "C200")
                            {
                                #region for C200

                                # region Calibration Sensor 0~7
                                if (MatchCollection1.Count == 8 && Calibration_0_7_OK == false) //appear 8 times
                                {
                                    //Create temp file.
                                    File_path = @"C:\temp\temp.txt";
                                    //建立檔案
                                    if (!System.IO.File.Exists(File_path))
                                    {
                                        using (System.IO.FileStream fs = System.IO.File.Create(File_path))
                                        {

                                        }
                                    }


                                    if (Send_ph1_ph7)
                                    {
                                        # region Send ph 1 log~ph 7 log
                                        Thread.Sleep(30000);
                                        Send_ph1_to_ph7();
                                        Send_ph1_ph7 = false;
                                        Thread.Sleep(20000);
                                        #endregion
                                    }
                                    else
                                    {
                                        //   Send_pl1_pl7 = true;
                                        # region Send g 0 log,pl 1 log~pl 7 log

                                        // LC - 1
                                        Double LC = Convert.ToDouble(PMS_log0_value);
                                        LC = LC;


                                        string str_g_0_log = "g 0 " + LC.ToString() + "\n\r";
                                        byte[] _g_0_value = Encoding.ASCII.GetBytes(str_g_0_log);

                                        if (has_compare_sensor0 == false)
                                        {
                                            serialPort1.Write(_g_0_value, 0, _g_0_value.Length);
                                            Thread.Sleep(1000);

                                        }
                                        string str_pl_1_log = "pl 1 " + PMS_log1_value + "\n\r";
                                        byte[] _pl_1_value = Encoding.ASCII.GetBytes(str_pl_1_log);

                                        if (has_compare_sensor1 == false)
                                        {
                                            serialPort1.Write(_pl_1_value, 0, _pl_1_value.Length);
                                            Thread.Sleep(1000);

                                        }

                                        string str_pl_2_log = "pl 2 " + PMS_log2_value + "\n\r";
                                        byte[] _pl_2_value = Encoding.ASCII.GetBytes(str_pl_2_log);

                                        if (has_compare_sensor2 == false)
                                        {
                                            serialPort1.Write(_pl_2_value, 0, _pl_2_value.Length);
                                            Thread.Sleep(1000);

                                        }

                                        string str_pl_3_log = "pl 3 " + PMS_log3_value + "\n\r";
                                        byte[] _pl_3_value = Encoding.ASCII.GetBytes(str_pl_3_log);

                                        if (has_compare_sensor3 == false)
                                        {
                                            serialPort1.Write(_pl_3_value, 0, _pl_3_value.Length);
                                            Thread.Sleep(1000);
                                        }

                                        string str_pl_4_log = "pl 4 " + PMS_log4_value + "\n\r";
                                        byte[] _pl_4_value = Encoding.ASCII.GetBytes(str_pl_4_log);

                                        if (has_compare_sensor4 == false)
                                        {
                                            serialPort1.Write(_pl_4_value, 0, _pl_4_value.Length);
                                            Thread.Sleep(1000);
                                        }

                                        string str_pl_5_log = "pl 5 " + PMS_log5_value + "\n\r";
                                        byte[] _pl_5_value = Encoding.ASCII.GetBytes(str_pl_5_log);

                                        if (has_compare_sensor5 == false)
                                        {
                                            serialPort1.Write(_pl_5_value, 0, _pl_5_value.Length);
                                            Thread.Sleep(1000);
                                        }

                                        string str_pl_6_log = "pl 6 " + PMS_log6_value + "\n\r";
                                        byte[] _pl_6_value = Encoding.ASCII.GetBytes(str_pl_6_log);

                                        if (has_compare_sensor6 == false)
                                        {
                                            serialPort1.Write(_pl_6_value, 0, _pl_6_value.Length);
                                            Thread.Sleep(1000);
                                        }

                                        string str_pl_7_log = "pl 7 " + PMS_log7_value + "\n\r";
                                        byte[] _pl_7_value = Encoding.ASCII.GetBytes(str_pl_7_log);

                                        if (has_compare_sensor7 == false)
                                        {
                                            serialPort1.Write(_pl_7_value, 0, _pl_7_value.Length);
                                            Thread.Sleep(1000);
                                        }

                                        #endregion

                                        #region Compare Sensor 0~7

                                        if (has_compare_sensor0 == false)
                                        {
                                            if ((Convert.ToDouble(sensor_0_value) <= (Convert.ToDouble(PMS_log0_value) + 0.3)) &&
                                      (Convert.ToDouble(sensor_0_value) >= (Convert.ToDouble(PMS_log0_value) - 0.3)) &&
                                                (Convert.ToDouble(PMS_log0_value) > 46.2)
                                                )
                                            {
                                                has_compare_sensor0 = true;

                                                StreamWriter sw = new StreamWriter(File_path2, true);
                                                sw.WriteLine("sensor0 Value: " + sensor_0_value);
                                                sw.WriteLine("PMS0 Value: " + PMS_log0_value);
                                                sw.WriteLine("----------------------------");
                                                sw.Close();
                                            }
                                        }


                                        if (has_compare_sensor1 == false)
                                        {
                                            if ((Convert.ToDouble(sensor_1_value) <= (Convert.ToDouble(PMS_log1_value) + 0.1)) &&
                                                  (Convert.ToDouble(sensor_1_value) >= (Convert.ToDouble(PMS_log1_value) - 0.1)))
                                            {
                                                has_compare_sensor1 = true;

                                                StreamWriter sw = new StreamWriter(File_path2, true);
                                                sw.WriteLine("sensor1 Value: " + sensor_1_value);
                                                sw.WriteLine("PMS1 Value: " + PMS_log1_value);
                                                sw.WriteLine("----------------------------");
                                                sw.Close();
                                            }
                                        }


                                        if (has_compare_sensor2 == false)
                                        {
                                            if ((Convert.ToDouble(sensor_2_value)) == Convert.ToDouble(PMS_log2_value))
                                            {
                                                has_compare_sensor2 = true;

                                                StreamWriter sw = new StreamWriter(File_path2, true);
                                                sw.WriteLine("sensor2 Value: " + sensor_2_value);
                                                sw.WriteLine("PMS2 Value: " + PMS_log2_value);
                                                sw.WriteLine("----------------------------");
                                                sw.Close();
                                            }
                                        }


                                        if (has_compare_sensor3 == false)
                                        {
                                            if ((Convert.ToDouble(sensor_3_value)) == Convert.ToDouble(PMS_log3_value))
                                            {
                                                has_compare_sensor3 = true;

                                                StreamWriter sw = new StreamWriter(File_path2, true);
                                                sw.WriteLine("sensor3 Value: " + sensor_3_value);
                                                sw.WriteLine("PMS3 Value: " + PMS_log3_value);
                                                sw.WriteLine("----------------------------");
                                                sw.Close();
                                            }
                                        }


                                        if (has_compare_sensor4 == false)
                                        {
                                            if ((Convert.ToDouble(sensor_4_value)) == Convert.ToDouble(PMS_log4_value))
                                            {
                                                has_compare_sensor4 = true;

                                                StreamWriter sw = new StreamWriter(File_path2, true);
                                                sw.WriteLine("sensor4 Value: " + sensor_4_value);
                                                sw.WriteLine("PMS4 Value: " + PMS_log4_value);
                                                sw.WriteLine("----------------------------");
                                                sw.Close();
                                            }
                                        }


                                        if (has_compare_sensor5 == false)
                                        {
                                            if ((Convert.ToDouble(sensor_5_value)) == Convert.ToDouble(PMS_log5_value))
                                            {
                                                has_compare_sensor5 = true;

                                                StreamWriter sw = new StreamWriter(File_path2, true);
                                                sw.WriteLine("sensor5 Value: " + sensor_5_value);
                                                sw.WriteLine("PMS5 Value: " + PMS_log5_value);
                                                sw.WriteLine("----------------------------");
                                                sw.Close();
                                            }
                                        }


                                        if (has_compare_sensor6 == false)
                                        {
                                            if ((Convert.ToDouble(sensor_6_value) <= (Convert.ToDouble(PMS_log6_value) + 0.1)) &&
                                               (Convert.ToDouble(sensor_6_value) >= (Convert.ToDouble(PMS_log6_value) - 0.1)))
                                            {
                                                has_compare_sensor6 = true;

                                                StreamWriter sw = new StreamWriter(File_path2, true);
                                                sw.WriteLine("sensor6 Value: " + sensor_6_value);
                                                sw.WriteLine("PMS6 Value: " + PMS_log6_value);
                                                sw.WriteLine("----------------------------");
                                                sw.Close();
                                            }
                                        }


                                        if (has_compare_sensor7 == false)
                                        {
                                            if ((Convert.ToDouble(sensor_7_value) <= (Convert.ToDouble(PMS_log7_value) + 0.1)) &&
                                               (Convert.ToDouble(sensor_7_value) >= (Convert.ToDouble(PMS_log7_value) - 0.1)))
                                            {
                                                has_compare_sensor7 = true;

                                                StreamWriter sw = new StreamWriter(File_path2, true);
                                                sw.WriteLine("sensor7 Value: " + sensor_7_value);
                                                sw.WriteLine("PMS7 Value: " + PMS_log7_value);
                                                sw.WriteLine("----------------------------");
                                                sw.Close();
                                            }
                                        }



                                        if (has_compare_sensor0 && has_compare_sensor1 && has_compare_sensor2 && has_compare_sensor3 && has_compare_sensor4
                                            && has_compare_sensor5 && has_compare_sensor6 && has_compare_sensor7)
                                        {
                                            Calibration_0_7_OK = true;

                                            ////Create temp file.
                                            //File_path = @"C:\temp\temp.txt";
                                            ////建立檔案
                                            //if (!System.IO.File.Exists(File_path))
                                            //{
                                            //    using (System.IO.FileStream fs = System.IO.File.Create(File_path))
                                            //    {

                                            //    }
                                            //}
                                            StreamWriter sw = new StreamWriter(File_path, true);
                                            sw.WriteLine("sensor Value Low");
                                            sw.WriteLine(sensor_0_value + "\t" + sensor_1_value + "\t" + sensor_2_value + "\t" + sensor_3_value +
                                                "\t" + sensor_4_value + "\t" + sensor_5_value + "\t" + sensor_6_value + "\t" + sensor_7_value);

                                            sw.WriteLine("PMS Value Low");
                                            sw.WriteLine(PMS_log0_value + "\t" + PMS_log1_value + "\t" + PMS_log2_value + "\t" + PMS_log3_value +
                                                "\t" + PMS_log4_value + "\t" + PMS_log5_value + "\t" + PMS_log6_value + "\t" + PMS_log7_value);
                                            ;
                                            sw.WriteLine("PMS -------------------------------------------------------------------------");
                                            sw.Close();

                                            //        MessageBox.Show("Sensor 0~7校正完成,請按下床右斜鍵");
                                            if (has_send_nurse_right == false)
                                            {
                                                has_send_nurse_right = true;
                                                string str_right = "sim.key 16" + "\n\r";
                                                byte[] str_right_value = Encoding.ASCII.GetBytes(str_right);
                                                serialPort1.Write(str_right_value, 0, str_right_value.Length);
                                                Thread.Sleep(20000);
                                            }
                                        }
                                        else
                                        {

                                        }

                                        #endregion

                                    }
                                    Thread.Sleep(1000);
                                }

                                #region for o u
                                if (Counter_pl6_pl7 < 200)
                                {
                                    Counter_pl6_pl7++;
                                }
                                else
                                {
                                    string str_o_u_6 = "o u 6 " + PMS_log6_value + "\n\r";
                                    byte[] _o_u_6_value = Encoding.ASCII.GetBytes(str_o_u_6);
                                    serialPort1.Write(_o_u_6_value, 0, _o_u_6_value.Length);
                                    Thread.Sleep(30);
                                    string str_o_u_7 = "o u 7 " + PMS_log7_value + "\n\r";
                                    byte[] _o_u_7_value = Encoding.ASCII.GetBytes(str_o_u_7);
                                    serialPort1.Write(_o_u_7_value, 0, _o_u_7_value.Length);
                                    Thread.Sleep(30);
                                    //  MessageBox.Show("6");     
                                    Counter_pl6_pl7 = Counter_pl6_pl7 - 10;
                                }
                                #endregion

                                #endregion

                                #region    Calibration Sensor 9

                                //    if (MatchCollection1.Count == 9 && Send_g_9 == true && Calibration_8_OK == true) //appear 10 times
                                if (MatchCollection1.Count == 9 && Calibration_9_OK == false) //appear 10 times
                                {
                                    // Send_g_9 = false;

                                    string str_g_9 = "g 9 " + PMS_log9_value + "\n\r";
                                    byte[] _g_9_value = Encoding.ASCII.GetBytes(str_g_9);
                                    // if (Convert.ToDouble(PMS_log8_value) < 80 && Convert.ToDouble(PMS_log8_value) > 50)
                                    {
                                        serialPort1.Write(_g_9_value, 0, _g_9_value.Length);
                                        Thread.Sleep(3000);
                                    }
                                }

                                if (MatchCollection1.Count == 9 && Calibration_9_OK == false && Calibration_8_OK == true) //appear 10 times
                                {

                                    string str_g_9 = "g 9 " + PMS_log9_value + "\n\r";
                                    byte[] _g_9_value = Encoding.ASCII.GetBytes(str_g_9);
                                    Send_g_8 = false;

                                    // compare Log and MCU +-3%
                                    if ((Convert.ToDouble(sensor_9_value) <= (Convert.ToDouble(PMS_log9_value) + 0.5)) &&
                                        (Convert.ToDouble(sensor_9_value) >= (Convert.ToDouble(PMS_log9_value) - 0.5)))
                                    {
                                        Calibration_9_OK = true; //Sensor Calibration OK
                                        //Write temp file.
                                        string File_path = @"C:\temp\temp.txt";
                                        StreamWriter sw = new StreamWriter(File_path, true);
                                        sw.WriteLine("sensor9 Value: " + sensor_9_value);
                                        sw.WriteLine("PMS9 Value: " + PMS_log9_value);
                                        sw.Close();

                                        StreamWriter sw2 = new StreamWriter(File_path2, true);
                                        sw2.WriteLine("sensor9 Value: " + sensor_9_value);
                                        sw2.WriteLine("PMS9 Value: " + PMS_log9_value);
                                        sw2.WriteLine("----------------------------");
                                        sw2.Close();

                                        //Send save command to MCU
                                        string str_save_command = "cal.sav " + "\n\r";
                                        byte[] _save_command = Encoding.ASCII.GetBytes(str_save_command);
                                        serialPort1.Write(_save_command, 0, _save_command.Length);
                                        Thread.Sleep(50);
                                        receive_232 = false;
                                        MessageBox.Show("全部校正完畢");
                                        has_start = false;
                                        has_finish_calibtation = true;
                                    }
                                    // else
                                    //  {
                                    //       if (Convert.ToDouble(PMS_log8_value) < 80 && Convert.ToDouble(PMS_log8_value) > 30)
                                    //      {
                                    //           serialPort1.Write(_g_9_value, 0, _g_9_value.Length);
                                    //           Thread.Sleep(4000);
                                    //       }
                                    //   }
                                }
                                #endregion

                                #region    Calibration Sensor 8

                                // if (MatchCollection1.Count == 9 && Send_g_8 == true) //appear 9 times
                                if (MatchCollection1.Count == 9 && Calibration_8_OK == false) //appear 9 times
                                {
                                    //   Send_g_8 = false;

                                    string str_g_8 = "g 8 " + PMS_log8_value + "\n\r";
                                    byte[] _g_8_value = Encoding.ASCII.GetBytes(str_g_8);
                                    //  if (Convert.ToDouble(PMS_log8_value) < 80 && Convert.ToDouble(PMS_log8_value) > 30)
                                    {
                                        serialPort1.Write(_g_8_value, 0, _g_8_value.Length);
                                        Thread.Sleep(3000);
                                    }
                                }

                                if (MatchCollection1.Count == 9 && Calibration_8_OK == false) //appear 9 times
                                {

                                    string str_g_8 = "g 8 " + PMS_log8_value + "\n\r";
                                    byte[] _g_8_value = Encoding.ASCII.GetBytes(str_g_8);
                                    Send_g_8 = false;

                                    // compare Log and MCU +-3%
                                    if ((Convert.ToDouble(sensor_8_value) <= (Convert.ToDouble(PMS_log8_value) + 0.5)) &&
                                        (Convert.ToDouble(sensor_8_value) >= (Convert.ToDouble(PMS_log8_value) - 0.5)))
                                    {
                                        Calibration_8_OK = true; //Sensor Calibration OK       

                                        //Write temp file.
                                        string File_path = @"C:\temp\temp.txt";
                                        StreamWriter sw = new StreamWriter(File_path, true);
                                        sw.WriteLine("sensor8 Value: " + sensor_8_value);
                                        sw.WriteLine("PMS8 Value: " + PMS_log8_value);
                                        sw.WriteLine("-----------------------------------------------");
                                        sw.Close();

                                        StreamWriter sw2 = new StreamWriter(File_path2, true);
                                        sw2.WriteLine("sensor8 Value: " + sensor_8_value);
                                        sw2.WriteLine("PMS8 Value: " + PMS_log8_value);
                                        sw2.WriteLine("----------------------------");
                                        sw2.Close();
                                        //    MessageBox.Show("Sensor 8校正完成,請按下床左斜鍵");

                                        string str_left = "sim.key 18" + "\n\r";
                                        byte[] str_left_value = Encoding.ASCII.GetBytes(str_left);
                                        serialPort1.Write(str_left_value, 0, str_left_value.Length);
                                        Thread.Sleep(30);
                                        Thread.Sleep(35000);
                                    }
                                    //  else
                                    // {
                                    //   if (Convert.ToDouble(PMS_log8_value) < 80 && Convert.ToDouble(PMS_log8_value) > 45)
                                    //    {
                                    //         serialPort1.Write(_g_8_value, 0, _g_8_value.Length);
                                    //         Thread.Sleep(4000);
                                    //     }
                                    // }

                                }
                                #endregion

                                #endregion
                            }
                        }
                    }
                }
                Thread.Sleep(500);
            }
            catch
            {

            }
        }

        private void cbx_model_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_model.SelectedIndex == 0)
            {
                model = "C100";
            }
            if (cbx_model.SelectedIndex == 1)
            {
                model = "C200";
            }
        }

        private void btn_burn_firmware_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();

                Close_flash_loader();
                Thread.Sleep(500);
                Process process = new Process();
                //自行定義的執行代號              
                process.StartInfo.FileName = "STMicroelectronics flash loader.exe";
                //定義要執行的外部程式
                process.StartInfo.WorkingDirectory = @"C:\Program Files (x86)\STMicroelectronics\Software\Flash Loader Demonstrator";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                //這裡的啟動模式是"Maximized"（最大化）
                process.Start(); //啟動程式     
                Thread.Sleep(1000);



                Mouse.MoveTo("947", "823");
                Mouse.LeftClick();
                Thread.Sleep(500);
                Mouse.LeftClick();
                Thread.Sleep(500);
                Mouse.LeftClick();
                Thread.Sleep(500);
                Mouse.LeftClick();
                Thread.Sleep(22000);

                Mouse.MoveTo("1120", "820");
                Mouse.LeftClick();

                Thread.Sleep(500);

                receive_232 = true;

                MessageBox.Show("燒錄完成, 按下UPGRADE -> RESET後,即可以開始進行校正");
                serialPort1.Close();
                Thread.Sleep(50);
                serialPort1.Open();
                Thread.Sleep(50);
                string power_off = "version?" + " \n\r";
                byte[] ASCII_power_off = Encoding.ASCII.GetBytes(power_off);
                serialPort1.Write(ASCII_power_off, 0, ASCII_power_off.Length);
                Thread.Sleep(50);
            }
            catch
            {
                MessageBox.Show("燒錄發生錯誤!!");
            }
        }

        string Get_last_line(string file_name)
        {

            string fname = file_name;
            StreamReader sr = new StreamReader(fname);
            string st = string.Empty;
            while (!sr.EndOfStream)
            {
                st = sr.ReadLine();
            }
            sr.Close();
            return st;
        }


        double pms_reduce = 0.3;
        void Send_ph1_to_ph7()
        {
            StreamWriter sw = new StreamWriter(File_path, true);
            sw.WriteLine("========================================================================================================================");
            sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            sw.WriteLine("sensor Value High");
            sw.WriteLine(sensor_0_value + "\t" + sensor_1_value + "\t" + sensor_2_value + "\t" + sensor_3_value +
                "\t" + sensor_4_value + "\t" + sensor_5_value + "\t" + sensor_6_value + "\t" + sensor_7_value);

            sw.WriteLine("PMS Value High");
            sw.WriteLine(PMS_log0_value + "\t" + PMS_log1_value + "\t" + PMS_log2_value + "\t" + PMS_log3_value +
                "\t" + PMS_log4_value + "\t" + PMS_log5_value + "\t" + PMS_log6_value + "\t" + PMS_log7_value);
            ;
            sw.WriteLine("PMS -------------------------------------------------------------------------");
            sw.Close();

            string str_ph_1_log = "ph 1 " + Convert.ToString(Convert.ToDouble(PMS_log1_value)) + "\n\r";
            byte[] _ph_1_value = Encoding.ASCII.GetBytes(str_ph_1_log);

            {
                serialPort1.Write(_ph_1_value, 0, _ph_1_value.Length);
                Thread.Sleep(30);
            }

            //SA
            string str_ph_2_log = "ph 2 " + Convert.ToString(Convert.ToDouble(PMS_log2_value)) + "\n\r";
            byte[] _ph_2_value = Encoding.ASCII.GetBytes(str_ph_2_log);

            {
                serialPort1.Write(_ph_2_value, 0, _ph_2_value.Length);
                Thread.Sleep(30);
            }

            //SB
            string str_ph_3_log = "ph 3 " + Convert.ToString(Convert.ToDouble(PMS_log3_value)) + "\n\r";
            byte[] _ph_3_value = Encoding.ASCII.GetBytes(str_ph_3_log);

            {
                serialPort1.Write(_ph_3_value, 0, _ph_3_value.Length);
                Thread.Sleep(30);
            }

            //BA
            string str_ph_4_log = "ph 4 " + Convert.ToString(Convert.ToDouble(PMS_log4_value)) + "\n\r";
            byte[] _ph_4_value = Encoding.ASCII.GetBytes(str_ph_4_log);

            {
                serialPort1.Write(_ph_4_value, 0, _ph_4_value.Length);
                Thread.Sleep(30);
            }

            //BB
            string str_ph_5_log = "ph 5 " + Convert.ToString(Convert.ToDouble(PMS_log5_value)) + "\n\r";
            byte[] _ph_5_value = Encoding.ASCII.GetBytes(str_ph_5_log);

            {
                serialPort1.Write(_ph_5_value, 0, _ph_5_value.Length);
                Thread.Sleep(30);
            }


            string str_ph_6_log = "ph 6 " + Convert.ToString(Convert.ToDouble(PMS_log6_value)) + "\n\r";
            byte[] _ph_6_value = Encoding.ASCII.GetBytes(str_ph_6_log);

            {
                serialPort1.Write(_ph_6_value, 0, _ph_6_value.Length);
                Thread.Sleep(30);
            }

            string str_ph_7_log = "ph 7 " + Convert.ToString(Convert.ToDouble(PMS_log7_value)) + "\n\r";
            byte[] _ph_7_value = Encoding.ASCII.GetBytes(str_ph_7_log);

            {
                serialPort1.Write(_ph_7_value, 0, _ph_7_value.Length);
                Thread.Sleep(30);
            }

            byte[] ASCII_p_d = Encoding.ASCII.GetBytes(_p_d);
            serialPort1.Write(ASCII_p_d, 0, ASCII_p_d.Length);
            Thread.Sleep(3000);
        }

        void Send_ph1_to_ph4()
        {

            StreamWriter sw = new StreamWriter(File_path, true);
            sw.WriteLine("========================================================================================================================");
            sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            sw.WriteLine("sensor Value High");
            sw.WriteLine(sensor_0_value + "\t" + sensor_1_value + "\t" + sensor_2_value + "\t" + sensor_3_value +
                "\t" + sensor_4_value);

            sw.WriteLine("PMS Value High");
            sw.WriteLine(PMS_log0_value + "\t" + PMS_log1_value + "\t" + PMS_log2_value + "\t" + PMS_log4_value +
                "\t" + PMS_log7_value);
            ;
            sw.WriteLine("PMS -------------------------------------------------------------------------");
            sw.Close();

            string str_ph_1_log = "ph 1 " + Convert.ToString(Convert.ToDouble(PMS_log1_value) - pms_reduce) + "\n\r";
            byte[] _ph_1_value = Encoding.ASCII.GetBytes(str_ph_1_log);
            // compare Log and MCU +-3%
            //  if ((Convert.ToDouble(sensor_1_value) > Convert.ToDouble(PMS_log1_value) + 0.3) ||
            //      (Convert.ToDouble(sensor_1_value) < Convert.ToDouble(PMS_log1_value) - 0.3))
            {
                serialPort1.Write(_ph_1_value, 0, _ph_1_value.Length);
                Thread.Sleep(30);
            }

            string str_ph_2_log = "ph 2 " + Convert.ToString(Convert.ToDouble(PMS_log2_value) - pms_reduce) + "\n\r";
            byte[] _ph_2_value = Encoding.ASCII.GetBytes(str_ph_2_log);
            // compare Log and MCU +-3%
            //   if ((Convert.ToDouble(sensor_2_value) > Convert.ToDouble(PMS_log2_value) + 0.3) ||
            //   (Convert.ToDouble(sensor_2_value) < Convert.ToDouble(PMS_log2_value) - 0.3))
            {
                serialPort1.Write(_ph_2_value, 0, _ph_2_value.Length);
                Thread.Sleep(30);
            }

            string str_ph_3_log = "ph 3 " + Convert.ToString(Convert.ToDouble(PMS_log4_value) - pms_reduce) + "\n\r";
            byte[] _ph_3_value = Encoding.ASCII.GetBytes(str_ph_3_log);
            // compare Log and MCU +-3%
            //   if ((Convert.ToDouble(sensor_3_value) > Convert.ToDouble(PMS_log3_value) + 0.3) ||
            //   (Convert.ToDouble(sensor_3_value) < Convert.ToDouble(PMS_log3_value) - 0.3))
            {
                serialPort1.Write(_ph_3_value, 0, _ph_3_value.Length);
                Thread.Sleep(30);
            }

            string str_ph_4_log = "ph 4 " + Convert.ToString(Convert.ToDouble(PMS_log7_value) - pms_reduce - 0.0) + "\n\r";
            byte[] _ph_4_value = Encoding.ASCII.GetBytes(str_ph_4_log);
            // compare Log and MCU +-3%
            //     if ((Convert.ToDouble(sensor_4_value) > Convert.ToDouble(PMS_log4_value) + 0.3) ||
            //    (Convert.ToDouble(sensor_4_value) < Convert.ToDouble(PMS_log4_value) - 0.3))
            {
                serialPort1.Write(_ph_4_value, 0, _ph_4_value.Length);
                Thread.Sleep(30);
            }


            byte[] ASCII_p_d = Encoding.ASCII.GetBytes(_p_d);
            serialPort1.Write(ASCII_p_d, 0, ASCII_p_d.Length);
            Thread.Sleep(50);
            serialPort1.Write(ASCII_p_d, 0, ASCII_p_d.Length);
            Thread.Sleep(3000);
        }

        void Close_flash_loader()
        {
            Process[] Process1 = Process.GetProcessesByName("STMicroelectronics flash loader");
            if (Process1.Length > 0)
            {
                foreach (Process p in Process1)
                {
                    // 關閉目前程序前先等待 1000 毫秒
                    p.WaitForExit(1000);
                    p.Kill();
                }
            }
        }

        void Load_RS232()
        {
            try
            {
                string[] strPortName = System.IO.Ports.SerialPort.GetPortNames();
                if (strPortName.Length > 0)
                {
                    foreach (string cpName in strPortName)
                    {
                        // cbComPort is ComboBox
                        cbx_RS232.Items.Add(cpName);
                    }
                    cbx_RS232.SelectedIndex = cbx_RS232.Items.Count - 1;
                }


                string[] strPortName2 = System.IO.Ports.SerialPort.GetPortNames();
                if (strPortName2.Length > 0)
                {
                    foreach (string cpName in strPortName2)
                    {
                        // cbComPort is ComboBox
                        cbx_RS232_2.Items.Add(cpName);
                    }
                    //   cbx_RS232_2.SelectedIndex = cbx_RS232_2.Items.Count - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        #region Watcher Files


        private void MyFileSystemWatcher()
        {
            try
            {
                //設定所要監控的資料夾
                _watch.Path = @tbx_dir_path.Text;


                //設定所要監控的變更類型
                _watch.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;

                //設定所要監控的檔案
                _watch.Filter = "*.*";

                //設定是否監控子資料夾
                _watch.IncludeSubdirectories = true;

                //設定是否啟動元件，此部分必須要設定為 true，不然事件是不會被觸發的
                _watch.EnableRaisingEvents = true;

                //設定觸發事件
                _watch.Created += new FileSystemEventHandler(_watch_Created);
            }
            catch
            {
                MessageBox.Show("資料夾Error");
            }
            }


        string PMS_file_name = "";
        /// <summary>
        /// 當所監控的資料夾有建立檔時觸發
        /// </summary>
        private void _watch_Created(object sender, FileSystemEventArgs e)
        {
            //dirInfo = new DirectoryInfo(e.FullPath.ToString());

            ////DAQ Create file           
            //File.Copy(dirInfo.FullName, fileName, true);
            //has_start = true;

            //sb = new StringBuilder();
            //dirInfo = new DirectoryInfo(e.FullPath.ToString());

            //PMS_file_name = dirInfo.Name;
            //MessageBox.Show(PMS_file_name);
        }

        # endregion

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        static public class Mouse
        {
            public enum MouseEventTFlags
            {
                LEFTDOWN = 0x00000002,
                LEFTUP = 0x00000004,
                MIDDLEDOWN = 0x00000020,
                MIDDLEUP = 0x00000040,
                MOVE = 0x00000001,
                ABSOLUTE = 0x00008000,
                RIGHTDOWN = 0x00000008,
                RIGHTUP = 0x00000010
            }


            //加入了這行
            [DllImport("User32")]
            public extern static void mouse_event(int dwFlags, int dx, int dy, int dwData, IntPtr dwExtraInfo);



            [DllImport("user32.dll", SetLastError = true)]
            public static extern Int32 SendInput(Int32 cInputs, ref INPUT pInputs, Int32 cbSize);

            [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 28)]
            public struct INPUT
            {
                [FieldOffset(0)]
                public INPUTTYPE dwType;
                [FieldOffset(4)]
                public MOUSEINPUT mi;
                [FieldOffset(4)]
                public KEYBOARDINPUT ki;
                [FieldOffset(4)]
                public HARDWAREINPUT hi;
            }

            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public struct MOUSEINPUT
            {
                public Int32 dx;
                public Int32 dy;
                public Int32 mouseData;
                public MOUSEFLAG dwFlags;
                public Int32 time;
                public IntPtr dwExtraInfo;
            }

            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public struct KEYBOARDINPUT
            {
                public Int16 wVk;
                public Int16 wScan;
                public KEYBOARDFLAG dwFlags;
                public Int32 time;
                public IntPtr dwExtraInfo;
            }

            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public struct HARDWAREINPUT
            {
                public Int32 uMsg;
                public Int16 wParamL;
                public Int16 wParamH;
            }

            public enum INPUTTYPE : int
            {
                Mouse = 0,
                Keyboard = 1,
                Hardware = 2
            }

            [Flags()]
            public enum MOUSEFLAG : int
            {
                MOVE = 0x1,
                LEFTDOWN = 0x2,
                LEFTUP = 0x4,
                RIGHTDOWN = 0x8,
                RIGHTUP = 0x10,
                MIDDLEDOWN = 0x20,
                MIDDLEUP = 0x40,
                XDOWN = 0x80,
                XUP = 0x100,
                VIRTUALDESK = 0x400,
                WHEEL = 0x800,
                ABSOLUTE = 0x8000
            }

            [Flags()]
            public enum KEYBOARDFLAG : int
            {
                EXTENDEDKEY = 1,
                KEYUP = 2,
                UNICODE = 4,
                SCANCODE = 8
            }

            static public void LeftDown()
            {
                INPUT leftdown = new INPUT();

                leftdown.dwType = 0;
                leftdown.mi = new MOUSEINPUT();
                leftdown.mi.dwExtraInfo = IntPtr.Zero;
                leftdown.mi.dx = 0;
                leftdown.mi.dy = 0;
                leftdown.mi.time = 0;
                leftdown.mi.mouseData = 0;
                leftdown.mi.dwFlags = MOUSEFLAG.LEFTDOWN;

                SendInput(1, ref leftdown, Marshal.SizeOf(typeof(INPUT)));
                mouse_event((int)(MouseEventTFlags.LEFTDOWN), 0, 0, 0, IntPtr.Zero);  // 按下            }
            }

            static public void LeftUp()
            {
                INPUT leftup = new INPUT();

                leftup.dwType = 0;
                leftup.mi = new MOUSEINPUT();
                leftup.mi.dwExtraInfo = IntPtr.Zero;
                leftup.mi.dx = 0;
                leftup.mi.dy = 0;
                leftup.mi.time = 0;
                leftup.mi.mouseData = 0;
                leftup.mi.dwFlags = MOUSEFLAG.LEFTUP;

                SendInput(1, ref leftup, Marshal.SizeOf(typeof(INPUT)));
                mouse_event((int)MouseEventTFlags.LEFTUP, 0, 0, 0, IntPtr.Zero); // 起來 
            }

            static public void LeftClick()
            {
                LeftDown();
                Thread.Sleep(50);
                LeftUp();
            }

            static public void LeftDoubleClick()
            {
                LeftClick();
                Thread.Sleep(50);
                LeftClick();
            }

            static public void DragTo(string sor_X, string sor_Y, string des_X, string des_Y)
            {
                MoveTo(sor_X, sor_Y);
                LeftDown();
                Thread.Sleep(200);
                MoveTo(des_X, des_Y);
                LeftUp();
            }

            static public void MoveTo(string tx, string ty)
            {
                int x, y;
                int.TryParse(tx, out x);
                int.TryParse(ty, out y);

                Cursor.Position = new System.Drawing.Point(x, y);
            }
        }

        private void cbx_RS232_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                serialPort2.Close();
                serialPort2.BaudRate = 9600;
                serialPort2.PortName = cbx_RS232_2.SelectedItem.ToString();
                serialPort2.Open();
            }
            catch
            {
                MessageBox.Show("請選擇其它COM PORT");
            }
        }

        Boolean down = true;
        private void button1_Click(object sender, EventArgs e)
        {
            if (down)
            {
                down = false;
                string _0 = "0";
                byte[] _byte_0 = Encoding.ASCII.GetBytes(_0);
                for (int i = 0; i < 30; i++)
                {
                    serialPort2.Write(_byte_0, 0, _byte_0.Length);
                    Thread.Sleep(30);
                }
            }
            else
            {
                down = true;
                string _1 = "1";
                byte[] _byte_1 = Encoding.ASCII.GetBytes(_1);
                for (int i = 0; i < 30; i++)
                {
                    serialPort2.Write(_byte_1, 0, _byte_1.Length);
                    Thread.Sleep(30);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str_on_off = "sim.key 2" + "\n\r";
            byte[] _on_off = Encoding.ASCII.GetBytes(str_on_off);
            {
                serialPort1.Write(_on_off, 0, _on_off.Length);
                Thread.Sleep(50);
            }
        }

        //-------------------------20200507
        private void ph_1_Click(object sender, EventArgs e)
        {          
            string str_ph_1_log = "ph 1 " + Convert.ToString(Convert.ToDouble(2)) + "\n\r";
            byte[] _ph_1_value = Encoding.ASCII.GetBytes(str_ph_1_log);

            {
                serialPort1.Write(_ph_1_value, 0, _ph_1_value.Length);
                Thread.Sleep(30);
            }        
        }

        private void ph_2_Click(object sender, EventArgs e)
        {
            string str_ph_2_log = "ph 2 " + Convert.ToString(Convert.ToDouble(2)) + "\n\r";
            byte[] _ph_2_value = Encoding.ASCII.GetBytes(str_ph_2_log);

            {
                serialPort1.Write(_ph_2_value, 0, _ph_2_value.Length);
                Thread.Sleep(30);
            }
        }

        private void ph_3_Click(object sender, EventArgs e)
        {
            string str_ph_3_log = "ph 3 " + Convert.ToString(Convert.ToDouble(2)) + "\n\r";
            byte[] _ph_3_value = Encoding.ASCII.GetBytes(str_ph_3_log);

            {
                serialPort1.Write(_ph_3_value, 0, _ph_3_value.Length);
                Thread.Sleep(30);
            }
        }

        private void ph_4_Click(object sender, EventArgs e)
        {
            string str_ph_4_log = "ph 4 " + Convert.ToString(Convert.ToDouble(2)) + "\n\r";
            byte[] _ph_4_value = Encoding.ASCII.GetBytes(str_ph_4_log);

            {
                serialPort1.Write(_ph_4_value, 0, _ph_4_value.Length);
                Thread.Sleep(30);
            }
        }

        private void ph_5_Click(object sender, EventArgs e)
        {
            string str_ph_5_log = "ph 5 " + Convert.ToString(Convert.ToDouble(2)) + "\n\r";
            byte[] _ph_5_value = Encoding.ASCII.GetBytes(str_ph_5_log);

            {
                serialPort1.Write(_ph_5_value, 0, _ph_5_value.Length);
                Thread.Sleep(30);
            }
        }

        private void ph_6_Click(object sender, EventArgs e)
        {
            string str_ph_6_log = "ph 6 " + Convert.ToString(Convert.ToDouble(2)) + "\n\r";
            byte[] _ph_6_value = Encoding.ASCII.GetBytes(str_ph_6_log);

            {
                serialPort1.Write(_ph_6_value, 0, _ph_6_value.Length);
                Thread.Sleep(30);
            }
        }

        private void ph_7_Click(object sender, EventArgs e)
        {
            string str_ph_7_log = "ph 7 " + Convert.ToString(Convert.ToDouble(2)) + "\n\r";
            byte[] _ph_7_value = Encoding.ASCII.GetBytes(str_ph_7_log);

            {
                serialPort1.Write(_ph_7_value, 0, _ph_7_value.Length);
                Thread.Sleep(30);
            }
        }
        //-------------------------20200507
    }
}