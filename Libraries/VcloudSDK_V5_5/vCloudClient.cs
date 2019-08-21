// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.vCloudClient
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.admin;
using com.vmware.vcloud.sdk.admin.extensions;
using com.vmware.vcloud.sdk.constants.query;
using com.vmware.vcloud.sdk.utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace com.vmware.vcloud.sdk
{
  public class vCloudClient
  {
    private string _vCloudApiURL = string.Empty;
    private string _vCloudTokenHeader = string.Empty;
    private string _vCloudToken = string.Empty;
    private string userName = string.Empty;
    private string orgName = string.Empty;
    private HttpClient _client;
    private Dictionary<string, ReferenceType> _orgRefsByName;
    private Dictionary<string, VersionInfoType> _supportedApiVersions;
    private HttpClientHandler _httpClientHandler;
    public static Dictionary<com.vmware.vcloud.sdk.constants.Version, string> SUPPORTED_SDK_VERSIONS;
    private com.vmware.vcloud.sdk.constants.Version _vcloudClientVersion;

    static vCloudClient()
    {
      if (vCloudClient.SUPPORTED_SDK_VERSIONS != null)
        return;
      vCloudClient.SUPPORTED_SDK_VERSIONS = new Dictionary<com.vmware.vcloud.sdk.constants.Version, string>();
      vCloudClient.SUPPORTED_SDK_VERSIONS.Add(com.vmware.vcloud.sdk.constants.Version.V1_5, "application/*+xml;version=1.5");
      vCloudClient.SUPPORTED_SDK_VERSIONS.Add(com.vmware.vcloud.sdk.constants.Version.V5_1, "application/*+xml;version=5.1");
      vCloudClient.SUPPORTED_SDK_VERSIONS.Add(com.vmware.vcloud.sdk.constants.Version.V5_5, "application/*+xml;version=5.5");
    }

    public vCloudClient(string vCloudUrl, com.vmware.vcloud.sdk.constants.Version version)
    {
      try
      {
        if (!vCloudUrl.EndsWith("/") && !vCloudUrl.EndsWith("\\"))
          vCloudUrl += "/";
        System.Uri uri = new System.Uri(vCloudUrl);
      }
      catch (UriFormatException ex)
      {
        throw new VCloudRuntimeException((Exception) ex);
      }
      this.VCloudApiURL = vCloudUrl + "api";
      this._httpClientHandler = new HttpClientHandler();
      this._client = new HttpClient((HttpMessageHandler) this._httpClientHandler);
      this._vcloudClientVersion = version;
      this._client.Timeout = TimeSpan.FromMilliseconds(-1.0);
    }

    public com.vmware.vcloud.sdk.constants.Version VcloudClientVersion
    {
      get
      {
        return this._vcloudClientVersion;
      }
    }

    public string VCloudApiURL
    {
      get
      {
        return this._vCloudApiURL;
      }
      set
      {
        this._vCloudApiURL = value;
      }
    }

    internal HttpClient HttpClient
    {
      get
      {
        return this._client;
      }
    }

    internal HttpClientHandler HttpClientHandler
    {
      get
      {
        return this._httpClientHandler;
      }
    }

    public string VcloudTokenHeader
    {
      get
      {
        return this._vCloudTokenHeader;
      }
      set
      {
        this._vCloudTokenHeader = value;
      }
    }

    public string VcloudToken
    {
      get
      {
        return this._vCloudToken;
      }
      set
      {
        this._vCloudToken = value;
        this._vCloudTokenHeader = "x-vcloud-authorization";
      }
    }

    public void SetConnectionTimeout(int milliseconds)
    {
      this._client.Timeout = TimeSpan.FromMilliseconds((double) milliseconds);
    }

    public void SetSocketTimeout(int milliseconds)
    {
      this._client.Timeout = TimeSpan.FromMilliseconds((double) milliseconds);
    }

    public Dictionary<string, VersionInfoType> GetSupportedVersions()
    {
      try
      {
        this._supportedApiVersions = new Dictionary<string, VersionInfoType>();
        Response supportedVersions = RestUtil.GetSupportedVersions(this, this.VCloudApiURL + "/versions");
        SupportedVersionsType supportedVersionsType = (SupportedVersionsType) null;
        if (supportedVersions.IsExpected(200))
          supportedVersionsType = supportedVersions.GetResource<SupportedVersionsType>();
        else
          supportedVersions.HandleUnExpectedResponse();
        if (supportedVersionsType != null)
        {
          if (supportedVersionsType.VersionInfo != null)
          {
            foreach (VersionInfoType versionInfoType in supportedVersionsType.VersionInfo)
              this._supportedApiVersions.Add(versionInfoType.Version, versionInfoType);
          }
        }
      }
      catch (Exception ex)
      {
        Logger.Log(TraceLevel.Critical, ex.Message, (object) ex);
        throw new VCloudRuntimeException(ex.Message);
      }
      return this._supportedApiVersions;
    }

    public void SetMaxConnections(int maxConnections)
    {
      ServicePointManager.DefaultConnectionLimit = maxConnections;
      if (maxConnections <= 20)
        return;
      ServicePointManager.FindServicePoint(this._client.BaseAddress).ConnectionLimit = maxConnections;
    }

    public void SetProxy(string proxyHost, int port)
    {
      this._httpClientHandler.Proxy = (IWebProxy) new WebProxy(proxyHost.Trim(), port);
    }

    public void SetProxyCredentials(string userName, string password)
    {
      this._httpClientHandler.Proxy.Credentials = (ICredentials) new NetworkCredential(userName.Trim(), password.Trim());
    }

    public void Login(string userName, string password)
    {
      try
      {
        HttpClient httpClient = this.HttpClient;
        httpClient.DefaultRequestHeaders.Clear();
        httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(userName.Trim() + ":" + password.Trim())));
        HttpRequestHeaders defaultRequestHeaders = httpClient.DefaultRequestHeaders;
        VersionInfoType supportedVersion = this.GetSupportedVersions()[this._vcloudClientVersion.Value()];
        if (supportedVersion == null)
          throw new VCloudException(this._vcloudClientVersion.Value() + " " + SdkUtil.GetI18nString(SdkMessage.VERSION_NOT_SUPPORTED));
        Response response = RestUtil.Login(this, supportedVersion.LoginUrl, defaultRequestHeaders);
        if (!response.IsExpected(200))
          response.HandleUnExpectedResponse();
        SessionType resource = response.GetResource<SessionType>();
        this.setOrgName(resource.org);
        this.setUserName(resource.user);
      }
      catch (Exception ex)
      {
        Logger.Log(TraceLevel.Critical, ex.Message);
        throw ex;
      }
    }

    public void SsoLogin(string samlAssertionXML, string orgName)
    {
      HttpClient httpClient = this.HttpClient;
      httpClient.DefaultRequestHeaders.Clear();
      string str = this.GZipEncodeXmlToString(samlAssertionXML);
      if (orgName.Equals("System", StringComparison.OrdinalIgnoreCase))
        httpClient.DefaultRequestHeaders.Add("Authorization", "SIGN token=\"" + str + "\"");
      else
        httpClient.DefaultRequestHeaders.Add("Authorization", "SIGN token=\"" + str + "\",org=\"" + orgName + "\"");
      httpClient.DefaultRequestHeaders.Add("Accept", vCloudClient.SUPPORTED_SDK_VERSIONS[this.VcloudClientVersion]);
      HttpRequestHeaders defaultRequestHeaders = httpClient.DefaultRequestHeaders;
      VersionInfoType supportedVersion = this.GetSupportedVersions()[this._vcloudClientVersion.Value()];
      if (supportedVersion == null)
        throw new VCloudException(this._vcloudClientVersion.Value() + " " + SdkUtil.GetI18nString(SdkMessage.VERSION_NOT_SUPPORTED));
      Response response = RestUtil.Login(this, supportedVersion.LoginUrl, defaultRequestHeaders);
      if (!response.IsExpected(200))
        response.HandleUnExpectedResponse();
      SessionType resource = response.GetResource<SessionType>();
      this.setOrgName(resource.org);
      this.setUserName(resource.user);
    }

    public void SsoLogin(
      string samlAssertionXML,
      string orgName,
      string signature,
      string signAlgo)
    {
      HttpClient httpClient = this.HttpClient;
      httpClient.DefaultRequestHeaders.Clear();
      string str = this.GZipEncodeXmlToString(samlAssertionXML);
      if (orgName.Equals("System", StringComparison.OrdinalIgnoreCase))
        httpClient.DefaultRequestHeaders.Add("Authorization", "SIGN token=\"" + str + "\",signature=\"" + signature + "\",signature_alg=\"" + signAlgo + "\"");
      else
        httpClient.DefaultRequestHeaders.Add("Authorization", "SIGN token=\"" + str + "\",org=\"" + orgName + "\",signature=\"" + signature + "\",signature_alg=\"" + signAlgo + "\"");
      httpClient.DefaultRequestHeaders.Add("Accept", vCloudClient.SUPPORTED_SDK_VERSIONS[this.VcloudClientVersion]);
      HttpRequestHeaders defaultRequestHeaders = httpClient.DefaultRequestHeaders;
      VersionInfoType supportedVersion = this.GetSupportedVersions()[this._vcloudClientVersion.Value()];
      if (supportedVersion == null)
        throw new VCloudException(this._vcloudClientVersion.Value() + " " + SdkUtil.GetI18nString(SdkMessage.VERSION_NOT_SUPPORTED));
      Response response = RestUtil.Login(this, supportedVersion.LoginUrl, defaultRequestHeaders);
      if (!response.IsExpected(200))
        response.HandleUnExpectedResponse();
      SessionType resource = response.GetResource<SessionType>();
      this.setOrgName(resource.org);
      this.setUserName(resource.user);
    }

    private string GZipEncodeXmlToString(string samlAssertionXML)
    {
      MemoryStream memoryStream1;
      byte[] array;
      using (memoryStream1 = new MemoryStream())
      {
        using (GZipStream gzipStream = new GZipStream((Stream) memoryStream1, CompressionMode.Compress))
        {
          using (MemoryStream memoryStream2 = new MemoryStream(Encoding.UTF8.GetBytes(samlAssertionXML)))
            memoryStream2.WriteTo((Stream) gzipStream);
        }
        array = memoryStream1.ToArray();
      }
      return Convert.ToBase64String(array).Replace(Environment.NewLine, "");
    }

    public void Logout()
    {
      try
      {
        SdkUtil.Delete<TaskType>(this, this.VCloudApiURL + "/session", 204);
        this._vCloudTokenHeader = (string) null;
        this._vCloudToken = (string) null;
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.LOGOUT_INFO_MSG));
      }
      catch (Exception ex)
      {
        Logger.Log(TraceLevel.Critical, ex.Message);
        throw new VCloudException(ex.Message);
      }
    }

    public Dictionary<string, ReferenceType> GetOrgRefsByName()
    {
      try
      {
        return this._orgRefsByName == null ? this.GetOrgReferences() : this._orgRefsByName;
      }
      catch (Exception ex)
      {
        Logger.Log(TraceLevel.Critical, ex.Message);
        throw new VCloudException(ex.Message);
      }
    }

    public Dictionary<string, ReferenceType> GetUpdatedOrgList()
    {
      try
      {
        return this.GetOrgReferences();
      }
      catch (Exception ex)
      {
        Logger.Log(TraceLevel.Critical, ex.Message);
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType GetOrgRefByName(string orgName)
    {
      try
      {
        return this._orgRefsByName == null ? this.GetOrgReferences()[orgName] : this._orgRefsByName[orgName];
      }
      catch (Exception ex)
      {
        Logger.Log(TraceLevel.Critical, ex.Message);
        throw new VCloudException(ex.Message);
      }
    }

    public List<ReferenceType> GetOrgRefs()
    {
      try
      {
        return this._orgRefsByName == null ? this.GetOrgReferences().Values.ToList<ReferenceType>() : this._orgRefsByName.Values.ToList<ReferenceType>();
      }
      catch (Exception ex)
      {
        Logger.Log(TraceLevel.Critical, ex.Message);
        throw new VCloudException(ex.Message);
      }
    }

    private Dictionary<string, ReferenceType> GetOrgReferences()
    {
      try
      {
        string str = this.VCloudApiURL + "/org/";
        Logger.Log(TraceLevel.Information, str);
        OrgListType orgListType = SdkUtil.Get<OrgListType>(this, str, 200);
        this._orgRefsByName = new Dictionary<string, ReferenceType>();
        if (orgListType == null || orgListType.Org == null)
          Logger.Log(TraceLevel.Warning, SdkUtil.GetI18nString(SdkMessage.ORGS_EMPTY_INFO_MSG));
        foreach (ReferenceType referenceType in orgListType.Org)
          this._orgRefsByName.Add(referenceType.name, referenceType);
        return this._orgRefsByName;
      }
      catch (Exception ex)
      {
        Logger.Log(TraceLevel.Critical, ex.Message);
        throw new VCloudException(ex.Message);
      }
    }

    public VcloudAdmin GetVcloudAdmin()
    {
      try
      {
        return new VcloudAdmin(this);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VcloudAdminExtension GetVcloudAdminExtension()
    {
      try
      {
        return new VcloudAdminExtension(this);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public QueryService GetQueryService()
    {
      return new QueryService(this);
    }

    public string GetUserName()
    {
      return this.userName;
    }

    public string GetOrgName()
    {
      return this.orgName;
    }

    public bool ExtendSession()
    {
      try
      {
        SdkUtil.Get<SessionType>(this, this.VCloudApiURL + "/session", 200);
        Logger.Log(TraceLevel.Information, this.VCloudApiURL + "/session");
      }
      catch (VCloudException ex)
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.SESSION_EXTENSION_FAILED));
        return false;
      }
      return true;
    }

    public Dictionary<string, OperatingSystemFamilyInfoType> GetOperatingSystemFamiliesByName()
    {
      try
      {
        Dictionary<string, OperatingSystemFamilyInfoType> dictionary = new Dictionary<string, OperatingSystemFamilyInfoType>();
        foreach (OperatingSystemFamilyInfoType systemFamilyInfoType in SdkUtil.Get<SupportedOperatingSystemsInfoType>(this, this.VCloudApiURL + "/supportedSystemsInfo", 200).OperatingSystemFamilyInfo)
          dictionary.Add(systemFamilyInfoType.Name, systemFamilyInfoType);
        return dictionary;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Dictionary<string, OperatingSystemInfoType> GetOperatingSystemsByName()
    {
      Dictionary<string, OperatingSystemInfoType> dictionary = new Dictionary<string, OperatingSystemInfoType>();
      foreach (OperatingSystemFamilyInfoType systemFamilyInfoType in SdkUtil.Get<SupportedOperatingSystemsInfoType>(this, this.VCloudApiURL + "/supportedSystemsInfo", 200).OperatingSystemFamilyInfo)
      {
        foreach (OperatingSystemInfoType operatingSystemInfoType in systemFamilyInfoType.OperatingSystem)
          dictionary.Add(operatingSystemInfoType.Name, operatingSystemInfoType);
      }
      return dictionary;
    }

    public ReferenceResult GetServiceRefs()
    {
      try
      {
        return this.GetQueryService().ExecuteQuery<ReferenceResult, ReferencesType, QueryResultServiceRecordType>(this.VCloudApiURL + "/service?" + this.GetQueryService().BuildQuery(FormatType.REFERENCE_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultFileDescriptorRecordType> GetFileDescriptorRecords()
    {
      try
      {
        return this.GetQueryService().ExecuteQuery<RecordResult<QueryResultFileDescriptorRecordType>, QueryResultRecordsType, QueryResultFileDescriptorRecordType>(this.VCloudApiURL + "/files?" + this.GetQueryService().BuildQuery(FormatType.RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Stream GetSchemaDefinition(string schemaFileName)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_SCHEMA_DEFINITION) + " - " + schemaFileName);
        return RestUtil.DownloadFile(this, this.VCloudApiURL + "/v1.5/schema/" + schemaFileName);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void setUserName(string userName)
    {
      this.userName = userName;
    }

    private void setOrgName(string orgName)
    {
      this.orgName = orgName;
    }
  }
}
