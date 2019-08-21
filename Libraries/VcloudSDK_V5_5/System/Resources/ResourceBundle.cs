// Decompiled with JetBrains decompiler
// Type: System.Resources.ResourceBundle
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System.Reflection;

namespace System.Resources
{
  public class ResourceBundle
  {
    private static ResourceManager _rm;
    private static ResourceBundle _instance;

    private ResourceBundle()
    {
    }

    public string GetString(string resourceName)
    {
      return ResourceBundle._rm.GetString(resourceName);
    }

    public static ResourceBundle getBundle(
      string resourceBundleName,
      string locale,
      string resourceKey)
    {
      if (ResourceBundle._instance == null)
        ResourceBundle._instance = new ResourceBundle();
      locale = locale.Replace('-', '_');
      ResourceBundle._rm = new ResourceManager(resourceBundleName + "." + locale + "." + resourceKey, Assembly.GetExecutingAssembly());
      if (ResourceBundle._rm == null)
        throw new MissingManifestResourceException();
      return ResourceBundle._instance;
    }
  }
}
