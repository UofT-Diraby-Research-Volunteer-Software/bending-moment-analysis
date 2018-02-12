# bending-moment-analysis
## Muffin/"Analyse this" Challenge: Description

This software was designed by Dhruv Warrier and Salar Khan.

This application helps you determine the maximum bending moment and its position, produced by a train as it passes over a bridge. There are 6 variables that affect the build of the train, and they are L (length of the bridge), n (number of cars in the train), d (the car length), alpha (the percentage of the car length that the tyres are from the edges), W (weight of each train car), and an additional variable linkLength (the length of the chain links between each car). The speed of the train can also be varied in the program.

The software provides the user with a simulation of the train moving across the tracks and dynamically calculates the maximum bending moment and its position for each instant in time, and also keeps track of the overall maximum bending moment for a set of given inputs.

The software makes sure the values are bounded by the numerical bounds provided in the specification of the challenge.

You can interact with the software in the following ways:
1. Provide all the input data at the dashboard, and press “Run Simulation” to create a live simulation of the scenario.
2. Use the “Pause”, “Forward”, and “Rewind” buttons to pause or move the simulation through time either forwards or backwards.
3. Use the “Return train to start” button to restart the simulation from the starting position on one side of the bridge.
4. Use the “Return to Dashboard” button to return to the dashboard to provide a new set of values for a simulation.
5. Use the “Quit” button to quit the program.

## Notes

Please run this in fullscreen for proper display of the UI.

We have aimed for abstraction in our code, so that in the future our code can easily be used to solve more complex problems along the same vein. The code we have written is general instead of specific, allowing it to be generalised to other projects. We have also followed proper industry standards in writing our code: maintaining transparent variable and function names, and organising all the code such that it is easy to read and understand.

## Known bugs in the current version

Clicking “Return to Dashboard” and specifying new values for a new simulation will occasionally not clear the maximum moment value from the previous simulation. If this occurs, simply return to Dashboard again and click “Run Simulation” once more.
Sometimes for a new simulation the train will not rebuilt perfectly. If this occurs, apply the same action as mentioned above (simply return to Dashboard again and click “Run Simulation” once more).
