# 2D Fighting Game

A 2-player, 2D fighting game built in Unity, featuring physics-based combat and motion-input special attacks.

## Features
- Local 2-player combat with independent controls for each player
- Rigidbody2D-based movement and hitbox detection for attacks
- A directional-input buffer that reads each player's recent movement to detect a motion-based special attack (similar to classic fighting-game "quarter-circle" inputs)
- Block, jump, and a paralysis status effect that temporarily disables a player
- Health system with per-attack damage values and cooldowns

## Tech Stack
- **Engine:** Unity
- **Language:** C#
- **Physics:** Unity Rigidbody2D

## How It Works
Each player's inputs are tracked over a short time window (a "direction buffer"). When the buffer matches a specific input pattern, the special attack triggers instead of a normal punch, similar to how classic 2D fighting games detect combo inputs.

## Status
Personal Unity project built to practice 2D physics, animation states, and input-pattern detection — built with a teammate under a tight deadline.
