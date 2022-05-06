using System;
using System.Linq;
using System.Reflection;

namespace Lowajo.Test
{
  public static class Commons
  {
    public static MethodInfo GetPrivateMethod<T>(string methodName)
    {
      Type type = typeof(T);
      return type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                              .Where(x => x.Name == methodName)
                              .First();
    }
  }
}
