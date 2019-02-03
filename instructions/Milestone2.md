# Milestone 2
**Starting the technology**
Your main goal for milestone 2 is getting a “bare bones” version of your game up and running.  This means the game should start up and there is some core functionality present, such as character movement, game states, a menu system, etc.  It is a good idea to have code stubs for most components, in addition to working implementations of core functionality.

Since the games are required to be data-driven, your team must develop one external tool that helps to get data into a useable format for your game.  These tools should allow the team to quickly and easily alter some core data that the game uses.  This data will be stored in an external file, and read in when the game starts. The tool does not have to be 100% complete for this milestone, but it should be functional.

## [Architecture](doc/Architecture.md)
**External Tool:** Design and initial implementation required in milestone 2. Completed in milestone 3.
Since the games are required to be data-driven, your team must develop one external tool that helps to get data into a useable format for your game.  These tools should allow the team to quickly and easily alter some core data that the game uses.  This data will be stored in an external file, and read in when the game starts.

The tool that you use must make sense for your game.  A game with platforms might want to create a level editor, while a game with waves of enemies might want a tool to assist with the types and numbers of enemies in each wave.  Tools that allow you to quickly tweak default game settings (such as player speed, starting health) or handle AI movement could be good choices, too.

It is common to use something other than MonoGame to create these external tools.  Windows Forms is a popular choice because of the available UI components (buttons, sliders, text boxes, etc.)  The exact type of tool you create is up to you.

**Milestone 2 must include:**
- Updates to your diagrams, etc. as you refine your design and implementation plans.
- The technical design and initial implementation for an  external tool to support your game development.

## [Presentation](doc/Presentations.md)
Your group will present your progress up to this point.  

Using a shorter PowerPoint presentation than your first one, discuss anything that has changed since your initial plan: any changes to architecture, design, interfaces, or your timelines. 

Discuss where your group feels they are in the development timeline, and what they expect to have done for the next milestone.  

Lastly, demonstrate your game.  

## [Implementation](src/ReleaseNotes.md)
**By the end of milestone 2 you should have:**
- A skeleton for all major states, classes and behavior in your game
- Implementation of the basic controls to drive the game
- The skeleton of your exeternal tool with core functionality complete (i.e. basic file IO works even if not all information is complete and it isn't fully integrated into your game)

