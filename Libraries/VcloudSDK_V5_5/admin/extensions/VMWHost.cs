// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.extensions.VMWHost
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;
using System;

namespace com.vmware.vcloud.sdk.admin.extensions
{
  public class VMWHost : VcloudEntity<HostType>
  {
    internal VMWHost(vCloudClient client, HostType hostType_v1_5)
      : base(client, hostType_v1_5)
    {
    }

    public static VMWHost GetVMWHostByReference(vCloudClient client, ReferenceType reference)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + reference.href);
        return new VMWHost(client, VcloudResource<HostType>.GetResourceByReference(client, reference));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static VMWHost GetVMWHostById(vCloudClient client, string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        return new VMWHost(client, VcloudEntity<HostType>.GetEntityById(client, vCloudId, "application/vnd.vmware.admin.host+xml"));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task DisableHost()
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/disable", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task DisableHost(vCloudClient client, ReferenceType vmwHostRef)
    {
      try
      {
        string url = vmwHostRef.href + "/action/disable";
        return new Task(client, SdkUtil.Post<TaskType>(client, url, (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task EnableHost()
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/enable", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task EnableHost(vCloudClient client, ReferenceType vmwHostRef)
    {
      try
      {
        string url = vmwHostRef.href + "/action/enable";
        return new Task(client, SdkUtil.Post<TaskType>(client, url, (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task UnPrepareHost()
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/unprepare", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task UnPrepareHost(vCloudClient client, ReferenceType hostRef)
    {
      try
      {
        string url = hostRef.href + "/action/unprepare";
        return new Task(client, SdkUtil.Post<TaskType>(client, url, (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task PrepareHost(string username, string password)
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/prepare", SerializationUtil.SerializeObject<PrepareHostParamsType>(new PrepareHostParamsType()
        {
          Password = password,
          Username = username
        }, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.prepareHostParams+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task PrepareHost(
      vCloudClient client,
      ReferenceType hostRef,
      string username,
      string password)
    {
      try
      {
        PrepareHostParamsType prepareHostParamsType = new PrepareHostParamsType();
        prepareHostParamsType.Password = password;
        prepareHostParamsType.Username = username;
        string url = hostRef.href + "/action/prepare";
        string requestString = SerializationUtil.SerializeObject<PrepareHostParamsType>(prepareHostParamsType, "com.vmware.vcloud.api.rest.schema");
        return new Task(client, SdkUtil.Post<TaskType>(client, url, requestString, "application/vnd.vmware.admin.prepareHostParams+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task RepairHost()
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/repair", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task RepairHost(vCloudClient client, ReferenceType hostRef)
    {
      try
      {
        string url = hostRef.href + "/action/repair";
        return new Task(client, SdkUtil.Post<TaskType>(client, url, (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task UpgradeHost()
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/upgrade", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task UpgradeHost(vCloudClient client, ReferenceType hostRef)
    {
      try
      {
        string url = hostRef.href + "/action/upgrade";
        return new Task(client, SdkUtil.Post<TaskType>(client, url, (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }
  }
}
