// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.Media
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace com.vmware.vcloud.sdk
{
  public class Media : VcloudEntity<com.vmware.vcloud.api.rest.schema.MediaType>
  {
    private Dictionary<string, FileType> _uploadFileMap = new Dictionary<string, FileType>();
    private Dictionary<string, FileType> _uploadedFileMap = new Dictionary<string, FileType>();
    private ReferenceType _catalogItemReference;
    private ReferenceType _vdcReference;

    internal Media(vCloudClient client, com.vmware.vcloud.api.rest.schema.MediaType mediaResource_v1_5)
      : base(client, mediaResource_v1_5)
    {
      this.SortMediaFilesAndReferences_v1_5();
    }

    public static Media GetMediaByReference(vCloudClient client, ReferenceType mediaRef)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + mediaRef.href);
        return new Media(client, VcloudResource<com.vmware.vcloud.api.rest.schema.MediaType>.GetResourceByReference(client, mediaRef));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Media GetMediaById(vCloudClient client, string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        return new Media(client, VcloudEntity<com.vmware.vcloud.api.rest.schema.MediaType>.GetEntityById(client, vCloudId, "application/vnd.vmware.vcloud.media+xml"));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task UpdateMedia(com.vmware.vcloud.api.rest.schema.MediaType mediaType)
    {
      try
      {
        string requestString = SerializationUtil.SerializeObject<com.vmware.vcloud.api.rest.schema.MediaType>(mediaType, "com.vmware.vcloud.api.rest.schema");
        string href = this.Resource.href;
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.PUT_URL_MSG) + " - " + href);
        return new Task(this.VcloudClient, SdkUtil.Put<TaskType>(this.VcloudClient, href, requestString, "application/vnd.vmware.vcloud.media+xml", 202));
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
        return Media.DeleteMedia(this.VcloudClient, this.Resource.href);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task Delete(vCloudClient client, ReferenceType mediaRef)
    {
      try
      {
        return Media.DeleteMedia(client, mediaRef.href);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public List<string> GetUploadFileNames()
    {
      if (this._uploadFileMap.Keys != null)
        return this._uploadFileMap.Keys.ToList<string>();
      return new List<string>();
    }

    public List<string> GetUploadedFileNames()
    {
      if (this._uploadedFileMap.Keys != null)
        return this._uploadedFileMap.Keys.ToList<string>();
      return new List<string>();
    }

    public void UploadFile(string fileName, Stream inputStream, long size)
    {
      try
      {
        if (this.Resource.status == 1)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.MEDIA_RESOLVED_MSG));
        if (this._uploadFileMap == null)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.NO_FILES_TO_UPLOAD_MSG));
        FileType uploadFile = this._uploadFileMap[fileName];
        if (uploadFile == null)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.FILE_NOT_FOUND_MSG));
        RestUtil.UploadFile(this.VcloudClient, uploadFile, inputStream, size, 0L, 0L);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void UploadFile(string fileName, Stream inputStream, long startByte, long endByte)
    {
      try
      {
        if (this.Resource.status == 1)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.MEDIA_RESOLVED_MSG));
        if (this._uploadFileMap == null)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.NO_FILES_TO_UPLOAD_MSG));
        FileType uploadFile = this._uploadFileMap[fileName];
        if (uploadFile == null)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.FILE_NOT_FOUND_MSG));
        RestUtil.UploadFile(this.VcloudClient, uploadFile, inputStream, uploadFile.size, startByte, endByte);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Dictionary<string, FileType> MonitorUpload()
    {
      try
      {
        Media mediaByReference = Media.GetMediaByReference(this.VcloudClient, this.Reference);
        List<FileType> source = (List<FileType>) null;
        Dictionary<string, FileType> dictionary = new Dictionary<string, FileType>();
        if (mediaByReference != null && mediaByReference.Resource != null && mediaByReference.Resource.Files != null)
        {
          FilesListType files = mediaByReference.Resource.Files;
          if (files != null && files.File != null)
            source = ((IEnumerable<FileType>) files.File).ToList<FileType>();
        }
        if (source != null)
          dictionary = source.ToDictionary<FileType, string, FileType>((Func<FileType, string>) (file => file.name), (Func<FileType, FileType>) (file => file));
        return dictionary;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType GetCatalogItemReference()
    {
      try
      {
        if (this._catalogItemReference != null)
          return this._catalogItemReference;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType GetVdcReference()
    {
      try
      {
        if (this._vdcReference != null)
          return this._vdcReference;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType GetOwner()
    {
      try
      {
        return this.Resource.Owner.User;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public bool IsPartOfCatalogItem()
    {
      try
      {
        return this._catalogItemReference != null;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task DeleteMedia()
    {
      try
      {
        string href = this.Reference.href;
        if (this.IsPartOfCatalogItem())
          CatalogItem.Delete(this.VcloudClient, this.GetCatalogItemReference());
        return new Task(this.VcloudClient, SdkUtil.Delete<TaskType>(this.VcloudClient, href, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task DeleteMedia(vCloudClient client, ReferenceType mediaRef)
    {
      try
      {
        return Media.DeleteMediaWithCatalogItem(client, mediaRef);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task EnableDownload()
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/enableDownload", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task EnableDownload(vCloudClient client, ReferenceType mediapRef)
    {
      try
      {
        string url = mediapRef.href + "/action/enableDownload";
        return new Task(client, SdkUtil.Post<TaskType>(client, url, (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void DownloadMedia(string downloadLocation)
    {
      Stream inputStream = this.DownloadFile();
      this.WriteToFile(downloadLocation, this.Resource.name, inputStream);
    }

    public void DownloadMedia(string downloadLocation, string mediaName)
    {
      Stream inputStream = this.DownloadFile();
      this.WriteToFile(downloadLocation, mediaName + "." + this.Resource.imageType, inputStream);
    }

    private static Task DeleteMedia(vCloudClient client, string mediaUrl)
    {
      try
      {
        return new Task(client, SdkUtil.Delete<TaskType>(client, mediaUrl, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private static Task DeleteMediaWithCatalogItem(vCloudClient client, ReferenceType mediaRef)
    {
      Media mediaByReference = Media.GetMediaByReference(client, mediaRef);
      string href = mediaRef.href;
      if (mediaByReference.IsPartOfCatalogItem())
        CatalogItem.Delete(client, mediaByReference.GetCatalogItemReference());
      return new Task(client, SdkUtil.Delete<TaskType>(client, href, 202));
    }

    private void SortMediaFilesAndReferences_v1_5()
    {
      FilesListType files = this.Resource.Files;
      if (files != null && files.File != null)
      {
        List<FileType> list = ((IEnumerable<FileType>) files.File).ToList<FileType>();
        if (list != null)
        {
          this._uploadedFileMap = list.Where<FileType>((Func<FileType, bool>) (file => file.size.CompareTo(file.bytesTransferred).Equals(0))).ToDictionary<FileType, string, FileType>((Func<FileType, string>) (file => file.name), (Func<FileType, FileType>) (file => file));
          this._uploadFileMap = list.Where<FileType>((Func<FileType, bool>) (file => !file.size.CompareTo(file.bytesTransferred).Equals(0))).ToDictionary<FileType, string, FileType>((Func<FileType, string>) (file => file.name), (Func<FileType, FileType>) (file => file));
        }
      }
      if (this.Resource.Link == null)
        return;
      foreach (LinkType linkType in this.Resource.Link)
      {
        if (this._catalogItemReference != null && this._vdcReference != null)
          break;
        if (linkType.rel.Equals("catalogItem") && linkType.type.Equals("application/vnd.vmware.vcloud.catalogItem+xml"))
          this._catalogItemReference = (ReferenceType) linkType;
        else if (linkType.rel.Equals("up") && linkType.type.Equals("application/vnd.vmware.vcloud.vdc+xml"))
          this._vdcReference = (ReferenceType) linkType;
      }
    }

    private Stream DownloadFile()
    {
      if (this.Resource.Files != null)
      {
        foreach (ResourceType resourceType in this.Resource.Files.File)
        {
          foreach (LinkType linkType in resourceType.Link)
          {
            if (linkType.rel.Equals("download:default"))
              return RestUtil.DownloadFile(this.VcloudClient, linkType.href);
          }
        }
      }
      throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.NO_DOWNLOAD_LINK_MSG));
    }

    private void WriteToFile(string downloadLocation, string fileName, Stream inputStream)
    {
      string path = downloadLocation + "/" + fileName;
      try
      {
        BinaryWriter binaryWriter = new BinaryWriter((Stream) File.Create(path));
        try
        {
          byte[] buffer = new byte[1024];
          int count;
          while ((count = inputStream.Read(buffer, 0, buffer.Length)) > 0)
            binaryWriter.Write(buffer, 0, count);
        }
        finally
        {
          if (binaryWriter != null)
          {
            binaryWriter.Flush();
            binaryWriter.Close();
          }
          inputStream?.Close();
        }
      }
      catch (FileNotFoundException ex)
      {
        throw new VCloudRuntimeException((Exception) ex);
      }
      catch (IOException ex)
      {
        throw new VCloudRuntimeException((Exception) ex);
      }
    }

    protected new void Dispose(bool disposing)
    {
    }

    public new void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }
  }
}
