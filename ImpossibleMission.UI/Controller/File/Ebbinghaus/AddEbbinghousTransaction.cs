using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpossibleMission.Model;
using System.Windows.Forms;
using ImpossibleMission.Contract;

namespace ImpossibleMission.Controller.File.Ebbinghaus
{
    public class AddEbbinghousTransaction : Transaction
    {
        #region Implement ITransaction
        public override void Execute()
        {
            try
            {
                _plan = PlanFactory.CreatePlan(GetPlanType(), ExecuteDate, NameFormatter, _args);
                if (!ChooseName())
                    return;
                _plan.Name = Name;
                _plan.Details = Details;
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
        private Type GetPlanType()
        {
            Type planType = null;

            if (ebbinghausTemplate is CommonEbbinghausTemplate)
            {
                planType = typeof(CommonEbbPlan);
            }
            else
            {
                // 
            }

            return planType;
        }

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

        private EbbinghausTemplate ebbinghausTemplate = UserSetting.Default;
        public EbbinghausTemplate EbbinghausTemplate
        {
            get
            {
                return ebbinghausTemplate;
            }

            set
            {
                ebbinghausTemplate = value;
            }
        }

        private FormatterArgs _args;

        private NameFormatter _nameFormatter = SingleParameterNameFormatter.Instance;
        public NameFormatter NameFormatter
        {
            get
            {
                return _nameFormatter;
            }
        }

        private void CheckParamters()
        {
            // TODO:
        }

        public void SetNameFormatter(NameFormatter nameFormatter, FormatterArgs args)
        {
            _nameFormatter = nameFormatter;
            _args = args;
        }

        public string Details
        {
            get;
            set;
        }

        private bool isTemplateDefault = true;
        public bool IsTemplateDefault
        {
            get
            {
                return isTemplateDefault;
            }
            set
            {
                isTemplateDefault = false;
            }
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

        private int _count;
        private int Count
        {
            get
            {
                return _count;
            }
            set
            {
                _args = new SingleParameterNameArgs(value);
                _count = value;
            }
        }

        #endregion

        #region output
        private Plan _plan;
        #endregion
    }
}
