targetScope = 'resourceGroup'

param zoneName string
var customDomainName = 'www.${zoneName}'


resource customDomain 'Microsoft.Web/staticSites/customDomains@2022-03-01' = {
  name: customDomainName
}
