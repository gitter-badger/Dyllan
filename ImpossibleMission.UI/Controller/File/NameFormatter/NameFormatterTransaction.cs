using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpossibleMission.Model;
using ImpossibleMission.Model.Model;

namespace ImpossibleMission.Controller
{
    public class NameFormatterTransaction : Transaction
    {
        #region Implement ITransaction
        public override void Execute()
        {
            try
            {
                CheckParameter();
                SetParameter();
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message, MessageType.Error);
                // TODO
            }
        }

        #endregion

        #region input

        private NameFormatter _nameFormatter = SingleParameterNameFormatter.Instance;
        public NameFormatter NameFormatter
        {
            get { return _nameFormatter; }
            set { _nameFormatter = value; }
        }

        private FormatterArgs _args = null;
        public FormatterArgs Args
        {
            get
            {
                SetParameter();
                return _args;
            }
        }

        private string _textItemCount;
        public string TextItemCount
        {
            get
            {
                return _textItemCount;
            }
            set
            {
                _textItemCount = value;
            }
        }

        private string _textStartNumber;
        public string TextStartNumber
        {
            get
            {
                return _textStartNumber;
            }
            set
            {
                _textStartNumber = value;
            }
        }

        private string _textFormatter;
        public string TextFormatter
        {
            get
            {
                return _textFormatter;
            }
            set
            {
                _textFormatter = value;
            }
        }

        private string _textIncrment;
        public string TextIncrement
        {
            get
            {
                return _textIncrment;
            }
            set
            {
                _textIncrment = value;
            }
        }
        #endregion

        #region output

        private void SetParameter()
        {
            if (!IsValid())
                return;

            if (_nameFormatter is SingleParameterNameFormatter)
            {
                SingleParameterNameArgs args = new SingleParameterNameArgs(int.Parse(TextItemCount));
                args.IncrementValue = int.Parse(TextIncrement);
                args.StartValue = int.Parse(TextStartNumber);
                var splitTuple = GetSplitValue();
                args.PrefixValue = splitTuple.Item1;
                args.PostfixValue = splitTuple.Item2;
                _args = args;
            }
            else
            {
                // TODO
            }
        }

        private void CheckParameter()
        {
            if (!IsValid())
                throw new InvalidNameFormatter();
        }

        private bool IsValid()
        {
            int count, startValue, increment;
            return !(string.IsNullOrEmpty(TextFormatter)
                || string.IsNullOrEmpty(TextItemCount)
                || string.IsNullOrEmpty(TextStartNumber)
                || string.IsNullOrEmpty(TextIncrement)
                || !int.TryParse(TextStartNumber, out startValue)
                || !int.TryParse(TextItemCount, out count)
                || !int.TryParse(TextIncrement, out increment));
        }

        private Tuple<string, string> GetSplitValue()
        {
            if (string.IsNullOrEmpty(TextFormatter))
                return null;
            string tempValue = TextFormatter;
            string preValue = tempValue;
            string postValue = string.Empty;
            if (tempValue.Contains(Constant.PLACEHOLDER))
            {
                preValue = tempValue.Substring(0, tempValue.IndexOf(Constant.PLACEHOLDER));
                postValue = tempValue.Substring(tempValue.IndexOf(Constant.PLACEHOLDER) + Constant.PLACEHOLDER.Length);
            }

            return new Tuple<string, string>(preValue, postValue);
        }

        public string Preview
        {
            get
            {
                string result = string.Empty;

                if (!IsValid())
                {
                    result = string.Empty;
                    return result;
                }
                StringBuilder sb = new StringBuilder();
                var values = _nameFormatter.Format(Args);

                foreach (var v in values)
                {
                    sb.AppendLine(v);
                }
                result = sb.ToString();
                return result;
            }
        }
        #endregion

    }
}
