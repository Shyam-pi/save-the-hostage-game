# Website

Detailed overview of the game can be found here : https://sites.google.com/view/vr-hostage-rescue-game/final-report?authuser=2

# Change Log

**Apr 18** : Sanjali Yadav
- Player shooting logic 
    - Modified the AddForce logic to make the gunshots more realistic. 
    - Added revolver bullet prefab to instantiate bullets when trigger pressed 
    - `ProjectileController.cs`: Attached to the revolver bullet prefab. Adds particle effect system to splash blood when enemy is hit and dust effect when the bullet hits other objects in the scene 
    - `Enemy.cs`: Attached to the enemy object to encode health logic. Currently, when the player hits the enemy once they disappear after some time. Can be modified to give several lives to the enemy. 
    - Added UI to display number of bullets shot. 
- Timer Logic 
    - `ControllerManager.cs`: keeps track of the logic for timer and the UI for the timer and time up message. 
- AI Enemy 
    - Implemented logic to make the enemy dynamic. The enemy patrols the area and once the player is in its sight of range, it starts chasing the player until the player is in the attack range. Once the player is in attack range, the enemy starts shooting bullets. 
    - Configured NavMesh agent to the enemy to define the walkable and non-walkable areas and enable the AI behavior. 

**Apr 21**: Ahmed Attia
- Added character models and animations
    - Added a character model for the enemy and rifle
    - Added animations for patrolling, chasing, and shooting
    - Added a script `EnemyAnimationStateController.cs` two switch between different animations based on flags from `AIEnemy.cs`
    - Temporarily removed walls because the soldier walks through them. See below
- Current Problems:
    - Bullets are too frequent and come out of the wrong place. I chose a model for AK47 which is a machine gun but the animations are for a regular rifle. I can fix the model or speed up the animation but I think for game play it's best of we use a regular rifle
    - Turning is too wide. Soldier needs to turn in place or in a tight circle
    - Soldier is floating. Don't know how to fix that.
    - Soldier walks through walls. Probably my mistake but don't know how to fix it.

**Apr 22**: Ahmed Attia
- Added user gun logic
    - Enemy starts with 100 points of health (tracked in `Enemy.cs`), and if heath is 0 enemy dies
    - Heath == 0 triggers death animations
    - Enemy heath is displayed instead of the bullet count
    - Fixed floading problem

- Current Problems:
    - Enemy can still move after death
    - Sometimes there's gitter after death
    - Boundaries between walking and standing is not clearly defined during partrol
    - Bullets are too frequent and come out of the wrong place. I chose a model for AK47 which is a machine gun but the animations are for a regular rifle. I can fix the model or speed up the animation but I think for game play it's best of we use a regular rifle
    - Turning is too wide. Soldier needs to turn in place or in a tight circle
    - Soldier walks through walls. Probably my mistake but don't know how to fix it.

**Apr 24**: Sanjali Yadav
- Fixes: 
    - Added boundaries between walking and standing and ensure that soldier doesn't walk through wall. `Note: Bake NavMesh every time environment changes`
    - Bullets instantiation position is fixed. 
    - Added logic to stop animation once enemy is dead so that they don't move after death. I tested it a few times but need to test it thoroughly. 
    - Fixed the health counter. Before every time the trigger was pressed and enemy was shot, the counter was decreasing by random values. Now it is fixed so that when enemy is shot once the value decreases by 10 uniformly. 
    - There were some floating issues when the soldier was patrolling so I fixed that. `Note: floating soldier can be fixed by baking NavMesh height in advanced settings`
    - Added gunshot sounds when firing the gun. 
- ToDo: 
    - Still need to fix the bullet frequency 
    - Fix the turning of the soldier 

**Apr 24**: Shyam
- Created a demo map, and wrote a controller script to explore around the map

**Apr 25**: Sanjali Yadav
- Added blood splattering effect to the animation. At first the particle effects were not compatible with animation, need to change the default setting of the blood prefab. 
- Separated bullet counter and health counter. Health counter is now at the top of the enemy and bullet counter is near the gun. Seperated the logic for bullet and health counter and enemy health counter is now controlled by the enemy script. 

**May 9**: Ahmed Attia 
--Added character model to the hostage and terrified idle animation 
--Added haptic feedback to the gunshots. Haptics are inferred from audio files. Had to change the gunshot sound for a shorter and stronger haptic feedback.

**May 9**: Shyam
- Changed map to a low-poly one since the previous one was taking a severe hit on low-spec PCs
- Created 3D SteamAudio elements for better virtualization of sound effects
- Wrote the logic for motion based footstep audio for the player and the enemies

**May 10**: Sanjali Yadav
- Added logic for player's health. Once the health goes down to zero, added UI to show the game over message. Also, if player runs out of bullets then game over message shows up.  
- Added game instructions at the beginning and added logic so that all the scripts start after the instructions are shown 
- Added UI for player's health next to the timer 
- Created muzzle flash effect to both the player's and enemy's gun 
- Fixed the enemy's firing rate so that player has time to escape and fixed player's collider so that we can track if the player was hit or not 
- Fixed the rotation and position of bullets coming out of the enemy's gun 
- Removed the right gun since we are not using it 

**May 12**: Ahmed Attia
Merged mine and Sanjali's changes

**May 12**: Shyam
- Modified the enviroment such that the game map is streamlined and user doesn't have too much of a difficulty navigating
- Reconfigured the locomotion script and added jump functionality. Performed optimizations to reduce nausea.
- Tested and did bug fixes for the footstep audio and finally integrated the same with the final environment
- Improved gun logic to shoot only once per trigger press and not depending on a fireRate variable for it to shoot. Fixed the bug with wrong location of 'dust' effect spawning.

**May 13**: Shyam
- Added hostage created by Ahmed to the environment
- Changed the enemy AI to be stationary and shoot when the player is within a certain range of the enemy
- Added collectible health kits to the game, including programming its logic to work with the existing enemy and player health models.
- Created prefabs for the enemy for better reusability.
- Complete overhaul of the UI, including graphical bars to show health and the game timer.

**May 14**: Shyam
To be done:
- Adding ambient sound, and enemy voiceovers
- Add spawns of enemies once Ahmed's work on the enemy animations is done
- Add a counter for how many enemies are still alive
