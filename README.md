# Understanding Clean Architecture
<p align="center">
  <img width="300px" height="300px" src="https://github.com/reyno120/Clean-Architecture/assets/59970959/8a39e2c1-9367-435b-8fc4-69829eaf297f)">
</p>

## Traditional 3 Layer Approach
<p align="center">
  <img width="500px" height="200px" src="https://github.com/reyno120/Clean-Architecture/assets/59970959/d50d9c90-27a2-45e7-9732-c1fc3d32e132">
</p>
The Traditional 3 Layer approach to software architecture consists of the following 3 components:

* Client/Presentation Layer
* Business/Application Layer
* Persistence/Database Layer

This 3 layer approach was the standard for some time and is how many applications are currently written. It seperated our presentation logic from our application logic and allowed us to scale our database independently from the rest of our application. However, this architecture has it's limitations, especially when it comes to large enterprise applications. As your application grows and becomes more complex it can be harder to maintain and scale up. Your application could become tightly coupled to it's dependencies, making it extremely difficult to swap out later.

As a result, development teams have been shifting to what's called "Clean Architecture", created by Robert C. Martin (a.k.a. "Uncle Bob"). The rest of this document covers the What, Why, and How of Clean Architecture, using a basic Recipe App for creating and viewing recipes as an example. It's important to remember that there is nothing inherently "bad" or "wrong" with the traditional 3 layer approach. In fact a traditional 3 layer approach may be better for smaller, less complex applications as it doesn't need the added benefits that Clean Architecture provides. When designing and building software, we should move away from labeling patterns and practices from either "good" or "bad" and instead ask, "What is best for my specific business problem that I am trying to solve"?

## What is Clean Architecture?
## Why Clean Architecture?
Works for small projects, but as project grows and gets more complex, start adding more features, traditional approach fails
## How to implement Clean Architecture
* Functional Cohesion rather than categorical
### Domain Layer
* DDD & Aggregates
* Strongly Typed Id's
### Application Layer
### Service Layer
### Persistence Layer
### Infrastructure Layer
### Presentation Layer

# Demo
Video demo

# Build Instructions
