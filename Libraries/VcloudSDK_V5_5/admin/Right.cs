// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.Right
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
  public class Right : VcloudEntity<RightType>
  {
    public Right(vCloudClient client, RightType rightType)
      : base(client, rightType)
    {
    }

    public static Right GetRightByReference(vCloudClient client, ReferenceType rightRef)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + rightRef.href);
        return new Right(client, VcloudResource<RightType>.GetResourceByReference(client, rightRef));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Right GetRightById(vCloudClient client, string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        return new Right(client, VcloudEntity<RightType>.GetEntityById(client, vCloudId, "application/vnd.vmware.admin.right+xml"));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Role AddToRole(ReferenceType roleRef)
    {
      try
      {
        Role roleByReference = Role.GetRoleByReference(this.VcloudClient, roleRef);
        roleByReference.Resource.RightReferences.RightReference = new ReferenceType[1]
        {
          this.Reference
        };
        return roleByReference.UpdateRole(roleByReference.Resource);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Role AddToRole(string vCloudRoleId)
    {
      try
      {
        Role roleById = Role.GetRoleById(this.VcloudClient, vCloudRoleId);
        roleById.Resource.RightReferences.RightReference = new ReferenceType[1]
        {
          this.Reference
        };
        return roleById.UpdateRole(roleById.Resource);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Role DeleteFromRole(string vCloudRoleId)
    {
      try
      {
        Role roleById = Role.GetRoleById(this.VcloudClient, vCloudRoleId);
        List<ReferenceType> list = ((IEnumerable<ReferenceType>) roleById.Resource.RightReferences.RightReference).ToList<ReferenceType>();
        for (int index = 0; index < list.Count<ReferenceType>(); ++index)
        {
          if (list[index].name.Equals(this.Reference.name))
            list.RemoveAt(index--);
        }
        roleById.Resource.RightReferences = new RightReferencesType()
        {
          RightReference = list.ToArray()
        };
        return roleById.UpdateRole(roleById.Resource);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Role DeleteFromRole(ReferenceType roleRef)
    {
      try
      {
        Role roleByReference = Role.GetRoleByReference(this.VcloudClient, roleRef);
        List<ReferenceType> list = ((IEnumerable<ReferenceType>) roleByReference.Resource.RightReferences.RightReference).ToList<ReferenceType>();
        for (int index = 0; index < list.Count; ++index)
        {
          if (list[index].name.Equals(this.Reference.name))
            list.RemoveAt(index--);
        }
        roleByReference.Resource.RightReferences = new RightReferencesType()
        {
          RightReference = list.ToArray()
        };
        return roleByReference.UpdateRole(roleByReference.Resource);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static void Delete(vCloudClient client, ReferenceType rightRef)
    {
      try
      {
        SdkUtil.Delete<TaskType>(client, rightRef.href, 204);
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
        SdkUtil.Delete<TaskType>(this.VcloudClient, this.Resource.href, 204);
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
