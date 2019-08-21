// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.utility.SdkUtil
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Resources;

namespace com.vmware.vcloud.sdk.utility
{
  public class SdkUtil
  {
    private static bool _isInitialised = false;
    private static ResourceBundle _resourceBundle;

    private SdkUtil()
    {
    }

    private static void Initialise()
    {
      if (SdkUtil._resourceBundle != null)
        return;
      try
      {
        SdkUtil._resourceBundle = ResourceBundle.getBundle("com.vmware.vcloud.sdk.Resource", Locale.getDefault(), "Resource");
      }
      catch (MissingManifestResourceException ex)
      {
        Logger.Log(TraceLevel.Critical, ex.Message);
        Logger.Log(TraceLevel.Information, "Loading locale en_US properties");
        SdkUtil._resourceBundle = ResourceBundle.getBundle("com.vmware.vcloud.sdk.Resource", Locale.US, "Resource");
      }
      SdkUtil._isInitialised = true;
    }

    public static string GetI18nString(SdkMessage sdkMessage)
    {
      if (!SdkUtil._isInitialised)
        SdkUtil.Initialise();
      try
      {
        return SdkUtil._resourceBundle.GetString(sdkMessage.ToString());
      }
      catch (MissingManifestResourceException ex)
      {
        Logger.Log(TraceLevel.Critical, ex.Message);
        return ex.Message;
      }
    }

    public static T Get<T>(vCloudClient client, string url, int statusCode)
    {
      try
      {
        return SdkUtil.ValidateResponse<T>(RestUtil.Get(client, url), statusCode);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static T Post<T>(
      vCloudClient client,
      string url,
      string requestString,
      string mediaType,
      int statusCode)
    {
      try
      {
        return SdkUtil.ValidateResponse<T>(RestUtil.Post(client, url, requestString, mediaType, "UTF-8"), statusCode);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static T Put<T>(
      vCloudClient client,
      string url,
      string requestString,
      string mediaType,
      int statusCode)
    {
      try
      {
        return SdkUtil.ValidateResponse<T>(RestUtil.Put(client, url, requestString, mediaType, "UTF-8"), statusCode);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static T Delete<T>(vCloudClient client, string url, int statusCode)
    {
      try
      {
        return SdkUtil.ValidateResponse<T>(RestUtil.Delete(client, url), statusCode);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private static T ValidateResponse<T>(Response response, int statusCode)
    {
      try
      {
        bool flag = response.IsExpected(statusCode);
        if (statusCode == 204)
        {
          if (flag)
            return default (T);
          response.HandleUnExpectedResponse();
        }
        if (!flag)
          response.HandleUnExpectedResponse();
        return response.GetResource<T>();
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }
  }
}
