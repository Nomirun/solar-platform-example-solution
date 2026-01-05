```powershell
# 1. Run the platform as microservices
nomi cluster new --cluster-name SolarPlatform
nomi cluster add-host --cluster-name SolarPlatform --host-name AccountService --modules "Accounts" --host-framework net10.0 --host-platform win-x64
nomi cluster add-host --cluster-name SolarPlatform --host-name ReportsService --modules "Reports" --host-framework net10.0 --host-platform win-x64
nomi cluster add-host --cluster-name SolarPlatform --host-name SolarInverterService --modules "SolarInverters" --host-framework net10.0 --host-platform win-x64
nomi cluster list
nomi cluster start --cluster-name SolarPlatform
nomi cluster stop --cluster-name SolarPlatform

# 2. Run the platform as modular monolith
nomi cluster new --cluster-name SolarPlatformMonolith
nomi cluster add-host --cluster-name SolarPlatformMonolith --host-name SolarPlatformService --modules "Accounts;Reports;SolarInverters"  --host-framework net10.0 --host-platform win-x64
nomi cluster list
nomi cluster start --cluster-name SolarPlatformMonolith
nomi cluster stop --cluster-name SolarPlatformMonolith

# 3. Build Modules
nomi module build --module-name Accounts --module-version 1.0.0 --nuget-server-name "GitHub"
nomi module build --module-name Reports --module-version 1.0.0 --nuget-server-name "GitHub"
nomi module build --module-name SolarInverters --module-version 1.0.0 --nuget-server-name "GitHub"
nomi library build -m SolarPlatformCommon -v 1.0.0 --nuget-server-name "GitHub"

# 4. Build containers for SolarPlatform hybrid cluster
nomi cluster new --cluster-name SolarPlatformLinux
nomi cluster add-host --cluster-name SolarPlatformLinux --host-name AccountAndSolarServiceLinux --modules "Accounts@1.0.0;SolarInverters@1.0.0" --host-framework net10.0 --host-platform linux-musl-x64
nomi cluster add-host --cluster-name SolarPlatformLinux --host-name ReportingServiceLinux --modules "Reports@1.0.0" --host-framework net10.0 --host-platform linux-musl-x64
nomi cluster configure -c SolarPlatformLinux --nuget-server-name "GitHub" -h Container
nomi cluster generate --cluster-name SolarPlatformLinux -t DockerEnvFile
nomi cluster start --cluster-name SolarPlatformLinux -t Container
nomi cluster stop --cluster-name SolarPlatformLinux -t Container
nomi cluster build --cluster-name SolarPlatformLinux -t Container --docker-image-tag v1 --generate-docker-compose

# Configure and build as standalone
nomi cluster configure -c SolarPlatformLinux --nuget-server-name "GitHub" -h Standalone
nomi cluster build --cluster-name SolarPlatformLinux -t Standalone -o c:\nomirun

# AI generation for SolarInverters module
nomi generate swagger -m SolarInverters
```
