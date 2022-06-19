using System;
using System.ComponentModel;
using System.Reflection;
using Xunit;

namespace Lowajo.Test
{
  internal enum Messages
  {
    [Description("계산 식을 입력해주세요.")]
    PleaseInputOperation,
    PleaseCorrectOperation,
  };
  public class CommonTest
  {
    [Trait("Common", "Get Enum Description Test")]
    [Fact(DisplayName = "Messages.PleaseInputOperation => 계산 식을 입력해주세요.")]
    public void EnumDesciptionTest()
    {

      Messages message = Messages.PleaseInputOperation;

      string? result = GetEnumDescription(message);

      Assert.True(string.Equals(result, "계산 식을 입력해주세요."));
    }

    [Trait("Common", "Get Enum Description Test")]
    [Fact(DisplayName = "Messages.PleaseCorrectOperation => enumValue가 null입니다.")]
    public void EnumDesciptionNullReferenceExceptionTest()
    {
      Messages message = Messages.PleaseCorrectOperation;

      string? result = GetEnumDescription(message);

      Assert.True(string.Equals(result, string.Empty));
    }

    public static string GetEnumDescription<T>(T enumValue)
    {
      string resultText = string.Empty;
      try
      {
        if(enumValue == null) throw new System.NullReferenceException("enumValue가 null입니다.");

        Type enumType = enumValue.GetType();

        FieldInfo? fieldInfo = enumType.GetField(enumValue.ToString() ?? throw new NullReferenceException("enumValue.ToString()이 null값입니다."));

        if(fieldInfo is not null)
        {
          var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

          if(attributes is not null && attributes.Length > 0) resultText = attributes[0].Description;
          else
          {
            throw new NullReferenceException("enumValue에 description을 할당하지 않았습니다.");
          }
        }
      }
      catch(NullReferenceException e)
      {
        string errorText = $"[{DateTime.Now:HH:mm:ss}] Error : {e.Message}\n" +
                           $"           StackTrace : {e.StackTrace}\n";
        System.Diagnostics.Trace.WriteLine(errorText);
      }
      return resultText;
    }
  }
}
