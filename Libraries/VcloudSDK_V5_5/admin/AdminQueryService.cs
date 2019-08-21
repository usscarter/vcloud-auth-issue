// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.AdminQueryService
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.constants.query;
using com.vmware.vcloud.sdk.utility;
using System;

namespace com.vmware.vcloud.sdk.admin
{
  public class AdminQueryService : QueryService
  {
    protected internal AdminQueryService(vCloudClient client)
      : base(client)
    {
    }

    public ReferenceResult QueryGroupReferences()
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultGroupRecordType>(this._client.VCloudApiURL + "/admin/groups/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.REFERENCE_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultGroupRecordType> QueryGroupRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultGroupRecordType>, QueryResultRecordsType, QueryResultGroupRecordType>(this._client.VCloudApiURL + "/admin/groups/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultGroupRecordType> QueryGroupIdRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultGroupRecordType>, QueryResultRecordsType, QueryResultGroupRecordType>(this._client.VCloudApiURL + "/admin/groups/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.ID_RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultGroupRecordType> QueryGroupRecords(
      QueryParams<QueryGroupField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultGroupRecordType>, QueryResultRecordsType, QueryResultGroupRecordType>(this._client.VCloudApiURL + "/admin/groups/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryGroupField>(queryParams)) + this.BuildQuery(FormatType.RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultGroupRecordType> QueryGroupIdRecords(
      QueryParams<QueryGroupField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultGroupRecordType>, QueryResultRecordsType, QueryResultGroupRecordType>(this._client.VCloudApiURL + "/admin/groups/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryGroupField>(queryParams)) + this.BuildQuery(FormatType.ID_RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryGroupReferences(
      QueryParams<QueryGroupField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultGroupRecordType>(this._client.VCloudApiURL + "/admin/groups/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryGroupField>(queryParams)) + this.BuildQuery(FormatType.REFERENCE_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryUserReferences()
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultUserRecordType>(this._client.VCloudApiURL + "/admin/users/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.REFERENCE_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultUserRecordType> QueryUserRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultUserRecordType>, QueryResultRecordsType, QueryResultUserRecordType>(this._client.VCloudApiURL + "/admin/users/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultUserRecordType> QueryUserIdRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultUserRecordType>, QueryResultRecordsType, QueryResultUserRecordType>(this._client.VCloudApiURL + "/admin/users/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.ID_RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultUserRecordType> QueryUserRecords(
      QueryParams<QueryUserField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultUserRecordType>, QueryResultRecordsType, QueryResultUserRecordType>(this._client.VCloudApiURL + "/admin/users/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryUserField>(queryParams)) + this.BuildQuery(FormatType.RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultUserRecordType> QueryUserIdRecords(
      QueryParams<QueryUserField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultUserRecordType>, QueryResultRecordsType, QueryResultUserRecordType>(this._client.VCloudApiURL + "/admin/users/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryUserField>(queryParams)) + this.BuildQuery(FormatType.ID_RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryUserReferences(
      QueryParams<QueryUserField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultUserRecordType>(this._client.VCloudApiURL + "/admin/users/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryUserField>(queryParams)) + this.BuildQuery(FormatType.REFERENCE_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryStrandedUserReferences()
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultStrandedUserRecordType>(this._client.VCloudApiURL + "/admin/strandedUsers/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.REFERENCE_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultStrandedUserRecordType> QueryStrandedUserRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultStrandedUserRecordType>, QueryResultRecordsType, QueryResultStrandedUserRecordType>(this._client.VCloudApiURL + "/admin/strandedUsers/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultStrandedUserRecordType> QueryStrandedUserIdRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultStrandedUserRecordType>, QueryResultRecordsType, QueryResultStrandedUserRecordType>(this._client.VCloudApiURL + "/admin/strandedUsers/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.ID_RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultStrandedUserRecordType> QueryStrandedUserRecords(
      QueryParams<QueryStrandedUserField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultStrandedUserRecordType>, QueryResultRecordsType, QueryResultStrandedUserRecordType>(this._client.VCloudApiURL + "/admin/strandedUsers/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryStrandedUserField>(queryParams)) + this.BuildQuery(FormatType.RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultStrandedUserRecordType> QueryStrandedUserIdRecords(
      QueryParams<QueryStrandedUserField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultStrandedUserRecordType>, QueryResultRecordsType, QueryResultStrandedUserRecordType>(this._client.VCloudApiURL + "/admin/strandedUsers/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryStrandedUserField>(queryParams)) + this.BuildQuery(FormatType.ID_RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryStrandedUserReferences(
      QueryParams<QueryStrandedUserField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultStrandedUserRecordType>(this._client.VCloudApiURL + "/admin/strandedUsers/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryStrandedUserField>(queryParams)) + this.BuildQuery(FormatType.REFERENCE_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryRoleReferences()
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultRoleRecordType>(this._client.VCloudApiURL + "/admin/roles/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.REFERENCE_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultRoleRecordType> QueryRoleRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultRoleRecordType>, QueryResultRecordsType, QueryResultRoleRecordType>(this._client.VCloudApiURL + "/admin/roles/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultRoleRecordType> QueryRoleIdRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultRoleRecordType>, QueryResultRecordsType, QueryResultRoleRecordType>(this._client.VCloudApiURL + "/admin/roles/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.ID_RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultRoleRecordType> QueryRoleRecords(
      QueryParams<QueryRoleField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultRoleRecordType>, QueryResultRecordsType, QueryResultRoleRecordType>(this._client.VCloudApiURL + "/admin/roles/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryRoleField>(queryParams)) + this.BuildQuery(FormatType.RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultRoleRecordType> QueryRoleIdRecords(
      QueryParams<QueryRoleField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultRoleRecordType>, QueryResultRecordsType, QueryResultRoleRecordType>(this._client.VCloudApiURL + "/admin/roles/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryRoleField>(queryParams)) + this.BuildQuery(FormatType.ID_RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryRoleReferences(
      QueryParams<QueryRoleField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultRoleRecordType>(this._client.VCloudApiURL + "/admin/roles/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryRoleField>(queryParams)) + this.BuildQuery(FormatType.REFERENCE_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryRightReferences()
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultRightRecordType>(this._client.VCloudApiURL + "/admin/rights/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.REFERENCE_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultRightRecordType> QueryRightRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultRightRecordType>, QueryResultRecordsType, QueryResultRightRecordType>(this._client.VCloudApiURL + "/admin/rights/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultRightRecordType> QueryRightIdRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultRightRecordType>, QueryResultRecordsType, QueryResultRightRecordType>(this._client.VCloudApiURL + "/admin/rights/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.ID_RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultRightRecordType> QueryRightRecords(
      QueryParams<QueryRightField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultRightRecordType>, QueryResultRecordsType, QueryResultRightRecordType>(this._client.VCloudApiURL + "/admin/rights/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryRightField>(queryParams)) + this.BuildQuery(FormatType.RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultRightRecordType> QueryRightIdRecords(
      QueryParams<QueryRightField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultRightRecordType>, QueryResultRecordsType, QueryResultRightRecordType>(this._client.VCloudApiURL + "/admin/rights/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryRightField>(queryParams)) + this.BuildQuery(FormatType.ID_RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryRightReferences(
      QueryParams<QueryRightField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultRightRecordType>(this._client.VCloudApiURL + "/admin/rights/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryRightField>(queryParams)) + this.BuildQuery(FormatType.REFERENCE_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryOrgReferences()
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultOrgRecordType>(this._client.VCloudApiURL + "/admin/orgs/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.REFERENCE_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultOrgRecordType> QueryOrgRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultOrgRecordType>, QueryResultRecordsType, QueryResultOrgRecordType>(this._client.VCloudApiURL + "/admin/orgs/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultOrgRecordType> QueryOrgIdRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultOrgRecordType>, QueryResultRecordsType, QueryResultOrgRecordType>(this._client.VCloudApiURL + "/admin/orgs/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.ID_RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultOrgRecordType> QueryOrgRecords(
      QueryParams<QueryOrgField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultOrgRecordType>, QueryResultRecordsType, QueryResultOrgRecordType>(this._client.VCloudApiURL + "/admin/orgs/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryOrgField>(queryParams)) + this.BuildQuery(FormatType.RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultOrgRecordType> QueryOrgIdRecords(
      QueryParams<QueryOrgField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultOrgRecordType>, QueryResultRecordsType, QueryResultOrgRecordType>(this._client.VCloudApiURL + "/admin/orgs/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryOrgField>(queryParams)) + this.BuildQuery(FormatType.ID_RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryOrgReferences(QueryParams<QueryOrgField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultOrgRecordType>(this._client.VCloudApiURL + "/admin/orgs/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryOrgField>(queryParams)) + this.BuildQuery(FormatType.REFERENCE_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryOrgVdcReferences()
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultOrgVdcRecordType>(this._client.VCloudApiURL + "/admin/vdcs/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.REFERENCE_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultOrgVdcRecordType> QueryOrgVdcRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultOrgVdcRecordType>, QueryResultRecordsType, QueryResultOrgVdcRecordType>(this._client.VCloudApiURL + "/admin/vdcs/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultOrgVdcRecordType> QueryOrgVdcIdRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultOrgVdcRecordType>, QueryResultRecordsType, QueryResultOrgVdcRecordType>(this._client.VCloudApiURL + "/admin/vdcs/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.ID_RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultOrgVdcRecordType> QueryOrgVdcRecords(
      QueryParams<QueryOrgVdcField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultOrgVdcRecordType>, QueryResultRecordsType, QueryResultOrgVdcRecordType>(this._client.VCloudApiURL + "/admin/vdcs/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryOrgVdcField>(queryParams)) + this.BuildQuery(FormatType.RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultOrgVdcRecordType> QueryOrgVdcIdRecords(
      QueryParams<QueryOrgVdcField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultOrgVdcRecordType>, QueryResultRecordsType, QueryResultOrgVdcRecordType>(this._client.VCloudApiURL + "/admin/vdcs/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryOrgVdcField>(queryParams)) + this.BuildQuery(FormatType.ID_RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryOrgVdcReferences(
      QueryParams<QueryOrgVdcField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultOrgVdcRecordType>(this._client.VCloudApiURL + "/admin/vdcs/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryOrgVdcField>(queryParams)) + this.BuildQuery(FormatType.REFERENCE_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private string ValidateFirstQueryString(string queryString)
    {
      if (queryString != string.Empty && queryString.Substring(0, 1) == "&")
        return queryString.Substring(1);
      return queryString;
    }
  }
}
