// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.Role
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;
using System;

namespace com.vmware.vcloud.sdk.admin
{
  public class Role : VcloudEntity<RoleType>
  {
    internal Role(vCloudClient client, RoleType roleType_v1_5)
      : base(client, roleType_v1_5)
    {
    }

    public static Role GetRoleByReference(vCloudClient client, ReferenceType roleRef)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + roleRef.href);
        return new Role(client, VcloudResource<RoleType>.GetResourceByReference(client, roleRef));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Role GetRoleById(vCloudClient client, string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        return new Role(client, VcloudEntity<RoleType>.GetEntityById(client, vCloudId, "application/vnd.vmware.admin.role+xml"));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Role UpdateRole(RoleType roleType)
    {
      try
      {
        string href = this.Reference.href;
        string requestString = SerializationUtil.SerializeObject<RoleType>(roleType, "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.PUT_URL_MSG) + " - " + href);
        return new Role(this.VcloudClient, SdkUtil.Put<RoleType>(this.VcloudClient, href, requestString, "application/vnd.vmware.admin.role+xml", 200));
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
        Role.DeleteRole(this.VcloudClient, this.Reference.href);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static void Delete(vCloudClient client, ReferenceType roleRef)
    {
      try
      {
        Role.DeleteRole(client, roleRef.href);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private static void DeleteRole(vCloudClient client, string roleUrl)
    {
      try
      {
        SdkUtil.Delete<TaskType>(client, roleUrl, 204);
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
