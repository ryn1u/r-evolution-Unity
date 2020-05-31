r-evolution-Unity
=================

*DONE:*

25/05/2020

>   Create a universal GameActor component which will give reference to entity’s
>   position, rotation and direction vector. It will also handle the Actor’s
>   rigidbody updates.

26/05/2020

>   Find a better way to calculate projectile’s distance travelled.

>   Implement UnityEvents to sequencer.

27/05/2020

>   Add a way for listeners to subscribe to ProjectileHit and ProjectileMiss
>   Events.

>   Move position and rotation to SceneEntity, so we don’t have to have
>   dependency on both SE and Rigidbody.

>   Remove constant rotating towards the mouse and rotate to it only when aiming
>   ability.

>   In Watershot sequencer replace passed for aiming SE.Direction with the
>   actual vector for aiming.

28/05/2020

>   Rework player controller.

>   Creating Aiming System for Sequencers

>   Create WaitSequencerAction to replace coroutines. Give it an ability to hold
>   multiple wait calls.

29/05/2020

>   Add git version control.

>   Fix aiming.

>   Create a default rangeIndicatorController. It will make sure that on button
>   press the indicator is shown and on release its hidden and emits events.

*TO DO:*

>   Sequencer Actions need refrences to rigibodies, sceneentities, controllers,
>   and stats they are attached to. We can’t assaign these values in inspector.
>   We need a universal way for them to initialize themselves.
>   SequencerComponents could have a method that takes in these required objects
>   and on Awake() in MainSequencerComponent we invoke an event with even three
>   arguments. SequencerComponents can than impement an interface or inherit
>   from a class that implements a sort of constructor like void
>   Initialize(rigidboy, sceneentity, controller).
