<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="ProjectSuperMarket" generation="1" functional="0" release="0" Id="6ae89e36-3528-40d4-8993-063bda7a2c99" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="ProjectSuperMarketGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="ProjectSuperMarket.Web:HttpIn" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/ProjectSuperMarket/ProjectSuperMarketGroup/LB:ProjectSuperMarket.Web:HttpIn" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="ProjectSuperMarket.WebInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/ProjectSuperMarket/ProjectSuperMarketGroup/MapProjectSuperMarket.WebInstances" />
          </maps>
        </aCS>
        <aCS name="ProjectSuperMarket.Web:DiagnosticsConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/ProjectSuperMarket/ProjectSuperMarketGroup/MapProjectSuperMarket.Web:DiagnosticsConnectionString" />
          </maps>
        </aCS>
        <aCS name="ProjectSuperMarket.Web:DataConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/ProjectSuperMarket/ProjectSuperMarketGroup/MapProjectSuperMarket.Web:DataConnectionString" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:ProjectSuperMarket.Web:HttpIn">
          <toPorts>
            <inPortMoniker name="/ProjectSuperMarket/ProjectSuperMarketGroup/ProjectSuperMarket.Web/HttpIn" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapProjectSuperMarket.WebInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/ProjectSuperMarket/ProjectSuperMarketGroup/ProjectSuperMarket.WebInstances" />
          </setting>
        </map>
        <map name="MapProjectSuperMarket.Web:DiagnosticsConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/ProjectSuperMarket/ProjectSuperMarketGroup/ProjectSuperMarket.Web/DiagnosticsConnectionString" />
          </setting>
        </map>
        <map name="MapProjectSuperMarket.Web:DataConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/ProjectSuperMarket/ProjectSuperMarketGroup/ProjectSuperMarket.Web/DataConnectionString" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="ProjectSuperMarket.Web" generation="1" functional="0" release="0" software="C:\Users\Narendra\Documents\Visual Studio 2008\Projects\ProjectSuperMarket\ProjectSuperMarket\obj\Debug\ProjectSuperMarket.Web\" entryPoint="base\x86\WaWebHost.exe" parameters="" memIndex="1792" hostingEnvironment="frontendfulltrust" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="HttpIn" protocol="http" />
            </componentports>
            <settings>
              <aCS name="DiagnosticsConnectionString" defaultValue="" />
              <aCS name="DataConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;ProjectSuperMarket.Web&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;ProjectSuperMarket.Web&quot;&gt;&lt;e name=&quot;HttpIn&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/ProjectSuperMarket/ProjectSuperMarketGroup/ProjectSuperMarket.WebInstances" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyID name="ProjectSuperMarket.WebInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="8265acb6-fa49-4f95-8f3c-e4f4db9134a4" ref="Microsoft.RedDog.Contract\ServiceContract\ProjectSuperMarketContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="fd994ae2-0b44-44db-8595-e7e9ddce95b2" ref="Microsoft.RedDog.Contract\Interface\ProjectSuperMarket.Web:HttpIn@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/ProjectSuperMarket/ProjectSuperMarketGroup/ProjectSuperMarket.Web:HttpIn" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>