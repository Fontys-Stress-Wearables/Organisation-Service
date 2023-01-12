# Organization Service

## Introduction
The Post Service is in charge of managing organizations (adding, updating and removing).


## Build steps

### development
To build and run the project locally you can run `docker compose up`.
This will build the API and run all the services necessary for it to function properly.
If there is no NATS service running you can start it by first running  `docker compose -f docker-compose-nats.yaml up -d`.

## Docker
If you want to manually build a Docker container of this service and push use the following commands
- build the image for the backend by running `docker build -t ghcr.io/fontys-stress-wearables/organization-service:main`.
- Push the image to the docker registry by running `docker push ghcr.io/fontys-stress-wearables/organization-service:main`
