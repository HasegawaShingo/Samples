using NUnit.Framework;
using System.Threading.Tasks;
using System.IO;
using SampleReadWriteFile.BusinessLogic.Entities;
using SampleReadWriteFile.BusinessLogic;
using System.Collections.Generic;
using System.Linq;

namespace SampleReadWriteFileTest
{
    public class ExamResultsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task ReadExamResultsAsyncTest_1()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "SampleInputSource");
            var inputFilePath = Path.Combine(filePath, "InputSource.txt");
            var resultFilePath = Path.Combine(filePath, "Dummy.txt");

            var expectedEntities = new List<ExamResultsEntity>()
            {
                // manageid, name, japanese, english, math, science, social
                new ExamResultsEntity(){ ManageID=1, Name="山田　一郎", JapaneseScore=80, EnglishScore=75, MathScore=80, ScienceScore=70, SocialScore=75},
                new ExamResultsEntity(){ ManageID=2, Name="鈴木　二郎", JapaneseScore=70, EnglishScore=75, MathScore=70, ScienceScore=75, SocialScore=80},
                new ExamResultsEntity(){ ManageID=3, Name="本田　三郎", JapaneseScore=85, EnglishScore=80, MathScore=85, ScienceScore=90, SocialScore=85},
                new ExamResultsEntity(){ ManageID=4, Name="豊田　四郎", JapaneseScore=80, EnglishScore=80, MathScore=85, ScienceScore=90, SocialScore=90},
                new ExamResultsEntity(){ ManageID=5, Name="山本　五郎", JapaneseScore=90, EnglishScore=90, MathScore=85, ScienceScore=85, SocialScore=90},
                new ExamResultsEntity(){ ManageID=6, Name="田中　六郎", JapaneseScore=100, EnglishScore=90, MathScore=100, ScienceScore=90, SocialScore=95}
            };

            var expected = ObjectToList(expectedEntities);

            var actualEntities = await ExamResults.ReadExamResultsAsync(inputFilePath, resultFilePath);
            var actual = ObjectToList(actualEntities);

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// オブジェクトを文字列リストに変換します。
        /// </summary>
        /// <param name="examResultsEntities">変換対象のオブジェクトを指定してください。</param>
        /// <returns>カラムリストで構成されたエンティティのリストを返します。</returns>
        private List<List<string>> ObjectToList(List<ExamResultsEntity> examResultsEntities)
        {
            var result = new List<List<string>>();
            foreach(var entity in examResultsEntities)
            {
                var properties = entity.GetType().GetProperties();
                var values = properties.Select(e => typeof(ExamResultsEntity).GetProperty(e.Name).GetValue(entity).ToString()).ToList();
                result.Add(values);
            }

            return result;
        }
    }
}