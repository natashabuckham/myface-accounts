using System.Collections.Generic;
using System.Linq;
using MyFace.Models.Database;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;

namespace MyFace.Data
{
    public static class SampleUsers
    {
        public const int NumberOfUsers = 100;

        private static readonly IList<IList<string>> Data = new List<IList<string>>
        {
            new List<string> {"0", "Kania", "Placido", "kplacido0", "kplacido0@qq.com" },
            new List<string> {"1", "Scotty", "Gariff", "sgariff1", "sgariff1@biblegateway.com" },
            new List<string> {"1", "Colly", "Burgiss", "cburgiss2", "cburgiss2@amazon.co.uk" },
            new List<string> {"1", "Barnie", "Percival", "bpercival3", "bpercival3@cmu.edu" },
            new List<string> {"1", "Brandon", "Narraway", "bnarraway4", "bnarraway4@trellian.com" },
            new List<string> {"1", "Carlos", "Sakins", "csakins5", "csakins5@spiegel.de" },
            new List<string> {"1", "Zeke", "Barkworth", "zbarkworth6", "zbarkworth6@symantec.com" },
            new List<string> {"1", "Henrietta", "Verick", "hverick7", "hverick7@adobe.com" },
            new List<string> {"1", "Maxine", "Lovett", "mlovett8", "mlovett8@mac.com" },
            new List<string> {"1", "Adorne", "Smyth", "asmyth9", "asmyth9@nyu.edu" },
            new List<string> {"1", "Roslyn", "O' Scallan", "roscallana", "roscallana@marriott.com" },
            new List<string> {"1", "Kalindi", "Bevington", "kbevingtonb", "kbevingtonb@wired.com" },
            new List<string> {"1", "Silva", "Cow", "scowc", "scowc@yellowbook.com" },
            new List<string> {"1", "Gnni", "Northage", "gnorthaged", "gnorthaged@lulu.com" },
            new List<string> {"1", "Jobi", "Balsom", "jbalsome", "jbalsome@ox.ac.uk" },
            new List<string> {"1", "Laurice", "Galgey", "lgalgeyf", "lgalgeyf@usa.gov" },
            new List<string> {"1", "Orsola", "Laurant", "olaurantg", "olaurantg@reverbnation.com" },
            new List<string> {"1", "Dante", "Mabley", "dmableyh", "dmableyh@scientificamerican.com" },
            new List<string> {"1", "Shantee", "Guillond", "sguillondi", "sguillondi@gravatar.com" },
            new List<string> {"1", "Mendy", "Djuricic", "mdjuricicj", "mdjuricicj@tuttocitta.it" },
            new List<string> {"1", "Ralph", "Adamovicz", "radamoviczk", "radamoviczk@salon.com" },
            new List<string> {"1", "Zsa zsa", "Goodacre", "zgoodacrel", "zgoodacrel@histats.com" },
            new List<string> {"1", "Fleurette", "Blow", "fblowm", "fblowm@who.int" },
            new List<string> {"1","1", "Zelda", "Pritchett", "zpritchettn", "zpritchettn@wordpress.org" },
            new List<string> {"1", "Kaitlyn", "Filshin", "kfilshino", "kfilshino@so-net.ne.jp" },
            new List<string> {"1", "Aube", "Goneau", "agoneaup", "agoneaup@barnesandnoble.com" },
            new List<string> {"1", "Natala", "Mackrill", "nmackrillq", "nmackrillq@google.es" },
            new List<string> {"1", "Ev", "Wadly", "ewadlyr", "ewadlyr@adobe.com" },
            new List<string> {"1", "Aurora", "Feedham", "afeedhams", "afeedhams@house.gov" },
            new List<string> {"1", "Farly", "Chestney", "fchestneyt", "fchestneyt@usda.gov" },
            new List<string> {"1", "Chico", "Guilloux", "cguillouxu", "cguillouxu@senate.gov" },
            new List<string> {"1", "Julianna", "Huckstepp", "jhucksteppv", "jhucksteppv@ycombinator.com" },
            new List<string> {"1", "Bev", "Sancto", "bsanctow", "bsanctow@spiegel.de" },
            new List<string> {"1", "Shara", "Jeeves", "sjeevesx", "sjeevesx@behance.net" },
            new List<string> {"1", "Legra", "Jereatt", "ljereatty", "ljereatty@prnewswire.com" },
            new List<string> {"1", "Katey", "Ternouth", "kternouthz", "kternouthz@webmd.com" },
            new List<string> {"1", "Val", "McMenamin", "vmcmenamin10", "vmcmenamin10@noaa.gov" },
            new List<string> {"1", "Shannan", "Greenhalf", "sgreenhalf11", "sgreenhalf11@gravatar.com" },
            new List<string> {"1", "Sterling", "Fellgate", "sfellgate12", "sfellgate12@surveymonkey.com" },
            new List<string> {"1", "Brina", "Dickens", "bdickens13", "bdickens13@zimbio.com" },
            new List<string> {"1", "Boniface", "McKaile", "bmckaile14", "bmckaile14@jalbum.net" },
            new List<string> {"1", "Vincenty", "Aishford", "vaishford15", "vaishford15@wordpress.org" },
            new List<string> {"1", "Kathye", "Gauford", "kgauford16", "kgauford16@xrea.com" },
            new List<string> {"1", "Chico", "Seelbach", "cseelbach17", "cseelbach17@over-blog.com" },
            new List<string> {"1", "Enoch", "Winsper", "ewinsper18", "ewinsper18@devhub.com" },
            new List<string> {"1", "Brandie", "Welds", "bwelds19", "bwelds19@chicagotribune.com" },
            new List<string> {"1", "Bethanne", "Kerin", "bkerin1a", "bkerin1a@acquirethisname.com" },
            new List<string> {"1", "Margo", "Tompkins", "mtompkins1b", "mtompkins1b@mayoclinic.com" },
            new List<string> {"1", "Allie", "Clever", "aclever1c", "aclever1c@slideshare.net" },
            new List<string> {"1", "North", "Denny", "ndenny1d", "ndenny1d@simplemachines.org" },
            new List<string> {"1", "Ted", "Scorah", "tscorah1e", "tscorah1e@devhub.com" },
            new List<string> {"1", "Leone", "McGow", "lmcgow1f", "lmcgow1f@unblog.fr" },
            new List<string> {"1", "Abbie", "Jannasch", "ajannasch1g", "ajannasch1g@sakura.ne.jp" },
            new List<string> {"1", "Marika", "Dommett", "mdommett1h", "mdommett1h@infoseek.co.jp" },
            new List<string> {"1", "Edith", "Norcop", "enorcop1i", "enorcop1i@behance.net" },
            new List<string> {"1", "Ernest", "Baline", "ebaline1j", "ebaline1j@amazon.co.uk" },
            new List<string> {"1", "Rowen", "Dorcey", "rdorcey1k", "rdorcey1k@gravatar.com" },
            new List<string> {"1", "Pasquale", "Surplice", "psurplice1l", "psurplice1l@paypal.com" },
            new List<string> {"1", "Tim", "Dyott", "tdyott1m", "tdyott1m@yellowbook.com" },
            new List<string> {"1", "Tedd", "Connachan", "tconnachan1n", "tconnachan1n@so-net.ne.jp" },
            new List<string> {"1", "Jacquetta", "McClelland", "jmcclelland1o", "jmcclelland1o@nifty.com" },
            new List<string> {"1", "0", "Nelli", "Maund", "nmaund1p", "nmaund1p@myspace.com" },
            new List<string> {"1", "Morie", "Anselmi", "manselmi1q", "manselmi1q@nytimes.com" },
            new List<string> {"1", "Gabie", "Antoniazzi", "gantoniazzi1r", "gantoniazzi1r@dailymail.co.uk" },
            new List<string> {"1", "Menard", "Engelbrecht", "mengelbrecht1s", "mengelbrecht1s@over-blog.com" },
            new List<string> {"1", "Mike", "Tommasetti", "mtommasetti1t", "mtommasetti1t@bluehost.com" },
            new List<string> {"1", "Eldin", "Fredy", "efredy1u", "efredy1u@mozilla.com" },
            new List<string> {"1", "Pris", "McCowen", "pmccowen1v", "pmccowen1v@jalbum.net" },
            new List<string> {"1", "Joey", "Dossettor", "jdossettor1w", "jdossettor1w@webnode.com" },
            new List<string> {"1", "Daisey", "Ogdahl", "dogdahl1x", "dogdahl1x@nyu.edu" },
            new List<string> {"1", "Melanie", "Searle", "msearle1y", "msearle1y@loc.gov" },
            new List<string> {"1", "Beatrix", "MacLise", "bmaclise1z", "bmaclise1z@hugedomains.com" },
            new List<string> {"1", "Missy", "Hillitt", "mhillitt20", "mhillitt20@multiply.com" },
            new List<string> {"1", "Belinda", "Tumielli", "btumielli21", "btumielli21@php.net" },
            new List<string> {"1", "Raynor", "Dupey", "rdupey22", "rdupey22@fc2.com" },
            new List<string> {"1", "Inigo", "Heineke", "iheineke23", "iheineke23@ihg.com" },
            new List<string> { "1", "Ilaire", "Angric", "iangric24", "iangric24@apache.org" },
            new List<string> { "1", "Estel", "Steljes", "esteljes25", "esteljes25@livejournal.com" },
            new List<string> { "1", "Lyell", "Ashard", "lashard26", "lashard26@umn.edu" },
            new List<string> { "1", "Darren", "Devons", "ddevons27", "ddevons27@economist.com" },
            new List<string> { "1", "Warden", "Undrell", "wundrell28", "wundrell28@mozilla.org" },
            new List<string> { "1", "Iris", "Langworthy", "ilangworthy29", "ilangworthy29@timesonline.co.uk" },
            new List<string> { "1", "Marten", "Minards", "mminards2a", "mminards2a@statcounter.com" },
            new List<string> { "1", "Kerry", "Bennion", "kbennion2b", "kbennion2b@spotify.com" },
            new List<string> { "1", "Olivette", "Norridge", "onorridge2c", "onorridge2c@cpanel.net" },
            new List<string> { "1", "Rosalinde", "Traske", "rtraske2d", "rtraske2d@bbc.co.uk" },
            new List<string> { "1", "Gaultiero", "McCard", "gmccard2e", "gmccard2e@utexas.edu" },
            new List<string> { "1", "Zonnya", "Capstaff", "zcapstaff2f", "zcapstaff2f@theatlantic.com" },
            new List<string> { "0", "Ingelbert", "Sleford", "isleford2g", "isleford2g@qq.com" },
            new List<string> { "1", "Nicol", "Nary", "nnary2h", "nnary2h@google.com.hk" },
            new List<string> { "1", "Jasun", "Lukianov", "jlukianov2i", "jlukianov2i@blogs.com" },
            new List<string> { "1", "Alison", "Durkin", "adurkin2j", "adurkin2j@sitemeter.com" },
            new List<string> { "1", "Claudius", "Coronas", "ccoronas2k", "ccoronas2k@tamu.edu" },
            new List<string> { "1", "Jakie", "Keener", "jkeener2l", "jkeener2l@princeton.edu" },
            new List<string> { "0", "Gilbertine", "Wynett", "gwynett2m", "gwynett2m@epa.gov" },
            new List<string> { "1", "Syd", "Cordelle", "scordelle2n", "scordelle2n@blogger.com" },
            new List<string> { "1", "Stafford", "Deport", "sdeport2o", "sdeport2o@wix.com" },
            new List<string> { "1", "Zacharie", "Perchard", "zperchard2p", "zperchard2p@qq.com" },
            new List<string> { "1", "Jane", "Iceton", "jiceton2q", "jiceton2q@lulu.com" },
            new List<string> { "0", "Marjy", "Beadell", "mbeadell2r", "mbeadell2r@delicious.com" }
        };
        
        public static IEnumerable<User> GetUsers()
        {
            return Enumerable.Range(0, NumberOfUsers).Select(CreateRandomUser);
        }

        public static (byte[] Salt, string Hash) GetSaltHash(int index)
        {
            string password = Data[index][2];
            
            byte[] saltByte = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(saltByte);
            }

            string hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltByte,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8
            ));

            return (saltByte, hash);
        }

        private static User CreateRandomUser(int index)
        {
            var saltHash = GetSaltHash(index);

            return new User
            {
                Role = (Role)int.Parse(Data[index][0]),
                FirstName = Data[index][1],
                LastName = Data[index][2],
                Username = Data[index][3],
                Email = Data[index][4],
                Salt = saltHash.Salt,
                HashedPassword = saltHash.Hash,
                ProfileImageUrl = ImageGenerator.GetProfileImage(Data[index][2]),
                CoverImageUrl = ImageGenerator.GetCoverImage(index),
            };
        }
    }
}
