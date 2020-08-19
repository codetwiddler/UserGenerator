using System;
using System.Collections.Generic;
using System.Linq;
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

                //this is not exactly securely random like, at all... But it's fast.
                people.Add(new Person()
                {
                    MarkerWord = listOfWords.RandomElement() + listOfWords.RandomElement(),
                    NameFirst = listOfFirstNames.RandomElement(),                
                    NameLast = listOfLastNames.RandomElement()
                });
            }

            return people;
        }
    }
}
