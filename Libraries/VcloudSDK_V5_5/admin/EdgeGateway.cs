// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.EdgeGateway
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;
using System;

namespace com.vmware.vcloud.sdk.admin
{
  public class EdgeGateway : VcloudEntity<GatewayType>
  {
    private ReferenceType adminVdcReference;

    internal EdgeGateway(vCloudClient client, GatewayType gatewayType)
      : base(client, gatewayType)
    {
      this.SortRefs();
    }

    public static EdgeGateway GetEgdeGatewayByReference(
      vCloudClient client,
      ReferenceType edgeGatewayTypeRef)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + edgeGatewayTypeRef.href);
        return new EdgeGateway(client, VcloudResource<GatewayType>.GetResourceByReference(client, edgeGatewayTypeRef));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType GetAdminVdcReference()
    {
      if (this.adminVdcReference != null)
        return this.adminVdcReference;
      throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
    }

    public static EdgeGateway GetEdgeGatewayById(vCloudClient client, string vCloudId)
    {
      Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
      return new EdgeGateway(client, VcloudEntity<GatewayType>.GetEntityById(client, vCloudId, "application/vnd.vmware.admin.edgeGateway+xml"));
    }

    public Task UpdateEdgeGateway(GatewayType gatewayParams)
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Put<TaskType>(this.VcloudClient, this.Resource.href, SerializationUtil.SerializeObject<GatewayType>(gatewayParams, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.edgeGateway+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task ReapplyServices()
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/reapplyServices", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task Redeploy()
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/redeploy", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task SyncSyslogServer()
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/syncSyslogServerSettings", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task UpgradeConfig()
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/upgradeConfig", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task Delete(vCloudClient client, ReferenceType gatewayRef)
    {
      try
      {
        return new Task(client, SdkUtil.Delete<TaskType>(client, gatewayRef.href, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task ConfigureServices(GatewayFeaturesType gatewayFeaturesType)
    {
      return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/configureServices", SerializationUtil.SerializeObject<GatewayFeaturesType>(gatewayFeaturesType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.edgeGatewayServiceConfiguration+xml", 202));
    }

    public Task Delete()
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Delete<TaskType>(this.VcloudClient, this.Resource.href, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void SortRefs()
    {
      if (this.Resource.Link == null)
        return;
      foreach (LinkType linkType in this.Resource.Link)
      {
        if (linkType.rel.Equals("up") && linkType.type.Equals("application/vnd.vmware.admin.vdc+xml"))
          this.adminVdcReference = (ReferenceType) linkType;
      }
    }
  }
}
