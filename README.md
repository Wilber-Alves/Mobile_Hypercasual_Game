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

