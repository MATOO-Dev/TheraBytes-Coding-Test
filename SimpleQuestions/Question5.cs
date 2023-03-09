//Q:
//5. What is the Problem with the following code?
//List<string> list = new List<string> { "mage", "warrior" };
//for (int i = 0; i < list.Count; i++)
//{
//    list.Add(list[i].ToLower());
//}

//A:
//The values are already added in the first line when the list is declared, the for loop is unneccessary
//The List will contain (in order):
//mage
//warrior
//mage
//warrior

//Additionally, adding values to the list while iterating over it will increase the list.Count value.
//This would result in an infinite loop of adding "mage" and "warrior" (or at least until memory runs out)