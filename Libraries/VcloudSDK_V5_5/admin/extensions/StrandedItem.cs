// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.extensions.StrandedItem
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;
using System;

namespace com.vmware.vcloud.sdk.admin.extensions
{
  public class StrandedItem : VcloudEntity<StrandedItemType>
  {
    internal StrandedItem(vCloudClient client, StrandedItemType strandedItemResource)
      : base(client, strandedItemResource)
    {
    }

    public static StrandedItem GetStrandedItemByReference(
      vCloudClient client,
      ReferenceType reference)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + reference.href);
        return new StrandedItem(client, VcloudResource<StrandedItemType>.GetResourceByReference(client, reference));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static StrandedItem GetStrandedItemById(vCloudClient client, string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        return new StrandedItem(client, VcloudEntity<StrandedItemType>.GetEntityById(client, vCloudId, "application/vnd.vmware.admin.strandedItem+xml"));
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
        return new Task(this.VcloudClient, SdkUtil.Delete<TaskType>(this.VcloudClient, this.Reference.href, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task Delete(vCloudClient client, ReferenceType strandedItemRef)
    {
      try
      {
        string href = strandedItemRef.href;
        return new Task(client, SdkUtil.Delete<TaskType>(client, href, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task ForceDelete()
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/forceDelete", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task ForceDelete(vCloudClient client, ReferenceType strandedItemRef)
    {
      try
      {
        string url = strandedItemRef.href + "/action/forceDelete";
        return new Task(client, SdkUtil.Post<TaskType>(client, url, (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }
  }
}
