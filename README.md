# DTT-MazeGenerator
I want to make a maze generator using the Depth-first search algorithm. Why this algorithm and not another one. My simple reason, I think it looks the coolest.

## Features I want in 
* Maze generation
* UI where you can change the width, height and you can  regenerate the maze
* change camera depending on the size of the maze

## Features that would be nice(Low Priority but are still really fun)
* Having a player that can walk around
* able to play from a first-person perspective of the player and back
* Particle effects for when you finish the maze
* particle effects for when a new Path is placed
* Check if both width and height are filled in on generation

# Post mortem
I think it turned out pretty good. I got stuck on many things so I will try and take this into account whenever I start working on a new project next time. I need to do more research and more preparations.

## Problems
* I had so many problems with my camera and had to settle with a system that works but isn't perfect at all. I will try to ask around next time to see if anybody can help me with a better idea.
* I didn't prepare correctly. You can see on my UML that I didn't think everything through enough. I had to add a lot of variables functions and more that were not noted in the UML. Next time I need lookup if the ideas that I thought of were actually going to work.
* UI. It is really bad. I now know that you can scale it with screen size and that kinda helped it but anchors are still set wrong. I'm not much of a Ui guy so I don't really know how to improve this. I will try and research more if I am going to do anything related to UI next time.

## Things that I would like to improve
* I don't know how but the camera. Maybe add the function that he will also focus on the middle of the maze or something like that.
* There is still a problem with the generation that the first cube will not get generated and added to the list so there will be a cube missing that will later get added when the program comes around to that.

## Things I am proud of
* I did not look up a single tutorial. The only reference I got was this wiki page: [link](https://en.wikipedia.org/wiki/Maze_generation_algorithm).
* I think that the idea of the camera zooming outlooks really cool. It didn't work out great but the zooming out still is pretty fun.
