# r-evolution Wiki



## Table of Contents:

1.  Base game objects
   1. SceneEntity
   2. Projectile
2. Sequencer system
   1. AbilitySequencer
   2. SequencerAction
   3. Sequencer components
      1. Wait
      2. Spawn Projectile
      3. Range Indicator and Range Indicator Controller
3. next point





## 1. Base game objects

### Scene Entity

SceneEntity is a base component of movable character. It's meant as a means for AI and Player controllers for kinematic interaction with game world. 

Properties:

- Rigibbody2D myRigidboy - holds reference to Rigidbody2D, which is used for moving the Entity.
- Vector2 movementDirection - we assign obtained and normalized, diagonal or straight, Vector2 which is used as a direction in which Entity will move on next frame update. Because it's calculated from Input.GetAxisRaw() it will be assigned Vector2.Zero value and make do Entity stop.
- boolean aiming - used to determined in which mode is the Entity rotated. If TRUE entity is aimed precisely, which means it will be rotated toward the exact location passed in SetDirection method in ctrlPos Vector2 argument. If FALSE Entity will automatically be rotated the same way as the last movementDirection ignoring Stop. This is to avoid a rotation bug.
- float lookingDirection - is passed as the direction towards which the entity will be rotated on next frame update and is assigned either based on aiming mode. It either aligns with movementDirection or rotates toward input from controller (ctrlPos).

Methods:

- void SetDirection(Vecto2, Vector2) - assigns values to movementDirection and lookingDirection. This method is a listener to UnityEvent<Vector2,Vector2> from controller. 
- void TakeAim() - switches aiming mode. 
- overriden void FixedUpdate() - updates the rigidbody.

To add:

- ability to override movement control. 
- add TakeAim(bool) method