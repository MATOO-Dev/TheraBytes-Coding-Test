//Q:
//3. What is the name of the following pattern:
//public class MyClass
//{
//    private static MyClass instance;
//    public static MyClass Instance
//    {
//        get
//        {
//            if (instance == null)
//            {
//                instance = new MyClass();
//            }
//            return instance;
//        }
//    }
//    private MyClass() { }
//}

//A:
//This is the singleton pattern.
//There is one static instance. If the instance is null, fill it with a new Object, otherwise return the existing instance.