##EAS_Diag##

**EAS Diagnostic Utility Desktop Application**

This Visual Studio Project contains the files for the application the user runs.

The app contains a number of tabs for different features. Most of them related to the ActiveSync tests, but some of them can be used outside the Exchange specific tasks as well.

**Main**  
Where the "action" happens. Fill in the necessary properties and run either the basic or full sync test.  
"Basic" will perform an HTTP OPTIONS and HTTP GET, and will give you a general idea of the Exchange Server is reachable, but will not generate actual ActiveSync traffic.
"Full" will do the same tests as "Basic", but will also attempt to execute a FolderSync. This means it's able to test on a user-level if ActiveSync is actually working.

**Device Information**  
The properties for the device we're faking. For EAS protocol version 14.1 these properties will be registered and viewable in Outlook Web App afterwards.  
Default values are provided so it's not necessary to change these if you're not looking to test the Quarantine/Block/Allow feature server side.

**Autodiscover**  
Used to perform autodiscovery tests to verify is the Exchange Server can be located through predefined dns lookups based on the email address and/or username.

**WBXML Utility**  
Used for encoding readable XML to Windows Binary XML format. Actual ActiveSync commands are passed along the HTTP POSTs in this format.  
The original thought was to create a "wizard" for building WBXML documents, but it's not entirely there at the moment.

**Certificate Info**  
Used to retrieve the SSL certificate chain from any given dns address. This is useful to verify that the chain is as expected, and gives the ability to see if there's an untrusted intermediate certificate or something similar.  
The output can be saved to .cer files by copy-pasting into a text editor.

**Information Rights Management**  
IRM is a feature for restricting what users can do to mails and attachments they sync from the Exchange Server. This could be things like enforcing the mail cannot be forwarded/printed/etc. This test verifies it's able to retrieve the policies defined on an IRM server connected to the Exchange Server.  
Not in very widespread usage due to lack of support in most ActiveSync clients.

**Base64 Utility**  
Used to encode plaintext to base64 format, and decode base64 to to plaintext. Useful for encoding the credentials used for authentication.