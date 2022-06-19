using System;
using System.ComponentModel;
using System.Reflection;

namespace Lowajo.Common
{
  public class Commons
  {
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
        }
      }
      catch(NullReferenceException e)
      {
        PrintErrorMessage(e);
      }
      return resultText;
    }

    public static void PrintErrorMessage(Exception e)
    {
      string errorText = $"[{DateTime.Now:HH:mm:ss}] Error : {e.Message}\n" +
                   $"           StackTrace : {e.StackTrace}\n";
      System.Diagnostics.Trace.WriteLine(errorText);
    }
  }
}
