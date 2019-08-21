// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.utility.VcloudEntity`1
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using System;
using System.Collections.Generic;

namespace com.vmware.vcloud.sdk.utility
{
  public abstract class VcloudEntity<T> : VcloudResource<T> where T : EntityType
  {
    private ReferenceType _referenceType;
    private List<Task> _tasks;

    protected VcloudEntity(vCloudClient client, T entityType)
      : base(client, entityType)
    {
      EntityType entityType1 = (EntityType) entityType;
      this.SetTasks(client, entityType1);
      this.SetReference(entityType1);
    }

    public List<Task> Tasks
    {
      get
      {
        if (this._tasks != null)
          return this._tasks;
        return new List<Task>();
      }
    }

    public new ReferenceType Reference
    {
      get
      {
        return this._referenceType;
      }
    }

    private void SetTasks(vCloudClient client, EntityType entityType)
    {
      if (this._tasks != null || entityType == null || (entityType.Tasks == null || entityType.Tasks.Task == null))
        return;
      foreach (TaskType taskResource_v1_5 in entityType.Tasks.Task)
      {
        if (this._tasks == null)
          this._tasks = new List<Task>();
        this._tasks.Add(new Task(client, taskResource_v1_5));
      }
    }

    private void SetReference(EntityType entity)
    {
      if (entity == null)
        return;
      this._referenceType = new ReferenceType();
      this._referenceType.href = entity.href;
      this._referenceType.name = entity.name;
      this._referenceType.type = entity.type;
      this._referenceType.id = entity.id;
    }

    protected static T GetEntityById(vCloudClient client, string vCloudId, string mediaType)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + client.VCloudApiURL + "/entity/" + vCloudId);
        foreach (LinkType linkType in SdkUtil.Get<EntityType>(client, client.VCloudApiURL + "/entity/" + vCloudId, 200).Link)
        {
          if (linkType.type.Equals(mediaType))
            return SdkUtil.Get<T>(client, linkType.href, 200);
        }
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Metadata GetMetadata()
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + this.Reference.href + "/metadata");
        return new Metadata(this.VcloudClient, SdkUtil.Get<MetadataType>(this.VcloudClient, this.Reference.href + "/metadata", 200));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }
  }
}
