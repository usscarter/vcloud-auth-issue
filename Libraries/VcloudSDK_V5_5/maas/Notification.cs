// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.maas.Notification
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;
using System;
using System.Collections.Generic;

namespace com.vmware.vcloud.sdk.maas
{
  public class Notification
  {
    private const string GLOBAL_SDK_LOGGER_NAME = "com.vmware.vcloud.sdk";
    private const string UTF_8_ENCODING = "UTF-8";
    private Dictionary<string, object> notificationHeaders;
    private NotificationType _notificationResource;
    private EntityLinkType _userEntityLinkType;
    private EntityLinkType _orgEntityLinkType;
    private EntityLinkType _entityLinkType;
    private EntityLinkType _taskOwnerLinkType;

    private Notification(string notificationMessage, Dictionary<string, object> notificationHeaders)
    {
      this.notificationHeaders = notificationHeaders;
      NotificationType resource;
      try
      {
        Logger.Log(TraceLevel.Information, notificationMessage);
        resource = Response.GetResource<NotificationType>(notificationMessage);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
      this._notificationResource = resource;
      this.SortNotificationLinks();
    }

    private void SortNotificationLinks()
    {
      if (this._notificationResource.EntityLink == null)
        return;
      foreach (EntityLinkType entityLinkType in this._notificationResource.EntityLink)
      {
        if (entityLinkType.rel.Equals("up"))
          this._orgEntityLinkType = entityLinkType;
        else if (entityLinkType.rel.Equals("down"))
          this._userEntityLinkType = entityLinkType;
        else if (entityLinkType.rel.Equals("entity"))
          this._entityLinkType = entityLinkType;
        else if (entityLinkType.rel.Equals("task:owner"))
          this._taskOwnerLinkType = entityLinkType;
      }
    }

    public EntityLinkType GetUserLink()
    {
      try
      {
        if (this._userEntityLinkType != null)
          return this._userEntityLinkType;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.ENTITY_LINK_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public EntityLinkType GetOrgLink()
    {
      try
      {
        if (this._orgEntityLinkType != null)
          return this._orgEntityLinkType;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.ENTITY_LINK_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public EntityLinkType GetTaskOwnerLink()
    {
      try
      {
        if (this._taskOwnerLinkType != null)
          return this._taskOwnerLinkType;
        if (this._entityLinkType != null)
          return this._entityLinkType;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.ENTITY_LINK_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public EntityLinkType GetEntityLink()
    {
      try
      {
        if (this._entityLinkType != null)
          return this._entityLinkType;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.ENTITY_LINK_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Notification GetNotification(
      string notificationMessage,
      Dictionary<string, object> notificationHeaders)
    {
      return new Notification(notificationMessage, notificationHeaders);
    }

    public NotificationType GetResource()
    {
      return this._notificationResource;
    }

    public Dictionary<string, object> GetNotificationHeaders()
    {
      try
      {
        if (this.notificationHeaders != null)
          return this.notificationHeaders;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.DATA_NOT_FOUND));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public bool IsBlockingTask()
    {
      try
      {
        return this.GetEntityLink().type.Equals(com.vmware.vcloud.sdk.constants.EntityType.BLOCKING_TASK.Value());
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public EntityLinkType GetBlockingTaskLink()
    {
      try
      {
        if (!this.IsBlockingTask())
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.NON_BLOCKING_NOTIFICATION));
        return this._entityLinkType;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public com.vmware.vcloud.sdk.constants.EventType GetNotificationEventType()
    {
      try
      {
        if (this.GetResource() == null && this.GetResource().type == null)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.DATA_NOT_FOUND));
        return com.vmware.vcloud.sdk.constants.EventType.FromValue(this.GetResource().type);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public com.vmware.vcloud.sdk.constants.EntityType GetEntityLinkType()
    {
      try
      {
        return com.vmware.vcloud.sdk.constants.EntityType.FromValue(this.GetEntityLink().type);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public com.vmware.vcloud.sdk.constants.EntityType GetTaskOwnerLinkType()
    {
      try
      {
        return com.vmware.vcloud.sdk.constants.EntityType.FromValue(this.GetTaskOwnerLink().type);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }
  }
}
