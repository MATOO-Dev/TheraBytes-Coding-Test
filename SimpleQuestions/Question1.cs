//Q:
//1. Which value has result?
//bool result = (myBool) ? !myBool : myBool;

//A:
//this is basically just another way to write the following:

//bool result;
//if(myBool)
//      result = !myBool;
//else
//      result = myBool;

//therefore, the value of result will always be the opposite of myBool