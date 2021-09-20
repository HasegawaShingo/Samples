using System.Reflection;
using NUnit.Framework;

namespace TestProject1;
public class Tests
{
    // NUnitを使ってみよう！

    [SetUp]
    public void Setup()
    {
    }

    /// <summary>
    /// 一回だけの場合
    /// </summary>
    [Test]
    public void Test1()
    {
        var actual = SampleNUnit.Class1.Sum(1, 5);
        Assert.AreEqual(actual, 6);
    }

    /// <summary>
    /// テストケースを使ったテスト。最小、最大、境界値なんかによいね。
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="expected"></param>
    [TestCase(100, 200, 300)]
    [TestCase(1, 2, 3)]
    public void Test2(int a, int b, int expected)
    {
        Assert.AreEqual(SampleNUnit.Class1.Sum(a, b), expected);
    }

    /// <summary>
    /// これでも良い。
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [TestCase(100, 200, ExpectedResult = 300)]
    [TestCase(1, 2, ExpectedResult = 3)]
    public int test3(int a, int b)
    {
        return SampleNUnit.Class1.Sum(a, b);
    }


    // このテストケースならとおる
    [TestCaseSource("test5_casesource")]
    public void test5(List<string> testData)
    {
        Assert.Pass();
    }

    static IList<object> test5_casesource = new List<object>
    {
        new object[] { new List<string> { "1,1,あああ,1" } }
    };

    // これもOK
    [TestCaseSource("test6_caseset")]
    public void test6(List<string> testData, List<List<string>> expected)
    {
        Assert.Pass();
    }

    // ジャグ配列にテストメソッドの引数を格納していく感じ
    static object[][] test6_caseset()
    {
        // create testdata
        var testdata = new List<string> { "1,1,あああ,1" };

        // create expected data
        var expected = new List<List<string>>();
        var expectedData = new List<string> { "1", "1", "あああ", "1" };
        expected.Add(expectedData);

        // create return object
        object[][] result = { new object[] { testdata, expected } };
        return result;
    }


    [TestCaseSource("test7_caseset")]
    public void test7(string filePath, List<string> expectedReadLines)
    {
        var actual = SampleNUnit.Class1.ReadLines(filePath);
        CollectionAssert.AreEqual(actual, expectedReadLines);
    }

 
    static object[][] test7_caseset()
    {
        // リソースから実行フォルダにフォルダ作って、ファイルを書き出してあげるのが一番簡単そう。
        var currentPath = Directory.GetCurrentDirectory();
        var resourceFolderPath = Path.Combine(currentPath, @"..\..\..\TestInputFile");
        var absoluteResoucePath = new Uri(resourceFolderPath).AbsolutePath;

        var testFolder = Path.Combine(currentPath, "TestInputFile");
        if (Directory.Exists(testFolder))
            Directory.Delete(testFolder, true);

        Directory.CreateDirectory(testFolder);
        foreach(var file in Directory.GetFiles(absoluteResoucePath))
        {
            File.Copy(file, Path.Combine(testFolder, Path.GetFileName(file)), true);
        }

        // ここまではテストクラスの初期化時に一回だけ実行するればよろし。
        // こんな感じであれば、テスト実行の環境に依存せずに、コミットしているフォルダーの構成を
        // 変えない限り、どの開発環境でも実行出来る。

        var testFile = Path.Combine(testFolder, $"{nameof(Resource.Source1)}.txt");

        var expectedList = new List<string> { Resource.Source1 };

        object[][] result =
        {
            new object[]{testFile, expectedList }
        };
        return result;
    }
}