https://www.telerik.com/blogs/aspnet-core-basics-understanding-practicing-solid

SOLID Principle
SOLID is an acronym created by Robert C Martin that represents set of object oriented design principles that aim to improve 
maintainability, extensibility and understanding of source code.

Each letter of SOLID representrs a principle.

S - Single Responsibility Principle
This principle emphasizes that a class should have only a single responsibility in the system. This results in more cohessive classes
and easier to maintain.

O - Open/Closed Principle
This principle states that software entities, such as classes and modules, should be open for extension but closed for modification.
This means you can add new behaviors or functionalities without changing existing code.

L - Liskov's Substitution Principle
This principle emphasizes that derived class(subclass) must be replaceable with the base classes. without affecting program correctness.
This promotes code consistency and interoperability.

I - Interface Segregation Principle
This principle suggests that interfaces should not be too comprehensive, but specific to the clients that use them. This prevents classes
from implementing methods they don't need, reducing coupling and improving cohesion.

D - Dependency Inversion Principle
This principal proposes that high level modules should not depend directly on low level modules, but both should depend on abstractions.
Furthermore, details should depend on abstractions, not the other way around, which promotes a more flexible and easily adaptable arch..

Code setups to demonstrate above principles - follow below links
https://www.telerik.com/blogs/aspnet-core-basics-understanding-practicing-solid
https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=visual-studio

Implementing the S
	A class must have only one function - that is, it must not contain more than one operation.
	A data insertion method should not contain validation logic, it should only inserts the data

ContactRepository
	this class implements the single responsibility principle because it has a single well-defined responsibility, which is to deal with 
	data persistence operations, providing methods to fetch, insert, update and delete contacts in the database.

	other aspects of SOLID present in the ContactRepository
	1. Coherence
		All methods in the class are related to the same domain entity, which are the contacts. This makes the class cohessive as all
		operations are related to the same functional area.

	2. Separation of Concerns
		The ContactRepository does not mix the business logic of the contacts with the interaction with the database. it just focuses on
		the database operations without worrying about the business logic of contacts.

	3. Ease of Maintenance
		Due to its unique responsibility and cohession, the ContactRepository class is easier to maintain and understand. Changes to 
		database operations related to contacts can be made in this class without affecting other parts of the code.


Implementing the O
	classes should be open for extension but closed for modification - that is, you can add new behavior or funcitonalities without
	changing the existing code.

	thinking about the example in the post, imagine that instead of contact class having a property names FullName, it should have  two
	new properties - FirstName and LastName

	In the contact class,  just add these two new properties, nothing will be affected


Implementing the L
	objects of a derived class must be able to be treated as objects of the base class without problems

	e.g. if you have a base class Contact and a derived class PersonalContact, you should be able to treat a PersonalContact object as 
	a Contact without breaking the program logic , i.e., the PersonalContact class it should just extend the Contact class without
	overwriting the behaviors of the base Contact class. Methods in the derived class must, at a minimum, maintain the same contract
	and functionality as the base class

	PersonalContact
	ContactService -> GetPersonalContactFullName

	a comparison is being made to find out if the object Contact is of type PersonalContact. This is only possible because 
	PersonalContact is a subclass of Contact and does not violate the principle of Liskov replacement because it just extends the base 
	class. In other words, it can be replaced, or in this case compared to the base class Contact.

Implementing the I
	in the principle of interface segregations, the interfaces should not be too comprehensive - that is, they must be specific to each
	client who will use them, thus avoiding the creation of unnecessary methods

	to practice interface segregation in the project, we will create an interface for the Repository class and another interface for
	Service class

	when creating interfaces, always prefer to create specific interfaces, rather than generic interfaces.

Implementing the D
	focus on the importance of reducing coupling between system modules

	in asp.net core, a well-known way to practice this principle is through dependency injection (DI)

	Dependency Injection: It is a design pattern and programming concept where dependencies external to an object are injected into it,
	rather than the object creating those dependencies on its own.

	ASP.NET Core has a system of built-in dependency injection that allows you to register and inject dependencies into your classes 
	through the ConfigureServices of the Program class
