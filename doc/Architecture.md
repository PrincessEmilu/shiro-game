# Architecture

## Overview

We are planning to create a complex architecture in order to keep such a large project clean and easy to read. We plan to implement 4 finite state machines and 3 main parent classes. By the end of our project we will have implemented many child classes. we plan to do this in an organized manner so that it does not become too overwhelming and instead allows for clarity through the specific and concise classes.

## General Approach

Our general approach to the architecture of this game, is to create all our necessary assets in the cleanest manner we can achieve. We plan to implement 4 finite state machines and 3 parent classes with their many children. We plan to have a state machine for the game state, the player state, the enemy state, and the battle state. Each of these state are designed to make our code cleaner and assist us when creating this large project. The 3 parent classes achieve the same goal. We plan to have them be abstract classes so that we have the base methods for each child class mostly taken care of. These classes will be GameObject, World, and Battle. Each of these classes focus on a main part of our game and will be very useful when developing it.

## State Machine(s)

We are planning on having 4 total state machines. We will have an overarching game state machine that will detail the current context of what the player is seeing and the actions necessary for that scene. The player's movement state machine to describe the animations for the player asset as well as one for the enemy. The final state will be a battle specific state to detail the different states of the battle system.

The game state machine will be the largest state machine we handle for this game. This state machine will have 6 different states, the title screen, the main menu, the level or game state, the pause menu, the battle state, and the game over state. The title screen state will be simple and display a large image as well as the title for our game. It will have little user intractability, other than pressing the Enter key to progress to the menu state. The menu state will also be simple with few images, but it will provide slightly more use intractability. The menu state will basically draw text to provide the following options for the player to choose: start, load, and quit. Pressing Enter on start or load will transition to the level state and quit will transition to the title screen. The level state will be the most complex state to code as it will have to contain data for the levels, enemies, and the player. This is the state in which all the gameplay will happen.From this state, pressing the escape key will transition to the pause state. This state will keep the gameplay data as it was left beforehand and await user input in the form of a menu with the options to resume, load, and quit. Resume and load both lead back into the game state but with different actions and the quit option transitions to the menu state. Also during the game state, if the player encounters an enemy, the state transitions to the battle state. The battle state will also be complex as it has many interface options to handle. The main focus of this state will be to provide the battle interface for the player and keep track of the player and enemy stamina. If the battle is won or the player chooses to run away this state transitions back to the game state and gameplay resumes. If the player loses, they are transitioned to the final state, the game over state. The game over state is another simple menu with the options to load or quit. Load will transition back into the game state and quit will transition into the menu state.

![alt text](https://kgcoe-git.rit.edu/eh8582/gdaps2-2185-section_2_Team_3/raw/master/doc/Documents/Game_State_Machine.png "Game State Machine")

The Player state machine will contain 8 states, two for each direction. One of the state is set to face that direction and the other to walk in that direction. This state machine wil mainly focus on which direction to move the player as well as which animation to use.

The Enemy state machine will be similar to the player state machine but the transition would be triggered by hard code instead of user input.

The Battle state machine will 4 states an attack state, an idle state, victory state, and losing state. The battle will begin in the idle state in which the player is given two options, stay or leave. If the player leaves the game state will transition back to level and the enemy will remain in the world until defeated. If the player chooses to stay, the battle state machine will transition to the attack state. The attack state will be the main focus of the state machine. This state will contain the user interface for battle in which the player will the correct arrow at the correct time in order to dodge the incoming attacks. In this state the player will stamina for each arrow missed or pressed too early. After the timer runs out, we will transition back to the idle state. During the attack state, if a player runs out of stamina, the state will change to the losing state. Likewise, if the player manages to survive the battle by depleting the enemy's stamina, the state will switch to the victory state. Both states are simple screens that transitions back to the game state level either through a previous save, in the losing state, or from where the battle occurred, in the victory state.

![alt text](https://kgcoe-git.rit.edu/eh8582/gdaps2-2185-section_2_Team_3/raw/master/doc/Documents/Battle_State_Machine.png "Game State Machine")

## OO Design

The classes in our game consists of one abstract class called GameObject which has three children, Player, Enemy and AttackKey. GameObject is very basic which has a Draw and Update method along with a Position property.
Enemy also has a child and that is the Boss class which is very similar to just a regular enemy. Boss is projected to have more uniqueness to it in Milestone 4 when the game is polished.
The inheritance can be visualized with this diagram that also shows each class' different methods and properties.

![alt text](https://kgcoe-git.rit.edu/eh8582/gdaps2-2185-section_2_Team_3/raw/master/doc/Documents/GameObject_Class_Diagram.png "GameObject Class Diagram")

Other classes that our game utilizes are Level, Camera, Battle, ImportAttackPatterns, Helpers, and CollisionItem.

Level is designed to load in a tileset from the level editor external tool. Level also has its own Draw method that will draw all of the tiles based on how they are selected in the editor.

Camera is designed to handle the movement of the area that the user will be able to see. The position of the camera is controlled with a vector and changes based on the key presses of the user.

Battle reads the attack keys from the attack key generator external tool. This class also displays the attack keys and moves them across the screen and tests to make sure the user presses the correct key when it is in the drawn hitbox.
It uses its own Draw method to draw the arrows and hitbox on the screen.
Battle tests to see if the user has won, lost, or ran away from the battle.

ImportAttackPatterns is a class that reads in the patterns from the attack key generator and allows them to be used in Battle.

Helpers is a class that is designed to hold methods that are used frequently. It currently only has a method called SingleKeyPress which returns whether or not the key was pressed once.

CollisionItem creates items that the player can collide with and interact differently depending on what the intended item is. For example, if the item is a door, there will be a different interaction with the player if it was not a door.

Input from the user is almost entirely with the arrow keys. On the main menu, the user will use the arrow keys to highlight start or instructions and enter to select either one. Escape can be used to go back and exit the game.
Once the user is in the game, they can use the arrow keys to move the player around the screen. Escape is used to pause the game. The pause menu works the same way as the main menu does with the arrow keys and enter.
Escape also works as resume when in the pause menu. When the user moves into collision with an enemy, it switches to battle mode. In battle, the user can either elect to run away or fight using the arrow keys and enter.
If the user elects to run away they are punished with the attack keys becoming faster for other enemies. If they elect to fight, the arrow keys will be sent across the screen which the user will need to press
the corresponding arrow key when it is in the hitbox.

Below is a visualization of the other classes that are independent and have no inheritance.

![alt text](https://kgcoe-git.rit.edu/eh8582/gdaps2-2185-section_2_Team_3/raw/master/doc/Documents/Other_Class_Diagrams.png "Other Classes Diagram")

## External Tool - Attack Creator

![alt text](https://kgcoe-git.rit.edu/eh8582/gdaps2-2185-section_2_Team_3/raw/master/doc/Documents/AttackKeyPopUpStart.PNG "Pop up window for attack key tool")

One of our external tools is a key attack generator, which is being used to generate all the attack patterns for our boss and enemies. If we didn't have this editor, we would have to hard code each attack pattern... 
which would be crazy for something like a 400 key attack pattern! Above, is a picture of what pops up when you run the program; It will ask you for how many keys will be in the attack pattern you are generating. Once you set your number 
between one and four hundred, it will pop up with this screen below which generates the set number of empty key slots you entered:

![alt text](https://kgcoe-git.rit.edu/eh8582/gdaps2-2185-section_2_Team_3/raw/master/doc/Documents/GIFofKeys.gif "GIF of external tool")

As you can see in the GIF, while it starts out empty, you can click on the empty slots to set keys which consist of: Up, Down, Left, Right and back to None. Once you are satisfied with the attack keys you have made, the button below can be clicked.
Once this button is clicked, it will pop up a "Save As.." pop up, which will save the file as whatever name you want as a .TXT file.

Here is a example output of the file:
![alt text](https://kgcoe-git.rit.edu/eh8582/gdaps2-2185-section_2_Team_3/raw/master/doc/Documents/ExportedTileSheet.png "Output file of the tool")

For our game, we are saving all the text files into this folder:
https://kgcoe-git.rit.edu/eh8582/gdaps2-2185-section_2_Team_3/tree/master/Shiro/AttackPatterns

This folder is hard coded as the only folder to look in for a file name that is passed into the constructor of a class in our main game called ImportAttackPatterns. What this class does is on creation, it will ask for a file name. If the file exists,
it will print into the console window that the keys were generated, while grabbing the number of keys from the top of the read file. Then, it will use the readed amount of keys to create an array of that size, as well as split the second read line
by each comma into a string array. Finally, for each string inside of the array, it will use the static method ConvertFromString to convert each string to a key based on a switch statement. This new key gets passed into a key array, which finally gets
passed into the enemy of the same file name if it exists. Below, is the flowchart of the outside generator and it's classes that it uses to make the form work. It then gets imported and follows the steps explained above.

![alt text](https://kgcoe-git.rit.edu/eh8582/gdaps2-2185-section_2_Team_3/raw/master/doc/Documents/KeyPressGenerator.png "KeyPressGenerator Diagram")

## External Tool - Level Editor

### Why
MonoGame and the Microsoft Xna Graphics Framework are very powerful tools for game developers, but unlike platforms such as Unity or Unreal Engine, it lacks a way
of graphically representing your game and the data involved in it. In some instances, that isn't a big deal, but many games have structured levels with hundreds, if
not thousands of tiles pieced together to make a single room or level in a game. Hard-coding such a graphically-intensive aspect of a video game would not only require
a lot of trial and error, but it would also be borderline illegible to read amongst a team.

*If only there were a better way...*

### What
Our team's level editor aims to bridge the gap between the abstract, human-unreadable understanding of a level and the final output of what the player actually
experiences when playing the game. This level editor allows a client to create levels of varying sizes and dimensions using tilesets of any size and number of tiles.
In addition, the client can also add collision to tile spaces, allowing the user to add behaviour to tiles beyond simply being a graphical depiction of a game world.

Our level editor supports saving to a text file that is relatively easy to read by a human, and easily loadable into a game project.

### How

**Overview**

Because a level can be easily represented and flexibly built with interchangeable tiles, it made sense to represent level data as a 2D Array. Each spot in said array
can hold some piece of data- anything from an integer to an image. The level editor built for our game works by accepting a tileset PNG, slicing it up into a list
of individual images that the user can select to paint with, and providing a canvas that is as many tiles wide/high as the user specifies. Under the hood, the individual
tiles are represented by an integer, and the map is simply saved as an array of integers. This design allows for tilesets with varying number of tiles and tile sizes.
Data for collisions is stored similarly by using a list of booleans.

**Generate Level**
Click on the button on the right on the toolbar. This button will open up a dialogue box asking the player for some specifications for their level.
*  Tileset- Click load to open a load file dialogue to open a PNG to use as the tileset
*  Tile Size- Provide the width/height value of individual tiles. The level editor assumes that tiles will be square-shaped, which is the standard for tilesets.
*  Tiles per row- The width of the level, in tiles
*  Tile per column- The height of the level, in tiles
*  Screens per row/column- The client should have an idea of how many tiles wide/high a single 'screen' of a level in their game will be. If the user prefers, they can
choose how many *screens* wide/tall their desired level will be. The previous dimensions for tiles per row/column will be multiplied by these dimensions to create a
map of the appropriate size. The user can simply leave these values at 1 if they prefer just measuring their overall level size in tiles.

![alt text](https://i.imgur.com/1EkFo41.png "Generate Level")
![alt text](https://i.imgur.com/3t27rJ2.png "Generate Level Example Values")


Once the user clicks generate, the generate window will close, a new grid of panels will be created i nthe main window,, and a paintbox window will open up. It may
take a moment or two to complete the map generation, based on the size of the level to be generated.

**Editing a Level**
Edit the level by click on the desired tile in the painbox, then by clicking on the desired square in the level editor. In order to mark a tile as being solid or
collidable, right-click on the tile. The tile will be given a blue background to denote it is solid. Right-click again to remove the collision.

![alt text](https://i.imgur.com/NTrFrMN.png "Example of level editing")

**Saving/Loading a Level**
Click on the center button on the toolbar in order to save the current level. This button opens up a dialogue window for saving a file, allowing the user to select
where they want to save the level.

In order to load an existing level, click on the button on the left of the toolbar. This will open up a window allowing the user to select the level file off of their
computer.

Level files are saved as plain .txt files that contain the size of the level, the size of the tiles, and two arrays, one of integers representing which tile from the
tileset is in that position, and the other mapping which tiles are meant to have collision.

![alt text](https://i.imgur.com/T4fc5i6.png "Level data under the hood")

### Known Issues
The level editor is currently fully-functional and seems to have no bugs. However, there are some quality-of-life issues that we are aware of and may improve as
part of milestone 4's polish.

*  The user can close the paintbox window, and there isn't any way for them to get it back without loading a file again or generating a new map.
*  The paintbox can be a little too small to work well with if the loaded tileset is very small.
*  The paintbox tiles do no accurately reflect which tile is currently selected. ALthough a selected tile will have a border added to it, the border is never removed.
*  No unique images for the toolbar buttons. The documentation should suffice for now.
*  Representation of collision tiles could be improved for tiles that have no transparency in them.
*  The user has to click individual tiles in order to paint tiles. Clicking and dragging to paint is more standard for editors such as this.