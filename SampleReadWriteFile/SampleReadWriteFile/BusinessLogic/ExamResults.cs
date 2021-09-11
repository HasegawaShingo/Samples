using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleReadWriteFile.BusinessLogic.Entities;
using SampleReadWriteFile.BusinessLogic.FileAccess;

namespace SampleReadWriteFile.BusinessLogic
{
    public static class ExamResults
    {
        public static async Task<List<ExamResultsEntity>> ReadExamResultsAsync(string inputFilePath, string resultFilePath)
        {
            if (string.IsNullOrWhiteSpace(inputFilePath) || string.IsNullOrWhiteSpace(resultFilePath))
                throw new ArgumentNullException($"{nameof(inputFilePath)} or {nameof(resultFilePath)}");

            // 入力ファイルと結果ファイルの読み込み
            var readInputFileTask = Task.Run(() => ReadFile.ReadAsync(inputFilePath));
            var readResultFileTask = Task.Run(() => ReadFile.ReadAsync(resultFilePath));

            var resultTask = await Task.WhenAll(readInputFileTask, readResultFileTask);

            List<ExamResultsEntity> resultEntities;

            // 入力ファイルをエンティティ化
            if (readInputFileTask.Result == null || readInputFileTask.Result.Count == 0)
            {
                return null;
            }
            else
            {
                resultEntities = InputListToEntity(readInputFileTask.Result);

                // 入力ファイルに行がなかった場合はnullを返して終了
                if (resultEntities.Count == 0)
                    return null;
            }

            // 結果ファイルをエンティティに追加
            if (readResultFileTask.Result == null)
            {
                return resultEntities;
            }
            else
            {
                try
                {
                    resultEntities = ResultListToEntity(resultEntities, readResultFileTask.Result);
                }
                catch
                {
                    return null;
                }
            }

            return resultEntities;
        }

        private static List<ExamResultsEntity> InputListToEntity(List<string> sourceLine)
        {
            var resultEntities = new List<ExamResultsEntity>();

            foreach(var line in sourceLine)
            {
                var columns = line.Split(',');
                if (columns.Length != 7)
                    throw new NotSupportedException(line);

                resultEntities.Add(
                    new ExamResultsEntity()
                    {
                        ManageID = Convert.ToInt32(columns[0]),
                        Name = columns[1],
                        JapaneseScore = Convert.ToInt32(columns[2]),
                        EnglishScore = Convert.ToInt32(columns[3]),
                        MathScore = Convert.ToInt32(columns[4]),
                        ScienceScore = Convert.ToInt32(columns[5]),
                        SocialScore = Convert.ToInt32(columns[6])
                    });
            }

            return resultEntities;
        }

        private static List<ExamResultsEntity> ResultListToEntity(List<ExamResultsEntity> examResultsEntities, List<string> sourceLines)
        {
            if (examResultsEntities == null || examResultsEntities.Count == 0)
                throw new ArgumentNullException(nameof(examResultsEntities));

            if (sourceLines == null || sourceLines.Count == 0)
                return examResultsEntities;

            foreach(var line in sourceLines)
            {
                var columns = line.Split(',');
                if (columns.Length != 4)
                    continue;

                foreach(var entity in examResultsEntities)
                {
                    if(entity.ManageID==Convert.ToInt32(columns[0]) && entity.Name == columns[1])
                    {
                        entity.AverageScore = Convert.ToDouble(columns[2]);
                        entity.Status = columns[3];
                        continue;
                    }
                }
            }

            return examResultsEntities;
        }
    }
}
