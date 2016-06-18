using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImpossibleMission.Dialog
{
    public enum DialogButton
    {
        OK = 0x01,
        Cancel = 0x02,
        Ignore = 0x04,
        OKCancel = 0x03,
        OKIgnoreCancel = 0x07
    }

    public partial class Prompt : Form
    {
        public Prompt()
        {
            InitializeComponent();
        }

        public string Title
        {
            get
            {
                return this.Text;
            }
            set
            {
                this.Text = value;
            }
        }

        public string Description
        {
            get
            {
                return lblDescription.Text;
            }
            set
            {
                lblDescription.Text = value;
            }
        }

        public string Content
        {
            get
            {
                return txtContent.Text;
            }
            set
            {
                txtContent.Text = value;
            }
        }

        private DialogButton dialogButtons;
        public DialogButton DialogButtons
        {
            get
            {
                return dialogButtons;
            }
            set
            {
                dialogButtons = value;
                btnOK.Visible = (dialogButtons & DialogButton.OK) == DialogButton.OK;
                btnIgnore.Visible = (dialogButtons & DialogButton.Ignore) == DialogButton.Ignore;
                btnCancel.Visible = (dialogButtons & DialogButton.Cancel) == DialogButton.Cancel;

            }
        }


        public void InitialMode(string command)
        {
            switch (command)
            {
                case "ChoosePlanName":
                    Title = "Choose Name";
                    Description = "Enter a name for the plan:";
                    DialogButtons = DialogButton.OKCancel;
                    break;
                default:
                    break;
            }
        }
    }
}
