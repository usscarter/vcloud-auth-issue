// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.Organization
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace com.vmware.vcloud.sdk
{
  public class Organization : VcloudEntity<OrgType>
  {
    private Dictionary<string, ReferenceType> _vdcRefsByName = new Dictionary<string, ReferenceType>();
    private Dictionary<string, ReferenceType> _networkRefsByName = new Dictionary<string, ReferenceType>();
    private Dictionary<string, ReferenceType> _catalogRefsById = new Dictionary<string, ReferenceType>();
    private Dictionary<string, ReferenceType> _catalogRefsByName = new Dictionary<string, ReferenceType>();
    private ReferenceType _tasksListRef;

    protected Organization(vCloudClient client, OrgType org_v1_5)
      : base(client, org_v1_5)
    {
      this.SortRefs_v1_5();
    }

    public static Organization GetOrganizationByReference(
      vCloudClient client,
      ReferenceType orgRef)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + orgRef.href);
        return new Organization(client, VcloudResource<OrgType>.GetResourceByReference(client, orgRef));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task CreateTask(TaskType taskType)
    {
      string requestString = SerializationUtil.SerializeObject<TaskType>(taskType, "com.vmware.vcloud.api.rest.schema");
      Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.POST_URL_MSG) + " - " + this.GetTasksListRef().href);
      return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.GetTasksListRef().href, requestString, "application/vnd.vmware.vcloud.task+xml", 200));
    }

    public static Organization GetOrganizationById(vCloudClient client, string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        return new Organization(client, VcloudEntity<OrgType>.GetEntityById(client, vCloudId, "application/vnd.vmware.vcloud.org+xml"));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType GetTasksListRef()
    {
      return this._tasksListRef;
    }

    public Dictionary<string, ReferenceType> GetVdcRefsByName()
    {
      return this._vdcRefsByName;
    }

    [Obsolete("This method is deprecated  since SDK 5.5. Use the Resource.Link")]
    public Dictionary<string, ReferenceType> GetNetworkRefsByName()
    {
      return this._networkRefsByName;
    }

    public List<ReferenceType> GetVdcRefs()
    {
      if (this._vdcRefsByName.Values != null)
        return this._vdcRefsByName.Values.ToList<ReferenceType>();
      return new List<ReferenceType>();
    }

    public List<ReferenceType> GetCatalogRefs()
    {
      if (this._catalogRefsByName.Values != null)
        return this._catalogRefsByName.Values.ToList<ReferenceType>();
      return new List<ReferenceType>();
    }

    public ReferenceType GetVdcRefByName(string name)
    {
      return this._vdcRefsByName[name];
    }

    [Obsolete("This method is deprecated  since SDK 5.5. Use the Resource.Link")]
    public List<ReferenceType> GetNetworkRefs()
    {
      if (this._networkRefsByName.Values != null)
        return this._networkRefsByName.Values.ToList<ReferenceType>();
      return new List<ReferenceType>();
    }

    [Obsolete("This method is deprecated  since SDK 5.5. Use the Resource.Link")]
    public ReferenceType GetNetworkRefByName(string name)
    {
      return this._networkRefsByName[name];
    }

    private static string GetId(string href)
    {
      int num = href.LastIndexOf("/");
      return href.Substring(num + 1);
    }

    public ControlAccessParamsType GetCatalogControlAccessByReference(
      ReferenceType catalogRef)
    {
      try
      {
        string url = this.Reference.href + "/catalog/" + Organization.GetId(catalogRef.href) + "/controlAccess/";
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + url);
        return SdkUtil.Get<ControlAccessParamsType>(this.VcloudClient, url, 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ControlAccessParamsType UpdateCatalogControlAccessByReference(
      ReferenceType catalogRef,
      ControlAccessParamsType controlAccessParams)
    {
      try
      {
        string url = this.Reference.href + "/catalog/" + Organization.GetId(catalogRef.href) + "/action/controlAccess";
        string requestString = SerializationUtil.SerializeObject<ControlAccessParamsType>(controlAccessParams, "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.POST_URL_MSG) + " - " + url);
        return SdkUtil.Post<ControlAccessParamsType>(this.VcloudClient, url, requestString, "application/vnd.vmware.vcloud.controlAccess+xml", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void SortRefs_v1_5()
    {
      if (this.Resource.Link == null)
        return;
      foreach (LinkType linkType in ((IEnumerable<LinkType>) this.Resource.Link).ToList<LinkType>())
      {
        ReferenceType referenceType = (ReferenceType) linkType;
        string id = Organization.GetId(linkType.href);
        if (linkType.type.Equals("application/vnd.vmware.vcloud.catalog+xml"))
        {
          if (!this._catalogRefsById.ContainsKey(id))
            this._catalogRefsById.Add(id, referenceType);
          if (!this._catalogRefsByName.ContainsKey(referenceType.name))
            this._catalogRefsByName.Add(referenceType.name, referenceType);
        }
        else if (linkType.type.Equals("application/vnd.vmware.vcloud.vdc+xml"))
        {
          if (!this._vdcRefsByName.ContainsKey(referenceType.name))
            this._vdcRefsByName.Add(referenceType.name, referenceType);
        }
        else if (linkType.type.Equals("application/vnd.vmware.vcloud.orgNetwork+xml"))
        {
          if (!this._networkRefsByName.ContainsKey(referenceType.name))
            this._networkRefsByName.Add(referenceType.name, referenceType);
        }
        else if (linkType.type.Equals("application/vnd.vmware.vcloud.tasksList+xml"))
          this._tasksListRef = referenceType;
        else
          Logger.Log(TraceLevel.Warning, SdkUtil.GetI18nString(SdkMessage.UNKNOWN_REF_TYPE_MSG) + " - " + linkType.type);
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
