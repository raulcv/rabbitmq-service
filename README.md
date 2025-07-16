## RabbitMQ + dotnet 8 [C#] service

Example of event manager with RabbitMQ in dotnet 8

#### Services appp

- sender
- Receiver one
- Receiver two

---

[![dotnet](https://img.shields.io/badge/dotnet-V8-purple?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/en-us/) [![csharp](https://img.shields.io/badge/CSharp-v12-darkgreen?style=for-the-badge&logo=C&logoColor=green)](https://dotnet.microsoft.com/es-es/languages/csharp) [![RabbitMQ](https://img.shields.io/badge/RabbitMQ-v8-blue?style=for-the-badge&logo=rabbitmq&logoColor=orange)](https://www.rabbitmq.com/) [![docker](https://img.shields.io/badge/DOCKER-v4-lightblue?style=for-the-badge&logo=docker&logoColor=lightblue)](https://www.docker.com/)

------------
#### Run this project locally
You need `dotnet CLI` check dotnet version `dotnet --version` or `Visual Studio`


* Run RabbitMQ on `Docker`
```
docker run -d --hostname rmq --name rabbitmq-server -p 8080:15672 -p 5672:5672 rabbitmq:4-management
```

* Located in the project file, Install dotnet project dependencies with `dotnet CLI`
```
dotnet restore
```

### Finally RUN

Sender One
 ```
 dotnet run --project rabbitmq-sender/rabbitmq-sender.csproj
 ```

 Receiver One
 ```
 dotnet run --project rabbitmq-sender/rabbitmq-receiver-one.csproj
 ```

 Receiver Two
 ```
 dotnet run --project rabbitmq-sender/rabbitmq-receiver-two.csproj
 ```

---

 #### Optional `Do You use MacOs?` use the run_project.sh included script to start 3 projects once

Make the script executable
```
chmod +x run_projects.sh
```

Start projects
```
./run_projects.sh
```

------------------------------------------------------------------------
<p align="center">
	With :heart: by <a href="https://www.raulcv.com" target="_blank">raulcv</a>
</p>

#
<h3 align="center">🤗 If you found helpful this repo, your welcome! 🐣</h3>
<p align="center">
<a href="https://www.buymeacoffee.com/iraulcv" target="_blank"><img src="https://cdn.buymeacoffee.com/buttons/default-orange.png" alt="Buy Me A Coffee" height="41" width="174"></a>
</p>