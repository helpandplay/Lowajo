using Lowajo.Model.Enums;
using Lowajo.ViewModel.Base;

namespace Lowajo.ViewModel
{
    public class CoinViewModel : ViewModelBase
    {
        //private readonly static int Normal =   

        private Distribution distribution = Distribution.Eight;
        public bool IsEight
        {
            get => distribution == Distribution.Eight;
            set
            {
                if (value)
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
                if (value)
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
    }
}
