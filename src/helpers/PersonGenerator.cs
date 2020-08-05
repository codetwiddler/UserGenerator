using System;
using System.Collections.Generic;
using System.Text;
using UserGenerator.Entities;
using UserGenerator.Helpers;

namespace UserGenerator.Helpers
{
    static class PersonGenerator
    {
        public static IEnumerable<Person> GetPeople (List<string> listOfWords, List<string> listOfFirstNames, List<string> listOfLastNames, int populationSize)
        {
            List<Person> people = new List<Person>();

            for (int i = 0; i < populationSize; i++ ) {
                string randomWord = listOfWords.RandomElement();
                string randomFirstName = listOfFirstNames.RandomElement();
                string randomLastName = listOfLastNames.RandomElement();

                people.Add(new Person()
                {
                    MarkerWord = randomWord,
                    NameFirst = randomFirstName,
                    NameLast = randomLastName,
                });
            }

            return people;
        }
    }
}
