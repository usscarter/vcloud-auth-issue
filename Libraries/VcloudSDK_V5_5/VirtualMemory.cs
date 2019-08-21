// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.VirtualMemory
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;

namespace com.vmware.vcloud.sdk
{
  public class VirtualMemory : HardwareItem
  {
    internal VirtualMemory(RASD_Type virtualMemoryItem)
      : base(virtualMemoryItem)
    {
    }

    public ulong GetMemorySize()
    {
      return this.GetItemResource().VirtualQuantity.Value;
    }

    public void SetMemorySize(ulong memorySize)
    {
      this.GetItemResource().VirtualQuantity = new cimUnsignedLong()
      {
        Value = memorySize
      };
    }
  }
}
