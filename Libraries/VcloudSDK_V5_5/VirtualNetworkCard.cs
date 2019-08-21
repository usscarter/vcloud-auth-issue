// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.VirtualNetworkCard
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
  public class VirtualNetworkCard : HardwareItem
  {
    public VirtualNetworkCard(RASD_Type virtualNetworkCardItem)
      : base(virtualNetworkCardItem)
    {
    }

    public VirtualNetworkCard(
      int nicId,
      bool isConnected,
      string networkName,
      bool isPrimaryNetworkConnection,
      IpAddressAllocationModeType ipAddressingMode,
      string ipAddress)
      : base(new RASD_Type())
    {
      this.Init(nicId, isConnected, networkName, isPrimaryNetworkConnection, ipAddressingMode, ipAddress, NetworkAdapterType.E1000);
    }

    public VirtualNetworkCard(
      int nicId,
      bool isConnected,
      string networkName,
      bool isPrimaryNetworkConnection,
      IpAddressAllocationModeType ipAddressingMode,
      string ipAddress,
      NetworkAdapterType adapterType)
      : base(new RASD_Type())
    {
      this.Init(nicId, isConnected, networkName, isPrimaryNetworkConnection, ipAddressingMode, ipAddress, adapterType);
    }

    public string GetIpAddress()
    {
      try
      {
        return this.GetConnectionAttributeValue("ipAddress");
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void UpdateIpAddress(string ipAddress)
    {
      try
      {
        if (this.GetItemResource().Connection.Length == 0)
          throw new VCloudException("Nic does not contain Ip for update");
        foreach (XmlAttribute xmlAttribute in this.GetItemResource().Connection[0].AnyAttr)
        {
          if (xmlAttribute.LocalName.Equals(nameof (ipAddress)))
            xmlAttribute.Value = ipAddress;
        }
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void UpdateNetwork(string networkName)
    {
      try
      {
        if (this.GetItemResource().Connection.Length == 0)
          throw new VCloudException("Nic does not contain network for update");
        this.GetItemResource().Connection[0].Value = networkName;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public string GetNetwork()
    {
      try
      {
        if (this.GetItemResource().Connection.Length == 0)
          throw new VCloudException("Nic is not attached to any network");
        return this.GetItemResource().Connection[0].Value;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public bool IsPrimaryNetworkConnection()
    {
      try
      {
        return bool.Parse(this.GetConnectionAttributeValue("primaryNetworkConnection"));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public string GetIpAddressingMode()
    {
      try
      {
        return this.GetConnectionAttributeValue("ipAddressingMode");
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public bool IsConnected()
    {
      try
      {
        return this.GetItemResource().AutomaticAllocation.Value;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void ResetMacAddress()
    {
      this.GetItemResource().Address = (cimString) null;
    }

    public string GetMacAddress()
    {
      return this.GetItemResource().Address.Value;
    }

    private string GetConnectionAttributeValue(string attributeName)
    {
      if (this.GetItemResource() != null && this.GetItemResource().ResourceType.Value.Equals("10") && (this.GetItemResource().Connection != null && ((IEnumerable<cimString>) this.GetItemResource().Connection).ToList<cimString>().Count > 0))
      {
        string stringAttributeValue = this.GetCimStringAttributeValue(((IEnumerable<cimString>) this.GetItemResource().Connection).FirstOrDefault<cimString>(), attributeName);
        if (stringAttributeValue != null)
          return stringAttributeValue;
      }
      throw new VCloudException(attributeName + SdkUtil.GetI18nString(SdkMessage.RESOURCE_NOT_FOUND_MSG));
    }

    private void Init(
      int nicId,
      bool isConnected,
      string networkName,
      bool isPrimaryNetworkConnection,
      IpAddressAllocationModeType ipAddressingMode,
      string ipAddress,
      NetworkAdapterType adapterType)
    {
      cimString cimString1 = new cimString();
      cimString1.Value = networkName;
      List<XmlAttribute> xmlAttributeList = new List<XmlAttribute>();
      XmlDocument xmlDocument = new XmlDocument();
      XmlAttribute attribute1 = xmlDocument.CreateAttribute("vcloud", nameof (ipAddress), "http://www.vmware.com/vcloud/v1.5");
      attribute1.Value = ipAddress;
      XmlAttribute attribute2 = xmlDocument.CreateAttribute("vcloud", "primaryNetworkConnection", "http://www.vmware.com/vcloud/v1.5");
      attribute2.Value = isPrimaryNetworkConnection.ToString();
      XmlAttribute attribute3 = xmlDocument.CreateAttribute("vcloud", nameof (ipAddressingMode), "http://www.vmware.com/vcloud/v1.5");
      attribute3.Value = ipAddressingMode.Value();
      xmlAttributeList.Add(attribute1);
      xmlAttributeList.Add(attribute2);
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
      cimString4.Value = nicId.ToString();
      cimBoolean cimBoolean = new cimBoolean();
      cimBoolean.Value = isConnected;
      ResourceType1 resourceType1 = new ResourceType1();
      resourceType1.Value = "10";
      cimString cimString5 = new cimString();
      cimString5.Value = adapterType.Value();
      RASD_Type itemResource = this.GetItemResource();
      itemResource.ElementName = cimString2;
      itemResource.InstanceID = cimString3;
      itemResource.ResourceType = resourceType1;
      itemResource.ResourceSubType = cimString5;
      itemResource.AddressOnParent = cimString4;
      itemResource.AutomaticAllocation = cimBoolean;
      itemResource.Connection = new cimString[1]
      {
        cimString1
      };
    }
  }
}
