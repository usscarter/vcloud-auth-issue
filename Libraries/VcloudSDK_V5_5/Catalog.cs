// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.Catalog
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

namespace com.vmware.vcloud.sdk
{
  public class Catalog : VcloudEntity<CatalogType>
  {
    protected Dictionary<string, ReferenceType> _catalogItemRefsByName = new Dictionary<string, ReferenceType>();
    private ReferenceType _orgReference;

    protected Catalog(vCloudClient client, CatalogType catalogType_v1_5)
      : base(client, catalogType_v1_5)
    {
      this.SortItemRefs_v1_5();
    }

    public static Catalog GetCatalogByReference(
      vCloudClient client,
      ReferenceType catalogRef)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + catalogRef.href);
        return new Catalog(client, VcloudResource<CatalogType>.GetResourceByReference(client, catalogRef));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Catalog GetCatalogById(vCloudClient client, string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        return new Catalog(client, VcloudEntity<CatalogType>.GetEntityById(client, vCloudId, "application/vnd.vmware.vcloud.catalog+xml"));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public CatalogItem AddCatalogItem(CatalogItemType catalogItemType)
    {
      try
      {
        return new CatalogItem(this.VcloudClient, SdkUtil.Post<CatalogItemType>(this.VcloudClient, this.Reference.href + "/catalogItems", SerializationUtil.SerializeObject<CatalogItemType>(catalogItemType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.vcloud.catalogItem+xml", 201));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Dictionary<string, ReferenceType> GetCatalogItemRefsByName()
    {
      return this._catalogItemRefsByName;
    }

    public ReferenceType GetCatalogItemRefByName(string name)
    {
      return this._catalogItemRefsByName[name];
    }

    public List<ReferenceType> GetCatalogItemReferences()
    {
      if (this._catalogItemRefsByName.Values != null)
        return this._catalogItemRefsByName.Values.ToList<ReferenceType>();
      return new List<ReferenceType>();
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

    public VappTemplate UploadVappTemplate(
      string vAppTemplateName,
      string vAppTemplateDesc,
      string localOvfFileLocation,
      bool manifestRequired,
      ReferenceType vdcStorageRef)
    {
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
      return VappTemplate.GetVappTemplateByReference(this.VcloudClient, templateByReference2.Reference);
    }

    public VappTemplate CreateVappTemplate(UploadVAppTemplateParamsType vappTemplParams)
    {
      return Catalog.ExecuteVappTemplateUpload(this.VcloudClient, this.Reference.href + "/action/upload", SerializationUtil.SerializeObject<UploadVAppTemplateParamsType>(vappTemplParams, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.vcloud.uploadVAppTemplateParams+xml");
    }

    public Task CaptureVapp(CaptureVAppParamsType captureVappParams)
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/captureVApp", SerializationUtil.SerializeObject<CaptureVAppParamsType>(captureVappParams, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.vcloud.captureVAppParams+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task Sync()
    {
      return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/sync", (string) null, (string) null, 201));
    }

    public Task CopyCatalogItem(string name, string description, ReferenceType sourceRef)
    {
      CopyOrMoveCatalogItemParamsType catalogItemParamsType = new CopyOrMoveCatalogItemParamsType();
      catalogItemParamsType.name = name;
      catalogItemParamsType.Description = description;
      catalogItemParamsType.Source = sourceRef;
      return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Resource.href + "/action/copy", SerializationUtil.SerializeObject<CopyOrMoveCatalogItemParamsType>(catalogItemParamsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.vcloud.copyOrMoveCatalogItemParams+xml", 202));
    }

    public Task MoveCatalogItem(string name, string description, ReferenceType sourceRef)
    {
      CopyOrMoveCatalogItemParamsType catalogItemParamsType = new CopyOrMoveCatalogItemParamsType();
      catalogItemParamsType.name = name;
      catalogItemParamsType.Description = description;
      catalogItemParamsType.Source = sourceRef;
      return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Resource.href + "/action/move", SerializationUtil.SerializeObject<CopyOrMoveCatalogItemParamsType>(catalogItemParamsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.vcloud.copyOrMoveCatalogItemParams+xml", 202));
    }

    private void SortItemRefs_v1_5()
    {
      this._catalogItemRefsByName = new Dictionary<string, ReferenceType>();
      if (this.Resource.CatalogItems != null)
      {
        CatalogItemsType catalogItems = this.Resource.CatalogItems;
        if (catalogItems.CatalogItem != null)
        {
          foreach (ReferenceType referenceType in ((IEnumerable<ReferenceType>) catalogItems.CatalogItem).ToList<ReferenceType>())
          {
            if (!this._catalogItemRefsByName.ContainsKey(referenceType.name))
              this._catalogItemRefsByName.Add(referenceType.name, referenceType);
          }
        }
      }
      if (this.Resource.Link == null)
        return;
      foreach (LinkType linkType in this.Resource.Link)
      {
        if (linkType.rel.Equals("up") && linkType.type.Equals("application/vnd.vmware.vcloud.org+xml"))
          this._orgReference = (ReferenceType) linkType;
      }
    }

    private static VappTemplate ExecuteVappTemplateUpload(
      vCloudClient client,
      string vdcActionUrl,
      string reqPayload,
      string contentType)
    {
      ReferenceType entity = new CatalogItem(client, SdkUtil.Post<CatalogItemType>(client, vdcActionUrl, reqPayload, contentType, 201)).Resource.Entity;
      return VappTemplate.GetVappTemplateByReference(client, entity);
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
