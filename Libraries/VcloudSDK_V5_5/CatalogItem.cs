// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.CatalogItem
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;
using System;

namespace com.vmware.vcloud.sdk
{
  public class CatalogItem : VcloudEntity<CatalogItemType>
  {
    private ReferenceType _catalogReference;

    public CatalogItem(vCloudClient client, CatalogItemType catalogItemType_v1_5)
      : base(client, catalogItemType_v1_5)
    {
      this.SortReferences_v1_5();
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

    public ReferenceType GetEntityReference()
    {
      try
      {
        if (this.Resource.Entity != null)
          return this.Resource.Entity;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void SortReferences_v1_5()
    {
      if (this.Resource == null || this.Resource.Link == null)
        return;
      foreach (LinkType linkType in this.Resource.Link)
      {
        if (linkType.rel.Equals("up") && linkType.type.Equals("application/vnd.vmware.vcloud.catalog+xml"))
        {
          this._catalogReference = (ReferenceType) linkType;
          break;
        }
      }
    }

    public static CatalogItem GetCatalogItemByReference(
      vCloudClient client,
      ReferenceType catalogItemRef)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + catalogItemRef.href);
        return new CatalogItem(client, VcloudResource<CatalogItemType>.GetResourceByReference(client, catalogItemRef));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static CatalogItem GetCatalogItemById(vCloudClient client, string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        return new CatalogItem(client, VcloudEntity<CatalogItemType>.GetEntityById(client, vCloudId, "application/vnd.vmware.vcloud.catalogItem+xml"));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public CatalogItem UpdateCatalogItem(CatalogItemType catalogItemType)
    {
      try
      {
        string href = this.Resource.href;
        string requestString = SerializationUtil.SerializeObject<CatalogItemType>(catalogItemType, "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.POST_URL_MSG) + " -" + href);
        return new CatalogItem(this.VcloudClient, SdkUtil.Put<CatalogItemType>(this.VcloudClient, href, requestString, "application/vnd.vmware.vcloud.catalogItem+xml", 200));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task Sync()
    {
      return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/sync", (string) null, (string) null, 202));
    }

    public void Delete()
    {
      try
      {
        CatalogItem.DeleteCatalogItem(this.VcloudClient, this.Resource.href);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static void Delete(vCloudClient client, ReferenceType catalogItemRef)
    {
      try
      {
        CatalogItem.DeleteCatalogItem(client, catalogItemRef.href);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private static void DeleteCatalogItem(vCloudClient client, string catalogItemUrl)
    {
      try
      {
        SdkUtil.Delete<TaskType>(client, catalogItemUrl, 204);
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
