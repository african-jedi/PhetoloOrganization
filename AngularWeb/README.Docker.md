## How to run Angular Application using Docker

The Dockerfile is already created in the solution. All you need to do is to run the following commands to test application.

Build a docker image first:
```bash
docker build -t math28.angularapp .
```

Create container with port to test on:
```bash
docker docker run -p 4201:4200 math28.angularapp
```
