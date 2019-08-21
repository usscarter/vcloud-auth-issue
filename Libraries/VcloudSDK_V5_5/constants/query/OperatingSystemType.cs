// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.OperatingSystemType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct OperatingSystemType
  {
    public static OperatingSystemType RHEL_6_64_BIT = OperatingSystemType.Get("Red Hat Enterprise Linux 6 (64-bit)", 26);
    public static OperatingSystemType RHEL_6_32_BIT = OperatingSystemType.Get("Red Hat Enterprise Linux 6 (32-bit)", 25);
    public static OperatingSystemType RHEL_5_64_BIT = OperatingSystemType.Get("Red Hat Enterprise Linux 5 (64-bit)", 28);
    public static OperatingSystemType RHEL_5_32_BIT = OperatingSystemType.Get("Red Hat Enterprise Linux 5 (32-bit)", 27);
    public static OperatingSystemType RHEL_4_64_BIT = OperatingSystemType.Get("Red Hat Enterprise Linux 4 (64-bit)", 30);
    public static OperatingSystemType RHEL_4_32_BIT = OperatingSystemType.Get("Red Hat Enterprise Linux 4 (32-bit)", 29);
    public static OperatingSystemType RHEL_3_64_BIT = OperatingSystemType.Get("Red Hat Enterprise Linux 3 (64-bit)", 32);
    public static OperatingSystemType RHEL_3_32_BIT = OperatingSystemType.Get("Red Hat Enterprise Linux 3 (32-bit)", 31);
    public static OperatingSystemType RHEL_2_1 = OperatingSystemType.Get("Red Hat Enterprise Linux 2.1", 33);
    public static OperatingSystemType SUSE_11_64_BIT = OperatingSystemType.Get("SUSE Linux Enterprise 11 (64-bit)", 35);
    public static OperatingSystemType SUSE_11_32_BIT = OperatingSystemType.Get("SUSE Linux Enterprise 11 (32-bit)", 34);
    public static OperatingSystemType SUSE_10_64_BIT = OperatingSystemType.Get("SUSE Linux Enterprise 10 (64-bit)", 37);
    public static OperatingSystemType SUSE_10_32_BIT = OperatingSystemType.Get("SUSE Linux Enterprise 10 (32-bit)", 36);
    public static OperatingSystemType SUSE_8_9_64_BIT = OperatingSystemType.Get("SUSE Linux Enterprise 8/9 (64-bit)", 39);
    public static OperatingSystemType SUSE_8_9_32_BIT = OperatingSystemType.Get("SUSE Linux Enterprise 8/9 (32-bit)", 38);
    public static OperatingSystemType CENTOS_4_5_6_64_BIT = OperatingSystemType.Get("CentOS 4/5/6 (64-bit)", 70);
    public static OperatingSystemType CENTOS_4_5_6_32_BIT = OperatingSystemType.Get("CentOS 4/5/6 (32-bit)", 69);
    public static OperatingSystemType DEBIAN_6_64_BIT = OperatingSystemType.Get("Debian GNU/Linux 6 (64 bit)", 74);
    public static OperatingSystemType DEBIAN_6_32_BIT = OperatingSystemType.Get("Debian GNU/Linux 6 (32 bit)", 73);
    public static OperatingSystemType DEBIAN_5_64_BIT = OperatingSystemType.Get("Debian GNU/Linux 5 (64-bit)", 44);
    public static OperatingSystemType DEBIAN_5_32_BIT = OperatingSystemType.Get("Debian GNU/Linux 5 (32-bit)", 43);
    public static OperatingSystemType DEBIAN_4_64_BIT = OperatingSystemType.Get("Debian GNU/Linux 4 (64-bit)", 46);
    public static OperatingSystemType DEBIAN_4_32_BIT = OperatingSystemType.Get("Debian GNU/Linux 4 (32-bit)", 45);
    public static OperatingSystemType ASIANUX_4_64_BIT = OperatingSystemType.Get("Asianux 4 (64 bit)", 76);
    public static OperatingSystemType ASIANUX_4_32_BIT = OperatingSystemType.Get("Asianux 4 (32 bit)", 75);
    public static OperatingSystemType ASIANUX_3_64_BIT = OperatingSystemType.Get("Asianux 3 (64-bit)", 42);
    public static OperatingSystemType ASIANUX_3_32_BIT = OperatingSystemType.Get("Asianux 3 (32-bit)", 41);
    public static OperatingSystemType NOVELL_OPEN_ENTERPRISE_SERVER = OperatingSystemType.Get("Novell Open Enterprise Server", 40);
    public static OperatingSystemType ORACLE_LINUX_4_5_6_64_BIT = OperatingSystemType.Get("Oracle Linux 4/5/6 (64 bit)", 72);
    public static OperatingSystemType ORACLE_LINUX_4_5_6_32_BIT = OperatingSystemType.Get("Oracle Linux 4/5/6 (32 bit)", 71);
    public static OperatingSystemType UBUNTU_64_BIT = OperatingSystemType.Get("Ubuntu Linux (64-bit)", 48);
    public static OperatingSystemType UBUNTU_32_BIT = OperatingSystemType.Get("Ubuntu Linux (32-bit)", 47);
    public static OperatingSystemType OTHER_2_6_X_LINUX_64_BIT = OperatingSystemType.Get("Other 2.6.x Linux (64-bit)", 50);
    public static OperatingSystemType OTHER_2_6_X_LINUX_32_BIT = OperatingSystemType.Get("Other 2.6.x Linux (32-bit)", 49);
    public static OperatingSystemType OTHER_2_4_X_LINUX_64_BIT = OperatingSystemType.Get("Other 2.4.x Linux (64-bit)", 52);
    public static OperatingSystemType OTHER_2_4_X_LINUX_32_BIT = OperatingSystemType.Get("Other 2.4.x Linux (32-bit)", 51);
    public static OperatingSystemType OTHER_LINUX_64_BIT = OperatingSystemType.Get("Other Linux (64-bit)", 54);
    public static OperatingSystemType OTHER_LINUX_32_BIT = OperatingSystemType.Get("Other Linux (32-bit)", 53);
    public static OperatingSystemType WINDOWS_SERVER_8_64_BIT = OperatingSystemType.Get("Microsoft Windows Server 8 (64-bit)", 85);
    public static OperatingSystemType WINDOWS_SERVER_2008_R2_64_BIT = OperatingSystemType.Get("Microsoft Windows Server 2008 R2 (64-bit)", 3);
    public static OperatingSystemType WINDOWS_SERVER_2008_64_BIT = OperatingSystemType.Get("Microsoft Windows Server 2008 (64-bit)", 5);
    public static OperatingSystemType WINDOWS_SERVER_2008_32_BIT = OperatingSystemType.Get("Microsoft Windows Server 2008 (32-bit)", 4);
    public static OperatingSystemType WINDOWS_SERVER_2003_64_BIT = OperatingSystemType.Get("Microsoft Windows Server 2003 (64-bit)", 7);
    public static OperatingSystemType WINDOWS_SERVER_2003_32_BIT = OperatingSystemType.Get("Microsoft Windows Server 2003 (32-bit)", 6);
    public static OperatingSystemType WINDOWS_SERVER_2003_DATACENTER_64_BIT = OperatingSystemType.Get("Microsoft Windows Server 2003 Datacenter (64-bit)", 9);
    public static OperatingSystemType WINDOWS_SERVER_2003_DATACENTER_32_BIT = OperatingSystemType.Get("Microsoft Windows Server 2003 Datacenter (32-bit)", 8);
    public static OperatingSystemType WINDOWS_SERVER_2003_STANDARD_64_BIT = OperatingSystemType.Get("Microsoft Windows Server 2003 Standard (64-bit)", 11);
    public static OperatingSystemType WINDOWS_SERVER_2003_STANDARD_32_BIT = OperatingSystemType.Get("Microsoft Windows Server 2003 Standard (32-bit)", 10);
    public static OperatingSystemType WINDOWS_SERVER_2003_WEB_32_BIT = OperatingSystemType.Get("Microsoft Windows Server 2003 Web Edition (32-bit)", 12);
    public static OperatingSystemType WINDOWS_SMALL_BUSINESS_SERVER_2003 = OperatingSystemType.Get("Microsoft Windows Small Business Server 2003", 13);
    public static OperatingSystemType WINDOWS_8_64_BIT = OperatingSystemType.Get("Microsoft Windows 8 (64-bit)", 86);
    public static OperatingSystemType WINDOWS_8_32_BIT = OperatingSystemType.Get("Microsoft Windows 8 (32-bit)", 87);
    public static OperatingSystemType WINDOWS_7_64_BIT = OperatingSystemType.Get("Microsoft Windows 7 (64-bit)", 2);
    public static OperatingSystemType WINDOWS_7_32_BIT = OperatingSystemType.Get("Microsoft Windows 7 (32-bit)", 1);
    public static OperatingSystemType WINDOWS_VISTA_64_BIT = OperatingSystemType.Get("Microsoft Windows Vista (64-bit)", 15);
    public static OperatingSystemType WINDOWS_VISTA_32_BIT = OperatingSystemType.Get("Microsoft Windows Vista (32-bit)", 14);
    public static OperatingSystemType WINDOWS_XP_PROFESSIONAL_64_BIT = OperatingSystemType.Get("Microsoft Windows XP Professional (64-bit)", 17);
    public static OperatingSystemType WINDOWS_XP_PROFESSIONAL_32_BIT = OperatingSystemType.Get("Microsoft Windows XP Professional (32-bit)", 16);
    public static OperatingSystemType WINDOWS_2000 = OperatingSystemType.Get("Microsoft Windows 2000", 18);
    public static OperatingSystemType WINDOWS_2000_SERVER = OperatingSystemType.Get("Microsoft Windows 2000 Server", 19);
    public static OperatingSystemType WINDOWS_2000_PROFESSIONAL = OperatingSystemType.Get("Microsoft Windows 2000 Professional", 20);
    public static OperatingSystemType WINDOWS_NT = OperatingSystemType.Get("Microsoft Windows NT", 23);
    public static OperatingSystemType WINDOWS_98 = OperatingSystemType.Get("Microsoft Windows 98", 21);
    public static OperatingSystemType WINDOWS_95 = OperatingSystemType.Get("Microsoft Windows 95", 22);
    public static OperatingSystemType WINDOWS_3_1 = OperatingSystemType.Get("Microsoft Windows 3.1", 24);
    public static OperatingSystemType MICROSOFT_MS_DOS = OperatingSystemType.Get("Microsoft MS-DOS", 66);
    public static OperatingSystemType APPLE_MAC_OS_X_10_7_64_BIT = OperatingSystemType.Get("Apple Mac OS X 10.7 (64-bit)", 88);
    public static OperatingSystemType APPLE_MAC_OS_X_10_7_32_BIT = OperatingSystemType.Get("Apple Mac OS X 10.7 (32-bit)", 89);
    public static OperatingSystemType APPLE_MAC_OS_X_10_6_64_BIT = OperatingSystemType.Get("Apple Mac OS X 10.6 (64-bit)", 83);
    public static OperatingSystemType APPLE_MAC_OS_X_10_6_32_BIT = OperatingSystemType.Get("Apple Mac OS X 10.6 (32-bit)", 84);
    public static OperatingSystemType WINDOWS_SERVER_8_32_BIT = OperatingSystemType.Get("Microsoft Windows Server 8 (32-bit)", 88);
    public static OperatingSystemType APPLE_MAC_OS_X_10_5_64_BIT = OperatingSystemType.Get("Apple Mac OS X 10.5 (64-bit)", 81);
    public static OperatingSystemType APPLE_MAC_OS_X_10_5_32_BIT = OperatingSystemType.Get("Apple Mac OS X 10.5 (32-bit)", 82);
    public static OperatingSystemType FREEBSD_64_BIT = OperatingSystemType.Get("FreeBSD (64-bit)", 62);
    public static OperatingSystemType FREEBSD_32_BIT = OperatingSystemType.Get("FreeBSD (32-bit)", 61);
    public static OperatingSystemType IBM_OS_2 = OperatingSystemType.Get("IBM OS/2", 63);
    public static OperatingSystemType NETWARE_6_X = OperatingSystemType.Get("Novell NetWare 6.x", 55);
    public static OperatingSystemType NETWARE_5_1 = OperatingSystemType.Get("Novell NetWare 5.1", 56);
    public static OperatingSystemType ORACLE_SOLARIS_11_64_BIT = OperatingSystemType.Get("Oracle Solaris 11 (64 bit)", 77);
    public static OperatingSystemType ORACLE_SOLARIS_10_64_BIT = OperatingSystemType.Get("Oracle Solaris 10 (64-bit)", 58);
    public static OperatingSystemType ORACLE_SOLARIS_10_32_BIT = OperatingSystemType.Get("Oracle Solaris 10 (32-bit)", 57);
    public static OperatingSystemType SUN_MICROSYSTEMS_SOLARIS_9 = OperatingSystemType.Get("Sun Microsystems Solaris 9 (experimental)", 59);
    public static OperatingSystemType SUN_MICROSYSTEMS_SOLARIS_8 = OperatingSystemType.Get("Sun Microsystems Solaris 8 (experimental)", 60);
    public static OperatingSystemType SCO_OPENSERVER_6 = OperatingSystemType.Get("SCO OpenServer 6", 78);
    public static OperatingSystemType SCO_OPENSERVER_5 = OperatingSystemType.Get("SCO OpenServer 5", 64);
    public static OperatingSystemType SCO_UNIXWARE_7 = OperatingSystemType.Get("SCO UnixWare 7", 65);
    public static OperatingSystemType SERENITY_SYSTEMS_ECOMSTATION_2 = OperatingSystemType.Get("Serenity Systems eComStation 2", 80);
    public static OperatingSystemType SERENITY_SYSTEMS_ECOMSTATION_1 = OperatingSystemType.Get("Serenity Systems eComStation 1", 79);
    public static OperatingSystemType OTHER_64_BIT = OperatingSystemType.Get("Other (64-bit)", 68);
    public static OperatingSystemType OTHER_32_BIT = OperatingSystemType.Get("Other (32-bit)", 67);
    private string _osName;
    private int _value;

    private static OperatingSystemType Get(string osName, int osId)
    {
      return new OperatingSystemType(osName, osId);
    }

    private OperatingSystemType(string osName, int osId)
    {
      this._osName = osName;
      this._value = osId;
    }

    public string Name()
    {
      return this._osName;
    }

    public int Value()
    {
      return this._value;
    }

    public static List<OperatingSystemType> Values()
    {
      OperatingSystemType operatingSystemType = new OperatingSystemType();
      List<OperatingSystemType> operatingSystemTypeList = new List<OperatingSystemType>();
      foreach (FieldInfo field in operatingSystemType.GetType().GetFields())
        operatingSystemTypeList.Add((OperatingSystemType) field.GetValue((object) operatingSystemType));
      return operatingSystemTypeList;
    }

    public static OperatingSystemType FromName(string osName)
    {
      foreach (OperatingSystemType operatingSystemType in OperatingSystemType.Values())
      {
        if (operatingSystemType.Name().Equals(osName))
          return operatingSystemType;
      }
      throw new ArgumentException(osName.ToString());
    }

    public static OperatingSystemType FromValue(int value)
    {
      foreach (OperatingSystemType operatingSystemType in OperatingSystemType.Values())
      {
        if (operatingSystemType.Value().Equals(value))
          return operatingSystemType;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
