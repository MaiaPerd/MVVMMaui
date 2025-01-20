# MVVMMaui

Bienvenue sur l'application MVVMMaui.

Le projet est une application MAUI cross-platform permettant à l'utilisateur de voir des informations sur les personnages du célèbre jeu League Of Legends et de modifier leurs informations.

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
- MVVM: MVVM maison (il n'est pas présent sur la branch du toolkit)

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

# Requirements

Le projet utilise .NET7, je vous conseille de le lancer sur Visual Studio 2022 (ou 2019).

## Lancement:

- Ouvrir la solution dans Visual Studio.
- Choisir l'émulateur
- Lancer le projet MVVMMaui

# Auteurs
Maïa PERDERIZET

