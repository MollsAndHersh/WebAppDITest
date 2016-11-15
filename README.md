# WebAppDITest
**Testing Updating razor view html using action result filter**

Files:
<br/>
1. IScriptManager,ScriptManager contains a collection of strings<br/>
2. AddScriptTagHelper each time <AddScript> is called it adds one dummy string to ScriptManager Collection<br/>
3. PostRazorResultFilter Updates view created by razor to add above body tag the real script tags<br/>

**Controller Attribute set as follows:**

```
[PostRazorResultFilter]
public IActionResult Index()
{  
    return View();
}
```

PROBLEM IS HTML NO ACCESSED CORRECTLY IN POSTRAZORRESULTFILTER
        
