# r-evolution Wiki



## Table of Contents:

1.  Base game objects
   1.  SceneEntity
   2.  Projectile
2.  Sequencer system
   1. AbilitySequencer
   2. SequencerAction
   3. Sequencer components
      1. Wait
      2. Spawn Projectile
      3. Range Indicator and Range Indicator Controller
3.  Animal stats
4.  next point





## 1. Base game objects

### Scene Entity

SceneEntity is a base component of movable character. It's meant as a means for AI and Player controllers for kinematic interaction with game world. 

Properties:

- Rigibbody2D myRigidboy - holds reference to Rigidbody2D, which is used for moving the Entity.
- Vector2 movementDirection - we assign obtained and normalized, diagonal or straight, Vector2 which is used as a direction in which Entity will move on next frame update. Because it's calculated from Input.GetAxisRaw() it will be assigned Vector2.Zero value and make do Entity stop.
- boolean aiming - used to determined in which mode is the Entity rotated. If TRUE entity is aimed precisely, which means it will be rotated toward the exact location passed in SetDirection method in ctrlPos Vector2 argument. If FALSE Entity will automatically be rotated the same way as the last movementDirection ignoring Stop. This is to avoid a rotation bug.
- float lookingDirection - is passed as the direction towards which the entity will be rotated on next frame update and is assigned either based on aiming mode. It either aligns with movementDirection or rotates toward input from controller (ctrlPos).
- float speed - how fast will Entity move.

Methods:

- void SetDirection(Vecto2, Vector2) - assigns values to movementDirection and lookingDirection. This method is a listener to UnityEvent<Vector2,Vector2> from controller. 
- void TakeAim() - switches aiming mode. 
- overriden void FixedUpdate() - moves and rotates the rigidbody.

To add:

- ability to override movement control. 

### Projectile

Child of SceneEntity, but also implements interface for objectPooling and assigning events for collisions on runtime.

Properties:

- Collider2DUnityEvent hitEvent - an event to which we assign what happens on projectile hit.
- ProjectileUnityEvent missEvent - same as above but on miss.
- float range - maximum distance which the projectile can travel. This is a squared value for optimasation.
- float currRange - a variable to keep track of how far the projectile has travelled. When it reaches 0 we invoke missEven.
- Vector2 prevPos - a variable for tracking how far has the projectile travelled since last update.

Methods:

- void SetEvents(Collider2DUnityEvent hitEv, ProjectileUnityEvent missEv) - a method so other classes can assign hit and miss events for projectiles.
- void Spawn(Vector2 position, Vector2 direction) - spawn projectile.

## 2. Sequencer System

### Ability Sequencer

Base class for the functionality of every in game ability. 

### Sequencer Action

Abstract base class for all components. It features the Initialize method that passes references to SceneEntities, Rigidbodies, Cameras, Controllers and etc. required by each SequencerAction.

### Sequencer Components

#### SequencerWait

Can create multiple timers that all trigger the UnityEvent and it's listeners.

#### IAbilityIndicator and BaseIndicatorController

IAbilityIndicator is an interface for all Ability Indicators. It includes the functions for showing the indicator, hiding it and invokeing the return events.

BaseIndicatorController interprets the inputs from Controllers(player input and AI) in form of BoolUnityEvents to IAbilityIndicators. It has three modes:

- instant cast - doesn't show the indicator, just invokes the events without showing the indicator.
- quick cast - shows the indicator on button press. Invokes and hides indicator on release.
- double cast - shows the indicator on first press and hides with invoke on second.

#### SequencerLineIndicator and DefaultRangeIndicatorController

Two components that are used for aiming of abilities. RangeIndicator is the graphical part of this functionality and DefaultRangeIndicatorController applies the input functionality.

To add:

- Create a base range indicator and base range indicator controller.

#### Spawn Projectile

Uses objectPooling to create and store instances for projectiles. A projectile needs to be spawned at position, activated, then based on hit or miss it invokes required methods and returns to pool. Because a projectile is a prefab we can't assign these hit and miss events in inspector so they need to be assigned by spawner.

## Animal Stats

