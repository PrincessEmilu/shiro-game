# Production

## Meeting Minutes
_Check out the [Meeting Log](mtgLog.md) for notes about individual meetings!_

## Scope

### Minumum Viable Product (MVP)
The MVP will be a working battle system that is accesible within a level that the player can walk around in and explore.    

Part of the battle that we want minimmally want finished is keys that can be changed through the key generator and work with the presses in the hitbox. There will also be an option
to fight or runaway with a slight penalty for running away. Currently the penalty will be increased key speed for other fights.

For the level we minimally want a few (6-7) enemies on the screen moving in their positions with a door that the player can get to to finish it. We also want collidable tiles
so the player will have to go around them to make it harder to get to the door.

### Extra Features
There are several extra features that would make our game shine and be more interesting. In a sense, these are stretch goals that can only
be implemented after getting our main mechanics working.
*  More levels
*  Worse penalty for fleeing attacks
*  Max number of attacks you can flee
*  Lose stamina for incorrect or early key presses in battle
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
