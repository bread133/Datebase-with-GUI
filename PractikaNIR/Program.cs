using PractikaNIR.Generators;
using PractikaNIR.Models;
using PractikaNIR.MySQL;

//ExhibitDb.DropTable(Connector.FileSettingsSandox);
//ArtistDb.DropTable(Connector.FileSettingsSandox);
//CollectionDb.DropTable(Connector.FileSettingsSandox);
//ExhibitionDb.DropTable(Connector.FileSettingsSandox);

//ExhibitionDb.CreateTable(Connector.FileSettingsSandox);
//CollectionDb.CreateTable(Connector.FileSettingsSandox);
//ArtistDb.CreateTable(Connector.FileSettingsSandox);
//ExhibitDb.CreateTable(Connector.FileSettingsSandox);

//ArtistDb.InsertItems(Connector.FileSettingsSandox, artists);
//ExhibitionDb.InsertItems(Connector.FileSettingsSandox, exhibitions);
//CollectionDb.InsertItems(Connector.FileSettingsSandox, collections);
//ExhibitDb.InsertItems(Connector.FileSettingsSandox, exhibits);
int nOfArtist = 0;
int nOfExhibition = 0;
int nOfCollection = 0;
List<Artist> artists = new();

bool programBegin = true;
while (programBegin)
{
    Console.WriteLine("Что вы хотите сделать?\n" +
        "1. Создать таблицы в базе данных песочницы\n" +
        "2. Сгенерировать данные в таблицах\n" +
        "3. Удалить данные из таблиц\n" +
        "4. Создать бекап\n" +
        "5. Удалить все таблицы\n" +
        "6. Перенести весь прогресс в базу данных галереи");
    int answer = Convert.ToInt32(Console.ReadLine());
    switch (answer)
    {
        case 1:
            ExhibitionDb.CreateTable(Connector.FileSettingsSandox);
            CollectionDb.CreateTable(Connector.FileSettingsSandox);
            ArtistDb.CreateTable(Connector.FileSettingsSandox);
            ExhibitDb.CreateTable(Connector.FileSettingsSandox);
            break;
        case 2:
            Console.WriteLine("Где вы хотите сгенерировать данные?\n" +
                "1. Таблица художников\n" +
                "2. Таблица выставок\n" +
                "3. Таблица коллекций картин\n" +
                "4. Таблица картин\n");
            int generationDataTableAnswer = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Сколько элементов вы хотите сгенерировать?");
            int numberOfItem = Convert.ToInt32(Console.ReadLine());
            while(numberOfItem < 1) 
            {
                Console.WriteLine("Неправильно введен параметр. " +
                    "В таблице может быть только положительное количество элементов." +
                    "Попробуйте еще раз.");
                numberOfItem = Convert.ToInt32(Console.ReadLine());
            }

            switch (generationDataTableAnswer)
            {
                case 1:
                    for(int i = 0; i < numberOfItem; i++)
                    {
                        Artist artist = new();
                        artist.Generate();
                        artists.Add(artist);
                    }
                    ArtistDb.InsertItems(Connector.FileSettingsSandox, artists);
                    nOfArtist += numberOfItem;
                    break;
                case 2:
                    List<Exhibition> exhibitions = new();
                    for (int i = 0; i <= numberOfItem; i++)
                    {
                        Exhibition exhibition = new(2023, 2025);
                        exhibition.Generate();
                        exhibitions.Add(exhibition);
                    }
                    ExhibitionDb.InsertItems(Connector.FileSettingsSandox, exhibitions);
                    nOfExhibition += numberOfItem;
                    break;
                case 3:
                    List<Collection> collections = new();
                    for (int i = 0; i < numberOfItem; i++)
                    {
                        Collection collection = new(nOfExhibition);
                        collection.Generate();
                        collections.Add(collection);
                    }
                    CollectionDb.InsertItems(Connector.FileSettingsSandox, collections);
                    nOfCollection += numberOfItem;
                    break;
                case 4:
                    List<Exhibit> exhibits = new();
                    for (int i = 0; i < numberOfItem; i++)
                    {
                        int key = new Random().Next(0, nOfArtist);
                        Exhibit exhibit = new(nOfCollection, artists[key], key + 1);
                        exhibit.Generate();
                        exhibits.Add(exhibit);
                    }
                    ExhibitDb.InsertItems(Connector.FileSettingsSandox, exhibits);
                    break;
                default:
                    Console.WriteLine("Значение выходит за пределы обозначенных значений. Попробуйте еще раз.");
                    continue;
            }
            break;
        case 3:
            Console.WriteLine("Где вы хотите удалить данные?\n" +
                "1. Таблица художников\n" +
                "2. Таблица выставок\n" +
                "3. Таблица коллекций картин\n" +
                "4. Таблица картин\n");
            int deleteDataTableAnswer = Convert.ToInt32(Console.ReadLine());
            switch (deleteDataTableAnswer)
            {
                case 1:
                    ArtistDb.DeleteItems(Connector.FileSettingsSandox);
                    nOfArtist = 0;
                    artists.Clear();
                    break;
                case 2:
                    ExhibitionDb.DeleteItems(Connector.FileSettingsSandox);
                    nOfExhibition = 0;
                    break;
                case 3:
                    CollectionDb.DeleteItems(Connector.FileSettingsSandox);
                    nOfCollection = 0;
                    break;
                case 4:
                    ExhibitDb.DeleteItems(Connector.FileSettingsSandox);
                    break;
                default:
                    Console.WriteLine("Значение выходит за пределы обозначенных значений. Попробуйте еще раз.");
                    continue;
            }
            break;
        case 4:

    }

}