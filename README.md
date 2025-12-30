# 🌐 Universal Viewer — Visualiseur polyvalent pour Windows  
*(FR / EN below)*

---

# 🇫🇷 Version française

Universal Viewer est un petit visualiseur/éditeur de texte polyvalent pour Windows, développé en VB.NET (WinForms).  
Il permet d’ouvrir, afficher, modifier et coloriser différents types de fichiers texte, notamment JSON, XML, HTML et INI.

![Version](https://img.shields.io/badge/version-v3.7.0.0-blue)

---

## ✨ Fonctionnalités

- Ouverture et sauvegarde de fichiers texte  
- Indicateur de modification (`*` dans le titre)  
- Coloration syntaxique JSON (avec détection d’URL)  
- Coloration XML / HTML / INI (si modules inclus)  
- Recherche, copier/coller, annuler/rétablir  
- Zoom avant/arrière, réinitialisation  
- Changement de police, couleur du texte et du fond  
- Suppression des lignes vides  
- Statistiques du document (lignes, mots, caractères)  
- Word Wrap activable/désactivable  

---

## 📁 Structure du projet

Le projet contient :

- `UniversalViewerForm.vb` — logique principale du visualiseur  
- `UniversalViewerForm.Designer.vb` — interface générée automatiquement  
- Modules éventuels (ex. `ApplyColor.vb`)  
- Références nécessaires (Newtonsoft.Json)

---

## 🛠️ Dépendances

- .NET Framework 4.x  
- Newtonsoft.Json (via NuGet)

---

## 🚀 Compilation

1. Ouvrir le projet dans Visual Studio  
2. Restaurer les packages NuGet si nécessaire  
3. Compiler en mode Release  
4. L’exécutable se trouve dans `bin/Release/`

---

## 📦 Téléchargement

Une version compilée est disponible dans l’onglet **Releases** du dépôt.

---

## 📜 Licence

Projet personnel librement réutilisable.  
Aucune garantie d’usage.

---

# 🇬🇧 English version

Universal Viewer is a small, versatile text viewer/editor for Windows, developed in VB.NET (WinForms).  
It allows you to open, display, edit, and colorize various text formats, including JSON, XML, HTML, and INI.

![Version](https://img.shields.io/badge/version-v3.7.0.0-blue)

---

## ✨ Features

- Open and save text files  
- Modification indicator (`*` in the window title)  
- JSON syntax highlighting (with URL detection)  
- XML / HTML / INI highlighting (if modules are included)  
- Search, copy/paste, undo/redo  
- Zoom in/out, reset  
- Change font, text color, and background color  
- Remove empty lines  
- Document statistics (lines, words, characters)  
- Optional Word Wrap  

---

## 📁 Project structure

The project includes:

- `UniversalViewerForm.vb` — main viewer logic  
- `UniversalViewerForm.Designer.vb` — auto‑generated UI  
- Optional modules (e.g., `ApplyColor.vb`)  
- Required references (Newtonsoft.Json)

---

## 🛠️ Dependencies

- .NET Framework 4.x  
- Newtonsoft.Json (via NuGet)

---

## 🚀 Build instructions

1. Open the project in Visual Studio  
2. Restore NuGet packages if needed  
3. Build in Release mode  
4. The executable will be located in `bin/Release/`

---

## 📦 Download

A compiled version is available in the repository’s **Releases** section.

---

## 📜 License

Personal project, freely reusable.  
No warranty provided.
