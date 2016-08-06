# HostIndependentWCFService

Host independent service using console as well window app
All separate project (service, host, datacontracts, proxy, client)
Using custom client proxy (ClientBase<IService>) and channel factory to communicate with server
Use contract equivalance to match contracts on client and servcer side
configure programatically without any config file.


Console app host independent service
Window app host the service in the same application using ServiceHost
DataContracts is to share between service and client
Config files only includes end points.
  client app (not proxy) mentioned end points for client
  Host app (not service) mention end point for service
