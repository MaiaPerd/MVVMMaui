# MVVMMaui

Bienvenue sur l'application prepaLoL.

Le projet est une application MAUI cross-platform.

    - MVVM "maison" sur la branch MVVM: https://codefirst.iut.uca.fr/git/maia.perderizet/MVVMMaui/src/branch/MVVM
    - MVVM community toolkit sur la branch MVVMtoolkit: https://codefirst.iut.uca.fr/git/maia.perderizet/MVVMMaui/src/branch/MVVMtoolkit

# Sommaire

- [MVVM maison](#mvvm_maison)
- [MVVM toolkit](#mvvm_toolkit)
- [Ce qui marche](#ce_qui_marche)
- [Ce qui marche pas](#ce_qui_marche_pas)
- [Ce qui marche un peu près](#ce_qui_marche_un_peu_pres)
- [Ce qui n'est pas fait](#ce_qui_nest_pas_fait)
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

## VM

Mes VMs sont divisé en deux, les VMs qui wrap le model qui sont dans "ViewModel" et mes VMs applicative qui sont dans le projet MVVMMaui->VM.

Mes VMs de wrapping:

Mes VMs applicative:

J'ai décider de faire une VM applicative par page.
Chaque page définie en BindingContext la page correspondante.
Dans ces VMs il y a l'objet sur lequelle je me bind pour récupérer ce que je veux afficher et les commandes de navigation exclusive a la vue.

Mes pages:

## toolkit "maison"

Mise en place de deux classe dont hériteront mes VM dans "MVVM".
La première classe est BaseVM implémente INotifyPropertyChanged.  
La deuxième classe est BaseGenericVM<Base> hérite de BaseVM et ajoute une propriétée model avec un constructeur qui l'initialise. 

# MVVM toolkit

Le toolkit permet de facilité la déclaration des propriétés observable et des commandes.

# Ce qui marche

- La page d'accueil.
- La page des champions avec:
    - la pagination.
    - la possibilité de changer le nombre de champion par page.
    - le swipe avec le clique sur le edit et la suppression.
    - bouton ajouter navigant vers la page d'ajout d'un nouveau champion.
- La page du détail d'un champion avec l'affichage de toutes ces informations:
    - Detail du skin avec un tap sur l'éléments
- La page Ajouter/Modifier un champion:
    - Le nom (que pour l'ajout).
    - L'icon.
    - L'image.
    - La bio.
    - La classe.
    - Ajout et suppression des caractéristiques (swipe sur l'element pour la suppression).
- La page de détail du skin avec la possibilité de le modifier.

# Ce qui ne marche pas

- Modifier un champion: 
    - Le radio bouton ne séléctionne pas la classe actuel du champion.
    - La gestion des compétences.

- La page ajouter une compétence:
    - Ajout de la nouvelle compétence (Modifie juste les vms sans modifier le model).
    
Sur android le bouton ajouter un skin fait planter l'application.

# Ce qui marche un peu près

- Gestion des skins:
    - Ajout d'un skin, il s'ajoute mais si on sort de la page puis reviens il n'est plus présent mais si on reviens une deuxième fois la mise à jours est faite.
    - Suppression d'un skin, même problème que l'ajout. (swipe sur le skin pour la suppression)

- Modifier un champion: 
    - La gestion des compétences marche mal.
    - Problème d'affichage du radio button.
    
- Picker des images sur les fichiers de l'appareil et non des photos.


# Ce qui n'est pas fait

Modification des caractéristiques et des skills.

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
