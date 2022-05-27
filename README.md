# Dynamic-Dependency-Injection-Using-Attribute
Dynamically register Dependecy using Custom Attribute 


Usage 


```C#
    public interface IUserRepository
    {
        Task<int> InsertUser(string email);
    }
```

    
    

    

```C#
    [Export(typeof(IUserRepository),Lifetime.Scoped)]
    public class UserRepository : IUserRepository
    {
        public Task<int> InsertUser(string email)
        {
            return 0;
        }
    }
```    

