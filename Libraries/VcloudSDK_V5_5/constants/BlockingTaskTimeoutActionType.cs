// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.BlockingTaskTimeoutActionType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct BlockingTaskTimeoutActionType
  {
    public static BlockingTaskTimeoutActionType ABORT = BlockingTaskTimeoutActionType.Get("abort");
    public static BlockingTaskTimeoutActionType RESUME = BlockingTaskTimeoutActionType.Get("resume");
    public static BlockingTaskTimeoutActionType FAIL = BlockingTaskTimeoutActionType.Get("fail");
    private string _value;

    private static BlockingTaskTimeoutActionType Get(string str)
    {
      return new BlockingTaskTimeoutActionType(str);
    }

    private BlockingTaskTimeoutActionType(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<BlockingTaskTimeoutActionType> Values()
    {
      BlockingTaskTimeoutActionType timeoutActionType = new BlockingTaskTimeoutActionType();
      List<BlockingTaskTimeoutActionType> timeoutActionTypeList = new List<BlockingTaskTimeoutActionType>();
      foreach (FieldInfo field in timeoutActionType.GetType().GetFields())
        timeoutActionTypeList.Add((BlockingTaskTimeoutActionType) field.GetValue((object) timeoutActionType));
      return timeoutActionTypeList;
    }

    public static BlockingTaskTimeoutActionType FromValue(string value)
    {
      foreach (BlockingTaskTimeoutActionType timeoutActionType in BlockingTaskTimeoutActionType.Values())
      {
        if (timeoutActionType.Value().Equals(value))
          return timeoutActionType;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
