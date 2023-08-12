using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AttLogs
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in Application.OpenForms)
            {
                if (item is formConfiguration frmu)
                {
                    frmu.Activate();
                    return;
                }
            }
            var frm = new formConfiguration();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            
            frm.Show();
        }

        private void downloadAttendanceLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in Application.OpenForms)
            {
                if (item is DownloadAttLog frmu)
                {
                    frmu.Activate();
                    return;
                }
            }
            var frm = new DownloadAttLog();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }
    }
}
