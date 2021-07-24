using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;

namespace SampleLog4net
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// ロガー
        /// </summary>
        private readonly ILog Logger;

        /// <summary>
        /// コンストラクタでロガーを設定します。
        /// </summary>
        /// <param name="logger">ロガーインスタンスを指定してください。</param>
        public Form1(ILog logger)
        {
            InitializeComponent();
            Logger = logger;
        }

        /// <summary>
        /// フォーム読み込み時にInfoレベルでログを書き出します。
        /// </summary>
        /// <param name="sender">イベント発行元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            Logger.Info("Load Main form.");
        }

        /// <summary>
        /// ボタンポチっとなで、Taskを動かしつつログを出力します。
        /// </summary>
        /// <param name="sender">イベント発行元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private async void Button1_ClickAsync(object sender, EventArgs e)
        {
            Logger.Info("Start async methods.");

            var commandTask1 = Task.Run(() => Command1Async());
            var commandTask2 = Task.Run(() => Command2Async());

            var result = await Task.WhenAll(commandTask1, commandTask2);

            Logger.Info("End async methods.");
            MessageBox.Show("処理が終了しました。");
        }

        /// <summary>
        /// 非同期のタスクメソッド（その1）
        /// 5秒待ちます。（その前後にログを出力します。）
        /// </summary>
        /// <returns>trueを返します。</returns>
        private async Task<bool> Command1Async()
        {
            Logger.Info("Command1 delay start.");
            await Task.Delay(5000);
            Logger.Info("Command1 delay end.");
            return true;
        }

        /// <summary>
        /// 非同期のタスクメソッド（その2）
        /// 10秒待ちます。（その前後にログを出力します。）
        /// </summary>
        /// <returns>trueを返します。</returns>
        private async Task<bool> Command2Async()
        {
            Logger.Info("Command2 delay start.");
            await Task.Delay(10000);
            Logger.Info("Command2 delay end.");
            return true;
        }
    }
}
