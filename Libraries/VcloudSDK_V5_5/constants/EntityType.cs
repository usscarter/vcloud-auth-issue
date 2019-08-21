// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.EntityType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct EntityType
  {
    public static EntityType ORGANIZATION = EntityType.Get("vcloud:org");
    public static EntityType CATALOG = EntityType.Get("vcloud:catalog");
    public static EntityType CATALOG_ITEM = EntityType.Get("vcloud:catalogitem");
    public static EntityType USER = EntityType.Get("vcloud:user");
    public static EntityType GROUP = EntityType.Get("vcloud:group");
    public static EntityType ROLE = EntityType.Get("vcloud:role");
    public static EntityType RIGHT = EntityType.Get("vcloud:right");
    public static EntityType TASK = EntityType.Get("vcloud:task");
    public static EntityType NETWORK = EntityType.Get("vcloud:network");
    public static EntityType NETWORK_POOL = EntityType.Get("vcloud:networkpool");
    public static EntityType VAPP = EntityType.Get("vcloud:vapp");
    public static EntityType VAPP_TEMPLATE = EntityType.Get("vcloud:vapptemplate");
    public static EntityType VM = EntityType.Get("vcloud:vm");
    public static EntityType MEDIA = EntityType.Get("vcloud:media");
    public static EntityType HOST = EntityType.Get("vcloud:host");
    public static EntityType VIM_SERVER = EntityType.Get("vcloud:vimserver");
    public static EntityType PROVIDER_VDC = EntityType.Get("vcloud:providervdc");
    public static EntityType VDC = EntityType.Get("vcloud:vdc");
    public static EntityType DATASTORE = EntityType.Get("vcloud:datastore");
    public static EntityType LICENSE_REPORT = EntityType.Get("vcloud:licenseReport");
    public static EntityType BLOCKING_TASK = EntityType.Get("vcloud:blockingTask");
    public static EntityType DISK = EntityType.Get("vcloud:disk");
    public static EntityType GATEWAY = EntityType.Get("vcloud:gateway");
    public static EntityType STRANDED_ITEM = EntityType.Get("vcloud:strandedItem");
    public static EntityType VDC_STORAGE_PROFILE = EntityType.Get("vcloud:vdcStorageProfile");
    public static EntityType PROVIDER_VDC_STORAGE_PROFILE = EntityType.Get("vcloud:providerVdcStorageProfile");
    private string _value;

    private static EntityType Get(string str)
    {
      return new EntityType(str);
    }

    private EntityType(string value)
    {
      this._value = value;
    }

    public static EntityType FromValue(string value)
    {
      EntityType entityType1 = new EntityType();
      foreach (FieldInfo field in entityType1.GetType().GetFields())
      {
        EntityType entityType2 = (EntityType) field.GetValue((object) entityType1);
        if (entityType2.Value() == value)
          return entityType2;
      }
      throw new ArgumentException(value.ToString());
    }

    public string Value()
    {
      return this._value;
    }

    public static List<EntityType> Values()
    {
      EntityType entityType = new EntityType();
      List<EntityType> entityTypeList = new List<EntityType>();
      foreach (FieldInfo field in entityType.GetType().GetFields())
        entityTypeList.Add((EntityType) field.GetValue((object) entityType));
      return entityTypeList;
    }
  }
}
