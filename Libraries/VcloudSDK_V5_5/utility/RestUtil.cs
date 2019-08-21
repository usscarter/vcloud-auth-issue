// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.utility.RestUtil
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace com.vmware.vcloud.sdk.utility
{
  public class RestUtil
  {
    private RestUtil()
    {
    }

    public static Response Delete(vCloudClient client, string url)
    {
      HttpClient httpClient = client.HttpClient;
      Response response = new Response();
      string empty = string.Empty;
      int num = 0;
      try
      {
        httpClient.DefaultRequestHeaders.Add("Accept", vCloudClient.SUPPORTED_SDK_VERSIONS[client.VcloudClientVersion]);
        httpClient.DefaultRequestHeaders.Add(client.VcloudTokenHeader, client.VcloudToken);
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.DELETE_URL_MSG) + " - " + url);
        HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, url);
        HttpResponseMessage result;
        using (result = httpClient.DeleteAsync(new System.Uri(url)).Result)
        {
          if (result != null)
          {
            num = (int) result.StatusCode;
            empty = SerializationUtil.UTF8ByteArrayToString(result.Content.ReadAsByteArrayAsync().Result);
          }
          response.ResponseStatusCode = num;
          Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.STATUS_CODE_MSG) + " - " + (object) num);
          Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.STATUS_MSG) + " - " + result.StatusCode.ToString());
          response.ResponseXml = empty;
          Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.RESPONSE_MSG) + " - " + empty);
        }
      }
      catch (HttpRequestException ex)
      {
        Logger.Log(TraceLevel.Critical, ex.Message);
        throw new VCloudRuntimeException((Exception) ex);
      }
      catch (ApplicationException ex)
      {
        Logger.Log(TraceLevel.Critical, ex.Message);
        throw new VCloudRuntimeException((Exception) ex);
      }
      catch (IOException ex)
      {
        Logger.Log(TraceLevel.Critical, ex.Message);
        throw new VCloudRuntimeException((Exception) ex);
      }
      return response;
    }

    public static Response Put(
      vCloudClient client,
      string url,
      string content,
      string contentType,
      string charset)
    {
      HttpClient httpClient = client.HttpClient;
      Response response = new Response();
      string str = (string) null;
      int num = 0;
      Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.PUT_URL_MSG) + " - " + url);
      try
      {
        httpClient.DefaultRequestHeaders.Add("Accept", vCloudClient.SUPPORTED_SDK_VERSIONS[client.VcloudClientVersion]);
        httpClient.DefaultRequestHeaders.Add(client.VcloudTokenHeader, client.VcloudToken);
        HttpContent content1 = (HttpContent) null;
        if (content != null && content.Length > 0 && (contentType != null && contentType.Length > 0))
        {
          Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.PUT_REQUEST_BODY) + " - " + content);
          Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.PUT_CONTENT_TYPE) + " - " + contentType);
          content1 = (HttpContent) new StringContent(content, Encoding.UTF8, contentType);
        }
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, url);
        HttpResponseMessage httpResponseMessage1;
        HttpResponseMessage httpResponseMessage2;
        if (content1 != null)
          httpResponseMessage2 = httpResponseMessage1 = httpClient.PutAsync(new System.Uri(url), content1).Result;
        else
          httpResponseMessage1 = httpResponseMessage2 = httpClient.SendAsync(request).Result;
        using (httpResponseMessage2)
        {
          if (httpResponseMessage1 != null)
          {
            num = (int) httpResponseMessage1.StatusCode;
            str = SerializationUtil.UTF8ByteArrayToString(httpResponseMessage1.Content.ReadAsByteArrayAsync().Result);
          }
          response.ResponseStatusCode = num;
          Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.STATUS_CODE_MSG) + " - " + (object) num);
          Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.STATUS_MSG) + " - " + httpResponseMessage1.StatusCode.ToString());
          response.ResponseXml = str;
          Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.RESPONSE_MSG) + " - " + str);
        }
      }
      catch (HttpRequestException ex)
      {
        Logger.Log(TraceLevel.Critical, ex.Message);
        throw new VCloudRuntimeException((Exception) ex);
      }
      catch (ApplicationException ex)
      {
        Logger.Log(TraceLevel.Critical, ex.Message);
        throw new VCloudRuntimeException((Exception) ex);
      }
      catch (IOException ex)
      {
        Logger.Log(TraceLevel.Critical, ex.Message);
        throw new VCloudRuntimeException((Exception) ex);
      }
      finally
      {
        httpClient.DefaultRequestHeaders.Clear();
      }
      return response;
    }

    private static string RedirectURL(HttpResponseMessage response)
    {
      string str = response.Headers.GetValues("Location").FirstOrDefault<string>();
      Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.REDIRECTED_URL_MSG) + " - " + str);
      return str;
    }

    internal static Response Login(
      vCloudClient client,
      string url,
      HttpRequestHeaders authHeader)
    {
      HttpClient httpClient = client.HttpClient;
      Response response = new Response();
      string str = (string) null;
      int num = 0;
      Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.LOGIN_URL_MSG) + " - " + url);
      try
      {
        httpClient.DefaultRequestHeaders.Add("Accept", vCloudClient.SUPPORTED_SDK_VERSIONS[client.VcloudClientVersion]);
        HttpRequestMessage request1 = new HttpRequestMessage(HttpMethod.Post, url);
        HttpResponseMessage result;
        using (result = httpClient.SendAsync(request1).Result)
        {
          if (result != null)
          {
            if (result.StatusCode == HttpStatusCode.MovedPermanently)
            {
              if (!httpClient.DefaultRequestHeaders.Contains("Accept"))
                httpClient.DefaultRequestHeaders.Add("Accept", vCloudClient.SUPPORTED_SDK_VERSIONS[client.VcloudClientVersion]);
              System.Uri uri = new System.Uri(RestUtil.RedirectURL(result));
              HttpRequestMessage request2 = (HttpRequestMessage) null;
              request2.RequestUri.MakeRelativeUri(uri);
              result = httpClient.SendAsync(request2).Result;
            }
            if (result.Headers.GetValues("x-vcloud-authorization") != null)
            {
              client.VcloudTokenHeader = "x-vcloud-authorization";
              client.VcloudToken = result.Headers.GetValues("x-vcloud-authorization").FirstOrDefault<string>();
            }
            num = (int) result.StatusCode;
            str = SerializationUtil.UTF8ByteArrayToString(result.Content.ReadAsByteArrayAsync().Result);
          }
          response.ResponseStatusCode = num;
          Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.STATUS_CODE_MSG) + " - " + (object) num);
          Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.STATUS_MSG) + " - " + result.StatusCode.ToString());
          response.ResponseXml = str;
          Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.RESPONSE_MSG) + " - " + str);
        }
      }
      catch (HttpRequestException ex)
      {
        Logger.Log(TraceLevel.Critical, ex.Message);
        throw new VCloudRuntimeException((Exception) ex);
      }
      catch (NotSupportedException ex)
      {
        Logger.Log(TraceLevel.Critical, ex.Message);
        throw new VCloudRuntimeException((Exception) ex);
      }
      catch (IOException ex)
      {
        Logger.Log(TraceLevel.Critical, ex.Message);
        throw new VCloudRuntimeException((Exception) ex);
      }
      catch (Exception ex)
      {
        Logger.Log(TraceLevel.Critical, ex.Message);
        throw new VCloudRuntimeException(ex);
      }
      finally
      {
        httpClient.DefaultRequestHeaders.Clear();
      }
      return response;
    }

    public static Response Post(
      vCloudClient client,
      string url,
      string content,
      string contentType,
      string charset)
    {
      HttpClient httpClient = client.HttpClient;
      Response response = new Response();
      string str = (string) null;
      int num = 0;
      Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.POST_URL_MSG) + " - " + url);
      try
      {
        HttpContent content1 = (HttpContent) null;
        if (!httpClient.DefaultRequestHeaders.Contains("Accept"))
          httpClient.DefaultRequestHeaders.Add("Accept", vCloudClient.SUPPORTED_SDK_VERSIONS[client.VcloudClientVersion]);
        if (!httpClient.DefaultRequestHeaders.Contains(client.VcloudTokenHeader))
          httpClient.DefaultRequestHeaders.Add(client.VcloudTokenHeader, client.VcloudToken);
        if (content != null && content.Length > 0 && (contentType != null && contentType.Length > 0))
        {
          Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.POST_REQUEST_BODY) + " - " + content);
          Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.POST_CONTENT_TYPE) + " - " + contentType);
          content1 = (HttpContent) new StringContent(content, Encoding.UTF8, contentType);
        }
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
        HttpResponseMessage httpResponseMessage1;
        HttpResponseMessage httpResponseMessage2;
        if (content1 != null)
          httpResponseMessage2 = httpResponseMessage1 = httpClient.PostAsync(new System.Uri(url), content1).Result;
        else
          httpResponseMessage1 = httpResponseMessage2 = httpClient.SendAsync(request).Result;
        using (httpResponseMessage2)
        {
          if (httpResponseMessage1 != null)
          {
            num = (int) httpResponseMessage1.StatusCode;
            str = SerializationUtil.UTF8ByteArrayToString(httpResponseMessage1.Content.ReadAsByteArrayAsync().Result);
          }
          response.ResponseStatusCode = num;
          Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.STATUS_CODE_MSG) + " - " + (object) num);
          Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.STATUS_MSG) + " - " + httpResponseMessage1.StatusCode.ToString());
          response.ResponseXml = str;
          Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.RESPONSE_MSG) + " - " + str);
        }
      }
      catch (HttpRequestException ex)
      {
        Logger.Log(TraceLevel.Critical, ex.Message);
        throw new VCloudRuntimeException((Exception) ex);
      }
      catch (ApplicationException ex)
      {
        Logger.Log(TraceLevel.Critical, ex.Message);
        throw new VCloudRuntimeException((Exception) ex);
      }
      catch (IOException ex)
      {
        Logger.Log(TraceLevel.Critical, ex.Message);
        throw new VCloudRuntimeException((Exception) ex);
      }
      finally
      {
        httpClient.DefaultRequestHeaders.Clear();
      }
      return response;
    }

    internal static Response GetSupportedVersions(vCloudClient client, string url)
    {
      HttpClient httpClient = client.HttpClient;
      Response response = new Response();
      string str = (string) null;
      int num = 0;
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_SUPPORTED_VERSIONS_URL_MSG) + " - " + url);
        using (HttpResponseMessage result = httpClient.GetAsync(new System.Uri(url)).Result)
        {
          if (result != null)
          {
            num = (int) result.StatusCode;
            str = SerializationUtil.UTF8ByteArrayToString(result.Content.ReadAsByteArrayAsync().Result);
          }
          response.ResponseStatusCode = num;
          Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.STATUS_CODE_MSG) + " - " + (object) num);
          Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.STATUS_MSG) + " - " + result.StatusCode.ToString());
          response.ResponseXml = str;
          Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.RESPONSE_MSG) + " - " + str);
        }
      }
      catch (HttpRequestException ex)
      {
        Logger.Log(TraceLevel.Critical, ex.Message + url);
        throw new VCloudRuntimeException((Exception) ex);
      }
      catch (IOException ex)
      {
        Logger.Log(TraceLevel.Critical, ex.Message);
        throw new VCloudRuntimeException((Exception) ex);
      }
      return response;
    }

    public static Response Get(vCloudClient client, string url)
    {
      HttpClient httpClient = client.HttpClient;
      Response response = new Response();
      string str = (string) null;
      int num = 0;
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + url);
        if (!httpClient.DefaultRequestHeaders.Contains("Accept"))
          httpClient.DefaultRequestHeaders.Add("Accept", vCloudClient.SUPPORTED_SDK_VERSIONS[client.VcloudClientVersion]);
        if (!httpClient.DefaultRequestHeaders.Contains(client.VcloudTokenHeader))
          httpClient.DefaultRequestHeaders.Add(client.VcloudTokenHeader, client.VcloudToken);
        using (HttpResponseMessage result = httpClient.GetAsync(new System.Uri(url)).Result)
        {
          if (result != null)
          {
            num = (int) result.StatusCode;
            str = SerializationUtil.UTF8ByteArrayToString(result.Content.ReadAsByteArrayAsync().Result);
          }
          response.ResponseStatusCode = num;
          Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.STATUS_CODE_MSG) + " - " + (object) num);
          Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.STATUS_MSG) + " - " + result.StatusCode.ToString());
          response.ResponseXml = str;
          Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.RESPONSE_MSG) + " - " + str);
        }
      }
      catch (HttpRequestException ex)
      {
        Logger.Log(TraceLevel.Critical, ex.Message + url);
        throw new VCloudRuntimeException((Exception) ex);
      }
      catch (IOException ex)
      {
        Logger.Log(TraceLevel.Critical, ex.Message);
        throw new VCloudRuntimeException((Exception) ex);
      }
      finally
      {
        httpClient.DefaultRequestHeaders.Clear();
      }
      return response;
    }

    public static void UploadFile(
      vCloudClient client,
      FileType file,
      Stream stream,
      long size,
      long startByte,
      long endByte)
    {
      try
      {
        string defaultUploadUrl = RestUtil.GetDefaultUploadURL(file);
        RestUtil.UploadFile(client, file.name, defaultUploadUrl, stream, size, startByte, endByte);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private static void UploadFile(
      vCloudClient client,
      string fileName,
      string fileURL,
      Stream inputStreams,
      long size,
      long startByte,
      long endByte)
    {
      HttpClient httpClient = client.HttpClient;
      Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.UPLOAD_FILE_SIZE_MSG) + " - " + fileName + "\t Total Size " + (object) size);
      try
      {
        long num = size;
        HttpContent httpContent = (HttpContent) new StreamContent(inputStreams);
        if (endByte > startByte)
        {
          num = endByte - startByte + 1L;
          Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.UPLOAD_FILE_SIZE_MSG) + " - " + fileName + "\t" + (object) size + "\t Upload \t" + (object) startByte + " to \t" + (object) endByte);
          ContentRangeHeaderValue rangeHeaderValue = new ContentRangeHeaderValue(startByte, endByte, size);
          httpContent.Headers.ContentRange = rangeHeaderValue;
        }
        httpContent.Headers.ContentLength = new long?(num);
        if (!httpClient.DefaultRequestHeaders.Contains(client.VcloudTokenHeader))
          httpClient.DefaultRequestHeaders.Add(client.VcloudTokenHeader, client.VcloudToken);
        HttpContent content = (HttpContent) new StreamContent(inputStreams);
        using (HttpResponseMessage result = httpClient.PutAsync(new System.Uri(fileURL), content).Result)
        {
          if (result == null)
            return;
          string message = SerializationUtil.UTF8ByteArrayToString(result.Content.ReadAsByteArrayAsync().Result);
          if (result.StatusCode == HttpStatusCode.OK)
          {
            Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.UPLOAD_COMPLETE_MSG) + " - " + fileName);
          }
          else
          {
            Logger.Log(TraceLevel.Critical, SdkUtil.GetI18nString(SdkMessage.UPLOAD_FAILED_MSG) + " - " + fileURL);
            Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.STATUS_MSG) + " - " + result.StatusCode.ToString());
            Logger.Log(TraceLevel.Information, message);
            Logger.Log(TraceLevel.Critical, SdkUtil.GetI18nString(SdkMessage.FILE_UPLOAD_FAILED_MSG) + " - " + fileURL);
          }
        }
      }
      catch (HttpRequestException ex)
      {
        Logger.Log(TraceLevel.Critical, SdkUtil.GetI18nString(SdkMessage.HTTP_EXCEPTION__UPLOADING_MSG) + " - " + fileURL);
        throw new VCloudRuntimeException((Exception) ex);
      }
      catch (IOException ex)
      {
        Logger.Log(TraceLevel.Critical, SdkUtil.GetI18nString(SdkMessage.IO_EXCEPTION_UPLOADING_MSG) + " - " + fileURL);
        throw new VCloudRuntimeException((Exception) ex);
      }
      finally
      {
        inputStreams.Dispose();
        httpClient.DefaultRequestHeaders.Clear();
      }
    }

    private static string GetDefaultUploadURL(FileType file)
    {
      string str = (string) null;
      LinkType[] link = file.Link;
      if (link != null)
      {
        foreach (LinkType linkType in link)
        {
          if (linkType.rel.Equals("upload:default"))
          {
            str = linkType.href;
            break;
          }
        }
      }
      return str;
    }

    public static Stream DownloadFile(vCloudClient client, string downloadURL)
    {
      HttpClient httpClient = client.HttpClient;
      Stream inputStream = (Stream) null;
      HttpStatusCode httpStatusCode = (HttpStatusCode) 0;
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.DOWNLOAD_URL_MSG) + " - " + downloadURL);
        if (!httpClient.DefaultRequestHeaders.Contains("Accept"))
          httpClient.DefaultRequestHeaders.Add("Accept", vCloudClient.SUPPORTED_SDK_VERSIONS[client.VcloudClientVersion]);
        if (!httpClient.DefaultRequestHeaders.Contains(client.VcloudTokenHeader))
          httpClient.DefaultRequestHeaders.Add(client.VcloudTokenHeader, client.VcloudToken);
        using (HttpResponseMessage result = httpClient.GetAsync(new System.Uri(downloadURL)).Result)
        {
          if (result != null)
          {
            httpStatusCode = result.StatusCode;
            inputStream = (Stream) new MemoryStream(result.Content.ReadAsByteArrayAsync().Result);
          }
          Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.STATUS_CODE_MSG) + " - " + (object) httpStatusCode);
          Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.STATUS_MSG) + " - " + result.StatusCode.ToString());
        }
      }
      catch (HttpRequestException ex)
      {
        Logger.Log(TraceLevel.Critical, ex.Message + " - " + downloadURL);
        throw new VCloudRuntimeException((Exception) ex);
      }
      catch (IOException ex)
      {
        Logger.Log(TraceLevel.Critical, ex.Message);
        throw new VCloudRuntimeException((Exception) ex);
      }
      if (httpStatusCode == HttpStatusCode.OK)
        return inputStream;
      if (inputStream != null)
        throw new VCloudException(SerializationUtil.DeserializeObject<ErrorType>(inputStream, "com.vmware.vcloud.api.rest.schema"));
      throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.DOWNLOAD_FAILED_MSG) + " - " + downloadURL);
    }

    public static class SdkStatusCode
    {
      public const int SC_OK = 200;
      public const int SC_CREATED = 201;
      public const int SC_ACCEPTED = 202;
      public const int SC_NO_CONTENT = 204;
      public const int SC_MOVED_TEMPORARILY = 301;
    }
  }
}
