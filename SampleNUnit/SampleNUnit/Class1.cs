
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
}
