// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.LambdaComparer`1
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;

namespace com.vmware.vcloud.sdk
{
  public class LambdaComparer<T> : IEqualityComparer<T>
  {
    private readonly Func<T, T, bool> _lambdaComparer;
    private readonly Func<T, int> _lambdaHash;

    public LambdaComparer(Func<T, T, bool> lambdaComparer)
      : this(lambdaComparer, (Func<T, int>) (o => 0))
    {
    }

    public LambdaComparer(Func<T, T, bool> lambdaComparer, Func<T, int> lambdaHash)
    {
      if (lambdaComparer == null)
        throw new ArgumentNullException(nameof (lambdaComparer));
      if (lambdaHash == null)
        throw new ArgumentNullException(nameof (lambdaHash));
      this._lambdaComparer = lambdaComparer;
      this._lambdaHash = lambdaHash;
    }

    public bool Equals(T x, T y)
    {
      return this._lambdaComparer(x, y);
    }

    public int GetHashCode(T obj)
    {
      return this._lambdaHash(obj);
    }
  }
}
