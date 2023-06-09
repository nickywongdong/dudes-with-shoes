targetScope = 'resourceGroup'

param name string
param location string = resourceGroup().location
param repositoryUrl string
param branch string
param zoneName string

resource swa 'Microsoft.Web/staticSites@2022-03-01' = {
  name: name
  location: location
  sku: {
    name: 'Free'
    tier: 'Free'
  }
  properties: {
    repositoryUrl: repositoryUrl
    branch: branch
    stagingEnvironmentPolicy: 'Enabled'
    allowConfigFileUpdates: true
    provider: 'GitHub'
    enterpriseGradeCdnStatus: 'Disabled'
  }
}
resource symbolicname 'Microsoft.Web/staticSites/customDomains@2022-03-01' = {
  name: 'www.${zoneName}'
  parent: swa
}

output staticWebAppHostName string = swa.properties.defaultHostname
