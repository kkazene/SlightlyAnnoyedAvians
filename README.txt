# Slightly Annoyed Avians
By Tuuli Sarantola, 218517

Angry birds clone game for VR and AI course.

Implemented requirements:
* Some sort of a non-destructible, non-deformable environment
* A number of boxes, crates, pillars and other such objects that react to physics, in a configuration of your own liking
* A Slightly Annoyed Avian that reacts to physics
* A way to launch said Avian and control launch direction and speed
* Eggs or other valuable collectibles that can be picked up hidden behind the objects
* Score tracking, game over screen, and/or restart functionality
* Background art - just a little bit of something extra in the background
* Version control for the project folder

On top of these, a few extra features were made:
* Particle animation for dying enemies
* Assets from the Unity Asset Store in use

Game score is kept in the debug log, and points are not relevant to passing the level, only killed enemies. You have three ball-shaped avians to try and beat the level. I chose not to manually add forces when handling avians, since Unity has a nice built-in spring method, which worked better when dealing with gameplay. To launch an avian, simply click and drag with mouse.