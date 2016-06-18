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

namespace ImpossibleMission.Widget.File
{
    public partial class UCDailyItemOperator : UCTabbedDocument
    {
        protected readonly Plan _plan;
        public Plan Plan
        {
            get
            {
                return _plan;
            }
        }

        // TODO: Remove
        public UCDailyItemOperator() : this(null)
        { }

        public UCDailyItemOperator(Plan plan)
        {
            InitializeComponent();
            _plan = plan;
        }
    }
}
