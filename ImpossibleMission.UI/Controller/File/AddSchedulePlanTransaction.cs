using ImpossibleMission.Contract;
using ImpossibleMission.Model;
using System;
using System.Windows.Forms;

namespace ImpossibleMission.Controller.File
{
    public class AddSchedulePlanTransaction : Transaction
    {
        #region Implement ITransaction
        public override void Execute()
        {
            try
            {
                _plan = new SchedulePlan(_executeDate);
                if (!ChooseName())
                    return;
                _plan.Name = Name;
                _plan.Details = Details;
                _plan.SetParameter(StartIndex, EndIndex, WeekDayWorkload, WeekendWorkload, Buffer);
                IPlanManager _planManager = ManagerFactory.GetPlanManager(_plan);
                _planManager.CreatePlan(_plan);
                AddMessage("Save successed!", MessageType.Success);
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message, MessageType.Error);
            }
        }

        #endregion

        #region Private Methods

        private Dialog.Prompt _prompt;

        public bool ChooseName(bool ignoreExistName = false)
        {
            if (!ignoreExistName && !string.IsNullOrEmpty(_name))
                return true;

            if (_prompt == null)
            {
                _prompt = new Dialog.Prompt();
                _prompt.InitialMode("ChoosePlanName");
                _prompt.Content = Name;
            }

            if (_prompt.ShowDialog() == DialogResult.OK)
            {
                Name = _prompt.Content;
                return true;
            }
            return false;
        }

        #endregion

        #region input

        private void CheckParamters()
        {
            // TODO:
        }

        public string Details
        {
            get;
            set;
        }

        private DateTime _executeDate = DateTime.Now.Date;
        public DateTime ExecuteDate
        {
            get
            {
                return _executeDate;
            }
            set
            {
                _executeDate = value;
            }
        }

        private string _name;
        private int _weekDayWorkload;
        private int _weekendWorkload;
        private int _startIndex;
        private int _endIndex;
        private float _buffer;

        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(_name))
                {
                    return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public int WeekDayWorkload
        {
            get
            {
                return _weekDayWorkload;
            }
            set
            {
                _weekDayWorkload = value;
            }
        }

        public int WeekendWorkload
        {
            get
            {
                return _weekendWorkload;
            }
            set
            {
                _weekendWorkload = value;
            }
        }

        public int StartIndex
        {
            get
            {
                return _startIndex;
            }
            set
            {
                _startIndex = value;
            }
        }

        public int EndIndex
        {
            get
            {
                return _endIndex;
            }
            set
            {
                _endIndex = value;
            }
        }

        public float Buffer
        {
            get
            {
                return _buffer;
            }
            set
            {
                _buffer = value;
            }
        }

        public int Amount
        {
            get
            {
                return _endIndex - _startIndex + 1;
            }
        }

        public DateTime? EndDate
        {
            get
            {
                try
                {
                    return SchedulePlan.GetEndDate(ExecuteDate, StartIndex, EndIndex, WeekDayWorkload, WeekendWorkload, Buffer);
                }
                catch
                {
                    return null;
                }
            }
        }

        #endregion

        #region output
        SchedulePlan _plan = null;
        #endregion
    }
}
