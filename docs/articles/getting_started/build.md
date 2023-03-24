### Build Locally

To get a local copy built, follow these simple example steps.

1. Obtain an API key from [National Rail Enquiries](http://realtime.nationalrail.co.uk/OpenLDBWSRegistration/)
2. Clone the repository
   ```sh
   git clone https://github.com/rhys-wootton/Darwin.Net.git
   ```
3. Create an `app.config` file within the Darwin.Net project and add the following
   ```xml
   <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
        <appSettings>
            <add key="DarwinApiKey" value="YOUR_API_KEY" />
            <add key="DarwinUrl" value="https://lite.realtime.nationalrail.co.uk/OpenLDBWS/ldb12.asmx"/>
            <add key="DarwinActionNameUrl" value="http://thalesgroup.com/RTTI/2021-11-01/ldb/"/>
            <add key="DarwinTokenTypeUrl" value="http://thalesgroup.com/RTTI/2013-11-28/Token/types"/>
        </appSettings>
    </configuration>
   ```
4. Build  the project