using ImpossibleMission.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImpossibleMission
{
    public partial class GetITBook : Form
    {
        private GetBooksTransaction _transaction = new GetBooksTransaction();
        private static GetITBook _instance = new GetITBook();
        protected readonly TaskScheduler _guiTaskScheduler;
        public static GetITBook Instance
        {
            get
            {
                return _instance;
            }
        }

        private GetITBook()
        {
            InitializeComponent();
            _guiTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            InitialData();
        }

        private void InitialData()
        {
            txtStartIndex.Text = (_transaction.LastValidNumber + 1).ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Task task = Task.Run(new Action(_transaction.Start));
            this.Enabled = false;
            task.ContinueWith(RestoreStatus, _guiTaskScheduler);
        }

        private void btnDownloadMissed_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Task task = Task.Run(new Action(_transaction.DownloadMissedBooks));
            task.ContinueWith(RestoreStatus, _guiTaskScheduler);
        }

        private void RestoreStatus(Task task)
        {
            this.Enabled = true;
            InitialData();
        }

        private void StatusChanged()
        {
            if (!string.IsNullOrEmpty(txtStartIndex.Text))
            _transaction.StartIndex = int.Parse(txtStartIndex.Text);
            _transaction.IncludeNotFound = chkIncludeNotFound.Checked;
            if (!string.IsNullOrEmpty(txtStartNum.Text))
                _transaction.StartNum = int.Parse(txtStartNum.Text);
            if (!string.IsNullOrEmpty(txtEndNum.Text))
                _transaction.EndNum = int.Parse(txtEndNum.Text);
            _transaction.Folder = txtFolder.Text;
        }

        private void Number_TextChanged(object sender, EventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            txtBox.Text = Constant.NumberRegex.Match(txtBox.Text).Value;
            StatusChanged();
        }

        private void GetITBook_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void chkIncludeNotFound_CheckedChanged(object sender, EventArgs e)
        {
            StatusChanged();
        }

        private void btnGetRealUrl_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Task task = Task.Run(new Action(_transaction.GetRealDownloadUrls));
            task.ContinueWith(RestoreStatus, _guiTaskScheduler);
        }

        private void txtFolder_DoubleClick(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtFolder.Text = fbd.SelectedPath;
            }
        }

        private void btnUpdateDownloaded_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Task task = Task.Run(new Action(_transaction.UpdateDownloaded));
            task.ContinueWith(RestoreStatus, _guiTaskScheduler);
        }

        private void txtFolder_TextChanged(object sender, EventArgs e)
        {
            StatusChanged();
        }

        private void btnUpdateLocalFiles_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Task task = Task.Run(new Action(_transaction.UpdateLocalFiles));
            task.ContinueWith(RestoreStatus, _guiTaskScheduler);
        }
    }
}
