# Understanding Clean Architecture
* Place project image here

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
<p align="center">
  <img width="300px" height="300px" src="https://github.com/reyno120/Clean-Architecture/assets/59970959/8a39e2c1-9367-435b-8fc4-69829eaf297f)">
</p>

With the traditional 3 layer architecture your database gets placed at the center, forcing your application to become highly dependent on your database implementation. Clean Architecture instead focuses on your business entities and forces your application to depend on those entities in what's typically called the "Domain" layer.

Clean Architecture also creates separation of concerns by organizing our application into layers. By separating our business logic and domain entities from our database implementation and presentation code we create a much more maintainable and testable system. We can swap out databases without requiring a whole rewrite of our application.

The key thing to remember with Clean architecture is that your dependencies must point inward. Your application layer is dependent on your domain layer. However, your domain layer lies at the center of your architecture and does not "know" about the other layers of your application.
## Why Clean Architecture?
A key concept of Clean Architecture is loose coupling between the components of your applicaiton by using abstraction. We can achieve this by using interfaces. Rather than your classes depending upon other classes and their implementation, we can depend on an interface that has it's implementation defined at runtime using dependency injection.

I mentioned earlier that the traditional 3 layer approach works well with smaller, less complex applications. As your application grows in size and complexity it can become harder to maintain. By separating out the concerns of your application and depending on abstractions rather than implementations, our code becomes more organized and flexible as the business requirements rapidly change

One of the biggest selling points to Clean Architecture is improved testability. By placing our business entities at the center of our application we can focus on testing the business rules without worrying about the details. Since our code is dependent on abstractions, we can replace those details with mock versions during testing.
<br />
<br />

### What are the disadvantages to Clean Architecture?
This approach requires more time and effort up front to implement, especially if there are developers on your team who don't have experience implementing Clean Architecture principles. Getting buy in from management and business owners can be difficult depending on your team's deadlines. Clean Architecture requires you to think about your application's growth in the long term.
## How to implement Clean Architecture
* Functional Cohesion rather than categorical
### Domain Layer
* DDD & Aggregates
* Strongly Typed Id's

The Domain layer sits at the center of our application. This is where me model our business entities using Domain-Driven Design. An entity is an object in your business domain that has an identity. An aggregate is a collection of entities
### Application Layer
### Service Layer
### Persistence Layer
* Abstracting away database, creating a black box, defining implementation on runtime through use of dependency injection
### Infrastructure Layer
### Presentation Layer

# Demo
Video demo

# Build Instructions
