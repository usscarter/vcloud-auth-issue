// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.VirtualCpu
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;
using System;
using System.Xml;

namespace com.vmware.vcloud.sdk
{
  public class VirtualCpu : HardwareItem
  {
    internal VirtualCpu(RASD_Type virtualCPUItem)
      : base(virtualCPUItem)
    {
    }

    public int GetNoOfCpus()
    {
      return (int) this.GetItemResource().VirtualQuantity.Value;
    }

    public void SetNoOfCpus(int cpuCount)
    {
      this.GetItemResource().VirtualQuantity = new cimUnsignedLong()
      {
        Value = (ulong) cpuCount
      };
    }

    public int GetCoresPerSocket()
    {
      try
      {
        foreach (XmlElement xmlElement in this.GetItemResource().Any)
        {
          if (xmlElement.Name.Contains("CoresPerSocket"))
            return int.Parse(xmlElement.InnerText);
        }
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.DATA_NOT_FOUND));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void SetCoresPerSocket(int coresPerSocket)
    {
      foreach (XmlElement xmlElement in this.GetItemResource().Any)
      {
        if (xmlElement.LocalName.Contains("CoresPerSocket"))
          xmlElement.InnerText = coresPerSocket.ToString();
      }
    }
  }
}
