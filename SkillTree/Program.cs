using System.Collections.Generic;
using SkillTree;

//alternatively, move this to a file instead and parse from that
//create skills for mage class
SkillNode Mage = new SkillNode("Mage", null);
SkillNode Fireball = new SkillNode("Fireball", new List<SkillNode> {Mage});
SkillNode ElectroShock = new SkillNode("ElectroShock", new List<SkillNode> {Fireball});
SkillNode Freeze = new SkillNode("Freeze", new List<SkillNode> {Fireball});
SkillNode Thunderbolt = new SkillNode("Thunderbolt", new List<SkillNode> {ElectroShock});
SkillNode Snowstorm = new SkillNode("Snowstorm", new List<SkillNode> {Freeze});

//create skills for warriror class
SkillNode Warrior = new SkillNode("Warrior", null);
SkillNode Strike = new SkillNode("Strike", new List<SkillNode> {Warrior});
SkillNode Hit = new SkillNode("Hit", new List<SkillNode> {Warrior});
SkillNode DoubleStrike = new SkillNode("Double Strike", new List<SkillNode> {Strike});
SkillNode Slash = new SkillNode("Slash", new List<SkillNode> {Strike});
SkillNode Knockout = new SkillNode("Knockout", new List<SkillNode> {Hit});
SkillNode RoundhouseKick = new SkillNode("Roundhouse Kick", new List<SkillNode> {Slash, Knockout});

//testing functionality
Mage.ListData();
Fireball.ListData();
ElectroShock.ListData();
Freeze.ListData();
Thunderbolt.ListData();
Snowstorm.ListData();
Warrior.ListData();
Strike.ListData();
Hit.ListData();
DoubleStrike.ListData();
Slash.ListData();
Knockout.ListData();
RoundhouseKick.ListData();

//all of these should probably be saved in a list instead, e.g. MageSkills and WarriorSkills respectively
//this would require caching the index of the dependency nodes when creating them, so they can be reused later