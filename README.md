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

*TO DO:*

>   Sequencer Actions need refrences to rigibodies, sceneentities, controllers,
>   and stats they are attached to. We can’t assaign these values in inspector.
>   We need a universal way for them to initialize themselves.
