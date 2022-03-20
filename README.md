# Dockerized-ClientServer-App

This repo contains the source code for the interactive communication between client and server. Both of the application developed in .Net 6 using C#.

## Server
Server application is use c# SOCKET for the receving information from the client app.

## Client
Client application also use c# SOCKET fot the sending information to server App.

## Usage
This application is compatible with Linux and max.
Once you have downloaded the application navigate to the /ClientServerApplication and run cmd and type
```cmd
docker-compose build && docker-compose up -d
```
This will setup and run the container into your local docker registry. If you have installed docker desktop. Open the docker desktop and start a bash shell for a client app and type following command in terminal
```bash
dotnet Client.dll start
```
This will start the client app and what else you type on bash it will be printed inside the Server application. For that you can check the terminal of server container.

If you want to stop the session type * in clinet app and ti will end the session with server.