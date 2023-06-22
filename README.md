# MVVMMaui

Bienvenue sur l'application prepaLoL.

Le projet est une application MAUI cross-platform.

    - MVVM "maison" sur la branch MVVM: https://codefirst.iut.uca.fr/git/maia.perderizet/MVVMMaui/src/branch/MVVM
    - MVVM community toolkit sur la branch MVVMtoolkit: https://codefirst.iut.uca.fr/git/maia.perderizet/MVVMMaui/src/branch/MVVMtoolkit

# Sommaire

- [MVVM maison](#mvvmmaison)
- [Requirements](#requirements)
- [Installation](#installation)
    - [Lancement:](#lancement)
- [Auteurs](#auteurs)

# Architecture du projet

- Shared
- StubLib
- Tests
- Model
- MVVMMaui: projet représentant la vue de l'application
- ViewModel: les VMs 
- MVVM: MVVM maison (il n'est pas présent sur la branch du tollkit)

Le principe du MVVM est de séprarer la vue et le model avec des VMs. Il est composé d'un model, de VM qui vont wrapper le model et enfin de la vue. Les VMs sont indépendante de la vue, on peut donc les réutilisés avec d'autre vue.

# MVVM "maison"

Mes VMs sont divisé en deux, les VMs qui wrap le model qui sont dans "ViewModel" et mes VMs applicative qui sont dans le projet MVVMMaui->VM.



# MVVM toolkit


# Requirements

Le projet utilise .NET7, je vous conseille de le lancé sur Visual Studio 2022 (ou 2019).

# Installation

Cloné le dépôt du projet: ```git clone https://codefirst.iut.uca.fr/git/maia.perderizet/MVVMMaui.git```.

## Lancement:

- Ouvrir la solution dans Visual Studio.
- Choisir l'émulateur
- Lancer le projet MVVMMaui

# Auteurs
Maïa PERDERIZET

_Generated with a_ **Code#0** _template_  
<img src="Documentation/doc_images/CodeFirst.png" height=40/>   
