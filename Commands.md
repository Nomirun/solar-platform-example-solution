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
nomi module build --module-name Accounts --module-version 94.0.0 --nuget-server-name "GitHub"
nomi module build --module-name Reports --module-version 94.0.0 --nuget-server-name "GitHub"
nomi module build --module-name SolarInverters --module-version 94.0.0 --nuget-server-name "GitHub"
nomi library build -m SolarPlatformCommon -v 1.0.2 --nuget-server-name "GitHub"














# 4. Build standalone app for SolarPlatform
nomi cluster new --cluster-name SolarPlatformWinStandalone
nomi cluster add-host --cluster-name SolarPlatformWinStandalone --host-name AccountAndSolarService --modules "Accounts@94.0.0;SolarInverters@94.0.0" --host-framework net10.0 --host-platform win-x64
nomi cluster add-host --cluster-name SolarPlatformWinStandalone --host-name ReportingService --modules "Reports@94.0.0"  --host-framework net10.0 --host-platform win-x64
nomi cluster configure -c SolarPlatformWinStandalone --nuget-server-name "GitHub"
nomi cluster build --cluster-name SolarPlatformWinStandalone -t Standalone -o c:\nomirun
nomi cluster start --cluster-name SolarPlatformWinStandalone
nomi cluster stop --cluster-name SolarPlatformWinStandalone





















# 5. Build containers for SolarPlatform
nomi cluster new --cluster-name SolarPlatformKubernetes
nomi cluster add-host --cluster-name SolarPlatformKubernetes --host-name AccountAndSolarServiceLinux --modules "Accounts@94.0.0;SolarInverters@94.0.0" --host-framework net10.0 --host-platform linux-musl-x64
nomi cluster add-host --cluster-name SolarPlatformKubernetes --host-name ReportingServiceLinux --modules "Reports@94.0.0" --host-framework net10.0 --host-platform linux-musl-x64
nomi cluster configure -c SolarPlatformKubernetes --nuget-server-name "GitHub" -h Container
nomi cluster generate --cluster-name SolarPlatformKubernetes -t DockerEnvFile
nomi cluster start --cluster-name SolarPlatformKubernetes -t Container
nomi cluster stop --cluster-name SolarPlatformKubernetes -t Container
nomi cluster build --cluster-name SolarPlatformKubernetes -t Container --docker-image-tag v1 --generate-docker-compose










# 6. Build only one cluster host
nomi cluster build-host --cluster-name SolarPlatformKubernetes --host-name AccountAndSolarServiceLinux -t Container --docker-image-tag v2 --generate-docker-compose












# 7. Show AI generation for the demo project
nomi generate swagger -m Accounts
nomi generate swagger -m Reports
nomi generate swagger -m SolarInverters
















# 8. Add a new module to the solution
nomi solution new-module -m Billing
```


