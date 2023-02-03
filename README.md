# SatCommerce CQRS Microservices 
[![DOI](https://zenodo.org/badge/582193037.svg)](https://zenodo.org/badge/latestdoi/582193037)

*Note: This project has been publicy released on Zenodo, you can cite this project (see Citation section [here](https://github.com/satrio-pamungkas/satcommerce/edit/main/README.md#citation))*

## About
This is public repository contains my research project (thesis) during college days. The aims of this research is actually to compare how Microservices with CQRS pattern perform across multiple databases. Four aspects that being measured are response time, throughput, cpu usage and memory usage.

## Overview
There are 3 project replicas (NewSQL with CockroachDB, NoSQL with MongoDB and Relational with PostgreSQL), all of them are shared with same architecture and several technology stack (except the database and ORMs). Here are the explanation :
### Architecture
- Microservices with three domains (Product, Cart and Payment), these are based on common e-commerve Software Product Line (SPL)
- Command Query Responsibility Segregation (CQRS), each domain have two services for command and query side
- Event Sourcing, this system using event-driven data exchange between services
### Technology Stack
- C# and .NET as programming language and web framework
- Apache Kafka as Event Bus to support event-driven or event sourcing pattern of the entire system
- Ocelot as an API Gateway to map request on each corresponding service
- Docker Compose to run all docker services
- Kubernetes (optional choice to run all docker services), but currently is not configured properly

## Citation
You can use and modify this project for further research or blog, but you must cite this repository in your publication. Feel free to modify citation below to specific citation style (i.e. APA, IEEE, etc)

> Muhammad Raihan Satrio Putra Pamungkas. (2023). satrio-pamungkas/satcommerce: 1.0.0 (1.0.0). Zenodo. https://doi.org/10.5281/zenodo.7511152

