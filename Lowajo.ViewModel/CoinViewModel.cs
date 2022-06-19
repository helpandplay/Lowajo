using System.Text.RegularExpressions;
using Lowajo.Model.Enums;
using Lowajo.ViewModel.Base;

namespace Lowajo.ViewModel
{
    public class CoinViewModel : ViewModelBase
    {
        private Distribution distribution = Distribution.None;
        public bool IsEight
        {
            get => distribution == Distribution.Eight;
            set
            {
                if(value)
                {
                    distribution = Distribution.Eight;
                }
                OnPropertyChanged(nameof(IsEight));
            }
        }
        public bool IsFour
        {
            get => distribution == Distribution.Four;
            set
            {
                if(value)
                {
                    distribution = Distribution.Four;
                }
                OnPropertyChanged(nameof(IsFour));
            }
        }

        private bool isGetBenefit;
        public bool IsGetBenefit
        {
            get
            {
                return isGetBenefit;
            }
            set
            {
                isGetBenefit = value;
                OnPropertyChanged(nameof(IsGetBenefit));
            }
        }

        private string inputText = string.Empty;
        public string InputText
        {
            get => inputText;
            set
            {
                bool isApplyInputValue = false;

                //값을 모두 지웠을 때
                if(string.IsNullOrEmpty(value))
                {
                    inputText = string.Empty;
                    OnPropertyChanged(nameof(InputText));
                }
                //나누기 식을 만족했을 때
                else if(GetIsDivisionCalculration(value) &&
                        ( IsEight || IsFour ))
                {
                    //분모가 4 또는 8로 나누어 떨어질 때
                    if(VaildateAuctionCalculration(value))
                    {
                        isApplyInputValue = true;
                    }
                }
                //나누기 식을 작성할 때, 분모는 없는 식일때 ex) 231/, 4314/
                //숫자만 있을 때
                else if(GetIsDivisionCalculrationNotDenominator(value) ||
                        GetIsOnlyNumberAndDivisionExpression(value))
                {
                    isApplyInputValue = true;
                }

                if(isApplyInputValue)
                {
                    inputText = value;
                    OnPropertyChanged(nameof(InputText));
                }
            }
        }

        private bool VaildateAuctionCalculration(string value)
        {
            return new Regex(@"\d+\/(4|8){1}\z").IsMatch(value);
        }

        public bool IsOnlyNumberInputText { get; private set; }
        public string ResultText;
        private static bool GetIsOnlyNumberAndDivisionExpression(string value)
        {
            //TODO: 문자열이 들어간 value도 true로 반환되는 현상이 있음
            return new Regex(@"[0-9]").IsMatch(value);
        }
        private static bool GetIsDivisionCalculration(string value)
        {
            return new Regex(@"\d+\/[0-9]").IsMatch(value);
        }
        private static bool GetIsDivisionCalculrationNotDenominator(string value)
        {
            return new Regex(@"\d+(\/)$", RegexOptions.Multiline | RegexOptions.ECMAScript).IsMatch(value);
        }
    }
}
