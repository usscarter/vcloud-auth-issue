// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.ExternalNetwork
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;
using System;

namespace com.vmware.vcloud.sdk.admin
{
  public class ExternalNetwork : VcloudEntity<ExternalNetworkType>
  {
    internal ExternalNetwork(vCloudClient client, ExternalNetworkType externalNetworkType_1_5)
      : base(client, externalNetworkType_1_5)
    {
    }

    public static ExternalNetwork GetExternalNetworkByReference(
      vCloudClient client,
      ReferenceType externalNetworkRef)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + externalNetworkRef.href);
        return new ExternalNetwork(client, VcloudResource<ExternalNetworkType>.GetResourceByReference(client, externalNetworkRef));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static ExternalNetwork GetExternalNetworkById(
      vCloudClient client,
      string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        return new ExternalNetwork(client, VcloudEntity<ExternalNetworkType>.GetEntityById(client, vCloudId, "application/vnd.vmware.admin.network+xml"));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    [Obsolete("This method is deprecated  since API 5.1, SDK 5.1.This API method will not work with SDK 5.1")]
    public Task Reset()
    {
      try
      {
        return ExternalNetwork.ExecuteAction(this.VcloudClient, this.Reference.href + "/action/reset", (string) null, (string) null, 202);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    [Obsolete("This method is deprecated  since API 5.1, SDK 5.1.This API method will not work with SDK 5.1")]
    public static Task Reset(vCloudClient client, ReferenceType externalNetworkReference)
    {
      try
      {
        return ExternalNetwork.ExecuteAction(client, externalNetworkReference.href + "/action/reset", (string) null, (string) null, 202);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private static Task ExecuteAction(
      vCloudClient client,
      string externalNetworkActionUrl,
      string content,
      string contentType,
      int statusCode)
    {
      try
      {
        return new Task(client, SdkUtil.Post<TaskType>(client, externalNetworkActionUrl, content, contentType, statusCode));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }
  }
}
