# Change Log

**Apr 18** 
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

