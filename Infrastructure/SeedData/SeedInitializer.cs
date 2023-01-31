using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SeedData;

public class SeedInitializer
{
    public static void ContextSeed(ModelBuilder modelBuilder)
    {
                    modelBuilder.Entity<MovieCountry>().HasData(
                new MovieCountry()
                {
                    Id = 1, Name = "France"
                },
                new MovieCountry()
                {
                    Id = 2, Name = "Italy"
                },
                new MovieCountry()
                {
                    Id = 3, Name = "USA"
                },
                new MovieCountry()
                {
                    Id = 4, Name = "USSR/Russia"
                }
            );

            modelBuilder.Entity<MovieGenre>().HasData(
                new MovieGenre()
                {
                    Id = 1, Name = "Drama"
                },
                new MovieGenre()
                {
                    Id = 2, Name = "Sci-Fi"
                },
                new MovieGenre()
                {
                    Id = 3, Name = "Action"
                },
                new MovieGenre()
                {
                    Id = 4, Name = "Comedy"
                }
            );

            modelBuilder.Entity<Movie>().HasData(
                new Movie()
                {
                    Id = 1, Title = "La dolce vita",
                    Description =
                        "In 1959/1960 Rome, Marcello Rubini (Marcello Mastroianni) is a writer and journalist, the worst kind of journalist--a tabloid journalist. His job is to try to catch celebrities in compromising or embarrassing situations. He tends to get quite close to his subjects--especially when they're beautiful women. Two such subjects are local heiress Maddalena (Anouk Aimee), and Swedish superstar-actress Sylvia (Anita Ekberg), with both of whom he has affairs despite being engaged to Emma (Yvonne Furneaux), a clingy, insecure, nagging, melodramatic woman. Despite his extravagant, pleasure-filled lifestyle, he is wondering if maybe a simpler life wouldn't be better.",
                    Year = 1960, Director = "Federico Fellini", RuntimeHours = 2.54, PictureUrl = "images/movies/movie1.jpg", MovieGenreId = 4,
                    MovieCountryId = 2
                },
                new Movie()
                {
                    Id = 2, Title = "Le Samouraï",
                    Description =
                        "In Paris, Jef Costello is a lonely hit man who works under contract. He is hired to kill the owner of a club and becomes the prime suspect of the murder. However, his perfect alibi drops the accusation against him. His girlfriend Jane, her client and citizen above any suspicion Wiener and Valerie, the pianist of the club and main witness of the crime, provide the necessary evidence of his innocence supporting his alibi. Free, he is betrayed and chased by the gangsters sent by the one who hired him and also by the police, not convinced of his innocence. Jef seeks out who has hired him to revenge.",
                    Year = 1967, Director = "Jean-Pierre Melville", RuntimeHours = 1.45, PictureUrl = "images/movies/movie2.jpg", MovieGenreId = 1,
                    MovieCountryId = 1
                },
                new Movie()
                {
                    Id = 3, Title = "Blade Runner",
                    Description =
                        "In the early twenty-first century, the Tyrell Corporation, during what was called the Nexus phase, developed robots, called replicants, that were supposed to aid society, the replicants which looked and acted like humans. When the superhuman generation Nexus 6 replicants, used for dangerous off-Earth endeavors, began a mutiny on an off-Earth colony, replicants became illegal on Earth. Police units, called blade runners, have the job of destroying - or in their parlance retiring - any replicant that makes its way back to or created on Earth, with anyone convicted of aiding or assisting a replicant being sentenced to death. It's now November, 2019 in Los Angeles, California. Rick Deckard, a former blade runner, is called out of retirement when four known replicants, most combat models, have made their way back to Earth, with their leader being Roy Batty. One, Leon Kowalski, tried to infiltrate his way into the Tyrell Corporation as an employee, but has since been able to escape. Beyond following Leon's trail in hopes of finding and retiring them all, Deckard believes part of what will help him is figuring out what the replicants wanted with the Tyrell Corporation in trying to infiltrate it. The answer may lie with Tyrell's fail-safe backup mechanism. Beyond tracking the four, Deckard faces a possible dilemma in encountering a fifth replicant: Rachael, who works as Tyrell's assistant. The issue is that Dr. Elden Tyrell is experimenting with her, to provide her with fake memories so as to be able to better control her. With those memories, Rachael has no idea that she is not human. The problem is not only Rachael's assistance to Deckard, but that he is beginning to develop feelings for her.",
                    Year = 1982, Director = "Ridley Scott", RuntimeHours = 1.57, PictureUrl = "images/movies/movie3.jpg", MovieGenreId = 2,
                    MovieCountryId = 3
                },
                new Movie()
                {
                    Id = 4, Title = "Come and See",
                    Description =
                        "The feature film directed by Elem Klimov, shot in the genre of military drama. The action takes place on the territory of Belarus in 1943. In the center of the story is a Belarusian boy, who witnesses the horrors of the Nazi punitive action, turning from a cheerful teenager into a gray-haired old man for two days.",
                    Year = 1985, Director = "Elem Klimov", RuntimeHours = 2.22, PictureUrl = "images/movies/movie4.jpg", MovieGenreId = 1,
                    MovieCountryId = 4
                }
            );
    }
}