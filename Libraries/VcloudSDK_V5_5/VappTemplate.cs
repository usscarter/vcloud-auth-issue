// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.VappTemplate
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
  public class VappTemplate : VcloudEntity<VAppTemplateType>
  {
    private Dictionary<string, FileType> _uploadFileMap = new Dictionary<string, FileType>();
    private Dictionary<string, FileType> _uploadedFileMap = new Dictionary<string, FileType>();
    private List<ProductSection_Type> _productSections = new List<ProductSection_Type>();
    private List<VappTemplate> _childrenvAppTemplates;
    private NetworkConnectionSectionType _networkConnectionSection;
    private NetworkConfigSectionType _networkConfigSection;
    private NetworkSection_Type _networkSection;
    private LeaseSettingsSectionType _leaseSettingsSection;
    private CustomizationSectionType _customizationSection;
    private GuestCustomizationSectionType _guestCustomizationSection;
    private ReferenceType _vdcReference;
    private ReferenceType _catalogItemReference;
    private ReferenceType _parentVappTemplateReference;
    private VmVimInfoType vmVimInfoType;
    private ReferenceType _storageProfileRef;

    public VappTemplate(vCloudClient client, VAppTemplateType vAppTemplateType_v1_5)
      : base(client, vAppTemplateType_v1_5)
    {
      this.SortVAppTemplateFiles_v1_5();
      this.SortOvfSectionAndReferences_v1_5();
    }

    public bool IsVm()
    {
      return this.Reference.type.Equals("application/vnd.vmware.vcloud.vm+xml");
    }

    public List<VappTemplate> GetChildren()
    {
      if (this._childrenvAppTemplates == null)
      {
        this._childrenvAppTemplates = new List<VappTemplate>();
        if (this.Resource.Children != null)
        {
          VAppTemplateChildrenType children = this.Resource.Children;
          if (children != null && children.Vm != null)
          {
            foreach (VAppTemplateType vAppTemplateType_v1_5 in ((IEnumerable<VAppTemplateType>) children.Vm).ToList<VAppTemplateType>())
              this._childrenvAppTemplates.Add(new VappTemplate(this.VcloudClient, vAppTemplateType_v1_5));
          }
        }
      }
      return this._childrenvAppTemplates;
    }

    public static VappTemplate GetVappTemplateByReference(
      vCloudClient client,
      ReferenceType vappTemplRef)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + vappTemplRef.href);
        return new VappTemplate(client, VcloudResource<VAppTemplateType>.GetResourceByReference(client, vappTemplRef));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static VappTemplate GetVappTemplateById(vCloudClient client, string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        if (vCloudId.Contains(com.vmware.vcloud.sdk.constants.EntityType.VM.Value()))
          return new VappTemplate(client, VcloudEntity<VAppTemplateType>.GetEntityById(client, vCloudId, "application/vnd.vmware.vcloud.vm+xml"));
        return new VappTemplate(client, VcloudEntity<VAppTemplateType>.GetEntityById(client, vCloudId, "application/vnd.vmware.vcloud.vAppTemplate+xml"));
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

    public ReferenceType GetVdcStorageProfileReference()
    {
      if (this._storageProfileRef != null)
        return this._storageProfileRef;
      throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
    }

    public ReferenceType GetCatalogItemReference()
    {
      try
      {
        if (this._catalogItemReference != null)
          return this._catalogItemReference;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType GetParentVappTemplateReference()
    {
      try
      {
        if (this._parentVappTemplateReference != null)
          return this._parentVappTemplateReference;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
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
        if (this.vmVimInfoType != null && this.vmVimInfoType.DatastoreVimObjectRef != null)
          return this.vmVimInfoType.DatastoreVimObjectRef;
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
        if (this.vmVimInfoType != null && this.vmVimInfoType.HostVimObjectRef != null)
          return this.vmVimInfoType.HostVimObjectRef;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.VIM_OBJECT_REF_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public int GetVMDiskChainLength()
    {
      if (this.vmVimInfoType != null)
        return this.vmVimInfoType.VirtualDisksMaxChainLength;
      throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.DATA_NOT_FOUND));
    }

    public VimObjectRefType GetVMVimRef()
    {
      try
      {
        if (this.Resource != null && this.Resource.VCloudExtension != null)
        {
          foreach (VCloudExtensionType vcloudExtensionType in this.Resource.VCloudExtension)
          {
            if (vcloudExtensionType.Any != null)
            {
              foreach (XmlNode xmlNode in vcloudExtensionType.Any)
              {
                VmVimInfoType resource = Response.GetResource<VmVimInfoType>(xmlNode.OuterXml);
                if (resource.VmVimObjectRef.VimObjectType.Equals(VimObjectTypeEnum.VIRTUAL_MACHINE.Value()))
                  return resource.VmVimObjectRef;
              }
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

    public VappTemplateStatus GetVappTemplateStatus()
    {
      return VappTemplateStatus.FromValue(this.Resource.status);
    }

    public static EnvelopeType GetOvf(
      vCloudClient client,
      ReferenceType vappTemplateRef)
    {
      try
      {
        return VappTemplate.GetOvf(client, vappTemplateRef.href + "/ovf");
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
        return VappTemplate.GetOvf(this.VcloudClient, this.Reference.href + "/ovf");
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static EnvelopeType GetOvf(vCloudClient client, string vAppTemplateOvfUrl)
    {
      try
      {
        return SdkUtil.Get<EnvelopeType>(client, vAppTemplateOvfUrl, 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task Delete()
    {
      try
      {
        return VappTemplate.DeletevAppTemplate(this.VcloudClient, this.Reference.href);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task Delete(vCloudClient client, ReferenceType vAppTemplateRef)
    {
      try
      {
        return VappTemplate.DeletevAppTemplate(client, vAppTemplateRef.href);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void DisableDownload()
    {
      try
      {
        SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/disableDownload", (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static void DisableDownload(vCloudClient client, ReferenceType vAppTemplateRef)
    {
      try
      {
        string url = vAppTemplateRef.href + "/action/disableDownload";
        SdkUtil.Post<TaskType>(client, url, (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task EnableDownload()
    {
      try
      {
        return VappTemplate.ExecuteVappTemplateAction(this.VcloudClient, this.Reference.href + "/action/enableDownload", (string) null, (string) null, 202);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task EnableDownload(vCloudClient client, ReferenceType vAppTemplateRef)
    {
      try
      {
        string vappActionUrl = vAppTemplateRef.href + "/action/enableDownload";
        return VappTemplate.ExecuteVappTemplateAction(client, vappActionUrl, (string) null, (string) null, 202);
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

    public static Task Consolidate(vCloudClient client, ReferenceType vappTemplateVmRef)
    {
      try
      {
        return new Task(client, SdkUtil.Post<TaskType>(client, vappTemplateVmRef.href + "/action/consolidate", (string) null, (string) null, 202));
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

    public void UploadFile(string fileName, Stream inputStream, long startByte, long endByte)
    {
      try
      {
        if (!this.Resource.ovfDescriptorUploaded)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.OVF_DESCRIPTOR_NOT_UPLOADED_MSG));
        if (this._uploadFileMap == null || this._uploadFileMap.Count == 0)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.NO_FILES_TO_UPLOAD_MSG));
        FileType uploadFile = this._uploadFileMap[fileName];
        if (uploadFile == null)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.FILE_NOT_FOUND_MSG));
        RestUtil.UploadFile(this.VcloudClient, uploadFile, inputStream, uploadFile.size, startByte, endByte);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void DownloadVappTemplate(string downloadLocation)
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

    public string GetOVFDownloadURL()
    {
      try
      {
        string str = string.Empty;
        if (this.Resource.Link != null)
        {
          foreach (LinkType linkType in this.Resource.Link)
          {
            if (linkType.rel.Equals("download:default"))
            {
              str = linkType.href;
              break;
            }
          }
        }
        if (str.Trim().Length == 0)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.NO_DOWNLOAD_LINK_MSG));
        return str;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
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

    public Dictionary<string, FileType> MonitorUpload()
    {
      try
      {
        Dictionary<string, FileType> dictionary = new Dictionary<string, FileType>();
        VappTemplate templateByReference = VappTemplate.GetVappTemplateByReference(this.VcloudClient, this.Reference);
        if (templateByReference != null && templateByReference.Resource != null && templateByReference.Resource.Files != null)
        {
          FilesListType files = templateByReference.Resource.Files;
          if (files != null && files.File != null)
          {
            List<FileType> list = ((IEnumerable<FileType>) files.File).ToList<FileType>();
            if (list != null)
              dictionary = list.ToDictionary<FileType, string, FileType>((Func<FileType, string>) (file => file.name), (Func<FileType, FileType>) (file => file));
          }
        }
        return dictionary;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task UpdateVappTemplate(VAppTemplateType vappTemplateType)
    {
      try
      {
        string requestString = SerializationUtil.SerializeObject<VAppTemplateType>(vappTemplateType, "com.vmware.vcloud.api.rest.schema");
        string href = this.Reference.href;
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.PUT_URL_MSG) + " - " + href);
        return new Task(this.VcloudClient, SdkUtil.Put<TaskType>(this.VcloudClient, href, requestString, "application/vnd.vmware.vcloud.vAppTemplate+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public List<ProductSection_Type> GetProductSections()
    {
      try
      {
        return this._productSections;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static List<ProductSection_Type> GetProductSections(
      vCloudClient client,
      ReferenceType vappRef)
    {
      try
      {
        ProductSectionListType productSectionListType = SdkUtil.Get<ProductSectionListType>(client, vappRef.href + "/productSections/", 200);
        if (productSectionListType.ProductSection != null)
          return ((IEnumerable<ProductSection_Type>) productSectionListType.ProductSection).ToList<ProductSection_Type>();
        return new List<ProductSection_Type>();
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public NetworkSection_Type GetNetworkSection()
    {
      return this._networkSection;
    }

    public static NetworkSection_Type GetNetworkSection(
      vCloudClient client,
      ReferenceType vappTemplateRef)
    {
      try
      {
        return SdkUtil.Get<NetworkSection_Type>(client, vappTemplateRef.href + "/networkSection/", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public NetworkConfigSectionType GetNetworkConfigSection()
    {
      return this._networkConfigSection;
    }

    public static NetworkConfigSectionType GetNetworkConfigSection(
      vCloudClient client,
      ReferenceType vappTemplateRef)
    {
      try
      {
        return SdkUtil.Get<NetworkConfigSectionType>(client, vappTemplateRef.href + "/networkConfigSection/", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public LeaseSettingsSectionType GetLeaseSettingsSection()
    {
      return this._leaseSettingsSection;
    }

    public static LeaseSettingsSectionType GetLeaseSettingsSection(
      vCloudClient client,
      ReferenceType vappTemplateRef)
    {
      try
      {
        return SdkUtil.Get<LeaseSettingsSectionType>(client, vappTemplateRef.href + "/leaseSettingsSection/", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public NetworkConnectionSectionType GetNetworkConnectionSection()
    {
      return this._networkConnectionSection;
    }

    public static NetworkConnectionSectionType GetNetworkConnectionSection(
      vCloudClient client,
      ReferenceType vappTemplateRef)
    {
      try
      {
        return SdkUtil.Get<NetworkConnectionSectionType>(client, vappTemplateRef.href + "/networkConnectionSection/", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public GuestCustomizationSectionType GetGuestCustomizationSection()
    {
      return this._guestCustomizationSection;
    }

    public static GuestCustomizationSectionType GetGuestCustomizationSection(
      vCloudClient client,
      ReferenceType vappTemplateRef)
    {
      try
      {
        return SdkUtil.Get<GuestCustomizationSectionType>(client, vappTemplateRef.href + "/guestCustomizationSection/", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public CustomizationSectionType GetCustomizationSection()
    {
      return this._customizationSection;
    }

    public static CustomizationSectionType GetCustomizationSection(
      vCloudClient client,
      ReferenceType vappTemplateRef)
    {
      try
      {
        return SdkUtil.Get<CustomizationSectionType>(client, vappTemplateRef.href + "/customizationSection/", 200);
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
        else if (sectionType is GuestCustomizationSectionType)
        {
          requestString = SerializationUtil.SerializeObject<GuestCustomizationSectionType>((GuestCustomizationSectionType) sectionType, "com.vmware.vcloud.api.rest.schema");
          url = href + "/guestCustomizationSection/";
          mediaType = "application/vnd.vmware.vcloud.guestCustomizationSection+xml";
        }
        else if (sectionType is CustomizationSectionType)
        {
          requestString = SerializationUtil.SerializeObject<CustomizationSectionType>((CustomizationSectionType) sectionType, "com.vmware.vcloud.api.rest.schema");
          url = href + "/customizationSection/";
          mediaType = "application/vnd.vmware.vcloud.customizationSection+xml";
        }
        else
        {
          Logger.Log(TraceLevel.Information, sectionType.GetType().Name + "-" + SdkUtil.GetI18nString(SdkMessage.NOT_VALID_SECTION_MSG));
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.NOT_VALID_SECTION_MSG));
        }
        return new Task(this.VcloudClient, SdkUtil.Put<TaskType>(this.VcloudClient, url, requestString, mediaType, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ulong GetVappTemplateSize()
    {
      try
      {
        ulong num = 0;
        if (this.Reference.type.Equals("application/vnd.vmware.vcloud.vm+xml"))
        {
          EnvelopeType ovf = VappTemplate.GetVappTemplateByReference(this.VcloudClient, this.GetParentVappTemplateReference()).GetOvf();
          if (ovf.Item != null)
          {
            if (ovf.Item is VirtualSystemCollection_Type)
            {
              foreach (VirtualSystem_Type virtualSystemType in ((VirtualSystemCollection_Type) ovf.Item).Items1)
              {
                if (virtualSystemType.id.Equals(this.Reference.name))
                  num += VappTemplate.GetVmSize(virtualSystemType);
              }
            }
            else if (ovf.Item is VirtualSystem_Type)
              num += VappTemplate.GetVmSize((VirtualSystem_Type) ovf.Item);
          }
        }
        else
        {
          EnvelopeType ovf = this.GetOvf();
          if (ovf.Item != null)
          {
            if (ovf.Item is VirtualSystemCollection_Type)
            {
              foreach (Content_Type contentType in ((VirtualSystemCollection_Type) ovf.Item).Items1)
                num += VappTemplate.GetVmSize((VirtualSystem_Type) contentType);
            }
            else if (ovf.Item is VirtualSystem_Type)
              num += VappTemplate.GetVmSize((VirtualSystem_Type) ovf.Item);
          }
        }
        return num;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public List<ReferenceType> GetShadowVmReferences()
    {
      try
      {
        if (!this.IsVm())
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.OPERATION_NOT_SUPPORTED));
        ShadowVMReferencesType vmReferencesType = SdkUtil.Get<ShadowVMReferencesType>(this.VcloudClient, this.Resource.href + "/shadowVms", 200);
        List<ReferenceType> referenceTypeList = new List<ReferenceType>();
        if (vmReferencesType != null && vmReferencesType.VMReference != null)
        {
          foreach (ReferenceType referenceType in vmReferencesType.VMReference)
            referenceTypeList.Add(referenceType);
        }
        return referenceTypeList;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task UpdateGoldMaster(bool goldMasterFlag)
    {
      try
      {
        this.Resource.goldMaster = goldMasterFlag;
        return this.UpdateVappTemplate(this.Resource);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public bool IsPartOfCatalogItem()
    {
      try
      {
        return this._catalogItemReference != null;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task DeleteVappTemplate()
    {
      string href = this.Reference.href;
      if (this.IsPartOfCatalogItem())
        CatalogItem.Delete(this.VcloudClient, this.GetCatalogItemReference());
      return new Task(this.VcloudClient, SdkUtil.Delete<TaskType>(this.VcloudClient, href, 202));
    }

    public static Task DeleteVappTemplate(vCloudClient client, ReferenceType vAppTemplateRef)
    {
      return VappTemplate.DeleteVappTemplateWithCatalogItem(client, vAppTemplateRef);
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

    private static VappTemplate GetVappTemplate(vCloudClient client, string url)
    {
      try
      {
        Response response = RestUtil.Get(client, url);
        VappTemplate vappTemplate = (VappTemplate) null;
        if (response.IsExpected(200))
        {
          VAppTemplateType resource = response.GetResource<VAppTemplateType>();
          vappTemplate = new VappTemplate(client, resource);
        }
        else
          response.HandleUnExpectedResponse();
        return vappTemplate;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void SortOvfSectionAndReferences_v1_5()
    {
      if (this.Resource.Items != null)
      {
        foreach (Section_Type sectionType in this.Resource.Items)
        {
          if (sectionType is NetworkConfigSectionType)
            this._networkConfigSection = (NetworkConfigSectionType) sectionType;
          else if (sectionType is NetworkSection_Type)
            this._networkSection = (NetworkSection_Type) sectionType;
          else if (sectionType is NetworkConnectionSectionType)
            this._networkConnectionSection = (NetworkConnectionSectionType) sectionType;
          else if (sectionType is LeaseSettingsSectionType)
            this._leaseSettingsSection = (LeaseSettingsSectionType) sectionType;
          else if (sectionType is CustomizationSectionType)
            this._customizationSection = (CustomizationSectionType) sectionType;
          else if (sectionType is GuestCustomizationSectionType)
            this._guestCustomizationSection = (GuestCustomizationSectionType) sectionType;
          else if (sectionType is ProductSection_Type)
            this._productSections.Add((ProductSection_Type) sectionType);
          Logger.Log(TraceLevel.Information, sectionType.GetType().Name);
        }
      }
      if (this.Resource.Link != null)
      {
        foreach (LinkType linkType in this.Resource.Link)
        {
          if (this._parentVappTemplateReference == null || this._catalogItemReference == null || this._vdcReference == null)
          {
            if (linkType.rel.Equals("up") && linkType.type.Equals("application/vnd.vmware.vcloud.vAppTemplate+xml"))
              this._parentVappTemplateReference = (ReferenceType) linkType;
            else if (linkType.rel.Equals("catalogItem") && linkType.type.Equals("application/vnd.vmware.vcloud.catalogItem+xml"))
              this._catalogItemReference = (ReferenceType) linkType;
            else if (linkType.rel.Equals("up") && linkType.type.Equals("application/vnd.vmware.vcloud.vdc+xml"))
              this._vdcReference = (ReferenceType) linkType;
            else if (linkType.rel.Equals("storageProfile") && linkType.type.Equals("application/vnd.vmware.vcloud.vdcStorageProfile+xml"))
              this._storageProfileRef = (ReferenceType) linkType;
          }
          else
            break;
        }
      }
      if (this.Resource == null || this.Resource.VCloudExtension == null)
        return;
      foreach (VCloudExtensionType vcloudExtensionType in this.Resource.VCloudExtension)
      {
        if (vcloudExtensionType.Any != null)
        {
          XmlElement[] any = vcloudExtensionType.Any;
          int index = 0;
          if (index < any.Length)
            this.vmVimInfoType = Response.GetResource<VmVimInfoType>(any[index].OuterXml);
        }
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

    private static Task DeletevAppTemplate(vCloudClient client, string vAppTemplateUrl)
    {
      try
      {
        return new Task(client, SdkUtil.Delete<TaskType>(client, vAppTemplateUrl, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private static Task DeleteVappTemplateWithCatalogItem(
      vCloudClient client,
      ReferenceType vappTemplRef)
    {
      VappTemplate templateByReference = VappTemplate.GetVappTemplateByReference(client, vappTemplRef);
      string href = vappTemplRef.href;
      if (templateByReference.IsPartOfCatalogItem())
        CatalogItem.Delete(client, templateByReference.GetCatalogItemReference());
      return new Task(client, SdkUtil.Delete<TaskType>(client, href, 202));
    }

    private static Task ExecuteVappTemplateAction(
      vCloudClient client,
      string vappActionUrl,
      string content,
      string contentType,
      int statusCode)
    {
      try
      {
        return new Task(client, SdkUtil.Post<TaskType>(client, vappActionUrl, content, contentType, statusCode));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void SortVAppTemplateFiles_v1_5()
    {
      if (this.Resource.Files == null)
        return;
      FilesListType files = this.Resource.Files;
      if (files == null && files.File != null)
        return;
      List<FileType> list = ((IEnumerable<FileType>) files.File).ToList<FileType>();
      if (list == null)
        return;
      this._uploadedFileMap = list.Where<FileType>((Func<FileType, bool>) (file => file.size.CompareTo(file.bytesTransferred).Equals(0))).ToDictionary<FileType, string, FileType>((Func<FileType, string>) (file => file.name), (Func<FileType, FileType>) (file => file));
      this._uploadFileMap = list.Where<FileType>((Func<FileType, bool>) (file => !file.size.CompareTo(file.bytesTransferred).Equals(0))).ToDictionary<FileType, string, FileType>((Func<FileType, string>) (file => file.name), (Func<FileType, FileType>) (file => file));
    }

    private static ulong GetVmSize(VirtualSystem_Type virtualSystemType)
    {
      try
      {
        ulong num = 0;
        foreach (Section_Type sectionType in virtualSystemType.Items)
        {
          if (sectionType is VirtualHardwareSection_Type)
          {
            VirtualHardwareSection_Type hardwareSectionType = (VirtualHardwareSection_Type) sectionType;
            if (hardwareSectionType.Item != null)
            {
              foreach (RASD_Type virtualDiskItem in ((IEnumerable<RASD_Type>) hardwareSectionType.Item).ToList<RASD_Type>())
              {
                if (virtualDiskItem.ResourceType.Value.Equals("17"))
                {
                  VirtualDisk virtualDisk = new VirtualDisk(virtualDiskItem);
                  if (virtualDisk.GetHardDiskSize() != 0UL)
                    num += virtualDisk.GetHardDiskSize();
                }
              }
            }
          }
        }
        return num;
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
