// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.utility.ClientAppTrace
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System.Diagnostics;

namespace com.vmware.vcloud.sdk.utility
{
  internal class ClientAppTrace
  {
    private static TraceSource _clientAppSource = new TraceSource(nameof (ClientAppTrace), SourceLevels.All);

    private ClientAppTrace()
    {
    }

    internal static TraceSource TraceSource
    {
      get
      {
        return ClientAppTrace._clientAppSource;
      }
    }
  }
}
