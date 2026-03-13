A reverse engineering and modding tool for Resident Evil Outbreak File 1 & File 2 (PS2). Provides direct access to game assets, memory editing, proprietary file format exploration, and audio playback.



## Overview

Netbio VFL Plus is a complete toolkit for examining and modifying both Resident evil/Biohazard Outbreak titles.(PS2)
It reads directly from ISO images, interfaces with running PCSX2 emulator instances for real-time memory hooking, and includes parsing for custom archives and propertitary CAPCOM formats - 
Includes native playback for PS2 audio formats.


![Netbio VFL Plus UI](https://raw.githubusercontent.com/n0rthw1ndz/Netbio-VFL-Plus/master/VFL.png)



## Features

**Real-Time Memory Editing**
The tool reads live memory from a running PCSX2 emulator, providing:
- Player coordinates (X, Y, Z) in real-time
- HP and virus percentage tracking
- Player rotation data
- Automatic game region detection (NTSC-J, NTSC-U, PAL)
- Dynamic switching between File 1 and File 2
- Current room ID and camera ID display


** Camera and light data can be edited in real time (RAM) and written back to ROM (ISO) ** 



**Complete Archive System**
- AFS parser for Capcom's proprietary archive format
- DAT structure handling for massive container files
- Native ISO9660 reader for raw PS2 disc images
- SLD decompression for proprietary texture compression
- Full import/export capability for modding

**Audio System**
- Native playback of PS2 ADPCM audio via custom DLL wrapper
- MOMO and VAGI container format parsing
- Real-time audio preview from within archives
- Support for ADX, SND, and SNP sound banks
- Loop flag detection and handling
- Frequency and channel configuration display
- Progress tracking during playback

**Specialized Asset Editors**
Dedicated forms for interpreting custom game formats

- FRM_RDT - Room data editor
- FRM_EVB - Event script viewer (bytecode and interpeted code)
- FRM_EMD - Enemy and model data
- FRM_ITBL - Item tables
- FRM_AUDIO - ADX, SND, and SNP sound banks with playback controls
- FRM_NAME_EDIT - NPC name editor
- FRM_ItemMemory - Item properties viewer
- FRM_HEX2DEC - Hexadecimal/decimal calculator








**Visual Design**
- Color-coded file types for quick identification of custom game formats
- Grouped list views organized by asset category


## Supported Formats

| Extension | Description |
|-----------|-------------|
| RDT | Room description |
| NBD | 3D container (mesh/texture/skeleton) |
| EMD | Enemy data |
| EVB | Event script |
| TBL | Item occurrence tables |
| SLD | Compressed TIM2 textures |
| TM2 | PS2 textures |
| ADX | Sound clips |
| SNP | Enemy sound banks |
| SND | Sound containers |
| MOMO | Audio container format |
| VAGI | Audio header format |
| ITT | Key item icons |
| NPC | NPC scripts |
| LIG | Lighting data |
| FOG | Fog data |
| WMD | Weapon model data |
| AFS | File archive |
| DAT | Data container |
