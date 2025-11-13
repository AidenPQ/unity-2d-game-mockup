# Unity 2D Game Mockup (PTS7)

Prototype Unity 2D de maquette jouable (léger, sans assets volumineux).  
**Parcours** : rue de ville → ruelle → intérieur d’immeuble, avec **système de dialogue**, **menus UI** (pause/options), **parallax**, **triggers/colliders**, et **sauvegarde des réglages via PlayerPrefs**.

> Objectif : démontrer une base propre et réutilisable pour une petite expérience narrative/arcade (projet PTS7).  
> Tech : Unity 2020+ (ou version de ton projet — à préciser ci-dessous).

---

## 🎮 Features

- **Scènes** : Main Menu, City Street, Alley (piège + clé), Building Interior (PNJ/dialogues), Game Over  
- **Gameplay** : déplacement 2D, zones interactives (triggers), collecte simple (clé), transitions de scènes  
- **Dialogues** : gestionnaire dédié (affichage, avancée, sons UI)  
- **UI & Audio** : menus (Start/Options/Pause), prompts contextuels, feedbacks sonores  
- **Parallax** : décor multi-plans pour donner de la profondeur  
- **Persistance** : réglages de base via **PlayerPrefs** (ex. volume)

---

## 🚀 Lancer le projet

1. **Ouvrir dans Unity** (version recommandée : **Unity 2021.3 LTS**).  
2. Charger la scène d’entrée : `Assets/Scenes/MainMenu.unity`  
3. Cliquer ▶️ **Play**.

> Si tu as une autre scène d’entrée (ex. `Assets/Scenes/CityStreet.unity`), indique-la ici.

---

## 🗂️ Structure du dépôt

```text
Assets/
  Scenes/            # MainMenu, CityStreet, Alley, BuildingInterior, GameOver
  Scripts/           # PlayerController, DialogueManager, UI, Triggers, ...
  Sprites/           # Décors/Personnages (compressés)
  UI/                # Canvases, fonts, sprites UI
  Audio/             # Effets courts (OGG/MP3)
Packages/
ProjectSettings/
```
Les caches Unity (Library/, Temp/, Obj/, Logs/, UserSettings/) sont ignorés via .gitignore.
Le dépôt reste volontairement léger : pas d’assets bruts lourds (PSD/WAV non compressés, etc.).
---


