# Mobile_Hypercasual_Game

  This project contains the exercises from modules 20 to 27 of EBAC for creating a hypercasual mobile game for Android System.

## February, 04th, 2026

### Core Systems & Item Mechanics Update

  In this update, I focused on structuring the game's technical foundation by creating the EDGEE - CORE folder, where I implemented the Singleton pattern for global management. The item system was redesigned using Scriptable Objects for coins and configurable data, in addition to implementing an Item Manager and basic scripts for collection. On the visual and movement side, I added animations for coins, a Lerp Helper system to smooth player actions, and dedicated logic for detecting item collection.

## February, 05th, 2026

### Player moviment and coin collection

  Scripts were created for player movement and coin collection was tested along a simple path. Implementation of player movement and coin collection system. Level 1 was updated with new materials, obstacles, and the creation of prefabs for optimization. Additionally, I performed an organizational restructuring of the project, including the creation of configuration folders, relocation of scripts, and updating of .meta files.

 <img src="https://github.com/user-attachments/assets/93705a8a-0e6a-4539-b7b3-cf68855e4283" width="180" title="player collecting coins"/>

 ## February, 06th, 2026

### Level design for test 

  The level design for the first stage was simple and tested to identify coin collection and obstacles. Wall collisions still need to be added.

<img src="https://github.com/user-attachments/assets/4d55cb27-1d49-4e18-aba7-de07e9e0a67a" width="180" title="Level design"/>

## February, 09th, 2026

### StartScreen UI e assets inclusion 

   Inclusion of the game's start screen and inclusion of the textmesh pro assets. Adjustments to the scene and modifications to the player controller. The game now has a prefab finish line, and the UI already includes play and restart buttons, making it a functional prototype. (Module 20 submission - Creating a mobile game: First controls - NOTE: The activity began on February 4th and ended on February 9th.).

<img src="https://github.com/user-attachments/assets/c7c00ae8-0f79-49bc-8fad-657aeae4c429" width="180" title="Start screen and Obstacle bump"/>
<img src="https://github.com/user-attachments/assets/1a998572-2635-429d-9dfb-5b4b9a787b53" width="180" title="Finish Line Prefab and restart Game Screen"/>

## February, 10th, 2026

### Refactoring Item Systems & PowerUp Implementation

  This update includes modifications to the Coin prefab and enhancements to the item animation scripts for better 3D performance. Significant architectural changes were made to the itemcollectableBase to support inheritance for PowerUp items, which now feature a dedicated base script, a custom pill-shaped prefab, and new materials for improved visual consistency.

<img src="https://github.com/user-attachments/assets/4ee58ba4-a430-4b29-a36c-48776e2c78cd" width="180" title="Coin and Pill prefabs with VFX"/>
<img src="https://github.com/user-attachments/assets/23d583ab-965d-4de4-bc5b-3c3d23fc42e4" width="180" title="Pill prefab"/>

## February, 11 and 12th, 2026

### Refactoring Item Systems & New PowerUp Implementation

   In this update, I refactored the player scripts and item collection system, introducing four new power-ups: Invincibility, Speed Up, Height Change (like a float or fly), and Area Coin Collection. To support these mechanics, I implemented the DOTween plugin, created new materials, and developed all necessary scripts, prefabs, and VFX—including obstacle explosion logic (Not working yet, but will be implemented soon: when the player gets the invincibility power-up, they can trigger an explosion animation on the obstacle.) and specific interactions for each power-up.(Module 21 submission - Creating a mobile game: PowerUps - NOTE: The activity began on February 10th and ended on February 12th.).


<img src="https://github.com/user-attachments/assets/99d220ca-1c7a-408d-846d-de10a60e1a26" width="180" title="Power Up Height Pill"/>
<img src="https://github.com/user-attachments/assets/dbc6d76c-f8a4-4367-a19a-2b7f1e8dae3b" width="180" title="Power Up Area Coin Collection Pill"/>
<img src="https://github.com/user-attachments/assets/956ea4cb-e1a5-460f-99df-bca95b2d9e3b" width="180" title="Power Ups Invincibility and Speed Up"/>

## February, 13th, 2026

### 3D animation

Adjustments to the visual effects of coins and power-ups. Adjustments to the 3D model shader. Inclusion of the player's 3D model package. Implementation of an animator manager for adjusting character animations. Now the player displays animations for Idle, Run, and when hitting an obstacle without being invincible, the death animation is triggered. A small adjustment to the camera was made to better observe the animations.(Module 22 submission - Creating a mobile game: 3D animations - NOTE: The activity began on February 12th and ended on February 13th.).

<img src="https://github.com/user-attachments/assets/20840148-ea52-442d-9c96-2f3233db29dc" width="180" title="Idle Animation"/>
<img src="https://github.com/user-attachments/assets/9ca1f33d-b918-4363-983a-813fee98972b" width="180" title="Run Animation"/>
<img src="https://github.com/user-attachments/assets/87d7d9c8-d072-4ecc-a72c-af054860891e" width="180" title=" Death Animation"/>

## February, 14th, 2026

### Level Design

In this stage, a Level Manager was created for randomizing scenery pieces, colors, and themes. To achieve this, 20 different initial scenery pieces were created to generate future levels. Some obstacles can move vertically, and adjustments will be made to allow horizontal movement, adding more challenges to the game.

<img src="https://github.com/user-attachments/assets/ac27157f-21d2-406d-bed1-d8f3b2a710ce" width="400" title="Prefabs Pieces for randomization - Isometric Projection View"/>
<img src="https://github.com/user-attachments/assets/51a34d42-7ec9-488d-b945-abd45050493d" width="445" title="Prefabs Pieces for randomization - Perspective Projection"/>


## February, 18th, 2026

###  procedural generation system - LevelManager

In this stage, a procedural generation system driven by a LevelManager that utilizes a list of scenario prefabs to build levels dynamically was created. The system ensures structural consistency by using fixed prefabs for the beginning and end of each level, while applying randomization logic solely to the remaining pieces in the sequence. To facilitate this, I developed the LevelPieceBase class, which acts as a container for positional variables, leveraging specific startpiece and endpiece GameObjects within each prefab to precisely calculate and adjust connections for seamless environment assembly.

## February, 19th, 2026

###  Level Manager Update - Arts

Updated the environment workflow by creating and organizing several scenery prefabs. This update includes core assets for the castle (main structures and towers), crystals for cave environments, and trees for forest areas, along with a default cube prefab to streamline level assembly.

<img src="https://github.com/user-attachments/assets/eb962e95-80b2-4460-971c-d2545a08e9ed" width="180" title="PFB_Castle"/>
<img src="https://github.com/user-attachments/assets/f88f5fa6-253f-4716-8936-1fc636044ba6" width="180" title="PFB_Woods"/>
<img src="https://github.com/user-attachments/assets/ead60957-2525-45d9-bfa6-581490c9893a" width="180" title="PFB_Cave"/>

## February, 22th, 2026

###  Level Manager Update - New Decorative Prefabs and Explosion VFX

Update to the PFB_debris prefab. Creation of a new material for debris. Update to the game's piece prefabs, including new obstacle animation scripts. Creation of a script for secondary obstacle animation. In addition, a new visual effect has been included along with the VFXHandler.sc script. Now, when touching an obstacle while invincible, the character passes through the obstacle and it disappears, resulting in an explosion of obstacle fragments.

<img src="https://github.com/user-attachments/assets/062e9ca6-e3f3-44e4-9c7a-7d01536f86a6" width="180" title="Explosion VFX"/>
<img src="https://github.com/user-attachments/assets/fa69034c-cf8b-4d1f-967a-6fc72e273ee9" width="400" title="PFB_Debris_VFX"/>

## March, 2nd, 2026

###  Color Manager - Randomization of the colors in the scenery for the game phases.

New materials have been added to the floor and cubes of the level. These materials were accessed using the new color_manager.sc script to randomize the level colors according to the castle, cave, woods, and default themes.(Module 23 submission - Creating a mobile game: Level Manager - NOTE: The activity began on February 14th and ended on March 2nd.).

<img src="https://github.com/user-attachments/assets/1d769e84-52c4-4f54-97c8-827a11879d3e" width="180" title="Default Level Color Randomized"/>
<img src="https://github.com/user-attachments/assets/9ab81356-8fad-49eb-9255-41dedbe8dc34" width="180" title="Castle Level Color Randomized"/>
<img src="https://github.com/user-attachments/assets/de6b7fe0-c1ed-4cc5-bfa0-847a45ac5bab" width="180" title="Woods Level Color Randomized"/>
<img src="https://github.com/user-attachments/assets/502a3367-9ece-4ee8-8b93-8807e92eb1cc" width="180" title="Cave Level Color Randomized"/>

## March, 07th, 2026

###  Polishing the game - Lerp and Scale Scenery Pieces.

Creation of scripts (MovimentHelper.sc) to assist in the movement of items in the scene, such as enemies or scene objects. Adjustment of negative prefab values. All were adjusted to positive values ​​to avoid console errors. To improve the functioning of coroutines, the positions of the items that carry the moviment item collector were converted to local positions. Creation of coroutines to scale and animate with Dotweening in the generation of new scene pieces in the level menager script.

## March, 08th, 2026

###  Polishing the game - Tweens and Color Changes.

Update to the color change scripts - The scenario received color change scripts to start white and acquire color after the game begins.

Warning: The Prefab folder seems to have changed location. This commit reported many new items, even though these prefabs were already present in the repository. It's possible the folder was moved unintentionally and these files are being copied twice.

In this stage, many scripts were created to polish the game, such as a change color (to change the color of the levels at the beginning of the game), a bounce helper to create animations when the player touches a power-up, and to concentrate the power-up logic in a single script called PowerUp Manager.

Note: The game is presenting some bugs, such as the color change of the white levels at the beginning of the second game; it doesn't revert to the original color effect, everything remains white. And it's presenting problems when we use the power-up to increase height; if, after the effect ends, we touch another power-up, we end up 0.5 meters off the ground on the Y-axis, as if we were floating.

## March, 15th, 2026

### WARNING!!

A movement of prefab files between the prefabs and resource folders resulted in duplicate files, preventing the game from running. Furthermore, changes to the game's tweens and background color variations were not implemented correctly, resulting in numerous bugs. The game had to revert to the March 7th version and restart all polishing from scratch.

###  Polishing the game (Again!)- Tweens and Color Changes.

Now, the procedural generation and feedback systems of the runner game was optmized. I corrected local space positioning issues to ensure obstacles remain correctly aligned with moving level pieces. The player's lifecycle management was improved by implementing an initialization method within the Singleton pattern, ensuring a smooth 'scale-up' spawn effect and consistent resets between matches. Finally, I enhanced the VFX impact system by synchronizing DOTween-based scale expansion and material transparency (fade-out) with the physics-driven explosion chunks, creating a much more fluid and impactful destruction sequence when the player is invincible.

Game Polishes:

* Now, when starting the game, the main character scales from 0 to 1, growing on the screen when the game starts.
* When collecting Coins, the main character performs a scaling bounce.
* Other level generation tweens have been added, such as the wave effect when assembling the stage pieces and generating coins, as well as the start of the stage changing from blank to the original stage color.
* A new scaling effect has been added when using the invincibility PowerUP, because when breaking obstacles, they scale (expand) and generate a FadeOut effect with the disappearance and reappearance of the VFX particle effect.

NOTE: 4 PFB_Pieces are corrupted because the SpeedUP PowerUp was lost in the 08th March commit. This issue needs to be fixed in the future.

(Module 24 submission - Creating a mobile game: Polishing the game - NOTE: The activity began on March 7th and ended on March 15th.).

## April, 07th, 2026

### Adding VFX and Particles - adding a trail renderer, line renderer and new particles

The project is resuming, as it was paused due to university and postgraduate assignments. Balancing work, postgraduate studies, lesson preparation, homework, university classes, course classes, and submitting assignments and exams has been quite difficult, but we will move forward. Including trails as visual effects on the character.
Line renderers were added to the game's PFB_pieces to create polygonal geometric figures with color gradients. Additionally, a death particle with a ghost-like appearance was included, and physics were incorporated into the debris particles, so they bounce off the ground when generated and explode high up in the air, directly into the player's line of sight!
