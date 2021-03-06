﻿using AudioPlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Audioplayer
{
    [Flags] 
    public enum Genres 
    { 
        Pop = 1, Rock = 2, Metal = 4, Electro = 8  
    }
    public enum Videoformate
    {
        HD =1, MPEG =2
    }
    class Program
    {

        
        static void Main(string[] args)
        {
            ColorSkin ColorSkn = new ColorSkin(ConsoleColor.DarkYellow); 
            ClassicSkin ClassicSkn = new ClassicSkin();  
            Player player = new Player(ColorSkn); 
            player.Items = new  List<Song>(); 
            for (int i = 0; i < 25; i++) 
            {
                player.Items.Add(new Song { Title = i + "sssssssssss", IsNext=false, Duration = 540, Genre=Genres.Pop });

                if (i == 8 || i == 7 || i == 23 || i == 24) { player.Items[i].Genre = Genres.Rock | Genres.Pop; }
                if (i == 1 || i == 2 || i == 20 || i == 13) { player.Items[i].Genre = Genres.Rock | Genres.Pop | Genres.Electro; }
                if (i == 3 || i == 5 || i == 15 || i == 22) { player.Items[i].Genre = Genres.Rock | Genres.Metal; }

                if (i == 3 || i == 7 || i == 23) { player.Items[i].LikeMethod(); }  
                if (i == 5 || i == 8 || i == 22 || i == 21) { player.Items[i].DislikeMethod(); } 
            }
            Genres testfilter = Genres.Rock | Genres.Pop; 
            List<Song> ListAfterFilter = player.FilterByGenres(player.Items, testfilter); 
            player.ListItem(ListAfterFilter); 
           
            WriteLine("Now we try to use your keyboard");

            
            while (true)
            {
                switch (ReadLine())
                {
                    case "a":
                        {
                            player.VolumeUp();
                            break;
                        }
                    case "s":
                        {
                            player.VolumeDown();
                            break;
                        }
                    case "d":
                        {
                            player.Play();
                            break;
                        }
                    case "q":
                        {
                            player.Lock();
                            break;
                        }
                    case "w":
                        {
                            player.UnLock();
                            break;
                        }
                    case "e":
                        {
                            player.Start();
                            break;
                        }
                    case "r":
                        {
                            player.Stop();
                            break;
                        }

                }
            }



            ReadLine();
        }
    }
}