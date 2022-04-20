using Lowajo.Model.Enums;
using Lowajo.ViewModel.Base;
using System.Text.RegularExpressions;

namespace Lowajo.ViewModel
{
    public class CoinViewModel : ViewModelBase
    {
        private const double eightDistributionValue = 7 / 8.0;
        private const double fourDistributionValue = 3 / 4.0;
        private const double benefitValue = 1.1;
        private const double baseAuctionRateValue = 0.95;


        private Distribution distribution = Distribution.Eight;
        public bool IsEight
        {
            get => distribution == Distribution.Eight;
            set
            {
                if(value)
                {
                    distribution = Distribution.Eight;
                    OnPropertyChanged(nameof(IsEight));
                }
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
                    OnPropertyChanged(nameof(IsFour));
                }
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
            get
            {
                return inputText;
            }
            set
            {
                if(VaildateInputText(value))
                {
                    inputText = value;
                    OnPropertyChanged(nameof(InputText));
                }
            }
        }
        public bool IsOnlyNumberInputText { get; private set; }
        public string ResultText
        {
            get
            {
                if(string.IsNullOrEmpty(InputText))
                {
                    return "Not supported calculration.";
                }
                return InputText;
            }
        }

        private bool VaildateInputText(string value)
        {
            string inputText = value.Trim();
            Regex divisionRegex = new Regex(@"(([0-9]+\/)8\b)|(([0-9]+\/)4\b)");
            Regex onlyNumberRegex = new Regex(@"^[0-9]+$");

            if(divisionRegex.IsMatch(inputText))
            {
                IsOnlyNumberInputText = false;
                return true;
            }
            if(onlyNumberRegex.IsMatch(inputText))
            {
                IsOnlyNumberInputText = true;
                return true;
            }
            return false;
        }
    }
}
