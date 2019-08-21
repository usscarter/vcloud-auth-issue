// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.utility.QueryParams`1
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.sdk.constants;
using com.vmware.vcloud.sdk.constants.query;
using System;
using System.Collections.Generic;

namespace com.vmware.vcloud.sdk.utility
{
  public class QueryParams<T> : QueryField
  {
    private Dictionary<T, SortType> _sortFields;
    private List<T> _fields;
    private List<string> metadataFields;
    private int? _page;
    private int? _pageSize;
    private int? _offset;
    private Filter _filter;

    internal List<string> GetMetadataFields()
    {
      if (this.metadataFields == null)
        this.metadataFields = new List<string>();
      return this.metadataFields;
    }

    public void AddMetadataField(string metadataKey, MetadataDomain domain)
    {
      if (metadataKey == null || domain.Value() == null)
        return;
      this.GetMetadataFields().Add("metadata@" + domain.Value() + ":" + metadataKey);
    }

    public void AddMetadataField(string metadataKey)
    {
      if (metadataKey == null)
        return;
      this.GetMetadataFields().Add("metadata:" + metadataKey);
    }

    public int? Offset
    {
      get
      {
        return this._offset;
      }
      set
      {
        this._offset = value;
      }
    }

    public List<T> Fields
    {
      get
      {
        if (this._fields == null)
          this._fields = new List<T>();
        return this._fields;
      }
      set
      {
        this._fields = value;
      }
    }

    public Filter Filter
    {
      get
      {
        return this._filter;
      }
      set
      {
        this._filter = value;
      }
    }

    public Dictionary<T, SortType> SortFields
    {
      get
      {
        if (this._sortFields == null)
          this._sortFields = new Dictionary<T, SortType>();
        return this._sortFields;
      }
      set
      {
        this._sortFields = value;
      }
    }

    public int? Page
    {
      get
      {
        return this._page;
      }
      set
      {
        this._page = value;
      }
    }

    public int? PageSize
    {
      get
      {
        return this._pageSize;
      }
      set
      {
        this._pageSize = value;
      }
    }

    public string Value()
    {
      throw new NotImplementedException();
    }
  }
}
