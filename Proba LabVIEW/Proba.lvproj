<?xml version='1.0' encoding='UTF-8'?>
<Project Type="Project" LVVersion="11008008">
	<Property Name="varPersistentID:{BD8926F3-B8FA-47A9-B264-F8F1D04F4ADE}" Type="Ref">/My Computer/jure.lvlib/ovoradiSingle</Property>
	<Property Name="varPersistentID:{DEC62371-A356-4F6B-9A6E-717D05AFE2D3}" Type="Ref">/My Computer/jure.lvlib/ovoSingle</Property>
	<Property Name="varPersistentID:{EAEAFCA2-6EFF-437F-AC41-7C335D9FCE91}" Type="Ref">/My Computer/jure.lvlib/Single</Property>
	<Item Name="My Computer" Type="My Computer">
		<Property Name="server.app.propertiesEnabled" Type="Bool">true</Property>
		<Property Name="server.control.propertiesEnabled" Type="Bool">true</Property>
		<Property Name="server.tcp.enabled" Type="Bool">false</Property>
		<Property Name="server.tcp.port" Type="Int">0</Property>
		<Property Name="server.tcp.serviceName" Type="Str">My Computer/VI Server</Property>
		<Property Name="server.tcp.serviceName.default" Type="Str">My Computer/VI Server</Property>
		<Property Name="server.vi.callsEnabled" Type="Bool">true</Property>
		<Property Name="server.vi.propertiesEnabled" Type="Bool">true</Property>
		<Property Name="specify.custom.address" Type="Bool">false</Property>
		<Item Name="Control 1.ctl" Type="VI" URL="../Control 1.ctl"/>
		<Item Name="Ispitivanje.vi" Type="VI" URL="../Ispitivanje.vi"/>
		<Item Name="jure.lvlib" Type="Library" URL="../jure.lvlib"/>
		<Item Name="Dependencies" Type="Dependencies"/>
		<Item Name="Build Specifications" Type="Build"/>
	</Item>
</Project>
