using System;
using Lowajo.ViewModel;
using Xunit;

namespace Lowajo.Test
{
  public class CoinViewModelTest
  {
    [Trait("CoinViewModel", "VaildateInputText Method Test")]
    [Fact(DisplayName = "string.Empty => False")]
    public void Test1()
    {
      string input = "";

      object? classInstance = Activator.CreateInstance(typeof(CoinViewModel));
      System.Reflection.MethodInfo? VaildateInputText = Commons.GetPrivateMethod<CoinViewModel>("VaildateInputText");

      bool? result = (bool?)VaildateInputText.Invoke(classInstance, new object[] { input });

      Assert.False(result);
    }
    [Trait("CoinViewModel", "VaildateInputText Method Test")]
    [Fact(DisplayName = "8 => True")]
    public void Test2()
    {
      string input = "8";

      object? classInstance = Activator.CreateInstance(typeof(CoinViewModel));
      System.Reflection.MethodInfo? VaildateInputText = Commons.GetPrivateMethod<CoinViewModel>("VaildateInputText");

      bool? result = (bool?)VaildateInputText.Invoke(classInstance, new object[] { input });

      Assert.True(result);
    }
    [Trait("CoinViewModel", "VaildateInputText Method Test")]
    [Fact(DisplayName = "321321 => True")]
    public void Test3()
    {
      string input = "321321";

      object? classInstance = Activator.CreateInstance(typeof(CoinViewModel));
      System.Reflection.MethodInfo? VaildateInputText = Commons.GetPrivateMethod<CoinViewModel>("VaildateInputText");

      bool? result = (bool?)VaildateInputText.Invoke(classInstance, new object[] { input });

      Assert.True(result);
    }
    [Trait("CoinViewModel", "VaildateInputText Method Test")]
    [Fact(DisplayName = "321321/ => False")]
    public void Test4()
    {
      string input = "321321/";

      object? classInstance = Activator.CreateInstance(typeof(CoinViewModel));
      System.Reflection.MethodInfo? VaildateInputText = Commons.GetPrivateMethod<CoinViewModel>("VaildateInputText");

      bool? result = (bool?)VaildateInputText.Invoke(classInstance, new object[] { input });

      Assert.False(result);
    }
    [Trait("CoinViewModel", "VaildateInputText Method Test")]
    [Fact(DisplayName = "3213/443 => False")]
    public void Test5()
    {
      string input = "3213/443";

      object? classInstance = Activator.CreateInstance(typeof(CoinViewModel));
      System.Reflection.MethodInfo? VaildateInputText = Commons.GetPrivateMethod<CoinViewModel>("VaildateInputText");

      bool? result = (bool?)VaildateInputText.Invoke(classInstance, new object[] { input });

      Assert.False(result);
    }
    [Trait("CoinViewModel", "VaildateInputText Method Test")]
    [Fact(DisplayName = "/231 => False")]
    public void Test6()
    {
      string input = "/231";

      object? classInstance = Activator.CreateInstance(typeof(CoinViewModel));
      System.Reflection.MethodInfo? VaildateInputText = Commons.GetPrivateMethod<CoinViewModel>("VaildateInputText");

      bool? result = (bool?)VaildateInputText.Invoke(classInstance, new object[] { input });

      Assert.False(result);
    }
    [Trait("CoinViewModel", "VaildateInputText Method Test")]
    [Fact(DisplayName = "3213/4 => True")]
    public void Test7()
    {
      string input = "3213/4";

      object? classInstance = Activator.CreateInstance(typeof(CoinViewModel));
      System.Reflection.MethodInfo? VaildateInputText = Commons.GetPrivateMethod<CoinViewModel>("VaildateInputText");

      bool? result = (bool?)VaildateInputText.Invoke(classInstance, new object[] { input });

      Assert.True(result);
    }
    [Trait("CoinViewModel", "VaildateInputText Method Test")]
    [Fact(DisplayName = "4 => True")]
    public void Test8()
    {
      string input = "4";

      object? classInstance = Activator.CreateInstance(typeof(CoinViewModel));
      System.Reflection.MethodInfo? VaildateInputText = Commons.GetPrivateMethod<CoinViewModel>("VaildateInputText");

      bool? result = (bool?)VaildateInputText.Invoke(classInstance, new object[] { input });

      Assert.True(result);
    }
    [Trait("CoinViewModel", "VaildateInputText Method Test")]
    [Fact(DisplayName = "(4 => IsOnlyNumberInputText = True) => (3213/4 => IsOnlyNumberInputText = False)")]
    public void Test9()
    {
      string input = "4";

      object? classInstance = Activator.CreateInstance(typeof(CoinViewModel));
      System.Reflection.MethodInfo? VaildateInputText = Commons.GetPrivateMethod<CoinViewModel>("VaildateInputText");

      if(classInstance is CoinViewModel viewModel)
      {
        bool? result = (bool?)VaildateInputText.Invoke(classInstance, new object[] { input });

        Assert.True(result);
        Assert.True(viewModel.IsOnlyNumberInputText);

        string input2 = "3213/4";

        result = (bool?)VaildateInputText.Invoke(classInstance, new object[] { input2 });

        Assert.True(result);
        Assert.False(viewModel.IsOnlyNumberInputText);
      }
    }
  }
}