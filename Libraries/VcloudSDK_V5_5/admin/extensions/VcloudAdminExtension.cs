// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.extensions.VcloudAdminExtension
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.admin.extensions.service;
using com.vmware.vcloud.sdk.constants.query;
using com.vmware.vcloud.sdk.utility;
using System;
using System.Collections.Generic;
using System.IO;

namespace com.vmware.vcloud.sdk.admin.extensions
{
  public class VcloudAdminExtension : IDisposable
  {
    private VMWExtensionType _vmwExtensionResource_v1_5;
    private vCloudClient _client;

    public VcloudAdminExtension(vCloudClient client)
    {
      try
      {
        this._client = client;
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + client.VCloudApiURL + "/admin/extension");
        this._vmwExtensionResource_v1_5 = SdkUtil.Get<VMWExtensionType>(client, client.VCloudApiURL + "/admin/extension", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VcloudAdminExtensionSettings GetVcloudAdminExtensionSettings()
    {
      try
      {
        return new VcloudAdminExtensionSettings(this._client);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ExtensionQueryService GetExtensionQueryService()
    {
      return new ExtensionQueryService(this._client);
    }

    public VMWExtensionType GetResource()
    {
      return this._vmwExtensionResource_v1_5;
    }

    public Dictionary<string, ReferenceType> GetVMWProviderVdcRefsByName()
    {
      try
      {
        Dictionary<string, ReferenceType> dictionary = new Dictionary<string, ReferenceType>();
        string url = this._client.VCloudApiURL + "/admin/extension/providerVdcReferences";
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + url);
        VMWProviderVdcReferencesType vdcReferencesType = SdkUtil.Get<VMWProviderVdcReferencesType>(this._client, url, 200);
        if (vdcReferencesType.ProviderVdcReference != null)
        {
          foreach (ReferenceType referenceType in vdcReferencesType.ProviderVdcReference)
            dictionary.Add(referenceType.name, referenceType);
        }
        return dictionary;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Dictionary<string, ReferenceType> GetVMWExternalNetworkRefsByName()
    {
      try
      {
        Dictionary<string, ReferenceType> dictionary = new Dictionary<string, ReferenceType>();
        string url = this._client.VCloudApiURL + "/admin/extension/externalNetworkReferences";
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + url);
        VMWExternalNetworkReferencesType networkReferencesType = SdkUtil.Get<VMWExternalNetworkReferencesType>(this._client, url, 200);
        if (networkReferencesType.ExternalNetworkReference != null)
        {
          foreach (ReferenceType referenceType in networkReferencesType.ExternalNetworkReference)
            dictionary.Add(referenceType.name, referenceType);
        }
        return dictionary;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Dictionary<string, ReferenceType> GetVMWNetworkPoolRefsByName()
    {
      try
      {
        Dictionary<string, ReferenceType> dictionary = new Dictionary<string, ReferenceType>();
        string url = this._client.VCloudApiURL + "/admin/extension/networkPoolReferences";
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + url);
        VMWNetworkPoolReferencesType poolReferencesType = SdkUtil.Get<VMWNetworkPoolReferencesType>(this._client, url, 200);
        if (poolReferencesType.NetworkPoolReference != null)
        {
          foreach (ReferenceType referenceType in poolReferencesType.NetworkPoolReference)
            dictionary.Add(referenceType.name, referenceType);
        }
        return dictionary;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Dictionary<string, ReferenceType> GetVMWVimServerRefsByName()
    {
      try
      {
        Dictionary<string, ReferenceType> dictionary = new Dictionary<string, ReferenceType>();
        string url = this._client.VCloudApiURL + "/admin/extension/vimServerReferences";
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + url);
        VMWVimServerReferencesType serverReferencesType = SdkUtil.Get<VMWVimServerReferencesType>(this._client, url, 200);
        if (serverReferencesType.VimServerReference != null)
        {
          foreach (ReferenceType referenceType in serverReferencesType.VimServerReference)
            dictionary.Add(referenceType.name, referenceType);
        }
        return dictionary;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Dictionary<string, ReferenceType> GetVMWHostRefsByName()
    {
      try
      {
        Dictionary<string, ReferenceType> dictionary = new Dictionary<string, ReferenceType>();
        string url = this._client.VCloudApiURL + "/admin/extension/hostReferences";
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + url);
        VMWHostReferencesType hostReferencesType = SdkUtil.Get<VMWHostReferencesType>(this._client, url, 200);
        if (hostReferencesType.HostReference != null)
        {
          foreach (ReferenceType referenceType in hostReferencesType.HostReference)
            dictionary.Add(referenceType.name, referenceType);
        }
        return dictionary;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public List<ReferenceType> GetVMWDatastoreRefs()
    {
      try
      {
        List<ReferenceType> referenceTypeList = new List<ReferenceType>();
        string url = this._client.VCloudApiURL + "/admin/extension/datastores";
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + url);
        ReferencesType referencesType = (ReferencesType) SdkUtil.Get<DatastoreReferencesType>(this._client, url, 200);
        if (referencesType.Reference != null)
        {
          foreach (ReferenceType referenceType in referencesType.Reference)
            referenceTypeList.Add(referenceType);
        }
        return referenceTypeList;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    [Obsolete("This method is obsolete, Deprecated Since SDK Version 5.5")]
    public List<ReferenceType> GetLicensingReportRefs()
    {
      try
      {
        List<ReferenceType> referenceTypeList = new List<ReferenceType>();
        string url = this._client.VCloudApiURL + "/admin/extension/licensing/reports";
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + url);
        LicensingReportListType licensingReportListType = SdkUtil.Get<LicensingReportListType>(this._client, url, 200);
        if (licensingReportListType.Report != null)
        {
          foreach (ReferenceType referenceType in licensingReportListType.Report)
            referenceTypeList.Add(referenceType);
        }
        return referenceTypeList;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RegisterVimServerParamsType RegisterVMWVimServer(
      RegisterVimServerParamsType registerVimServerParamsType)
    {
      try
      {
        string url = this._client.VCloudApiURL + "/admin/extension/action/registervimserver";
        string requestString = SerializationUtil.SerializeObject<RegisterVimServerParamsType>(registerVimServerParamsType, "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + url);
        return SdkUtil.Post<RegisterVimServerParamsType>(this._client, url, requestString, "application/vnd.vmware.admin.registerVimServerParams+xml", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    [Obsolete("This method is obsolete; Use method CreateVMWProviderVdc with VMWProviderVdcParamsType params instead ")]
    public VMWProviderVdc CreateVMWProviderVdc(VMWProviderVdcType vmwProviderVdcType)
    {
      try
      {
        string url = this._client.VCloudApiURL + "/admin/extension/providervdcs";
        string requestString = SerializationUtil.SerializeObject<VMWProviderVdcType>(vmwProviderVdcType, "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.POST_URL_MSG) + " - " + url);
        return new VMWProviderVdc(this._client, SdkUtil.Post<VMWProviderVdcType>(this._client, url, requestString, "application/vnd.vmware.admin.vmwprovidervdc+xml", 201));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VMWProviderVdc CreateVMWProviderVdc(
      VMWProviderVdcParamsType vmwProviderVdcParams)
    {
      try
      {
        string url = this._client.VCloudApiURL + "/admin/extension/providervdcsparams";
        string requestString = SerializationUtil.SerializeObject<VMWProviderVdcParamsType>(vmwProviderVdcParams, "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.POST_URL_MSG) + " - " + url);
        return new VMWProviderVdc(this._client, SdkUtil.Post<VMWProviderVdcType>(this._client, url, requestString, "application/vnd.vmware.admin.createProviderVdcParams+xml", 201));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VMWExternalNetwork CreateVMWExternalNetwork(
      VMWExternalNetworkType vmwExternalNetworkType)
    {
      try
      {
        string url = this._client.VCloudApiURL + "/admin/extension/externalnets";
        string requestString = SerializationUtil.SerializeObject<VMWExternalNetworkType>(vmwExternalNetworkType, "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.POST_URL_MSG) + " - " + url);
        return new VMWExternalNetwork(this._client, SdkUtil.Post<VMWExternalNetworkType>(this._client, url, requestString, "application/vnd.vmware.admin.vmwexternalnet+xml", 201));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VMWNetworkPool CreateVMWNetworkPool(VMWNetworkPoolType vmwNetworkPoolType)
    {
      try
      {
        string url = this._client.VCloudApiURL + "/admin/extension/networkPools";
        string requestString = SerializationUtil.SerializeObject<VMWNetworkPoolType>(vmwNetworkPoolType, "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.POST_URL_MSG) + " - " + url);
        return new VMWNetworkPool(this._client, SdkUtil.Post<VMWNetworkPoolType>(this._client, url, requestString, "application/vnd.vmware.admin.networkPool+xml", 201));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public List<ReferenceType> GetBlockingTaskRefs()
    {
      try
      {
        List<ReferenceType> referenceTypeList = new List<ReferenceType>();
        string url = this._client.VCloudApiURL + "/admin/extension/blockingTasks";
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.POST_URL_MSG) + " - " + url);
        ReferencesType referencesType = (ReferencesType) SdkUtil.Get<BlockingTaskReferencesType>(this._client, url, 200);
        if (referencesType.Reference != null)
        {
          foreach (ReferenceType referenceType in referencesType.Reference)
            referenceTypeList.Add(referenceType);
        }
        return referenceTypeList;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult GetStrandedItemRefs()
    {
      try
      {
        return this._client.GetQueryService().ExecuteQuery<ReferenceResult, ReferencesType, QueryResultStrandedItemRecordType>(this._client.VCloudApiURL + "/admin/extension/strandedItems/query?" + this._client.GetQueryService().BuildQuery(FormatType.REFERENCE_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult GetAdminServiceRefs()
    {
      try
      {
        return this._client.GetQueryService().ExecuteQuery<ReferenceResult, ReferencesType, QueryResultAdminServiceRecordType>(this._client.VCloudApiURL + "/admin/extension/service/query?" + this._client.GetQueryService().BuildQuery(FormatType.REFERENCE_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public AdminService CreateService(AdminServiceType serviceParams)
    {
      try
      {
        return new AdminService(this._client, SdkUtil.Post<AdminServiceType>(this._client, this._client.VCloudApiURL + "/admin/extension/service", SerializationUtil.SerializeObject<AdminServiceType>(serviceParams, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.service+xml", 201));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void ClearUnusedRights()
    {
      try
      {
        SdkUtil.Post<RightType>(this._client, this._client.VCloudApiURL + "/admin/extension/service/action/clearunusedrights", (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void ClearUnusedLocalizationBundles()
    {
      try
      {
        SdkUtil.Post<BundleUploadSocketType>(this._client, this._client.VCloudApiURL + "/admin/extension/service/action/clearunusedlocalizationbundles", (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void UploadLocalizationBundle(
      BundleUploadParamsType bundleUploadParamsType,
      Stream inputStream)
    {
      try
      {
        string uploadLocation = SdkUtil.Post<BundleUploadSocketType>(this._client, this._client.VCloudApiURL + "/admin/extension/servicelocalizationbundles", SerializationUtil.SerializeObject<BundleUploadParamsType>(bundleUploadParamsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.bundleUploadParams+xml", 200).uploadLocation;
        FileType file = new FileType();
        file.name = uploadLocation;
        LinkType linkType = new LinkType();
        linkType.href = uploadLocation;
        linkType.rel = "upload:default";
        file.Link = new LinkType[1]{ linkType };
        RestUtil.UploadFile(this._client, file, inputStream, bundleUploadParamsType.fileSize, 0L, 0L);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void UploadLocalizationBundle(string localFileLocation, string serviceNamespace)
    {
      try
      {
        FileStream fileStream = File.OpenRead(localFileLocation);
        this.UploadLocalizationBundle(new BundleUploadParamsType()
        {
          fileSize = fileStream.Length,
          serviceNamespace = serviceNamespace
        }, (Stream) fileStream);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public bool IsAuthorized(
      AuthorizationCheckParamsType authorizationCheckParamsType)
    {
      try
      {
        return SdkUtil.Post<AuthorizationCheckResponseType>(this._client, this._client.VCloudApiURL + "/admin/extension/service/authorizationcheck", SerializationUtil.SerializeObject<AuthorizationCheckParamsType>(authorizationCheckParamsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.authorizationCheckParams+xml", 200).IsAuthorized;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public AdminService GetAdminServiceByName(string serviceName)
    {
      foreach (ReferenceType reference in this.GetAdminServiceRefs().GetReferences())
      {
        if (reference.name.Equals(serviceName))
          return AdminService.GetAdminServiceByReference(this._client, reference);
      }
      throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.SERVICE_NOT_FOUND) + " - " + serviceName);
    }

    public bool IsServiceAlreadyRegistered(string serviceName)
    {
      try
      {
        this.GetAdminServiceByName(serviceName);
        return true;
      }
      catch (VCloudException ex)
      {
        return false;
      }
    }

    public AdminService CreateService(
      string serviceName,
      string serviceNamespace,
      string serviceExchange,
      string serviceRoutingKey,
      int servicePriority,
      bool serviceAuthorizationEnabled)
    {
      try
      {
        AdminServiceType serviceParams = new AdminServiceType();
        serviceParams.name = serviceName;
        serviceParams.Namespace = serviceNamespace;
        serviceParams.Exchange = serviceExchange;
        serviceParams.RoutingKey = serviceRoutingKey;
        serviceParams.Enabled = true;
        serviceParams.EnabledSpecified = true;
        serviceParams.AuthorizationEnabled = serviceAuthorizationEnabled;
        serviceParams.AuthorizationEnabledSpecified = true;
        serviceParams.Priority = servicePriority;
        serviceParams.PrioritySpecified = true;
        return this.CreateService(serviceParams);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    protected void Dispose(bool disposing)
    {
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }
  }
}
