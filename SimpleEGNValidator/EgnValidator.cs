using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EgnValidatorProgram
{
    public enum Gender
    {
        Male = 1,
        Female = 2,
    }

    public class EgnValidator : IEgnValidator
    {

        private static readonly DateTime minDate = new DateTime(1800, 01, 01);
        private static readonly DateTime maxDate = new DateTime(2099, 12, 31);
        private int[] egnWeights = { 2, 4, 8, 5, 10, 9, 7, 3, 6 };

        public EgnValidator()
        {
            Regions = new Dictionary<string, IEnumerable<int>>();
            string[] cities = File.ReadAllLines("Regions.txt");
            foreach (var city in cities)
            {
                string[] line = city.Split(",", StringSplitOptions.RemoveEmptyEntries);
                Regions.Add(line[0], Enumerable.Range(int.Parse(line[1]), int.Parse(line[2]) + 1 - int.Parse(line[1])));
            }
            EgnCollection = new List<StringBuilder>();
        }

        private Dictionary<string, IEnumerable<int>> Regions { get; set; }
        private List<StringBuilder> EgnCollection { get; set; }

        /// <summary>
        /// Generate all valid EGN numbers for given criteria.
        /// </summary>
        /// <param name="birthDate">Date of birth.</param>
        /// <param name="city">The city where EGN holders are born in.</param>
        /// <param name="isMale">True for male, false for female</param>
        /// <returns>List of all valid EGN numbers</returns>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        /// <exception cref="InvalidCityException"></exception>
        public string[] Generate(DateTime birthDate, string city, Gender gender)
        {
            if (birthDate.Year < 1800 || birthDate.Year > 2099) // [1800-2099]
            {
                throw new ArgumentOutOfRangeException("birthDate", "Birth date should be greater or equal to 1800");
            }
            if (city == null)
            {
                throw new ArgumentNullException(city);
            }
            if (Regions.ContainsKey(city) == false)
            {
                throw new InvalidCityException(city);
            }
            if (gender != Gender.Male && gender != Gender.Female)
            {
                throw new ArgumentOutOfRangeException("gender", "Gender should be 1 for male,2 for female");
            }

            StringBuilder date = GenerateDateOfBirth(birthDate);
            
            foreach (var regionCode in Regions[city])
            {
                StringBuilder egnToAdd = new StringBuilder(date.ToString());
                if (gender == Gender.Male)
                {
                    if (regionCode % 2 == 0)
                    {
                        egnToAdd.Append(regionCode);
                        EgnCollection.Add(egnToAdd);
                    }
                }
                else
                {
                    if (regionCode % 2 != 0)
                    {
                        egnToAdd.Append(regionCode);
                        EgnCollection.Add(egnToAdd);
                    }
                }
            }
            return CalculateControl(EgnCollection).Select(s => s.ToString()).ToArray();
        }


       
        /// <summary>
        /// Chekcs the validity of EGN
        /// </summary>
        /// <param name="egn"></param>
        /// <returns>True for valid,false for invalid</returns>
        public bool Validate(string egn)
        {
            if (egn == null || egn.Length != 10)
            {
                return false;
            }
            else
            {
                if (long.TryParse(egn, out _) == false)
                {
                    return false;
                }
            }

            string[] egnArray = egn.ToCharArray().Select(c => c.ToString()).ToArray();

            if (ValidateDate(egnArray) && ValidateRegion(egnArray) && ValidateControl(egnArray))
            {
                return true;
            }
            return false;
        }



        private StringBuilder GenerateDateOfBirth(DateTime birthDate)
        {
            StringBuilder egn = new StringBuilder();
            int year = birthDate.Year;
            int month = birthDate.Month;
            int day = birthDate.Day;
            if (year > 1999)
            {
                year -= 2000;
                month += 40;
            }
            else if (year < 1900)
            {
                year -= 1800;
                month += 20;
            }
            else
            {
                year -= 1900;
            }
           return egn.Append($"{year:d2}{month:d2}{day:d2}");
        }



        private List<StringBuilder> CalculateControl(List<StringBuilder> egnCollection)
        {
            for (int i = 0; i < egnCollection.Count; i++)
            {
                string egn = egnCollection[i].ToString();
                int controlNum = 0;
                for (int j = 0; j < 9; j++)
                {
                    controlNum += int.Parse(egn[j].ToString()) * egnWeights[j];
                }
                controlNum %= 11;
                if (controlNum == 10)
                {
                    egnCollection[i].Append(0);
                }
                else
                {
                    egnCollection[i].Append(controlNum);
                }
            }
            return egnCollection;
        }

       

        private bool ValidateControl(string[] egnArray)
        {
            int controlNum = int.Parse(egnArray[^1]);
            int result = 0;
            for (int i = 0; i < egnArray.Length - 1; i++)
            {
                result += int.Parse(egnArray[i]) * egnWeights[i];
            }
            result %= 11;
            if (result == 10)
            {
                return controlNum == 0;
            }
            else
            {
                return controlNum == result;
            }
        }




        private bool ValidateRegion(string[] egnArray)
        {
            int regionCode = int.Parse($"{egnArray[6]}{egnArray[7]}{egnArray[8]}");
            foreach (var region in Regions)
            {
                if (region.Value.Contains(regionCode))
                {
                    return true;
                }
            }
            return false;
        }



        private bool ValidateDate(string[] egnArray)
        {
            int year = int.Parse($"{egnArray[0]}{egnArray[1]}");
            int month = int.Parse($"{egnArray[2]}{egnArray[3]}");
            int day = int.Parse($"{egnArray[4]}{egnArray[5]}");
            if (month > 0 && month <= 12)
            {
                year += 1900;
            }
            else if (month >= 21 && month <= 32)
            {
                year += 1800;
                month -= 20;
            }
            else if (month >= 41 && month <= 52)
            {
                year += 2000;
                month -= 40;
            }
            else return false;
            try
            {
                DateTime date = new DateTime(year, month, day);
                if (date >= minDate && date <= maxDate)
                {
                    return true;
                }
                return false;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
        }
    }
}
