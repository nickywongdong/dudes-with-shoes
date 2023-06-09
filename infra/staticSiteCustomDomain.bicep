targetScope = 'resourceGroup'

param zoneName string
param staticWebAppResourceName string

var customDomainName = 'www.${zoneName}'

resource swa 'Microsoft.Web/staticSites@2022-03-01' existing = {
  name: staticWebAppResourceName
}

resource customDomain 'Microsoft.Web/staticSites/customDomains@2022-03-01' = {
  parent: swa
  name: customDomainName
}
