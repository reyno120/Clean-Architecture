# Understanding Clean Architecture
* Place project image here

## Traditional 3 Layer Approach
<p align="center">
  <img width="500px" height="200px" src="https://github.com/reyno120/Clean-Architecture/assets/59970959/6bdceafa-802a-4244-9c98-19ad771f2380">
</p>
The Traditional 3 Tier approach to software architecture consists of the following 3 components:

* Client/Presentation Tier
* Business/Application Tier
* Persistence/Database Tier

This 3 Tier approach was the standard for some time and is how many applications are currently written. It seperated our presentation logic from our application logic and allowed us to scale our database independently from the rest of our application. However, this architecture has it's limitations, especially when it comes to large enterprise applications. As your application grows and becomes more complex it can be harder to maintain and scale up. Your application could become tightly coupled to it's dependencies, making it extremely difficult to swap out later.

As a result, development teams have been shifting to what's called "Clean Architecture", created by Robert C. Martin (a.k.a. "Uncle Bob"). The rest of this document covers the What, Why, and How of Clean Architecture, using a basic Recipe App for creating and viewing recipes as an example. It's important to remember that there is nothing inherently "bad" or "wrong" with the traditional 3 tier approach. In fact a traditional 3 tier approach may be better for smaller, less complex applications as it doesn't need the added benefits that Clean Architecture provides. When designing and building software, we should move away from labeling patterns and practices from either "good" or "bad" and instead ask, "What is best for my specific business problem that I am trying to solve"?

## What is Clean Architecture?
With the traditional 3 tier architecture your database gets placed at the center, forcing your application to become highly dependent on your database implementation. Clean Architecture instead focuses on your business entities and forces your application to depend on those entities in what's typically called the "Domain" layer.

<p align="center">
  <img width="300px" height="300px" src="https://github.com/reyno120/Clean-Architecture/assets/59970959/efcc52ee-6ada-409d-89cc-8e56c5e71200">
</p>

Clean Architecture creates separation of concerns by organizing our application into layers. By separating our business logic and domain entities from our database implementation and presentation code we create a much more maintainable and testable system. We can swap out databases without requiring a whole rewrite of our application.

The key thing to remember with Clean architecture is that your dependencies must point inward. Your application layer is dependent on your domain layer. However, your domain layer lies at the center of your architecture and does not "know" about the other layers of your application.
## Why Clean Architecture?
A key concept of Clean Architecture is loose coupling between the components of your applicaiton by using abstraction. We can achieve this by using interfaces. Rather than your classes depending upon other classes and their implementation, we can depend on an interface that has it's implementation defined at runtime using dependency injection.

I mentioned earlier that the traditional 3 tier approach works well with smaller, less complex applications. As your application grows in size and complexity it can become harder to maintain. By separating out the concerns of your application and depending on abstractions rather than implementations, our code becomes more organized and flexible as the business requirements rapidly change

One of the biggest selling points to Clean Architecture is improved testability. By placing our business entities at the center of our application we can focus on testing the business rules without worrying about the details. Since our code is dependent on abstractions, we can replace those details with mock versions during testing.
<br />
<br />

### What are the disadvantages to Clean Architecture?
This approach requires more time and effort up front to implement, especially if there are developers on your team who don't have experience implementing Clean Architecture principles. Getting buy in from management and business owners can be difficult depending on your team's deadlines. Clean Architecture requires you to think about your application's growth in the long term.
## How to implement Clean Architecture
### Domain Layer
The Domain layer sits at the center of our application. This is where me model our business entities using Domain-Driven Design. An entity is an object in your business domain that has an identity. An aggregate is a collection of entities held together by the aggregate root. In our recipe app example, the Recipes aggregate consists of a Recipe and a Direction class. The Recipe class is our aggregate root and has a reference to the Direction class. Anytime we want to access the Direction entity we need to do so through the aggregate root - our Recipe class.
* Insert diagram of aggregate
### Application Layer
The application layer stores all of our business logic. It references our domain layer but is unaware of any of our infrastructure or presentation details.

In order to perform database operations or call 3rd party API's stored in our infrastructure layer we use the dependency inversion principle. Rather than depending on those layers directly, we can create an interface to depend on and define it's implementation at runtime using dependy injection.

Let's take a look at the ICloudinaryHelper interface in the common folder of our Application layer. Cloudinary is a 3rd part API we use for storing digital media (in our use case, recipe images) and thus it's implementation details lie in the Infrastructure layer. Rather than depending on these details directly, we can depend upon the interface and inject it into our RecipesLogic. This creates a "black box" for our application layer. It does not know about it's implementation details, it just knows what parameters to pass it from the "contract" defined in the interface. 
### Service Layer
The service layer is an optional layer you can add to your application. It further decouples the frontend of your application from the backend by "wrapping" up your application logic into API endpoints and exposing those endpoints to your presentation layer. This is beneficial if at some point down the road we decide to add a mobile app UI layer for example, or switch technologies on the frontend.

This layer is also where we register our dependencies and define their implementation.
### Persistence Layer
The persistance layer contains all our data access code. Here we made use of the repository and unit of work pattern. In our domain layer we defined interfaces for our repositories. The implementation for these interfaces is defined in the service layer, injected into our application layer, and stored in our persistence layer.

By abstracting away our database implementation like this we decouple our application from persistence frameworks, allowing us to swap frameworks or databases in the future without having to rewrite other parts of our application.
### Infrastructure Layer
The infrastructure layer stores the details for any external dependencies. In our app's example we use Cloudinary to store digital assets.
### Presentation Layer
The presentation layer is exactly what it sounds like. It's responsible for presenting data to the user and should not contain any business logic. Our frontend is built using a React web api with Bootstrap components.

By structuring our application this way we can add multiple presentation layers. We can build a mobile UI layer or a desktop UI layer that all share the same backend logic.

# Demo
Video demo

# Build Instructions
