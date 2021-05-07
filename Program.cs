using System;
using System.Collections.Generic;


/* Ce jeu présente le même fonctionnement que le jeu familial Trivial Pursuit. 
 * Il est conseilé de jouer à plusieurs pour que les participants valident les réponses des autres (en cas de réponse mal orthographiée par exemple).
 * Un décompte est fait est le jeu s'arrête lorsqu'un participant à les 6 fromages et a répondu juste à une question de son choix. */

namespace Trivial_poursuite
{
    class Program
    {
        /* Cette première méthode permet de lancer une partie et relancer une nouvelle partie ou quitter le jeu lorsqu'une partie est terminée. */
        static void Main(string[] args)
        {
            string fin = "N";
            while (fin != "Q")
            {
                if (fin == "N")
                {
                    Console.Clear();
                    partie();
                    Console.WriteLine("\nAppuyez sur Q pour quitter le jeu et N pour commencer une nouvelle partie.");
                    fin = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("\nAppuyez sur Q pour quitter le jeu et N pour commencer une nouvelle partie.");
                    fin = Console.ReadLine();
                }
            }

        }

        /*Cette méthoed permet de lancer une partie.*/
        static void partie()
        {
            /*Instructions de jeu*/
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\tCe jeu fonctionne comme le jeu du Trivial Pursuit à quelques exceptions près.");
            Console.WriteLine("\tTout d'abord, il vous faudra indiquer le nombre de personnes qui vont participer à la partie lorsqu'il vous le sera demandé.");
            Console.WriteLine("Info: il est conseillé de jouer à plusieurs car ce sera à vous de valider les réponses, à cause de l'orthographie des réponses.");
            Console.WriteLine("\tEnsuite la partie se déroulera dans l'ordre des participants. Le principe est de répondre juste à au moins une question de chaque catégorie : Géographie, Divertissement, Histoire, Arts et Littératures, SVT et Sports et Loisirs.");
            Console.WriteLine("Vous pouvez répondre à plusieurs questions de chaque catégorie mais cela ne vous servira à rien, vous ne marquerez pas de points.");
            Console.WriteLine("Pour répondre à la question, rentrez votre réponse dans la console.");
            Console.WriteLine("\tUne fois votre réponse donnée, vos collègues de jeu devront valider la réponse avec le mot clé Vrai ou Faux.");
            Console.WriteLine("\tUne fois qu'un joueur aura répondu juste à chacune des catégories, il aura gagné.");
            Console.ResetColor();

            /* Début de la partie.  Récupère le nombre de joueurs.*/
            int nbrJoueurs = 0;
            while (nbrJoueurs == 0)
            {
                Console.WriteLine("\nCombien de joueurs êtes vous ?");
                string nbrJoueursStr = Console.ReadLine();
                if (int.TryParse(nbrJoueursStr, out nbrJoueurs))
                {
                    Console.WriteLine("Vous êtes " + nbrJoueurs + " joueurs.");

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Erreur : Rentrez un nombre de joueurs sous forme de nombre.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }

            /* Crée un tableau contenant les scores de chaque personnes sous forme d'une liste de tableaux. Chaque tableau de score est initialisé à 0.*/
            List<int[]> scorePartie = new List<int[]>();
            for (int i = 0; i < nbrJoueurs; i++)
            {
                scorePartie.Add(new int[] { 0, 0, 0, 0, 0, 0 });
            }

            /*Appelle les différentes fonctions et la boucle While permet de faire tourner la partie tant qu'aucun joueur n'a répondu juste dans chaque catégorie de questions.*/
            int numJoueur = 1;
            while (testGagnant(nbrJoueurs, scorePartie) == false)
            {
                Console.WriteLine("\n\nC'est au joueur " + numJoueur + " de jouer.");
                Console.WriteLine("\nVous voulez une question de quelle catégorie : Histoire, Divertissement, Géographie, Arts et Littérature, SVT ou Sports et loisirs");
                Console.WriteLine("Saisissez la catégorie tel quelle est écrite au-dessus.");
                string categorie = Console.ReadLine();

                /* Vérifie que la catégorie rentrée existe bien. */
                while (categorie != "Histoire")
                {
                    if (categorie == "Géographie")
                    {
                        break;
                    }
                    else if (categorie == "Arts et Littérature")
                    {
                        break;
                    }
                    else if (categorie == "SVT")
                    {
                        break;
                    }
                    else if (categorie == "Divertissement")
                    {
                        break;
                    }
                    else if (categorie == "Sports et loisirs")
                    {
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine("\n Erreur : Saississez une des catégories suivantes : Histoire, Divertissement, Géographie, Arts et Littérature, SVT ou Sports et loisirs.");
                        categorie = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                }

                /* Pose la question en fonction de la catégorie choisie. */
                if (categorie == "Histoire")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    questionHist(scorePartie, numJoueur);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (categorie == "Géographie")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    questionGeo(scorePartie, numJoueur);
                    Console.ForegroundColor = ConsoleColor.White;                    
                }
                else if (categorie == "Divertissement")
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    questionDiv(scorePartie, numJoueur);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (categorie == "Arts et Littérature")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    questionAEL(scorePartie, numJoueur);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (categorie == "SVT")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    questionSvt(scorePartie, numJoueur);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (categorie == "Sports et loisirs")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    questionSEL(scorePartie, numJoueur);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                /*Calcule le numéro du joueur qui doit jouer le prochain tour.*/
                if (numJoueur == nbrJoueurs)
                {
                    numJoueur = 1;
                    affichageScore(scorePartie, nbrJoueurs);
                }
                else
                {
                    numJoueur = numJoueur + 1;
                }
            }
        }

        /*Cette méthode permet de tester si un joueur a 1 point dans chaque catégorie de questions. */
        static Boolean testGagnant(int nbrJoueurs, List<int[]> scorePartie)
        {
            for (int i = 0; i < nbrJoueurs; i++)
            {
                if (scorePartie[i][0] == 1 && scorePartie[i][1] == 1 && scorePartie[i][2] == 1 && scorePartie[i][3] == 1 && scorePartie[i][4] == 1 && scorePartie[i][5] == 1)
                {
                    Gagnant(i);
                    return true;
                }
            }
            return false;
        }

        /*Cette méthode affiche le gagnant de la partie.*/
        static void Gagnant(int i)
        {
            int numjoueur = i + 1;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\tLe joueur qui a gagné est le joueur " + numjoueur + ". Il a donné une bonne réponse dans toutes les catégories.");
            Console.WriteLine("\tFélicitations Joueur " + numjoueur + ", vous êtes le vainqueur de cette partie !!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        /*Cette méthode pose une question d'histoire.*/
        static void questionHist(List<int[]> scorePartie, int numJoueur)
        {
            /*Dans cette partie, nous choissons le numéro de la question. */
            Random rndHistoire = new Random();
            string[] histoire = new string[] {"Quel est le surnom courant du bonhomme Michelin ?",
            "La Marseillaise a été composée à Marseille, Vrai ou Faux ?",
            "En Suisse, les plaques d'immatriculation identifient le propriétaire d'un véhicule et non le véhicule. Vrai ou Faux ?",
            "Selon les récits mythologiques grecs, qui aurait offert le feu aux hommes : Panacée, Pandore ou Prométhée ?",
            "Quel pays a un premier empereur dont le tombeau est gardé par des milliers de guerriers en terre cuite ?",
            "Comment s'appelel le module grâce auquel Armstrong et Aldrin ont marché sur la Lune en 1969 : Eagle, Lunar ou Moonwalk ?",
            "Quel roi a dû se convertir au catholicisme et signer l'Edit de Nantes ?",
            "Comment les grecs de l'Antiquité appelaient-ils les femmes oracles, prêtresses d'Apollon à Delphes ?",
            "Qui a découvert la Jamaïque : Christophe Colomb, Fernand de Magellan ou Vasco de Gama ?",
            "Sous quel nom la favorite de Louis XV, Jeanne Antoinette Poisson, est-elle mieux connue ?",
            "Lequel n'est pas l'un des 7 péchés capitaux : l'envie, la malhonnêteté ou la luxure ?",
            "Dans quelle salle les députés de la Révolution ont-ils fait serment de doter la France d'une constituion ?",
            "Quelle couleur n'apparaît pas sur le logo de l'ONU : blanc, bleu ou rouge ?",
            "Laquelle de ces villes se trouve le plus au nord : Charleroi, Liège ou Anvers ?",
            "Mao Zedong a déclaré une guerre contre les moineaux. Vrai ou Faux ?",
            "Quel pays asiatique a eu Sukarno comme premier président : le Cambodge, l'Indonésie ou la Malaisie ?",
            "En quelle année a été inventé le mot Internet : 1982, 1989 ou 1994 ?",
            "Comment appelle-t-on l'étude des armoiries : héraldique, philathélie ou sigillographie ?",
            "Comment s'appelait la première épouse de Napoléon Bonaparte ?",
            "Quel homme d'affaires américain a été condamné à 150 ans de prison pour une escroquerie du type \"chaîne de Ponzi\" ?",
            "La Flandre historique a un tigre pour symbole. Vrai ou Faux ?",
            "Dans quel pays la dynastie des Romanov a-t-elle été renversée par une révolution en 1917 ?",
            "La Révolution russe a eu lieu avant la fin de la Première Guerre Mondiale. Vrai ou Faux ?",
            "Selon la médecine traditionnelle indienne, combien le corps humain compte-t-il de chakras : 5, 7 ou 12 ?",
            "Quel Plantagenêt était surnommé \"le Prince noir\" : Edouard, Henri II ou Richard ?"};
            int numQuestRep = rndHistoire.Next(0, histoire.Length - 1);
            string question = histoire[numQuestRep];
            string[] repHistoire = new string[] {"Bibendum.",
            "Faux - Elle a été composée à Strasbourg mais a d'abord été chantée par les fédérés marseillais.",
            "Vrai - comme en Belgique d'ailleurs.",
            "Prométhée.",
            "La Chine.",
            "Eagle.",
            "Henri IV - Pour mettre fin aux guerres de religion.",
            "Les Pythies.",
            "Christophe Colomb.",
            "La marquise de Pompadour.",
            "La luxure - Les autres péchés sont l'orgueil, la gourmandise, la paresse, la colère, l'envie et l'avarice.",
            "Dans la salle du jeu de Paume.",
            "Rouge.",
            "Anvers.",
            "Vrai - Les moineaux sont considérés comme nuisibles car ils mangent les récoltes.",
            "L'Indonésie.",
            "1982.",
            "L'héraldique.",
            "Joséphine (de BeauHarnnais).",
            "Bernard Madoff.",
            "Faux - C'est le lion.",
            "En Russie.", 
            "Vrai - Elle a commencée en 1917.",
            "7.",
            "Edouard."};
            string bonneReponse = repHistoire[numQuestRep];
            
            /* Ici nous lisons la réponse du joueur, donnons la réponse correcte et nous vérifions si le joueur a juste grâce à une méthode.*/
            Console.WriteLine("\n" + question);
            string reponse = Console.ReadLine();
            Console.WriteLine("\nLe joueur " + numJoueur + " a donné la réponse suivante : " + reponse + ".");
            Console.WriteLine("La bonne réponse était : " + bonneReponse);
            testReponse(numJoueur, "Histoire", scorePartie);
        }

        /*Cette méthode pose une question de géographie.*/
        static void questionGeo(List<int[]> scorePartie, int numJoueur)
        {
            /*Dans cette partie, nous choissons le numéro de la question. */
            Random rndGeo = new Random();
            string[] geographie = new string[] {"Laquelle de ces villes n'est pas liée à un syndrôme : Paris, San Francisco ou Stockholm ?",
            "Dans quel pays l'Euro a t'il remplacé la drachme ?",
            "Comment appelle-t-on l'écosystème sans arbres de l'Arctique et du sommet des montagnes : toundra, savane ou steppe ?",
            "Selon le surnom qui lui est donné, combien Rome compte-t-elle de collines ?",
            "Quelle race de chiens porte le même nom qu'un comté du Nord Est de l'Angleterre ?",
            "Lequel de ces pays ne possède pas de parc Lego : l'Allemagne, le Danemark ou l'Espagne ?",
            "Quelle est la plus grande des îles de la mer Méditerranée : Chypre, la Corse ou la Sicile ?",
            "Laquelle de ces îles n'appartient pas à la Polynésie française : Bora Bora, Moorea ou Tonga ?",
            "Quel pays d'Europe est relié à Sydney par la route Kangourou ?",
            "Lequel de ces pays ne se trouve pas en Amérique du Sud : l'Equateur, le Guyana ou le Mexique ?",
            "Quelle grande ville d'Italie se trouve à quelques kilomètres à l'Ouest du Vésuve ?",
            "A quel pays méditérannéen les îles de Gozo et Comino appartiennent-elles ?",
            "Quel étit autrefois le terminus de l'Orient-Express partant d'Istanbul ?",
            "Sur quelle île peut-on voir des statues géantes, parfois coiffées d'un chapeau rouge, appelées moaï ?",
            "En économie, dans quel secteur classe-t-on la pêche ?",
            "Citez au moins 3 des 5 pays d'Afrique dont le nom comprend un \"Z\" ?",
            "Dans quelle ville se trouve la petite statue du Manneken-Pis ?",
            "De quelle ville belge le waterzooi est-il une spécialité : Bruges, Bruxelles ou Gand ?",
            "Quel pays a un drapeau décoré d'un lama et d'un condor : la Bolivie, le Kenya ou la Suisse ?",
            "Lequel de ces pays n'est pas traversé par le Nil : l'Ouganda, la Somalie ou le Soudan ?",
            "Quelle ville d'Aquitaine est particulièrement réputée pour ses pruneaux ?",
            "Dans quelle région française se trouve la forêt de Brocéliande : Bretagne, Normandie ou Poitou-Charente ?",
            "Lequel de ces pays ne fait pas partie de l'ex-Yougoslavie : l'Albanie, le Monténégro ou la Serbie ?",
            "Le mcDonald's de Hong Kong propose d'y organiser son repas de mariage. Vrai ou Faux ?",
            "Quel capitale est desservie par l'aéroport codé LHR ?"};
            int numQuestRep = rndGeo.Next(0, geographie.Length - 1);
            string question = geographie[numQuestRep];
            string[] repGeographie = new string[] {"San Francisco.",
            "En Grèce.",
            "La toundra.",
            "Sept - comme Lisbonne.",
            "Le Yorkshire.",
            "L'Espagne.",
            "La Sicile.",
            "Tonga - C'est un Etat indépendant.",
            "Le Royaume-Uni.",
            "Le Mexique - Géographiquement, le Mexique se trouve en Amérique du Nord.",
            "Naples.",
            "A Malte.",
            "Paris.",
            "Sur l'île de Pâques.",
            "Le secteur primaire.",
            "Mozambique, Swaziland, Tanzanie, Zambie, Zimbabwe.",
            "A Bruxelles - En Belgique.",
            "Gand - C'est un plat en sauce de poisson ou de poulet.",
            "La Bolivie.",
            "La Somalie.",
            "Agen.",
            "Bretagne.",
            "L'Albanie.",
            "Vrai - Le gâteau est une tour de tartes aux pommes.",
            "Londres - C'est le code de l'aéroport de Heathrow."};
            string bonneReponse = repGeographie[numQuestRep];

            /* Ici nous lisons la réponse du joueur, donnons la réponse correcte et nous vérifions si le joueur a juste grâce à une méthode.*/
            Console.WriteLine("\n" + question);
            string reponse = Console.ReadLine();
            Console.WriteLine("\nLe joueur " + numJoueur + " a donné la réponse suivante : " + reponse + ".");
            Console.WriteLine("La bonne réponse était : " + bonneReponse);
            testReponse(numJoueur, "Géographie", scorePartie);
        }

        /*Cette méthode pose une question de divertissement.*/
        static void questionDiv(List<int[]> scorePartie, int numJoueur)
        {
            /*Dans cette partie, nous choissons le numéro de la question. */
            Random rndDiv = new Random();
            string[] divertissement = new string[] {"Quel chapeau tire son nom du mot espagnol signifiant \"ombre\" ?",
            "Quel groupe compte des membres tels que will.i.am et apl.de.ap ?",
            "Lequel de ces acteurs n'a pas interprété Astérix au cinéma : Christian Clavier, Alain Chabat ou Clovis Cornillac ?",
            "Quelle chanson signée John Legend se termine par ces mots : \"And the world will live as one\" ?",
            "Quelle lecture radiophonique d'un ouvrage d'Orson Welles a paniqué les auditeurs en 1938 ?",
            "Quels super-héros ont croisé le Surfer d'argent au cinéma en 2007 ?",
            "Lequel de ces acteurs n'a pas interprété Jack Ryan au cinéma : Ben Affleck, Alec Baldwin ou Tom Hanks ?",
            "Quelle chanteuse appelle ses fans ses \"petits monstres\" ?",
            "Quel Batman a sur sa bande originale la chanson \"Hold Me, Thrill Me, Kiss Me, Kill Me\" de U2 ?",
            "Comment s'appelle la marionnette du ventriloque Michel Dejeneffe : Gnafron, Muppet ou Tatayet ?",
            "Qui incarne le guide du film Les Randonneurs : Benoît Poelvoorde, Albert Dupontel ou Vincent Elbaz ?",
            "Quelle actrice américaine a épousé Rainier III, prince de Monaco : Grace Kelly, Shirley Knight ou Marilyn Monroe ?",
            "A qui Elton John avait-il dédié la première version de sa chanson \"Candle in the Wind\" ?",
            "Lequel de ces films n'est pas avec Cécile de France : L'Auberge espagnole, Le Gamin au vélo ou Un frère ?",
            "Avec quel rappeur Rihanna a-t-elle chanté Love The Way You Lie ?",
            "Quel film a été le premier film en 3D à faire l'ouverture du festival de Cannes ?",
            "Quel est le héros grec dont le film Le Choc des Titans relate l'histoire ?",
            "Comment s'appelle le personnage de la série L'Agence tous risques interprété par Mister T ?",
            "Qui a remplacé Evelyne Leclerc aux manettes de Tournez manège ?",
            "Nicolas Canteloup a été GO au Club Med avant de devenir imitateur. Vrai ou Faux ?",
            "Comment sont nommés les Men in Black : par des lettres, par des chiffres ou bien ils s'appellent tous \"agent Smith\" ?",
            "Quel groupe de rock compte parmi ses membres Paul Hewson et Dave Evans ?",
            "De quoi parle Tournée de Matthieu Amalric : de Girl Power, de New Burlesque ou de Roller Derby ?",
            "Quel humoriste ponctue la plupart de ses phrases d'un \"pour toi, public\" ?",
            "Quelle série télévisée a pour narratrice une jeune femme décédée appelée Mary Alice Young ?"};
            int numQuestRep = rndDiv.Next(0, divertissement.Length - 1);
            string question = divertissement[numQuestRep];
            string[] repDivertissement = new string[] {"Le sombrero.",
            "The Black Eyed Peas.",
            "Alain Chabat.",
            "Imagine.",
            "La Guerre des Mondes - Certains auditeurs ont cru qu'une invasion extraterrestre était en cours.",
            "Les Quatre Fantastiques.",
            "Tom Hanks.",
            "Lady Gaga.",
            "Batman Forever.",
            "Tatayet.",
            "Benoît Poelvoorde.",
            "Grace Kelly.",
            "A Marilyn Monroe - Une nouvelle version a ensuite été écrite pour la princesse Diana.",
            "Un frère.", 
            "Eminem.",
            "Là-haut.",
            "Persée.",
            "Barracuda.",
            "Sébastien Cauet.",
            "Vrai.",
            "Par des lettre.",
            "U2 - Mieux connus sous leurs noms de scène, Bono et The Edge.",
            "De New Burlesque.",
            "Franck Dubosc.",
            "Desperate Housewives."};
            string bonneReponse = repDivertissement[numQuestRep];

            /* Ici nous lisons la réponse du joueur, donnons la réponse correcte et nous vérifions si le joueur a juste grâce à une méthode.*/
            Console.WriteLine("\n" + question);
            string reponse = Console.ReadLine();
            Console.WriteLine("\nLe joueur " + numJoueur + " a donné la réponse suivante : " + reponse + ".");
            Console.WriteLine("La bonne réponse était : " + bonneReponse);
            testReponse(numJoueur, "Divertissement", scorePartie);
        }

        /*Cette méthode pose une question d'arts et littérature.*/
        static void questionAEL(List<int[]> scorePartie, int numJoueur)
        {
            /*Dans cette partie, nous choissons le numéro de la question. */
            Random rndAEL = new Random();
            string[] artsLitterature = new string[] {"En informatique, quelle est l'unité de base permettant de mesurer la définition d'une image ?",
            "Combien une trompette moderne compte-t-elle de pistons : deux, trois ou cinq ?",
            "Dans quel village de bande dessiné se trouve la boucherie Sanzot ?",
            "\"Les chaussettes de l'archiduchesse sont-elles sèches ?\" est : une fourchebouche, un paronyme ou un virelangue ?",
            "Lequel de ces artistes n'a pas vécu dans la \"Maison Jaune\" d'Arles : Gauguin, Monet ou Van Gogh ?",
            "Les personnages principaux de Tom est mort et de Clèves de Marie Darrieussecq sont des hommes. Vrai ou Faux ?",
            "Comment s'appelle le style de chapeau que portait Maurice Chevalier ?",
            "Comment s'appellent les parents de Gargantua, dans le roman de François Rabelais ?",
            "Quel jour de la semaine paraît l'hebdomadaire culturel Les Inrockuptibles : le mardi, le mercredi ou le jeudi ?",
            "Dans la bande dessinée Boule et Bill, Bill est le graçon et Boule son chien. Vrai ou Faux ?",
            "Quel couple de la mythologie grecque symbolise l'amour conjugal éternel ?",
            "Laquelle de ces langues ne se trouvait pas sur la pierre de Rosette : le démotique, le grec ancien ou le latin ?",
            "Les sculptures romaines anciennes étaient souvent peintes de couleurs vives. Vrai ou faux ?",
            "Quel ouvrage Karl Marx et Friedrich Engels ont-ils coécrit ?",
            "Dans Sans famille, comment s'appelle le vieil homme à qui le jeune orphelin Rémi est vendu ?",
            "Lequel de ces mots n'a pas de ligature (\"e dans l'o\") : moelleux, Oedipe ou oesophage ?",
            "Lequel de ces philosophes a dit : \"Tout ce que je sais, c'est que je ne sais rien.\" : Socrate, Platon ou Nietzsche ?",
            "Laquelle de ces BD n'est pas signée Hergé : Jo, Zette et Jocko, Blake et Mortimer ou Quick et Flupke ?",
            "Le prix Goncourt est doté d'une récompense de 10 euros. Vrai ou Faux ?",
            "Quel est le plat favori du commissaire Maigret : la blanquette de veau, le boeuf bourguignon ou la poule au pot ?",
            "Quel écrivain a affirmé qu'\"il faut être absolument moderne\" : Albert Camus, Arthur Rimbaud ou Jean-Paul Sartre ?",
            "Quel artiste est connu pour ses peintures et sculptures de danseurs de ballet : Degas, Gauguin ou Matisse ?",
            "Comment s'appelle le théâtre le plus prestigieux de Moscou, situé non loin du Kremlin ?",
            "Quels insectes Bernard Werber a-t-il mis en scène dans sa première trilogie : des abeilles, des fourmis ou des guêpes ?",
            "Qu'est-ce qui n'est pas mentionné dans le titre de Guérir de David Servan-Schreiber : l'anxiété, le cancer ou le stress ?"};
            int numQuestRep = rndAEL.Next(0, artsLitterature.Length - 1);
            string question = artsLitterature[numQuestRep];
            string[] repArtsLitterature = new string[] {"Le pixel.",
            "Trois.",
            "A Moulinsart.",
            "Un virelangue.",
            "Monet.",
            "Faux - Marie Darrieussecq fait souvent le choix d'un personnage principal féminin.",
            "Un canotier.",
            "Gargamelle et Grandgousier.",
            "Le mardi.",
            "Faux - C'est Boule le petit garçon, et Bill son chien.",
            "Philémon et Baucis.",
            "Le latin - En revanche il y avait de l'égyptien.",
            "Vrai - les Romains peignaient leurs sculptures et utilisaient également des marbres colorés.",
            "Le Manifeste du Parti Communiste.",
            "Vitalis.",
            "Moelleux.",
            "Socrate.",
            "Blake et Mortimer - Elle est signée Edgar P.Jacobs.",
            "Vrai - Mais le tirage attendu compense largement la faiblesse de cette somme.",
            "La blanquette de veau.",
            "Arthur Rimbaud.", 
            "Degas.",
            "Le Bolchoï.",
            "Des fourmis.",
            "Le cancer."};
            string bonneReponse = repArtsLitterature[numQuestRep];

            /* Ici nous lisons la réponse du joueur, donnons la réponse correcte et nous vérifions si le joueur a juste grâce à une méthode.*/
            Console.WriteLine("\n" + question);
            string reponse = Console.ReadLine();
            Console.WriteLine("\nLe joueur " + numJoueur + " a donné la réponse suivante : " + reponse + ".");
            Console.WriteLine("La bonne réponse était : " + bonneReponse);
            testReponse(numJoueur, "Arts et Littérature", scorePartie);
        }

        /*Cette méthode pose une question de SVT.*/
        static void questionSvt(List<int[]> scorePartie, int numJoueur)
        {
            /*Dans cette partie, nous choissons le numéro de la question. */
            Random rndSvt = new Random();
            string[] svt = new string[] {"Le son voyage plus vite que la lumière. Vrai ou Faux ?",
            "En imprimerie, que signifie CMJN ?",
            "Dans le film d'animation Le Roi lion, quel genre d'animal est Timon ?",
            "De quel combustible l'anthracite et le lignite sont-ils des formes ?",
            "Lequel de ces fruits est le moins calorique (pour 100g) : la banane, la fraise ou la myrtille ?",
            "Laquelle de ces espèces de de tigres est la plus grosse : tigre du Bengale, tigre de Malaisie ou tigre de Sibérie ?",
            "A quelle vitesse va un bateau qui se déplace à 5 noeuds : 9, 14 ou 21 km/h ?",
            "\"Crocodile\" vient du latin crocodilus, qui signifie littéralement \"cheval de rivière\". Vrai ou Faux ?",
            "S'il y a suffisamment de soleil, quelle vitamine le corps humain est-il capable de synthétiser ?",
            "Quelle maladie banale est souvent provoquée par un rhinovirus ?",
            "Un oeuf d'autruche n'est formé que d'une seule cellule. Vrai ou Faux ?",
            "Quel organe est enlevé en cas de néphrectomie : le foie, le pancréas ou le rein ?",
            "Quel animal se défant en jetant ses intestins sur ses adversaires : le bigorneau, le concombre de mer ou l'anguille ?",
            "Quelle hormone notre cerveau sécrète-t-il en l'abscence de lumière : de l'adrénaline, du cortisol ou de la mélatonine ?",
            "Quel aliment n'est pas autorisé lors de la phase d'attaque du régime du Dr Dukan : la banane, le poulet ou le thon ?",
            "Les yeux du caméléon peuvent : bouger indépendamment, changer de couleur ou sortir de leurs orbites ?",
            "Quel groupe sanguin est considéré comme donneur universel : AB+, O+ ou O- ?",
            "Les pommes de terre et les tomates font partie de la même famille. Vrai ou Faux ?",
            "Comment appelle-t-on la lumière composée de toutes les couleur du spectre ?",
            "Quel était le métier d'Haroun Tazieff : entomologue, spéléologue ou volcanologue ?",
            "Qu'a-t-on découvert sur la Lune en 2009 lorsque la NASA y a volontairement écrasé un satellite ?",
            "Quelle échelle permet de mesurer l'intensité des cyclones : Beaufort, Saffir-Simpson ou Richter ?",
            "Quel organe du corps les hépatologues étudient-ils ?", 
            "Quelle planète a des lunes appelées Io, Europe et Callisto ?",
            "Uranus est la seule planète du Système Solaire qui tire son nom d'un Dieu grec. Vrai ou Faux ?"};
            int numQuestRep = rndSvt.Next(0, svt.Length - 1);
            string question = svt[numQuestRep];
            string[] repSvt = new string[] {"Faux - la lumière voyage plus vite que le son.",
            "Cyan, Magenta, Jaune et Noir - les quatres couleurs de la quadrichromie.",
            "C'est un suricate.",
            "De charbon.",
            "La fraise.",
            "Le tigre de Sibérie.",
            "9 km/h.",
            "Faux - C'est l'étymologie de hippopotame.",
            "La vitamine D.",
            "Le rhume.",
            "Vrai - Comme tous les oeufs.",
            "Le rein.",
            "Le concombre de mer.",
            "De la mélatonine.",
            "La banane.",
            "Bouger indépendamment - Ce qui est utile pour suivre les proies du regard sans bouger.",
            "O-.", 
            "Vrai.",
            "La lumière blanche.",
            "Volcanologue.",
            "De l'eau.",
            "Saffir-Simpson.",
            "Le foie.",
            "Jupiter.",
            "Vrai."};
            string bonneReponse = repSvt[numQuestRep];

            /* Ici nous lisons la réponse du joueur, donnons la réponse correcte et nous vérifions si le joueur a juste grâce à une méthode.*/
            Console.WriteLine("\n" + question);
            string reponse = Console.ReadLine();
            Console.WriteLine("\nLe joueur " + numJoueur + " a donné la réponse suivante : " + reponse + ".");
            Console.WriteLine("La bonne réponse était : " + bonneReponse);
            testReponse(numJoueur, "SVT", scorePartie);
        }

        /*Cette méthode pose une question de sports et loisirs.*/
        static void questionSEL(List<int[]> scorePartie, int numJoueur)
        {
            /*Dans cette partie, nous choissons le numéro de la question. */
            Random rndSEL = new Random();
            string[] sportLoisirs = new string[] {"Qu'est-ce qu'un cul-de-poule : un bol rond, une fenêtre ronde ou un trou dans la chaussée ?",
            "Comment appelle-t-on le football aux Etas-Unis ?",
            "Quel événement sportif est connu pour ses fraises à la crème : l'Open d'Australie, Roland Garros ou Wimbledon ?",
            "La course cycliste surnommée l'enfer du Nord relie Paris à Lille. Vrai ou Faux ?",
            "Quel sport Nelson Monfort commente-t-il souvent : la natation synchronisée, le patinage artistique ou le tennis ?",
            "Dans quelle discipline sportive Jean-Michel Saive s'illustre-t-il : le beach-volley, le tennis ou le tennis de table ?",
            "Aux Jeux Olympiques, les cavaliers doivent être de la même nationalité que leur monture. Vrai ou Faux ?",
            "Quelle équipe a gagné par 145 à 17 un match de coupe du monde de rugby : l'Australie, la France ou la Nouvelle-Zélande ?",
            "Lequel de ces aliments un pescetarien ne mange-t-il pas : des cacahuètes, du poulet ou du saumon ?",
            "Comment les derniers concurrents des Foulées du Gois finissent-ils leur course ?",
            "A quel éditeur de jeux vidéos doit-on Donkey Kong, Punch-Out!! et La Légende de Zelda ?",
            "En plus des oeufs, quel autre ingrédient faut-il pour fabriquer l'appareil de base de la quiche ?",
            "Qu'est-ce que le CIO, dans le domaine du sport ?",
            "Le whisky est fabriqué avec des baies de genévrier. Vrai ou Faux ?",
            "Qu'est-ce que la zumba : un animal virtuel, une danse-fitness ou un légume asiatique ?",
            "Un terrain de baseball est parfois appelé \"le carré\". Vrai ou Faux ?",
            "L'agar-agar est un produit alimentaire gélifiant obtenu à partir d'un champignon. Vrai ou Faux ?",
            "Comment appelle-t-on une manifestatiion soudaine, organisée à l'avance, et se dispersant très rapidement ?",
            "Laquelle n'est pas une lutte traditionnelle : la capoeira, la samba ou le sambo ?",
            "Quelle équipe de football a été entraîné par Guy Roux pendant plus de quarante ans ?",
            "De quelle couleur est la ceinture d'un judoka 7e dan : blanche, blanche et rouge ou rouge ?",
            "Le maté est une boison à base de malt. Vrai ou Faux ?",
            "Sur quelle distance les femmes courent-elles l'équivalent du 110 mètres haies ?",
            "Quel style de nage, parmi les quatre officiels, est le plus lent ?",
            "Quelle équipe de rugby joue à domicile dans le stade de Murrayfield : l'équipe australienne, écossaise ou irlandandaise ?"};
            int numQuestRep = rndSEL.Next(0, sportLoisirs.Length - 1);
            string question = sportLoisirs[numQuestRep];
            string[] repSportLoisirs = new string[] {"Un bol rond, on s'en sert pour la patisserie",
            "Soccer - le mot \"football\" est résérvé au football américain",
            "Wimbledon",
            "Faux - Elle relie Paris à Roubaix",
            "Le patinage artistique",
            "Le tennis de table.",
            "Vrai.",
            "La Nouvelle-Zélande - C'était contre le Japon en 1995.",
            "Du poulet - Les pescetariens ne mange pas de viande, mais ils mangent du poisson.",
            "A la nage - Le Gois est une chaussée submersible entre Noirmoutier et le continent.",
            "Nintendo.",
            "De la crème fraîche - Cette base s'appelle une migraine.",
            "Le Comité international olympique.",
            "Faux - C'est le gin.",
            "Une danse fitness.",
            "Faux - C'est le \"diamant\".",
            "Faux - Il est obtenu à partir d'algues.",
            "Une flash mob.",
            "La samba - C'est une danse populaire brésilienne.",
            "L'équipe d'Auxerre.",
            "Blanche et rouge.",
            "Faux - C'est une infusion issue d'une plante indienne.",
            "Sur 100 mètres.",
            "La brasse.",
            "L'équipe écossaise."};
            string bonneReponse = repSportLoisirs[numQuestRep];

            /* Ici nous lisons la réponse du joueur, donnons la réponse correcte et nous vérifions si le joueur a juste grâce à une méthode.*/
            Console.WriteLine("\n" + question);
            string reponse = Console.ReadLine();
            Console.WriteLine("\nLe joueur " + numJoueur + " a donné la réponse suivante : " + reponse + ".");
            Console.WriteLine("La bonne réponse était : " + bonneReponse);
            testReponse(numJoueur, "Sports et loisirs", scorePartie);
        }

        /*Cette méthode vérifie si la réponse du joueur est juste pour n'importe quelle catégorie.*/
        static void testReponse(int numJoueur, string categorie, List<int[]> scorePartie)
        {
            /*Nous récupérons ici si la réponse est Vrai ou Fausse. */
            Console.WriteLine("\n\tSa réponse est-elle juste ? Rentrez Vrai si oui, Faux sinon.");
            string justeFaux = Console.ReadLine();
            while (justeFaux != "Vrai")
            {
                if (justeFaux == "Faux")
                {
                    break;
                }
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine("Erreur : Rentrez Vrai ou Faux (avec une majuscule au début).");
                justeFaux = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }

            /* Ici nous ajoutons les points au tableau des scores si la réponse est juste et que le joueur n'a pas déjà un point dans cette catégorie.*/
            int indJoueur = numJoueur - 1;
            if (justeFaux == "Vrai")
            {
                Console.WriteLine("\nBien joué joueur " + numJoueur + ", vous avez donné la bonne réponse.");

                string[] tableauCategorie = new string[] { "Histoire", "Géographie", "Divertissement", "Arts et Littérature", "SVT", "Sports et loisirs" };
                int positionQuestion = 0;
                for (int i = 0; i < 6; i++)
                {
                    if (categorie == tableauCategorie[i])
                    {
                        positionQuestion = i;
                    }
                }

                int score = scorePartie[indJoueur][positionQuestion];
                if (score == 0)
                {
                    scorePartie[indJoueur][positionQuestion] = 1;
                    Console.WriteLine("Vous avez un point en " + tableauCategorie[positionQuestion]);
                }
                else
                {
                    Console.WriteLine("\nDommage joueur " + numJoueur + ", vous aviez déjà un point dans cette catégorie.");
                }
            }
            else
            {
                Console.WriteLine("\nDomage joueur " + numJoueur + ", vous y arriverez la prochaine fois :)");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nAppuyez sur la touche entrée pour continuer.");
            Console.ReadKey();
        }

        /* Cette méthode permet d'afficher un tableau des scores.*/
        static void affichageScore(List<int[]> scorePartie, int nbrJoueurs)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\n\nTableau des scores :                                                                          ");
            Console.WriteLine(" ____________________________________________________________________________________________ ");
            Console.WriteLine("|  Joueur  |  Histoire  |  Géographie  | Divertissement |   Arts et    |   SVT   |  Sports   |");
            Console.WriteLine("|          |            |              |                | Littérature  |         | et loisirs|");
            Console.WriteLine("|__________|____________|______________|________________|______________|_________|___________|");
            for (int i = 0; i < nbrJoueurs; i++)
            {
                int numJoueur = i + 1;
                Console.WriteLine("| Joueur " + numJoueur + " |      " + scorePartie[i][0] + "     |      " + scorePartie[i][1] + "       |        " + scorePartie[i][2] + "       |       " + scorePartie[i][3] + "      |    " + scorePartie[i][4] + "    |     " + scorePartie[i][5] + "     |");
                Console.WriteLine("|__________|____________|______________|________________|______________|_________|___________|");
                Console.WriteLine("                                                                                              ");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}