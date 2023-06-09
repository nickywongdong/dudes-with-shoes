targetScope = 'subscription'

param resourceGroupName string
param location string
param repositoryUrl string
param webAppName string
param deploymentId string = utcNow()
param branch string
param zoneName string

resource rg 'Microsoft.Resources/resourceGroups@2021-04-01' = {
  name: resourceGroupName
  location: location
}

module app 'staticWebApp.bicep' = {
  name: 'dep-staticWebApp-${deploymentId}'
  scope: rg
  params: {
    name: webAppName
    location: rg.location
    repositoryUrl: repositoryUrl
    branch: branch
  }
}

module dnsZone 'dnsZone.bicep' = {
  name: 'dep-dnsZone-${deploymentId}'
  scope: rg
  params: {
    zoneName: zoneName
    staticWebAppHostName: app.outputs.staticWebAppHostName
  }
}

module customDomain 'staticSiteCustomDomain.bicep' = {
  name: 'custom-domain-${deploymentId}'
  scope: rg
  params: {
    zoneName: zoneName
    staticWebAppResourceName: webAppName
  }
}
