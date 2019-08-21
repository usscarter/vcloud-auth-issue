// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.utility.Expression
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.constants;
using com.vmware.vcloud.sdk.constants.query;
using System;
using System.Text;

namespace com.vmware.vcloud.sdk.utility
{
  public class Expression
  {
    private string _expressionText = string.Empty;

    public Expression(QueryField key, string value, ExpressionType expressionType)
    {
      if (key == null || value == null || (!(expressionType.Value() != ExpressionType.NULL.Value()) || string.IsNullOrEmpty(value)))
        return;
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(key.Value());
      stringBuilder.Append(expressionType.Value());
      stringBuilder.Append(value);
      try
      {
        this._expressionText = this.EncodeValue(stringBuilder.ToString());
      }
      catch (Exception ex)
      {
        throw new VCloudRuntimeException(ex);
      }
    }

    public Expression(
      string key,
      MetadataDomain domain,
      MetadataTypedValue value,
      MetadataExpressionType expressionType)
    {
      try
      {
        if (key == null || value == null || expressionType.Value() == null)
          return;
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("metadata@" + domain.Value() + ":" + key);
        stringBuilder.Append(expressionType.Value());
        if (value is MetadataStringValue)
          stringBuilder.Append("STRING:" + ((MetadataStringValue) value).Value);
        else if (value is MetadataDateTimeValue)
          stringBuilder.Append("DATETIME:" + ((MetadataDateTimeValue) value).Value.ToString());
        else if (value is MetadataNumberValue)
          stringBuilder.Append("NUMBER:" + (object) ((MetadataNumberValue) value).Value);
        else if (value is MetadataBooleanValue)
          stringBuilder.Append("BOOLEAN:" + (object) ((MetadataBooleanValue) value).Value);
        try
        {
          this._expressionText = this.EncodeValue(stringBuilder.ToString());
        }
        catch (Exception ex)
        {
          throw new VCloudRuntimeException(ex);
        }
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Expression(string key, MetadataTypedValue value, MetadataExpressionType expressionType)
    {
      if (key == null || value == null || expressionType.Value() == null)
        return;
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("metadata:" + key);
      stringBuilder.Append(expressionType.Value());
      if (value is MetadataStringValue)
        stringBuilder.Append("STRING:" + ((MetadataStringValue) value).Value);
      else if (value is MetadataDateTimeValue)
        stringBuilder.Append("DATETIME:" + ((MetadataDateTimeValue) value).Value.ToString());
      else if (value is MetadataNumberValue)
        stringBuilder.Append("NUMBER:" + (object) ((MetadataNumberValue) value).Value);
      else if (value is MetadataBooleanValue)
        stringBuilder.Append("BOOLEAN:" + (object) ((MetadataBooleanValue) value).Value);
      try
      {
        this._expressionText = this.EncodeValue(stringBuilder.ToString());
      }
      catch (Exception ex)
      {
        throw new VCloudRuntimeException(ex);
      }
    }

    internal string GetExpressionText()
    {
      return this._expressionText;
    }

    private string EncodeValue(string value)
    {
      try
      {
        System.Uri uri = new System.Uri("http://www.vmware.com/vcloud/v1.5");
        return new UriBuilder(uri)
        {
          Path = (uri.PathAndQuery + "/" + value)
        }.Uri.ToString().Replace("http://www.vmware.com/vcloud/v1.5/", "");
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }
  }
}
