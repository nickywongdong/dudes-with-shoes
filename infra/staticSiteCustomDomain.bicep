targetScope = 'resourceGroup'

param zoneName string
param location string = resourceGroup().location
param staticWebAppResourceName string

resource swa 'Microsoft.Web/staticSites@2022-03-01' = {
  name: staticWebAppResourceName
  location: location

  resource symbolicname 'customDomains@2022-03-01' = {
    name: 'www.${zoneName}'
  }
}
