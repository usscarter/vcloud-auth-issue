// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.User
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
  public class User : VcloudEntity<UserType>
  {
    private Dictionary<string, ReferenceType> groupRefsByName = new Dictionary<string, ReferenceType>();

    internal User(vCloudClient client, UserType userType_v1_5)
      : base(client, userType_v1_5)
    {
      this.SortReferences_v1_5();
    }

    private void SortReferences_v1_5()
    {
      this.groupRefsByName = new Dictionary<string, ReferenceType>();
      GroupsListType groupReferences = this.Resource.GroupReferences;
      if (groupReferences == null || groupReferences.GroupReference == null)
        return;
      foreach (ReferenceType referenceType in groupReferences.GroupReference)
        this.groupRefsByName.Add(referenceType.name, referenceType);
    }

    public static User GetUserByReference(vCloudClient client, ReferenceType userRef)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + userRef.href);
        return new User(client, VcloudResource<UserType>.GetResourceByReference(client, userRef));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static User GetUserById(vCloudClient client, string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        return new User(client, VcloudEntity<UserType>.GetEntityById(client, vCloudId, "application/vnd.vmware.admin.user+xml"));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public User UpdateUser(UserType userType)
    {
      try
      {
        string href = this.Reference.href;
        string requestString = SerializationUtil.SerializeObject<UserType>(userType, "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.PUT_URL_MSG) + " - " + href);
        return new User(this.VcloudClient, SdkUtil.Put<UserType>(this.VcloudClient, href, requestString, "application/vnd.vmware.admin.user+xml", 200));
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
        User.DeleteUser(this.VcloudClient, this.Reference.href);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static void Delete(vCloudClient client, ReferenceType userRef)
    {
      try
      {
        User.DeleteUser(client, userRef.href);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private static void DeleteUser(vCloudClient client, string userUrl)
    {
      try
      {
        SdkUtil.Delete<TaskType>(client, userUrl, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void Unlock()
    {
      try
      {
        SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/unlock", (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static void Unlock(vCloudClient client, ReferenceType userRef)
    {
      try
      {
        SdkUtil.Post<TaskType>(client, userRef.href + "/action/unlock", (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
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

    public Dictionary<string, ReferenceType> GetGroupRefsByName()
    {
      return this.groupRefsByName;
    }

    public ReferenceType GetGroupRefByName(string groupName)
    {
      return this.groupRefsByName[groupName];
    }

    public List<ReferenceType> GetGroupRefs()
    {
      if (this.groupRefsByName.Values != null)
        return this.groupRefsByName.Values.ToList<ReferenceType>();
      return new List<ReferenceType>();
    }

    public List<EntityRightsType> GetEntityRights(List<ReferenceType> entityRefs)
    {
      try
      {
        EntityReferencesType entityReferencesType = new EntityReferencesType();
        List<ReferenceType> referenceTypeList = entityReferencesType.Reference != null ? ((IEnumerable<ReferenceType>) entityReferencesType.Reference).ToList<ReferenceType>() : new List<ReferenceType>();
        foreach (ReferenceType entityRef in entityRefs)
          referenceTypeList.Add(entityRef);
        UserEntityRightsType entityRightsType = SdkUtil.Post<UserEntityRightsType>(this.VcloudClient, this.Resource.href + "/entityRights", SerializationUtil.SerializeObject<EntityReferencesType>(entityReferencesType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.entityReferences+xml", 200);
        if (entityRightsType.EntityRights == null)
          return new List<EntityRightsType>();
        return ((IEnumerable<EntityRightsType>) entityRightsType.EntityRights).ToList<EntityRightsType>();
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public List<ReferenceType> GetGrantedRights()
    {
      try
      {
        RightReferencesType rightReferencesType = SdkUtil.Get<RightReferencesType>(this.VcloudClient, this.Resource.href + "/grantedRights", 200);
        List<ReferenceType> referenceTypeList = new List<ReferenceType>();
        if (rightReferencesType != null && rightReferencesType.RightReference != null)
        {
          foreach (ReferenceType referenceType in rightReferencesType.RightReference)
            referenceTypeList.Add(referenceType);
        }
        return referenceTypeList;
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
