---README---
MADE BY: Jeremy Poulin (40112762)

The following behaviours have been defined for Assignment 1:

Movements:
- Wandering (Both for Chasers/Evaders)
- Fleeing (For Evaders)
- Pursuing (For Chasers, and for Evaders when they want too unfreeze their teammates)
- PathFinding - using the A* Algorithm (used for Chasers (find token)/Evaders (find frozen teammate))
- Collision Avoidance (Using 3 Rays method)
- RootMotion (Used to move the player character around the map)

Rules:
- Freeze an Evader if a Chaser touches them
- An Evader Frozen for too long becomes a Chaser
- An Evader touching a Frozen Evader before the timer runs out saves the teammate
- A CountDown plays before the start of a new game
- The Game ends when the timer runs out or when the Player becomes a Chaser
- The Winner is decided based on the number of tokens acquired

Additional Info:
- Main Menu Scene
- Pause / Resume Functionality 
- Play Again Functionality
- Graph Creation based on Nodes and Vertices
- A* implementation
