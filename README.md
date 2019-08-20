# vcloud-auth-issue

Reproducing vCloud authentication issue

## Steps

Clone repository

```bash
git clone https://github.com/reisbel/vcloud-auth-issue.git
```

Update app.config credentials

```xml
 <add key="vcloud.user" value="user@org"/>
 <add key="vcloud.pass" value="REPLACE WITH PASSWORD"/>
 <add key="vcloud.url" value="https://cloud.ussignalcom.net"/>
 ```

Open solution using Visual Studio and execute the application, see error below:

```output
Error: The given key was not present in the dictionary.
```

## Dependencies

Visual Studio
<https://visualstudio.microsoft.com/vs/>

vCloud SDK for .Net, version 5.5.0-1294396
<https://code.vmware.com/web/sdk/5.5.0-1294396/vcloud-dotnet>

## License

MIT - See [LICENSE](LICENSE) for more information.
