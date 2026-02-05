## Deploy Math28 App to Kubernetes (Local Server: Minikube)

Minikube runs a local, single-node Kubernetes cluster and does not provide a native cloud LoadBalancer. Therefore:

* **NodePort** is used for external-facing services
* **ClusterIP** is used for internal services
* **Resource limits (CPU/memory)** may not be strictly enforced in the local Minikube environment

Follow the steps below to deploy the Math28 application to Kubernetes using Minikube.

### 1. Create Namespace

Create namespace to group resource for the application under one namespace so that the are not confused with other deployments on Kubernetes. Namespace also makes it easy to check if all the pods are running when you have a large Kubernetes environment.

```bash
kubectl create namespace math28
```

### 2. Deploy Angular Front-end

To deploy the front-end, the Angular application Docker image must be published to *Docker Hub* registry.

1. Build Container

```bash
docker build . -t kgapzajedi56/math28-frontend:01
```

2. Publish to Docker Hub
```bash
docker push kgapzajedi56/math28-frontend:01
```

3. Deploy front-end on Kubernetes
To deploy to Kubernetes a deployment configuration file is created and used to deploy the front-end application. The `frontend-deployment.yml` contains deployment and service configuration.

NB: **-f** stands for *file* in the below command:
```bash
kubectl apply -f frontend-deployment.yml
```

### 2. Deploy Back-end

To deploy the back-end, the Back-end application Docker image must be published to *Docker Hub* registry.

1. Build Container

```bash
docker build . -t kgapzajedi56/math28-backend:01
```

2. Publish to Docker Hub
```bash
docker push kgapzajedi56/math28-backend:01
```

3. Deploy front-end on Kubernetes
To deploy to Kubernetes a deployment configuration file is created and used to deploy the front-end application. The `backend-deployment.yml` contains deployment and service configuration.

NB: **-f** stands for *file* in the below command:
```bash
kubectl apply -f backend-deployment.yml
```

### 3. Deploy Heathcheck-Web

To deploy the healthcheck-web, the healthcheck-web application Docker image must be published to *Docker Hub* registry.

1. Build Container

```bash
docker build . -t kgapzajedi56/math28-healthcheck-web:01
```

2. Publish to Docker Hub
```bash
docker push kgapzajedi56/math28-healthcheck-web:01
```

3. Deploy healthcheck-web on Kubernetes
To deploy to Kubernetes a deployment configuration file is created and used to deploy the front-end application. The `healthcheckweb-deployment.yml` contains deployment and service configuration.

NB: **-f** stands for *file* in the below command:
```bash
kubectl apply -f healthcheckweb-deployment.yml
```

### 4. Deploy Redis (`cache Server`)

To deploy the Redis cache, the public Docker image published by Redis on *Docker Hub* will be used.

1. Deploy Redis on Kubernetes
To deploy to Kubernetes a deployment configuration file is created and used to deploy the Redis cache which will be used by backend application. The `redis-deployment.yml` contains deployment and service configuration.

NB: **-f** stands for *file* in the below command:
```bash
kubectl apply -f redis-deployment.yml
```

### 4. Deploy PostgreSQL (`DB Server`)

To deploy the Redis cache, the public Docker image published by Redis on *Docker Hub* will be used.

1. Deploy PostgreSQL on Kubernetes
To deploy to Kubernetes a deployment configuration file is created and used to deploy the PostgreSQL which will be used by backend application. The `postgressql-deployment.yml` contains deployment and service configuration.

NB: **-f** stands for *file* in the below command:
```bash
kubectl apply -f postgressql-deployment.yml

