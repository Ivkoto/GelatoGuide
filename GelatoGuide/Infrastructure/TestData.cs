using GelatoGuide.Data.Models;
using System;
using System.Collections.Generic;

namespace GelatoGuide.Infrastructure
{
    public class TestData
    {
        public IEnumerable<Place> Places()
        {

            yield return new Place()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Gelato di Natura",
                Description =
                    "Място вдъхновено от обичта към добрата храна, уважение към себе си и безкомпромисност по отношение на високото качество и чистота на продуктите.",
                MainImageUrl =
                    "https://res.cloudinary.com/dmflbhinu/image/upload/v1627424468/GelatoGuide/GDNSof_vskst8.png",
                SinceYear = 2015,
                WebsiteLink = "https://www.facebook.com/Gelato-di-Natura-Sofia-346970619528312/?ref=page_internal",
                FacebookUrl = "https://www.facebook.com/Gelato-di-Natura-Sofia-346970619528312/?ref=page_internal",
                City = "Русе",
                Country = "България",
                Location = "42.69102786793613, 23.32575909830204",
                DateCreated = new DateTime(2021, 7, 18, 23, 55, 13)
            };

            yield return new Place()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "GELATO FABBRICA",
                Description =
                    "Gelato Fabbrica е сладък ресторант за италиански сладолед и вкусни сладкарски изкушения, които правим на място с много страст, желание, любов и труд!",
                MainImageUrl =
                    "https://res.cloudinary.com/dmflbhinu/image/upload/v1627424468/GelatoGuide/2021-01-13_jyfarw.png",
                SinceYear = 2019,
                WebsiteLink = "https://www.gelatofabbrica.com/bg",
                City = "София",
                Country = "България",
                Location = "42.69830560910363, 23.318543084810848",
                DateCreated = new DateTime(2021, 5, 5, 12, 03, 15)
            };

            yield return new Place()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Dolce Vita Gelato",
                Description =
                    "Dolce Vita Gelato е местенце на което може да намерите уникален, приготвен на място италиански сладолед!",
                MainImageUrl =
                    "https://res.cloudinary.com/dmflbhinu/image/upload/v1627592425/GelatoGuide/Dolce_Vita_Gelato_aaxdmd.jpg",
                SinceYear = 2006,
                WebsiteLink = "https://www.facebook.com/Dolce.Vita.Gelato.BG/",
                FacebookUrl = "https://www.facebook.com/Dolce.Vita.Gelato.BG/",
                City = "София",
                Country = "България",
                Location = "42.692332330695784, 23.324327081063817",
                DateCreated = new DateTime(2021, 7, 23, 11, 10, 45)
            };

            yield return new Place()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "GELATERIA VIVALDI",
                Description = "Authentic gelato ice cream with the most delicious flavors.",
                MainImageUrl =
                    "https://res.cloudinary.com/dmflbhinu/image/upload/v1627678515/GelatoGuide/20200907_175358_m3nknh.jpg",
                SinceYear = 2008,
                WebsiteLink = "https://www.facebook.com/gelateriavivaldi.eu/",
                FacebookUrl = "https://www.facebook.com/gelateriavivaldi.eu/",
                City = "София",
                Country = "България",
                Location = "42.68720493140862, 23.31817401112721",
                DateCreated = new DateTime(2021, 7, 30, 23, 57, 49)
            };

            yield return new Place()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Raffy Bar & Gelato",
                Description =
                    "Raffy Bar & Gelato е концепция, която е симбиоза от дизайн, страхотна кухня и музикални събития, която до ден-днешен няма аналог в България!",
                MainImageUrl =
                    "https://res.cloudinary.com/dmflbhinu/image/upload/v1627593182/GelatoGuide/Rafi_gelato_spuyt1.jpg",
                SinceYear = 2015,
                WebsiteLink = "http://raffy.bg/",
                FacebookUrl = "https://www.facebook.com/raffybargelato",
                InstagramUrl = "https://www.instagram.com/raffybargelato/",
                City = "София",
                Country = "България",
                Location = "42.694245115089146, 23.340427248848375",
                DateCreated = new DateTime(2021, 7, 29, 9, 48, 26)
            };

            yield return new Place()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Fichi",
                Description = "FICHI GELATO&POPS 100% natural🌱gluten-free🌱organic ingredients.",
                MainImageUrl =
                    "https://res.cloudinary.com/dmflbhinu/image/upload/v1627424467/GelatoGuide/fichiMain_oo0ola.jpg",
                SinceYear = 2018,
                WebsiteLink = "https://www.instagram.com/p/COSXn1XjVvJ/",
                InstagramUrl = "https://www.instagram.com/p/COSXn1XjVvJ/",
                City = "Ниш",
                Country = "Сърбия",
                DateCreated = new DateTime(2021, 7, 18, 23, 55, 13)
            };
        }

        public IEnumerable<Article> Articles()
        {
            yield return new Article()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Тайните на италианското джелато",
                SubTitle = "Най-простото обяснение какво е джелато",
                ArticleText = "Най-простото обяснение какво е джелато е, че е италиански сладолед. Но това е все едно да кажем, че алпийският първенец Монблан е просто някакъв връх. Както снежната шапка на Монблан е мечта и цел за много хора, така и леденият десерт е в мислите и желанията на всеки любител на студените сладки удоволствия.За разлика обаче от най-високия връх в Алпите, за който спорят Франция и Италия, родината на джелатото е съвсем ясна. Затова тайните на италинското джелато знаят само на Ботуша, а славата му се носи навсякъде по света.",
                SourceName = "Ресторант Леонардо",
                SourceUrl = "https://leonardobansko.bg/",
                PostedByName = "Gelato team",
                PostedByDate = new DateTime(2021, 8, 15, 22, 59, 13)
            };
            yield return new Article()
            {
                Title = "Домашен сладолед с Гери от Gelato Fabbrica",
                SubTitle = "Рецепта за сорбе",
                ArticleText = "Не че сладоледът някога ни омръзва, но с идването на лятото той се превръща във фикс идея. “Хайде да си вземем по една фунийка от занаятчийското джелато” или “Хайде да си направим домашен сладолед” са чести хрумки през летните месеци. И точно на тези хрумки ще ви отговорим тук.",
                SourceName = "Gelato Fabbrica",
                SourceUrl = "https://giftcometrue.com/blogs/experiences/homemade-ice-cream-with-gerry-from-gelato-fabbrica",
                PostedByName = "Gelato team",
                PostedByDate = new DateTime(2021, 3, 25, 11, 23, 14)
            };
            yield return new Article()
            {
                Title = "Италиански Сладолед (Джелато)",
                SubTitle = "Да си поговорим за Негово Величество Италианското Джелато",
                ArticleText = "За да се насладите на наистина вкусен такъв, обаче ще трябва да се огледате за Gelateria Artigenale (занаятчийска сладоледжийница). Ако говорите малко италиански или английски е най-добре да попитате къде има хубав сладолед. Тъй като производството му се възприема като изкуство, и в общи линии е такова, всяка зона, всяко малко градче има няколко слодоледжийници, но само една – две достигат съвършенство и са познати на всички.",
                SourceName = "Уни-Блог",
                SourceUrl = "https://uniblogbg.com/vera-italia/2019/03/02/%D0%B8%D1%82%D0%B0%D0%BB%D0%B8%D0%B0%D0%BD%D1%81%D0%BA%D0%B8-%D1%81%D0%BB%D0%B0%D0%B4%D0%BE%D0%BB%D0%B5%D0%B4-%D0%B4%D0%B6%D0%B5%D0%BB%D0%B0%D1%82%D0%BE/",
                PostedByName = "Gelato team",
                PostedByDate = new DateTime(2021, 5, 5, 15, 55, 15)
            };
            yield return new Article()
            {
                Title = "ДЖЕЛАТО НУТЕЛА",
                SubTitle = "Как да си приготвим този невероятен десерт удома",
                ArticleText = "Aĸo cтe имaли yдoвoлcтвиeтo дa пoceтитe ĸpacивaтa Итaлия , вepoятнo cтe oпитaли джeлaтo .  Джeлaтoтo e  “ бpaтoвчeд “  нa cлaдoлeдa . Paзлиĸитe нe ca мнoгo , нo ca cъщecтвeни .  Πpигoтвя ce  c пoвeчe мляĸo , a cмeтaнaтa e в пo – мaлĸo ĸoличecтвo , ĸoлĸoтo дa пoдoбpи cтpyĸтypaтa . Toвa гo пpaви пo – диeтичнo лaĸoмcтвo  , c пo – мaлĸo мaзнини . Taзи вĸycнa пpoxлaдa имa ĸpeмooбpaзнa и мнoгo глaдĸa cтpyĸтypa и зaтoвa  вĸycът мy e  мнoгo пo – нacитeн . B нeгo нямa дa oтĸpиeтe лeдeни ĸpиcтaлчeтa . Aĸo oбичaтe ĸpeмooбpaзeн cлaдoлeд , тoвa e вaшият избop.",
                Image = "https://res.cloudinary.com/dmflbhinu/image/upload/v1628797665/GelatoGuide/IMG_2930-2-945x1417_ds1obt.jpg",
                SourceName = "BeautifulKitchen.net",
                SourceUrl = "https://beautifulkitchen.net/%D0%B4%D0%B6%D0%B5%D0%BB%D0%B0%D1%82%D0%BE-%D0%BD%D1%83%D1%82%D0%B5%D0%BB%D0%B0/",
                PostedByName = "Gelato team",
                PostedByDate = new DateTime(2021, 4, 1, 14, 32, 55)
            };
            yield return new Article()
            {
                Title = "Джелатерия у дома",
                SubTitle = "Лесен сладолед и фунийки",
                ArticleText = "Неделя следобед. Времето навън, направо учудващо напоследък, визуално и температурно спада към лято. Седя си на дивана, пиша тези редове и си хапвам ултра вкусен и кадифен домашен шоколадов сладолед. И още по-хубавото – в хрупкава домашна фунийка. У-ля-ля, идилия!",
                SourceName = "Cherry Bakery",
                SourceUrl = "https://cherrybakery.eu/tag/%D0%B4%D0%BE%D0%BC%D0%B0%D1%88%D0%BD%D0%BE-%D0%B4%D0%B6%D0%B5%D0%BB%D0%B0%D1%82%D0%BE-%D1%80%D0%B5%D1%86%D0%B5%D0%BF%D1%82%D0%B0/",
                PostedByName = "Gelato team",
                PostedByDate = new DateTime(2021, 8, 12, 22, 53, 12)
            };

        }
    }
}
