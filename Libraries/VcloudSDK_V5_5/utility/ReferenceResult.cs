// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.utility.ReferenceResult
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using System;
using System.Collections.Generic;

namespace com.vmware.vcloud.sdk.utility
{
  public class ReferenceResult : Result<ReferencesType>
  {
    private List<ReferenceType> _references;

    internal ReferenceResult(vCloudClient client, ReferencesType referencesType)
      : base(client, (ContainerType) referencesType)
    {
      this.SortReferences_v1_5();
    }

    private void SortReferences_v1_5()
    {
      if (this._references == null)
        this._references = new List<ReferenceType>();
      if (this.GetResource() == null || this.GetResource().Reference == null)
        return;
      foreach (ReferenceType referenceType in this.GetResource().Reference)
        this._references.Add(referenceType);
    }

    public ReferencesType GetResource()
    {
      return (ReferencesType) this.Resource;
    }

    public List<ReferenceType> GetReferences()
    {
      if (this._references == null)
        this._references = new List<ReferenceType>();
      return this._references;
    }

    public ReferenceResult GetFirstPage()
    {
      try
      {
        if (this.HasFirstPage())
          return this.VcloudClient.GetQueryService().ExecuteQuery<ReferenceResult, ReferencesType, QueryResultRecordType>(this.GetFirstPageReference().href);
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult GetPreviousPage()
    {
      try
      {
        if (this.HasPreviousPage())
          return this.VcloudClient.GetQueryService().ExecuteQuery<ReferenceResult, ReferencesType, QueryResultRecordType>(this.GetPreviousPageReference().href);
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult GetNextPage()
    {
      try
      {
        if (this.HasNextPage())
          return this.VcloudClient.GetQueryService().ExecuteQuery<ReferenceResult, ReferencesType, QueryResultRecordType>(this.GetNextPageReference().href);
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult GetLastPage()
    {
      try
      {
        if (this.HasLastPage())
          return this.VcloudClient.GetQueryService().ExecuteQuery<ReferenceResult, ReferencesType, QueryResultRecordType>(this.GetLastPageReference().href);
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultRecordType> GetRecordResult()
    {
      try
      {
        if (this.HasAlternateRecordsRefResult())
          return this.VcloudClient.GetQueryService().ExecuteQuery<RecordResult<QueryResultRecordType>, QueryResultRecordsType, QueryResultRecordType>(this.GetAlternateRecordRef().href);
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultRecordType> GetIdRecordResult()
    {
      try
      {
        if (this.HasAlternateIdRecordsRefResult())
          return this.VcloudClient.GetQueryService().ExecuteQuery<RecordResult<QueryResultRecordType>, QueryResultRecordsType, QueryResultRecordType>(this.GetAlternateIdRecordRef().href);
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }
  }
}
