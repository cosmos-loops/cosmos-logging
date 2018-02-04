using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Cosmos.Logging;
using Cosmos.Logging.Events;
using Cosmos.Logging.MessageTemplates;
using Cosmos.Logging.Sinks.SampleLogSink;
using Microsoft.Extensions.Configuration;

namespace Cosmos.Loggings.MessageTemplateTokenTests {
    class Program {

        static void Preheater(MessageTemplateCachePreheater preheater) {
            preheater.Add("token test: {@Hello}, {0}, {@World}");
            preheater.Add("token test: {@Hello}, {0}, {@World}1");
            preheater.Add("token test: {@Hello:U}, {0:U}, {@World},{1}, {$ConsoleHelloWorld}, {$Hello}, {@Alewix}, {3}");
        }

        static object SyncLock = new object();

        static void Main(string[] args) {
            try {
                var root = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true).Build();


                LOGGER.Initialize(root).RunsOnConsole()
                    .PreheatMessageTemplates(Preheater)
                    .AddSampleLog(s => s.UseMinimumLevel(LogEventLevel.Information))
                    .AllDone();

                var logger = LOGGER.GetLogger<Program>();
//                lock (SyncLock) {
//                    //Text token
//                    logger.Information("text token test--> {{1.helloworld");
//                    logger.Information("text token test--> {{2.helloworld}");
//                    logger.Information("text token test--> {{3.helloworld}}");
//                    logger.Information("text token test--> {{4.helloworld}lewis");
//                    logger.Information("text token test--> {{5.helloworld}lewis");
//                    logger.Information("text token test--> {{6.helloworld}}lewis");
//                }
//
//                lock (SyncLock) {
//                    //format token for $
//                    logger.Information("$ format test--> {$01.TokenBody");
//                    logger.Information("$ format test--> {$02.TokenBody:");
//                    logger.Information("$ format test--> {$03.TokenBody}");
//                    logger.Information("$ format test--> {$04.TokenBody:}");
//                    logger.Information("$ format test--> {$05.TokenBody ");
//                    logger.Information("$ format test--> {$06.TokenBody");
//                    logger.Information("$ format test--> {$07.TokenBody:Format");
//                    logger.Information("$ format test--> {$08.TokenBody:Format:");
//                    logger.Information("$ format test--> {$09.TokenBody:Format}");
//                    logger.Information("$ format test--> {$10.TokenBody:Format:}");
//                    logger.Information("$ format test--> {$11.TokenBody other text");
//                    logger.Information("$ format test--> {$12.TokenBody}other text");
//                    logger.Information("$ format test--> {$13.TokenBody: other text");
//                    logger.Information("$ format test--> {$14.TokenBody:}other text");
//                    logger.Information("$ format test--> {$15.TokenBody:Format other text");
//                    logger.Information("$ format test--> {$16.TokenBody:Format}other text");
//                    logger.Information("$ format test--> {$17.TokenBody:Format: other text");
//                    logger.Information("$ format test--> {$18.TokenBody:Format:}other text");
//                }
//
//                lock (SyncLock) {
//                    //params token for $
//                    logger.Information("$ params test--> {$19.TokenBody:Format:params");
//                    logger.Information("$ params test--> {$20.TokenBody:Format:params:");
//                    logger.Information("$ params test--> {$21.TokenBody:Format:params}");
//                    logger.Information("$ params test--> {$22.TokenBody:Format:params:}");
//                    logger.Information("$ params test--> {$23.TokenBody:Format:params other text");
//                    logger.Information("$ params test--> {$24.TokenBody:Format:params}other text");
//                    logger.Information("$ params test--> {$25.TokenBody:Format:params: other text");
//                    logger.Information("$ params test--> {$26.TokenBody:Format:params:}other text");
//                }
//
//                lock (SyncLock) {
//                    //format token for @
//                    logger.Information("@ format test--> {@101.TokenBody");
//                    logger.Information("@ format test--> {@102.TokenBody:");
//                    logger.Information("@ format test--> {@103.TokenBody}");
//                    logger.Information("@ format test--> {@104.TokenBody:}");
//                    logger.Information("@ format test--> {@105.TokenBody ");
//                    logger.Information("@ format test--> {@106.TokenBody");
//                    logger.Information("@ format test--> {@107.TokenBody:Format");
//                    logger.Information("@ format test--> {@108.TokenBody:Format:");
//                    logger.Information("@ format test--> {@109.TokenBody:Format}");
//                    logger.Information("@ format test--> {@110.TokenBody:Format:}");
//                    logger.Information("@ format test--> {@111.TokenBody other text");
//                    logger.Information("@ format test--> {@112.TokenBody}other text");
//                    logger.Information("@ format test--> {@113.TokenBody: other text");
//                    logger.Information("@ format test--> {@114.TokenBody:}other text");
//                    logger.Information("@ format test--> {@115.TokenBody:Format other text");
//                    logger.Information("@ format test--> {@116.TokenBody:Format}other text");
//                    logger.Information("@ format test--> {@117.TokenBody:Format: other text");
//                    logger.Information("@ format test--> {@118.TokenBody:Format:}other text");
//                }
//
//                lock (SyncLock) {
//                    //params token for @
//                    logger.Information("@ params test--> {@119.TokenBody:Format:params");
//                    logger.Information("@ params test--> {@120.TokenBody:Format:params:");
//                    logger.Information("@ params test--> {@121.TokenBody:Format:params}");
//                    logger.Information("@ params test--> {@122.TokenBody:Format:params:}");
//                    logger.Information("@ params test--> {@123.TokenBody:Format:params other text");
//                    logger.Information("@ params test--> {@124.TokenBody:Format:params}other text");
//                    logger.Information("@ params test--> {@125.TokenBody:Format:params: other text");
//                    logger.Information("@ params test--> {@126.TokenBody:Format:params:}other text");
//                }
//
//                logger.Information("token test--> {{alexLEWIS} }.}}..{$123}.{$123WithSpace ...{$456:000}.{$789:111:333}nice{@999}{{$12333}");
//                logger.Information("token test--> alexLEWIS {$1234567890:");
//                logger.Information("token test--> {$789:111:3[ ]33}");
//                logger.Information("token test--> forerunner {$ErrorToken:ErrorFormat:ErrorParams");


//                logger.LogInformation(@"
//
//Google、{{AWS}}和{@Azure}都已经发表了声明，{$ConsoleHelloWorld:jpr30w}，说道：
//“我们的云（基本上）已经打好了补丁，现在轮到你们为虚拟机操作系统打补丁了”。
//遗憾的是，对于为什么要同{时}对虚拟机管理程序和虚拟机操作系统打补丁，他们没有提供多少细节。
//安全研究人员Katie Moussouris援引了Robert O'Callahan博文中的一段话：{$Memeda ,
//“对于CPU供应商和云供应商而言，重要的是准确地说明他们采取了什么防范措施，
//什么攻击他们无法防范以及他们期望下游客户负责解决哪些问题”。
//AWS在声明中明确表示，“我们会保障客户的实例不会受到来自其他实例的威胁”。
//这意味着，VM操作系统仍然需要打补丁来防止App之间的攻击或者对特定VM内核的攻击，
//来自{$Amazon:yyyyMMdd[ ]HH[:]mm[:]ss}的Richard Harvey对此进行了确认。
//
//");

//                logger.LogInformation("position test{10}");
//                logger.LogInformation("position test{10} ");
//                logger.LogInformation("position test{10:}");
//                logger.LogInformation("position test{10:} ");
//                logger.LogInformation("position test{10::}");
//                logger.LogInformation("position test{10::} ");
//                logger.LogInformation("position test{10:w}");
//                logger.LogInformation("position test{10:w:} ");

                Stopwatch sw = new Stopwatch();
                sw.Start();
                logger.LogInformation("{$Date::yyyy年MM月dd日} token test: {@Hello:U}, {0:U}, {@World},{1}, {$ConsoleHelloWorld}, {$Hello}, {@Alewix}, {3}", new {Hello = "_hello_"},
                    "?world?");
                logger.LogInformation("token test: {@Hello}, {0}, {@World}？？？？？", paramObjects: new Object[] {new {Hello = "_hello_", World = "_world_"}, "?world?"});

                using (var scope = logger.BeginScope("123")) {
                    logger.LogInformation("token test: {@Hello}, {0}, {@World}");
                }

                sw.Stop();
                Console.WriteLine($"1:{sw.ElapsedMilliseconds}");
                sw.Restart();
                logger.LogInformation("{$Date::yyyy年MM月dd日} token test: {@Hello:U}, {0:U}, {@World},{1}, {$ConsoleHelloWorld}, {$Hello}, {@Alewix}, {3}", new {Hello = "_hello_"},
                    "?world?");
                logger.LogInformation("token test: {@Hello}, {0}, {@World}", new {Hello = "_hello_", World = "_world_"}, "?world?");

                using (var scope = logger.BeginScope("123")) {
                    logger.LogInformation("token test: {@Hello}, {0}, {@World}");
                }

                sw.Stop();
                Console.WriteLine($"2:{sw.ElapsedMilliseconds}");

                Thread.Sleep(TimeSpan.FromSeconds(4));
                sw.Restart();
                logger.LogInformation("{$Date::yyyy年MM月dd日} token test: {@Hello:U}, {0:U}, {@World},{1}, {$ConsoleHelloWorld}, {$Hello}, {@Alewix}, {3}", new {Hello = "_hello_"},
                    "?world?");
                logger.LogInformation("token test: {@Hello}, {0}, {@World}", new {Hello = "_hello_", World = "_world_"}, "?world?");

                using (var scope = logger.BeginScope("123")) {
                    logger.LogInformation("token test: {@Hello}, {0}, {@World}");
                }

                sw.Stop();
                Console.WriteLine($"3:{sw.ElapsedMilliseconds}");
                Console.WriteLine("I'm live");
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Source);

                Console.WriteLine(e.StackTrace);
            }

            Console.ReadLine();
        }
    }
}