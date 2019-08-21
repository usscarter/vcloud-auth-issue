// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.extensions.service.ExtensionServiceConstants
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System.Runtime.InteropServices;

namespace com.vmware.vcloud.sdk.admin.extensions.service
{
  internal class ExtensionServiceConstants
  {
    public const string GLOBAL_SDK_LOGGER_NAME = "com.vmware.vcloud.sdk";

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct Uri
    {
      public const string RIGHTS = "/rights";
      public const string SERVICE_LINKS = "/links";
      public const string FILES = "/files";
      public const string API_DEFINITIONS = "/apidefinitions";
      public const string API_FILTERS = "/apifilters";
      public const string RESOURCE_CLASSES = "/resourceclasses";
      public const string RESOURCE_CLASS_ACTIONS = "/resourceclassactions";
      public const string SERVICE_RESOURCES = "/serviceresources";
      public const string ACL_RULES = "/aclrules";
      public const string ENTITY = "/entity";
      public const string AUTHORIZATION_CHECK = "/authorizationcheck";
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct ActionUri
    {
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct RelationType
    {
      public const string UP = "up";
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct MediaType
    {
      public const string SERVICE = "application/vnd.vmware.admin.service+xml";
      public const string RIGHT = "application/vnd.vmware.admin.right+xml";
      public const string SERVICE_LINK = "application/vnd.vmware.admin.serviceLink+xml";
      public const string API_DEFINITION = "application/vnd.vmware.admin.apiDefinition+xml";
      public const string API_FILTER = "application/vnd.vmware.admin.apiFilter+xml";
      public const string RESOURCE_CLASS = "application/vnd.vmware.admin.resourceClass+xml";
      public const string RESOURCE_CLASS_ACTION = "application/vnd.vmware.admin.resourceClassAction+xml";
      public const string SERVICE_RESOURCE = "application/vnd.vmware.admin.serviceResource+xml";
      public const string ACL_RULE = "application/vnd.vmware.admin.aclRule+xml";
      public const string FILE_DESC = "application/vnd.vmware.admin.fileDescriptor+xml";
      public const string AUTHORIZATION_CHECK = "application/vnd.vmware.admin.authorizationCheckParams+xml";
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct QueryConstants
    {
      public const string QUESTION_MARK = "?";
    }
  }
}
