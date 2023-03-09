//Q:
//7. Complete the story (two possible answers - please explain your thoughts)
//Three programmers have died due to a deadlock. At heaven’s gate Petrus asks: “Do all three of you want to go to heaven?”
//The first programmer says: „I don’t know. “
//The second programmer says: „I don’t know. “
//The third programmer says: „< your answer > “

//A:
//A deadlock occurs when multiple threads are all waiting for each other to finish using a locked resource, meaning none can continue.
//My assumption is that Programmers 1 & 2 cannot access the resource that indicates whether they go to heaven or not

//Option 1:         The third programmer answers the question
//Explaination:     The third programmer locked the resource and is therefore the only person that can currently access it.
//                  Once they are done answering, one of the other 2 programmers can answer, then the last one

//Option 2:         The third programmer also doesn't know
//Explaination:     The resource is locked by an unknown 4th person.
//                  Because of this, none of the 3 programmers have access to it and therefore cannot read it's value

//Option 3:         The third programmer also doesn't know
//Explaination      The 3 programmers are all accessing different variables and blocking each other, creating another deadlock
//                  For example, if we assume P stands for "Programmer" and A for "Answer"
//                  P1 accesses A2;     P2 accesses A3;     P3 accesses A1;
//                  Each programmer is attempting to access their own variable (e.g. P1 accesses A1)
//                  Since their own variable is in use by someone else and (presumably) locked, a new deadlock is created and none can continue