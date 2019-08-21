// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.utility.Response
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using System;

namespace com.vmware.vcloud.sdk.utility
{
  public class Response : IDisposable
  {
    private string _responseXml = string.Empty;
    private int _responseStatusCode = int.MinValue;

    public string ResponseXml
    {
      get
      {
        return this._responseXml;
      }
      internal set
      {
        this._responseXml = value;
      }
    }

    public int ResponseStatusCode
    {
      get
      {
        return this._responseStatusCode;
      }
      internal set
      {
        this._responseStatusCode = value;
      }
    }

    public bool IsExpected(int expectedStatusCode)
    {
      Exception exception = new Exception();
      if (this.ResponseStatusCode == expectedStatusCode)
        return true;
      Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.EXPECTED_STATUS_CODE_MSG) + " - " + (object) expectedStatusCode);
      Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.ACTUAL_STATUS_CODE_MSG) + " - " + (object) this.ResponseStatusCode);
      return false;
    }

    public T GetResource<T>()
    {
      string responseXml = this.ResponseXml;
      if (string.IsNullOrEmpty(responseXml))
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.NO_RESPONSE_RECEIVED_MSG));
      return SerializationUtil.DeserializeObject<T>(responseXml, "com.vmware.vcloud.api.rest.schema");
    }

    public static T GetResource<T>(string inputXml)
    {
      if (string.IsNullOrEmpty(inputXml))
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.NO_RESPONSE_RECEIVED_MSG));
      return SerializationUtil.DeserializeObject<T>(inputXml, "com.vmware.vcloud.api.rest.schema");
    }

    public void HandleUnExpectedResponse()
    {
      string responseXml = this.ResponseXml;
      if (!string.IsNullOrEmpty(responseXml))
        throw new VCloudException(SerializationUtil.DeserializeObject<ErrorType>(responseXml, "com.vmware.vcloud.api.rest.schema"));
      throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.NO_ERROR_MSG) + " - " + (object) this.ResponseStatusCode);
    }

    protected void Dispose(bool disposing)
    {
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }
  }
}
