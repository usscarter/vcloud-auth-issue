// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.VirtualDisk
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.constants;
using com.vmware.vcloud.sdk.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace com.vmware.vcloud.sdk
{
  public class VirtualDisk : HardwareItem
  {
    public VirtualDisk(long diskSize, BusType busType, BusSubType busSubType)
      : base(new RASD_Type())
    {
      cimString cimString1 = new cimString();
      List<XmlAttribute> xmlAttributeList = new List<XmlAttribute>();
      XmlDocument xmlDocument = new XmlDocument();
      if (busType.Value().Equals(BusType.IDE.Value()))
      {
        XmlAttribute attribute = xmlDocument.CreateAttribute("vcloud", nameof (busType), "http://www.vmware.com/vcloud/v1.5");
        attribute.Value = "5";
        xmlAttributeList.Add(attribute);
      }
      else
      {
        XmlAttribute attribute1 = xmlDocument.CreateAttribute("vcloud", nameof (busSubType), "http://www.vmware.com/vcloud/v1.5");
        attribute1.Value = busSubType.Value();
        XmlAttribute attribute2 = xmlDocument.CreateAttribute("vcloud", nameof (busType), "http://www.vmware.com/vcloud/v1.5");
        attribute2.Value = "6";
        xmlAttributeList.Add(attribute1);
        xmlAttributeList.Add(attribute2);
      }
      XmlAttribute attribute3 = xmlDocument.CreateAttribute("vcloud", "capacity", "http://www.vmware.com/vcloud/v1.5");
      attribute3.Value = diskSize.ToString();
      xmlAttributeList.Add(attribute3);
      if (cimString1.AnyAttr == null)
      {
        cimString1.AnyAttr = xmlAttributeList.ToArray();
      }
      else
      {
        List<XmlAttribute> list = ((IEnumerable<XmlAttribute>) cimString1.AnyAttr).ToList<XmlAttribute>();
        list.AddRange((IEnumerable<XmlAttribute>) xmlAttributeList);
        cimString1.AnyAttr = list.ToArray();
      }
      cimString cimString2 = new cimString();
      cimString2.Value = "";
      cimString cimString3 = new cimString();
      cimString3.Value = "";
      ResourceType1 resourceType1 = new ResourceType1();
      resourceType1.Value = "17";
      RASD_Type itemResource = this.GetItemResource();
      itemResource.ElementName = cimString2;
      itemResource.InstanceID = cimString3;
      itemResource.ResourceType = resourceType1;
      itemResource.HostResource = new cimString[1]
      {
        cimString1
      };
    }

    public VirtualDisk(
      long diskSize,
      BusType busType,
      BusSubType busSubType,
      int busNumber,
      int unitNumber)
      : base(new RASD_Type())
    {
      cimString cimString1 = new cimString();
      List<XmlAttribute> xmlAttributeList = new List<XmlAttribute>();
      XmlDocument xmlDocument = new XmlDocument();
      if (busType.Value().Equals(BusType.IDE.Value()))
      {
        XmlAttribute attribute = xmlDocument.CreateAttribute("vcloud", nameof (busType), "http://www.vmware.com/vcloud/v1.5");
        attribute.Value = "5";
        xmlAttributeList.Add(attribute);
      }
      else
      {
        XmlAttribute attribute1 = xmlDocument.CreateAttribute("vcloud", nameof (busSubType), "http://www.vmware.com/vcloud/v1.5");
        attribute1.Value = busSubType.Value();
        XmlAttribute attribute2 = xmlDocument.CreateAttribute("vcloud", nameof (busType), "http://www.vmware.com/vcloud/v1.5");
        attribute2.Value = "6";
        xmlAttributeList.Add(attribute1);
        xmlAttributeList.Add(attribute2);
      }
      XmlAttribute attribute3 = xmlDocument.CreateAttribute("vcloud", "capacity", "http://www.vmware.com/vcloud/v1.5");
      attribute3.Value = diskSize.ToString();
      xmlAttributeList.Add(attribute3);
      if (cimString1.AnyAttr == null)
      {
        cimString1.AnyAttr = xmlAttributeList.ToArray();
      }
      else
      {
        List<XmlAttribute> list = ((IEnumerable<XmlAttribute>) cimString1.AnyAttr).ToList<XmlAttribute>();
        list.AddRange((IEnumerable<XmlAttribute>) xmlAttributeList);
        cimString1.AnyAttr = list.ToArray();
      }
      cimString cimString2 = new cimString();
      cimString2.Value = "";
      cimString cimString3 = new cimString();
      cimString3.Value = "";
      cimString cimString4 = new cimString();
      cimString4.Value = unitNumber.ToString();
      cimString cimString5 = new cimString();
      cimString5.Value = busNumber.ToString();
      cimString cimString6 = new cimString();
      cimString6.Value = busNumber.ToString() + busSubType.Value() + (object) unitNumber;
      ResourceType1 resourceType1 = new ResourceType1();
      resourceType1.Value = "17";
      RASD_Type itemResource = this.GetItemResource();
      itemResource.ElementName = cimString2;
      itemResource.InstanceID = cimString3;
      itemResource.ResourceType = resourceType1;
      itemResource.AddressOnParent = cimString4;
      itemResource.Address = cimString5;
      itemResource.Parent = cimString6;
      itemResource.HostResource = new cimString[1]
      {
        cimString1
      };
    }

    public VirtualDisk(RASD_Type virtualDiskItem)
      : base(virtualDiskItem)
    {
    }

    public ulong GetHardDiskSize()
    {
      try
      {
        return ulong.Parse(this.GetHostResourceAttributeValue("capacity"));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void UpdateHardDiskSize(ulong hardDiskSize)
    {
      foreach (XmlAttribute xmlAttribute in this.GetItemResource().HostResource[0].AnyAttr)
      {
        if (xmlAttribute.LocalName.Equals("capacity"))
          xmlAttribute.Value = hardDiskSize.ToString();
      }
    }

    public string GetHardDiskBusType()
    {
      try
      {
        return this.GetHostResourceAttributeValue("busSubType");
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public bool IsHardDisk()
    {
      return this.GetItemResource().ResourceType.Value.Equals("17");
    }

    internal string GetHostResourceAttributeValue(string attributeName)
    {
      if (this.GetItemResource() != null && this.GetItemResource().ResourceType.Value.Equals("17") && (this.GetItemResource().HostResource != null && ((IEnumerable<cimString>) this.GetItemResource().HostResource).ToList<cimString>().Count > 0))
      {
        string stringAttributeValue = this.GetCimStringAttributeValue(this.GetItemResource().HostResource[0], attributeName);
        if (stringAttributeValue != null)
          return stringAttributeValue;
      }
      throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.NOT_HARD_DISK_MSG) + " - " + this.GetItemResource().ElementName.Value);
    }
  }
}
