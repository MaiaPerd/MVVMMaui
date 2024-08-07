# MVVMMaui

Bienvenue sur l'application prepaLoL.

Le projet est une application MAUI cross-platform.

    - MVVM "maison" sur la branch MVVM
    - MVVM community toolkit sur la branch MVVMtoolkit

# Sommaire

- [Architecture du projet](#architecture-du-projet)
- [MVVM maison](#mvvm-maison)
- [MVVM toolkit](#mvvm-toolkit)
- [Ce qui fonctionne](#ce-qui-fonctionne)
- [Ce qui ne fonctionne pas](#ce-qui-ne-fonctionne-pas)
- [Ce qui fonctionne à-peu-près](#ce-qui-fonctionne-à-peu-près)
- [Ce qui n'est pas fait](#ce-qui-nest-pas-fait)
- [Requirements](#requirements)
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

Le principe du MVVM est de séparer la vue et le model avec des VMs. Il est composé d'un model, de VMs qui vont wrapper le model et enfin de la vue. Les VMs sont indépendantes de la vue, on peut donc les réutiliser avec d'autres vues.

# MVVM "maison"

## VM

Mes VMs sont divisées en deux, les VMs qui wrap le model qui sont dans "ViewModel" et mes VMs applicative qui sont dans le projet MVVMMaui->VM.

J'ai décidé de faire une VM applicative par page.
Chaque page définit en BindingContext la page correspondante.
Dans ces VMs il y a l'objet sur lequel je me bind pour récupérer ce que je veux afficher et les commandes de navigation exclusives à la vue.

## toolkit "maison"

Mise en place de deux classes dont hériteront mes VM dans "MVVM".
La première classe est BaseVM qui implémente INotifyPropertyChanged.  
La deuxième classe est BaseGenericVM<Base> qui hérite de BaseVM et ajoute une propriété model avec un constructeur qui l'initialise. 

# MVVM toolkit

Le toolkit permet de faciliter la déclaration des propriétés observables et des commandes.
J'ai commencé à le mettre en place sur mon projet. (La relay command pour la pagination ne fonctionne pas)

# Ce qui fonctionne

- La page d'accueil.
- La page des champions avec:
    - la pagination.
    - la possibilité de changer le nombre de champion par page.
    - le swipe avec le clique sur le edit et la suppression.
    - le bouton "Ajouter" navigant vers la page d'ajout d'un nouveau champion.
- La page du détail d'un champion avec l'affichage de toutes ces informations:
    - Detail du skin avec un clique sur l'élément
- La page "Ajouter/Modifier" un champion:
    - Le nom (que pour l'ajout).
    - L'icône.
    - L'image.
    - La bio.
    - La classe.
    - Ajout et suppression des caractéristiques (swipe sur l'élement pour la suppression).
- La page de détail du skin avec la possibilité de la modifier.

# Ce qui ne fonctionne pas

- Modifier un champion: 
    - Le bouton "radio" ne séléctionne pas la classe actuel du champion.
    - La gestion des compétences.

- La page "Ajouter une compétence":
    - Ajout de la nouvelle compétence (Modifie juste les vms sans modifier le model).
    
Sur android le bouton "Ajouter un skin" fait planter l'application.

# Ce qui fonctionne à-peu-près

- Gestion des skins:
    - Ajout d'un skin, il s'ajoute mais si on sort de la page puis on y revient, il n'est plus présent mais si on revient une deuxième fois la mise à jour est faite.
    - Suppression d'un skin, même problème que l'ajout. (swipe sur le skin pour la suppression)

- Modifier un champion: 
    - La gestion des compétences fonctionne mal.
    - Problème d'affichage du "bouton radio".
    
- "Picker" qui permet de récupérer des images sur les fichiers de l'appareil et non des photos.


# Ce qui n'est pas fait

Modification des caractéristiques et des skills.
Tri des listes par ordre alphabétique.

# Requirements

Le projet utilise .NET7, je vous conseille de le lancer sur Visual Studio 2022 (ou 2019).

## Lancement:

- Ouvrir la solution dans Visual Studio.
- Choisir l'émulateur
- Lancer le projet MVVMMaui

# Auteurs
Maïa PERDERIZET

