// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.Vapp
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
  public class Vapp : AbstractVapp<VAppType>
  {
    private Dictionary<string, ReferenceType> _vappNetworkRefsByName = new Dictionary<string, ReferenceType>();
    private Dictionary<string, FileType> _uploadFileMap = new Dictionary<string, FileType>();
    private Dictionary<string, FileType> _uploadedFileMap = new Dictionary<string, FileType>();
    private StartupSection_Type _startupSection;
    private NetworkSection_Type _networkSection;
    private NetworkConfigSectionType _networkConfigSection;
    private LeaseSettingsSectionType _leaseSettingsSection;
    private List<Vapp> _childrenvApps;
    private List<VM> _childrenVms;
    private ReferenceType _vdcReference;
    private Dictionary<string, string> vmUuidMap;

    public Vapp(vCloudClient client, VAppType vAppType)
      : base(client, vAppType)
    {
      this.SortOvfSectionsAndReferences_v1_5();
      this.SortVAppFiles();
    }

    public static Vapp GetVappByReference(vCloudClient client, ReferenceType vappRef)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + vappRef.href);
        VAppType resourceByReference = VcloudResource<VAppType>.GetResourceByReference(client, vappRef);
        return new Vapp(client, resourceByReference);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Vapp GetVappById(vCloudClient client, string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        VAppType entityById = VcloudEntity<VAppType>.GetEntityById(client, vCloudId, "application/vnd.vmware.vcloud.vApp+xml");
        return new Vapp(client, entityById);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task UpdateVapp(VAppType vAppType)
    {
      try
      {
        string href = this.Reference.href;
        string requestString = SerializationUtil.SerializeObject<VAppType>(vAppType, "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.PUT_URL_MSG) + " - " + href);
        return new Task(this.VcloudClient, SdkUtil.Put<TaskType>(this.VcloudClient, href, requestString, "application/vnd.vmware.vcloud.vApp+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VappStatus GetVappStatus()
    {
      return VappStatus.FromValue(this.Resource.status);
    }

    public List<Vapp> GetChildrenVapps()
    {
      try
      {
        if (this._childrenvApps == null)
        {
          this._childrenvApps = new List<Vapp>();
          if (this.Resource.Children != null)
          {
            VAppChildrenType children = this.Resource.Children;
            if (children != null && children.VApp != null)
            {
              foreach (VAppType vAppType in children.VApp)
                this._childrenvApps.Add(new Vapp(this.VcloudClient, vAppType));
            }
          }
        }
        return this._childrenvApps;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public List<VM> GetChildrenVms()
    {
      try
      {
        if (this._childrenVms == null)
        {
          this._childrenVms = new List<VM>();
          if (this.Resource.Children != null)
          {
            VAppChildrenType children = this.Resource.Children;
            if (children != null && children.Vm != null)
            {
              foreach (VmType vmType in ((IEnumerable<VmType>) children.Vm).ToList<VmType>())
                this._childrenVms.Add(new VM(this.VcloudClient, vmType));
            }
          }
        }
        return this._childrenVms;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public LeaseSettingsSectionType GetLeaseSettingsSection()
    {
      try
      {
        if (this._leaseSettingsSection == null)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.DATA_NOT_FOUND));
        return this._leaseSettingsSection;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static LeaseSettingsSectionType GetLeaseSettingsSection(
      vCloudClient client,
      ReferenceType vappRef)
    {
      try
      {
        return SdkUtil.Get<LeaseSettingsSectionType>(client, vappRef.href + "/leaseSettingsSection/", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public StartupSection_Type GetStartUpSection()
    {
      try
      {
        if (this._startupSection == null)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.DATA_NOT_FOUND));
        return this._startupSection;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static StartupSection_Type GetStartUpSection(
      vCloudClient client,
      ReferenceType vappRef)
    {
      try
      {
        return SdkUtil.Get<StartupSection_Type>(client, vappRef.href + "/startupSection/", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public NetworkSection_Type GetNetworkSection()
    {
      try
      {
        if (this._networkSection == null)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.DATA_NOT_FOUND));
        return this._networkSection;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static NetworkSection_Type GetNetworkSection(
      vCloudClient client,
      ReferenceType vappRef)
    {
      try
      {
        return SdkUtil.Get<NetworkSection_Type>(client, vappRef.href + "/networkSection/", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Dictionary<string, NetworkSection_TypeNetwork> GetNetworksByName()
    {
      try
      {
        Dictionary<string, NetworkSection_TypeNetwork> dictionary = new Dictionary<string, NetworkSection_TypeNetwork>();
        if (this._networkSection != null && this._networkSection.Network != null)
          dictionary = ((IEnumerable<NetworkSection_TypeNetwork>) this._networkSection.Network).ToList<NetworkSection_TypeNetwork>().ToDictionary<NetworkSection_TypeNetwork, string, NetworkSection_TypeNetwork>((Func<NetworkSection_TypeNetwork, string>) (network => network.name), (Func<NetworkSection_TypeNetwork, NetworkSection_TypeNetwork>) (network => network));
        return dictionary;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public NetworkSection_TypeNetwork GetNetworkByName(string networkName)
    {
      try
      {
        return this.GetNetworksByName()[networkName];
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public List<string> GetNetworkNames()
    {
      try
      {
        if (this.GetNetworksByName() != null)
          return this.GetNetworksByName().Keys.ToList<string>();
        return new List<string>();
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public List<NetworkSection_TypeNetwork> GetNetworks()
    {
      try
      {
        if (this.GetNetworksByName() != null)
          return this.GetNetworksByName().Values.ToList<NetworkSection_TypeNetwork>();
        return new List<NetworkSection_TypeNetwork>();
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public NetworkConfigSectionType GetNetworkConfigSection()
    {
      try
      {
        if (this._networkConfigSection == null)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.DATA_NOT_FOUND));
        return this._networkConfigSection;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static NetworkConfigSectionType GetNetworkConfigSection(
      vCloudClient client,
      ReferenceType vappRef)
    {
      try
      {
        return SdkUtil.Get<NetworkConfigSectionType>(client, vappRef.href + "/networkConfigSection/", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Dictionary<string, ReferenceType> GetVappNetworkRefsByName()
    {
      return this._vappNetworkRefsByName;
    }

    public Dictionary<string, VAppNetworkConfigurationType> GetVappNetworkConfigurationsByName()
    {
      try
      {
        if (this._networkConfigSection == null)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.DATA_NOT_FOUND));
        Dictionary<string, VAppNetworkConfigurationType> dictionary = new Dictionary<string, VAppNetworkConfigurationType>();
        if (this._networkConfigSection != null && this._networkConfigSection.NetworkConfig != null)
        {
          List<VAppNetworkConfigurationType> list = ((IEnumerable<VAppNetworkConfigurationType>) this._networkConfigSection.NetworkConfig).ToList<VAppNetworkConfigurationType>();
          if (list != null)
            dictionary = list.ToDictionary<VAppNetworkConfigurationType, string, VAppNetworkConfigurationType>((Func<VAppNetworkConfigurationType, string>) (vAppNetConfigType => vAppNetConfigType.networkName), (Func<VAppNetworkConfigurationType, VAppNetworkConfigurationType>) (vAppNetConfigType => vAppNetConfigType));
        }
        return dictionary;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VAppNetworkConfigurationType GetVappNetworkConfigurationByName(
      string vappNetworkConfigurationName)
    {
      try
      {
        return this.GetVappNetworkConfigurationsByName()[vappNetworkConfigurationName];
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public List<string> GetVappNetworkConfigurationNames()
    {
      try
      {
        if (this.GetVappNetworkConfigurationsByName() != null)
          return this.GetVappNetworkConfigurationsByName().Keys.ToList<string>();
        return new List<string>();
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public List<VAppNetworkConfigurationType> GetVappNetworkConfigurations()
    {
      try
      {
        if (this.GetVappNetworkConfigurationsByName() != null)
          return this.GetVappNetworkConfigurationsByName().Values.ToList<VAppNetworkConfigurationType>();
        return new List<VAppNetworkConfigurationType>();
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
        if (sectionType is LeaseSettingsSectionType)
        {
          requestString = SerializationUtil.SerializeObject<LeaseSettingsSectionType>((LeaseSettingsSectionType) sectionType, "com.vmware.vcloud.api.rest.schema");
          url = href + "/leaseSettingsSection/";
          mediaType = "application/vnd.vmware.vcloud.leaseSettingsSection+xml";
        }
        else if (sectionType is StartupSection_Type)
        {
          requestString = SerializationUtil.SerializeObject<StartupSection_Type>((StartupSection_Type) sectionType, "com.vmware.vcloud.api.rest.schema");
          url = href + "/startupSection/";
          mediaType = "application/vnd.vmware.vcloud.startupSection+xml";
        }
        else if (sectionType is NetworkConfigSectionType)
        {
          requestString = SerializationUtil.SerializeObject<NetworkConfigSectionType>((NetworkConfigSectionType) sectionType, "com.vmware.vcloud.api.rest.schema");
          url = href + "/networkConfigSection/";
          mediaType = "application/vnd.vmware.vcloud.networkConfigSection+xml";
        }
        else
        {
          Logger.Log(TraceLevel.Information, sectionType.GetType().Name + " - " + SdkUtil.GetI18nString(SdkMessage.NOT_VALID_SECTION_MSG));
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.NOT_VALID_SECTION_MSG));
        }
        return new Task(this.VcloudClient, SdkUtil.Put<TaskType>(this.VcloudClient, url, requestString, mediaType, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ControlAccessParamsType GetControlAccess()
    {
      try
      {
        string url = this.Reference.href + "/controlAccess/";
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + url);
        return SdkUtil.Get<ControlAccessParamsType>(this.VcloudClient, url, 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ControlAccessParamsType UpdateControlAccess(
      ControlAccessParamsType controlAccessParams)
    {
      try
      {
        string url = this.Reference.href + "/action/controlAccess";
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.POST_URL_MSG) + " - " + url);
        string requestString = SerializationUtil.SerializeObject<ControlAccessParamsType>(controlAccessParams, "com.vmware.vcloud.api.rest.schema");
        return SdkUtil.Post<ControlAccessParamsType>(this.VcloudClient, url, requestString, "application/vnd.vmware.vcloud.controlAccess+xml", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ulong GetVappSize()
    {
      try
      {
        ulong num = 0;
        foreach (VM childrenVm in this.GetChildrenVms())
          num += childrenVm.GetVmSize();
        return num;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType GetVdcReference()
    {
      try
      {
        if (this._vdcReference != null)
          return this._vdcReference;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VimObjectRefType GetNetworkVimRef(string vAppNetworkName)
    {
      try
      {
        VAppNetworkConfigurationType configurationByName = this.GetVappNetworkConfigurationByName(vAppNetworkName);
        if (configurationByName != null && configurationByName.VCloudExtension != null)
        {
          foreach (VCloudExtensionType vcloudExtensionType in configurationByName.VCloudExtension)
          {
            if (vcloudExtensionType.Any != null)
            {
              XmlElement[] any = vcloudExtensionType.Any;
              int index = 0;
              if (index < any.Length)
                return Response.GetResource<VimObjectRefType>(any[index].OuterXml);
            }
          }
        }
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.VIM_OBJECT_REF_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task RecomposeVapp(RecomposeVAppParamsType recomposeVappParamsType)
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Resource.href + "/action/recomposeVApp", SerializationUtil.SerializeObject<RecomposeVAppParamsType>(recomposeVappParamsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.vcloud.recomposeVAppParams+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType GetOwner()
    {
      try
      {
        return this.Resource.Owner.User;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static ReferenceType GetOwner(vCloudClient client, ReferenceType vappRef)
    {
      try
      {
        string url = vappRef.href + "/owner";
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + url);
        return SdkUtil.Get<OwnerType>(client, url, 200).User;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static void ChangeOwner(
      vCloudClient client,
      ReferenceType vappRef,
      ReferenceType userReference)
    {
      try
      {
        Vapp.ChangeOwner(vappRef.href + "/owner", userReference, client);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void ChangeOwner(ReferenceType userReference)
    {
      try
      {
        Vapp.ChangeOwner(this.Reference.href + "/owner", userReference, this.VcloudClient);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task ResetvAppNetwork(string vAppNetworkName)
    {
      try
      {
        foreach (LinkType linkType in this.GetVappNetworkConfigurationByName(vAppNetworkName).Link)
        {
          if (linkType.rel.Equals("repair"))
            return AbstractVapp<VAppType>.ExecuteAbstractVappAction(this.VcloudClient, linkType.href, (string) null, (string) null, 202);
        }
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.RESOURCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task SyncSyslogServer(string vAppNetworkName)
    {
      try
      {
        foreach (LinkType linkType in this.GetVappNetworkConfigurationByName(vAppNetworkName).Link)
        {
          if (linkType.rel.Equals("syncSyslogSettings"))
            return AbstractVapp<VAppType>.ExecuteAbstractVappAction(this.VcloudClient, linkType.href, (string) null, (string) null, 202);
        }
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.RESOURCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void EnableMaintenance()
    {
      try
      {
        SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/enterMaintenanceMode", (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void DisableMaintenance()
    {
      try
      {
        SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/exitMaintenanceMode", (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static void EnableMaintenance(vCloudClient client, ReferenceType vappRef)
    {
      try
      {
        string url = vappRef.href + "/action/enterMaintenanceMode";
        SdkUtil.Post<TaskType>(client, url, (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static void DisableMaintenance(vCloudClient client, ReferenceType vappRef)
    {
      try
      {
        string url = vappRef.href + "/action/exitMaintenanceMode";
        SdkUtil.Post<TaskType>(client, url, (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static EnvelopeType GetOvf(vCloudClient client, ReferenceType vappRef)
    {
      try
      {
        return Vapp.GetOvf(client, vappRef.href + "/ovf");
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public EnvelopeType GetOvf()
    {
      try
      {
        return Vapp.GetOvf(this.VcloudClient, this.Reference.href + "/ovf");
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task EnableDownload()
    {
      return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/enableDownload", (string) null, (string) null, 202));
    }

    public static Task EnableDownload(vCloudClient client, ReferenceType vappRef)
    {
      string url = vappRef.href + "/action/enableDownload";
      return new Task(client, SdkUtil.Post<TaskType>(client, url, (string) null, (string) null, 202));
    }

    public void DisableDownload()
    {
      SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/disableDownload", (string) null, (string) null, 204);
    }

    public static void DisableDownload(vCloudClient client, ReferenceType vappRef)
    {
      string url = vappRef.href + "/action/disableDownload";
      SdkUtil.Post<TaskType>(client, url, (string) null, (string) null, 204);
    }

    public Stream DownloadOVFFile()
    {
      try
      {
        Stream stream = (Stream) null;
        if (this.Resource.Link != null)
        {
          foreach (LinkType linkType in this.Resource.Link)
          {
            if (linkType.rel.Equals("download:default"))
            {
              stream = RestUtil.DownloadFile(this.VcloudClient, linkType.href);
              break;
            }
          }
        }
        if (stream == null)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.NO_DOWNLOAD_LINK_MSG));
        return stream;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Stream DownloadLosslessOVF()
    {
      foreach (LinkType linkType in this.Resource.Link)
      {
        if (linkType.rel.Equals("download:identity"))
          return RestUtil.DownloadFile(this.VcloudClient, linkType.href);
      }
      throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.NO_DOWNLOAD_LINK_MSG));
    }

    public Dictionary<string, File_Type> GetDownloadFileNames()
    {
      try
      {
        Dictionary<string, File_Type> dictionary = new Dictionary<string, File_Type>();
        EnvelopeType envelopeType = this.DownloadOvfEnvelope();
        if (envelopeType != null)
        {
          References_Type references = envelopeType.References;
          if (references != null && references.File != null)
          {
            List<File_Type> list = ((IEnumerable<File_Type>) references.File).ToList<File_Type>();
            if (list != null)
              dictionary = list.Distinct<File_Type>((IEqualityComparer<File_Type>) new LambdaComparer<File_Type>((Func<File_Type, File_Type, bool>) ((file1, file2) => file1.href == file2.href))).ToList<File_Type>().ToDictionary<File_Type, string, File_Type>((Func<File_Type, string>) (file => file.href), (Func<File_Type, File_Type>) (file => file));
          }
        }
        return dictionary;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Stream DownloadFile(string fileName)
    {
      try
      {
        Stream stream = (Stream) null;
        if (this.Resource.Link != null)
        {
          foreach (LinkType linkType in this.Resource.Link)
          {
            if (linkType.rel.Equals("download:default"))
              return this.DownloadFile(fileName, linkType.href);
          }
        }
        if (stream == null)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.NO_DOWNLOAD_LINK_MSG));
        return stream;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void DownloadVapp(string downloadLocation)
    {
      try
      {
        List<string> list = this.GetDownloadFileNames().Keys.ToList<string>();
        Stream inputStream1 = this.DownloadOVFFile();
        this.WriteToFile(downloadLocation, "descriptor.ovf", inputStream1);
        foreach (string fileName in list)
        {
          Stream inputStream2 = this.DownloadFile(fileName);
          this.WriteToFile(downloadLocation, fileName, inputStream2);
        }
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public List<string> GetUploadFileNames()
    {
      try
      {
        if (!this.Resource.ovfDescriptorUploaded)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.OVF_DESCRIPTOR_NOT_UPLOADED_NO_FILES_MSG));
        if (this._uploadFileMap != null && this._uploadFileMap.Keys != null)
          return this._uploadFileMap.Keys.ToList<string>();
        return new List<string>();
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public List<string> GetUploadedFileNames()
    {
      try
      {
        if (this._uploadedFileMap != null && this._uploadedFileMap.Keys != null)
          return this._uploadedFileMap.Keys.ToList<string>();
        return new List<string>();
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void UploadOVFFile(Stream inputStream, long size)
    {
      try
      {
        if (this.Resource.ovfDescriptorUploaded)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.OVF_DESCRIPTOR_ALREADY_UPLOADED_MSG));
        if (this._uploadFileMap.Count != 1)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.INVALID_NO_FILES_MSG) + " - " + (object) this._uploadFileMap.Count);
        Dictionary<string, FileType> uploadFileMap = this._uploadFileMap;
        if (uploadFileMap == null)
          return;
        RestUtil.UploadFile(this.VcloudClient, this._uploadFileMap[uploadFileMap.FirstOrDefault<KeyValuePair<string, FileType>>().Key], inputStream, size, 0L, 0L);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void UploadFile(string fileName, Stream inputStream, long size)
    {
      try
      {
        if (!this.Resource.ovfDescriptorUploaded)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.OVF_DESCRIPTOR_NOT_UPLOADED_MSG));
        if (this._uploadFileMap == null)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.NO_FILES_TO_UPLOAD_MSG));
        FileType uploadFile = this._uploadFileMap[fileName];
        if (uploadFile == null)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.FILE_NOT_FOUND_MSG));
        RestUtil.UploadFile(this.VcloudClient, uploadFile, inputStream, size, 0L, 0L);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public string GetOvfAsString()
    {
      try
      {
        return SerializationUtil.SerializeObject<EnvelopeType>(this.GetOvf(), "com.vmware.vcloud.api.rest.schema.ovf");
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Dictionary<string, string> GetVmUUIDsByName()
    {
      try
      {
        if (this.vmUuidMap != null)
          return this.vmUuidMap;
        this.vmUuidMap = new Dictionary<string, string>();
        EnvelopeType ovf = this.GetOvf();
        if (ovf != null && ovf.Item is VirtualSystemCollection_Type)
        {
          foreach (VirtualSystem_Type virtualSystemType in ((VirtualSystemCollection_Type) ovf.Item).Items1)
          {
            string key = virtualSystemType.Name.Value;
            foreach (Section_Type sectionType in virtualSystemType.Items)
            {
              if (sectionType is VirtualHardwareSection_Type)
              {
                foreach (XmlNode xmlNode in ((VirtualHardwareSection_Type) sectionType).Any)
                {
                  XmlAttributeCollection attributes = xmlNode.Attributes;
                  if (attributes.Item(1).Value.Equals("uuid"))
                    this.vmUuidMap.Add(key, attributes.Item(0).Value);
                }
              }
            }
          }
        }
        return this.vmUuidMap;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private static EnvelopeType GetOvf(vCloudClient client, string vAppOvfUrl)
    {
      try
      {
        return SdkUtil.Get<EnvelopeType>(client, vAppOvfUrl, 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void SortOvfSectionsAndReferences_v1_5()
    {
      if (this.Resource.Items == null)
        return;
      foreach (Section_Type sectionType in this.Resource.Items)
      {
        if (sectionType is NetworkConfigSectionType)
          this._networkConfigSection = (NetworkConfigSectionType) sectionType;
        else if (sectionType is NetworkSection_Type)
          this._networkSection = (NetworkSection_Type) sectionType;
        else if (sectionType is LeaseSettingsSectionType)
          this._leaseSettingsSection = (LeaseSettingsSectionType) sectionType;
        else if (sectionType is StartupSection_Type)
          this._startupSection = (StartupSection_Type) sectionType;
        Logger.Log(TraceLevel.Information, sectionType.GetType().Name);
      }
      if (this.Resource.Link == null)
        return;
      foreach (LinkType linkType in this.Resource.Link)
      {
        if (this._vdcReference != null)
          break;
        if (linkType.rel != null && linkType.type != null)
        {
          if (linkType.rel.Equals("up") && linkType.type.Equals("application/vnd.vmware.vcloud.vdc+xml"))
            this._vdcReference = (ReferenceType) linkType;
          else if (linkType.rel.Equals("down") && linkType.type.Equals("application/vnd.vmware.vcloud.vAppNetwork+xml"))
            this._vappNetworkRefsByName.Add(linkType.name, (ReferenceType) linkType);
        }
      }
    }

    private static void ChangeOwner(string url, ReferenceType userReference, vCloudClient client)
    {
      try
      {
        string requestString = SerializationUtil.SerializeObject<OwnerType>(new OwnerType()
        {
          User = userReference
        }, "com.vmware.vcloud.api.rest.schema");
        SdkUtil.Put<TaskType>(client, url, requestString, "application/vnd.vmware.vcloud.owner+xml", 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private Stream DownloadFile(string fileName, string href)
    {
      try
      {
        if (!this.GetDownloadFileNames().ContainsKey(fileName))
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.FILE_NOT_FOUND_MSG));
        return RestUtil.DownloadFile(this.VcloudClient, href.Replace("descriptor.ovf", fileName));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private EnvelopeType DownloadOvfEnvelope()
    {
      try
      {
        if (this.Resource.Link != null)
        {
          foreach (LinkType linkType in this.Resource.Link)
          {
            if (linkType.rel.Equals("download:default"))
              return SerializationUtil.DeserializeObject<EnvelopeType>(RestUtil.DownloadFile(this.VcloudClient, linkType.href), "com.vmware.vcloud.api.rest.schema");
          }
        }
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.NO_DOWNLOAD_LINK_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void WriteToFile(string downloadLocation, string fileName, Stream inputStream)
    {
      string path = downloadLocation + "/" + fileName;
      BinaryWriter binaryWriter;
      try
      {
        binaryWriter = new BinaryWriter((Stream) File.Create(path));
      }
      catch (FileNotFoundException ex)
      {
        throw new VCloudRuntimeException((Exception) ex);
      }
      byte[] buffer = new byte[1024];
      try
      {
        int count;
        while ((count = inputStream.Read(buffer, 0, buffer.Length)) > 0)
          binaryWriter.Write(buffer, 0, count);
      }
      catch (IOException ex)
      {
        throw new VCloudRuntimeException((Exception) ex);
      }
      finally
      {
        try
        {
          if (binaryWriter != null)
          {
            binaryWriter.Flush();
            binaryWriter.Close();
          }
          inputStream?.Close();
        }
        catch (IOException ex)
        {
          throw new VCloudRuntimeException((Exception) ex);
        }
      }
    }

    private void SortVAppFiles()
    {
      if (this.Resource.Files == null)
        return;
      FilesListType files = this.Resource.Files;
      if (files == null)
        return;
      List<FileType> list = ((IEnumerable<FileType>) files.File).ToList<FileType>();
      if (list == null)
        return;
      this._uploadedFileMap = list.Where<FileType>((Func<FileType, bool>) (file => file.size.CompareTo(file.bytesTransferred).Equals(0))).ToDictionary<FileType, string, FileType>((Func<FileType, string>) (file => file.name), (Func<FileType, FileType>) (file => file));
      this._uploadFileMap = list.Where<FileType>((Func<FileType, bool>) (file => !file.size.CompareTo(file.bytesTransferred).Equals(0))).ToDictionary<FileType, string, FileType>((Func<FileType, string>) (file => file.name), (Func<FileType, FileType>) (file => file));
    }

    protected new void Dispose(bool disposing)
    {
    }

    public new void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }
  }
}
