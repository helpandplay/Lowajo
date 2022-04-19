using Lowajo.ViewModel;
using System;
using Xunit;

namespace Lowajo.Test
{
    public class CoinViewModelTest
    {
        [Trait("CoinViewModel", "VaildateInputText Method Test")]
        [Fact(DisplayName = "string.Emply => False")]
        public void Test1()
        {
            string input = "";

            var classInstance = Activator.CreateInstance(typeof(CoinViewModel));
            var VaildateInputText = Commons.GetPrivateMethod<CoinViewModel>("VaildateInputText");

            var result = (bool?)VaildateInputText.Invoke(classInstance, new object[] { input });

            Assert.False(result);
        }
        [Trait("CoinViewModel", "VaildateInputText Method Test")]
        [Fact(DisplayName = "8 => True")]
        public void Test2()
        {
            string input = "8";

            var classInstance = Activator.CreateInstance(typeof(CoinViewModel));
            var VaildateInputText = Commons.GetPrivateMethod<CoinViewModel>("VaildateInputText");

            var result = (bool?)VaildateInputText.Invoke(classInstance, new object[] { input });

            Assert.True(result);
        }
        [Trait("CoinViewModel", "VaildateInputText Method Test")]
        [Fact(DisplayName = "321321 => True")]
        public void Test3()
        {
            string input = "321321";

            var classInstance = Activator.CreateInstance(typeof(CoinViewModel));
            var VaildateInputText = Commons.GetPrivateMethod<CoinViewModel>("VaildateInputText");

            var result = (bool?)VaildateInputText.Invoke(classInstance, new object[] { input });

            Assert.True(result);
        }
        [Trait("CoinViewModel", "VaildateInputText Method Test")]
        [Fact(DisplayName = "321321/ => False")]
        public void Test4()
        {
            string input = "321321/";

            var classInstance = Activator.CreateInstance(typeof(CoinViewModel));
            var VaildateInputText = Commons.GetPrivateMethod<CoinViewModel>("VaildateInputText");

            var result = (bool?)VaildateInputText.Invoke(classInstance, new object[] { input });

            Assert.False(result);
        }
        [Trait("CoinViewModel", "VaildateInputText Method Test")]
        [Fact(DisplayName = "3213/443 => False")]
        public void Test5()
        {
            string input = "3213/443";

            var classInstance = Activator.CreateInstance(typeof(CoinViewModel));
            var VaildateInputText = Commons.GetPrivateMethod<CoinViewModel>("VaildateInputText");

            var result = (bool?)VaildateInputText.Invoke(classInstance, new object[] { input });

            Assert.False(result);
        }
        [Trait("CoinViewModel", "VaildateInputText Method Test")]
        [Fact(DisplayName = "/231 => False")]
        public void Test6()
        {
            string input = "/231";

            var classInstance = Activator.CreateInstance(typeof(CoinViewModel));
            var VaildateInputText = Commons.GetPrivateMethod<CoinViewModel>("VaildateInputText");

            var result = (bool?)VaildateInputText.Invoke(classInstance, new object[] { input });

            Assert.False(result);
        }
        [Trait("CoinViewModel", "VaildateInputText Method Test")]
        [Fact(DisplayName = "3213/4 => True")]
        public void Test7()
        {
            string input = "3213/4";

            var classInstance = Activator.CreateInstance(typeof(CoinViewModel));
            var VaildateInputText = Commons.GetPrivateMethod<CoinViewModel>("VaildateInputText");

            var result = (bool?)VaildateInputText.Invoke(classInstance, new object[] { input });

            Assert.True(result);
        }
        [Trait("CoinViewModel", "VaildateInputText Method Test")]
        [Fact(DisplayName = "4 => True")]
        public void Test8()
        {
            string input = "4";

            var classInstance = Activator.CreateInstance(typeof(CoinViewModel));
            var VaildateInputText = Commons.GetPrivateMethod<CoinViewModel>("VaildateInputText");

            var result = (bool?)VaildateInputText.Invoke(classInstance, new object[] { input });

            Assert.True(result);
        }
    }
}