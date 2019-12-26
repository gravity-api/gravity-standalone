# gravity-standalone
Standalone implementation of Gravity API back-end on ASP.NET Core. The service can run on Windows, Linux, MacOS.  

Artifacts Location: <https://1drv.ms/f/s!AmRY2pH37JevdRPMYRvBV2QZgLs>

## Run the Service
You must have dotnet core installed on your machine you can download it here:
https://dotnet.microsoft.com/download  

1. Navigate to the folder where the compiled files are
2. execute the following command

```$ dotnet Gravity.Service.Standalone.dll```

## API - Orbit
### Status
Gets the status of this service (if it is running or if there is a problem).  

**GET** ```<your_server_address>/api/orbit```

### Web Automation
Executes the provided web automation sequence, based on actions, configuration and driver parameters provided. The request body is a WebAutomation data contract.  

**POST** ```<your_server_address>/api/orbit```  

```json
{
  "Authentication": {
    "Password": "myPass",
    "UserName": "myUser@mail.com"
  },
  "EngineConfiguration": {
    "ElementSearchingTimeout": 3000,
    "PageLoadTimeout": 60000
  },
  "DriverParams": "{'Driver':'ChromeDriver','DriverBinaries':'.'}",
  "Actions": [
    {
      "ActionType": "GoToUrl",
      "Argument": "https://www.google.com"
    },
    {
      "ActionType": "SendKeys",
      "ElementToActOn": "//input[@name='q']",
      "Argument": "automation"
    },
    {
      "ActionType": "Click",
      "ElementToActOn": "//ul[@role='listbox']/li"
    },
    {
      "ActionType": "CloseBrowser"
    }
  ]
}
```  

## API - KB
### Actions  
Gets a list of all actions which were loaded under the current domain or gets a knowledge base of a specific action, provided it's name.  

**GET** ```<your_server_address>/api/kb/actions```  
**GET** ```<your_server_address>/api/kb/actions/<action_name>```  

### Macros
Gets a list of all macros which were loaded under the current domain or gets a knowledge base of a specific macro, provided it's name.  

**GET** ```<your_server_address>/api/kb/macros```  
**GET** ```<your_server_address>/api/kb/macros/<macro_name>```  

### Locators
Gets a list of all locators which were loaded under the current domain.  

**GET** ```<your_server_address>/api/kb/locators```  

### Data Source
Gets a list of all data source types which were loaded under the current domain.  

**GET** ```<your_server_address>/api/kb/sources```  

### Contracts
Gets a list of all data contract types which were loaded under the current domain or a specific contract, provided it's name.  

**GET** ```<your_server_address>/api/kb/contracts```  
**GET** ```<your_server_address>/api/kb/contracts/<contract_name>```
