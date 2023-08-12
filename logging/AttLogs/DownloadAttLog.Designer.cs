
namespace AttLogs
{
    partial class DownloadAttLog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDownload = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_fp_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_fp_user_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(18, 15);
            this.btnDownload.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(112, 36);
            this.btnDownload.TabIndex = 0;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_fp_id,
            this.col_fp_user_id,
            this.col_date,
            this.col_time,
            this.col_code});
            this.dataGridView1.Location = new System.Drawing.Point(18, 60);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1053, 486);
            this.dataGridView1.TabIndex = 1;
            // 
            // col_id
            // 
            this.col_id.DataPropertyName = "col_id";
            this.col_id.HeaderText = "ID";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            // 
            // col_fp_id
            // 
            this.col_fp_id.DataPropertyName = "col_fp_id";
            this.col_fp_id.HeaderText = "Device ID";
            this.col_fp_id.Name = "col_fp_id";
            this.col_fp_id.ReadOnly = true;
            this.col_fp_id.Width = 150;
            // 
            // col_fp_user_id
            // 
            this.col_fp_user_id.DataPropertyName = "col_fp_user_id";
            this.col_fp_user_id.HeaderText = "User ID";
            this.col_fp_user_id.Name = "col_fp_user_id";
            this.col_fp_user_id.ReadOnly = true;
            this.col_fp_user_id.Width = 150;
            // 
            // col_date
            // 
            this.col_date.DataPropertyName = "col_date";
            this.col_date.HeaderText = "Date";
            this.col_date.Name = "col_date";
            this.col_date.ReadOnly = true;
            this.col_date.Width = 150;
            // 
            // col_time
            // 
            this.col_time.DataPropertyName = "col_time";
            this.col_time.HeaderText = "Time";
            this.col_time.Name = "col_time";
            this.col_time.ReadOnly = true;
            this.col_time.Width = 150;
            // 
            // col_code
            // 
            this.col_code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_code.DataPropertyName = "col_code";
            this.col_code.HeaderText = "Code";
            this.col_code.Name = "col_code";
            this.col_code.ReadOnly = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(189, 15);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(157, 33);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "192.168.1.202";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(414, 15);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(98, 33);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "4370";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(146, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(354, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(640, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "State : Not Connect";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(959, 15);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 33);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Upload";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(520, 15);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(112, 33);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(793, 17);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(159, 30);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "ສະເພາະມື້ນີ້ + ມື້ວານ";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // DownloadAttLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 561);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnDownload);
            this.Font = new System.Drawing.Font("XiengThong MX", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximumSize = new System.Drawing.Size(1387, 1161);
            this.Name = "DownloadAttLog";
            this.Text = "DownloadAttLog";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fp_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fp_user_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_code;
    }
}