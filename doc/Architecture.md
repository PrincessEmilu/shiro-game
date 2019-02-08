# Architecture

## Overview

## General Approach

## State Machine(s)

##### We are planning on having 4 total state machines. We will have an overarching game state machine that will detail the current context of what the player is seeing and the actions necessary for that scene. The player's movement state machine to describe the animations for the player asset as well as one for the enemy. The final state will be a battle specific state to detail the different states of the battle system.

##### The game state machine will be the largest state machine we handle for this game. This state machine will have 6 different states, the title screen, the main menu, the level or game state, the pause menu, the battle state, and the game over state. The title screen state will be simple and display a large image as well as the title for our game. It will have litle user interactibility, other than pressing the Enter key to progress to the menu state. The menu state will also be simple with few images, but it will provide slightly more use interactibiliy. The menu state will basically draw text to provide the following options for the player to choose: start, load, and quit. Pressing Enter on start or load will transition to the level state and quit will transition to the title screen. 

##### The Player state machine will contain 8 states, two for each direction. One of the state is set to face that direction and the other to walk in that direction. This state machine wil mainly focus on which direction to move the player as well as which animation to use.

##### The Enemy state machine will be similar to the player state machine but the transition would be triggered by hard code instead of user input.

##### The Battle state machine will 4 states an attack state, an idle state, victory state, and losing state. The battle will begin in the idle state in which the player is given two options, stay or leave. If the player leaves the game state will transition back to level and the enemy will remain in the world until defeated. If the player chooses to stay, the battle state machine will transition to the attack state. The attack state will be the main focus of the state machine. This state will contain the user interface for battle in which the player will the correct arrow at the aorrect time in order to dodge the incoming attacks. In this state the player will stamina for each arrow missed or pressed too early. After the timer runs out, we will transition back to the idle state. During the attack state, if a player runs out of stamina, the state will change to the losing state. Likewise, if the player manages to survive the battle by depleting the enemy's stamina, the state will switch to the victory state. Both states are simple screens that transitions back to the game state level either through a previous save, in the losing state, or from where the battle occurred, in the victory state.

## OO Design

## External Tool
