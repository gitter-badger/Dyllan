using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TD.SandDock;

namespace ImpossibleMission.Widget
{
    public enum UCTabbedStatus
    {
        Default = 0,
        SaveVisible = 0x01,
        SaveTEnable = 0x02,
        SaveEnable = 0x03,
        AllowTitleChange = 0x04,
        RefreshVisible = 0x08,
        RefreshTEnable = 0x10,
        RefreshEnable = 0x18,
    }

    public class UCTabbedDocument : UserControl
    {
        public UCTabbedDocument()
        {
            _guiTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            _tabbedStatus = UCTabbedStatus.Default;
        }

        protected readonly TaskScheduler _guiTaskScheduler;

        protected UCTabbedStatus _tabbedStatus;
        public UCTabbedStatus TabbedStatus
        {
            get
            {
                return _tabbedStatus;
            }
        }

        public virtual void Execute()
        {
        }

        public virtual void SelfRefresh(bool fauseRefresh = true)
        { }

        public virtual string Title
        {
            get;
        }

        public virtual void Rename()
        {
        }
    }
}
