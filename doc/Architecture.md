# Architecture

## Overview

We are planning to create a complex architecture in order to keep such a large project clean and easy to read. We plan to implement 4 finite state machines and 3 main parent classes. By the end of our project we will have implemented many child classes. we plan to do this in an organized manner so that it does not become too overwhelming and instead allows for clarity through the specific and concise classes.

## General Approach

Our general approach to the architecture of this game, is to create all our necessary assets in the cleanest manner we can achieve. We plan to implement 4 finite state machines and 3 parent classes with their many children. We plan to have a state machine for the game state, the player state, the enemy state, and the battle state. Each of these state are designed to make our code cleaner and assist us when creating this large project. The 3 parent classes achieve the same goal. We plan to have them be abstract classes so that we have the base methods for each child class mostly taken care of. These classes will be GameObject, World, and Battle. Each of these classes focus on a main part of our game and will be very useful when developing it.

## State Machine(s)

We are planning on having 4 total state machines. We will have an overarching game state machine that will detail the current context of what the player is seeing and the actions necessary for that scene. The player's movement state machine to describe the animations for the player asset as well as one for the enemy. The final state will be a battle specific state to detail the different states of the battle system.

The game state machine will be the largest state machine we handle for this game. This state machine will have 6 different states, the title screen, the main menu, the level or game state, the pause menu, the battle state, and the game over state. The title screen state will be simple and display a large image as well as the title for our game. It will have litle user interactibility, other than pressing the Enter key to progress to the menu state. The menu state will also be simple with few images, but it will provide slightly more use interactibiliy. The menu state will basically draw text to provide the following options for the player to choose: start, load, and quit. Pressing Enter on start or load will transition to the level state and quit will transition to the title screen. The level state will be the most complex state to code as it will have to contain data for the levels, enemies, and the player. This is the state in which all the gameplay will happen.From this state, pressing the escape key will transition to the pause state. This state will keep the gameplay data as it was left beforehand and await user input in the form of a menu with the options to resume, load, and quit. Resume and load both lead back into the game state but with different actions and the quit option transitions to the menu state. Also during the game state, if the player encounters an enemy, the state transitions to the battle state. The battle state will also be complex as it has many interface options to handle. The main focus of this state will be to provide the battle interface for the player and keep track of the player and enemy stamina. If the battle is won or the player chooses to run away this state transitions back to the game state and gameplay resumes. If the player loses, they are transitioned to the final state, the game over state. The game over state is another simple menu with the options to load or quit. Load will transition back into the game state and quit will transition into the menu state.

![alt text](https://kgcoe-git.rit.edu/eh8582/gdaps2-2185-section_2_Team_3/raw/master/doc/Documents/Game_State_Machine.png "Game State Machine")

The Player state machine will contain 8 states, two for each direction. One of the state is set to face that direction and the other to walk in that direction. This state machine wil mainly focus on which direction to move the player as well as which animation to use.

The Enemy state machine will be similar to the player state machine but the transition would be triggered by hard code instead of user input.

The Battle state machine will 4 states an attack state, an idle state, victory state, and losing state. The battle will begin in the idle state in which the player is given two options, stay or leave. If the player leaves the game state will transition back to level and the enemy will remain in the world until defeated. If the player chooses to stay, the battle state machine will transition to the attack state. The attack state will be the main focus of the state machine. This state will contain the user interface for battle in which the player will the correct arrow at the aorrect time in order to dodge the incoming attacks. In this state the player will stamina for each arrow missed or pressed too early. After the timer runs out, we will transition back to the idle state. During the attack state, if a player runs out of stamina, the state will change to the losing state. Likewise, if the player manages to survive the battle by depleting the enemy's stamina, the state will switch to the victory state. Both states are simple screens that transitions back to the game state level either through a previous save, in the losing state, or from where the battle occurred, in the victory state.

![alt text](https://kgcoe-git.rit.edu/eh8582/gdaps2-2185-section_2_Team_3/raw/master/doc/Documents/Battle_State_Machine.png "Game State Machine")

## OO Design

The classes in our game consists of one abstract class called GameObject which has three children, Player, Enemy and AttackKey. GameObject is very basic which has a Draw and Update method along with a Position property.
Enemy also has a child and that is the Boss class which is very similar to just a regular enemy. Boss is projected to have more uniqueness to it in Milestone 4 when the game is polished.
The inheritance can be visualized with this diagram that also shows each class' different methods and properties.

![alt text](https://kgcoe-git.rit.edu/eh8582/gdaps2-2185-section_2_Team_3/raw/master/doc/Documents/GameObject_Class_Diagram.png "GameObject Class Diagram")

Other classes that our game utilizes are Level, Camera, Battle, ImportAttackPatterns, Helpers, and CollisionItem.

Level is designed to load in a tileset from the level editor external tool. Level also has its own Draw method that will draw all of the tiles based on how they are selected in the editor.

Camera is designed to handle the movement of the area that the user will be able to see. The postition of the camera is controlled with a vector and changes based on the key presses of the user.

Battle reads the attack keys from the attack key generator external tool. This class also displays the attack keys and moves them across the screen and tests to make sure the user presses the correct key when it is in the drawn hitbox.
Battle tests to see if the user has won, lost, or ran away from the battle.

The characters consist of only the player and enemies they interact with and will be handled by their respective classes. The Player class will be similar in structure to the of Homework One with its own Update method and any other methods/variables (stats) the player will have. Enemy will be similar, it will have its own Update method with possible movement methods and its own stats.

The common base classes are the GameObject and World classes because they extend to multiple different children classes.

The abstract classes we have, as stated above, are GameObject, World, and Battle.

Input will be handled in two different ways, the first being the movement which will be put into Player's Update method and will move similarly to that of Homework One. The other type of input will be handled by the Battle class. In a Battle state, the player will have to time key presses at the right time so they can dodge attacks. There will be a method that takes the input from the key presses and tests to see if they were pressed at the right time.

## External Tool
