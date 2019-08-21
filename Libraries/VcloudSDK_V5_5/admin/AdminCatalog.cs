// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.AdminCatalog
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace com.vmware.vcloud.sdk.admin
{
  public class AdminCatalog : VcloudEntity<AdminCatalogType>
  {
    private ReferenceType _adminOrgReference;
    private ReferenceType _catalogReference;
    private Dictionary<string, ReferenceType> _catalogItemRefsByName;

    internal AdminCatalog(vCloudClient client, AdminCatalogType catalogType_v1_5)
      : base(client, catalogType_v1_5)
    {
      this.SortRefs_v1_5();
    }

    public ReferenceType GetAdminOrganizationReference()
    {
      try
      {
        if (this._adminOrgReference != null)
          return this._adminOrgReference;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType GetCatalogReference()
    {
      try
      {
        if (this._catalogReference != null)
          return this._catalogReference;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void SortRefs_v1_5()
    {
      if (this.Resource.Link != null)
      {
        foreach (LinkType linkType in this.Resource.Link)
        {
          if (linkType.rel.Equals("up") && linkType.type.Equals("application/vnd.vmware.admin.organization+xml"))
            this._adminOrgReference = (ReferenceType) linkType;
          if (linkType.rel.Equals("alternate") && linkType.type.Equals("application/vnd.vmware.vcloud.catalog+xml"))
            this._catalogReference = (ReferenceType) linkType;
        }
      }
      this._catalogItemRefsByName = new Dictionary<string, ReferenceType>();
      if (this.Resource.CatalogItems == null)
        return;
      CatalogItemsType catalogItems = this.Resource.CatalogItems;
      if (catalogItems.CatalogItem == null)
        return;
      foreach (ReferenceType referenceType in ((IEnumerable<ReferenceType>) catalogItems.CatalogItem).ToList<ReferenceType>())
        this._catalogItemRefsByName.Add(referenceType.name, referenceType);
    }

    public static AdminCatalog GetCatalogByReference(
      vCloudClient client,
      ReferenceType catalogRef)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + catalogRef.href);
        return new AdminCatalog(client, VcloudResource<AdminCatalogType>.GetResourceByReference(client, catalogRef));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static AdminCatalog GetCatalogById(vCloudClient client, string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        return new AdminCatalog(client, VcloudEntity<AdminCatalogType>.GetEntityById(client, vCloudId, "application/vnd.vmware.admin.catalog+xml"));
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
        return new CatalogItem(this.VcloudClient, SdkUtil.Post<CatalogItemType>(this.VcloudClient, this.Reference.href.Replace("/admin", "") + "/catalogItems", SerializationUtil.SerializeObject<CatalogItemType>(catalogItemType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.vcloud.catalogItem+xml", 201));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public AdminCatalog UpdateAdminCatalog(AdminCatalogType catalogType)
    {
      try
      {
        string href = this.Reference.href;
        string requestString = SerializationUtil.SerializeObject<AdminCatalogType>(catalogType, "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.PUT_URL_MSG) + " - " + href);
        return new AdminCatalog(this.VcloudClient, SdkUtil.Put<AdminCatalogType>(this.VcloudClient, href, requestString, "application/vnd.vmware.admin.catalog+xml", 200));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void Delete()
    {
      try
      {
        AdminCatalog.DeleteAdminCatalog(this.VcloudClient, this.Reference.href);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static void Delete(vCloudClient client, ReferenceType adminCatalogRef)
    {
      try
      {
        AdminCatalog.DeleteAdminCatalog(client, adminCatalogRef.href);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private static void DeleteAdminCatalog(vCloudClient client, string adminCatalogUrl)
    {
      try
      {
        SdkUtil.Delete<TaskType>(client, adminCatalogUrl, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void PublishCatalog(PublishCatalogParamsType publishCatalogParamsType)
    {
      try
      {
        SdkUtil.Post<PublishCatalogParamsType>(this.VcloudClient, this.Reference.href + "/action/publish", SerializationUtil.SerializeObject<PublishCatalogParamsType>(publishCatalogParamsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.publishCatalogParams+xml", 204);
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

    public static ReferenceType GetOwner(
      vCloudClient client,
      ReferenceType adminCatalogRef)
    {
      try
      {
        string url = adminCatalogRef.href + "/owner";
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
      ReferenceType catalogRef,
      ReferenceType userReference)
    {
      try
      {
        AdminCatalog.ChangeOwner(catalogRef.href + "/owner", userReference, client);
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
        AdminCatalog.ChangeOwner(this.Reference.href + "/owner", userReference, this.VcloudClient);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
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
        SdkUtil.Put<OwnerType>(client, url, requestString, "application/vnd.vmware.vcloud.owner+xml", 204);
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
      return this._catalogItemRefsByName.Values.ToList<ReferenceType>();
    }

    public void PublishToExternalOrganizations(
      PublishExternalCatalogParamsType publishExternalCatalogParams)
    {
      SdkUtil.Post<PublishExternalCatalogParamsType>(this.VcloudClient, this.Reference.href + "/action/publishToExternalOrganizations", SerializationUtil.SerializeObject<PublishExternalCatalogParamsType>(publishExternalCatalogParams, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.publishExternalCatalogParams+xml", 204);
    }

    public void SubscribeToExternalCatalog(
      ExternalCatalogSubscriptionParamsType externalCatalogSubscriptionParams)
    {
      SdkUtil.Post<ExternalCatalogSubscriptionParamsType>(this.VcloudClient, this.Reference.href + "/action/subscribeToExternalCatalog", SerializationUtil.SerializeObject<ExternalCatalogSubscriptionParamsType>(externalCatalogSubscriptionParams, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.externalCatalogSubscriptionParams+xml", 204);
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
