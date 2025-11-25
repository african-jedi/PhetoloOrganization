## How to run Angular Application using Docker

The ***Dockerfile*** is already included in the solution. To test the application, simply run the following commands:

Build a docker image first:
```bash
docker build -t math28.angularapp .
```

Create container with port to test on:
```bash
docker run -p 4201:4200 math28.angularapp
```
