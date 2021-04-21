namespace Auto_Calibration
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbl_sensor1 = new System.Windows.Forms.Label();
            this.lbl_sensor2 = new System.Windows.Forms.Label();
            this.lbl_sensor3 = new System.Windows.Forms.Label();
            this.lbl_sensor4 = new System.Windows.Forms.Label();
            this.lbl_sensor5 = new System.Windows.Forms.Label();
            this.lbl_sensor6 = new System.Windows.Forms.Label();
            this.lbl_sensor7 = new System.Windows.Forms.Label();
            this.lbl_sensor8 = new System.Windows.Forms.Label();
            this.lbl_sensor9 = new System.Windows.Forms.Label();
            this.lbl_sensor0 = new System.Windows.Forms.Label();
            this.backgroundWorker_Sensor = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_start = new System.Windows.Forms.Button();
            this.tbx_dir_path = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.cbx_RS232 = new System.Windows.Forms.ComboBox();
            this.lbl_PMS0 = new System.Windows.Forms.Label();
            this.lbl_PMS9 = new System.Windows.Forms.Label();
            this.lbl_PMS8 = new System.Windows.Forms.Label();
            this.lbl_PMS7 = new System.Windows.Forms.Label();
            this.lbl_PMS6 = new System.Windows.Forms.Label();
            this.lbl_PMS5 = new System.Windows.Forms.Label();
            this.lbl_PMS4 = new System.Windows.Forms.Label();
            this.lbl_PMS3 = new System.Windows.Forms.Label();
            this.lbl_PMS2 = new System.Windows.Forms.Label();
            this.lbl_PMS1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbx_model = new System.Windows.Forms.ComboBox();
            this.btn_burn_firmware = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_RS232_2 = new System.Windows.Forms.ComboBox();
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ph_1 = new System.Windows.Forms.Button();
            this.ph_2 = new System.Windows.Forms.Button();
            this.ph_3 = new System.Windows.Forms.Button();
            this.ph_4 = new System.Windows.Forms.Button();
            this.ph_5 = new System.Windows.Forms.Button();
            this.ph_6 = new System.Windows.Forms.Button();
            this.ph_7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_sensor1
            // 
            this.lbl_sensor1.AutoSize = true;
            this.lbl_sensor1.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sensor1.Location = new System.Drawing.Point(3, 270);
            this.lbl_sensor1.Name = "lbl_sensor1";
            this.lbl_sensor1.Size = new System.Drawing.Size(15, 16);
            this.lbl_sensor1.TabIndex = 1;
            this.lbl_sensor1.Text = "0";
            // 
            // lbl_sensor2
            // 
            this.lbl_sensor2.AutoSize = true;
            this.lbl_sensor2.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sensor2.Location = new System.Drawing.Point(3, 290);
            this.lbl_sensor2.Name = "lbl_sensor2";
            this.lbl_sensor2.Size = new System.Drawing.Size(15, 16);
            this.lbl_sensor2.TabIndex = 2;
            this.lbl_sensor2.Text = "0";
            // 
            // lbl_sensor3
            // 
            this.lbl_sensor3.AutoSize = true;
            this.lbl_sensor3.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sensor3.Location = new System.Drawing.Point(3, 310);
            this.lbl_sensor3.Name = "lbl_sensor3";
            this.lbl_sensor3.Size = new System.Drawing.Size(15, 16);
            this.lbl_sensor3.TabIndex = 3;
            this.lbl_sensor3.Text = "0";
            // 
            // lbl_sensor4
            // 
            this.lbl_sensor4.AutoSize = true;
            this.lbl_sensor4.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sensor4.Location = new System.Drawing.Point(3, 330);
            this.lbl_sensor4.Name = "lbl_sensor4";
            this.lbl_sensor4.Size = new System.Drawing.Size(15, 16);
            this.lbl_sensor4.TabIndex = 4;
            this.lbl_sensor4.Text = "0";
            // 
            // lbl_sensor5
            // 
            this.lbl_sensor5.AutoSize = true;
            this.lbl_sensor5.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sensor5.Location = new System.Drawing.Point(3, 350);
            this.lbl_sensor5.Name = "lbl_sensor5";
            this.lbl_sensor5.Size = new System.Drawing.Size(15, 16);
            this.lbl_sensor5.TabIndex = 5;
            this.lbl_sensor5.Text = "0";
            // 
            // lbl_sensor6
            // 
            this.lbl_sensor6.AutoSize = true;
            this.lbl_sensor6.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sensor6.Location = new System.Drawing.Point(3, 370);
            this.lbl_sensor6.Name = "lbl_sensor6";
            this.lbl_sensor6.Size = new System.Drawing.Size(15, 16);
            this.lbl_sensor6.TabIndex = 6;
            this.lbl_sensor6.Text = "0";
            // 
            // lbl_sensor7
            // 
            this.lbl_sensor7.AutoSize = true;
            this.lbl_sensor7.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sensor7.Location = new System.Drawing.Point(3, 390);
            this.lbl_sensor7.Name = "lbl_sensor7";
            this.lbl_sensor7.Size = new System.Drawing.Size(15, 16);
            this.lbl_sensor7.TabIndex = 7;
            this.lbl_sensor7.Text = "0";
            // 
            // lbl_sensor8
            // 
            this.lbl_sensor8.AutoSize = true;
            this.lbl_sensor8.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sensor8.Location = new System.Drawing.Point(3, 410);
            this.lbl_sensor8.Name = "lbl_sensor8";
            this.lbl_sensor8.Size = new System.Drawing.Size(15, 16);
            this.lbl_sensor8.TabIndex = 8;
            this.lbl_sensor8.Text = "0";
            // 
            // lbl_sensor9
            // 
            this.lbl_sensor9.AutoSize = true;
            this.lbl_sensor9.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sensor9.Location = new System.Drawing.Point(3, 430);
            this.lbl_sensor9.Name = "lbl_sensor9";
            this.lbl_sensor9.Size = new System.Drawing.Size(15, 16);
            this.lbl_sensor9.TabIndex = 9;
            this.lbl_sensor9.Text = "0";
            // 
            // lbl_sensor0
            // 
            this.lbl_sensor0.AutoSize = true;
            this.lbl_sensor0.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sensor0.Location = new System.Drawing.Point(3, 250);
            this.lbl_sensor0.Name = "lbl_sensor0";
            this.lbl_sensor0.Size = new System.Drawing.Size(15, 16);
            this.lbl_sensor0.TabIndex = 10;
            this.lbl_sensor0.Text = "0";
            // 
            // backgroundWorker_Sensor
            // 
            this.backgroundWorker_Sensor.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_Sensor_DoWork);
            this.backgroundWorker_Sensor.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_Sensor_ProgressChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_start
            // 
            this.btn_start.Font = new System.Drawing.Font("PMingLiU", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_start.Location = new System.Drawing.Point(12, 205);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(119, 37);
            this.btn_start.TabIndex = 12;
            this.btn_start.Text = "Start Calibration";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // tbx_dir_path
            // 
            this.tbx_dir_path.Location = new System.Drawing.Point(9, 503);
            this.tbx_dir_path.Name = "tbx_dir_path";
            this.tbx_dir_path.Size = new System.Drawing.Size(171, 22);
            this.tbx_dir_path.TabIndex = 13;
            this.tbx_dir_path.Text = "E:\\T047-001-01 Test Log\\2015";
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // cbx_RS232
            // 
            this.cbx_RS232.FormattingEnabled = true;
            this.cbx_RS232.Location = new System.Drawing.Point(88, 10);
            this.cbx_RS232.Name = "cbx_RS232";
            this.cbx_RS232.Size = new System.Drawing.Size(121, 20);
            this.cbx_RS232.TabIndex = 14;
            this.cbx_RS232.SelectedIndexChanged += new System.EventHandler(this.cbx_RS232_SelectedIndexChanged);
            // 
            // lbl_PMS0
            // 
            this.lbl_PMS0.AutoSize = true;
            this.lbl_PMS0.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PMS0.Location = new System.Drawing.Point(101, 250);
            this.lbl_PMS0.Name = "lbl_PMS0";
            this.lbl_PMS0.Size = new System.Drawing.Size(15, 16);
            this.lbl_PMS0.TabIndex = 29;
            this.lbl_PMS0.Text = "0";
            // 
            // lbl_PMS9
            // 
            this.lbl_PMS9.AutoSize = true;
            this.lbl_PMS9.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PMS9.Location = new System.Drawing.Point(101, 430);
            this.lbl_PMS9.Name = "lbl_PMS9";
            this.lbl_PMS9.Size = new System.Drawing.Size(15, 16);
            this.lbl_PMS9.TabIndex = 28;
            this.lbl_PMS9.Text = "0";
            // 
            // lbl_PMS8
            // 
            this.lbl_PMS8.AutoSize = true;
            this.lbl_PMS8.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PMS8.Location = new System.Drawing.Point(101, 410);
            this.lbl_PMS8.Name = "lbl_PMS8";
            this.lbl_PMS8.Size = new System.Drawing.Size(15, 16);
            this.lbl_PMS8.TabIndex = 27;
            this.lbl_PMS8.Text = "0";
            // 
            // lbl_PMS7
            // 
            this.lbl_PMS7.AutoSize = true;
            this.lbl_PMS7.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PMS7.Location = new System.Drawing.Point(101, 390);
            this.lbl_PMS7.Name = "lbl_PMS7";
            this.lbl_PMS7.Size = new System.Drawing.Size(15, 16);
            this.lbl_PMS7.TabIndex = 26;
            this.lbl_PMS7.Text = "0";
            // 
            // lbl_PMS6
            // 
            this.lbl_PMS6.AutoSize = true;
            this.lbl_PMS6.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PMS6.Location = new System.Drawing.Point(101, 370);
            this.lbl_PMS6.Name = "lbl_PMS6";
            this.lbl_PMS6.Size = new System.Drawing.Size(15, 16);
            this.lbl_PMS6.TabIndex = 25;
            this.lbl_PMS6.Text = "0";
            // 
            // lbl_PMS5
            // 
            this.lbl_PMS5.AutoSize = true;
            this.lbl_PMS5.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PMS5.Location = new System.Drawing.Point(101, 350);
            this.lbl_PMS5.Name = "lbl_PMS5";
            this.lbl_PMS5.Size = new System.Drawing.Size(15, 16);
            this.lbl_PMS5.TabIndex = 24;
            this.lbl_PMS5.Text = "0";
            // 
            // lbl_PMS4
            // 
            this.lbl_PMS4.AutoSize = true;
            this.lbl_PMS4.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PMS4.Location = new System.Drawing.Point(101, 330);
            this.lbl_PMS4.Name = "lbl_PMS4";
            this.lbl_PMS4.Size = new System.Drawing.Size(15, 16);
            this.lbl_PMS4.TabIndex = 23;
            this.lbl_PMS4.Text = "0";
            // 
            // lbl_PMS3
            // 
            this.lbl_PMS3.AutoSize = true;
            this.lbl_PMS3.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PMS3.Location = new System.Drawing.Point(101, 310);
            this.lbl_PMS3.Name = "lbl_PMS3";
            this.lbl_PMS3.Size = new System.Drawing.Size(15, 16);
            this.lbl_PMS3.TabIndex = 22;
            this.lbl_PMS3.Text = "0";
            // 
            // lbl_PMS2
            // 
            this.lbl_PMS2.AutoSize = true;
            this.lbl_PMS2.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PMS2.Location = new System.Drawing.Point(101, 290);
            this.lbl_PMS2.Name = "lbl_PMS2";
            this.lbl_PMS2.Size = new System.Drawing.Size(15, 16);
            this.lbl_PMS2.TabIndex = 21;
            this.lbl_PMS2.Text = "0";
            // 
            // lbl_PMS1
            // 
            this.lbl_PMS1.AutoSize = true;
            this.lbl_PMS1.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PMS1.Location = new System.Drawing.Point(101, 270);
            this.lbl_PMS1.Name = "lbl_PMS1";
            this.lbl_PMS1.Size = new System.Drawing.Size(15, 16);
            this.lbl_PMS1.TabIndex = 20;
            this.lbl_PMS1.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 18);
            this.label1.TabIndex = 30;
            this.label1.Text = "Com Port:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox1.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Bold);
            this.textBox1.ForeColor = System.Drawing.Color.Red;
            this.textBox1.Location = new System.Drawing.Point(12, 75);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(197, 124);
            this.textBox1.TabIndex = 31;
            this.textBox1.Text = "1.確定氣管全部未接，並執行完歸零按鈕 ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 18);
            this.label3.TabIndex = 33;
            this.label3.Text = "機型:";
            // 
            // cbx_model
            // 
            this.cbx_model.FormattingEnabled = true;
            this.cbx_model.Items.AddRange(new object[] {
            "C100",
            "C200"});
            this.cbx_model.Location = new System.Drawing.Point(88, 39);
            this.cbx_model.Name = "cbx_model";
            this.cbx_model.Size = new System.Drawing.Size(121, 20);
            this.cbx_model.TabIndex = 32;
            this.cbx_model.SelectedIndexChanged += new System.EventHandler(this.cbx_model_SelectedIndexChanged);
            // 
            // btn_burn_firmware
            // 
            this.btn_burn_firmware.Font = new System.Drawing.Font("PMingLiU", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_burn_firmware.Location = new System.Drawing.Point(12, 451);
            this.btn_burn_firmware.Name = "btn_burn_firmware";
            this.btn_burn_firmware.Size = new System.Drawing.Size(119, 37);
            this.btn_burn_firmware.TabIndex = 34;
            this.btn_burn_firmware.Text = "Write firmware";
            this.btn_burn_firmware.UseVisualStyleBackColor = true;
            this.btn_burn_firmware.Click += new System.EventHandler(this.btn_burn_firmware_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(9, 542);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(913, 407);
            this.textBox2.TabIndex = 35;
            this.textBox2.Text = "E:\\T047-001-01 Test Log\\2015";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(215, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 18);
            this.label2.TabIndex = 37;
            this.label2.Text = "Com Port2:";
            // 
            // cbx_RS232_2
            // 
            this.cbx_RS232_2.FormattingEnabled = true;
            this.cbx_RS232_2.Location = new System.Drawing.Point(297, 11);
            this.cbx_RS232_2.Name = "cbx_RS232_2";
            this.cbx_RS232_2.Size = new System.Drawing.Size(121, 20);
            this.cbx_RS232_2.TabIndex = 36;
            this.cbx_RS232_2.SelectedIndexChanged += new System.EventHandler(this.cbx_RS232_2_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(297, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 35);
            this.button1.TabIndex = 38;
            this.button1.Text = "扶手-開/關";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.Location = new System.Drawing.Point(297, 150);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 35);
            this.button2.TabIndex = 39;
            this.button2.Text = "主機-開/關";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ph_1
            // 
            this.ph_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ph_1.Location = new System.Drawing.Point(736, 12);
            this.ph_1.Name = "ph_1";
            this.ph_1.Size = new System.Drawing.Size(170, 35);
            this.ph_1.TabIndex = 40;
            this.ph_1.Text = "ph 1";
            this.ph_1.UseVisualStyleBackColor = true;
            this.ph_1.Click += new System.EventHandler(this.ph_1_Click);
            // 
            // ph_2
            // 
            this.ph_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ph_2.Location = new System.Drawing.Point(736, 53);
            this.ph_2.Name = "ph_2";
            this.ph_2.Size = new System.Drawing.Size(170, 35);
            this.ph_2.TabIndex = 41;
            this.ph_2.Text = "ph 2";
            this.ph_2.UseVisualStyleBackColor = true;
            this.ph_2.Click += new System.EventHandler(this.ph_2_Click);
            // 
            // ph_3
            // 
            this.ph_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ph_3.Location = new System.Drawing.Point(736, 94);
            this.ph_3.Name = "ph_3";
            this.ph_3.Size = new System.Drawing.Size(170, 35);
            this.ph_3.TabIndex = 42;
            this.ph_3.Text = "ph 3";
            this.ph_3.UseVisualStyleBackColor = true;
            this.ph_3.Click += new System.EventHandler(this.ph_3_Click);
            // 
            // ph_4
            // 
            this.ph_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ph_4.Location = new System.Drawing.Point(736, 135);
            this.ph_4.Name = "ph_4";
            this.ph_4.Size = new System.Drawing.Size(170, 35);
            this.ph_4.TabIndex = 43;
            this.ph_4.Text = "ph 4";
            this.ph_4.UseVisualStyleBackColor = true;
            this.ph_4.Click += new System.EventHandler(this.ph_4_Click);
            // 
            // ph_5
            // 
            this.ph_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ph_5.Location = new System.Drawing.Point(736, 176);
            this.ph_5.Name = "ph_5";
            this.ph_5.Size = new System.Drawing.Size(170, 35);
            this.ph_5.TabIndex = 44;
            this.ph_5.Text = "ph 5";
            this.ph_5.UseVisualStyleBackColor = true;
            this.ph_5.Click += new System.EventHandler(this.ph_5_Click);
            // 
            // ph_6
            // 
            this.ph_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ph_6.Location = new System.Drawing.Point(736, 217);
            this.ph_6.Name = "ph_6";
            this.ph_6.Size = new System.Drawing.Size(170, 35);
            this.ph_6.TabIndex = 45;
            this.ph_6.Text = "ph 6";
            this.ph_6.UseVisualStyleBackColor = true;
            this.ph_6.Click += new System.EventHandler(this.ph_6_Click);
            // 
            // ph_7
            // 
            this.ph_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ph_7.Location = new System.Drawing.Point(736, 258);
            this.ph_7.Name = "ph_7";
            this.ph_7.Size = new System.Drawing.Size(170, 35);
            this.ph_7.TabIndex = 46;
            this.ph_7.Text = "ph 7";
            this.ph_7.UseVisualStyleBackColor = true;
            this.ph_7.Click += new System.EventHandler(this.ph_7_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1512, 960);
            this.Controls.Add(this.ph_7);
            this.Controls.Add(this.ph_6);
            this.Controls.Add(this.ph_5);
            this.Controls.Add(this.ph_4);
            this.Controls.Add(this.ph_3);
            this.Controls.Add(this.ph_2);
            this.Controls.Add(this.ph_1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbx_RS232_2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btn_burn_firmware);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbx_model);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_PMS0);
            this.Controls.Add(this.lbl_PMS9);
            this.Controls.Add(this.lbl_PMS8);
            this.Controls.Add(this.lbl_PMS7);
            this.Controls.Add(this.lbl_PMS6);
            this.Controls.Add(this.lbl_PMS5);
            this.Controls.Add(this.lbl_PMS4);
            this.Controls.Add(this.lbl_PMS3);
            this.Controls.Add(this.lbl_PMS2);
            this.Controls.Add(this.lbl_PMS1);
            this.Controls.Add(this.cbx_RS232);
            this.Controls.Add(this.tbx_dir_path);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.lbl_sensor0);
            this.Controls.Add(this.lbl_sensor9);
            this.Controls.Add(this.lbl_sensor8);
            this.Controls.Add(this.lbl_sensor7);
            this.Controls.Add(this.lbl_sensor6);
            this.Controls.Add(this.lbl_sensor5);
            this.Controls.Add(this.lbl_sensor4);
            this.Controls.Add(this.lbl_sensor3);
            this.Controls.Add(this.lbl_sensor2);
            this.Controls.Add(this.lbl_sensor1);
            this.Name = "Form1";
            this.Text = "Pressure Sensor Calibration 20191002";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_sensor1;
        private System.Windows.Forms.Label lbl_sensor2;
        private System.Windows.Forms.Label lbl_sensor3;
        private System.Windows.Forms.Label lbl_sensor4;
        private System.Windows.Forms.Label lbl_sensor5;
        private System.Windows.Forms.Label lbl_sensor6;
        private System.Windows.Forms.Label lbl_sensor7;
        private System.Windows.Forms.Label lbl_sensor8;
        private System.Windows.Forms.Label lbl_sensor9;
        private System.Windows.Forms.Label lbl_sensor0;
        private System.ComponentModel.BackgroundWorker backgroundWorker_Sensor;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.TextBox tbx_dir_path;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox cbx_RS232;
        private System.Windows.Forms.Label lbl_PMS0;
        private System.Windows.Forms.Label lbl_PMS9;
        private System.Windows.Forms.Label lbl_PMS8;
        private System.Windows.Forms.Label lbl_PMS7;
        private System.Windows.Forms.Label lbl_PMS6;
        private System.Windows.Forms.Label lbl_PMS5;
        private System.Windows.Forms.Label lbl_PMS4;
        private System.Windows.Forms.Label lbl_PMS3;
        private System.Windows.Forms.Label lbl_PMS2;
        private System.Windows.Forms.Label lbl_PMS1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbx_model;
        private System.Windows.Forms.Button btn_burn_firmware;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbx_RS232_2;
        private System.IO.Ports.SerialPort serialPort2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button ph_1;
        private System.Windows.Forms.Button ph_2;
        private System.Windows.Forms.Button ph_3;
        private System.Windows.Forms.Button ph_4;
        private System.Windows.Forms.Button ph_5;
        private System.Windows.Forms.Button ph_6;
        private System.Windows.Forms.Button ph_7;
    }
}

