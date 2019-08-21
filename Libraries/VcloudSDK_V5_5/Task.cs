// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.Task
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.constants;
using com.vmware.vcloud.sdk.utility;
using System;
using System.Threading;

namespace com.vmware.vcloud.sdk
{
  public class Task : VcloudEntity<TaskType>
  {
    private ReferenceType _blockingTaskReference;

    public Task(vCloudClient client, TaskType taskResource_v1_5)
      : base(client, taskResource_v1_5)
    {
      this.SortTaskRefs_v1_5();
    }

    public bool IsBlockingTask()
    {
      return this._blockingTaskReference != null;
    }

    public ReferenceType GetBlockingTaskReference()
    {
      try
      {
        if (this.IsBlockingTask())
          return this._blockingTaskReference;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task GetTaskByReference(vCloudClient client, ReferenceType taskRef)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + taskRef.href);
        return new Task(client, VcloudResource<TaskType>.GetResourceByReference(client, taskRef));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType GetUserReference()
    {
      return this.Resource.User;
    }

    public static ReferenceType GetUserReference(
      vCloudClient client,
      ReferenceType taskReference)
    {
      try
      {
        return new Task(client, VcloudResource<TaskType>.GetResourceByReference(client, taskReference)).Resource.User;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType GetOrgReference()
    {
      return this.Resource.Organization;
    }

    public static ReferenceType GetOrgReference(
      vCloudClient client,
      ReferenceType taskReference)
    {
      try
      {
        return new Task(client, VcloudResource<TaskType>.GetResourceByReference(client, taskReference)).Resource.Organization;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public int GetProgress()
    {
      return this.Resource.Progress;
    }

    public static int GetProgress(vCloudClient client, ReferenceType taskReference)
    {
      try
      {
        return new Task(client, VcloudResource<TaskType>.GetResourceByReference(client, taskReference)).Resource.Progress;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void CancelTask()
    {
      try
      {
        Task.ExecuteAction(this.VcloudClient, this.Reference.href + "/action/cancel", (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static void CancelTask(vCloudClient client, ReferenceType taskReference)
    {
      try
      {
        Task.ExecuteAction(client, taskReference.href + "/action/cancel", (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void WaitForTask(long timeout)
    {
      try
      {
        Task.WaitForTaskCompletion(this.VcloudClient, this.Reference, timeout > 0L ? (long) DateTime.Now.Millisecond + timeout : 0L, 0L);
      }
      catch (TimeoutException ex)
      {
        throw ex;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static void WaitForTask(vCloudClient client, ReferenceType taskRef, long timeout)
    {
      try
      {
        long endTime = timeout > 0L ? (long) DateTime.Now.Millisecond + timeout : 0L;
        Task.WaitForTaskCompletion(client, taskRef, endTime, 0L);
      }
      catch (TimeoutException ex)
      {
        throw ex;
      }
      catch (VCloudException ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void WaitForTask(long timeout, long period)
    {
      try
      {
        Task.WaitForTaskCompletion(this.VcloudClient, this.Reference, timeout > 0L ? (long) DateTime.Now.Millisecond + timeout : 0L, period);
      }
      catch (TimeoutException ex)
      {
        throw ex;
      }
      catch (VCloudException ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static void WaitForTask(
      vCloudClient client,
      ReferenceType taskRef,
      long timeout,
      long period)
    {
      try
      {
        long endTime = timeout > 0L ? (long) DateTime.Now.Millisecond + timeout : 0L;
        Task.WaitForTaskCompletion(client, taskRef, endTime, period);
      }
      catch (TimeoutException ex)
      {
        throw ex;
      }
      catch (VCloudException ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task GetTaskById(vCloudClient client, string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        return new Task(client, VcloudEntity<TaskType>.GetEntityById(client, vCloudId, "application/vnd.vmware.vcloud.task+xml"));
      }
      catch (VCloudException ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task UpdateTask(TaskType taskType)
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Put<TaskType>(this.VcloudClient, this.Resource.href, SerializationUtil.SerializeObject<TaskType>(taskType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.vcloud.task+xml", 200));
      }
      catch (VCloudException ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private static void ExecuteAction(
      vCloudClient client,
      string vappActionUrl,
      string content,
      string contentType,
      int statusCode)
    {
      try
      {
        SdkUtil.Post<Task>(client, vappActionUrl, content, contentType, statusCode);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void SortTaskRefs_v1_5()
    {
      if (this.Resource.Link == null)
        return;
      foreach (LinkType linkType in this.Resource.Link)
      {
        if (linkType.rel.Equals("down") && linkType.type.Equals("application/vnd.vmware.admin.blockingTask+xml"))
          this._blockingTaskReference = (ReferenceType) linkType;
      }
    }

    private static void WaitForTaskCompletion(
      vCloudClient client,
      ReferenceType taskRef,
      long endTime,
      long period)
    {
      Task taskByReference = Task.GetTaskByReference(client, taskRef);
      while (taskByReference.Resource.status.Equals(TaskStatusType.QUEUED.Value()) || taskByReference.Resource.status.Equals(TaskStatusType.RUNNING.Value()) || taskByReference.Resource.status.Equals(TaskStatusType.PRERUNNING.Value()))
      {
        if (period > 0L)
        {
          try
          {
            Thread.Sleep((int) period);
          }
          catch (ThreadInterruptedException ex)
          {
            throw new VCloudRuntimeException((Exception) ex);
          }
        }
        taskByReference = Task.GetTaskByReference(client, taskByReference.Reference);
        if ((long) DateTime.Now.Millisecond > endTime && endTime > 0L)
        {
          Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.TASK_TIMEOUT) + " - " + taskByReference.Resource.operation + " - " + taskByReference.Reference.href);
          throw new TimeoutException(SdkUtil.GetI18nString(SdkMessage.TASK_TIMEOUT) + " - " + taskByReference.Resource.operation + " - " + taskByReference.Reference.href);
        }
      }
      if (taskByReference.Resource.status.Equals(TaskStatusType.ABORTED.Value()))
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.TASK_ABORTED) + " - " + taskByReference.Resource.operation + " - " + taskByReference.Reference.href);
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.TASK_ABORTED) + " - " + taskByReference.Resource.operation + " - " + taskByReference.Reference.href);
      }
      if (taskByReference.Resource.status.Equals(TaskStatusType.CANCELED.Value()))
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.TASK_CANCELLED) + " - " + taskByReference.Resource.Error.message);
        throw new VCloudException(taskByReference.Resource.Error);
      }
      if (taskByReference.Resource.status.Equals(TaskStatusType.ERROR.Value()))
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.TASK_ERRORED) + " - " + taskByReference.Resource.Error.message);
        throw new VCloudException(taskByReference.Resource.Error);
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
