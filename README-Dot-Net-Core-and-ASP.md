# Lesson 60 - Module 2 : ASP Core MVC : Structure Overview

Distributed applications

	Presentation layer : views and controllers

	Business logic layer : models

	Data access layer : tables

	Database layer : db itself

Communication

    HTTP from user to web server

    WEB API from web server to middle tier server, or WCF

    T-SQL to database

State

    Client-side

        Cookies

        Query string

    Server-side

        Temp folder
        App State
        Session State
        DB


    Index.es.resx. for spanish or Index.es-CL.resx

Security



## Chapter 2 Lesson 2 : Designing MVC

Models

    User : User Class eg user/pass

    Photo : Photo Class

Controllers inherit from Microsoft.AspNetCore.Mvc.Controller

    One controller per model

    Photo model has PhotoController controller

    User
        Logon GET
        Logon POST
    Photo
        AddPhoto GET.    display form
        AddPhoto POST.   new photo
        DisplayAll GET


Navigation Controls
    Menu
    Tree
    Breadcrumb

    URL : mysite/Controller/Action/ID






























# Lesson 65 - Module 3 - Middleware, Services, Static Files

## Lesson 1 : Middleware

Attaches to request/response

## Startup class

    class Startup{
        ConfigureServices(){
            // used to inject services
        }
        Configure(){
            // supports dependency injection
        }
    }

    class Program{
        void Main(){
            var instance = new Startup()
            instance.Configure();
        }
    }



### Static files

wwwroot folder

Problem : all are completely open so there is no authentication for them

Problem : paths are visible to an attacker

Problem : files may or may not be case sensitive which can affect ASP.NET Core open source files on Windows/Linux/MAC machines



## Module 3 Lesson 2 : Configure Services

Services are classes which can be reused in multiple locations without having to reinstantiate.  We can use `Dependency Injection` to add the services where required.

We can add this code in Startup class, Configure method

We can use the IServiceProvider class which has the ConfigureServices method in the Startup class

Dependency injection : advantage : more consistent testing

services.AddMvc() 

Declare a custom service ..

Register a custom service..

app.UseMvc();

app.UseMvcWithDefaultRoute();
    will use Controllers => HomeController => Index action

Controller

```cs
public class HomeController : Controller{
    public IActionResult Index(){
        return Content("Hello World");
    }
}

```

### Service Instance Lifetime

AddSingleton - data persists for ever until service shut down

AddScoped - data for lifetime of request

AddTransient - stateless

































# Lesson 70 - Module 4 : ASP Controllers

## Controllers

Controller is a class

Methods are called Actions

URL routing 

URL mapping

action filters - run code before or after every action

HTTP requests => Controller object is instantiated.  Action method is chosen.  Model binder passes parameters to the action.

Model

```cs
public class MyModel{
    public string MyField{get;set;}
}
```
Controller

```cs
public class HomeController:Controller{
    public IActionResult Index(){
        var model = new MyModel(){MyField="hello"};
        return View(model);
    }
}
```


View

```cshtml
@model MyWebApplication.Models.MyModel

@{
    Layout=null;
}
<div>@Model.Value</div>
```


### Controller Returning A View Which Is Sent To The Browser

```cs
class HomeController:Conroller{
    public IActionResult Index(){
        return View();  // creates and returns a ViewResult object
    }
}

```

### RedirectToAction

RedirectToAction can call another action



### RedirectToRouteResult

This can redirect to another controller with another action selected for that controller

```cs
public class HomeController:Controller{
    public RedirectToRouteResult Index(){
        return RedirectToRoute(new {
            controller="Another",
            action="AnotherAction"
            });
    }
}

public class AnotherController:Controller{
    public ContentResult AnotherAction(){
        return Content("another action in another controller is now working");
    }
}

```


### Returning HTTP Status Codes with StatusCodeResult

```cs
public class HomeController:Controller{
    public StatusCodeResult Index(){
        return new StatusCodeResult(404);
    }
}
```


## Using Parameters

First of all configure a route in the Startup.cs

```cs
/* startup.cs */
public void Configure(....){
    app.UseMvc(routes=>{
        routes.MapRoute(
                name:default,
                template:"{controller}/{action}/{id?}"
            );
        });
}
```

Now match this in the controller

```cs
public class HomeController : Controller{
    public IActionResult Index(string id){
        return Content(id);
    }
}
// If the user types http://localhost:1234/Home/Index/100 the browser will return the number 100
```

### Obtaining the ID without passing id directly into the controller

We can also obtain the id even if it's not passed into the controller

```cs
public class HomeController:Controller{
    public IActionResult Index(){
        string id = (string)RouteData.Values["id"];
        return Content(id);
    }
}

```

### Matching parameters passed in as query string items in the request URL

If we have a request URL `http://localhost:1234/Home/Index?title=someTitle we can obtain the string `title` and its data`

```cs
public class HomeController:Controller{
    public IActionResult Index(string title){
        return Content(title);
    }
}
```

### Passing model data to the View

We can also pass model data from the controller back into the View

This is the recommended method of passing data.

### Adding extra data with `ViewData` and `ViewBag`

We can add extra data to our model data which we are passing into the View.

`ViewData` is a dictionary of key/value pairs : use this one preferably

`ViewBag` is an object which can take any type as its input

```cs
public class HomeController:Controller{
    public IActionResult Index(){
        ViewData["Field01"]="some data";
        return View();
    }
}
```

We can now see the data using Razor syntax : 

```html
<div>@ViewData["Field01"]</div>
```



## Module 4 Lesson 2 : Configuring Routes

### Summary of web request

1. Controller instantiated

2. Route determined

3. Examine request URL to get action

4. Model binding determines parameters to pass to the action from a form, URL query string, or from files

5. Action invoked, often invoking new instance of Model class.  

6. Model instance passed to the View to render.

7. Response sent to user.

### Limitations of routing

Routing only affects the part after the domain and the port ie the folder and file structure /controller/action/1

Routes are used

1. Parse URL to right controller and action

2. To create URLs

### Why add routes?

1. Easier for user to understand

2. Improve SEO ranking 

### Convention based routing contains

    name
    template
    defaults
    constraints

### Passing parameters by Route Data

```cs
public class ExampleController:Controller{
    public IActionResult Index(){
        string controller = (string)RouteData.Values["Controller"];
        string action = (string)RouteData.Values["Action"];
        string id = (string)RouteData.Values["id"];
        return controller + "/" + action + "/" + id;
    }
}

```

### Passing parameters by parameters

```cs
public IActionResult Index(string id){
    return Content "id : " + id;
}
```

or for numeric id

```cs
public IActionResult Index(int? id){
    return Content "id : " + id;
}
```

or optional values

```cs
public IActionResult Index(int? id=500){
    return Content "id : " + id;
}
```


or multiple values which would match http://localhost:1234/controller/action/id/title

```cs
public IActionResult Index(int? id=500, string title){
    return Content "id : " + id + "/" + title;
}
```


## Routes With Attributes

### Routes with HttpGet Attributes

```cs
public class CitiesController:Controller{
    [HttpGet]("/cities/{id}");
    public IActionResult GetCity(int id){}
}
```

or

```cs
[Route("cities")]
public class CitiesController:Controller{
    [HttpGet]
    public IActionResult ListCities(){}
    [HttpGet("{id}")]
    public  IActionResult GetCity(int id){}
}
```






## Module 4 Lesson 3 : Action Filters

Filters can be applied before or after a controller

    Authorisation Filters run first and check permissions

    Action Filters run before and after

    Exception Filters

    Result Filters

    Logging 

    Caching





























# Lesson 75 - Module 5 - ASP Views

Views handle the presentation logic

Normally there is one controller class for one model class.  One controller may have many views though.

    Views/Model/
        Index : lists all
        Details : details of one
        Create
        Edit
        Delete
        Index

View name should match the controller action name

    Model       Product
    Controller  ProductController
    View        Views/Product


Template : can be used for scaffolding

To create a view, find the `ActionResult` method inside the controller, right click on it and choose `Create View`

To map to the default view just choose Index

To map to a different view change the View name

To map to a View which does not match the ActionResult method name, you have to pass into the View the name of the View file which is to be read as a result of the Action.

```cs
public class TestController : Controller
{

    // This will map https://localhost:44365/Test to Views/Test/Index.cshtml
    public ActionResult Index()
    {
        return View();
    }
    // This will map https://localhost:44365/Test/Index2 to Views/Test/Index2.cshtml
    public ActionResult Index2()
    {
        return View();
    }
    // This will map https://localhost:44365/Test/View2 to Views/Test/TestView.cshtml
    public ActionResult View2()
    {
        return View("TestView");
    }
}
```


## Razor code

Razor code is denoted `@` and is processed at the server.  All other code is HTML code and is processed at the browser.

```cshtml
@{
    ViewBag.Title = "TestView";
}

    <h2>@ViewBag.Title</h2>
<ul>
    @for (int i = 0; i < 10; i++)
    {
        <li>@i</li>
    }
</ul>
@string.Concat("Some " + "Text")
```


### @: explicit string delimiter

@ signifies code

@: signifies literal string text to follow

@@ displays the `@` symbol on the screen

### Razor Comments

`@*` Razor comment `*@`

### ViewBag

We can pass text in from the Controller using `ViewBag`

```cs
public class MyController : Controller{
    public ActionResult Index(){
        ViewBag.Price=2;
        Return View();
    }
}
```

```html
<div>Total Price is @(ViewBag.Price*2)</div>
```


### Razor Code Block

We can denote a Razor code block with `@{}`

```cs
@{
    
}
```

### Razor `if` statements

```cs
@{ 
    int j = 7;
    int k = 8;
    if (j < k)
    {
        @j
    }
}
```


### Razor `foreach` loops

We have already seen a `for` loop.  

Let's look at a `foreach` loop

```cs
public ActionResult Index()
{
    ViewBag.Names = new List<string> { "Some", "List", "Of", "Strings" };
    return View();
}
```


```cshtml
<ul>
@foreach(string item in ViewBag.Names)
{
    <li>@item</li>
}
</ul>
```

returns

```
Some
List
Of
Strings
```


### Rendering A Model In The View

Imagine we have a model class

```cs
public class Test
{
    public int TestId { get; set; }
    public string TestName { get; set; }
}
```

In the controller we can create a list of such items and pass them into our View

```cs
public ActionResult Index()
{
    var t1 = new Test() { TestId=1, TestName="TestName" };
    var t2 = new Test() { TestId=2, TestName="TestName2" };
    var testItems = new List<Test>() { t1, t2 };
    return View(testItems);
}
```

and finally render the View with the Model items

```cs
@model IEnumerable<ASP_MVC_03.Models.Test>
<ul>
@foreach (var item in Model)
{
    <li>@item.TestId -- @item.TestName</li>
}
</ul>
```

Also notice the slightly more advanced @Html syntax

```cs
@model IEnumerable<ASP_MVC_03.Models.Test>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(model => model.TestId)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.TestName)

        </th>
    </tr>

    @foreach (var item in Model)
    {
        <tr>
            <td>
                @Html.DisplayFor(modelItem => item.TestId)
                @Html.DisplayFor(modelItem => item.TestName)
            </td>
        </tr>
    }
</table>


<ul>
@foreach (var item in Model)
{
    <li>@item.TestId -- @item.TestName</li>
}
</ul>

```

### Html.ActionLink

also note Html.ActionLink which can call a given URL for example from the `_Layout` file

```cshtml
@Html.ActionLink("Test2","","Test2");

@Html.ActionLink("Link Text","Action","Controller");
```

### Partial Views

Partial views are reusable blocks of code which can be inserted at more than one place.

The partial view is a file which has content which can be loaded from the main View file

`Index.cshtml`

```cshtml
This is text from the main view
@Html.Partial("_PartialView")
```

`_My_PartialView.cshtml` 

```cshtml
This is text in the partial view file
```

See ASP_MVC_03 for an example of this

## Viewbag and ViewData

We can pass data between the controller and the view using `Viewbag` and `ViewData` although it's mainly used for quick-and-easy code rather than on larger projects, where it is frowned upon as it can cause issues with type safety.

ViewData is a dictionary of key-value pairs of strings

```cs
// controller
public ActionResult Index(){
    ViewBag.Name="Phil";
    ViewData["Hobbies"]="Tennis";
    return View();
}
// Calling in View
@ViewBag.Name
@ViewData["Hobbies"] 
```

## View Components

View components are similar to partial views


























# Lesson 80 - Module 6 - ASP Models

Here is an example of a model class

```cs
public class Photo{
    public int PhotoId{get;set;}
    public string Title{get;set;}
    public byte PhotoFile{get;set;}
    public string Description{get;set;}
    public DateTime CreateDate{get;set;}
    public string Owner{get;set;}
    // one photo may have many comments
    public virtual ICollection<Comment> Comments {get;set;}
}
public class Comment{
    public int CommentId{get;set;}
    // tie to single photo
    public int PhotoId{get;set;}
    public string UserName{get;set;}
    public string Subject{get;set;}
    public string Body{get;set;}
    // returns the related photo object
    public virtual Photo{get;set;}
}
```

Simple applications pass the model from the Controller to the View

More complex applications use the ViewModels

## @model and @Model in the View

@model refers to the model class

    @model MyApp.Models.MyModel

@Model refers to the instance of the model passed in, and can have fields attached

    @Model.Field01


## Passing in a collection

In the controller if we are passing in a collection such as

```cs
public class MyController:Controller{
    public ActionResult Index(){
        var list = new List<MyModel>();
        return View(list);
    }
}
```

```cshtml
@model IEnumerable<MyApp.Models.MyModel>
foreach(var item in @Model){
    <li>item.Field01</li>                      
}
```

See [ASP_MVC_03 View3](https://github.com/philanderson888/c-sharp/blob/master/ASP_MVC_03/Views/Test3/View3.cshtml) for a worked example

### Passing To A Different View

```cs
// return to ThisView.cshtml view a data item
return View("ThisView",thisModelInstance)
```

See [ASP_MVC_04](ASP_MVC_04) for a mixture of controllers and views

### Strongly Typed vs Dynamic view

Strongly Typed view : types are fixed

    @Model.FieldName is used to access the fields in the instance

Dynamic View : any type may be used

    Dynamic views do not have the @model at the top of the page

    Directly name the item on the page eg ThisModel.ThisField





## Async..await

If you enable async version of your project then this will be the syntax to use

```cs
public async Task<ActionResult> GetName()
{
    return View("Index", await db.People.ToListAsync());
}
```

## Forms

### @Html.EditorForModel

We can use the `@Html.EditorForModel` syntax to generate an input form for us.

If we add a controller

```cs
public ActionResult InputName()
{
    return View();
}
```

and a view

```cshtml
@model ASP_MVC_04.Models.Person
@{
    ViewBag.Title = "InputName";
}

<h2>InputName</h2>

<form action="/People/InputName" method="post">
    @Html.EditorForModel()
    <input type="submit" value="Submit My Name" />
</form>
```

Then this will display a form to fill out and complete.

If we add the POST logic to the controller we can add new records like this

```cs
[HttpGet]
public ActionResult InputName()
{
    return View();
}
[HttpPost]
public async Task<ActionResult> InputName([Bind(Include = "PersonId,FirstName")] Person person)
{
    if (ModelState.IsValid)
    {
        db.People.Add(person);
        await db.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    return View(person);
}
```

See [ASP_MVC_04](ASP_MVC_04) for a working instance of this






## ASP Form with multiple submit buttons

```html
<form action="" method="post">
    <input type="submit" value="Option 1" formaction="DoWorkOne" />
    <input type="submit" value="Option 2" formaction="DoWorkTwo"/>
</form>
```

Then simply have controller actions like this:

```cs
[HttpPost]
public IActionResult DoWorkOne(TheModel model) { ... }
[HttpPost]
public IActionResult DoWorkTwo(TheModel model) { ... }
```

