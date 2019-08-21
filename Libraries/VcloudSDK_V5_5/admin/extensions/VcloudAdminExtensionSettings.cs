// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.extensions.VcloudAdminExtensionSettings
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.constants;
using com.vmware.vcloud.sdk.utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace com.vmware.vcloud.sdk.admin.extensions
{
  public class VcloudAdminExtensionSettings
  {
    private List<BlockingTaskOperationType> _enabledBlockingTaskOperations = new List<BlockingTaskOperationType>();
    private SystemSettingsType _vcloudSystemSettings;
    private vCloudClient _client;

    internal VcloudAdminExtensionSettings(vCloudClient vcloudClient)
    {
      try
      {
        this._client = vcloudClient;
        this._vcloudSystemSettings = SdkUtil.Get<SystemSettingsType>(this._client, this._client.VCloudApiURL + "/admin/extension/settings", 200);
        this.Sort_v1_5();
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public SystemSettingsType GetResource()
    {
      return this._vcloudSystemSettings;
    }

    public SystemSettingsType GetSystemSettings()
    {
      return this._vcloudSystemSettings;
    }

    public SystemSettingsType UpdateSystemSettings(
      SystemSettingsType systemSettingsType)
    {
      try
      {
        return SdkUtil.Put<SystemSettingsType>(this._client, this._client.VCloudApiURL + "/admin/extension/settings", SerializationUtil.SerializeObject<SystemSettingsType>(systemSettingsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.systemSettings+xml", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public GeneralSettingsType GetGeneralSettings()
    {
      return this.GetSystemSettings().GeneralSettings;
    }

    public static GeneralSettingsType GetGeneralSettings(vCloudClient client)
    {
      try
      {
        string url = client.VCloudApiURL + "/admin/extension/settings/general";
        return SdkUtil.Get<GeneralSettingsType>(client, url, 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public KerberosSettingsType GetKerberosSettings()
    {
      try
      {
        return this.GetSystemSettings().KerberosSettings;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static KerberosSettingsType GetKerberosSettings(vCloudClient client)
    {
      try
      {
        string url = client.VCloudApiURL + "/admin/extension/settings/kerberosSettings";
        return SdkUtil.Get<KerberosSettingsType>(client, url, 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public GeneralSettingsType UpdateGeneralSettings(
      GeneralSettingsType generalSettingsType)
    {
      try
      {
        return SdkUtil.Put<GeneralSettingsType>(this._client, this._client.VCloudApiURL + "/admin/extension/settings/general", SerializationUtil.SerializeObject<GeneralSettingsType>(generalSettingsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.generalSettings+xml", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public KerberosSettingsType UpdateKerberosSettings(
      KerberosSettingsType kerberosSettingsType)
    {
      try
      {
        return SdkUtil.Put<KerberosSettingsType>(this._client, this._client.VCloudApiURL + "/admin/extension/settings/kerberosSettings", SerializationUtil.SerializeObject<KerberosSettingsType>(kerberosSettingsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.kerberosSettings+xml", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public BrandingSettingsType GetBrandingSettings()
    {
      try
      {
        return this.GetResource().BrandingSettings;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static BrandingSettingsType GetBrandingSettings(vCloudClient client)
    {
      try
      {
        string url = client.VCloudApiURL + "/admin/extension/settings/branding";
        return SdkUtil.Get<BrandingSettingsType>(client, url, 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public BrandingSettingsType UpdateBrandingSettings(
      BrandingSettingsType brandingSettingsType)
    {
      try
      {
        return SdkUtil.Put<BrandingSettingsType>(this._client, this._client.VCloudApiURL + "/admin/extension/settings/branding", SerializationUtil.SerializeObject<BrandingSettingsType>(brandingSettingsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.brandingSettings+xml", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public EmailSettingsType GetEmailSettings()
    {
      try
      {
        return this.GetResource().EmailSettings;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static EmailSettingsType GetEmailSettings(vCloudClient client)
    {
      try
      {
        string url = client.VCloudApiURL + "/admin/extension/settings/email";
        return SdkUtil.Get<EmailSettingsType>(client, url, 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public EmailSettingsType UpdateEmailSettings(
      EmailSettingsType emailSettingsType)
    {
      try
      {
        return SdkUtil.Put<EmailSettingsType>(this._client, this._client.VCloudApiURL + "/admin/extension/settings/email", SerializationUtil.SerializeObject<EmailSettingsType>(emailSettingsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.emailSettings+xml", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public LicenseType GetLicenseSettings()
    {
      try
      {
        return this.GetResource().License;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static LicenseType GetLicenseSettings(vCloudClient client)
    {
      try
      {
        string url = client.VCloudApiURL + "/admin/extension/settings/license";
        return SdkUtil.Get<LicenseType>(client, url, 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public LicenseType UpdateLicenseSettings(LicenseType licenseType)
    {
      try
      {
        return SdkUtil.Put<LicenseType>(this._client, this._client.VCloudApiURL + "/admin/extension/settings/license", SerializationUtil.SerializeObject<LicenseType>(licenseType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.licenseSettings+xml", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public LicenseMetricsInfoType GetLicenseMetricsInfo()
    {
      try
      {
        return this.GetResource().License.LicenseMetricsInfo;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public SmtpSettingsType GetEmailSmtpSettings()
    {
      try
      {
        return this.GetEmailSettings().SmtpSettings;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public bool IsNotificationsEnabled()
    {
      return this.GetSystemSettings().NotificationsSettings.EnableNotifications;
    }

    public static bool IsNotificationsEnabled(vCloudClient client)
    {
      try
      {
        string url = client.VCloudApiURL + "/admin/extension/settings/notifications";
        return SdkUtil.Get<NotificationsSettingsType>(client, url, 200).EnableNotifications;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void SetEnableNotifications(bool enableNotificationsSetting)
    {
      try
      {
        SdkUtil.Put<NotificationsSettingsType>(this._client, this._client.VCloudApiURL + "/admin/extension/settings/notifications", SerializationUtil.SerializeObject<NotificationsSettingsType>(new NotificationsSettingsType()
        {
          EnableNotifications = enableNotificationsSetting
        }, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.notificationsSettings+xml", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public AmqpSettingsType GetAmqpSettings()
    {
      return this.GetSystemSettings().AmqpSettings;
    }

    public static AmqpSettingsType GetAmqpSettings(vCloudClient client)
    {
      string url = client.VCloudApiURL + "/admin/extension/settings/amqp";
      return SdkUtil.Get<AmqpSettingsType>(client, url, 200);
    }

    public AmqpSettingsType UpdateAmqpSettings(AmqpSettingsType amqpSettingsType)
    {
      try
      {
        return SdkUtil.Put<AmqpSettingsType>(this._client, this._client.VCloudApiURL + "/admin/extension/settings/amqp", SerializationUtil.SerializeObject<AmqpSettingsType>(amqpSettingsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.amqpSettings+xml", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    [Obsolete("This method is deprecated  since API 5.1, SDK 5.1")]
    public LdapSettingsType GetLdapSettings()
    {
      return this.GetSystemSettings().LdapSettings;
    }

    [Obsolete("This method is deprecated  since API 5.1, SDK 5.1")]
    public static LdapSettingsType GetLdapSettings(vCloudClient client)
    {
      try
      {
        string url = client.VCloudApiURL + "/admin/extension/settings/ldapSettings";
        return SdkUtil.Get<LdapSettingsType>(client, url, 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    [Obsolete("This method is deprecated  since API 5.1, SDK 5.1")]
    public LdapSettingsType UpdateLdapSettings(LdapSettingsType ldapSettingsType)
    {
      try
      {
        return SdkUtil.Put<LdapSettingsType>(this._client, this._client.VCloudApiURL + "/admin/extension/settings/ldapSettings", SerializationUtil.SerializeObject<LdapSettingsType>(ldapSettingsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.ldapSettings+xml", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    [Obsolete("This method is deprecated  since API 5.1, SDK 5.1")]
    public LdapUserAttributesType GetLdapUserSettings()
    {
      return this.GetSystemSettings().LdapSettings.UserAttributes;
    }

    [Obsolete("This method is deprecated  since API 5.1, SDK 5.1")]
    public LdapGroupAttributesType GetLdapGroupSettings()
    {
      return this.GetSystemSettings().LdapSettings.GroupAttributes;
    }

    public bool TestAmqpConnection()
    {
      try
      {
        return SdkUtil.Post<AmqpSettingsTestType>(this._client, this._client.VCloudApiURL + "/admin/extension/settings/amqp/action/test", SerializationUtil.SerializeObject<AmqpSettingsType>(this.GetAmqpSettings(), "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.amqpSettings+xml", 200).Valid;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static bool TestAmqpConnection(vCloudClient client, AmqpSettingsType amqpSettings)
    {
      try
      {
        string url = client.VCloudApiURL + "/admin/extension/settings/amqp/action/test";
        string requestString = SerializationUtil.SerializeObject<AmqpSettingsType>(amqpSettings, "com.vmware.vcloud.api.rest.schema");
        return SdkUtil.Post<AmqpSettingsTestType>(client, url, requestString, "application/vnd.vmware.admin.amqpSettings+xml", 200).Valid;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public SystemPasswordPolicySettingsType GetPasswordPolicySettings()
    {
      return this.GetSystemSettings().PasswordPolicySettings;
    }

    public static SystemPasswordPolicySettingsType GetPasswordPolicySettings(
      vCloudClient client)
    {
      try
      {
        string url = client.VCloudApiURL + "/admin/extension/settings/passwordPolicy";
        return SdkUtil.Get<SystemPasswordPolicySettingsType>(client, url, 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public SystemPasswordPolicySettingsType UpdatePasswordPolicySettings(
      SystemPasswordPolicySettingsType passwordPolicySettingsType)
    {
      try
      {
        return SdkUtil.Put<SystemPasswordPolicySettingsType>(this._client, this._client.VCloudApiURL + "/admin/extension/settings/passwordPolicy", SerializationUtil.SerializeObject<SystemPasswordPolicySettingsType>(passwordPolicySettingsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.systemPasswordPolicySettings+xml", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public BlockingTaskSettingsType GetBlockingTaskSettings()
    {
      return this.GetSystemSettings().BlockingTaskSettings;
    }

    public static BlockingTaskSettingsType GetBlockingTaskSettings(
      vCloudClient client)
    {
      try
      {
        string url = client.VCloudApiURL + "/admin/extension/settings/blockingTask";
        return SdkUtil.Get<BlockingTaskSettingsType>(client, url, 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public BlockingTaskSettingsType UpdateBlockingTaskSettings(
      BlockingTaskSettingsType extensionSettingsType)
    {
      try
      {
        return SdkUtil.Put<BlockingTaskSettingsType>(this._client, this._client.VCloudApiURL + "/admin/extension/settings/blockingTask", SerializationUtil.SerializeObject<BlockingTaskSettingsType>(extensionSettingsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.extensionSettings+xml", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public List<BlockingTaskOperationType> GetEnabledBlockingTaskOperations()
    {
      return this._enabledBlockingTaskOperations;
    }

    public static List<BlockingTaskOperationType> GetEnabledBlockingTaskOperations(
      vCloudClient client)
    {
      try
      {
        string url = client.VCloudApiURL + "/admin/extension/settings/blockingTask/operations";
        TaskOperationListType operationListType = SdkUtil.Get<TaskOperationListType>(client, url, 200);
        List<string> values = new List<string>();
        if (operationListType.Operation != null)
          values = ((IEnumerable<string>) operationListType.Operation).ToList<string>();
        return BlockingTaskOperationType.FromValues(values);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public List<BlockingTaskOperationType> UpdateEnabledBlockingTaskOperations(
      List<BlockingTaskOperationType> enabledBlockingTaskOperations)
    {
      try
      {
        string url = this._client.VCloudApiURL + "/admin/extension/settings/blockingTask/operations";
        TaskOperationListType operationListType1 = new TaskOperationListType();
        List<string> stringList = new List<string>();
        stringList.AddRange((IEnumerable<string>) BlockingTaskOperationType.ToValues(enabledBlockingTaskOperations));
        operationListType1.Operation = stringList.ToArray();
        string requestString = SerializationUtil.SerializeObject<TaskOperationListType>(operationListType1, "com.vmware.vcloud.api.rest.schema");
        TaskOperationListType operationListType2 = SdkUtil.Put<TaskOperationListType>(this._client, url, requestString, "application/vnd.vmware.admin.taskOperationList+xml", 200);
        List<string> values = new List<string>();
        if (operationListType2.Operation != null)
          values = ((IEnumerable<string>) operationListType2.Operation).ToList<string>();
        return BlockingTaskOperationType.FromValues(values);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public LookupServiceSettingsType GetLookupService()
    {
      try
      {
        return this.GetResource().LookupServiceSettings;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static LookupServiceSettingsType GetLookupService(
      vCloudClient client)
    {
      try
      {
        string url = client.VCloudApiURL + "/admin/extension/settings/lookupService";
        return SdkUtil.Get<LookupServiceSettingsType>(client, url, 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    [Obsolete("This method is deprecated  since API 5.1, SDK 5.1")]
    public Task UpdateLookupService(LookupServiceParamsType lookupServiceParams)
    {
      try
      {
        return new Task(this._client, SdkUtil.Put<TaskType>(this._client, this._client.VCloudApiURL + "/admin/extension/settings/lookupService", SerializationUtil.SerializeObject<LookupServiceParamsType>(lookupServiceParams, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.lookupServiceParams+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void ResetAmqpCertificate()
    {
      try
      {
        SdkUtil.Post<TaskType>(this._client, this._client.VCloudApiURL + "/admin/extension/settings/amqp/action/resetAmqpCertificate", (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void ResetAmqpTruststore()
    {
      try
      {
        SdkUtil.Post<TaskType>(this._client, this._client.VCloudApiURL + "/admin/extension/settings/amqp/action/resetAmqpTruststore", (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public CertificateUploadSocketType UpdateAmqpCertificate(
      CertificateUpdateParamsType certificateUpdateParamsType)
    {
      try
      {
        return SdkUtil.Post<CertificateUploadSocketType>(this._client, this._client.VCloudApiURL + "/admin/extension/settings/amqp/action/updateAmqpCertificate", SerializationUtil.SerializeObject<CertificateUpdateParamsType>(certificateUpdateParamsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.certificateUpdateParams+xml", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public TrustStoreUploadSocketType UpdateAmqpTruststore(
      TrustStoreUpdateParamsType trustStoreUpdateParamsType)
    {
      try
      {
        return SdkUtil.Post<TrustStoreUploadSocketType>(this._client, this._client.VCloudApiURL + "/admin/extension/settings/amqp/action/updateAmqpTruststore", SerializationUtil.SerializeObject<TrustStoreUpdateParamsType>(trustStoreUpdateParamsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.trustStoreUpdateParams+xml", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void ResetVcTrustsore()
    {
      try
      {
        SdkUtil.Post<TaskType>(this._client, this._client.VCloudApiURL + "/admin/extension/settings/general/action/resetVcTrustsore", (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VcTrustStoreUploadSocketType UpdateVcTrustsore(
      VcTrustStoreUpdateParamsType vcTrustStoreUpdateParamsType)
    {
      try
      {
        return SdkUtil.Post<VcTrustStoreUploadSocketType>(this._client, this._client.VCloudApiURL + "/admin/extension/settings/general/action/updateVcTrustsore", SerializationUtil.SerializeObject<VcTrustStoreUpdateParamsType>(vcTrustStoreUpdateParamsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.vcTrustStoreUpdateParams+xml", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void ResetLdapCertificate()
    {
      try
      {
        SdkUtil.Post<TaskType>(this._client, this._client.VCloudApiURL + "/admin/extension/settings/ldapSettings/action/resetLdapCertificate", (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void ResetLdapKeyStore()
    {
      try
      {
        SdkUtil.Post<TaskType>(this._client, this._client.VCloudApiURL + "/admin/extension/settings/ldapSettings/action/resetLdapKeyStore", (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void ResetLdapSspiKeytab()
    {
      try
      {
        SdkUtil.Post<TaskType>(this._client, this._client.VCloudApiURL + "/admin/extension/settings/ldapSettings/action/resetLdapSspiKeytab", (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public CertificateUploadSocketType UpdateLdapCertificate(
      CertificateUpdateParamsType certificateUpdateParamsType)
    {
      try
      {
        return SdkUtil.Post<CertificateUploadSocketType>(this._client, this._client.VCloudApiURL + "/admin/extension/settings/ldapSettings/action/updateLdapCertificate", SerializationUtil.SerializeObject<CertificateUpdateParamsType>(certificateUpdateParamsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.certificateUpdateParams+xml", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public KeystoreUploadSocketType UpdateLdapKeyStore(
      KeystoreUpdateParamsType keystoreUpdateParamsType)
    {
      try
      {
        return SdkUtil.Post<KeystoreUploadSocketType>(this._client, this._client.VCloudApiURL + "/admin/extension/settings/ldapSettings/action/updateLdapKeyStore", SerializationUtil.SerializeObject<KeystoreUpdateParamsType>(keystoreUpdateParamsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.keystoreUpdateParams+xml", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public SspiKeytabUploadSocketType UpdateLdapSspiKeytab(
      SspiKeytabUpdateParamsType sspiKeytabUpdateParamsType)
    {
      try
      {
        return SdkUtil.Post<SspiKeytabUploadSocketType>(this._client, this._client.VCloudApiURL + "/admin/extension/settings/ldapSettings/action/updateLdapSspiKeytab", SerializationUtil.SerializeObject<SspiKeytabUpdateParamsType>(sspiKeytabUpdateParamsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.sspiKeytabUpdateParams+xml", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public CatalogSettingsType GetCatalogSettings()
    {
      try
      {
        return this.GetSystemSettings().CatalogSettings;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static CatalogSettingsType GetCatalogSettings(vCloudClient client)
    {
      try
      {
        string url = client.VCloudApiURL + "/admin/extension/settings/catalog";
        return SdkUtil.Get<CatalogSettingsType>(client, url, 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public CatalogSettingsType UpdateCatalogSettings(
      CatalogSettingsType catalogSettingsParams)
    {
      try
      {
        return SdkUtil.Put<CatalogSettingsType>(this._client, this._client.VCloudApiURL + "/admin/extension/settings/catalog", SerializationUtil.SerializeObject<CatalogSettingsType>(catalogSettingsParams, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.catalogSettings+xml", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void Sort_v1_5()
    {
      this._enabledBlockingTaskOperations = new List<BlockingTaskOperationType>();
      if (this.GetSystemSettings().BlockingTaskSettings == null)
        return;
      if (this.GetSystemSettings().BlockingTaskSettings.BlockingTaskOperations == null)
        return;
      try
      {
        this._enabledBlockingTaskOperations = BlockingTaskOperationType.FromValues(((IEnumerable<string>) this.GetSystemSettings().BlockingTaskSettings.BlockingTaskOperations.Operation).ToList<string>());
      }
      catch (ArgumentException ex)
      {
        Logger.Log(TraceLevel.Information, ex.Message);
      }
    }
  }
}
