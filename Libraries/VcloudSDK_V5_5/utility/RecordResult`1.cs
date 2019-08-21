// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.utility.RecordResult`1
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using System;
using System.Collections.Generic;

namespace com.vmware.vcloud.sdk.utility
{
  public class RecordResult<T> : Result<QueryResultRecordsType> where T : QueryResultRecordType
  {
    private List<T> _records;

    internal RecordResult(vCloudClient client, QueryResultRecordsType recordsType)
      : base(client, (ContainerType) recordsType)
    {
      this.SortRecords_v1_5();
    }

    private void SortRecords_v1_5()
    {
      QueryResultRecordsType resource = this.GetResource();
      if (this._records == null)
        this._records = new List<T>();
      if (resource.Record == null)
        return;
      foreach (T obj in resource.Record)
        this._records.Add(obj);
    }

    public QueryResultRecordsType GetResource()
    {
      return (QueryResultRecordsType) this.Resource;
    }

    public List<T> GetRecords()
    {
      if (this._records == null)
        this._records = new List<T>();
      return this._records;
    }

    public RecordResult<T> GetFirstPage()
    {
      try
      {
        if (this.HasFirstPage())
          return this.VcloudClient.GetQueryService().ExecuteQuery<RecordResult<T>, QueryResultRecordsType, T>(this.GetFirstPageReference().href);
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<T> GetPreviousPage()
    {
      try
      {
        if (this.HasPreviousPage())
          return this.VcloudClient.GetQueryService().ExecuteQuery<RecordResult<T>, QueryResultRecordsType, T>(this.GetPreviousPageReference().href);
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<T> GetNextPage()
    {
      try
      {
        if (this.HasNextPage())
          return this.VcloudClient.GetQueryService().ExecuteQuery<RecordResult<T>, QueryResultRecordsType, T>(this.GetNextPageReference().href);
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<T> GetLastPage()
    {
      try
      {
        if (this.HasLastPage())
          return this.VcloudClient.GetQueryService().ExecuteQuery<RecordResult<T>, QueryResultRecordsType, T>(this.GetLastPageReference().href);
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult GetReferenceResult()
    {
      try
      {
        if (this.HasAlternateReferencesRefResult())
          return this.VcloudClient.GetQueryService().ExecuteQuery<ReferenceResult, ReferencesType, T>(this.GetAlternateReferencesRef().href);
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<T> GetRecordResult()
    {
      try
      {
        if (this.HasAlternateRecordsRefResult())
          return this.VcloudClient.GetQueryService().ExecuteQuery<RecordResult<T>, QueryResultRecordsType, T>(this.GetAlternateRecordRef().href);
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<T> GetIdRecordResult()
    {
      try
      {
        if (this.HasAlternateIdRecordsRefResult())
          return this.VcloudClient.GetQueryService().ExecuteQuery<RecordResult<T>, QueryResultRecordsType, T>(this.GetAlternateIdRecordRef().href);
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }
  }
}
