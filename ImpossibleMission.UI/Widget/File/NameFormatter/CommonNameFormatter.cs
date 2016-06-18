using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImpossibleMission.Model;
using System.Text.RegularExpressions;
using ImpossibleMission.Controller;

namespace ImpossibleMission.Widget.File
{
    public partial class CommonNameFormatter : UserControl
    {
        NameFormatterTransaction _transaction = new NameFormatterTransaction();
        private NameFormatter _nameFormatter;
        public CommonNameFormatter()
        {
            InitializeComponent();
            InitialData();
        }

        public Transaction Transaction
        {
            get
            {
                return _transaction;
            }
        }

        public NameFormatter NameFormatter
        {
            get
            {
                return _transaction.NameFormatter;
            }
        }

        public FormatterArgs Args
        {
            get
            {
                _transaction.Execute();
                return _transaction.Args;
            }
        }

        private void TxtChanged(object sender, EventArgs e)
        {
            BindData();
            rtxPreview.Text = _transaction.Preview;
        }

        private void Number_TextChanged(object sender, EventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            txtBox.Text = Constant.NumberRegex.Match(txtBox.Text).Value;
            TxtChanged(sender, e);
        }

        private void InitialData()
        {
            _nameFormatter = _transaction.NameFormatter;
        }

        private void BindData()
        {
            _transaction.NameFormatter = _nameFormatter;
            _transaction.TextFormatter = txtGenerateTemplate.Text;
            _transaction.TextItemCount = txtItemCount.Text;
            _transaction.TextStartNumber = txtStartNumber.Text;
            _transaction.TextIncrement = txtIncrement.Text;
        }
    }
}
