// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.Metadata
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.constants;
using com.vmware.vcloud.sdk.utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace com.vmware.vcloud.sdk
{
  public class Metadata : VcloudResource<MetadataType>
  {
    private Dictionary<string, string> _metadataEntries;
    private List<MetadataEntryType> typedMetadataEntries;

    public Metadata(vCloudClient client, MetadataType metadataType)
      : base(client, metadataType)
    {
      this.SortMetadataEntries();
      this.SortTypedMetadataEntries();
    }

    private void SortMetadataEntries()
    {
      try
      {
        this._metadataEntries = new Dictionary<string, string>();
        if (this.Resource.MetadataEntry == null)
          return;
        foreach (MetadataEntryType metadataEntryType in this.Resource.MetadataEntry)
        {
          if (metadataEntryType.Value != null && metadataEntryType.Domain == null)
            this._metadataEntries.Add(metadataEntryType.Key, metadataEntryType.Value);
        }
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void SortTypedMetadataEntries()
    {
      try
      {
        this.typedMetadataEntries = new List<MetadataEntryType>();
        if (this.Resource.MetadataEntry == null)
          return;
        foreach (MetadataEntryType metadataEntryType in this.Resource.MetadataEntry)
        {
          if (metadataEntryType.Value == null)
            this.typedMetadataEntries.Add(metadataEntryType);
        }
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public string GetMetadataEntry(string key)
    {
      if (this._metadataEntries.ContainsKey(key))
        return this._metadataEntries[key];
      throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.DATA_NOT_FOUND));
    }

    public MetadataEntryType GetTypedMetadataEntry(string key)
    {
      foreach (MetadataEntryType typedMetadataEntry in this.typedMetadataEntries)
      {
        if (typedMetadataEntry.Key.Equals(key) && typedMetadataEntry.Domain == null)
          return typedMetadataEntry;
      }
      throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.DATA_NOT_FOUND));
    }

    public MetadataEntryType GetTypedMetadataEntry(
      string key,
      MetadataDomain domain)
    {
      if (domain.Value() != null && key != null)
      {
        foreach (MetadataEntryType typedMetadataEntry in this.typedMetadataEntries)
        {
          if (typedMetadataEntry.Key.Equals(key) && typedMetadataEntry.Domain.Value.Equals(domain.Value()))
            return typedMetadataEntry;
        }
      }
      throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.DATA_NOT_FOUND));
    }

    public Dictionary<string, string> GetMetadataEntries()
    {
      return this._metadataEntries;
    }

    public List<MetadataEntryType> GetTypedMetadataEntries()
    {
      return this.typedMetadataEntries;
    }

    public Task UpdateMetadataEntries(Dictionary<string, string> metadataEntries)
    {
      try
      {
        MetadataType metadataType = new MetadataType();
        List<MetadataEntryType> source = new List<MetadataEntryType>();
        foreach (string key in metadataEntries.Keys)
          source.Add(new MetadataEntryType()
          {
            Key = key,
            Value = metadataEntries[key]
          });
        metadataType.MetadataEntry = source.OfType<MetadataEntryType>().ToArray<MetadataEntryType>();
        string requestString = SerializationUtil.SerializeObject<MetadataType>(metadataType, "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.PUT_URL_MSG) + " - " + this.Reference.href);
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href, requestString, "application/vnd.vmware.vcloud.metadata+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task UpdateTypedMetadataEntries(List<MetadataEntryType> metadataEntries)
    {
      try
      {
        string requestString = SerializationUtil.SerializeObject<MetadataType>(new MetadataType()
        {
          MetadataEntry = metadataEntries.ToArray()
        }, "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.POST_URL_MSG) + " - " + this.Reference.href);
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href, requestString, "application/vnd.vmware.vcloud.metadata+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task UpdateMetadataEntry(string key, string value)
    {
      string url = Metadata.EncodeUrl(this.Reference.href, key);
      try
      {
        string requestString = SerializationUtil.SerializeObject<MetadataValueType>(new MetadataValueType()
        {
          Value = value
        }, "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.PUT_URL_MSG) + " - " + url);
        return new Task(this.VcloudClient, SdkUtil.Put<TaskType>(this.VcloudClient, url, requestString, "application/vnd.vmware.vcloud.metadata.value+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task UpdateTypedMetadataEntry(MetadataEntryType typedMetadataEntry)
    {
      return this.UpdateTypedMetadataEntries(new List<MetadataEntryType>()
      {
        typedMetadataEntry
      });
    }

    public Task DeleteMetadataEntry(string key)
    {
      string url = Metadata.EncodeUrl(this.Reference.href, key);
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.DELETE_URL_MSG) + " - " + url);
        return new Task(this.VcloudClient, SdkUtil.Delete<TaskType>(this.VcloudClient, url, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task DeleteTypedMetadataEntry(string key)
    {
      try
      {
        MetadataEntryType typedMetadataEntry = this.GetTypedMetadataEntry(key);
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.DELETE_URL_MSG) + " - " + typedMetadataEntry.href);
        return new Task(this.VcloudClient, SdkUtil.Delete<TaskType>(this.VcloudClient, typedMetadataEntry.href, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task DeleteTypedMetadataEntry(string key, MetadataDomain domain)
    {
      try
      {
        MetadataEntryType typedMetadataEntry = this.GetTypedMetadataEntry(key, domain);
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.DELETE_URL_MSG) + " - " + typedMetadataEntry.href);
        return new Task(this.VcloudClient, SdkUtil.Delete<TaskType>(this.VcloudClient, typedMetadataEntry.href, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static string GetMetadataEntry(vCloudClient client, ReferenceType entityRef, string key)
    {
      try
      {
        string url = Metadata.EncodeUrl(entityRef.href + "/metadata", key);
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + url);
        return SdkUtil.Get<MetadataValueType>(client, url, 200).Value;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Dictionary<string, string> GetMetadataEntries(
      vCloudClient client,
      ReferenceType entityRef)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + entityRef.href + "/metadata");
        MetadataType metadataType = SdkUtil.Get<MetadataType>(client, entityRef.href + "/metadata", 200);
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        foreach (MetadataEntryType metadataEntryType in metadataType.MetadataEntry)
          dictionary.Add(metadataEntryType.Key, metadataEntryType.Value);
        return dictionary;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task UpdateMetadataEntry(
      vCloudClient client,
      ReferenceType entityRef,
      string key,
      string value)
    {
      try
      {
        string url = Metadata.EncodeUrl(entityRef.href + "/metadata", key);
        string requestString = SerializationUtil.SerializeObject<MetadataValueType>(new MetadataValueType()
        {
          Value = value
        }, "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.PUT_URL_MSG) + " - " + url);
        return new Task(client, SdkUtil.Put<TaskType>(client, url, requestString, "application/vnd.vmware.vcloud.metadata.value+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task DeleteMetadataEntry(
      vCloudClient client,
      ReferenceType entityRef,
      string key)
    {
      try
      {
        string url = Metadata.EncodeUrl(entityRef.href + "/metadata", key);
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.DELETE_URL_MSG) + " - " + url);
        return new Task(client, SdkUtil.Delete<TaskType>(client, url, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private static string EncodeUrl(string url, string key)
    {
      try
      {
        System.Uri uri = new System.Uri(url);
        return new UriBuilder(uri)
        {
          Path = (uri.PathAndQuery + "/" + key)
        }.Uri.ToString();
      }
      catch (Exception ex)
      {
        throw new VCloudRuntimeException(ex);
      }
    }
  }
}
