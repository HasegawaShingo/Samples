
namespace SampleNUnit;
public class Class1
{

    /// <summary>
    /// NUnitお試し用
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static int Sum(int a, int b)
    {
        return a + b;
    }

    /// <summary>
    /// いきなり難易度上げる
    /// </summary>
    /// <param name="soureLines"></param>
    /// <returns></returns>
    public static List<List<string>> GetColumns(List<string> sourceLines)
    {
        if (sourceLines == null || sourceLines.Count == 0)
            throw new ArgumentNullException(nameof(sourceLines));

        var result = new List<List<string>>();

        foreach(var line in sourceLines)
        {
            // コンマで分割
            var columns = line.Split(',');
            result.Add(columns.ToList());
        }

        return result;
    }

    /// <summary>
    /// 外部のファイルを読んで、読み込んだ行リストを返します。
    /// </summary>
    /// <param name="filePath">読み込むファイルのパスを指定</param>
    /// <returns></returns>
    public static List<string> ReadLines(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException(filePath);

        return File.ReadAllLines(filePath).ToList();
    }
}
