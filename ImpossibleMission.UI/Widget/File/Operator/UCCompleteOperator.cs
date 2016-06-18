using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImpossibleMission.Controller.File;
using ImpossibleMission.Model;

namespace ImpossibleMission.Widget.File
{
    public partial class UCCompleteOperator : UCTabbedDocument
    {
        private Plan _plan;
        public Plan Plan
        {
            get
            {
                return _plan;
            }
        }
        private CompletePlanOperatorTransaction _transaction;
        public UCCompleteOperator(Plan plan)
        {
            InitializeComponent();
            _transaction = new CompletePlanOperatorTransaction(plan);
            _plan = plan;
        }

        private void InitialData()
        {
            rtxReview.Text = _transaction.Review;
        }

        private void rtxReview_TextChanged(object sender, EventArgs e)
        {
            _transaction.Review = rtxReview.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Task task = Task.Run(new Action(_transaction.Execute));
            task.ContinueWith(RestoreStatus, _guiTaskScheduler);
        }

        private void RestoreStatus(Task task)
        {
            this.Enabled = true;
            InitialData();
        }
    }
}
