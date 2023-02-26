# ECommerceMicroserviceProject
  
  ### Goals of the Project:  
   - Refactor my [ECommerceProject](https://github.com/BarisClb/ECommerceProject) to Microservice.  
   - Deploy it on Cloud.  
   - Create CI/CD with DevOps Tools.  
  
  ### TODOs:  
  
   - Basket Service (Redis)  
   - Order Service  
   - Comment Service  
   - Authorization / Authentication (JWT)  
   - Caching (One for Categories, Redis)  
   - Gateway / API for calls between UI (React) and Services  
   - Refactoring / Cleaning the UI (React) Project  
   - RabbitMq for Eventual Consistency  
   - ELK for Logging  
   - Data Seeding  
   - Docker  
  
   ### Second Part of the Plan (Deploying the Project on Cloud, Automation with DevOps tools):  
   
   - Deploy Project on both IIS and Docker Swarm  
   - Jenkins  
   - Deployment Automation (On Git Merge)  
   - Record videos about the Second Part  
   
   ### Notes  
  
   - Hash User Passwords  
  
   ### Highlights  
  
   - BaseRepository (SQL)  
     - Interfaces  
	   - [Read](https://github.com/BarisClb/ECommerceMicroserviceProject/blob/master/Services/UserService/Application/Interfaces/IBaseReadRepository.cs)  
	   - [Write](https://github.com/BarisClb/ECommerceMicroserviceProject/blob/master/Services/UserService/Application/Interfaces/IBaseWriteRepository.cs)  
  
	 - Implementations	
	   - [Read](https://github.com/BarisClb/ECommerceMicroserviceProject/blob/master/Services/UserService/Persistence/Repositories/BaseReadRepository.cs)  
	   - [Write](https://github.com/BarisClb/ECommerceMicroserviceProject/blob/master/Services/UserService/Persistence/Repositories/BaseWriteRepository.cs)  
  
   - BaseRepository (Mongo)  
     - [Interface](https://github.com/BarisClb/ECommerceMicroserviceProject/blob/master/Services/ProductService/Application/Interfaces/IBaseRepository.cs)  
	 - [Implementation](https://github.com/BarisClb/ECommerceMicroserviceProject/blob/master/Services/ProductService/Persistence/Repositories/BaseRepository.cs)  
  
   - Extensions  
     - [All Extensions](https://github.com/BarisClb/ECommerceMicroserviceProject/blob/master/Shared/SharedLibrary/Extensions)  
     - Dynamic Predicate Builder  
	   - [Method Extension](https://github.com/BarisClb/ECommerceMicroserviceProject/blob/master/Shared/SharedLibrary/Extensions/PredicateBuilder.cs)  
	   - [Usage](https://github.com/BarisClb/ECommerceMicroserviceProject/blob/master/Services/UserService/Application/Queries/Address/GetAddressesByUserId/GetAddressesByUserIdQueryHandler.cs)  
  
   - Helpers  
     - [All Helpers](https://github.com/BarisClb/ECommerceMicroserviceProject/blob/master/Shared/SharedLibrary/Helpers)  
  
   - Middlewares  
     - [All Middlewares](https://github.com/BarisClb/ECommerceMicroserviceProject/blob/master/Shared/SharedLibrary/Middlewares)  
  
