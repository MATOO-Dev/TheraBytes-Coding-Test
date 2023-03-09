//Q:
//6. Can you find problems with this code? How to fix the problems?
//public class MyClass
//{
//    public object Object;
//    public event Action<object> ObjectReleasedCallback;
//    public void AssignObject(object value)
//    {
//        Object = value;
//    }
//    public void ReleaseObject()
//    {
//        ObjectReleasedCallback(Object);
//        Object = null;
//    }
//}

//A:
//Problem 1:
//ReleaseObject() will throw a NullReferenceException if the object or the event Action<object> are null
//Implement null checks here to prevent this

//Problem 2:
//naming the object 'Object' can cause confusion, consider renaming this variable

//Problem 3:
//The 'Object' variable is public, making the setter obsolete
//Instead, declare 'Object' as follows:
//public object Object { get; private set; }

//Problem 4:
//'Object' is not nullable, declare this as nullable using "object?" instead
//public object? Object

//Problem 5:
//ObjectReleasedCallback is not nullable, declare this as nullable using "Action<object>?" instead
//public event Action<object>? ObjectReleasedCallback;