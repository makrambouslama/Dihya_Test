# Dihya_Test
Enoncé de l’exercice .Net :


Implémenter une structure de données gérant les mois de l'année dans deux langues différentes (au choix dans le constructeur ou dans une factory) , SANS utiliser ni liste, ni tableau ni autre structure gérant une collection interne(il est interdit d'avoir un tableau private qui garde les mois en mémoire) . On doit pouvoir énumérer l'ensemble des mois et les voir s'afficher à l'écran et de même, si l'on donne un numéro, avoir le mois qui correspond (et vice-versa dans l'idéal). Il est évidemment interdit d'utiliser les objets de Culture de NET (ou de Js puisque le langage n'est pas important pour le coup). La structure , sans être un singleton , doit aussi vérifier qu'il n'existe aucune autre instance d'elle -même en cours d'exécution (dans le même process pour les devs voire au niveau de toute la machine si possible)

Après, un niveau au-dessus, c'est la même mais en implémentant IList , puis IList<T> où T est une classe /structure/record représentant un mois.

Pour finir faire un contrôle JQuery qui, en utilisant cette même structure nous permet de sélectionner un mois dans une drop-down, en gérant si possible les traductions.

En exercice extra : gestion d'autres calendriers que le calendrier Grégorien
