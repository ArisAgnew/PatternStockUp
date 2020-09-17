```
public static class Singleton<T> where T : class, new()
{
    static Singleton()
    {
        // Developer may put some extra conditions out here only with rigid adherence to T type.
    }

    public static readonly T Instance = 
        typeof(T).InvokeMember(typeof(T).Name, 
                                BindingFlags.CreateInstance | 
                                BindingFlags.Instance |
                                BindingFlags.Public |
                                BindingFlags.NonPublic, 
                                null, null, null) as T;
}
```
