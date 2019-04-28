# Game Design
**Shiro**  
*By Base 23*
## Overview

### Genre
Primarily, this game is an RPG with a very basic story. The player will move around in eight directions in a top-down view of the various levels.
The actual gameplay mechanics of fights will feature rhythm-based button presses that will be designed to capture the personality of the fight and the enemies involved. 

### Background Story
The main character of the story, a kitten named Shiro, is trying to get back home to his family after being washed away in a flood. The kitten has to face things it is
afraid of in the form of battles.

### Objectives
The objective of the game is to *bring that cat home!*  
We want a game to have a sense of atmosphere that the player will feel emotionally invested in. We also want our game to be simple and accessible to all ages and all levels
of gaming experience. We plan on doing this by keeping the game controls simple and presenting the fights in minimalist ways. By keeping things simple, we will also have 
an easier-to-implement design to follow and complete by the deadlines.

### Inspiration and References
A lot of us are inspired by RPG games such as Undertale and Shadow of the Colossus. We appreciate the simple way that games like these are built
and we admire how the stories are more hands-off and told "in the background". The player is meant to experience the game world and feel emotion based on what they 
are seeing and experiencing as the protagonist.

## Game Play

### Game Modes
The game only has one main mode, which is the single player story.  
Within the story, there are two main gameplay states of the game, which are exploring the world and fighting an enemy. The game levels will be presented in isomorphic settings
built with tilesets. When the player engages in a fight, the game will transition to the fight state, which shows the player and the enemy in more of a side-by-side view.
The screen will also show a progressive track that will represent incoming attacks.

### Controls
The game will exclusively use keyboard controls. The player will use the arrow keys to move and the enter key to interact with objects and menus.
Battles will require rapid and accurate key presses, but the keys used will remain the directional arrow keys.

### Levels
Our base game will have one main environment: the city. The area is divided into sub-levels, which would essentially be
different screens the player moves through.
The first area of our first level will be designed as a tutorial for the player to get used to the game controls. They will be fairly conventional for moving.  
For the battle system, keys to be pressed will be displayed on the screen and will not deviate from the basic movement and interactive mechanics.

### Player(s)
There will be only one player. The player will basically need two seperate classes for the two game states- in the battle, and in the game world.

### Non-playable characters
Our game features enemies that wander around on the game overworld and fight the player in battles when they collide. In the overworld, enemy sprites are represented by a 
generic imp-like enemy that will become one of three enemy types with it's own unique attack pattern when the player enters a battle. 

From a design perspective, both the player and the enemy have similar traits, such as bounding boxes and stamina. Our battle class will take in whatever enemy the player
collided with, as well as the player, and keep track of their stamina as they fight.

## Assets

### Graphics
Our graphics will be vector-based and where possible, digitally hand-drawn by our artists. It will not be feasible for all of our art to come from our team's artists.
We may need to use online resources, such as OpenGameArt, to fill in the gaps.

### Text
In game menus, our font is a fancier script, but for pop-up alerts such as the messages for attempting to run away or getting perfect hits, we have used Segoe UI font. 
It is an easy-to-read font that is already installed on Windows 10, so we think it is a good choice.

### Sound
Unfortunately, nobody on our team is a sound designer. Luckily, there exist websites with assets for video games! We used OpenGameArt, Incompetech, and Freesound to 
supplement our game with contextual music and sound effects for better feedback. The sounds we have added have made the game much more responsive to player input and overall
more fun to play.

### What makes Shiro fun?
Shiro is an exploration game that is designed to make the player feel for the cat and become determined to get him home to his family. The battles with rhythm key presses make it fun 
for the player to stay in a groove to make sure that they are not defeated. Without the rhythm, the player could potentially lose the groove. Shiro is a fun game to explore his world
and discover how to get him home.

## Screenshots & Demo Videos
See the Art document for concept art and screen mock-ups.

## Menu Screens


Starting Menu:
![alt text](https://kgcoe-git.rit.edu/eh8582/gdaps2-2185-section_2_Team_3/raw/master/src/Screenshots%20of%20game/ShiroPressEnter.PNG "Start menu - Press Enter")

Main Menu:
![alt text](https://kgcoe-git.rit.edu/eh8582/gdaps2-2185-section_2_Team_3/raw/master/src/Screenshots%20of%20game/StartMenu.PNG "Main Menu - Instructions and Start")

Instructions Screen:
![alt text](https://kgcoe-git.rit.edu/eh8582/gdaps2-2185-section_2_Team_3/raw/master/src/Screenshots%20of%20game/instructionsscreen.png "Instructions Screen")

A Single Level with door collision shown:
![alt text](https://kgcoe-git.rit.edu/eh8582/gdaps2-2185-section_2_Team_3/raw/master/src/Screenshots%20of%20game/Gameplay.PNG "A single level with a door collision shown")

In Battle:
![alt text](https://kgcoe-git.rit.edu/eh8582/gdaps2-2185-section_2_Team_3/raw/master/src/Screenshots%20of%20game/bbattle.PNG "Picture in battle")

## External References
In order to suplement our game with extra feedback, we have used public-domain sound effects from freesound.org and music tracks made by Kevin Macleod from the
 website incompetech.
 
 [Incompetech](https://incompetech.com)  
 [Freesound](https://freesound.org)
 
 
We are currently using an edited version of this free to use tileset. Not only did we change some of the tones in it, but we also added our own tiles.
http://freegameassets.blogspot.com/2013/09/blog-post_20.html
