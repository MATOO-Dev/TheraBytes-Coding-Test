using System;
using System.Collections.Generic;

namespace SkillTree
{
    internal class SkillNode
    {
        //name of the skill node
        public string Name {get; private set;}
        //whether the skill node is currently locked or unlocked
        public bool IsLocked {get; private set;}
        //list of dependency nodes
        private List<SkillNode> NodeDependencies;

        //constructor
        public SkillNode (string nodeName, List<SkillNode> dependencies)
        {
            Name = nodeName;
            NodeDependencies = dependencies;
            IsLocked = true;
        }

        //check whether the node can be unlocked
        public bool CanBeUnlocked()
        {
            //first, check if parents are available. if no parents are available, the node can be unlocked
            if(NodeDependencies == null || NodeDependencies.Count == 0)
                return true;
            //if parents are available, check if they are already unlocked. if any parent is still locked, return false
            foreach (SkillNode current in NodeDependencies)
            {
                if(current.IsLocked)
                    return false;
            }
            //if all previous checks were passed, return true
            return true;
        }

        public void UpdateName(string newName)
        {
            Name = newName;
        }

        public void UpdateDependencies(List<SkillNode> newDependencies)
        {
            NodeDependencies = newDependencies;
        }

        public void ListData()
        {
            Console.Write("Name: " + Name + "\n");
            Console.Write("Currently locked: " + IsLocked + "\n");
            if(IsLocked)
            {
                Console.Write("Node depends on: ");
                if(NodeDependencies != null)
                    foreach(SkillNode current in NodeDependencies)
                    {
                        Console.Write(current.Name + ", ");
                    }
                Console.Write("\n" + "Available for unlock: " + CanBeUnlocked().ToString() + "\n" + "\n");
            }
        }
    }
}