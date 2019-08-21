// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.AbstractVapp`1
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.constants;
using com.vmware.vcloud.sdk.utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace com.vmware.vcloud.sdk
{
  public abstract class AbstractVapp<T> : VcloudEntity<T> where T : AbstractVAppType
  {
    private List<ProductSection_Type> _productSections;
    private SnapshotSectionType snapshotSection;

    internal AbstractVapp(vCloudClient client, T abstractvAppType)
      : base(client, abstractvAppType)
    {
      this.SortOvfSectionsAndReferences();
    }

    public T GetResource()
    {
      return this.Resource;
    }

    public bool IsDeployed()
    {
      return this.Resource.deployed;
    }

    public List<ProductSection_Type> GetProductSections()
    {
      try
      {
        return this._productSections;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public SnapshotSectionType GetSnapshotSection()
    {
      if (this.snapshotSection == null)
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.DATA_NOT_FOUND));
      return this.snapshotSection;
    }

    public static SnapshotSectionType GetSnapshotSection(
      vCloudClient client,
      ReferenceType vappRef)
    {
      return SdkUtil.Get<SnapshotSectionType>(client, vappRef.href + "/snapshotSection", 200);
    }

    public static List<ProductSection_Type> GetProductSections(
      vCloudClient client,
      ReferenceType _ref)
    {
      try
      {
        ProductSectionListType productSectionListType = SdkUtil.Get<ProductSectionListType>(client, _ref.href + "/productSections/", 200);
        if (productSectionListType.ProductSection == null)
          return new List<ProductSection_Type>();
        return ((IEnumerable<ProductSection_Type>) productSectionListType.ProductSection).ToList<ProductSection_Type>();
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task UpdateProductSections(List<ProductSection_Type> productSections)
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Put<TaskType>(this.VcloudClient, this.Reference.href + "/productSections/", SerializationUtil.SerializeObject<ProductSectionListType>(new ProductSectionListType()
        {
          ProductSection = productSections.ToArray()
        }, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.vcloud.productSections+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void SortOvfSectionsAndReferences()
    {
      this._productSections = new List<ProductSection_Type>();
      if (this.Resource.Items == null)
        return;
      foreach (Section_Type sectionType in this.Resource.Items)
      {
        if (sectionType is ProductSection_Type)
          this._productSections.Add((ProductSection_Type) sectionType);
        else if (sectionType is SnapshotSectionType)
          this.snapshotSection = (SnapshotSectionType) sectionType;
        Logger.Log(TraceLevel.Information, sectionType.GetType().Name);
      }
    }

    public Task Deploy(bool powerOn, int lease, bool forceCustomization)
    {
      try
      {
        return AbstractVapp<T>.ExecuteAbstractVappAction(this.VcloudClient, this.Reference.href + "/action/deploy", AbstractVapp<T>.CreateAbstractVappDeployParamBody(powerOn, lease, forceCustomization), "application/vnd.vmware.vcloud.deployVAppParams+xml", 202);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task Deploy(
      vCloudClient client,
      ReferenceType _ref,
      bool powerOn,
      int lease,
      bool forceCustomization)
    {
      try
      {
        string actionUrl = _ref.href + "/action/deploy";
        string vappDeployParamBody = AbstractVapp<T>.CreateAbstractVappDeployParamBody(powerOn, lease, forceCustomization);
        return AbstractVapp<T>.ExecuteAbstractVappAction(client, actionUrl, vappDeployParamBody, "application/vnd.vmware.vcloud.deployVAppParams+xml", 202);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private static string CreateAbstractVappDeployParamBody(
      bool powerOn,
      int lease,
      bool forceCustomization)
    {
      DeployVAppParamsType deployVappParamsType = new DeployVAppParamsType()
      {
        powerOn = powerOn,
        powerOnSpecified = true,
        deploymentLeaseSeconds = lease,
        deploymentLeaseSecondsSpecified = true,
        forceCustomization = forceCustomization
      };
      deployVappParamsType.deploymentLeaseSecondsSpecified = true;
      return SerializationUtil.SerializeObject<DeployVAppParamsType>(deployVappParamsType, "com.vmware.vcloud.api.rest.schema");
    }

    private static string CreateVappUnDeployParamBody(UndeployPowerActionType undeployPowerAction)
    {
      return SerializationUtil.SerializeObject<UndeployVAppParamsType>(new UndeployVAppParamsType()
      {
        UndeployPowerAction = undeployPowerAction.Value()
      }, "com.vmware.vcloud.api.rest.schema");
    }

    public Task Undeploy(UndeployPowerActionType undeployPowerAction)
    {
      try
      {
        return AbstractVapp<T>.ExecuteAbstractVappAction(this.VcloudClient, this.Reference.href + "/action/undeploy", AbstractVapp<T>.CreateVappUnDeployParamBody(undeployPowerAction), "application/vnd.vmware.vcloud.undeployVAppParams+xml", 202);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task Undeploy(
      vCloudClient client,
      ReferenceType _ref,
      UndeployPowerActionType undeployPowerAction)
    {
      try
      {
        string actionUrl = _ref.href + "/action/undeploy";
        string unDeployParamBody = AbstractVapp<T>.CreateVappUnDeployParamBody(undeployPowerAction);
        return AbstractVapp<T>.ExecuteAbstractVappAction(client, actionUrl, unDeployParamBody, "application/vnd.vmware.vcloud.undeployVAppParams+xml", 202);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task PowerOn()
    {
      try
      {
        return AbstractVapp<T>.ExecuteAbstractVappAction(this.VcloudClient, this.Reference.href + "/power/action/powerOn", (string) null, (string) null, 202);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task PowerOn(vCloudClient client, ReferenceType _ref)
    {
      try
      {
        return AbstractVapp<T>.ExecuteAbstractVappAction(client, _ref.href + "/power/action/powerOn", (string) null, (string) null, 202);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task PowerOff()
    {
      try
      {
        return AbstractVapp<T>.ExecuteAbstractVappAction(this.VcloudClient, this.Reference.href + "/power/action/powerOff", (string) null, (string) null, 202);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task PowerOff(vCloudClient client, ReferenceType _ref)
    {
      try
      {
        return AbstractVapp<T>.ExecuteAbstractVappAction(client, _ref.href + "/power/action/powerOff", (string) null, (string) null, 202);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task Reset()
    {
      try
      {
        return AbstractVapp<T>.ExecuteAbstractVappAction(this.VcloudClient, this.Reference.href + "/power/action/reset", (string) null, (string) null, 202);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task Reset(vCloudClient client, ReferenceType _ref)
    {
      try
      {
        return AbstractVapp<T>.ExecuteAbstractVappAction(client, _ref.href + "/power/action/reset", (string) null, (string) null, 202);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task Suspend()
    {
      try
      {
        return AbstractVapp<T>.ExecuteAbstractVappAction(this.VcloudClient, this.Reference.href + "/power/action/suspend", (string) null, (string) null, 202);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task Suspend(vCloudClient client, ReferenceType _ref)
    {
      try
      {
        return AbstractVapp<T>.ExecuteAbstractVappAction(client, _ref.href + "/power/action/suspend", (string) null, (string) null, 202);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task DiscardSuspend()
    {
      try
      {
        return AbstractVapp<T>.ExecuteAbstractVappAction(this.VcloudClient, this.Reference.href + "/action/discardSuspendedState", (string) null, (string) null, 202);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task DiscardSuspend(vCloudClient client, ReferenceType _ref)
    {
      try
      {
        return AbstractVapp<T>.ExecuteAbstractVappAction(client, _ref.href + "/action/discardSuspendedState", (string) null, (string) null, 202);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task Shutdown()
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/power/action/shutdown", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task Shutdown(vCloudClient client, ReferenceType _ref)
    {
      try
      {
        return new Task(client, SdkUtil.Post<TaskType>(client, _ref.href + "/power/action/shutdown", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task Reboot()
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/power/action/reboot", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task Reboot(vCloudClient client, ReferenceType _ref)
    {
      try
      {
        return new Task(client, SdkUtil.Post<TaskType>(client, _ref.href + "/power/action/reboot", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task RemoveAllSnapshots()
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/removeAllSnapshots", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task RemoveAllSnapshots(vCloudClient client, ReferenceType refer)
    {
      try
      {
        return new Task(client, SdkUtil.Post<TaskType>(client, refer.href + "/action/removeAllSnapshots", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task RevertToCurrentSnapshot()
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/revertToCurrentSnapshot", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task RevertToCurrentSnapshot(vCloudClient client, ReferenceType refer)
    {
      try
      {
        return new Task(client, SdkUtil.Post<TaskType>(client, refer.href + "/action/revertToCurrentSnapshot", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task CreateSnapshot(string name, string description, bool memory, bool quiesce)
    {
      try
      {
        CreateSnapshotParamsType snapshotParamsType = new CreateSnapshotParamsType();
        snapshotParamsType.name = name;
        snapshotParamsType.Description = description;
        snapshotParamsType.memory = memory;
        snapshotParamsType.quiesce = quiesce;
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/createSnapshot", SerializationUtil.SerializeObject<CreateSnapshotParamsType>(snapshotParamsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.vcloud.createSnapshotParams+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task CreateSnapshot(
      vCloudClient client,
      ReferenceType refer,
      string name,
      string description,
      bool memory,
      bool quiesce)
    {
      try
      {
        CreateSnapshotParamsType snapshotParamsType = new CreateSnapshotParamsType();
        snapshotParamsType.name = name;
        snapshotParamsType.Description = description;
        snapshotParamsType.memory = memory;
        snapshotParamsType.quiesce = quiesce;
        string requestString = SerializationUtil.SerializeObject<CreateSnapshotParamsType>(snapshotParamsType, "com.vmware.vcloud.api.rest.schema");
        return new Task(client, SdkUtil.Post<TaskType>(client, refer.href + "/action/createSnapshot", requestString, "application/vnd.vmware.vcloud.createSnapshotParams+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task Delete(vCloudClient client, ReferenceType _ref)
    {
      try
      {
        return AbstractVapp<T>.AsyncDelete(client, _ref.href);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task Delete()
    {
      try
      {
        return AbstractVapp<T>.AsyncDelete(this.VcloudClient, this.Reference.href);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private static Task AsyncDelete(vCloudClient client, string anyUrl)
    {
      try
      {
        return new Task(client, SdkUtil.Delete<TaskType>(client, anyUrl, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task ExecuteAbstractVappAction(
      vCloudClient client,
      string actionUrl,
      string content,
      string contentType,
      int statusCode)
    {
      try
      {
        return new Task(client, SdkUtil.Post<TaskType>(client, actionUrl, content, contentType, statusCode));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }
  }
}
