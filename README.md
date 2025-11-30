NOTE:THIS PROJECT MAKE IN UNITY 2022.362F2 LTS VERSION 


1.Controls:

 Movement: `W`, `A`, `S`, `D`  (Moves the character relative to the screen).
 Aiming: `Mouse Cursor` (The player character rotates to face the cursor position).
 Shoot: `Left Mouse Button` (Fires the currently active weapon).
 Dash: `Left Shift` (Performs a quick burst of movement to dodge attacks; has a cooldown).
 UI Interaction:`Mouse Click` (Used for Restart and Quit buttons on the Game Over/Win screens).

2.Features Implemented:

 2.1Combat & Weapon System:

 Distinct Weapon Types: Implemented Pistol (Projectile), Shotgun (Spread Projectile), and Laser Gun (Hitscan/Raycast).
 
 Power-Up System:A "Pickup" item that temporarily boosts weapon stats (Fire Rate, Damage, Projectile Count) for a set duration.
 
 Random Weapon Spawning:** Guns spawn dynamically at random coordinates within defined world limits.

 Enemy Animations: Added movement animations for enemies.

 Loot System: Enemies randomly drop power-ups and healing potions upon death.

 Weapon Spawning: Guns spawn randomly throughout the level.

 Visual Effects (VFX): Added particle effects for bullet impacts and enemy deaths.

 2.2Enemy AI & Progression:
     State Machine AI:Enemies wander randomly and switch to a "Chase" state when the player enters their detection radius. 
     Wave System:** A structured progression system with 4 waves of increasing difficulty, culminating in a Win state.
     Visual Feedback:** Added enemy movement animations and particle effects for death and bullet impacts.

 2.3Loot & Economy:
     Loot Drops: Defeated enemies have a chance to drop random items, including Power-ups and Healing Potions.
     Scoring: Score increases when enemies are defeated (linked to ScoreManager).

2.4Player Mechanics:
     Dash Ability:A tactical movement mechanic to evade enemy swarms.
     Invincibility Frames (I-Frames) The player becomes temporarily invincible after taking damage to prevent instant death.
     Visual Sync:Animator parameters sync with movement speed and the currently held weapon.

3.Known Issues:

 3.1 Weapon Loot Assignment Limitation:
     Issue: Guns cannot be assigned to the Enemy Loot drop system.
     Reason:The weapon logic (e.g., `PlayerShoot`, `Spreadgun`) requires a reference to the
            firePoint`Transform. The `firePoint` is a child of the Player object in the active Scene.
            Unity Prefabs (assets) cannot store references to objects inside a Scene.
            Therefore, if a Gun is spawned as loot from a prefab, the `firePoint` reference becomes null, and theweapon cannot fire.

  3.2 Missing ScoreManager
     Issue:  Killing an enemy may result in a runtime error.
     Reason: The `EnemyHealth`script attempts to call `ScoreManager.instance.AddScore()`, but the ScoreManager script/object is currently missing from the project files.
 
  3.4 Animation Gliding:
      Issue:  The player character may appear to "slide" slightly after input stops.
      Reason: The Animation script uses `Input.GetAxis` (which applies smoothing) while the Movement script uses `Input.GetAxisRaw` (instant movement).
              This mismatch causes the walk animation to play slightly longer than the actual movement.

  3.5Unassigned UI References:
      Issue:Game may throw Null Reference Exceptions during Waves or Player Damage.
            Reason:Scripts like `WaveManager` and `HealthController` require UI Text and Panels to be manually assigned in the Inspector.
            If these fields are empty, the UI updates will fail.
