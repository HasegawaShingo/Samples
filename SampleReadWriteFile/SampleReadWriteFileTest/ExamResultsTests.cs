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
                new ExamResultsEntity(){ ManageID=1, Name="�R�c�@��Y", JapaneseScore=80, EnglishScore=75, MathScore=80, ScienceScore=70, SocialScore=75},
                new ExamResultsEntity(){ ManageID=2, Name="��؁@��Y", JapaneseScore=70, EnglishScore=75, MathScore=70, ScienceScore=75, SocialScore=80},
                new ExamResultsEntity(){ ManageID=3, Name="�{�c�@�O�Y", JapaneseScore=85, EnglishScore=80, MathScore=85, ScienceScore=90, SocialScore=85},
                new ExamResultsEntity(){ ManageID=4, Name="�L�c�@�l�Y", JapaneseScore=80, EnglishScore=80, MathScore=85, ScienceScore=90, SocialScore=90},
                new ExamResultsEntity(){ ManageID=5, Name="�R�{�@�ܘY", JapaneseScore=90, EnglishScore=90, MathScore=85, ScienceScore=85, SocialScore=90},
                new ExamResultsEntity(){ ManageID=6, Name="�c���@�Z�Y", JapaneseScore=100, EnglishScore=90, MathScore=100, ScienceScore=90, SocialScore=95}
            };

            var expected = ObjectToList(expectedEntities);

            var actualEntities = await ExamResults.ReadExamResultsAsync(inputFilePath, resultFilePath);
            var actual = ObjectToList(actualEntities);

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// �I�u�W�F�N�g�𕶎��񃊃X�g�ɕϊ����܂��B
        /// </summary>
        /// <param name="examResultsEntities">�ϊ��Ώۂ̃I�u�W�F�N�g���w�肵�Ă��������B</param>
        /// <returns>�J�������X�g�ō\�����ꂽ�G���e�B�e�B�̃��X�g��Ԃ��܂��B</returns>
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