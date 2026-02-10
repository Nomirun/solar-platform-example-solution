# 1. Nomirun Solution description

SolarPlatform is a distributed system designed for the management and monitoring of solar energy infrastructure. The solution is organized into the following projects:

- `src/SolarInverters` This Nomirun module responsible for managing solar inverter hardware.
- `src/Accounts` This Nomirun module manages the identity and access control aspect of the platform.
- `src/Reports` This Nomirun module focuses on reports.
- `src/SolarPlatformCommon` A shared library referenced by the other 3 projects. It contains common infrastructure, data transfer objects (Requests/Responses), and shared logic to ensure consistency across the platform's services.

# 2. Configure Nomirun CLI

First Install Nomirun CLI: https://nomirun.com/docs/getting-started/installation

Next you need to initialize Nomirun CLI: https://nomirun.com/docs/getting-started/init

Make sure you configure at least 1 NuGet repository. We recommend GitHub.

Then go to `<user_profile>\.nomirun` folder and create these 3 files.

## 2.1. modules.yaml

```yaml
modules:
- name: SolarInverters
  csproj: SolarPlatform\src\SolarInverters\SolarInverters.csproj
- name: Accounts
  csproj: SolarPlatform\src\Accounts\Accounts.csproj
- name: Reports
  csproj: SolarPlatform\src\Reports\Reports.csproj
```

## 2.2. libraries.yaml

```yaml
libraries:
- name: SolarPlatformCommon
  csproj: SolarPlatform\src\SolarPlatformCommon\SolarPlatformCommon.csproj
```

## 2.3. clusters.yaml

```yaml
clusters:
- name: SolarInverters
  hosts:
  - name: SolarInverters
    hostPath: \hosts\SolarInverters
    hostFramework: net10.0
    hostPlatform: win-x64
    hostVersion: latest
    hostPorts:
      httpPort: 5310
      httpsPort: 5311
      grpcPort: 5312
      grpcsPort: 5313
      metricsHttpPort: 5314
      metricsHttpsPort: 5315
    modules:
    - name: SolarInverters
      version: 
    extensions:
      - name: Nomirun.Host.OpenTelemetry
        version: 1.0.2
        hash: 58E4E33FB1943B51FBC4A346A24012104AA92B3F2F738F8B9EF83DC6A50343389D315BFB8F51F6CB6DDAB0F13BBFE87CFFD86A4F26D0FB4686D0C273F7A8C721
      - name: Nomirun.Host.Configuration.Azure.AppConfig
        version: 1.0.1
        hash: 466BC299145FBE10859F103014728BF50E12AE68A81660B72D0D93EC71E2270BAD7220BDA25FE7027AFE17E2E2AA78C131DF6465EF0AA858866E8B4882D6CE0F
      - name: Nomirun.Host.Configuration.Azure.KeyVault
        version: 1.0.1
        hash: 653AB2FBAC6A3D7D2D245CFB7B6D5F85399599561D8F5B285C020F8D549B67698EC3AB7C724D584A316AE6E82150D02731630AFCB36432FEF8B0868DAB4799B5
      - name: Nomirun.Host.Authentication.JwtBearer
        version: 1.0.0
        hash: 58E4E33FB1943B51FBC4A346A24012104AA92B3F2F738F8B9EF83DC6A50343389D315BFB8F51F6CB6DDAB0F13BBFE87CFFD86A4F26D0FB4686D0C273F7A8C721
    configuration:
      caching:
        type: Memory
        redisConnectionString: 
      metrics:
        enabled: true
        username: 
        password: 
      swagger:
        enabled: true
        username: 
        password: 
      otel:
        hostUrl: http://localhost:4317
        protocol: 
        headers: 
      serilog:
        using:
        - Serilog.Sinks.Console
        minimumLevel:
          default: Information
          override:
            microsoft: Information
            interceptorsHelper: Information
      rateLimiting:
        enabled: true
        policies:
        - endpoint: Global
          limit: 250
          periodInSeconds: 5
- name: Accounts
  hosts:
  - name: Accounts
    hostPath: \hosts\Accounts
    hostFramework: net10.0
    hostPlatform: win-x64
    hostVersion: latest
    hostPorts:
      httpPort: 5320
      httpsPort: 5321
      grpcPort: 5322
      grpcsPort: 5323
      metricsHttpPort: 5324
      metricsHttpsPort: 5325
    modules:
    - name: Accounts
      version: 
    extensions:
      - name: Nomirun.Host.OpenTelemetry
        version: 1.0.2
        hash: 58E4E33FB1943B51FBC4A346A24012104AA92B3F2F738F8B9EF83DC6A50343389D315BFB8F51F6CB6DDAB0F13BBFE87CFFD86A4F26D0FB4686D0C273F7A8C721
      - name: Nomirun.Host.Configuration.Azure.AppConfig
        version: 1.0.1
        hash: 466BC299145FBE10859F103014728BF50E12AE68A81660B72D0D93EC71E2270BAD7220BDA25FE7027AFE17E2E2AA78C131DF6465EF0AA858866E8B4882D6CE0F
      - name: Nomirun.Host.Configuration.Azure.KeyVault
        version: 1.0.1
        hash: 653AB2FBAC6A3D7D2D245CFB7B6D5F85399599561D8F5B285C020F8D549B67698EC3AB7C724D584A316AE6E82150D02731630AFCB36432FEF8B0868DAB4799B5
    configuration:
      caching:
        enabled: true
        type: Memory
        redisConnectionString: 
      metrics:
        enabled: true
        username: 
        password: 
      swagger:
        enabled: true
        username: 
        password: 
      otel:
        hostUrl: http://localhost:4317
        protocol: 
        headers: 
      serilog:
        using:
        - Serilog.Sinks.Console
        minimumLevel:
          default: Information
          override:
            microsoft: Information
            interceptorsHelper: Information
      rateLimiting:
        enabled: true
        policies:
        - endpoint: Global
          limit: 250
          periodInSeconds: 5
- name: Reports
  hosts:
  - name: Reports
    hostPath: \hosts\Reports
    hostFramework: net10.0
    hostPlatform: win-x64
    hostVersion: latest
    hostPorts:
      httpPort: 5330
      httpsPort: 5331
      grpcPort: 5332
      grpcsPort: 5333
      metricsHttpPort: 5334
      metricsHttpsPort: 5335
    modules:
    - name: Reports
      version: 
    extensions:
      - name: Nomirun.Host.OpenTelemetry
        version: 1.0.2
        hash: 58E4E33FB1943B51FBC4A346A24012104AA92B3F2F738F8B9EF83DC6A50343389D315BFB8F51F6CB6DDAB0F13BBFE87CFFD86A4F26D0FB4686D0C273F7A8C721
      - name: Nomirun.Host.Configuration.Azure.AppConfig
        version: 1.0.1
        hash: 466BC299145FBE10859F103014728BF50E12AE68A81660B72D0D93EC71E2270BAD7220BDA25FE7027AFE17E2E2AA78C131DF6465EF0AA858866E8B4882D6CE0F
      - name: Nomirun.Host.Configuration.Azure.KeyVault
        version: 1.0.1
        hash: 653AB2FBAC6A3D7D2D245CFB7B6D5F85399599561D8F5B285C020F8D549B67698EC3AB7C724D584A316AE6E82150D02731630AFCB36432FEF8B0868DAB4799B5
    configuration:
      caching:
        enabled: true
        type: Memory
        redisConnectionString: 
      metrics:
        enabled: true
        username: 
        password: 
      swagger:
        enabled: true
        username:
        password:
      otel:
        hostUrl: http://localhost:4317
        protocol: 
        headers: 
      serilog:
        using:
        - Serilog.Sinks.Console
        minimumLevel:
          default: Information
          override:
            microsoft: Information
            interceptorsHelper: Information
      rateLimiting:
        enabled: true
        policies:
        - endpoint: Global
          limit: 250
          periodInSeconds: 5
      configurationStores:
        azureKeyVault:
          name: ''
          managedIdentityId: ''
        azureAppConfig:
          name: ''
          managedIdentityId: ''
          label: ''
```

Now you can open the solution in your IDE / code editor and build the code.

# 3. Pull down this GIT repository

Pull down this git repository to `<user_profile>\.nomirun\repos`. The `repos` folder is created with `nomirun init` and is the standard folder where all new Nomirun modules are created. Since you are pulling down the code from this repository, clone it to that folder.

# 4. Run some commands to test it :)

Read out [Getting started guides](https://nomirun.com/docs/getting-started/development-configuration/).

## 4.1. Run the platform as microservices architecture

```powershell
nomi cluster new --cluster-name SolarPlatform
nomi cluster add-host --cluster-name SolarPlatform --host-name AccountService --modules "Accounts" --host-framework net10.0 --host-platform win-x64
nomi cluster add-host --cluster-name SolarPlatform --host-name ReportsService --modules "Reports" --host-framework net10.0 --host-platform win-x64
nomi cluster add-host --cluster-name SolarPlatform --host-name SolarInverterService --modules "SolarInverters" --host-framework net10.0 --host-platform win-x64
nomi cluster list
nomi cluster start --cluster-name SolarPlatform
nomi cluster stop --cluster-name SolarPlatform
```

## 4.2. Run the platform as modular monolith architecture

```powershell
nomi cluster new --cluster-name SolarPlatformMonolith
nomi cluster add-host --cluster-name SolarPlatformMonolith --host-name SolarPlatformService --modules "Accounts;Reports;SolarInverters"  --host-framework net10.0 --host-platform win-x64
nomi cluster list
nomi cluster start --cluster-name SolarPlatformMonolith
nomi cluster stop --cluster-name SolarPlatformMonolith
```

## 4.3. Build Modules

```powershell
nomi module build --module-name Accounts --module-version 1.0.0 --nuget-server-name "GitHub"
nomi module build --module-name Reports --module-version 1.0.0 --nuget-server-name "GitHub"
nomi module build --module-name SolarInverters --module-version 1.0.0 --nuget-server-name "GitHub"
nomi library build -m SolarPlatformCommon -v 1.0.0 --nuget-server-name "GitHub"
```

## 4.4. Run the platform as hybrid architecture

```powershell
nomi cluster new --cluster-name SolarPlatformLinux
nomi cluster add-host --cluster-name SolarPlatformLinux --host-name AccountAndSolarServiceLinux --modules "Accounts@1.0.0;SolarInverters@1.0.0" --host-framework net10.0 --host-platform linux-musl-x64
nomi cluster add-host --cluster-name SolarPlatformLinux --host-name ReportingServiceLinux --modules "Reports@1.0.0" --host-framework net10.0 --host-platform linux-musl-x64
nomi cluster configure -c SolarPlatformLinux --nuget-server-name "GitHub" -h Container
nomi cluster generate --cluster-name SolarPlatformLinux -t DockerEnvConfigFiles
nomi cluster start --cluster-name SolarPlatformLinux -t Container
nomi cluster stop --cluster-name SolarPlatformLinux -t Container
nomi cluster build --cluster-name SolarPlatformLinux -t Container --docker-image-tag v1 --generate-docker-compose
```

Configure and build as standalone

```powershell
nomi cluster configure -c SolarPlatformLinux --nuget-server-name "GitHub" -h Standalone
nomi cluster build --cluster-name SolarPlatformLinux -t Standalone -o c:\nomirun
```

## 4.5. Generate Swagger controller attributes with AI Agent

Read our documentation [here](https://nomirun.com/docs/getting-started/ai-agent-skills).