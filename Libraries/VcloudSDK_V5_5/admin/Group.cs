// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.Group
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
  public class Group : VcloudEntity<GroupType>
  {
    private Dictionary<string, ReferenceType> _userRefsByName = new Dictionary<string, ReferenceType>();

    internal Group(vCloudClient client, GroupType groupType_v1_5)
      : base(client, groupType_v1_5)
    {
      this.SortRefs_v1_5();
    }

    public static Group GetGroupByReference(vCloudClient client, ReferenceType groupRef)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + groupRef.href);
        return new Group(client, VcloudResource<GroupType>.GetResourceByReference(client, groupRef));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Group GetGroupById(vCloudClient client, string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        return new Group(client, VcloudEntity<GroupType>.GetEntityById(client, vCloudId, "application/vnd.vmware.admin.group+xml"));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Group UpdateGroup(GroupType groupType)
    {
      try
      {
        string href = this.Reference.href;
        string requestString = SerializationUtil.SerializeObject<GroupType>(groupType, "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.PUT_URL_MSG) + " - " + href);
        return new Group(this.VcloudClient, SdkUtil.Put<GroupType>(this.VcloudClient, href, requestString, "application/vnd.vmware.admin.group+xml", 200));
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
        Group.DeleteGroup(this.VcloudClient, this.Reference.href);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static void Delete(vCloudClient client, ReferenceType groupRef)
    {
      try
      {
        Group.DeleteGroup(client, groupRef.href);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void SortRefs_v1_5()
    {
      this._userRefsByName = new Dictionary<string, ReferenceType>();
      if (this.Resource.UsersList == null || this.Resource.UsersList.UserReference == null)
        return;
      foreach (ReferenceType referenceType in this.Resource.UsersList.UserReference)
        this._userRefsByName.Add(referenceType.name, referenceType);
    }

    public ReferenceType GetRoleReference()
    {
      try
      {
        if (this.Resource.Role != null)
          return this.Resource.Role;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Dictionary<string, ReferenceType> GetUserRefsByName()
    {
      return this._userRefsByName;
    }

    public List<ReferenceType> GetUserRefs()
    {
      return this._userRefsByName.Values.ToList<ReferenceType>();
    }

    public ReferenceType GetUserRefByName(string userName)
    {
      return this._userRefsByName[userName];
    }

    private static void DeleteGroup(vCloudClient client, string groupUrl)
    {
      try
      {
        SdkUtil.Delete<TaskType>(client, groupUrl, 204);
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
