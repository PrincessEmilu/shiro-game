# Architecture

## Instructions
Decide on the program architecture of your game. Your game must be data driven and must read in content from one or more files. Some things to consider:
- What classes will you need in your game?
- How will your characters, enemies & NPCs be handled?
- Will there be some common base classes that are extended by different entities in your game?
- Will you need any abstract classes and/or interfaces?
- How will input be handled?

Your architecture must describe ALL of the classes and interactions that will occur during your game development.  Although game development is a largely iterative process, plan as much as possible in advance.  “We’ll figure it out later” won’t work here. Do recognize that certain architecture decisions may change throughout the development process, and that is completely acceptable (and often normal for game dev!)

Your game may not use third party software (physics systems, pre-built engines, etc.) unless given the ok by the professor. Previous experiences have shown that often when such software is used, a greater part of the quarter is spent learning how to use the software rather than learning about algorithms and data structures, which is what this course is about. 

### Milestone 1
*Milestone 1 must include:*
- A diagram of all the classes and interfaces that your project will implement, and display the relationships between those classes. 
- A state diagram of the primary game modes with at least a high level description of how you plan to implement this (i.e. which classes it impacts).

### Milestone 2
*Milestone 2 must include:*
- Updates to your diagrams, etc. as you refine your design and implementation plans.
- The technical design and initial implementation for an  external tool to support your game development.

### Milestone 3
*By the end of milestone 3:*
- _Your basic game algorithms (such as collision detection & response, animations, etc.) should be finalized for this milestone._  This means they should work the way you want, so you can move on to other areas of your game for the last milestone.  If you’re stuck or having problems, you can always stop by office hours or ask one of the gaming tutors for help.
- _All “minimally required” states of your game should be reachable._  They don’t have to all work perfectly or look pretty, but they should all be implemented at this stage.  This includes: menus, pause screens, level selection, battle modes, etc.  If you have some extra states that are on your “if we have time” list, they don’t need to be implemented yet.
- _The external tool should be finished so that it can be used for the last milestone._  It should read & write files as necessary to create maps, settings, etc. for your game.  - _Other areas of the game should be progressing as well._  After this milestone you only have a few weeks until the game is due.  Follow your group’s timeline and make adjustments where necessary.

You may also find it useful to implement some of the new data structures and algorithms we have talked about this quarter: trees, hash tables, graphs, etc.  While not required, you may find that they can simplify some areas of your code or allow you to implement new features.


This [UML class diagram reference](https://www.uml-diagrams.org/class-reference.html) probably has more than you'll need, but it's a good starting point.

_The remaining sections in this document are a rough guide. You can use/change them as you see fit._

## Overview

## General Approach

## State Machine(s)

## OO Design

## External Tool
*Design and initial implementation required in milestone 2. Completed in milestone 3.*

_Since the games are required to be data-driven, your team must develop one external tool that helps to get data into a useable format for your game.  These tools should allow the team to quickly and easily alter some core data that the game uses.  This data will be stored in an external file, and read in when the game starts._

_The tool that you use must make sense for your game.  A game with platforms might want to create a level editor, while a game with waves of enemies might want a tool to assist with the types and numbers of enemies in each wave.  Tools that allow you to quickly tweak default game settings (such as player speed, starting health) or handle AI movement could be good choices, too._

_It is common to use something other than MonoGame to create these external tools.  Windows Forms is a popular choice because of the available UI components (buttons, sliders, text boxes, etc.)  The exact type of tool you create is up to you._
