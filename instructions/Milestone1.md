# Milestone 1
**Creating a plan**
_You main goal for milestone 1 is establishing your game concept, game play, and a prioritized feature list. Once you have this, you'll make initial art/UI mockups and start your technical design (state machines, classes, etc.). During milestone 1, you'll also establish how your team will keep itself organized and manage tasks._

## [Game Design](doc/GameDesign.md)
Decide how the game should be designed. All games must be 2D, but the design is up to your group. You may want to look at the often unique designs of the games submitted to the Independent Game Festival. Some things to consider:
- What genre is the game? 
- Is it a knockoff game? 
- What are the objectives of the game? 
- How many players does the game allow? 
- Is it turn-based or real-time? 
- What is the look-and-feel of the game? 
- Will the game have multiple levels?
- What makes the game fun?

You should not simply implement an existing game (like Pac Man, Tetris or Chess).  If you want to use an existing game as inspiration, that is great, but make it your own.  Five points of this assignment will be dedicated to the creativity shown in game design.

**This document should be largely complete by the end of milestone 1. In subsequent milestones (especially #2), you may need to refine the concept and add details.**

## [Art and Interface](doc/Art.md)
Describe how your game looks and feels.  Does it have a visual style?  How will you gather art for the game?  How does the user interact with your game?  Describe both the interface and the control scheme(s).  What are the user interface requirements (health bars, ammo, units, etc.)?  

**Milestone 1 must include a UI prototype with a mockup of all menus, user interfaces and example game screens.**  While these will be a rough draft, it is expected that each group will spend time thinking about what the user really needs and how the game will look.  Having a solid plan makes implementing the game easier later. In subsequent milestones, you will refine the concept and add details (especially screenshots, etc.).

## [Architecture](doc/Architecture.md)
Decide on the program architecture of your game. Your game must be data driven and must read in content from one or more files. Some things to consider:
- What classes will you need in your game?
- How will your characters, enemies & NPCs be handled?
- Will there be some common base classes that are extended by different entities in your game?
- Will you need any abstract classes and/or interfaces?
- How will input be handled?

Your architecture must describe ALL of the classes and interactions that will occur during your game development.  Although game development is a largely iterative process, plan as much as possible in advance.  “We’ll figure it out later” won’t work here. Do recognize that certain architecture decisions may change throughout the development process, and that is completely acceptable (and often normal for game dev!)

Your game may not use third party software (physics systems, pre-built engines, etc.) unless given the ok by the professor. Previous experiences have shown that often when such software is used, a greater part of the quarter is spent learning how to use the software rather than learning about algorithms and data structures, which is what this course is about. 

**Milestone 1 must include:**
- A diagram of all the classes and interfaces that your project will implement, and display the relationships between those classes. 
- A state diagram of the primary game modes with at least a high level description of how you plan to implement this (i.e. which classes it impacts).

## [Production](doc/Production.md)
### Scope
**Minumum Viable Product (MVP)**
What are the minimal specifications you need to have a working version of the game by the end of the semester?_

**Extra Features**
Which elements of the game fall under “if we have time”?_ How are you going to develop the game, test it, and integrate all group members’ code together? What deliverables will you have throughout the project?

### Task Management
Having a game design and architecture plan so you know what you want to implement is crucial, but it won't be enough unless you also break it down into tasks that individuals can claim and work on. Tasks must also be prioritized based on your desired scope (i.e. MVP above) and dependencies between them.

How you manage tasks is up to you, but you are **required** to establish some form of task tracking and keep it up to date. GitLab has issue tracking built in with the option of displaying issues in distinct lists on a [board](https://docs.gitlab.com/ee/user/project/issue_board.html) (and assgning issues to specific developers). You can also do something similar using [Trello](https://trello.com/). The tool you use doesn't matter, but you should, at a minimum, be able to know, at any given time, which tasks are:
- _Waiting to be defined_: In other words, you know something needs ot be done for this, and you don't want to forget about it, but you haven't completed enough game design or figured out how to implement it yet.
- _Waiting to be done_: You know everything you need to know to start implementation on this (or writing/drawing if it's a documentation or art task), but no one is working on it yet.
- _In progress_: Tasks that someone is actively working on (these should also someone indicate **who** is working on it)
- _Done_: All set (documented, implemented, tested, etc.)

Whatever you decide to do, add instructions/links in your production document so that everyone can find your current task list._

#### Task Breakdowns
**Start this this during Milestone 1 and complete it in Milestone 2. Update it as needed throughout the semester.**
In order to divide work effectively, take some time to consider how you'll break down tasks into independent "chunks". Some potential categories of work include:
- _Character and Object Implementation:_ This person works on any core classes for characters, enemies and other game objects. It may be advantageous for some of these classes to be used by both the game and the external tool (such as a behavior or map editor). A variety of algorithms and data structures may be used such as character movement/physics and collision detection.
- _Tool Builder / Level or Map Editor:_ This person designs all map or level-related classes and may build the external tool. Since characters and items usually appear in a game map or level, the person carrying these responsibilities should work closely with the character and object implementation person to figure out the file format & saving/loading process for the game before either begins work.
- _Game View:_ This person is in charge of the basic drawing of the screens in the game, from the GUI to the game screens themselves. Note that if it is a graphics intensive game, a role like this may be better suited for two people. Animation loops can satisfy the algorithm requirement for this part of the assignment as well as the many routines that may be used for “camera” movement and item drawing. 
- _Gameplay:_ This person is generally in charge of implementing the logic behind the game, such as the differences between game states (world map and battle screens, for instance).  The gameplay role usually involves creating the finite state machine(s) that drive the game.

### Testing
**Start this this during Milestone 1 and complete it in Milestone 2. Update it as needed throughout the semester.**

While you won't be making detailed test plans or doing any automated testing for this project, you should think about how you will test your game. Will you just play through it a lot? Are there specific scenarios you need to test? What questions will you ask of your play testers? Where/how will you track bugs that you find? (GitLab does have support for [issue tracking](https://docs.gitlab.com/ee/user/project/issues/). If you want help using this, ask your instructor.

## [Presentation](doc/Presentations.md)
Here is where you will present your group to the class.  Your group is your game studio, and your presentation is like a game pitch.  It tells the audience what you’re building, why you’re making it and how you plan on accomplishing what you’ve decided to create.

Each section of the presentation will be a summary of your documentation.  However, **don’t just copy and paste your write-up into a PowerPoint slide**; summarize the major points and explain them to the class.

Your presentation should contain each of the following four sections, with about 1 – 3 slides per topic depending on detail and visuals:
- **Design**: Talk about the design of your game: What type of game is it?  Does it draw upon other similar games?  What makes it unique, special, exciting, fun? Why are you excited to create it?
- **Architecture**: What will you need to do to make the game?  What are the general classes that will be required?  You must show a basic diagram of the classes and their relationships. Be sure to include this in your write-ups, too.  
- **Art and Interface**: What will the visual (art) style of the game be? What will we see on the screen?  What types of menus will we encounter?  What will the overall flow of your game be?  Show some of the interface mock-ups you’ve done and explain the choices you’ve made.
- **Production**: What is your game’s timeline?  Which pieces of the game are necessary vs. “if we have time”? What is your weekly meeting time?  How have they been going?  Have you been using any external tools (Google Docs, Google Calendar, Trello, etc.) to keep track of tasks and timelines?  

## [Implementation](src/ReleaseNotes.md)
No implementation is required for milestone 1. That said, I strongly suggest that your at least create the base MonoGame project, add it to version control, and make sure everyone can build/run it.

