targetScope = 'resourceGroup'

param zoneName string
param staticWebAppHostName string

resource zone 'Microsoft.Network/dnsZones@2018-05-01' = {
  name: zoneName
  location: 'global'
}

resource record 'Microsoft.Network/dnsZones/CNAME@2018-05-01' = {
  name: 'www'
  parent: zone
  properties: {
    TTL: 3600
    CNAMERecord: {
      cname: staticWebAppHostName
    }
  }
}
