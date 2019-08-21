// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.utility.Result`1
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;

namespace com.vmware.vcloud.sdk.utility
{
  public abstract class Result<T> : VcloudResource<ContainerType> where T : ContainerType
  {
    private string _name;
    private int _page;
    private int _pageSize;
    private long _total;
    private ReferenceType _nextPage;
    private ReferenceType _lastPage;
    private ReferenceType _previousPage;
    private ReferenceType _firstPage;
    private ReferenceType _alternateReferencesRef;
    private ReferenceType _alternateIdRecordsRef;
    private ReferenceType _alternateRecordsRef;

    internal Result(vCloudClient client, ContainerType containerType)
      : base(client, containerType)
    {
      if (containerType == null)
        return;
      this._name = containerType.name;
      this._page = containerType.page;
      this._pageSize = containerType.pageSize;
      this._total = containerType.total;
      if (containerType.Link == null)
        return;
      foreach (LinkType linkType in containerType.Link)
      {
        if (linkType.rel.Equals("nextPage"))
          this._nextPage = (ReferenceType) linkType;
        if (linkType.rel.Equals("lastPage"))
          this._lastPage = (ReferenceType) linkType;
        if (linkType.rel.Equals("firstPage"))
          this._firstPage = (ReferenceType) linkType;
        if (linkType.rel.Equals("previousPage"))
          this._previousPage = (ReferenceType) linkType;
        if (linkType.rel.Equals("alternate") && linkType.type.Equals("application/vnd.vmware.vcloud.query.references+xml"))
          this._alternateReferencesRef = (ReferenceType) linkType;
        if (linkType.rel.Equals("alternate") && linkType.type.Equals("application/vnd.vmware.vcloud.query.idrecords+xml"))
          this._alternateIdRecordsRef = (ReferenceType) linkType;
        if (linkType.rel.Equals("alternate") && linkType.type.Equals("application/vnd.vmware.vcloud.query.records+xml"))
          this._alternateRecordsRef = (ReferenceType) linkType;
      }
    }

    internal ReferenceType GetNextPageReference()
    {
      return this._nextPage;
    }

    internal ReferenceType GetFirstPageReference()
    {
      return this._firstPage;
    }

    internal ReferenceType GetPreviousPageReference()
    {
      return this._previousPage;
    }

    internal ReferenceType GetLastPageReference()
    {
      return this._lastPage;
    }

    internal ReferenceType GetAlternateRecordRef()
    {
      return this._alternateRecordsRef;
    }

    internal ReferenceType GetAlternateIdRecordRef()
    {
      return this._alternateIdRecordsRef;
    }

    internal ReferenceType GetAlternateReferencesRef()
    {
      return this._alternateReferencesRef;
    }

    public string GetName()
    {
      return this._name;
    }

    public int GetPage()
    {
      return this._page;
    }

    public int GetPageSize()
    {
      return this._pageSize;
    }

    public long GetTotal()
    {
      return this._total;
    }

    public bool HasNextPage()
    {
      return this.GetNextPageReference() != null;
    }

    public bool HasFirstPage()
    {
      return this.GetFirstPageReference() != null;
    }

    public bool HasPreviousPage()
    {
      return this.GetPreviousPageReference() != null;
    }

    public bool HasLastPage()
    {
      return this.GetLastPageReference() != null;
    }

    public bool HasAlternateReferencesRefResult()
    {
      return this.GetAlternateReferencesRef() != null;
    }

    public bool HasAlternateRecordsRefResult()
    {
      return this.GetAlternateRecordRef() != null;
    }

    public bool HasAlternateIdRecordsRefResult()
    {
      return this.GetAlternateIdRecordRef() != null;
    }
  }
}
