# Organization Service

## Introduction
The Post Service is in charge of managing organizations (adding, updating and removing).


## Build steps

### development
To build and run the project locally you can run `docker compose up`.
This will build the API and run all the services necessary for it to function properly.
If there is no NATS service running you can start it by first running  `docker compose -f docker-compose-nats.yaml up -d`.

## Production
To get the project running in kubernetes there are a couple of steps:
- build the image for the backend by running `docker build -f Organization-Service/Dockerfile -t <HOST>/Organization-service:<TAG>`.
- Push the image to the docker registry by running `docker push <HOST>/Organization-service:<TAG>`.
- add the service and the database to kubernetes by running `kubectl apply -f api.yaml -f db.yaml`. 
If there is no NATS service running you can deploy it along with the other services by running `kubectl apply -f api.yaml -f db.yaml -f nats.yaml`.


Alternatively you can execute these steps by running the `deploy.sh` script. You can set the host and tag by passing the "h" and "t" flags. For example `./deploy.sh -t latest -h localhost:5001`.
If you just want to update the kubernetes configuration you can run `./deploy.sh -s`. 
The `-s` option skips the docker build steps.