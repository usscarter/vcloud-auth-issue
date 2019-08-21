// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.HardwareItem
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using System;
using System.Xml;

namespace com.vmware.vcloud.sdk
{
  public class HardwareItem : IDisposable
  {
    private RASD_Type _itemResource;

    internal HardwareItem()
    {
    }

    internal HardwareItem(RASD_Type virtualCpuItem)
    {
      this._itemResource = virtualCpuItem;
    }

    public RASD_Type GetItemResource()
    {
      return this._itemResource;
    }

    internal string GetCimStringAttributeValue(cimString cimStrings, string attributeName)
    {
      if (cimStrings.AnyAttr != null)
      {
        foreach (XmlAttribute xmlAttribute in cimStrings.AnyAttr)
        {
          if (xmlAttribute.LocalName.Equals(attributeName))
            return xmlAttribute.Value;
        }
      }
      return (string) null;
    }

    protected void Dispose(bool disposing)
    {
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }
  }
}
