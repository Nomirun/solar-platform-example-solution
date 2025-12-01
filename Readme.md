# Solution Documentataion

SolarPlatform is a distributed system designed for the management and monitoring of solar energy infrastructure. The solution is organized into the following projects:

- `src/SolarInverters` This is the core domain module responsible for managing solar inverter hardware. It likely handles device registration, telemetry data ingestion, and configuration of solar inverters.
- `src/Accounts` This module manages the identity and access control aspect of the platform. It is responsible for user registration, authentication, profile management, and potentially tenant handling for different solar installations.
- `src/Reports` This project focuses on data analytics and output. It aggregates data (likely from the Inverters module) to generate usage reports, energy production statistics, and performance summaries.
- `src/SolarPlatformCommon` A shared library referenced by the other projects. It contains common infrastructure, data transfer objects (Requests/Responses), and shared logic to ensure consistency across the platform's services.

## 1. Run the platform as microservices architecture

```powershell
nomi cluster new --cluster-name SolarPlatform
nomi cluster add-host --cluster-name SolarPlatform --host-name AccountService --modules "Accounts" --host-framework net10.0 --host-platform win-x64
nomi cluster add-host --cluster-name SolarPlatform --host-name ReportsService --modules "Reports" --host-framework net10.0 --host-platform win-x64
nomi cluster add-host --cluster-name SolarPlatform --host-name SolarInverterService --modules "SolarInverters" --host-framework net10.0 --host-platform win-x64
nomi cluster list
nomi cluster start --cluster-name SolarPlatform
nomi cluster stop --cluster-name SolarPlatform
```

## 2. Run the platform as modular monolith architecture

```powershell
nomi cluster new --cluster-name SolarPlatformMonolith
nomi cluster add-host --cluster-name SolarPlatformMonolith --host-name SolarPlatformService --modules "Accounts;Reports;SolarInverters"  --host-framework net10.0 --host-platform win-x64
nomi cluster list
nomi cluster start --cluster-name SolarPlatformMonolith
nomi cluster stop --cluster-name SolarPlatformMonolith
```

## 3. Build Modules

```powershell
nomi module build --module-name Accounts --module-version 1.0.0 --nuget-server-name "GitHub"
nomi module build --module-name Reports --module-version 1.0.0 --nuget-server-name "GitHub"
nomi module build --module-name SolarInverters --module-version 1.0.0 --nuget-server-name "GitHub"
nomi library build -m SolarPlatformCommon -v 1.0.0 --nuget-server-name "GitHub"
```

## 4. Run the platform as hybrid architecture

```powershell
nomi cluster new --cluster-name SolarPlatformLinux
nomi cluster add-host --cluster-name SolarPlatformLinux --host-name AccountAndSolarServiceLinux --modules "Accounts@1.0.0;SolarInverters@1.0.0" --host-framework net10.0 --host-platform linux-musl-x64
nomi cluster add-host --cluster-name SolarPlatformLinux --host-name ReportingServiceLinux --modules "Reports@1.0.0" --host-framework net10.0 --host-platform linux-musl-x64
nomi cluster configure -c SolarPlatformLinux --nuget-server-name "GitHub" -h Container
nomi cluster generate --cluster-name SolarPlatformLinux -t DockerEnvFile
nomi cluster start --cluster-name SolarPlatformLinux -t Container
nomi cluster stop --cluster-name SolarPlatformLinux -t Container
nomi cluster build --cluster-name SolarPlatformLinux -t Container --docker-image-tag v1 --generate-docker-compose
```

Configure and build as standalone

```powershell
nomi cluster configure -c SolarPlatformLinux --nuget-server-name "GitHub" -h Standalone
nomi cluster build --cluster-name SolarPlatformLinux -t Standalone -o c:\nomirun
```

## 5. Generate Swagger controller attributes with AI

```powershell
nomi generate swagger -m Accounts
nomi generate swagger -m Reports
nomi generate swagger -m SolarInverters
```