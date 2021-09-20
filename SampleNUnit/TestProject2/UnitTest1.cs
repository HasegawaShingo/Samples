using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using NUnit.Framework;

namespace TestProject2
{
    public class Tests
    {
        string TestSourceDirectoryPath;

        [SetUp]
        public void Setup()
        {
            // 入力ファイルを実行フォルダ内にコピーします。
            // 特に、入力に対する出力ファイルがある場合なんかは、これで初期化しないと前試験のファイルが残っちゃう。
            var sourceTestFilePath = @"..\..\..\TestInputFile";
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var destinationPath = Path.Combine(assemblyPath, @"TestInputFile");

            var absSourceTestFileURI = new System.Uri(Path.Combine(assemblyPath, sourceTestFilePath)).AbsolutePath;

            if (Directory.Exists(destinationPath))
                Directory.Delete(destinationPath, true);

            Directory.CreateDirectory(destinationPath);

            foreach (var file in Directory.GetFiles(absSourceTestFileURI))
                File.Copy(file, Path.Combine(destinationPath, Path.GetFileName(file)));

            TestSourceDirectoryPath = destinationPath;
        }

        [Test]
        public void Test1()
        {
            // app.configの内容を試験に合わせて書き換え。
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["InputSource"].Value = @".\TestInputFile\HogeHoge1.txt";
            config.Save();
            // 実ファイルから設定を読み取るように、設定の更新をかけます。
            // これをしないと、他の試験で変更された値を使い続けることになりんす。
            ConfigurationManager.RefreshSection("appSettings");

            var target = new SampleNUnit_net48.Form1();
            var actual = target.ReadSourceFile();

            var expected = new List<string>();
            CollectionAssert.AreEqual(actual, expected);
            target.Close();
        }

        [Test]
        public void Test2()
        {
            // app.configの内容を試験に合わせて書き換え。
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["InputSource"].Value = @".\TestInputFile\Source1.txt";
            config.Save();
            // 実ファイルから設定を読み取るように、設定の更新をかけます。
            // これをしないと、他の試験で変更された値を使い続けることになりんす。
            ConfigurationManager.RefreshSection("appSettings");

            var target = new SampleNUnit_net48.Form1();
            var actual = target.ReadSourceFile();

            var expected = new List<string>() { "1,10,100,1000,InputFile1" };
            CollectionAssert.AreEqual(actual, expected);
            target.Close();
        }
    }
}