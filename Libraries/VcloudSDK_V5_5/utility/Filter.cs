// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.utility.Filter
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.sdk.constants.query;
using System.Collections.Generic;
using System.Text;

namespace com.vmware.vcloud.sdk.utility
{
  public class Filter
  {
    private string _filterText = string.Empty;

    public Filter(Expression expression)
    {
      if (expression == null || string.IsNullOrEmpty(expression.GetExpressionText()))
        return;
      this.SetFilterText(new List<Expression>()
      {
        expression
      }, FilterType.NULL);
    }

    public Filter(FilterType filterType, List<Expression> expressions)
    {
      this.SetFilterText(expressions, filterType);
    }

    public Filter(List<Filter> filters, FilterType filterType)
    {
      StringBuilder stringBuilder = new StringBuilder();
      if (filters.Count > 0)
        stringBuilder.Append("(");
      int index = 0;
      if (filters != null)
      {
        foreach (Filter filter in filters)
        {
          if (filters[index].GetFilterText().Length > 0)
          {
            if (index < filters.Count)
            {
              stringBuilder.Append(filters[index].GetFilterText());
              if (filterType.Value() != FilterType.NULL.Value() && index != filters.Count - 1)
                stringBuilder.Append(filterType.Value());
            }
            ++index;
          }
        }
      }
      if (filters.Count > 0)
        stringBuilder.Append(")");
      this._filterText = stringBuilder.ToString();
      if (!this._filterText.Equals("()"))
        return;
      this._filterText = "";
    }

    private void SetFilterText(List<Expression> expressions, FilterType filterType)
    {
      StringBuilder stringBuilder = new StringBuilder();
      if (expressions.Count > 0)
        stringBuilder.Append("(");
      int index = 0;
      if (expressions != null)
      {
        foreach (Expression expression in expressions)
        {
          if (expressions[index].GetExpressionText().Length > 0)
          {
            if (index < expressions.Count)
            {
              stringBuilder.Append(expressions[index].GetExpressionText());
              if (filterType.Value() != FilterType.NULL.Value() && index != expressions.Count - 1 && expressions[index + 1].GetExpressionText().Length > 0)
                stringBuilder.Append(filterType.Value());
            }
            ++index;
          }
        }
      }
      if (expressions.Count > 0)
        stringBuilder.Append(")");
      this._filterText = stringBuilder.ToString();
      if (!this._filterText.Equals("()"))
        return;
      this._filterText = "";
    }

    internal string GetFilterText()
    {
      return this._filterText;
    }
  }
}
