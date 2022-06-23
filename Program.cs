//Valeur Booléenne qui servira à definir la fin du programme
bool Continuer = true;
while (Continuer == true)
{
    //Enoncé affiché
    Console.WriteLine("Bonjour, veuillez entrer une liste de nombre entre -1000 et 1000. Veillez à séparer vos nombres par des virgules !\n" +
        "si le nombre est divisible par 3 : on affiche Geste,\n" +
        "si le nombre est divisible par 5 : on affiche Forme,\n" +
        "si le nombre est divisible par 3 et par 5 : on affiche Gestform\n" +
        "sinon: on affiche le nombre n\n\n" +
        "Saisissez votre liste :");
    //Saisie de la liste de nombre
    string ListNombreString = Console.ReadLine();
    //Verification de la conformité de la liste
    if (!string.IsNullOrEmpty(ListNombreString))
    {
        //Recuperation des valeurs entre les virgules dans une liste d'entier, les valeurs qui ne sont pas de type int ne sont pas recuperées
        int nombre;
        var ListNombreInt = ListNombreString.Split(',')
                    .Where(m => int.TryParse(m, out nombre))
                    .Select(m => int.Parse(m))
                    .ToList();
        //On verifie si un ou plusieurs nombre ont été trouvé dans la liste saisie
        if (ListNombreInt.Count > 0)
        {
            //On verifie s'il y a un nombre inferieur à -1000 ou superieur à 1000
            //ListNombreASupprimer est une liste de int qui va permettre de stocker les nombres ne correspondant pas au critere,
            //et les supprimer apres la verification pour ne pas modifier ListNombreInt pendant la boucle
            List<int> ListNombreASupprimer = new List<int>();
            foreach (int NombreInt in ListNombreInt)
            {
                if (NombreInt > 1000 || NombreInt<-1000)
                {
                    ListNombreASupprimer.Add(NombreInt);
                }
            }
            //On supprime les nombres qui ne sont pas dans [-1000;1000]
            if (ListNombreASupprimer.Count!=0)
            {
                Console.WriteLine("\nUn ou plusieurs nombre ne correspondaient pas au critère : nombre entre -1000 et 1000\n" +
                    "Ils ont donc été supprimés");
                foreach (int NombreInt in ListNombreASupprimer)
                {
                    ListNombreInt.Remove(NombreInt);
                }
            }
            //On verifie si des nombres sont toujours présent dans la liste
            if(ListNombreInt.Count > 0)
            {
                //Affichage de la liste finale des nombres saisis répondant à tous les critères
                string NombreString = "";
                Console.WriteLine("\nVoici la liste finale des nombres saisis:\n");
                foreach (int NombreInt in ListNombreInt)
                {
                    NombreString += NombreInt + " ";
                }
                Console.WriteLine(NombreString + "\n");
                //Debut du traitement des nombres de la liste
                Console.WriteLine("Debut du traitement des nombres de la liste :");
                //Centralisation des valeurs à afficher (En cas de changement d'affichage on aura juste à modifier ici)
                string NombreDiv3 = "Geste";
                string NombreDiv5 = "Forme";
                string NombreDiv3et5 = "Gestform";
                foreach (int NombreInt in ListNombreInt)
                {
                    if (NombreInt % 3 == 0 && NombreInt % 5 == 0)
                    {
                        Console.WriteLine(NombreInt + ": " + NombreDiv3et5);

                    }
                    else
                    {
                        if (NombreInt % 3 == 0)
                        {
                            Console.WriteLine(NombreInt + ": " + NombreDiv3);
                        }
                        else
                        {
                            if (NombreInt % 5 == 0)
                            {
                                Console.WriteLine(NombreInt + ": " + NombreDiv5 );
                            }
                            else
                            {
                                Console.WriteLine(NombreInt + ": " + NombreInt );
                            }
                        }
                    }

                }
                Console.WriteLine("Fin du traitement de la liste\n");
                bool resultatCorrect = false;
                while (resultatCorrect == false)
                {
                    Console.WriteLine("Voulez-vous recommencer un nouveau traitement ? (O/o pour oui, N/n pour non)\n");
                    string resultat = Console.ReadLine();
                    if (resultat != "O" && resultat != "o" && resultat != "N" && resultat != "n")
                    {
                        Console.WriteLine("\nValeur saisie incorrecte !\n");
                    }
                    else
                    {
                        if (resultat == "N" || resultat == "n")
                        {
                            Continuer=false;
                            resultatCorrect = true;
                            Console.WriteLine("Fin du programme !");
                        }
                        else
                        {
                            resultatCorrect = true;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("\nAprès suppression des nombres incorrect, plus aucun nombre n'est présent dans la liste.\nVeuillez rentrer une nouvelle liste!\n");
                Console.WriteLine("Rappel de la consigne: ");
            }

        }
        else
        {
            Console.WriteLine("\nVotre liste ne contient aucun nombre ou n'est pas séparée par des virgules !\n");
            Console.WriteLine("Rappel de la consigne: ");

        }

    }
    else
    {
        Console.WriteLine("Vous n'avez écrit aucun nombre !\n");
        Console.WriteLine("Rappel de la consigne: ");

    }
}