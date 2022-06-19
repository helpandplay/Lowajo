using System.ComponentModel;

namespace Lowajo.Common
{
    public enum Messages
    {
        [Description("계산 식을 입력해주세요.")]
        PleaseInputOperation,
        [Description("올바르지 않은 계산식입니다.")]
        PleaseCorrectOperation,
        [Description("숫자가 너무 큽니다.")]
        OverflowNumber
    }
}
