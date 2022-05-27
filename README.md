# Dynamic-Dependency-Injection-Using-Attribute
Dynamically register Dependecy using Custom Attribute 


Usage 


```C#
    public interface IUserRepository
    {
        Task<int> InsertUser(string email);
    }
```

    
    

Register as Scoped Service    

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

Register as Transient Service    

```C#
    [Export(typeof(IUserRepository),Lifetime.Transient)]
    public class UserRepository : IUserRepository
    {
        public Task<int> InsertUser(string email)
        {
            return 0;
        }
    }
```   

Register as Singleton Service    

```C#
    [Export(typeof(IUserRepository),Lifetime.Singleton)]
    public class UserRepository : IUserRepository
    {
        public Task<int> InsertUser(string email)
        {
            return 0;
        }
    }
```   

If Lifetime is not mentioned it register service as Transient by default
