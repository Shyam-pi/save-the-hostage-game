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
-Added character models and animations
    - Added a character model for the enemy and rifle
    - Added animations for patrolling, chasing, and shooting
    - Added a script `EnemyAnimationStateController.cs` two switch between different animations based on flags from `AIEnemy.cs`
    -Temporarily removed walls because the soldier walks through them. See below
-Current Problems:
    1-Bullets are too frequent and come out of the wrong place. I chose a model for AK47 which is a machine gun but the animations are for a regular rifle. I can fix the model or speed up the animation but I think for game play it's best of we use a regular rifle
    2-Turning is too wide. Soldier needs to turn in place or in a tight circle
    3-Soldier is floating. Don't know how to fix that.
    4-Soldier walks through walls. Probably my mistake but don't know how to fix it.
