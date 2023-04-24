Feature: TestLivres

Tests fonctionnels sur l'onglet des livres

@RechercheNom
Scenario: Test recherche par nom
	Given Je saisis la valeur "Guide" dans le champ de recherche de titre
	Then Le datagridview affiche des livres avec le nom contenant uniquement la valeur "Guide"


@RechercheID
Scenario: Test recherche par ID
	Given Je saisis la valeur "00017" dans le champ de recherche de l'id
	When Je clique sur le bouton de recherche
	Then Le datagridview affiche le livre possédant l'id "00017"

@RechercheGenre
Scenario: Test recherche par Genre
	Given Je choisis l'option "Voyages" dans le combobox de recherche par genre
	Then Tous les livres auront "Voyages" comme genre

@RecherchePublic
Scenario: Test recherche par Public
	Given Je choisis l'option "Tout public" dans le combobox de recherche par public
	Then Tous les livres auront "Tout public" comme public

@RechercheRayon
Scenario: Test recherche par Rayon
	Given Je choisis l'option "Voyages" dans le combobox de recherche par rayon
	Then Tous les livres seront dans le rayon "Voyages"
