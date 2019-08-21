// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.TaskList
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
  public class TaskList : VcloudEntity<TasksListType>
  {
    private List<Task> _tasks;

    private TaskList(vCloudClient client, TasksListType tasksList)
      : base(client, tasksList)
    {
      this.SortTasks_v1_5();
    }

    public List<Task> GetTasks()
    {
      return this._tasks;
    }

    public static TaskList GetTaskListByReference(
      vCloudClient client,
      ReferenceType taskListReference)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + taskListReference.href);
        return new TaskList(client, VcloudResource<TasksListType>.GetResourceByReference(client, taskListReference));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void SortTasks_v1_5()
    {
      try
      {
        this._tasks = new List<Task>();
        if (this.Resource.Task == null)
          return;
        foreach (TaskType taskResource_v1_5 in ((IEnumerable<TaskType>) this.Resource.Task).ToList<TaskType>())
        {
          Task task = new Task(this.VcloudClient, taskResource_v1_5);
          if (task != null)
            this._tasks.Add(task);
        }
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
