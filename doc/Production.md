# Production

## Meeting Minutes
_Keep the [Meeting Log](mtgLog.md) log up to date to track when your team meets and the main topic(s) of discussion._

_Make sure to also keep the weekly meeting time on the main [README](../README.md) up to date._

## Scope
*Complete this during Milestone 1 once you have established a general game concept and feature list. Update it as needed throughout the semester.*

### Minumum Viable Product (MVP)
_What are the minimal specifications you need to have a working version of the game by the end of the semester?_

### Extra Features
_Which elements of the game fall under “if we have time”?_ How are you going to develop the game, test it, and integrate all group members’ code together? What deliverables will you have throughout the project?

## Task Management
*Complete this during Milestone 1 and update it as needed throughout the semester.*

_Having a game design and architecture plan so you know what you want to implement is crucial, but it won't be enough unless you also break it down into tasks that individuals can claim and work on. Tasks must also be prioritized based on your desired scope (i.e. MVP above) and dependencies between them._

_How you manage tasks is up to you, but you are *required* to establish some form of task tracking and keep it up to date. GitLab has issue tracking built in with the option of displaying issues in distinct lists on a [board](https://docs.gitlab.com/ee/user/project/issue_board.html) (and assgning issues to specific developers). You can also do something similar using [Trello](https://trello.com/). The tool you use doesn't matter, but you should, at a minimum, be able to know, at any given time, which tasks are:_
- _Waiting to be defined_: In other words, you know something needs ot be done for this, and you don't want to forget about it, but you haven't completed enough game design or figured out how to implement it yet.
- _Waiting to be done_: You know everything you need to know to start implementation on this (or writing/drawing if it's a documentation or art task), but no one is working on it yet.
- _In progress_: Tasks that someone is actively working on (these should also someone indicate *who* is working on it)
- _Done_: All set (documented, implemented, tested, etc.)

_Whatever you decide to do, add instructions/links here so that everyone can find your current task list._

### Task Breakdowns
_In order to divide work effectively, take some time to consider how you'll break down tasks into independent "chunks". Some potential categories of work include:_
- _Character and Object Implementation: This person works on any core classes for characters, enemies and other game objects. It may be advantageous for some of these classes to be used by both the game and the external tool (such as a behavior or map editor). A variety of algorithms and data structures may be used such as character movement/physics and collision detection. _
- _Tool Builder / Level or Map Editor:_ This person designs all map or level-related classes and may build the external tool. Since characters and items usually appear in a game map or level, the person carrying these responsibilities should work closely with the character and object implementation person to figure out the file format & saving/loading process for the game before either begins work._
- _Game View:_ This person is in charge of the basic drawing of the screens in the game, from the GUI to the game screens themselves. Note that if it is a graphics intensive game, a role like this may be better suited for two people. Animation loops can satisfy the algorithm requirement for this part of the assignment as well as the many routines that may be used for “camera” movement and item drawing._ 
- _Gameplay:_ This person is generally in charge of implementing the logic behind the game, such as the differences between game states (world map and battle screens, for instance).  The gameplay role usually involves creating the finite state machine(s) that drive the game._


## Testing
*Start this this during Milestone 1 and complete it in Milestone 2. Update it as needed throughout the semester.*

_While you won't be making detailed test plans or doing any automated testing for this project, you should think about how you will test your game. Will you just play through it a lot? Are there specific scenarios you need to test? What questions will you ask of your play testers? Where/how will you track bugs that you find? (GitLab does have support for [issue tracking](https://docs.gitlab.com/ee/user/project/issues/). If you want help using this, ask your instructor._