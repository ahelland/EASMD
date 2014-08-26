##EAS MD##

**Exchange ActiveSync Diagnostic Utility**

EAS MD is a desktop application that will let you perform ActiveSync commands against an Exchange Server like a mobile device. This is intented as a diagnostic utility that will let you verify the configuration and/or troubleshoot issues in your Exchange ActiveSync deployment.

This Visual Studio solution consists of two projects:  

- EAS_Diag 
	- The app you run and the interface belonging to it.
- EAS Protocol
	- The library handling conversion to/from WBXML, and the "back-end" of the protocol.

For background info on how it works: 
<http://mobilitydojo.net/2010/03/17/digging-into-the-exchange-activesync-protocol/>  
<http://mobilitydojo.net/2010/03/30/rolling-your-own-exchange-activesync-client/>

