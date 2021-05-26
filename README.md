# IBM Watson Speech To Text
### Simple applcation on how to use IBM Watson Speech To Text service, which converts the given audio file to text

![image](https://user-images.githubusercontent.com/49093331/119618543-98246c00-be35-11eb-85e7-04883ccbc16f.png)

This code example use the client library that is provided for .NET Standard.
```sh
dotnet add package IBM.Watson.SpeechToText.v1 --version 5.1.0
```
#### You authenticate to the API by using IBM Cloud Identity and Access Management (IAM).
You can pass either a bearer token in an authorization header or an API key, for this example I used API key.

First you need to subscribe to [Speech to Text](https://cloud.ibm.com/apidocs/speech-to-text?code=dotnet-standard) service from IBM's cloud shell from there you will get {apikey} and {apiServiceUrl}
You pass in the {apikey} and {apiServiceUrl} in config file Transcriber.dll.Config <appSettings> section.

```sh
	<appSettings>
		<add key="apiKey" value="XXXXXXXXXXXXXXXXXXXXXXXX"/>
		<add key="apiServiceUrl" value="XXXXXXXXXXXXXXXXXXXXXXXXXXXX"/>
		<add key="AudioFilesPath" value="audio"/>
		<add key="SupportedAudioFormat" value="flac|mp3|mpeg|wav"/>
		<add key="TextFilesPath" value="text"/>
	</appSettings>
  ```
  
  Inside application path you will see 2 folders
  1. audio - which is input to this application
  2. text - which is output from this application
  
  ![image](https://user-images.githubusercontent.com/49093331/119621683-fdc62780-be38-11eb-819d-e6d6d7599c18.png)
  
  Many things to explore in this [Speech to Text](https://cloud.ibm.com/apidocs/speech-to-text?code=dotnet-standard) service, I just touched the very basic feature.
  
  Kindly let me know if you have any suggestions.
  
  Thank you.
