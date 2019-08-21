// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.Vdc
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.constants;
using com.vmware.vcloud.sdk.constants.query;
using com.vmware.vcloud.sdk.exceptions;
using com.vmware.vcloud.sdk.utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace com.vmware.vcloud.sdk
{
  public class Vdc : VcloudEntity<VdcType>
  {
    private Dictionary<string, ReferenceType> _vappRefsByName = new Dictionary<string, ReferenceType>();
    private Dictionary<string, ReferenceType> _availableNetworkRefsByName = new Dictionary<string, ReferenceType>();
    private ReferenceType _orgReference = new ReferenceType();
    private List<ReferenceType> _vappTemplateRefs;
    private List<ReferenceType> _mediaRefs;
    private List<ReferenceType> _diskRefs;
    private List<ReferenceType> _storageProfileRefs;

    internal Vdc(vCloudClient client, VdcType vdcType_v1_5)
      : base(client, vdcType_v1_5)
    {
      this.SortEntityRefs_v1_5();
    }

    public static Vdc GetVdcByReference(vCloudClient client, ReferenceType vdcRef)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + vdcRef.href);
        return new Vdc(client, VcloudResource<VdcType>.GetResourceByReference(client, vdcRef));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Vdc GetVdcById(vCloudClient client, string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        return new Vdc(client, VcloudEntity<VdcType>.GetEntityById(client, vCloudId, "application/vnd.vmware.vcloud.vdc+xml"));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VimObjectRefType GetResourcePoolVimRef()
    {
      try
      {
        if (this.Resource.VCloudExtension != null)
        {
          foreach (VCloudExtensionType vcloudExtensionType in this.Resource.VCloudExtension)
          {
            if (vcloudExtensionType.Any != null)
            {
              foreach (XmlNode xmlNode in vcloudExtensionType.Any)
              {
                VimObjectRefType resource = Response.GetResource<VimObjectRefType>(xmlNode.OuterXml);
                if (resource.VimObjectType.Equals(VimObjectTypeEnum.RESOURCE_POOL.Value()))
                  return resource;
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

    public ReferenceType GetOrgReference()
    {
      try
      {
        if (this._orgReference != null)
          return this._orgReference;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    [Obsolete("This method is deprecated since SDK 5.5. Use the Resource.AvailableNetworks")]
    public Dictionary<string, ReferenceType> GetAvailableNetworkRefsByName()
    {
      return this._availableNetworkRefsByName;
    }

    [Obsolete("This method is deprecated  since SDK 5.5. Use the Resource.AvailableNetworks")]
    public List<ReferenceType> GetAvailableNetworkRefs()
    {
      if (this._availableNetworkRefsByName.Values != null)
        return this._availableNetworkRefsByName.Values.ToList<ReferenceType>();
      return new List<ReferenceType>();
    }

    [Obsolete("This method is deprecated  since SDK 5.5. Use the Resource.AvailableNetworks")]
    public ReferenceType GetAvailableNetworkRefByName(string name)
    {
      return this._availableNetworkRefsByName[name];
    }

    public List<ReferenceType> GetVappTemplateRefs()
    {
      return this._vappTemplateRefs;
    }

    public List<ReferenceType> GetMediaRefs()
    {
      return this._mediaRefs;
    }

    public List<ReferenceType> GetDiskRefs()
    {
      if (this._diskRefs != null)
        return this._diskRefs;
      return new List<ReferenceType>();
    }

    public Dictionary<string, ReferenceType> GetVappRefsByName()
    {
      return this._vappRefsByName;
    }

    public List<ReferenceType> GetVappTemplateRefsByName(string vAppTemplateName)
    {
      List<ReferenceType> referenceTypeList = new List<ReferenceType>();
      foreach (ReferenceType vappTemplateRef in this.GetVappTemplateRefs())
      {
        if (vappTemplateRef.name.Equals(vAppTemplateName))
          referenceTypeList.Add(vappTemplateRef);
      }
      return referenceTypeList;
    }

    public List<ReferenceType> GetMediaRefsByName(string mediaName)
    {
      List<ReferenceType> referenceTypeList = new List<ReferenceType>();
      foreach (ReferenceType mediaRef in this.GetMediaRefs())
      {
        if (mediaRef.name.Equals(mediaName))
          referenceTypeList.Add(mediaRef);
      }
      return referenceTypeList;
    }

    public ReferenceType GetVappRefByName(string name)
    {
      return this._vappRefsByName[name];
    }

    public List<ReferenceType> GetVappRefs()
    {
      if (this._vappRefsByName.Values != null)
        return this._vappRefsByName.Values.ToList<ReferenceType>();
      return new List<ReferenceType>();
    }

    public VappTemplate CreateVappTemplate(UploadVAppTemplateParamsType vappTemplParams)
    {
      try
      {
        return Vdc.ExecuteVappTemplUpload(this.VcloudClient, this.Reference.href + "/action/uploadVAppTemplate", SerializationUtil.SerializeObject<UploadVAppTemplateParamsType>(vappTemplParams, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.vcloud.uploadVAppTemplateParams+xml");
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VappTemplate UploadVappTemplate(
      string vAppTemplateName,
      string vAppTemplateDesc,
      string localOvfFileLocation,
      bool manifestRequired,
      ReferenceType vdcStorageRef,
      ReferenceType catalogRef)
    {
      Catalog catalog = this.CheckCatalogForDuplicates(catalogRef, vAppTemplateName);
      UploadVAppTemplateParamsType vappTemplParams = new UploadVAppTemplateParamsType();
      vappTemplParams.Description = vAppTemplateDesc;
      vappTemplParams.name = vAppTemplateName;
      vappTemplParams.manifestRequired = manifestRequired;
      vappTemplParams.VdcStorageProfile = vdcStorageRef;
      VappTemplate vappTemplate = this.CreateVappTemplate(vappTemplParams);
      FileStream fileStream1;
      try
      {
        fileStream1 = File.OpenRead(localOvfFileLocation);
      }
      catch (FileNotFoundException ex)
      {
        throw new VCloudRuntimeException((Exception) ex);
      }
      string fileName = Path.GetFileName(localOvfFileLocation);
      vappTemplate.UploadOVFFile((Stream) fileStream1, fileStream1.Length);
      VappTemplate templateByReference1 = VappTemplate.GetVappTemplateByReference(this.VcloudClient, vappTemplate.Reference);
      while (!templateByReference1.Resource.ovfDescriptorUploaded)
        templateByReference1 = VappTemplate.GetVappTemplateByReference(this.VcloudClient, templateByReference1.Reference);
      try
      {
        fileStream1.Close();
      }
      catch (IOException ex)
      {
        throw new VCloudRuntimeException((Exception) ex);
      }
      foreach (string uploadFileName in templateByReference1.GetUploadFileNames())
      {
        string path = localOvfFileLocation.Replace(fileName, uploadFileName);
        FileStream fileStream2;
        try
        {
          fileStream2 = File.OpenRead(path);
        }
        catch (FileNotFoundException ex)
        {
          throw new VCloudRuntimeException((Exception) ex);
        }
        templateByReference1.UploadFile(uploadFileName, (Stream) fileStream2, fileStream2.Length);
        try
        {
          fileStream2.Close();
        }
        catch (IOException ex)
        {
          throw new VCloudRuntimeException((Exception) ex);
        }
      }
      VappTemplate templateByReference2 = VappTemplate.GetVappTemplateByReference(this.VcloudClient, templateByReference1.Reference);
      while (templateByReference2.Resource.status == VappTemplateStatus.UNRESOLVED.Value())
        templateByReference2 = VappTemplate.GetVappTemplateByReference(this.VcloudClient, templateByReference2.Reference);
      this.AddResourceToCatalog(templateByReference2.Reference, catalog);
      return VappTemplate.GetVappTemplateByReference(this.VcloudClient, templateByReference2.Reference);
    }

    private Catalog CheckCatalogForDuplicates(ReferenceType catalogRef, string resourceName)
    {
      try
      {
        Catalog catalogByReference = Catalog.GetCatalogByReference(this.VcloudClient, catalogRef);
        if (catalogByReference.GetCatalogItemRefsByName().ContainsKey(resourceName))
          throw new DuplicateNameException(SdkUtil.GetI18nString(SdkMessage.DUPLICATE_NAME));
        return catalogByReference;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void AddResourceToCatalog(ReferenceType resourceRef, Catalog catalog)
    {
      CatalogItemType catalogItemType = new CatalogItemType();
      catalogItemType.name = resourceRef.name;
      catalogItemType.Entity = resourceRef;
      CatalogItem catalogItem;
      try
      {
        catalogItem = catalog.AddCatalogItem(catalogItemType);
      }
      catch (VCloudException ex)
      {
        throw new ResourceNotAddedException(ex, resourceRef);
      }
      if (catalogItem.Tasks.Count <= 0)
        return;
      catalogItem.Tasks[0].WaitForTask(0L);
    }

    public Media CreateMedia(com.vmware.vcloud.api.rest.schema.MediaType mediaParams)
    {
      try
      {
        return new Media(this.VcloudClient, SdkUtil.Post<com.vmware.vcloud.api.rest.schema.MediaType>(this.VcloudClient, this.Reference.href + "/media/", SerializationUtil.SerializeObject<com.vmware.vcloud.api.rest.schema.MediaType>(mediaParams, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.vcloud.media+xml", 201));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Media UploadMedia(
      string mediaName,
      string mediaDescription,
      ImageType mediaType,
      string localMediaFile,
      ReferenceType vdcStorageProfileRef,
      ReferenceType catalogRef)
    {
      try
      {
        Catalog catalog = this.CheckCatalogForDuplicates(catalogRef, mediaName);
        FileStream fileStream;
        try
        {
          fileStream = File.OpenRead(localMediaFile);
        }
        catch (FileNotFoundException ex)
        {
          throw new VCloudRuntimeException((Exception) ex);
        }
        com.vmware.vcloud.api.rest.schema.MediaType mediaParams = new com.vmware.vcloud.api.rest.schema.MediaType();
        mediaParams.name = mediaName;
        mediaParams.Description = mediaDescription;
        mediaParams.imageType = mediaType.Value();
        mediaParams.size = fileStream.Length;
        mediaParams.VdcStorageProfile = vdcStorageProfileRef;
        Media media = this.CreateMedia(mediaParams);
        string fileName = media.GetUploadFileNames().FirstOrDefault<string>();
        media.UploadFile(fileName, (Stream) fileStream, fileStream.Length);
        while (media.Resource.status == 0)
          media = Media.GetMediaByReference(this.VcloudClient, media.Reference);
        this.AddResourceToCatalog(media.Reference, catalog);
        return Media.GetMediaByReference(this.VcloudClient, media.Reference);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Vapp ComposeVapp(ComposeVAppParamsType composeVappParamsType)
    {
      try
      {
        return new Vapp(this.VcloudClient, SdkUtil.Post<VAppType>(this.VcloudClient, this.Reference.href + "/action/composeVApp", SerializationUtil.SerializeObject<ComposeVAppParamsType>(composeVappParamsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.vcloud.composeVAppParams+xml", 201));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VappTemplate CaptureVapp(CaptureVAppParamsType captureVappParamsType)
    {
      try
      {
        return new VappTemplate(this.VcloudClient, SdkUtil.Post<VAppTemplateType>(this.VcloudClient, this.Reference.href + "/action/captureVApp", SerializationUtil.SerializeObject<CaptureVAppParamsType>(captureVappParamsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.vcloud.captureVAppParams+xml", 201));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VappTemplate CaptureVapp(
      CaptureVAppParamsType captureVappParamsType,
      ReferenceType catalogRef)
    {
      if (captureVappParamsType.name == null)
        throw new MissingPropertyException(SdkUtil.GetI18nString(SdkMessage.MISSING_PROPERTY));
      Catalog catalog = this.CheckCatalogForDuplicates(catalogRef, captureVappParamsType.name);
      VappTemplate vappTemplate = this.CaptureVapp(captureVappParamsType);
      this.AddResourceToCatalog(vappTemplate.Reference, catalog);
      return VappTemplate.GetVappTemplateByReference(this.VcloudClient, vappTemplate.Reference);
    }

    public Vapp InstantiateVappTemplate(
      InstantiateVAppTemplateParamsType instVappTemplParamsType)
    {
      try
      {
        return new Vapp(this.VcloudClient, SdkUtil.Post<VAppType>(this.VcloudClient, this.Reference.href + "/action/instantiateVAppTemplate", SerializationUtil.SerializeObject<InstantiateVAppTemplateParamsType>(instVappTemplParamsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.vcloud.instantiateVAppTemplateParams+xml", 201));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Vapp CloneVapp(CloneVAppParamsType cloneVappParamsType)
    {
      try
      {
        return new Vapp(this.VcloudClient, SdkUtil.Post<VAppType>(this.VcloudClient, this.Reference.href + "/action/cloneVApp", SerializationUtil.SerializeObject<CloneVAppParamsType>(cloneVappParamsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.vcloud.cloneVAppParams+xml", 201));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VappTemplate CloneVappTemplate(
      CloneVAppTemplateParamsType cloneVappTemplateParamsType)
    {
      try
      {
        return new VappTemplate(this.VcloudClient, SdkUtil.Post<VAppTemplateType>(this.VcloudClient, this.Reference.href + "/action/cloneVAppTemplate", SerializationUtil.SerializeObject<CloneVAppTemplateParamsType>(cloneVappTemplateParamsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.vcloud.cloneVAppTemplateParams+xml", 201));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Media CloneMedia(CloneMediaParamsType cloneMediaParamsType)
    {
      try
      {
        return new Media(this.VcloudClient, SdkUtil.Post<com.vmware.vcloud.api.rest.schema.MediaType>(this.VcloudClient, this.Reference.href + "/action/cloneMedia", SerializationUtil.SerializeObject<CloneMediaParamsType>(cloneMediaParamsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.vcloud.cloneMediaParams+xml", 201));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VappTemplate CloneVappTemplate(
      CloneVAppTemplateParamsType cloneVappTemplateParamsType,
      ReferenceType catalogRef)
    {
      if (cloneVappTemplateParamsType.name == null)
        throw new MissingPropertyException(SdkUtil.GetI18nString(SdkMessage.MISSING_PROPERTY));
      Catalog catalog = this.CheckCatalogForDuplicates(catalogRef, cloneVappTemplateParamsType.name);
      VappTemplate vappTemplate = this.CloneVappTemplate(cloneVappTemplateParamsType);
      this.AddResourceToCatalog(vappTemplate.Reference, catalog);
      return VappTemplate.GetVappTemplateByReference(this.VcloudClient, vappTemplate.Reference);
    }

    public Media CloneMedia(
      CloneMediaParamsType cloneMediaParamsType,
      ReferenceType catalogRef)
    {
      if (cloneMediaParamsType.name == null)
        throw new MissingPropertyException(SdkUtil.GetI18nString(SdkMessage.MISSING_PROPERTY));
      Catalog catalog = this.CheckCatalogForDuplicates(catalogRef, cloneMediaParamsType.name);
      Media media = this.CloneMedia(cloneMediaParamsType);
      this.AddResourceToCatalog(media.Reference, catalog);
      return Media.GetMediaByReference(this.VcloudClient, media.Reference);
    }

    public List<ReferenceType> GetVdcStorageProfileRefs()
    {
      try
      {
        if (this._storageProfileRefs != null && this._storageProfileRefs.Count > 0)
          return this._storageProfileRefs;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.DATA_NOT_FOUND));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Disk CreateDisk(DiskCreateParamsType diskCreateParams)
    {
      try
      {
        return new Disk(this.VcloudClient, SdkUtil.Post<DiskType>(this.VcloudClient, this.Reference.href + "/disk", SerializationUtil.SerializeObject<DiskCreateParamsType>(diskCreateParams, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.vcloud.diskCreateParams+xml", 201));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Vapp UploadVapp(
      InstantiateOvfParamsType InstantiateOvfParamsType,
      string localOvfFileLocation)
    {
      Vapp vapp = this.InstantiateOvf(InstantiateOvfParamsType);
      FileStream fileStream1;
      try
      {
        fileStream1 = File.OpenRead(localOvfFileLocation);
      }
      catch (FileNotFoundException ex)
      {
        throw new VCloudRuntimeException((Exception) ex);
      }
      string fileName = Path.GetFileName(localOvfFileLocation);
      vapp.UploadOVFFile((Stream) fileStream1, fileStream1.Length);
      Vapp vappByReference1 = Vapp.GetVappByReference(this.VcloudClient, vapp.Reference);
      while (!vappByReference1.Resource.ovfDescriptorUploaded)
        vappByReference1 = Vapp.GetVappByReference(this.VcloudClient, vappByReference1.Reference);
      try
      {
        fileStream1.Close();
      }
      catch (IOException ex)
      {
        throw new VCloudRuntimeException((Exception) ex);
      }
      foreach (string uploadFileName in vappByReference1.GetUploadFileNames())
      {
        string path = localOvfFileLocation.Replace(fileName, uploadFileName);
        FileStream fileStream2;
        try
        {
          fileStream2 = File.OpenRead(path);
        }
        catch (FileNotFoundException ex)
        {
          throw new VCloudRuntimeException((Exception) ex);
        }
        vappByReference1.UploadFile(uploadFileName, (Stream) fileStream2, fileStream2.Length);
        try
        {
          fileStream2.Close();
        }
        catch (IOException ex)
        {
          throw new VCloudRuntimeException((Exception) ex);
        }
      }
      Vapp vappByReference2 = Vapp.GetVappByReference(this.VcloudClient, vappByReference1.Reference);
      while (vappByReference2.Resource.status == VappTemplateStatus.UNRESOLVED.Value())
        vappByReference2 = Vapp.GetVappByReference(this.VcloudClient, vappByReference2.Reference);
      return Vapp.GetVappByReference(this.VcloudClient, vappByReference2.Reference);
    }

    public Vapp InstantiateOvf(InstantiateOvfParamsType instantiateOvfParams)
    {
      return new Vapp(this.VcloudClient, SdkUtil.Post<VAppType>(this.VcloudClient, this.Reference.href + "/action/instantiateOvf", SerializationUtil.SerializeObject<InstantiateOvfParamsType>(instantiateOvfParams, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.vcloud.instantiateOvfParams+xml", 201));
    }

    public OrgVdcNetwork CreateOrgVdcNetwork(OrgVdcNetworkType orgVdcNetworkParams)
    {
      string requestString = SerializationUtil.SerializeObject<OrgVdcNetworkType>(orgVdcNetworkParams, "com.vmware.vcloud.api.rest.schema");
      foreach (LinkType linkType in this.Resource.Link)
      {
        if (linkType.rel.Equals("orgVdcNetworks"))
          return new OrgVdcNetwork(this.VcloudClient, SdkUtil.Post<OrgVdcNetworkType>(this.VcloudClient, linkType.href, requestString, "application/vnd.vmware.vcloud.orgVdcNetwork+xml", 201));
      }
      throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.LINK_NOT_FOUND_MSG));
    }

    public ReferenceResult GetEdgeGatewayRefs()
    {
      foreach (LinkType linkType in this.Resource.Link)
      {
        if (linkType.rel.Equals("edgeGateways"))
          return this.VcloudClient.GetQueryService().ExecuteQuery<ReferenceResult, ReferencesType, QueryResultEdgeGatewayRecordType>(linkType.href + "?" + this.VcloudClient.GetQueryService().BuildQuery(FormatType.REFERENCE_VIEW));
      }
      throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.LINK_NOT_FOUND_MSG));
    }

    private void SortEntityRefs_v1_5()
    {
      this._vappTemplateRefs = new List<ReferenceType>();
      this._mediaRefs = new List<ReferenceType>();
      this._vappRefsByName = new Dictionary<string, ReferenceType>();
      this._availableNetworkRefsByName = new Dictionary<string, ReferenceType>();
      this._storageProfileRefs = new List<ReferenceType>();
      this._diskRefs = new List<ReferenceType>();
      if (this.Resource.ResourceEntities != null)
      {
        ResourceEntitiesType resourceEntities = this.Resource.ResourceEntities;
        if (resourceEntities.ResourceEntity != null)
        {
          foreach (ResourceReferenceType resourceReferenceType in ((IEnumerable<ResourceReferenceType>) resourceEntities.ResourceEntity).ToList<ResourceReferenceType>())
          {
            if (resourceReferenceType.type.Equals("application/vnd.vmware.vcloud.vAppTemplate+xml"))
              this._vappTemplateRefs.Add((ReferenceType) resourceReferenceType);
            else if (resourceReferenceType.type.Equals("application/vnd.vmware.vcloud.media+xml"))
              this._mediaRefs.Add((ReferenceType) resourceReferenceType);
            else if (resourceReferenceType.type.Equals("application/vnd.vmware.vcloud.vApp+xml"))
              this._vappRefsByName.Add(resourceReferenceType.name, (ReferenceType) resourceReferenceType);
            else if (resourceReferenceType.type.Equals("application/vnd.vmware.vcloud.disk+xml"))
              this._diskRefs.Add((ReferenceType) resourceReferenceType);
            else
              Logger.Log(TraceLevel.Warning, SdkUtil.GetI18nString(SdkMessage.UNKNOWN_REF_TYPE_MSG) + " - ", resourceReferenceType.type);
          }
        }
      }
      if (this.Resource.AvailableNetworks != null)
      {
        AvailableNetworksType availableNetworks = this.Resource.AvailableNetworks;
        if (availableNetworks.Network != null)
        {
          foreach (ReferenceType referenceType in availableNetworks.Network)
          {
            if (!this._availableNetworkRefsByName.ContainsKey(referenceType.name))
              this._availableNetworkRefsByName.Add(referenceType.name, referenceType);
          }
        }
      }
      foreach (LinkType linkType in this.Resource.Link)
      {
        if (linkType.rel.Equals("up") && linkType.type.Equals("application/vnd.vmware.vcloud.org+xml"))
          this._orgReference = (ReferenceType) linkType;
      }
      if (this.Resource.VdcStorageProfiles == null)
        return;
      foreach (ReferenceType referenceType in this.Resource.VdcStorageProfiles.VdcStorageProfile)
        this._storageProfileRefs.Add(referenceType);
    }

    private static VappTemplate ExecuteVappTemplUpload(
      vCloudClient client,
      string vdcActionUrl,
      string reqPayload,
      string contentType)
    {
      try
      {
        return new VappTemplate(client, SdkUtil.Post<VAppTemplateType>(client, vdcActionUrl, reqPayload, contentType, 201));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
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
