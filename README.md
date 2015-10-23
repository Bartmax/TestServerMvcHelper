# TestServerMvcHelper - ASP.NET 5 MVC 6.
Easy usage of TestServer when testing AspNet.Mvc applications.

This allows for customization of TestServer base path so it can find Razor views.

###Usage

add the dependency in your `project.json` file of your test project.

```
"dependencies": {
    // ...
    "YourMvcApplication" : ""
    "TestServerMvcHelper": "1.0.0-*"
}
```

and a simple test:

```c#
[Fact]
public async void TestIndex()
{
    var builder = TestServer.CreateBuilder();
    builder.UseStartup<Startup>()
        .UseEnvironment("Testing")
        .UseApplicationPath("YourMvcApplication");
    var server = new TestServer(builder);
    var client = server.CreateClient();
    var getReponse = await client.GetAsync("http://localhost/");
    Assert.Equal(HttpStatusCode.OK, getReponse.StatusCode);
}
```

