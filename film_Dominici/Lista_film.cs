using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Text;
using static System.Console;
using System.Threading.Tasks;

namespace film_Dominici
{
    class Program
    {
        static void Main(string[] args)
        {
            bool stop = false;
            XmlDocument film = null;
            XmlElement catalog = null;
            XmlNodeList films = null;
            
            while (!stop)
            {
                
                Console.ForegroundColor = ConsoleColor.Green;
                WriteLine("MENU PRINCIPALE-[DOMINICI DISTRIBUATION]\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                WriteLine("1. Caricamento della lista dei Blockbuster.");
                Console.ForegroundColor = ConsoleColor.White;
                WriteLine("2. Visualizzazione dei Blockbuster.");
                WriteLine("3. Quanti film abbiamo in negozio?");
                WriteLine("4. C'è un errore nella lista? Modificala!");
                WriteLine("5. Salva le modifiche apportate.");
                WriteLine("6. Ricerca un film tramite l'anno! ");
                Console.ForegroundColor = ConsoleColor.Red;
                WriteLine("7. Esci dal menù");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Write("\nOPZIONE: ");
                string opz = ReadLine();
                Clear();
                switch (opz)
                {

                    case "1":
                        //carica il documento
                        film = new XmlDocument();
                        film.Load("film.xml");
                        catalog = film.DocumentElement;
                        films = catalog.ChildNodes;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        WriteLine("Documento caricato con successo!\npremere INVIO per tornare al Menù");
                        ReadLine();
                        Clear();
                        break;
                    case "2":
                       
                        if (film == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            WriteLine("Documento non ancora caricato... Premere 1");
                            WriteLine(new string('_', Console.BufferWidth));
                        }
                        else
                        {
                           
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            WriteLine("LISTA FILM:\n");
                            foreach (XmlNode element in films)
                            {
                                //metodi per la lista dei film che cambiano per malmkrog e soul che hanno una impostazione delle posizioni differente
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                XmlNodeList elementi = element.ChildNodes;
                                if (elementi[0].InnerText == "Soul") 
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    WriteLine($"Titolo del Film: {elementi[0].InnerText}");
                                    
                                    WriteLine($"Regista del Film: {elementi[1].InnerText}");
                                    WriteLine($"Altro Regista del Film: {elementi[2].InnerText}");
                                    WriteLine($"Anno del Film: {elementi[3].InnerText}");
                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                    WriteLine(new string('_', Console.BufferWidth));
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                }
                                else
                                {
                                    WriteLine($"Titolo del Film: {elementi[0].InnerText}");
                                    WriteLine($"Regista del Film: {elementi[1].InnerText}");
                                    WriteLine($"Anno del Film: {elementi[2].InnerText}");
                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                    WriteLine(new string('_', Console.BufferWidth));
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                }
                                if (elementi[0].InnerText == "Malmkrog")
                                {
                                    WriteLine($"Titolo del Film: {elementi[0].InnerText}");
                                    WriteLine($"Regista del Film: {elementi[1].InnerText}");
                                    WriteLine($"Anno del Film: {elementi[2].InnerText}");
                                    WriteLine($"Nazionalità del Film: {elementi[4].InnerText}");
                                    WriteLine($"Co-Nazionalità del Film: {elementi[5].InnerText}");
                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                    WriteLine(new string('_', Console.BufferWidth));
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                }

                                
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        WriteLine("\nPremere INVIO per tornare al menu");
                        ReadLine();
                        Clear();
                        break;
                    case "3":
                        if (film == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            WriteLine("Documento non ancora caricato... Premere 1");
                            WriteLine(new string('_', Console.BufferWidth));
                        }
                        else
                        {
                            //grazie al metodo count in childnodes vedo quanti nodi ci sono
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            int filmtot = catalog.ChildNodes.Count;
                            WriteLine($"\nIl negozio ha a disposizione {filmtot} film");
                            WriteLine(new string('_', Console.BufferWidth));
                        }
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        WriteLine("\nPremere INVIO per tornare al menu");
                        ReadLine();
                        Clear();
                        break;
                    case "4":
                        if (film == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            WriteLine("Documento non ancora caricato... Premere 1");
                        }


                        WriteLine("inserisci il nome del film");
                        string titoloFilm = ReadLine();
                        WriteLine("inserisci il nuovo anno");
                        string newYear = ReadLine();
                       
                        //tramite le posizione e il metodo inner text si controllano il titolo e si cambia l'anno
                        foreach (XmlNode elements in films)
                        {
                            XmlNodeList elementi = elements.ChildNodes;
                            if (elementi[0].InnerText == titoloFilm)
                            {
                                elementi[2].InnerText = newYear;

                            }
                        }
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        WriteLine("Ricordati di salvare premendo 5!\n");

                        break;
                    case "5":
                        if (film == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            WriteLine("Documento non ancora caricato... Premere 1");
                        }
                        else
                        {
                            //metodo per salvare il file post modifiche
                            film.Save(@"C:\Users\alessandro.dominici\Desktop\film_Dominici\film_Dominici\bin\Debug\film.xml");
                            Console.ForegroundColor = ConsoleColor.Green;
                            WriteLine("Documento salvato con Successo!");
                        }

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        WriteLine("\nPremere INVIO per tornare al menu");
                        ReadLine();
                        Clear();
                        break;
                    case "6":
                        //pattern per controllare se il documento è inserito
                        if (film == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            WriteLine("Documento non ancora caricato... Premere 1");
                        }

                        WriteLine("inserisci l'anno dei film");
                        string yearFilms = ReadLine();
                        //Ad esclusione se in un anno non esistono film non te li visualizza
                        if (yearFilms != "2019" && yearFilms != "2021" && yearFilms != "2020")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            WriteLine("In quel anno non abbiamo film in elenco!");
                        }
                        //grazie al foreach si vede se l'anno è uguale a quello richiesto, per il caso di soul metto la terza posizione
                        foreach (XmlNode anni in films)
                        {
                            XmlNodeList listaAnni = anni.ChildNodes;
                            if (listaAnni[2].InnerText == yearFilms || listaAnni[3].InnerText == yearFilms)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                WriteLine($"Lista dei film usciti nel {yearFilms} sono: {listaAnni[0].InnerText}");
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        WriteLine("\nPremere INVIO per tornare al menu");
                        ReadLine();
                        Clear();
                        break;
                    case "7":
                        //uscire dal menu
                        stop = true;

                        break;
                    default:
                        WriteLine("OPZIONE NON VALIDA...");
                        break;
                }
            }
        }
    }
}
