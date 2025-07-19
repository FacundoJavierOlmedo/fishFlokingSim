# 🐟 Simulación de Peces - Flocking con Comportamiento

Este es un pequeño proyecto sobre **comportamiento de manada (flocking)** inspirado en el algoritmo de Reynolds, donde múltiples peces nadan de forma grupal y coordinada. Cada pez tiene parámetros configurables que determinan su comportamiento, como velocidad máxima, distancia de separación, pesos de alineación y evasión, entre otros.

🎯 **Objetivo de los peces:**
- Perseguir un alimento que se reubica constantemente en el mapa.
- Evitar un barco que patrulla el área.

Cada pez tiene asignados **pesos de comportamiento** (editable desde el Inspector de Unity) que modifican cómo reacciona ante sus compañeros, el objetivo (comida), y amenazas (barco). Estos parámetros hacen que cada pez pueda actuar de forma ligeramente distinta dentro del grupo.

⚙️ **Variables clave (editables por agente):**
- `Max Speed` / Velocidad máxima
- `Separation Distance` / Distancia de separación
- `View Distance` / Rango de visión
- `Evade Weight` / Peso de evasión del barco
- `Arrive Weight` / Atracción al objetivo (comida)
- `Cohesion`, `Alignment`, `Separation` Weights / Pesos de comportamiento grupal

🔧 **Hecho en Unity**  
Usa un sistema sencillo de navegación y lógica de flocking con control por `MonoBehaviour`. La comida se reubica periódicamente y los peces se adaptan dinámicamente.

📦 **Incluye:**
- Proyecto completo en Unity
- Build ejecutable
- Script con lógica de flocking
- Control de parámetros desde el editor

---

# 🐟 Fish Flocking Simulation

This is a small project demonstrating **flocking behavior** based on Reynolds' algorithm, where multiple fish swim in a coordinated group. Each fish has editable parameters that define its behavior, such as max speed, separation distance, alignment weight, and evade weight.

🎯 **Fish goals:**
- Chase a moving food object that relocates around the map.
- Evade a patrolling boat.

Each fish has **customizable behavior weights** (editable in the Unity Inspector), allowing each one to behave slightly differently in the flock.

⚙️ **Key parameters (editable per agent):**
- `Max Speed`
- `Separation Distance`
- `View Distance`
- `Evade Weight` (from boat)
- `Arrive Weight` (to food)
- `Cohesion`, `Alignment`, `Separation` Weights (for flocking)

🔧 **Built with Unity**  
Uses simple navigation and flocking logic via `MonoBehaviour`. Food relocates periodically, and fish react accordingly.

📦 **Includes:**
- Complete Unity project
- Playable build
- Flocking logic script
- Parameter control from the Inspector

---

🖼️ **Capturas / Screenshots**

<img width="621" height="453" alt="image" src="https://github.com/user-attachments/assets/080897b2-14e6-4a60-8245-59e5d659672b" />

<img width="849" height="537" alt="image" src="https://github.com/user-attachments/assets/00ef3236-a133-469f-8f04-cceb5a21fae7" />

<img width="877" height="557" alt="image" src="https://github.com/user-attachments/assets/bcf2f8dc-74f0-4ff7-a2e1-8aaba97cf987" />




---
📦 Descargar/Download
📥 **Download the project build (RAR):**  
[Download FishFlockingSim](https://github.com/FacundoJavierOlmedo/fishFlokingSim/releases/download/floking/fishflokingsim.rar)

👨‍💻  Facundo Olmedo
