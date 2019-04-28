# Shiro Postmortem

Our team of Game Design and Development (GDD) students in a first year course at Rochester Institute of Technology (RIT) first met in February.
Knowing very little about each other or about working on a large game project as a team, we didn't know exactly what to expect from our project. After
talking about the various genres we wanted to work on, we came up with the idea of a story-driven game about a cat wanting to get home. Initially, we had
concerns about scope of the project, but we were convinced that we would learn a lot about game development could create something unique if we went forward
with our idea of the lost cat facing his fears on a journey home.

When we started actually coding together at the start of milestone 2, things seemed to be going smoothly for us. We each worked independently on different classes 
and mechanics that we were interested in individually. At first, it seemed like this was a very efficient way to get a lot done. While it certainly was efficient, we 
slowly started to run into some issues with our various pieces of the game actually fitting together. At some points, this caused us a lot of frustration with trying 
to force the pieces together. What had seemed in the beginning to be a simple plan quickly became more complex, due to both our newness with programming in C# and due 
to working on a group coding project, which was unlike anything we had done last semester, or in other classes. Because we had to deal with this difficulty, Shiro 
slowly evolved in how we implemented classes and mechanics from how we originally planned. This evolution however was not strictly negative- new ideas and features 
revealed themselves to us as we continue to code and playtest, and the Shiro we have ended up with is not the same Shiro we started with in our minds.

## What Went Right:

Throughout the development of our project, there was a lot that went right and some things that went even better than expected. The one huge thing that went right was our group members themselves. Throughout the semester, our group worked well together and very rarely had issues. We had full attendance at almost every meeting, everyone completed their assigned tasks in a timely manner, we felt as if we were well-prepared for each milestone as they approached, and everyone in our group was heard and has a small piece of them and their ideas in our final product. During our meetings we would try our hardest to make sure everyone was working on something they wanted to instead of just assigning tasks. While this was not always achieved, we believe that we did fairly well in accomplishing this goal where possible. Our group also benefited as coders and designers from each other's experience. We often had members showing each other cool tricks or how to use outside programs to create art or even easier and faster ways to implement their code.

Another thing we believe went really well throughout the development process was the art style. From the initial concept sketches our art looked promising and it has never let us down since. As the game progressed, so did the art. Eventually our promising sketches turned into beautiful sprites and finally worked their way into the game. We had originally planned to use the artstyle to tell the narrative of the game, so as the artstyle evolved, our game evolved as well. While the art style became more adorable and family friendly as it developed, so did our game and we all agreed this change was for the best.

One of our achievements that went even better than planned was the usage of external tools. When we were first told that we would be required to implement one, none of us really knew how we would accomplish that task. We bounced some ideas off of each other but none of them really stuck. It was an idea that we eventually just decided to leave in the background and just occasionally brainstorm ideas. By the end of our project we ended up creating two external tools which greatly eased our workload when it came to design our game. The two tools were a level editor and a generator of enemy attack patterns. Originally we had just planned to hardcode both, but these tools made our code cleaner, faster, and less time consuming to write.

## What Went Wrong:

Nothing in our project went horribly wrong, but there were a couple of issues and inconveniences that could have been avoided. During the milestone three presentations,
one of the other groups mentioned having meetings where they explained their code to one another. We did not have meetings like that, and not having them was definitely
a mistake. Not all of our coding styles meshed, and we needed to consult the others on issues that could have been avoided if we had those meetings and explained our code
better. We had a lot of useless variables by the end of the project that were created just to get around each others’ code. Many of our classes ended up cluttered with these
empty variables and needed to be cleaned up. None of this resulted in major errors and everything was easy enough to fix, but it was a time-sink we should have avoided.

Our group occasionally failed to prioritize. Most of that was working on art when we should have been coding, but there were other instances as well. We only started to work on
collisions at the end of milestone three, and that ended up being discarded because of time constraints. We probably should have had more than one level by the end of milestone 
three, but we recovered from that in milestone four. Everything got done, except for collisions, but we could have been far more organized and planned out exactly what we were 
going to do every meeting so that we did not drift off and work on things that were not necessary at the moment.

Some of our code overlapped, and that was never quite fixed. For example, some of our classes had very similar code but we did not use inheritance or anything to make the coding 
process easier. We did not use interfaces, which was most likely a mistake because that would have made piecing our code together easier. We did not use any events or delegates, and we only used
one abstract class. Our code would probably have looked a lot cleaner and flowed a bit better if we had incorporated these techniques into our game, instead of just having a lot 
of classes.

## What We Learned:
Working as a group, while having it's benefits, also has some things that we never considered that could be an issue. While we all worked together wonderfully, group
work is still different than personal work. We all came in with different strengths and weakness, and we sometimes struggled to adapt to each other's
knowledge and coding styles. Group work also consisted of a lot of conversation of when to push set code, because we had a lot of conflicts at many points in the project. 
At one point, we lost a whole days' worth of work because of lack of communication and double checking if everything merged right. Another thing that we realized as we were
coding Shiro was that planning architecture is more important than we planned it to be. 

While we were on top of most of the documents in our Git repo, one of the documents we slacked a bit on was updating our architecture diagrams. This made it somewhat
difficult for teammates to code other portions of code they didn't write, just because whoever was working on it new didn't realize that there were set variables/methods already
made for something they were coding. Architecture was also important for laying out all of our inheritance, which was constantly changing because we didn't sit down and make the
architecture diagrams for all of our enemies and bosses correctly.

Finally, the most important thing that we learned is that the response of playtesting is important! While we are masters at our own game because we coded it, we realized that for
some people during playtesting that Shiro was difficult for set age groups. Something that also came into light was that the story of the game (and why Shiro is fighting weird monsters)
was lost to some people because we only showed it on the instructions screen. While we don't have time to make a introduction to the game or add context in story format, the factor of 
the game being difficult to younger demographics is something we should have thought about during our group conversations and planning. Playtesting and getting feedback also was beneficial
for our group because it boosted our confidence in our game, and we practiced a lot of skills that we would need to use later on in our careers and college game making lives.
## What We Would Do Differently:
 
There are many things that we would do differently if we could restart this project. One of them being the fact that we would take more time out of our meetings to sit down and
explain to each other what our code means and why we chose to implement something in the way that we chose. This was a big thing that caused confusion and is necessary for any
future projects that we may work on. It will help us learn more and improve the project by having a better understanding of what is going on. Another thing that we would definitely change 
is our plans for architecture. Planning out the architecture was not as strong as we would like and we see it as something that we would change. We saw many times that we were
making changes to it as we went along. A better plan at the start would cut down changes and would give us a better idea of how to move forward.

Another thing that was lacking that could have been improved on was our method of organization and division of tasks. We had a solid idea for the use of Trello within our project
but we see that it could have been more effective. First of all, we did not fully use it until part way through the project, using it from the very beginning would have helped
a lot more than starting it part way through. Another thing with Trello is that we could have used it more by assigning certain tasks to people more often or creating more cards
on the board that kept track of things. The method of how we used it was good, the problem falls with how often it was being used by everyone and that is what should be changed.
One last thing would be to use data structures more often and efficiently. We used some of them in certain parts of the project but looking back at it, we see that there could
have been more use for them. Having the knowledge that we do now, we would have certainly used them more to clean up our code better and keep things more tidy and more efficient.

There were definite changes that we would have made if we knew what we knew now. We still succeeded in our project but we still could have been even more efficient with better
tactics to solve problems.

## Conclusion

Insert Conclusion Here
