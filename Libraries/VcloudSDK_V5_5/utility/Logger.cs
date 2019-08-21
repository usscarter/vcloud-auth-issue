// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.utility.Logger
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System.Diagnostics;

namespace com.vmware.vcloud.sdk.utility
{
  public class Logger
  {
    private static TraceSource _traceSource = ClientAppTrace.TraceSource;

    private Logger()
    {
    }

    public static void SourceLevel(Levels level)
    {
      Logger._traceSource.Switch.Level = Logger.GetSourceLevel(level);
    }

    public static void Log(TraceLevel traceLevel, string message)
    {
      Logger._traceSource.TraceEvent(Logger.GetTraceEventType(traceLevel), 0, message);
    }

    public static void Log(TraceLevel traceLevel, string message, string module)
    {
      Logger._traceSource.TraceEvent(Logger.GetTraceEventType(traceLevel), 0, string.Format("{0},{1}", (object) module, (object) message));
    }

    public static void Log(TraceLevel traceLevel, string format, params object[] args)
    {
      Logger._traceSource.TraceEvent(Logger.GetTraceEventType(traceLevel), 0, format, args);
    }

    public static void CloseTracing()
    {
      Logger._traceSource.Close();
    }

    private static TraceEventType GetTraceEventType(TraceLevel level)
    {
      TraceEventType traceEventType = (TraceEventType) 0;
      switch (level)
      {
        case TraceLevel.Critical:
          traceEventType = TraceEventType.Critical;
          break;
        case TraceLevel.Error:
          traceEventType = TraceEventType.Error;
          break;
        case TraceLevel.Warning:
          traceEventType = TraceEventType.Warning;
          break;
        case TraceLevel.Information:
          traceEventType = TraceEventType.Information;
          break;
        case TraceLevel.Verbose:
          traceEventType = TraceEventType.Verbose;
          break;
      }
      return traceEventType;
    }

    private static SourceLevels GetSourceLevel(Levels level)
    {
      SourceLevels sourceLevels = SourceLevels.Off;
      switch (level)
      {
        case Levels.Off:
          sourceLevels = SourceLevels.Off;
          break;
        case Levels.Critical:
          sourceLevels = SourceLevels.Critical;
          break;
        case Levels.Error:
          sourceLevels = SourceLevels.Error;
          break;
        case Levels.Warning:
          sourceLevels = SourceLevels.Warning;
          break;
        case Levels.Information:
          sourceLevels = SourceLevels.Information;
          break;
        case Levels.Verbose:
          sourceLevels = SourceLevels.Verbose;
          break;
        case Levels.ActivityTracing:
          sourceLevels = SourceLevels.ActivityTracing;
          break;
        case Levels.All:
          sourceLevels = SourceLevels.All;
          break;
      }
      return sourceLevels;
    }
  }
}
