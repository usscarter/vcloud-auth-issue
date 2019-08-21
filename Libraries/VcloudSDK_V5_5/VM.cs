// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.VM
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.constants;
using com.vmware.vcloud.sdk.utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace com.vmware.vcloud.sdk
{
  public class VM : AbstractVapp<VmType>
  {
    private VirtualHardwareSection_Type _virtualHardwareSection;
    private OperatingSystemSection_Type _operatingSystemSection;
    private NetworkConnectionSectionType _networkConnectionSection;
    private GuestCustomizationSectionType _guestCustomizationSection;
    private RuntimeInfoSectionType _runtimeInfoSection;
    private VirtualCpu _virtualCpu;
    private VirtualMemory _virtualMemory;
    private List<VirtualDisk> _virtualDisks;
    private List<SerialPort> _serialPorts;
    private List<VirtualNetworkCard> _networkCards;
    private List<VirtualMedia> _medias;
    private ReferenceType _parentVappReference;
    private VmVimInfoType _vmVimInfoType;

    internal VM(vCloudClient client, VmType vmType)
      : base(client, vmType)
    {
      this.SortOvfSectionsAndReferences_v1_5();
    }

    public static VM GetVMByReference(vCloudClient client, ReferenceType vmRef)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + vmRef.href);
        VmType resourceByReference = VcloudResource<VmType>.GetResourceByReference(client, vmRef);
        return new VM(client, resourceByReference);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static VM GetVMById(vCloudClient client, string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        VmType entityById = VcloudEntity<VmType>.GetEntityById(client, vCloudId, "application/vnd.vmware.vcloud.vm+xml");
        return new VM(client, entityById);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VMStatus GetVMStatus()
    {
      return VMStatus.FromValue(this.Resource.status);
    }

    public Task UpdateVM(VmType vmType)
    {
      try
      {
        string href = this.Reference.href;
        string requestString = SerializationUtil.SerializeObject<VmType>(vmType, "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.PUT_URL_MSG) + " - " + href);
        return new Task(this.VcloudClient, SdkUtil.Put<TaskType>(this.VcloudClient, href, requestString, "application/vnd.vmware.vcloud.vm+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public GuestCustomizationSectionType GetGuestCustomizationSection()
    {
      try
      {
        if (this._guestCustomizationSection == null)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.DATA_NOT_FOUND));
        return this._guestCustomizationSection;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static GuestCustomizationSectionType GetGuestCustomizationSection(
      vCloudClient client,
      ReferenceType vmRef)
    {
      try
      {
        return SdkUtil.Get<GuestCustomizationSectionType>(client, vmRef.href + "/guestCustomizationSection/", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VirtualHardwareSection_Type GetVirtualHardwareSection()
    {
      try
      {
        if (this._virtualHardwareSection == null)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.DATA_NOT_FOUND));
        return this._virtualHardwareSection;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static VirtualHardwareSection_Type GetVirtualHardwareSection(
      vCloudClient client,
      ReferenceType vmRef)
    {
      try
      {
        return SdkUtil.Get<VirtualHardwareSection_Type>(client, vmRef.href + "/virtualHardwareSection/", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public OperatingSystemSection_Type GetOperatingSystemSection()
    {
      try
      {
        if (this._operatingSystemSection == null)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.DATA_NOT_FOUND));
        return this._operatingSystemSection;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static OperatingSystemSection_Type GetOperatingSystemSection(
      vCloudClient client,
      ReferenceType vmRef)
    {
      try
      {
        return SdkUtil.Get<OperatingSystemSection_Type>(client, vmRef.href + "/operatingSystemSection/", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RuntimeInfoSectionType GetRuntimeInfoSection()
    {
      try
      {
        if (this._runtimeInfoSection == null)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.DATA_NOT_FOUND));
        return this._runtimeInfoSection;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static RuntimeInfoSectionType GetRuntimeInfoSection(
      vCloudClient client,
      ReferenceType vmRef)
    {
      try
      {
        return SdkUtil.Get<RuntimeInfoSectionType>(client, vmRef.href + "/runtimeInfoSection/", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task UpdateSection(Section_Type sectionType)
    {
      try
      {
        string href = this.Reference.href;
        string requestString;
        string url;
        string mediaType;
        if (sectionType is VirtualHardwareSection_Type)
        {
          requestString = SerializationUtil.SerializeObject<VirtualHardwareSection_Type>((VirtualHardwareSection_Type) sectionType, "com.vmware.vcloud.api.rest.schema");
          url = href + "/virtualHardwareSection/";
          mediaType = "application/vnd.vmware.vcloud.virtualHardwareSection+xml";
        }
        else if (sectionType is OperatingSystemSection_Type)
        {
          requestString = SerializationUtil.SerializeObject<OperatingSystemSection_Type>((OperatingSystemSection_Type) sectionType, "com.vmware.vcloud.api.rest.schema");
          url = href + "/operatingSystemSection/";
          mediaType = "application/vnd.vmware.vcloud.operatingSystemSection+xml";
        }
        else if (sectionType is GuestCustomizationSectionType)
        {
          requestString = SerializationUtil.SerializeObject<GuestCustomizationSectionType>((GuestCustomizationSectionType) sectionType, "com.vmware.vcloud.api.rest.schema");
          url = href + "/guestCustomizationSection/";
          mediaType = "application/vnd.vmware.vcloud.guestCustomizationSection+xml";
        }
        else if (sectionType is NetworkConnectionSectionType)
        {
          requestString = SerializationUtil.SerializeObject<NetworkConnectionSectionType>((NetworkConnectionSectionType) sectionType, "com.vmware.vcloud.api.rest.schema");
          url = href + "/networkConnectionSection/";
          mediaType = "application/vnd.vmware.vcloud.networkConnectionSection+xml";
        }
        else
        {
          Logger.Log(TraceLevel.Information, sectionType.GetType().ToString() + " - " + SdkUtil.GetI18nString(SdkMessage.NOT_VALID_SECTION_MSG));
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.NOT_VALID_SECTION_MSG));
        }
        return new Task(this.VcloudClient, SdkUtil.Put<TaskType>(this.VcloudClient, url, requestString, mediaType, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task InsertMedia(
      MediaInsertOrEjectParamsType mediaInsertOrEjectParamsType)
    {
      try
      {
        string url = this.Reference.href + "/media/action/insertMedia";
        string requestString = SerializationUtil.SerializeObject<MediaInsertOrEjectParamsType>(mediaInsertOrEjectParamsType, "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.POST_URL_MSG) + " - " + url);
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, url, requestString, "application/vnd.vmware.vcloud.mediaInsertOrEjectParams+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task EjectMedia(
      MediaInsertOrEjectParamsType mediaInsertOrEjectParamsType)
    {
      try
      {
        string url = this.Reference.href + "/media/action/ejectMedia";
        string requestString = SerializationUtil.SerializeObject<MediaInsertOrEjectParamsType>(mediaInsertOrEjectParamsType, "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.POST_URL_MSG) + " - " + url);
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, url, requestString, "application/vnd.vmware.vcloud.mediaInsertOrEjectParams+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ulong GetVmSize()
    {
      try
      {
        ulong num = 0;
        foreach (VirtualDisk disk in this.GetDisks())
        {
          if ("17".Equals(disk.GetItemResource().ResourceType.Value))
          {
            ulong hardDiskSize = disk.GetHardDiskSize();
            num += hardDiskSize;
          }
        }
        return num;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VirtualCpu GetCpu()
    {
      try
      {
        if (this._virtualCpu == null && this._virtualHardwareSection != null)
        {
          List<RASD_Type> list = ((IEnumerable<RASD_Type>) this._virtualHardwareSection.Item).ToList<RASD_Type>();
          if (list != null)
          {
            foreach (RASD_Type virtualCPUItem in list)
            {
              if (virtualCPUItem.ResourceType.Value.Equals("3"))
                this._virtualCpu = new VirtualCpu(virtualCPUItem);
            }
          }
        }
        if (this._virtualCpu != null)
          return this._virtualCpu;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.NO_VIRTUAL_CPU_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static VirtualCpu GetCpu(vCloudClient client, ReferenceType vmRef)
    {
      try
      {
        string url = vmRef.href + "/virtualHardwareSection/cpu";
        return VM.GetCpuByUrl(client, url);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private static VirtualCpu GetCpuByUrl(vCloudClient client, string url)
    {
      try
      {
        return new VirtualCpu(SdkUtil.Get<RASD_Type>(client, url, 200));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task UpdateCpu(VirtualCpu virtualCpuItem)
    {
      try
      {
        string url = this.Reference.href + "/virtualHardwareSection/cpu";
        string requestString = SerializationUtil.SerializeObject<RASD_Type>(virtualCpuItem.GetItemResource(), "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.PUT_URL_MSG) + " - " + url);
        return new Task(this.VcloudClient, SdkUtil.Put<TaskType>(this.VcloudClient, url, requestString, "application/vnd.vmware.vcloud.rasdItem+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VirtualMemory GetMemory()
    {
      try
      {
        if (this._virtualMemory == null && this._virtualHardwareSection != null)
        {
          List<RASD_Type> list = ((IEnumerable<RASD_Type>) this._virtualHardwareSection.Item).ToList<RASD_Type>();
          if (list != null)
          {
            foreach (RASD_Type virtualMemoryItem in list)
            {
              if (virtualMemoryItem.ResourceType.Value.Equals("4"))
                this._virtualMemory = new VirtualMemory(virtualMemoryItem);
            }
          }
        }
        if (this._virtualMemory != null)
          return this._virtualMemory;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.NO_VIRTUAL_MEMORY_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static VirtualMemory GetMemory(vCloudClient client, ReferenceType vmRef)
    {
      try
      {
        string url = vmRef.href + "/virtualHardwareSection/memory";
        return VM.GetMemoryByUrl(client, url);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private static VirtualMemory GetMemoryByUrl(vCloudClient client, string url)
    {
      try
      {
        return new VirtualMemory(SdkUtil.Get<RASD_Type>(client, url, 200));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task UpdateMemory(VirtualMemory virtualMemoryItem)
    {
      try
      {
        string url = this.Reference.href + "/virtualHardwareSection/memory";
        string requestString = SerializationUtil.SerializeObject<RASD_Type>(virtualMemoryItem.GetItemResource(), "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.PUT_URL_MSG) + " - " + url);
        return new Task(this.VcloudClient, SdkUtil.Put<TaskType>(this.VcloudClient, url, requestString, "application/vnd.vmware.vcloud.rasdItem+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    [Obsolete("This method is obsolete; Internal API - NotSupported/UnImplemented")]
    public List<SerialPort> GetSerialPorts()
    {
      throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.NOT_SUPPORTED_API));
    }

    [Obsolete("This method is obsolete; Internal API - NotSupported/UnImplemented")]
    public static List<SerialPort> GetSerialPorts(
      vCloudClient client,
      ReferenceType vmRef)
    {
      throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.NOT_SUPPORTED_API));
    }

    [Obsolete("This method is obsolete; Internal API - NotSupported/UnImplemented")]
    public Task UpdateSerialPorts(List<SerialPort> serialPorts)
    {
      throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.NOT_SUPPORTED_API));
    }

    public List<VirtualDisk> GetDisks()
    {
      try
      {
        if (this._virtualDisks == null)
        {
          this._virtualDisks = new List<VirtualDisk>();
          if (this._virtualHardwareSection != null)
          {
            List<RASD_Type> list = ((IEnumerable<RASD_Type>) this._virtualHardwareSection.Item).ToList<RASD_Type>();
            if (list != null)
            {
              foreach (RASD_Type virtualDiskItem in list)
              {
                if (virtualDiskItem.ResourceType.Value.Equals("17") || virtualDiskItem.ResourceType.Value.Equals("6") || virtualDiskItem.ResourceType.Value.Equals("5"))
                  this._virtualDisks.Add(new VirtualDisk(virtualDiskItem));
              }
            }
          }
        }
        return this._virtualDisks;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static List<VirtualDisk> GetDisks(
      vCloudClient client,
      ReferenceType vmRef)
    {
      try
      {
        string url = vmRef.href + "/virtualHardwareSection/disks";
        return VM.GetDisksByUrl(client, url);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private static List<VirtualDisk> GetDisksByUrl(vCloudClient client, string url)
    {
      try
      {
        List<VirtualDisk> virtualDiskList = new List<VirtualDisk>();
        RasdItemsListType rasdItemsListType = SdkUtil.Get<RasdItemsListType>(client, url, 200);
        if (rasdItemsListType != null && rasdItemsListType.Item != null)
        {
          foreach (RASD_Type virtualDiskItem in rasdItemsListType.Item)
            virtualDiskList.Add(new VirtualDisk(virtualDiskItem));
        }
        return virtualDiskList;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private cimString GetBusAddress(VirtualDisk disk, List<VirtualDisk> disks)
    {
      try
      {
        foreach (VirtualDisk disk1 in disks)
        {
          if (disk1.GetItemResource().ResourceType.Value.Equals("6") && disk.GetHostResourceAttributeValue("busType").Equals("6"))
          {
            if (disk1.GetItemResource().ResourceType.Value.Equals(disk.GetHardDiskBusType()) && disk1.GetItemResource().Address.Value.Equals(disk.GetItemResource().Address.Value))
              return disk1.GetItemResource().InstanceID;
          }
          else if (disk1.GetItemResource().ResourceType.Value.Equals("5") && disk.GetHostResourceAttributeValue("busType").Equals("5") && disk1.GetItemResource().Address.Value.Equals(disk.GetItemResource().Address.Value))
            return disk1.GetItemResource().InstanceID;
        }
        return (cimString) null;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private VirtualDisk CreateController(VirtualDisk disk)
    {
      try
      {
        RASD_Type virtualDiskItem = new RASD_Type();
        cimString cimString1 = new cimString();
        cimString1.Value = "";
        cimString cimString2 = new cimString();
        ResourceType1 resourceType1 = new ResourceType1();
        if (disk.GetHostResourceAttributeValue("busType").Equals("5"))
        {
          resourceType1.Value = "5";
        }
        else
        {
          cimString2.Value = disk.GetHardDiskBusType();
          resourceType1.Value = "6";
          virtualDiskItem.ResourceSubType = cimString2;
        }
        virtualDiskItem.ElementName = cimString1;
        virtualDiskItem.Description = cimString1;
        virtualDiskItem.InstanceID = cimString1;
        virtualDiskItem.Address = disk.GetItemResource().Address;
        virtualDiskItem.ResourceType = resourceType1;
        virtualDiskItem.InstanceID = disk.GetItemResource().Parent;
        return new VirtualDisk(virtualDiskItem);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void ProcessDisks(List<VirtualDisk> disks)
    {
      try
      {
        for (int index = 0; index < disks.Count; ++index)
        {
          if (disks[index].IsHardDisk() && disks[index].GetItemResource().AddressOnParent != null && disks[index].GetItemResource().Address != null)
          {
            cimString busAddress = this.GetBusAddress(disks[index], disks);
            if (busAddress != null)
              disks[index].GetItemResource().Parent = busAddress;
            else
              disks.Add(this.CreateController(disks[index]));
          }
        }
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task UpdateDisks(List<VirtualDisk> virtualDisks)
    {
      try
      {
        this.ProcessDisks(virtualDisks);
        string url = this.Reference.href + "/virtualHardwareSection/disks";
        string requestString = SerializationUtil.SerializeObject<RasdItemsListType>(this.GetRASDItemsList<VirtualDisk>(virtualDisks), "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.PUT_URL_MSG) + " - " + url);
        return new Task(this.VcloudClient, SdkUtil.Put<TaskType>(this.VcloudClient, url, requestString, "application/vnd.vmware.vcloud.rasdItemsList+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public List<VirtualNetworkCard> GetNetworkCards()
    {
      try
      {
        if (this._networkCards == null)
        {
          this._networkCards = new List<VirtualNetworkCard>();
          if (this._virtualHardwareSection != null)
          {
            List<RASD_Type> list = ((IEnumerable<RASD_Type>) this._virtualHardwareSection.Item).ToList<RASD_Type>();
            if (list != null)
            {
              foreach (RASD_Type virtualNetworkCardItem in list)
              {
                if (virtualNetworkCardItem.ResourceType.Value.Equals("10"))
                  this._networkCards.Add(new VirtualNetworkCard(virtualNetworkCardItem));
              }
            }
          }
        }
        return this._networkCards;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static List<VirtualNetworkCard> GetNetworkCards(
      vCloudClient client,
      ReferenceType vmRef)
    {
      try
      {
        string url = vmRef.href + "/virtualHardwareSection/networkCards";
        return VM.GetNetworkCardsByUrl(client, url);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private static List<VirtualNetworkCard> GetNetworkCardsByUrl(
      vCloudClient client,
      string url)
    {
      try
      {
        List<VirtualNetworkCard> virtualNetworkCardList = new List<VirtualNetworkCard>();
        RasdItemsListType rasdItemsListType = SdkUtil.Get<RasdItemsListType>(client, url, 200);
        if (rasdItemsListType != null && rasdItemsListType.Item != null)
        {
          foreach (RASD_Type virtualNetworkCardItem in rasdItemsListType.Item)
            virtualNetworkCardList.Add(new VirtualNetworkCard(virtualNetworkCardItem));
        }
        return virtualNetworkCardList;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task UpdateNetworkCards(List<VirtualNetworkCard> virtualNetworkCards)
    {
      try
      {
        string url = this.Reference.href + "/virtualHardwareSection/networkCards";
        string requestString = SerializationUtil.SerializeObject<RasdItemsListType>(this.GetRASDItemsList<VirtualNetworkCard>(virtualNetworkCards), "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.PUT_URL_MSG) + " - " + url);
        return new Task(this.VcloudClient, SdkUtil.Put<TaskType>(this.VcloudClient, url, requestString, "application/vnd.vmware.vcloud.rasdItemsList+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public List<VirtualMedia> GetMedias()
    {
      try
      {
        if (this._medias == null)
        {
          this._medias = new List<VirtualMedia>();
          if (this._virtualHardwareSection != null)
          {
            List<RASD_Type> list = ((IEnumerable<RASD_Type>) this._virtualHardwareSection.Item).ToList<RASD_Type>();
            if (list != null)
            {
              foreach (RASD_Type virtualMediaItem in list)
              {
                if (virtualMediaItem.ResourceType.Value.Equals("14") || virtualMediaItem.ResourceType.Value.Equals("15") || virtualMediaItem.ResourceType.Value.Equals("5"))
                  this._medias.Add(new VirtualMedia(virtualMediaItem));
              }
            }
          }
        }
        return this._medias;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static List<VirtualMedia> GetMedias(
      vCloudClient client,
      ReferenceType vmRef)
    {
      try
      {
        string url = vmRef.href + "/virtualHardwareSection/media";
        return VM.GetMediasByUrl(client, url);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private static List<VirtualMedia> GetMediasByUrl(
      vCloudClient client,
      string url)
    {
      try
      {
        List<VirtualMedia> virtualMediaList = new List<VirtualMedia>();
        RasdItemsListType rasdItemsListType = SdkUtil.Get<RasdItemsListType>(client, url, 200);
        if (rasdItemsListType != null)
        {
          foreach (RASD_Type virtualMediaItem in rasdItemsListType.Item)
            virtualMediaList.Add(new VirtualMedia(virtualMediaItem));
        }
        return virtualMediaList;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private RasdItemsListType GetRASDItemsList<T>(List<T> items) where T : HardwareItem
    {
      RasdItemsListType rasdItemsListType = new RasdItemsListType();
      rasdItemsListType.Item = new RASD_Type[items.Count];
      for (int index = 0; index < items.Count; ++index)
        rasdItemsListType.Item[index] = items[index].GetItemResource();
      return rasdItemsListType;
    }

    private void SortOvfSectionsAndReferences_v1_5()
    {
      if (this.Resource.Items != null)
      {
        foreach (Section_Type sectionType in this.Resource.Items)
        {
          if (sectionType is VirtualHardwareSection_Type)
            this._virtualHardwareSection = (VirtualHardwareSection_Type) sectionType;
          else if (sectionType is OperatingSystemSection_Type)
            this._operatingSystemSection = (OperatingSystemSection_Type) sectionType;
          else if (sectionType is NetworkConnectionSectionType)
            this._networkConnectionSection = (NetworkConnectionSectionType) sectionType;
          else if (sectionType is GuestCustomizationSectionType)
            this._guestCustomizationSection = (GuestCustomizationSectionType) sectionType;
          else if (sectionType is RuntimeInfoSectionType)
            this._runtimeInfoSection = (RuntimeInfoSectionType) sectionType;
          Logger.Log(TraceLevel.Information, sectionType.GetType().Name);
        }
      }
      foreach (LinkType linkType in this.Resource.Link)
      {
        if (linkType.rel.Equals("up") && linkType.type.Equals("application/vnd.vmware.vcloud.vApp+xml"))
          this._parentVappReference = (ReferenceType) linkType;
      }
      if (this.Resource.VCloudExtension == null)
        return;
      foreach (VCloudExtensionType vcloudExtensionType in this.Resource.VCloudExtension)
      {
        foreach (XmlElement xmlElement in vcloudExtensionType.Any)
        {
          try
          {
            this._vmVimInfoType = Response.GetResource<VmVimInfoType>(xmlElement.OuterXml);
            break;
          }
          catch
          {
          }
        }
        if (this._vmVimInfoType != null)
          break;
      }
    }

    public ReferenceType GetParentVappReference()
    {
      try
      {
        if (this._parentVappReference != null)
          return this._parentVappReference;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VimObjectRefType GetVMVimRef()
    {
      try
      {
        if (this._vmVimInfoType != null && this._vmVimInfoType.VmVimObjectRef != null)
          return this._vmVimInfoType.VmVimObjectRef;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.VIM_OBJECT_REF_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VimObjectRefType GetVMDatastoreVimRef()
    {
      try
      {
        if (this._vmVimInfoType != null && this._vmVimInfoType.DatastoreVimObjectRef != null)
          return this._vmVimInfoType.DatastoreVimObjectRef;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.VIM_OBJECT_REF_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VimObjectRefType GetVMHostVimRef()
    {
      try
      {
        if (this._vmVimInfoType != null && this._vmVimInfoType.HostVimObjectRef != null)
          return this._vmVimInfoType.HostVimObjectRef;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.VIM_OBJECT_REF_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public int GetVMDiskChainLength()
    {
      if (this._vmVimInfoType != null)
        return this._vmVimInfoType.VirtualDisksMaxChainLength;
      throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.DATA_NOT_FOUND));
    }

    public bool IsVMwareToolsInstalled()
    {
      try
      {
        return this.GetRuntimeInfoSection().VMWareTools != null;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public PlatformSection_Type GetPlatformSection()
    {
      try
      {
        if (this.GetResource().Environment != null)
        {
          foreach (object obj in this.GetResource().Environment.Items)
          {
            if (obj is PlatformSection_Type)
              return (PlatformSection_Type) obj;
          }
        }
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.DATA_NOT_FOUND));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public PropertySection_Type GetPropertySection()
    {
      try
      {
        if (this.GetResource().Environment != null)
        {
          foreach (object obj in this.GetResource().Environment.Items)
          {
            if (obj is PropertySection_Type)
              return (PropertySection_Type) obj;
          }
        }
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.DATA_NOT_FOUND));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public NetworkConnectionSectionType GetNetworkConnectionSection()
    {
      try
      {
        if (this._networkConnectionSection == null)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.DATA_NOT_FOUND));
        return this._networkConnectionSection;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static NetworkConnectionSectionType GetNetworkConnectionSection(
      vCloudClient client,
      ReferenceType vmRef)
    {
      try
      {
        return SdkUtil.Get<NetworkConnectionSectionType>(client, vmRef.href + "/networkConnectionSection/", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public List<NetworkConnectionType> GetNetworkConnections()
    {
      try
      {
        if (this._networkConnectionSection == null)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.DATA_NOT_FOUND));
        if (this._networkConnectionSection.NetworkConnection == null)
          return new List<NetworkConnectionType>();
        return ((IEnumerable<NetworkConnectionType>) this._networkConnectionSection.NetworkConnection).ToList<NetworkConnectionType>();
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Dictionary<int, string> GetIpAddressesById()
    {
      try
      {
        if (this._networkConnectionSection == null)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.DATA_NOT_FOUND));
        Dictionary<int, string> dictionary = new Dictionary<int, string>();
        if (this._networkConnectionSection.NetworkConnection != null)
        {
          foreach (NetworkConnectionType networkConnectionType in this._networkConnectionSection.NetworkConnection)
          {
            if (networkConnectionType.IpAddress != null)
              dictionary.Add(networkConnectionType.NetworkConnectionIndex, networkConnectionType.IpAddress);
            else if (networkConnectionType.IpAddressAllocationMode.Equals((object) IpAddressAllocationModeType.DHCP))
              dictionary.Add(networkConnectionType.NetworkConnectionIndex, IpAddressAllocationModeType.DHCP.ToString());
          }
        }
        return dictionary;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VmPendingQuestionType GetVmQuestion()
    {
      try
      {
        return SdkUtil.Get<VmPendingQuestionType>(this.VcloudClient, this.Reference.href + "/question", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static VmPendingQuestionType GetVmQuestion(
      vCloudClient client,
      ReferenceType vmRef)
    {
      try
      {
        string url = vmRef.href + "/question";
        return SdkUtil.Get<VmPendingQuestionType>(client, url, 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private static string CreateVmQuestionAnswerBody(int choiceId, string questionId)
    {
      return SerializationUtil.SerializeObject<VmQuestionAnswerType>(new VmQuestionAnswerType()
      {
        ChoiceId = choiceId,
        QuestionId = questionId.ToString()
      }, "com.vmware.vcloud.api.rest.schema");
    }

    public void AnswerVmQuestion(int choiceId, string questionId)
    {
      try
      {
        SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/question/action/answer", VM.CreateVmQuestionAnswerBody(choiceId, questionId), "application/vnd.vmware.vcloud.vmPendingAnswer+xml", 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Stream GetScreen()
    {
      try
      {
        return RestUtil.DownloadFile(this.VcloudClient, this.Reference.href + "/screen");
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ScreenTicketType AcquireTicket()
    {
      try
      {
        return SdkUtil.Post<ScreenTicketType>(this.VcloudClient, this.Reference.href + "/screen/action/acquireTicket", (string) null, (string) null, 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task InstallVMwareTools()
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/installVMwareTools", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task UpgradeHardware()
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/upgradeHardwareVersion", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task Consolidate()
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/consolidate", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task InstallVMwareTools(vCloudClient client, ReferenceType vmRef)
    {
      try
      {
        return new Task(client, SdkUtil.Post<TaskType>(client, vmRef.href + "/action/installVMwareTools", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task UpgradeHardware(vCloudClient client, ReferenceType vmRef)
    {
      try
      {
        return new Task(client, SdkUtil.Post<TaskType>(client, vmRef.href + "/action/upgradeHardwareVersion", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task Consolidate(vCloudClient client, ReferenceType vmRef)
    {
      try
      {
        return new Task(client, SdkUtil.Post<TaskType>(client, vmRef.href + "/action/consolidate", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    [Obsolete("This method is deprecated  since API 5.1, SDK 5.1")]
    public static Task Relocate(
      vCloudClient client,
      ReferenceType vmRef,
      ReferenceType datastoreReference)
    {
      try
      {
        string requestString = SerializationUtil.SerializeObject<RelocateParamsType>(new RelocateParamsType()
        {
          Datastore = datastoreReference
        }, "com.vmware.vcloud.api.rest.schema");
        return new Task(client, SdkUtil.Post<TaskType>(client, vmRef.href + "/action/relocate", requestString, "application/vnd.vmware.vcloud.relocateVmParams+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    [Obsolete("This method is deprecated  since API 5.1, SDK 5.1")]
    public Task Relocate(ReferenceType datastoreReference)
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/relocate", SerializationUtil.SerializeObject<RelocateParamsType>(new RelocateParamsType()
        {
          Datastore = datastoreReference
        }, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.vcloud.relocateVmParams+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task AttachDisk(ReferenceType diskRef)
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/disk/action/attach", SerializationUtil.SerializeObject<DiskAttachOrDetachParamsType>(new DiskAttachOrDetachParamsType()
        {
          Disk = diskRef
        }, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.vcloud.diskAttachOrDetachParams+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task AttachDisk(ReferenceType diskRef, short busNumber, short unitNumber)
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/disk/action/attach", SerializationUtil.SerializeObject<DiskAttachOrDetachParamsType>(new DiskAttachOrDetachParamsType()
        {
          Disk = diskRef,
          BusNumber = (int) busNumber,
          UnitNumber = (int) unitNumber
        }, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.vcloud.diskAttachOrDetachParams+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task DetachDisk(ReferenceType diskRef)
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/disk/action/detach", SerializationUtil.SerializeObject<DiskAttachOrDetachParamsType>(new DiskAttachOrDetachParamsType()
        {
          Disk = diskRef
        }, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.vcloud.diskAttachOrDetachParams+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task DetachDisk(ReferenceType diskRef, int busNumber, int unitNumber)
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/disk/action/detach", SerializationUtil.SerializeObject<DiskAttachOrDetachParamsType>(new DiskAttachOrDetachParamsType()
        {
          Disk = diskRef,
          BusNumber = busNumber,
          UnitNumber = unitNumber
        }, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.vcloud.diskAttachOrDetachParams+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public List<ReferenceType> GetAttachedDisks()
    {
      try
      {
        List<ReferenceType> referenceTypeList = new List<ReferenceType>();
        foreach (VirtualDisk disk in this.GetDisks())
        {
          if (disk.IsHardDisk())
          {
            try
            {
              referenceTypeList.Add(new ReferenceType()
              {
                href = disk.GetHostResourceAttributeValue("disk"),
                type = "application/vnd.vmware.vcloud.disk+xml"
              });
            }
            catch (VCloudException ex)
            {
              Logger.Log(TraceLevel.Information, disk.GetItemResource().ElementName.Value + " - not an independent disk attached to the vm");
            }
          }
        }
        return referenceTypeList;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task EnableNestedHypervisor()
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/enableNestedHypervisor", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task EnableNestedHypervisor(vCloudClient client, ReferenceType vmRef)
    {
      try
      {
        return new Task(client, SdkUtil.Post<TaskType>(client, vmRef.href + "/action/enableNestedHypervisor", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task DisableNestedHypervisor()
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/disableNestedHypervisor", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task DisableNestedHypervisor(vCloudClient client, ReferenceType vmRef)
    {
      try
      {
        return new Task(client, SdkUtil.Post<TaskType>(client, vmRef.href + "/action/disableNestedHypervisor", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task UpdateHotAdd(bool memoryHotAdd, bool cpuHotAdd)
    {
      try
      {
        return VM.UpdateHotAdd(this.VcloudClient, this.Reference, memoryHotAdd, cpuHotAdd);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task UpdateHotAdd(
      vCloudClient client,
      ReferenceType vmRef,
      bool memoryHotAdd,
      bool cpuHotAdd)
    {
      try
      {
        string requestString = SerializationUtil.SerializeObject<VmCapabilitiesType>(new VmCapabilitiesType()
        {
          CpuHotAddEnabled = cpuHotAdd,
          MemoryHotAddEnabled = memoryHotAdd
        }, "com.vmware.vcloud.api.rest.schema");
        return new Task(client, SdkUtil.Put<TaskType>(client, vmRef.href + "/vmCapabilities", requestString, "application/vnd.vmware.vcloud.vmCapabilitiesSection+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task CheckCompliance()
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Resource.href + "/action/checkCompliance", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task CheckCompliance(vCloudClient client, ReferenceType vmRef)
    {
      try
      {
        return new Task(client, SdkUtil.Post<TaskType>(client, vmRef.href + "/action/checkCompliance", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ComplianceResultType ComplianceResult()
    {
      try
      {
        return SdkUtil.Get<ComplianceResultType>(this.VcloudClient, this.Resource.href + "/complianceResult", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static ComplianceResultType ComplianceResult(
      vCloudClient client,
      ReferenceType vmRef)
    {
      try
      {
        return SdkUtil.Get<ComplianceResultType>(client, vmRef.href + "/complianceResult", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task ReconfigureVm(VmType vmType)
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/reconfigureVm", SerializationUtil.SerializeObject<VmType>(vmType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.vcloud.vm+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public MksTicketType AcquireMksTicket()
    {
      try
      {
        return SdkUtil.Post<MksTicketType>(this.VcloudClient, this.Reference.href + "/screen/action/acquireMksTicket", (string) null, (string) null, 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }
  }
}
