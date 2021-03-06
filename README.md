# OpenBreed.Editor
Map and resources editor for classic Alien Breed 2D games:
 - *Alien Breed (Special Edition 92)* - (ABSE)
 - *Alien Breed II: Horror continues* - (ABHC)
 - *Alien Breed: Tower Assault* - (ABTA)

## Introduction

First *Alien Breed* game was released on Amiga and PC DOS platforms in 1991 by *Team17*. In next year, special edition of this game appeared only for Amiga.
In 1993 also only for Amiga, a sequel *Horror continues* was created. And 1994 was the year when both Amiga and PC DOS got the last classic Alien Breed game called *Tower Assault*.

Tower Assault for PC DOS uses EPF archive (due to porting being done by different company - *East Point Software*) as container for resources. Writing an EPF archive manager opened a possibility of extracting or modifying game resources like sounds, maps, tiles and sprites to run the game with changed content.
Data format of some resource types appear to be similar between both Amiga/PC platforms and all three games (excluding 1991 version of AB) probably due to usage of same game engine with slight modifications.

## General goal

Create fully functional map editor for AB games with parallel thinking about open source implementation for Alien Breed classic games (OpenBreed).

## Current editor functionality

**ABTA:**
 - Viewing maps with their original color palettes, tiles and properties
 - Maps edition and storage back to EPF archive (unstable)
 - Viewing tile sets (\*.BLK entries) associated with maps
 - Viewing sprite sets (\*.SPR entries) associated with maps (reverted)
 - Viewing images (\*.LBM entries) from EPF archive 
 - Playing game sounds
 - Level password generator (works for PC and Amiga platforms)

**ABHC:**
 - Viewing maps with their original color palettes, tiles and properties
 - Edition and sorage of maps
 - Viewing tile sets associated with maps
 - Viewing some images used in game with original palette
 
**ABSE**
 - Viewing maps with their color palettes tiles and properties
 - Edition and sorage of maps
 - Viewing tile sets associated with maps
 - Viewing some images used in game with original palette
 
 ## Development status
 Currently this repository goes trough very heavy refactoring, so declared functionality may be missing or not working at all
  
  
 
