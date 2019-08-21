// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.extensions.BlockingTask
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;
using System;

namespace com.vmware.vcloud.sdk.admin.extensions
{
  public class BlockingTask : VcloudEntity<BlockingTaskType>
  {
    private ReferenceType _taskReference;

    internal BlockingTask(vCloudClient client, BlockingTaskType resourceType)
      : base(client, resourceType)
    {
      this.SortBlockingTaskRefs_v1_5();
    }

    private void SortBlockingTaskRefs_v1_5()
    {
      if (this.Resource.Link == null)
        return;
      foreach (LinkType linkType in this.Resource.Link)
      {
        if (linkType.rel.Equals("up") && linkType.type.Equals("application/vnd.vmware.vcloud.task+xml"))
          this._taskReference = (ReferenceType) linkType;
      }
    }

    public ReferenceType GetTaskReference()
    {
      try
      {
        if (this._taskReference != null)
          return this._taskReference;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static BlockingTask GetBlockingTaskByReference(
      vCloudClient client,
      ReferenceType reference)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + reference.href);
        return new BlockingTask(client, VcloudResource<BlockingTaskType>.GetResourceByReference(client, reference));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static BlockingTask GetBlockingTaskById(vCloudClient client, string vCloudId)
    {
      Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
      return new BlockingTask(client, VcloudEntity<BlockingTaskType>.GetEntityById(client, vCloudId, "application/vnd.vmware.admin.blockingTask+xml"));
    }

    public ReferenceType GetOrgReference()
    {
      return this.Resource.Organization;
    }

    public ReferenceType GetUserReference()
    {
      return this.Resource.User;
    }

    public ReferenceType GetOwnerReference()
    {
      return this.Resource.TaskOwner;
    }

    public DateTime GetCreatedDate()
    {
      return this.Resource.createdTime;
    }

    public DateTime GetTimeoutDate()
    {
      return this.Resource.timeoutDate;
    }

    public string GetStatus()
    {
      return this.Resource.status;
    }

    public string GetTimeoutAction()
    {
      return this.Resource.timeoutAction;
    }

    public void AbortOperation(string abortMessage)
    {
      try
      {
        SdkUtil.Post<BlockingTaskOperationParamsType>(this.VcloudClient, this.Reference.href + "/action/abort", SerializationUtil.SerializeObject<BlockingTaskOperationParamsType>(new BlockingTaskOperationParamsType()
        {
          Message = abortMessage
        }, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.blockingTaskOperationParams+xml", 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void FailOperation(string failMessage)
    {
      try
      {
        SdkUtil.Post<BlockingTaskOperationParamsType>(this.VcloudClient, this.Reference.href + "/action/fail", SerializationUtil.SerializeObject<BlockingTaskOperationParamsType>(new BlockingTaskOperationParamsType()
        {
          Message = failMessage
        }, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.blockingTaskOperationParams+xml", 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void ResumeOperation(string resumeMessage)
    {
      try
      {
        SdkUtil.Post<BlockingTaskOperationParamsType>(this.VcloudClient, this.Reference.href + "/action/resume", SerializationUtil.SerializeObject<BlockingTaskOperationParamsType>(new BlockingTaskOperationParamsType()
        {
          Message = resumeMessage
        }, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.blockingTaskOperationParams+xml", 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public BlockingTask UpdateProgress(string updateMessage, long timeout)
    {
      try
      {
        BlockingTaskUpdateProgressParamsType progressParamsType = new BlockingTaskUpdateProgressParamsType();
        progressParamsType.Message = updateMessage;
        progressParamsType.TimeoutValueInMilliseconds = timeout;
        return new BlockingTask(this.VcloudClient, SdkUtil.Post<BlockingTaskType>(this.VcloudClient, this.Reference.href + "/action/updateProgress", SerializationUtil.SerializeObject<BlockingTaskUpdateProgressParamsType>(progressParamsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.blockingTaskUpdateProgressOperationParams+xml", 200));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public BlockingTask UpdateProgress(string updateMessage)
    {
      try
      {
        BlockingTaskUpdateProgressParamsType progressParamsType = new BlockingTaskUpdateProgressParamsType();
        progressParamsType.Message = updateMessage;
        return new BlockingTask(this.VcloudClient, SdkUtil.Post<BlockingTaskType>(this.VcloudClient, this.Reference.href + "/action/updateProgress", SerializationUtil.SerializeObject<BlockingTaskUpdateProgressParamsType>(progressParamsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.blockingTaskUpdateProgressOperationParams+xml", 200));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static ReferenceType GetOrgReference(
      vCloudClient client,
      ReferenceType blockingTaskRef)
    {
      try
      {
        return SdkUtil.Get<BlockingTaskType>(client, blockingTaskRef.href, 200).Organization;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static ReferenceType GetUserReference(
      vCloudClient client,
      ReferenceType blockingTaskRef)
    {
      try
      {
        return SdkUtil.Get<BlockingTaskType>(client, blockingTaskRef.href, 200).User;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static ReferenceType GetOwnerReference(
      vCloudClient client,
      ReferenceType blockingTaskRef)
    {
      try
      {
        return SdkUtil.Get<BlockingTaskType>(client, blockingTaskRef.href, 200).TaskOwner;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static DateTime GetCreatedDate(
      vCloudClient client,
      ReferenceType blockingTaskRef)
    {
      try
      {
        return SdkUtil.Get<BlockingTaskType>(client, blockingTaskRef.href, 200).createdTime;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static DateTime GetTimeoutDate(
      vCloudClient client,
      ReferenceType blockingTaskRef)
    {
      try
      {
        return SdkUtil.Get<BlockingTaskType>(client, blockingTaskRef.href, 200).timeoutDate;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static string GetStatus(vCloudClient client, ReferenceType blockingTaskRef)
    {
      try
      {
        return SdkUtil.Get<BlockingTaskType>(client, blockingTaskRef.href, 200).status;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static string GetTimeoutAction(vCloudClient client, ReferenceType blockingTaskRef)
    {
      try
      {
        return SdkUtil.Get<BlockingTaskType>(client, blockingTaskRef.href, 200).timeoutAction;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static void AbortOperation(
      vCloudClient client,
      ReferenceType blockingTaskRef,
      string abortMessage)
    {
      try
      {
        string requestString = SerializationUtil.SerializeObject<BlockingTaskOperationParamsType>(new BlockingTaskOperationParamsType()
        {
          Message = abortMessage
        }, "com.vmware.vcloud.api.rest.schema");
        SdkUtil.Post<TaskType>(client, blockingTaskRef.href + "/action/abort", requestString, "application/vnd.vmware.admin.blockingTaskOperationParams+xml", 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static void FailOperation(
      vCloudClient client,
      ReferenceType blockingTaskRef,
      string failMessage)
    {
      try
      {
        string requestString = SerializationUtil.SerializeObject<BlockingTaskOperationParamsType>(new BlockingTaskOperationParamsType()
        {
          Message = failMessage
        }, "com.vmware.vcloud.api.rest.schema");
        SdkUtil.Post<TaskType>(client, blockingTaskRef.href + "/action/fail", requestString, "application/vnd.vmware.admin.blockingTaskOperationParams+xml", 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static void ResumeOperation(
      vCloudClient client,
      ReferenceType blockingTaskRef,
      string resumeMessage)
    {
      try
      {
        string requestString = SerializationUtil.SerializeObject<BlockingTaskOperationParamsType>(new BlockingTaskOperationParamsType()
        {
          Message = resumeMessage
        }, "com.vmware.vcloud.api.rest.schema");
        SdkUtil.Post<TaskType>(client, blockingTaskRef.href + "/action/resume", requestString, "application/vnd.vmware.admin.blockingTaskOperationParams+xml", 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static BlockingTask UpdateProgress(
      vCloudClient client,
      ReferenceType blockingTaskRef,
      string updateMessage,
      long timeout)
    {
      try
      {
        BlockingTaskUpdateProgressParamsType progressParamsType = new BlockingTaskUpdateProgressParamsType();
        progressParamsType.Message = updateMessage;
        progressParamsType.TimeoutValueInMilliseconds = timeout;
        string requestString = SerializationUtil.SerializeObject<BlockingTaskOperationParamsType>((BlockingTaskOperationParamsType) progressParamsType, "com.vmware.vcloud.api.rest.schema");
        return new BlockingTask(client, SdkUtil.Post<BlockingTaskType>(client, blockingTaskRef.href + "/action/updateProgress", requestString, "application/vnd.vmware.admin.blockingTaskUpdateProgressOperationParams+xml", 200));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static BlockingTask UpdateProgress(
      vCloudClient client,
      ReferenceType blockingTaskRef,
      string updateMessage)
    {
      try
      {
        BlockingTaskUpdateProgressParamsType progressParamsType = new BlockingTaskUpdateProgressParamsType();
        progressParamsType.Message = updateMessage;
        string requestString = SerializationUtil.SerializeObject<BlockingTaskOperationParamsType>((BlockingTaskOperationParamsType) progressParamsType, "com.vmware.vcloud.api.rest.schema");
        return new BlockingTask(client, SdkUtil.Post<BlockingTaskType>(client, blockingTaskRef.href + "/action/updateProgress", requestString, "application/vnd.vmware.admin.blockingTaskUpdateProgressOperationParams+xml", 200));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }
  }
}
