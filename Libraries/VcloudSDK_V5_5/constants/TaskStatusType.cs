// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.TaskStatusType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct TaskStatusType
  {
    public static TaskStatusType QUEUED = TaskStatusType.Get("queued");
    public static TaskStatusType PRERUNNING = TaskStatusType.Get("preRunning");
    public static TaskStatusType SUCCESS = TaskStatusType.Get("success");
    public static TaskStatusType RUNNING = TaskStatusType.Get("running");
    public static TaskStatusType ERROR = TaskStatusType.Get("error");
    public static TaskStatusType CANCELED = TaskStatusType.Get("canceled");
    public static TaskStatusType ABORTED = TaskStatusType.Get("aborted");
    private string _value;

    private static TaskStatusType Get(string str)
    {
      return new TaskStatusType(str);
    }

    private TaskStatusType(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<TaskStatusType> Values()
    {
      TaskStatusType taskStatusType = new TaskStatusType();
      List<TaskStatusType> taskStatusTypeList = new List<TaskStatusType>();
      foreach (FieldInfo field in taskStatusType.GetType().GetFields())
        taskStatusTypeList.Add((TaskStatusType) field.GetValue((object) taskStatusType));
      return taskStatusTypeList;
    }

    public static TaskStatusType FromValue(string value)
    {
      foreach (TaskStatusType taskStatusType in TaskStatusType.Values())
      {
        if (taskStatusType.Value().Equals(value))
          return taskStatusType;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
