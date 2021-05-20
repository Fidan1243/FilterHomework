using ConsoleApp7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Program
{
    class Debtor
    {
        public Debtor(string fullname, DateTime birthDay, string phone, string email, string address, int debt)
        {
            this.FullName = fullname;
            this.BirthDay = birthDay;
            this.Phone = phone;
            this.Email = email;
            this.Address = address;
            this.Debt = debt;
        }

        public string FullName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Debt { get; set; }
        public override string ToString()
        {
            return $"{this.FullName} {this.BirthDay.ToShortDateString()} {this.Phone} {this.Email} {this.Address} {this.Debt}";
        }
    }


    class Helper
    {
        public int CountOfSeven(string data)
        {
            int count = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == '7')
                {
                    count++;
                }
            }
            return count;
        }

        public decimal MiddleOfDebt(List<Debtor> debtor)
        {
            int i = 0;

            decimal total = 0;
            debtor.ForEach(d => total += d.Debt);
            
            debtor.ForEach(d=> i++);
            return total /= i;
        }

        public bool HasEight(string phone)
        {
            for (int i = 0; i < phone.Length; i++)
            {
                if (phone[i] == '8')
                {
                    return true;
                }
            }
            return false;
        }
        public bool HasThreeSameCharacter(string fullname)
        {
            int counter1 = 0;
            for (int i = 0; i < fullname.Length; i++)
            {
                counter1 = 0;
                for (int k = 0; k < fullname.Length; k++)
                {
                    if (fullname[k] == fullname[i])
                    {
                        counter1++;
                    }
                }
                if (counter1 > 2)
                {
                    return true;
                }
            }
            return false;
        }
        public int MostYear(List<Debtor> debtors)
        {
            int max = 0;
            int counter = 0;
            int maxcounter = 0;

            debtors.ForEach(d1 => {
                counter = 0;
                debtors.ForEach(d2 =>
                {

                    if (d1.BirthDay.Year == d2.BirthDay.Year)
                    {
                        counter++;
                    }
                }
                );
                if (counter > maxcounter)
                {
                    maxcounter = counter;
                    max = d1.BirthDay.Year;
                }
            });
            return max;
        }
        public int Total(List<Debtor> debtors)
        {
            int total = 0;

            debtors.ForEach(d1 => total += d1.Debt);
            return total;
        }

        public bool IsUnicalNumber(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                for (int k = 0; k < number.Length; k++)
                {
                    if (number[i] == number[k] && number[i] != '-')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool IsBirthdayTimeFree(int debt, int birthmonth)
        {
            int monthcount = debt / 500;
            monthcount += DateTime.Now.Month;
            if (DateTime.Now.Month < birthmonth)
            {
                if (birthmonth > monthcount)
                {
                    return true;
                }
            }
            if (DateTime.Now.Month > birthmonth)
            {
                if (12 - DateTime.Now.Month + birthmonth > monthcount)
                {
                    return true;
                }
            }
            return false;
        }
    }

    class Starter
    {
        public void Run(List<Debtor> debtors)
        {
            Helper help = new Helper();
            Console.Clear();
            Console.WriteLine("1: For Print debtors which have rhyta.com and dayrep.com domain in their email");
            Console.WriteLine("2: For print debtors between the ages of 26 and 36");
            Console.WriteLine("3: For print debtors whose debt does not exceed 5,000");
            Console.WriteLine("4: For print debtors 18- character in fullname and 2+ 7 number in phone number ");
            Console.WriteLine("5: For print winter child debtors");
            Console.WriteLine("6: For Print debtors debt more than middle of debts (For surname sort and debt sort)");
            Console.WriteLine("7: For Print debtors whose phone number doesn't consists 8");
            Console.WriteLine("8: For Print debtors 3 same character in their fullname");
            Console.WriteLine("9: For Print most debtors' birth year");
            Console.WriteLine("10: For Print 5 debtors whose debt is bigger than others");
            Console.WriteLine("11: For Print total debt");
            Console.WriteLine("12: For Print debtors whose age bigger than 76");
            Console.WriteLine("13: For Print debtors whose has unical number");
            Console.WriteLine("14: For Print debtors we can write smile in their fullname's characters");
            Console.WriteLine("15: For Print extra");

            string ch = Console.ReadLine();

            if (Convert.ToInt32(ch) == 1)
            {
                Console.Clear();
                var domain = debtors.Where(d => d.Email.EndsWith("rhyta.com") || d.Email.EndsWith("dayrep.com")).ToList();
                domain.ForEach(d => Console.WriteLine($"Name: {d.FullName}  -  Email: {d.Email}"));
                Thread.Sleep(4000);
            }
            else if (Convert.ToInt32(ch) == 2)
            {
                Console.Clear();
                var year = debtors.Where(d => DateTime.Now.Year - d.BirthDay.Year >= 26 && DateTime.Now.Year - d.BirthDay.Year < 36).ToList();
                year.ForEach(d => Console.WriteLine($"Name: {d.FullName}  -  Age: {DateTime.Now.Year - d.BirthDay.Year}"));
                Thread.Sleep(4000);
            }
            else if (Convert.ToInt32(ch) == 3)
            {
                Console.Clear();
                var debt5000 = debtors.Where(d => d.Debt <= 5000).ToList();
                debt5000.ForEach(d => Console.WriteLine($"Name: {d.FullName}  -  Debt: {d.Debt}"));
                Thread.Sleep(4000);
            }
            else if (Convert.ToInt32(ch) == 4)
            {
                Console.Clear();
                var nameandnumber = debtors.Where(d => d.FullName.Split(' ')[0].Length + d.FullName.Split(' ')[1].Length + d.FullName.Split(' ')[2].Length <= 18 && help.CountOfSeven(d.Phone) >= 2).ToList();
                nameandnumber.ForEach(d => Console.WriteLine($"Name: {d.FullName}  -  Number: {d.Phone}"));
                Thread.Sleep(4000);
            }
            else if (Convert.ToInt32(ch) == 5)
            {
                Console.Clear();
                var winterchild = debtors.Where(d => d.BirthDay.Month == 12 || d.BirthDay.Month == 1 || d.BirthDay.Month == 2).ToList();
                winterchild.ForEach(d => Console.WriteLine($"Name: {d.FullName}"));
                Thread.Sleep(4000);
            }
            else if (Convert.ToInt32(ch) == 6)
            {
                Console.Clear();
                var debtlow = debtors.Where(d => d.Debt > help.MiddleOfDebt(debtors)).ToList();
                var debtlowSurname = debtlow.OrderByDescending(d => d.FullName.Split(' ')[2]).ToList();
                var debtlowDebt = debtlow.OrderByDescending(d => d.Debt).ToList();
                debtlowSurname.ForEach(d => Console.WriteLine($" Name: {d.FullName} - Debt: {d.Debt}"));
                Console.WriteLine("========================================================");
                debtlowDebt.ForEach(d => Console.WriteLine($"Name: {d.FullName} - Debt: {d.Debt}"));
                Thread.Sleep(4000);
            }
            else if (Convert.ToInt32(ch) == 7)
            {
                Console.Clear();
                var withouteight = debtors.Where(d => help.HasEight(d.Phone) != true).ToList();
                withouteight.ForEach(d => Console.WriteLine($"Surname: {d.FullName.Split(' ')[2]}   -   Age: {DateTime.Now.Year - d.BirthDay.Year}   -   Debt: {d.Debt}"));
                Thread.Sleep(4000);
            }
            else if (Convert.ToInt32(ch) == 8)
            {
                Console.Clear();
                var samethree = debtors.Where(d => help.HasThreeSameCharacter(d.FullName) == true).ToList();
                samethree = samethree.OrderByDescending(d => d.FullName).ToList();
                samethree.ForEach(d => Console.WriteLine($"Fullname: {d.FullName}   -   Age: {DateTime.Now.Year - d.BirthDay.Year}   -   Debt: {d.Debt}"));
                Thread.Sleep(4000);
            }
            else if (Convert.ToInt32(ch) == 9)
            {
                Console.Clear();
                Console.WriteLine(help.MostYear(debtors));
                Thread.Sleep(4000);
            }
            else if (Convert.ToInt32(ch) == 10)
            {
                Console.Clear();
                var mostdebt = debtors.OrderByDescending(d => d.Debt).Take(5).ToList();
                mostdebt.ForEach(d => Console.WriteLine($"Name: {d.FullName}   -   Debt: {d.Debt}"));
                Thread.Sleep(4000);
            }
            else if (Convert.ToInt32(ch) == 11)
            {
                Console.Clear();
                Console.WriteLine($"Total debts: {help.Total(debtors)}");
                Thread.Sleep(4000);
            }
            else if (Convert.ToInt32(ch) == 12)
            {
                Console.Clear();
                var wwIIdebt = debtors.Where(d => d.BirthDay.Year < 1945).ToList();
                wwIIdebt.ForEach(d => Console.WriteLine($"Name: {d.FullName}   -   Birth date: {d.BirthDay}"));
                Thread.Sleep(4000);
            }
            else if (Convert.ToInt32(ch) == 13)
            {
                Console.Clear();
                var unicalnumberdebtor = debtors.Where(d => help.IsUnicalNumber(d.Phone) == true).ToList();
                unicalnumberdebtor.ForEach(d => Console.WriteLine(d.Phone));
                Thread.Sleep(4000);
            }
            else if (Convert.ToInt32(ch) == 14)
            {
                Console.Clear();
                var smiledebtor = debtors.Where(d => d.FullName.Contains("s") && d.FullName.Contains("m") && d.FullName.Contains("i") && d.FullName.Contains("l") && d.FullName.Contains("e")).ToList();
                smiledebtor.ForEach(d => Console.WriteLine(d.FullName));
                Thread.Sleep(4000);
            }
            else if (Convert.ToInt32(ch) == 15)
            {
                Console.Clear();
                var birthdayfreedebtor = debtors.Where(d => help.IsBirthdayTimeFree(d.Debt, d.BirthDay.Month)).ToList();
                birthdayfreedebtor.ForEach(d => Console.WriteLine($"Name: {d.FullName}   -   Birth date: {d.BirthDay}   -   Debt: {d.Debt}"));
                Thread.Sleep(4000);
            }
            else
            {
                throw new Exception("Invalid Choose!");
            }
        }
    }

    static void Main()
    {
        List<Debtor> debtors = new List<Debtor> {
            new Debtor("Shirley T. Qualls", DateTime.Parse("March 30, 1932"), "530-662-7732", "ShirleyTQualls@teleworm.us", "3565 Eagles Nest Drive Woodland, CA 95695", 2414),
            new Debtor("Danielle W. Grier", DateTime.Parse("October 18, 1953"), "321-473-4178", "DanielleWGrier@rhyta.com", "1973 Stoneybrook Road Maitland, FL 32751", 3599),
            new Debtor("Connie W. Lemire", DateTime.Parse("June 18, 1963"), "828-321-3751", "ConnieWLemire@rhyta.com", "2432 Hannah Street Andrews, NC 28901", 1219),
            new Debtor("Coy K. Adams", DateTime.Parse("March 1, 1976"), "410-347-1307", "CoyKAdams@dayrep.com", "2411 Blue Spruce Lane Baltimore, MD 21202", 3784),
            new Debtor("Bernice J. Miles", DateTime.Parse("June 1, 1988"), "912-307-6797", "BerniceJMiles@armyspy.com", "4971 Austin Avenue Savannah, GA 31401", 4060),
            new Debtor("Bob L. Zambrano", DateTime.Parse("February 28, 1990"), "706-446-1649", "BobLZambrano@armyspy.com", "2031 Limer Street Augusta, GA 30901", 6628),
            new Debtor("Adam D. Bartlett", DateTime.Parse("May 6, 1950"), "650-693-1758", "AdamDBartlett@rhyta.com", "2737 Rardin Drive San Jose, CA 95110", 5412),
            new Debtor("Pablo M. Skinner", DateTime.Parse("August 26, 1936"), "630-391-2034", "PabloMSkinner@armyspy.com", "16 Fraggle Drive Hickory Hills, IL 60457", 11097),
            new Debtor("Dorothy J. Brown", DateTime.Parse("July 9, 1971"), "270-456-3288", "DorothyJBrown@rhyta.com", "699 Harper Street Louisville, KY 40202", 7956),
            new Debtor("Larry A. Miracle", DateTime.Parse("May 22, 1998"), "301-621-3318", "LarryAMiracle@jourrapide.com", "2940 Adams Avenue Columbia, MD 21044", 7150),
            new Debtor("Donna B. Maynard", DateTime.Parse("January 26, 1944"), "520-297-0575", "DonnaBMaynard@teleworm.us", "4821 Elk Rd Little Tucson, AZ 85704", 2910),
            new Debtor("Jessica J. Stoops", DateTime.Parse("April 22, 1989"), "360-366-8101", "JessicaJStoops@dayrep.com", "2527 Terra Street Custer, WA 98240", 11805),
            new Debtor("Audry M. Styles", DateTime.Parse("February 7, 1937"), "978-773-4802", "AudryMStyles@jourrapide.com", "151 Christie Way Marlboro, MA 01752", 1001),
            new Debtor("Violet R. Anguiano", DateTime.Parse("November 4, 1958"), "585-340-7888", "VioletRAnguiano@dayrep.com", "1460 Walt Nuzum Farm Road Rochester, NY 14620", 9128),
            new Debtor("Charles P. Segundo", DateTime.Parse("October 21, 1970"), "415-367-3341", "CharlesPSegundo@dayrep.com", "1824 Roosevelt Street Fremont, CA 94539", 5648),
            new Debtor("Paul H. Sturtz", DateTime.Parse("September 15, 1944"), "336-376-1732", "PaulHSturtz@dayrep.com", "759 Havanna Street Saxapahaw, NC 27340", 10437),
            new Debtor("Doris B. King", DateTime.Parse("October 10, 1978"), "205-231-8973", "DorisBKing@rhyta.com", "3172 Bedford Street Birmingham, AL 35203", 7230),
            new Debtor("Deanna J. Donofrio", DateTime.Parse("April 16, 1983"), "952-842-7576", "DeannaJDonofrio@rhyta.com", "1972 Orchard Street Bloomington, MN 55437", 515),
            new Debtor("Martin S. Malinowski", DateTime.Parse("January 17, 1992"), "765-599-3523", "MartinSMalinowski@dayrep.com", "3749 Capitol Avenue New Castle, IN 47362", 1816),
            new Debtor("Melissa R. Arner", DateTime.Parse("May 24, 1974"), "530-508-7328", "MelissaRArner@armyspy.com", "922 Hill Croft Farm Road Sacramento, CA 95814", 5037),
            new Debtor("Kelly G. Hoffman", DateTime.Parse("September 22, 1969"), "505-876-8935", "KellyGHoffman@armyspy.com", "4738 Chapmans Lane Grants, NM 87020", 7755),
            new Debtor("Doyle B. Short", DateTime.Parse("June 15, 1986"), "989-221-4363", "DoyleBShort@teleworm.us", "124 Wood Street Saginaw, MI 48607", 11657),
            new Debtor("Lorrie R. Gilmore", DateTime.Parse("December 23, 1960"), "724-306-7138", "LorrieRGilmore@teleworm.us", "74 Pine Street Pittsburgh, PA 15222", 9693),
            new Debtor("Lionel A. Cook", DateTime.Parse("April 16, 1972"), "201-627-5962", "LionelACook@jourrapide.com", "29 Goldleaf Lane Red Bank, NJ 07701", 2712),
            new Debtor("Charlene C. Burke", DateTime.Parse("January 18, 1990"), "484-334-9729", "CharleneCBurke@armyspy.com", "4686 Renwick Drive Philadelphia, PA 19108", 4016),
            new Debtor("Tommy M. Patton", DateTime.Parse("June 30, 1981"), "774-571-6481", "TommyMPatton@rhyta.com", "748 Rockford Road Westborough, MA 01581", 349),
            new Debtor("Kristin S. Bloomer", DateTime.Parse("June 16, 1944"), "443-652-0734", "KristinSBloomer@dayrep.com", "15 Hewes Avenue Towson, MD 21204", 9824),
            new Debtor("Daniel K. James", DateTime.Parse("November 10, 1997"), "801-407-4693", "DanielKJames@rhyta.com", "3052 Walton Street Salt Lake City, UT 84104", 8215),
            new Debtor("Paula D. Henry", DateTime.Parse("September 6, 1976"), "618-378-5307", "PaulaDHenry@rhyta.com", "3575 Eagle Street Norris City, IL 62869", 5766),
            new Debtor("Donna C. Sandoval", DateTime.Parse("December 13, 1947"), "540-482-5463", "DonnaCSandoval@rhyta.com", "675 Jehovah Drive Martinsville, VA 24112", 8363),
            new Debtor("Robert T. Taylor", DateTime.Parse("August 17, 1932"), "270-596-6442", "RobertTTaylor@armyspy.com", "2812 Rowes Lane Paducah, KY 42001", 7785),
            new Debtor("Donna W. Alamo", DateTime.Parse("December 9, 1948"), "978-778-2533", "DonnaWAlamo@teleworm.us", "4367 Christie Way Marlboro, MA 01752", 10030),
            new Debtor("Amy R. Parmer", DateTime.Parse("May 19, 1995"), "480-883-4934", "AmyRParmer@armyspy.com", "85 Elmwood Avenue Chandler, AZ 85249", 5347),
            new Debtor("Newton K. Evans", DateTime.Parse("October 8, 1986"), "303-207-9084", "NewtonKEvans@rhyta.com", "3552 Columbia Road Greenwood Village, CO 80111", 9838),
            new Debtor("Kathleen C. Chaney", DateTime.Parse("January 5, 1949"), "605-245-3513", "KathleenCChaney@rhyta.com", "316 Elsie Drive Fort Thompson, SD 57339", 1672),
            new Debtor("Manuel C. Johnson", DateTime.Parse("February 23, 1957"), "606-247-2659", "ManuelCJohnson@jourrapide.com", "4146 May Street Sharpsburg, KY 40374", 9195),
            new Debtor("Carla A. Creagh", DateTime.Parse("November 21, 1988"), "614-307-8974", "CarlaACreagh@dayrep.com", "3106 Bates Brothers Road Columbus, OH 43215", 11271),
            new Debtor("Norma M. New", DateTime.Parse("May 18, 1988"), "857-492-8703", "NormaMNew@jourrapide.com", "965 Metz Lane Woburn, MA 01801", 9761),
            new Debtor("Roy D. Green", DateTime.Parse("January 27, 1983"), "308-340-5981", "RoyDGreen@jourrapide.com", "401 Romrog Way Grand Island, NE 68801", 10771),
            new Debtor("Cristy J. Jensen", DateTime.Parse("November 2, 1935"), "440-626-9550", "CristyJJensen@jourrapide.com", "2177 Harley Vincent Drive Cleveland, OH 44113", 5205),
            new Debtor("Nancy J. Fergerson", DateTime.Parse("June 10, 1993"), "219-987-8498", "NancyJFergerson@dayrep.com", "3584 Jadewood Drive Demotte, IN 46310", 1276),
            new Debtor("Dave N. Rodriguez", DateTime.Parse("January 21, 1938"), "214-540-2499", "DaveNRodriguez@rhyta.com", "1890 Poco Mas Drive Dallas, TX 75247", 9132),
            new Debtor("James E. Denning", DateTime.Parse("May 4, 1988"), "504-289-8640", "JamesEDenning@jourrapide.com", "1444 Rose Avenue Metairie, LA 70001", 8176),
            new Debtor("Richard M. Thomas", DateTime.Parse("February 13, 1972"), "510-735-3359", "RichardMThomas@jourrapide.com", "4454 Green Avenue Oakland, CA 94609", 7875),
            new Debtor("Lakisha R. Forrest", DateTime.Parse("December 1, 1973"), "334-830-1181", "LakishaRForrest@armyspy.com", "3121 Quarry Drive Montgomery, AL 36117", 3088),
            new Debtor("Pamela H. Beauchamp", DateTime.Parse("November 20, 1959"), "801-559-6347", "PamelaHBeauchamp@jourrapide.com", "3239 Tori Lane Salt Lake City, UT 84104", 6588)
        };
        Starter start = new Starter();
        while (true)
        {
            try
            {
                start.Run(debtors);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        

    }
}