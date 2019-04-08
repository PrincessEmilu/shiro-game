# Production

## Meeting Minutes
_Check out the [Meeting Log](mtgLog.md) for notes about individual meetings!_

## Scope

### Minumum Viable Product (MVP)
The MVP will be a working battle system that is accesible within a level that the player can walk around in and explore.    

In order to accomplish this, we have identified the following components
*  A level class that can read a text file and intitiaalize a given level
*  A player class that can move around on the screen and interact with objects
*  An enemy class that can colide with the player and initialize a battle
*  A battle class that initializes the battle system
*  A player class that depcits the player in a battle scene and handles animations
*  An enemy class that depicts the enemy in the battle scene and handles attacking
*  A controller object that monitors player condition

### Extra Features
There are several extra features that would make our game shine and be more interesting. In a sense, these are stretch goals that can only
be implemented after getting our main mechanics working.
*  Minor detailed animations
*  Puzzles within levels
*  A save system with checkpoints
*  Music for the levels and the battles
*  A more solid story that uses dialogue and cutscenes
*  Special ambient effects for various environments
*  Ambient sound effects

## Task Management
Our group plans to utilize Trello to maintain deadlines and help with smooth task management and assignments.

### Task Breakdowns
Trello is being used in a different way now in a much more effective way. Currently, it is now being used in a four section layout. The first section is called "To-Do" where
important tasks are created that are not done yet and marked with a color that signifies importance (red = most important, lighter colors = less important. The second is called "Doing"
where the tasks are assigned to certain team members and are in the process of doing. The third is called "Done" where the assigned task member moves their doing task when they 
finish the task. Here they also change the color to green for done. The last is called "Bugs" for bugs that are found and not fixed right away in something that is finished.

Our Trello Board can be located here: https://trello.com/b/n6mIV6kK/shiro-the-game

Here is a screen cap of the board:

![alt text](https://kgcoe-git.rit.edu/eh8582/gdaps2-2185-section_2_Team_3/raw/master/doc/Documents/trello.PNG "Trello Board")

## Testing
At this point, our plans for testing are simply to play the game amongst ourselves and to share it with others. 

New testing methods include drawing the boxes around the player and enemy temporarily to show where their collisions are happening. There is also a large bounding box around the player
that he can not leave and it can not leave the screen to add buffer space. We also draw that for testing purposes to see how the bounding is working to make sure the view looks good for the user.
Drawing these boxes has helped significantly show where some issues have come from.
