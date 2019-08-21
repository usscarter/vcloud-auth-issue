// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.extensions.LicenseReport
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;
using System;
using System.Collections.Generic;

namespace com.vmware.vcloud.sdk.admin.extensions
{
  [Obsolete("This class is obsolete, Deprecated Since SDK Version 5.5")]
  public class LicenseReport : VcloudResource<LicensingReportType>
  {
    private Dictionary<DateTime, LicensingReportSampleType> _samples = new Dictionary<DateTime, LicensingReportSampleType>();

    internal LicenseReport(vCloudClient client, LicensingReportType licensingReportType_v1_5)
      : base(client, licensingReportType_v1_5)
    {
    }

    [Obsolete("This method is obsolete, Deprecated Since SDK Version 5.5")]
    public static LicenseReport GetLicenseReportByReference(
      vCloudClient client,
      ReferenceType referenceType)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + referenceType.href);
        return new LicenseReport(client, VcloudResource<LicensingReportType>.GetResourceByReference(client, referenceType));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Dictionary<DateTime, LicensingReportSampleType> GetSamplesByDate()
    {
      if (this.Resource != null && this.Resource.Sample != null)
      {
        foreach (LicensingReportSampleType reportSampleType in this.Resource.Sample)
          this._samples.Add(reportSampleType.observationDate, reportSampleType);
      }
      return this._samples;
    }

    public DateTime GetReportDate()
    {
      return this.Resource.reportDate;
    }

    public string GetProductSerialNumber()
    {
      return this.Resource.productSerialNumber;
    }
  }
}
