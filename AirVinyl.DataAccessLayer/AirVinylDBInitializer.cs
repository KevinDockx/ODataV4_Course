using AirVinyl.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace AirVinyl.DataAccessLayer
{

    // Note: to avoid recreation of the DB, use DropCreateDatabaseIfModelChanges<AirVinylDbContext>  
    public class AirVinylDBInitializer : DropCreateDatabaseAlways<AirVinylDbContext> 
    {
        protected override void Seed(AirVinylDbContext context)
        {
            // PressingDetail 
            var pressingDetailAudiophileLP = new PressingDetail()
            {
                Description = "Audiophile LP",
                Grams = 180,
                Inches = 12
            };

            var pressingDetailRegularLP = new PressingDetail()
            {
                Description = "Regular LP",
                Grams = 140,
                Inches = 12
            };

            var pressingDetailAudiophileSingle = new PressingDetail()
            {
                Description = "Audiophile Single",
                Grams = 50,
                Inches = 7
            };

            var pressingDetailRegularSingle = new PressingDetail()
            {
                Description = "Regular Single",
                Grams = 40,
                Inches = 7
            };

            context.PressingDetails.Add(pressingDetailAudiophileLP);
            context.PressingDetails.Add(pressingDetailRegularLP);
            context.PressingDetails.Add(pressingDetailAudiophileSingle);
            context.PressingDetails.Add(pressingDetailRegularSingle);

            // Person
            var personKevin = new Person()
            {
                DateOfBirth = new DateTimeOffset(new DateTime(1981, 5, 5)),
                Email = "kevin@kevindockx.com",
                FirstName = "Kevin",
                LastName = "Dockx",
                Gender = Gender.Male,
                NumberOfRecordsOnWishList = 10,
                AmountOfCashToSpend = 300
            };

            var personSven = new Person()
            {
                DateOfBirth = new DateTimeOffset(new DateTime(1986, 3, 6)),
                Email = "sven@someemailprovider.com",
                FirstName = "Sven",
                LastName = "Vercauteren",
                Gender = Gender.Male,
                NumberOfRecordsOnWishList = 34,
                AmountOfCashToSpend = 2000
            };

            var personNils = new Person()
            {
                DateOfBirth = new DateTimeOffset(new DateTime(1983, 5, 18)),
                Email = "nils@someemailprovider.com",
                FirstName = "Nils",
                LastName = "Missorten",
                Gender = Gender.Male,
                NumberOfRecordsOnWishList = 23,
                AmountOfCashToSpend = 2500
            };

            var personBob = new Person()
            {
                DateOfBirth = new DateTimeOffset(new DateTime(1981, 10, 25)),
                Email = "bob@someemailprovider.com",
                FirstName = "Bob",
                LastName = "Vervloet",
                Gender = Gender.Male,
                NumberOfRecordsOnWishList = 50,
                AmountOfCashToSpend = 200
            };

            var personTim = new Person()
            {
                DateOfBirth = new DateTimeOffset(new DateTime(1981, 10, 15)),
                Email = "tim@someemailprovider.com",
                FirstName = "Tim",
                LastName = "Van den Broeck",
                Gender = Gender.Male,
                NumberOfRecordsOnWishList = 19,
                AmountOfCashToSpend = 90
            };

            var personNele = new Person()
            {
                DateOfBirth = new DateTimeOffset(new DateTime(1977, 12, 27)),
                Email = "nele@someemailprovider.com",
                FirstName = "Nele",
                LastName = "Verheyen",
                Gender = Gender.Female,
                NumberOfRecordsOnWishList = 120,
                AmountOfCashToSpend = 100
            };

            var personKenneth = new Person()
            {
                DateOfBirth = new DateTimeOffset(new DateTime(1981, 1, 16)),
                Email = null,
                FirstName = "Kenneth",
                LastName = "Mills",
                Gender = Gender.Male,
                NumberOfRecordsOnWishList = 98,
                AmountOfCashToSpend = 200
            };


            // Add friends & records for Kevin
            personKevin.Friends = new List<Person>()
            {
                personSven, personNils, personTim
            };
            personKevin.VinylRecords = new List<VinylRecord>()
            {
                new VinylRecord()
                {
                    Artist = "Nirvana",
                    Title = "Nevermind",
                    CatalogNumber = "ABC/111",
                    PressingDetail = pressingDetailAudiophileLP,
                    Year= 1991
                },
                new VinylRecord()
                {
                    Artist = "Arctic Monkeys",
                    Title = "AM",
                    CatalogNumber = "EUI/111",
                    PressingDetail = pressingDetailAudiophileLP,
                    Year = 2013
                },
                new VinylRecord()
                {
                    Artist = "Beatles",
                    Title = "The White Album",
                    CatalogNumber = "DEI/113",
                    PressingDetail = pressingDetailRegularLP,
                    Year = 1968
                },
                new VinylRecord()
                {
                    Artist = "Beatles",
                    Title = "Sergeant Pepper's Lonely Hearts Club Band",
                    CatalogNumber = "DPI/123",
                    PressingDetail = pressingDetailRegularLP,
                    Year = 1967
                },
                new VinylRecord()
                {
                    Artist = "Nirvana",
                    Title = "Bleach",
                    CatalogNumber = "DPI/123",
                    PressingDetail = pressingDetailRegularLP,
                    Year = 1989
                },
                new VinylRecord()
                {
                    Artist = "Leonard Cohen",
                    Title = "Suzanne",
                    CatalogNumber = "PPP/783",
                    PressingDetail = pressingDetailRegularSingle,
                    Year = 1967
                },
                new VinylRecord()
                {
                    Artist = "Marvin Gaye",
                    Title = "What's Going On",
                    CatalogNumber = "MVG/445",
                    PressingDetail = pressingDetailRegularLP,
                    Year = null
                },
            };

            // get Sven, add friends & records
            personSven.Friends = new List<Person>()
            {
                personKevin, personNils, personTim, personNele
            };
            personSven.VinylRecords = new List<VinylRecord>()
            {
                new VinylRecord()
                {
                    Artist = "Nirvana",
                    Title = "Nevermind",
                    CatalogNumber = "ABC/111",
                    PressingDetail = pressingDetailAudiophileLP,
                    Year = 1991
                },
                new VinylRecord()
                {
                    Artist = "Cher",
                    Title = "Closer to the Truth",
                    CatalogNumber = "CHE/190",
                    PressingDetail = pressingDetailRegularLP,
                    Year = 2013
                }
             };

            // get Nils, add friends & records
            personNils.Friends = new List<Person>()
            {
                personSven, personKevin, personBob, personKenneth
            };
            personNils.VinylRecords = new List<VinylRecord>()
            {
                new VinylRecord()
                {
                    Artist = "Justin Bieber",
                    Title = "Baby",
                    CatalogNumber = "OOP/098",
                    PressingDetail = pressingDetailAudiophileSingle
                },
                new VinylRecord()
                {
                    Artist = "The Prodigy",
                    Title = "Music for the Jilted Generation",
                    CatalogNumber = "NBE/864",
                    PressingDetail = pressingDetailRegularLP
                }
             };

            // get Bob, add records
            personBob.VinylRecords = new List<VinylRecord>()
            {
                new VinylRecord()
                {
                    Artist = "Arctic Monkeys",
                    Title = "Favourite Worst Nightmare",
                    CatalogNumber = "IOC/113",
                    PressingDetail = pressingDetailAudiophileLP
                }
            };


            // get Tim, add friends & records
            personTim.Friends = new List<Person>()
            {
                personNele, personKenneth, personNils
            };
            personTim.VinylRecords = new List<VinylRecord>()
            {
                new VinylRecord()
                {
                    Artist = "Anne Clarke",
                    Title = "Our Darkness",
                    CatalogNumber = "TII/339",
                    PressingDetail = pressingDetailAudiophileSingle
                },
                new VinylRecord()
                {
                    Artist = "Dead Kennedys",
                    Title = "Give Me Convenience or Give Me Death",
                    CatalogNumber = "DKE/864",
                    PressingDetail = pressingDetailRegularLP
                },
                new VinylRecord()
                {
                    Artist = "Sisters of Mercy",
                    Title = "Temple of Love",
                    CatalogNumber = "IIE/824",
                    PressingDetail = pressingDetailRegularSingle
                }
             };

            // get Nele, add friends & records
            personNele.Friends = new List<Person>()
            {
                personTim, personKenneth, personSven
            };
            personNele.VinylRecords = new List<VinylRecord>()
            {
                new VinylRecord()
                {
                    Artist = "The Dandy Warhols",
                    Title = "Thirteen Tales From Urban Bohemia",
                    CatalogNumber = "TDW/516",
                    PressingDetail = pressingDetailRegularLP
                }
             };

            // get Kenneth, add friends & records
            personKenneth.Friends = new List<Person>()
            {
                personTim, personKevin, personSven
            };
            personKenneth.VinylRecords = new List<VinylRecord>()
            {
                new VinylRecord()
                {
                    Artist = "Abba",
                    Title = "Gimme Gimme Gimme",
                    CatalogNumber = "TDW/516",
                    PressingDetail = pressingDetailRegularSingle
                }
             };

            context.People.Add(personKevin);
            context.People.Add(personSven);
            context.People.Add(personKenneth);
            context.People.Add(personBob);
            context.People.Add(personNele);
            context.People.Add(personNils);

            context.People.Add(personTim);

            // RecordStore
            var recordStores = new List<RecordStore>()
            {
                new SpecializedRecordStore()
                {
                    Name = "Indie Records, Inc",
                    StoreAddress = new Address()
                    {
                        City = "Antwerp",
                        PostalCode = "2000",
                        Street = "1, Main Street",
                        Country = "Belgium"
                    },
                    Tags = new List<string>() {"Rock", "Indie", "Alternative"},
                    Ratings = new List<Rating>()
                    {
                        new Rating() {
                            RatedBy = personKevin,
                            Value = 5
                        },
                        new Rating() {
                            RatedBy = personSven,
                            Value = 4
                        }
                    },
                    Specialization = "Indie"
                },
                 new SpecializedRecordStore()
                {
                    Name = "Rock Records, Inc",
                    StoreAddress = new Address()
                    {
                        City = "Antwerp",
                        PostalCode = "2000",
                        Street = "5, Big Street",
                        Country = "Belgium"
                    },
                    Tags = new List<string>() {"Rock", "Pop"},
                    Ratings = new List<Rating>()
                    {
                        new Rating() {
                            RatedBy = personKevin,
                            Value = 5
                        },
                        new Rating() {
                            RatedBy = personSven,
                            Value = 4
                        }
                    },
                    Specialization = "Rock"
                },
                new RecordStore()
                {
                    Name = "All Your Music Needs",
                    StoreAddress = new Address()
                    {
                        City = "Antwerp",
                        PostalCode = "2000",
                        Street = "25, Fluffy Road",
                        Country = "Belgium"
                    },
                    Tags = new List<string>() {"Rock", "Pop", "Indie", "Alternative" },
                    Ratings = new List<Rating>()
                    {
                        new Rating() {
                            RatedBy = personKevin,
                            Value = 4
                        },
                        new Rating() {
                            RatedBy = personSven,
                            Value = 4
                        },
                        new Rating() {
                            RatedBy = personNele,
                            Value = 4
                        }
                    }
                }
            };

            context.RecordStores.AddRange(recordStores);

            base.Seed(context);
        }
    }
}
