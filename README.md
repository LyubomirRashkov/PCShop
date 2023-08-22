## :computer: [Online PC Shop](https://pcshopwebproject.azurewebsites.net/)

PCShop is my defence project for [ASP.NET Advanced - октомври 2022](https://softuni.bg/trainings/3854/asp-net-advanced-october-2022) course at [SoftUni](https://softuni.bg/).

### :boom: Deployed -> you can test it [here](https://pcshopwebproject.azurewebsites.net/)

### :eyeglasses: Overview

PCShop is an online store for laptops and peripherals (monitors, keyboards, mice, headphones and microphones). Every registered user has the opportunity to browse the products in the store, and in order to improve the user experience, he can use the search and sorting filters, then he can buy the products he chooses. According to the policy of the app, when a user makes his first purchase he becomes a client and when he makes the required number of purchases (5) he gets the opportunity to add his own products for sale. The maximum number of active products to sell for one user is 10. There is a logic implemented that prevents a user from buying his own products but it is possible for him to edit and delete them.

### :bricks: Structure

  + Two separate areas – one common and one Administration area;
  +	Two different roles – SuperUser and Administrator. SuperUser can add products to sell, Administrator have all privileges (only buying is not allowed);
  +	The Database layer consists of 7 entity models (Laptop, Monitor, Keyboard, Mouse, Headphone, Microphone, Client);
  +	The UI layer consists of 8 controllers in the common area and 2 controllers in the Administration area (plus one BaseController);
  +	The Service layer consists of 9 services;
  +	The Test layer consists of more than 160 tests (unit tests and integration tests);
  +	More than 40 views and more than 10 partial views.

### :hammer_and_wrench: Built With

-	[ASP.NET Core 6.0](https://learn.microsoft.com/en-us/aspnet/core/release-notes/aspnetcore-6.0?view=aspnetcore-7.0);
-	[Entity Framework Core 6.0.10](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/6.0.10);
-	[Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads);
-	[TempData messages](https://www.tutorialsteacher.com/mvc/tempdata-in-asp.net-mvc);
-	[Bootstrap 5.1.0](https://blog.getbootstrap.com/2021/08/04/bootstrap-5-1-0/);
-	[jQuery 3.5.1](https://blog.jquery.com/2020/05/04/jquery-3-5-1-released-fixing-a-regression/);
-	[coverlet.collector 3.1.2](https://www.nuget.org/packages/coverlet.collector);
-	[Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore 6.0.10](https://www.nuget.org/packages/Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore/6.0.0-rc.2.21480.10);
-	[Microsoft.AspNetCore.Identity 2.2.0](https://www.nuget.org/packages/Microsoft.AspNetCore.Identity/);
-	[Microsoft.AspNetCore.Identity.EntityFrameworkCore 6.0.10](https://www-0.nuget.org/packages/Microsoft.AspNetCore.Identity.EntityFrameworkCore/);
-	[Microsoft.AspNetCore.Identity.UI 6.0.10](https://www.nuget.org/packages/Microsoft.AspNetCore.Identity.UI/6.0.0-rc.2.21480.10);
-	[Microsoft.EntityFrameworkCore.InMemory 6.0.12](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.InMemory);
-	[Microsoft.EntityFrameworkCore.SqlServer 6.0.10](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/6.0.10);
-	[Microsoft.EntityFrameworkCore.Tools 6.0.10](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/6.0.10);
-	[Microsoft.NET.Test.Sdk 17.3.2](https://www.nuget.org/packages/Microsoft.NET.Test.Sdk/17.3.2);
-	[Microsoft.VisualStudio.Web.CodeGeneration.Design 6.0.10](https://www.nuget.org/packages/Microsoft.VisualStudio.Web.CodeGeneration.Design/6.0.10);
-	[Moq 4.18.3](https://www.nuget.org/packages/Moq/636.0.0);
-	[Newtonsoft.Json 13.0.1](https://www.nuget.org/packages/Newtonsoft.Json/);
-	[NUnit 3.13.3](https://www.nuget.org/packages/NUnit/);
-	[NUnit.Analyzers 3.3.0](https://www.nuget.org/packages/NUnit.Analyzers/3.3.0);
-	[NUnit3TestAdapter 4.2.1](https://www.nuget.org/packages/NUnit3TestAdapter/4.2.1);
-	[System.Linq.Expressions 4.3.0](https://www.nuget.org/packages/System.Linq.Expressions/);
-	[GitHub](https://github.com/);
-	[Tortoise Git](https://tortoisegit.org/).

### :film_strip: Screenshots

<br>

![изображение](https://user-images.githubusercontent.com/82647282/208303441-3b3aa72e-61d9-4cab-b282-cd6834297122.png)

<br>

<br>

![изображение](https://user-images.githubusercontent.com/82647282/208303448-8825c2b5-23a5-4d4e-a877-bdb2295bc551.png)

<br>

<br>

![изображение](https://user-images.githubusercontent.com/82647282/208303456-ba5e0125-e708-41ac-bb84-938ae7e60014.png)

<br>

<br>

![изображение](https://user-images.githubusercontent.com/82647282/208303462-3ae62cef-3ae7-45d0-91f9-427e0752d7dc.png)

<br>

<br>

![изображение](https://user-images.githubusercontent.com/82647282/208303466-f3301db3-b61e-4343-b99a-ade60014138e.png)

<br>

<br>

![изображение](https://user-images.githubusercontent.com/82647282/208303471-82534694-81ef-43ae-b6e4-f0e169dee58c.png)

<br>

<br>

![изображение](https://user-images.githubusercontent.com/82647282/208303478-3324c129-3372-40d5-9650-651b851c8c5d.png)

<br>

<br>

![изображение](https://user-images.githubusercontent.com/82647282/208303488-f2b5a3a1-d9b1-4969-84d3-dc7216218638.png)

<br>

<br>

![изображение](https://user-images.githubusercontent.com/82647282/208303493-a2957e03-58e1-4ad8-a807-30f7070bf750.png)

<br>

<br>

![изображение](https://user-images.githubusercontent.com/82647282/208303496-e3cf8b48-0ee9-4595-ab92-7f2ff8414571.png)

<br>

### :pushpin: DB Diagrams

<br>

![изображение](https://user-images.githubusercontent.com/82647282/208303505-feb1dd37-8357-499f-a4e5-875c71afe6b7.png)

<br>

<br>

![изображение](https://user-images.githubusercontent.com/82647282/208303514-a5f0e429-cd20-4a36-ba14-b2dbdc028420.png)

<br>

<br>

![изображение](https://user-images.githubusercontent.com/82647282/208303526-180ebd76-c32e-44ec-9176-d4ed1b5c64b3.png)

<br>

<br>

![изображение](https://user-images.githubusercontent.com/82647282/208303536-a7f5cab7-58be-44ac-bbf1-201e2e079aa4.png)

<br>

<br>

![изображение](https://user-images.githubusercontent.com/82647282/208303543-3b813743-ff75-461a-bbd9-aa870f44b91c.png)

<br>

<br>

![изображение](https://user-images.githubusercontent.com/82647282/208303550-2c6732c6-be64-46b7-89c7-b65e062fc421.png)

<br>

<br>

![изображение](https://user-images.githubusercontent.com/82647282/208303560-8739d155-e4a0-4e63-8a3e-33add47dba50.png)

<br>

### :cowboy_hat_face: On The Road To

  + Implement and integrate more functionality;
  +	Host the application;
  + Improve user interface and user experience...
  