# Conference Management System

## Table of Contents
1. [Project Overview](#project-overview)
2. [Architecture](#architecture)


## Project Overview
"Summits" is a simulation of a system which manage conferences planning and ticket distribution for organisation XYZ.
The main reason of creating this project is my desire to increase my knowledge in event sourcing and microservices topics.

## Architecture
My current plan is to build a set of microservices, each with their own materialized view and separate event store. Every service will be developed in clean architecture with CQRS in .NET 8.
Most probably I will use MongoDb as my event store, raw RabbitMQ/Kafka for asynchronous messaging between microservices and grpc for synchronous messaging when needed.


