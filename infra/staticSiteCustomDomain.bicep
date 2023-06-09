targetScope = 'resourceGroup'

param zoneName string
param staticWebAppResourceName string

resource swa 'Microsoft.Web/staticSites@2022-03-01' existing = {
  name: staticWebAppResourceName
}

resource symbolicname 'Microsoft.Web/staticSites/customDomains@2022-03-01' = {
  name: 'www.${zoneName}'
}
